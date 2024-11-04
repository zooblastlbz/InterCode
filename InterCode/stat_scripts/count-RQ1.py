
from pathlib import *
from typing import List, Union
import numpy as np
import itertools
import pandas as pd
from collections import Counter  

models = ["GPT-4o-mini", "deepseek-coder-6.7b-instruct", "gemma-7b-it", "codegemma-7b-it", "Llama-2-7b-chat-hf", "CodeLlama-7b-Instruct"]
# "deepseek-coder-6.7b-instruct", , "codegemma-7b-it",  "Llama-2-7b-chat-hf", "CodeLlama-7b-Instruct"
# test_root = Path("UnitTest-CodeHunt")
# consider_problems = []
# for problem in test_root.iterdir():
#     if not problem.is_dir() or problem.name.startswith('.'):
#         continue
#     consider_problems.append(problem.name)



def estimate_pass_at_k(
    num_samples: Union[int, List[int], np.ndarray],
    num_correct: Union[List[int], np.ndarray],
    k: int
) -> np.ndarray:
    """
    Estimates pass@k of each problem and returns them in an array.
    """

    def estimator(n: int, c: int, k: int) -> float:
        """
        Calculates 1 - comb(n - c, k) / comb(n, k).
        """
        if n - c < k:
            return 1.0
        return 1.0 - np.prod(1.0 - k / np.arange(n - c + 1, n + 1))

    if isinstance(num_samples, int):
        num_samples_it = itertools.repeat(num_samples, len(num_correct))
    else:
        assert len(num_samples) == len(num_correct)
        num_samples_it = iter(num_samples)

    return np.array([estimator(int(n), int(c), k) for n, c in zip(num_samples_it, num_correct)])

def extract_prompt(s):
    parts = s.split('/')
    if parts[1] == "code":
        parts = parts[1:]
    answer = parts[2] + '/' + parts[3]
    prompt = answer.split('.answer')[0]
    return prompt

def extract_problem(s):
    parts = s.split('/')
    if parts[1] == "code":
        parts = parts[1:]
    problem = parts[2]
    return problem

def extract_mode(s):
    parts = s.split('/')
    if parts[1] == "code":
        parts = parts[1:]
    mode = parts[1]
    return mode

def extract_answer(s):
    parts = s.split('/')
    if parts[1] == "code":
        parts = parts[1:]
    answer = parts[2] + '/' + parts[3]
    return answer

def whether_input_match(row):
    code_file_relative_path = row["code_file"].split(' ')[1]
    input_num = int(row["mode"].split('-')[1])
    code_file = Path("group1-round1/after-compile") / model / code_file_relative_path
    # print(input_num)
    # print(code_file, code_file.exists())
    with open(code_file) as f:
        code_lines = f.readlines()
    count_if = 0
    count_case = 0
    for line in code_lines:
        if ("if" in line) and ("==" in line):
            count_if += 1
        elif ("case" in line):
            count_case += 1
    if count_if == input_num or count_if == input_num - 1:
        return True
    if count_case == input_num or count_case == input_num - 1:
        return True
    return False
    
def remove_input_match(row):
    flag = row["is_matching"]
    old_result = row["result"]
    if flag:
        return "Fail! use input matching"
    return old_result  
        

name_dict = {
    "GPT-4o-mini": "GPT-4o-mini",
    "deepseek-coder-6.7b-instruct": "Deepseek-Coder-6.7b-instruct",
    "gemma-7b-it":  "Gemma-7b-it",
    "codegemma-7b-it": "CodeGemma-7b-it",
    "Llama-2-7b-chat-hf": "Llama-2-7b-chat",
    "CodeLlama-7b-Instruct": "CodeLlama-7b-Instruct"
}

def formalize_name(old_name):
    return name_dict[old_name]



mode_list = ["Random-3", "Random-5", "Random-7", "Random-10"]
remove_problem = ["2", "4", "8", "90", "101", "S2L1", "S2L3", "S4L4"] #, "S1L1", "S1L5", "S3L1", "S3L2", "S4L1", "S4L4", "S4L5"]

def prepare4calculate(testing_df):
    dict4cal = {}    
    testing_df['prompt'] = testing_df['code_file'].apply(extract_prompt)
    testing_df['problem'] = testing_df['code_file'].apply(extract_problem)
    testing_df['mode'] = testing_df['code_file'].apply(extract_mode)
    testing_df['answer'] = testing_df['code_file'].apply(extract_answer)

    # # remove those use input-matching
    testing_df['is_matching'] = testing_df.apply(whether_input_match, axis=1) 
    testing_df['result'] = testing_df.apply(remove_input_match, axis=1) 

    

    consider_df = testing_df

    for mode in mode_list:
        records = consider_df[consider_df['mode'].str.contains(mode)]
        records = records[~records['problem'].isin(remove_problem)]
        
        check_df = records[['prompt', 'answer']]
        size_p = check_df.groupby('prompt')['answer'].nunique()
        lessthan10 = size_p[size_p != 10]
        if (lessthan10.shape[0] != 0):
            print("find error! there are some problem gets less than 10 answers")
        remove_prompts = lessthan10.index.tolist()
        records = records[~records['prompt'].isin(remove_prompts)]

        records['shot'] = False
        answer_groups = records.groupby('answer')
        for answer, group in answer_groups:
            if group['result'].str.contains('Success').any():
                records.loc[records['answer'] == answer, 'shot'] = True
        prompt_result = records[["answer", "prompt", "shot"]].drop_duplicates()
        prompt_groups = prompt_result.groupby('prompt')
        samples = []
        corrects = []
        prompts = []
        for prompt, group in prompt_groups:
            prompt_result_list = group['shot'].tolist()
            sample_num = len(prompt_result_list)
            correct_num = prompt_result_list.count(True)
            correct_numm = group['shot'].sum()
            if not (correct_num == correct_numm):
                print("count error!")
            if sample_num!=10:
                print(f'{prompt} ??')
            samples.append(sample_num)
            corrects.append(correct_num)
            prompts.append(prompt)
        dict4cal[mode] = [samples, corrects, prompts]
    return dict4cal



    
# produce pass@k the table
Benchmarks = ["HumanEval", "HumanEval-2", "CodeHunt"]
separate_answer_dict = {}
for model in models:
    # print(model)
    model_dir = Path("group1-round2/before-asking") / model
    result_df = pd.DataFrame(columns=['code_file', 'result'])
    line = [formalize_name(model)]
    for benchmark in Benchmarks:
        benchmark_result_dir = model_dir / benchmark
        testing_file = benchmark_result_dir /"whether_need_pex_info.txt"
        one_df = pd.read_csv(testing_file, sep=":", header=None, names=["code_file", "result"])
        result_df = pd.concat([result_df, one_df], axis=0, ignore_index=True)
        # print(result_df.shape[0])

    model_results_dict = prepare4calculate(result_df)
    for setting, setting_result in model_results_dict.items():
        for k in [1, 5, 10]:
            # key = f"{model}-{setting}-{k}"
            passk = estimate_pass_at_k(setting_result[0], setting_result[1], k).tolist()
            # print(len(passk), len(setting_result[0]))
            # if not key in separate_answer_dict.keys():
            #     separate_answer_dict[key] = passk
            # else:
            #     separate_answer_dict[key] += passk
            line.append(round(sum(passk) / len(passk), 2))
    line = [str(x) for x in line]
    print(' & '.join(line) + '\\\\')



# # get why llama is better than code-llama
# Benchmarks = ["HumanEval", "HumanEval-2", "CodeHunt"]
# separate_answer_dict = {}
# model1 = "CodeLlama-7b-Instruct"
# model2 = "Llama-2-7b-chat-hf"

# model_dir1 = Path("group1-round2/before-asking") / model1
# result_df1 = pd.DataFrame(columns=['code_file', 'result'])
# for benchmark in Benchmarks:
#     benchmark_result_dir = model_dir1 / benchmark
#     testing_file = benchmark_result_dir /"whether_need_pex_info.txt"
#     one_df = pd.read_csv(testing_file, sep=":", header=None, names=["code_file", "result"])
#     result_df1 = pd.concat([result_df1, one_df], axis=0, ignore_index=True)
# model_results_dict1 = prepare4calculate(result_df1)

# model_dir2 = Path("group1-round2/before-asking") / model2
# result_df2 = pd.DataFrame(columns=['code_file', 'result'])
# for benchmark in Benchmarks:
#     benchmark_result_dir = model_dir2 / benchmark
#     testing_file = benchmark_result_dir /"whether_need_pex_info.txt"
#     one_df = pd.read_csv(testing_file, sep=":", header=None, names=["code_file", "result"])
#     result_df2 = pd.concat([result_df2, one_df], axis=0, ignore_index=True)
# model_results_dict2 = prepare4calculate(result_df2)


# for setting, lists in model_results_dict1.items():
#     # print(setting)
#     dct1 = dict(zip(lists[2], lists[1]))  
#     other_lists = model_results_dict2[setting]
#     dct2 = dict(zip(other_lists[2], other_lists[1]))

#     fail_count = 0
#     success_count = 0
#     max_gap = 0
#     for k, v in dct1.items():
#         # print(v, dct2[k])
#         new_gap = dct2[k] - v 
#         if new_gap >= 9:
#             print(setting, k, new_gap)
