
from pathlib import *
from typing import List, Union
import numpy as np
import itertools
import pandas as pd
from collections import Counter 
import seaborn as sns
import matplotlib.pyplot as plt 

models = ["GPT-4o-mini", "deepseek-coder-6.7b-instruct", "gemma-7b-it", "codegemma-7b-it", "Llama-2-7b-chat-hf", "CodeLlama-7b-Instruct"]
# "deepseek-coder-6.7b-instruct", , "codegemma-7b-it",  "Llama-2-7b-chat-hf", "CodeLlama-7b-Instruct"

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

def get_problem_from_prompt(s):
    parts = s.split('/')
    return parts[0]

# mode_list = ["Random-3", "Random-5", "Random-7", "Random-10"]
remove_problem = ["2", "4", "8", "90", "101", "S2L1", "S2L3", "S4L4"] #, "S1L1", "S1L5", "S3L1", "S3L2", "S4L1", "S4L4", "S4L5"]

def prepare4calculate(testing_df, mode):
    testing_df['prompt'] = testing_df['code_file'].apply(extract_prompt)
    testing_df['problem'] = testing_df['code_file'].apply(extract_problem)
    testing_df['mode'] = testing_df['code_file'].apply(extract_mode)
    testing_df['answer'] = testing_df['code_file'].apply(extract_answer)
    consider_df = testing_df
    # print("consider:", consider_df.shape[0])
    records = consider_df[consider_df['mode'].str.contains(mode)]
    records = records[~records['problem'].isin(remove_problem)]
    # print(f"in mode {mode}:", records.shape[0])

    # print(mode, records.shape[0], records['prompt'].nunique(), records['answer'].nunique())
    check_df = records[['prompt', 'answer']]
    size_p = check_df.groupby('prompt')['answer'].nunique()
    lessthan10 = size_p[size_p != 10]
    if (lessthan10.shape[0] != 0):
        print("find error! there are some problem gets less than 10 answers")
    remove_prompts = lessthan10.index.tolist()
    records = records[~records['prompt'].isin(remove_prompts)]
    # print(mode, records.shape[0], records['prompt'].nunique(), records['answer'].nunique())
    
    records['shot'] = False
    # print(records)
    answer_groups = records.groupby('answer')
    for answer, group in answer_groups:
        # print(group['result'])
        if group['result'].str.contains('Success').any():
            records.loc[records['answer'] == answer, 'shot'] = True
    # print(records.columns)
    prompt_result = records[["answer", "prompt", "shot"]].drop_duplicates()
    prompt_groups = prompt_result.groupby('prompt')
    samples = []
    corrects = []
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
    
    return samples, corrects

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

def plot_df(stat_dict):
    model_lst = []
    set_lst = []
    x_lst = []
    # y_lst = []
    for model2setting, data in stat_dict.items():
        model, setting = model2setting.split('--')

        model_lst += [model] * len(data)
        set_lst += [setting] * len(data)
        x_lst += data


        # print(model, setting)
        # counts = [0] * 11
        # for num in data:
        #     if 0 <= num <= 10:
        #         counts[num] += 1
        # total = 0
        
        # for i, count in enumerate(counts):
        #     total += count
        #     x_lst.append(i)
        #     y_lst.append(total/len(data))
        #     model_lst.append(model)
        #     set_lst.append(setting)
    
    df = pd.DataFrame({
        'setting': set_lst,
        'model': model_lst,    
        'value': x_lst})

    return df



Benchmarks = ["HumanEval", "HumanEval-2", "CodeHunt"]
settings = ["Random-3", "Random-5", "Random-7", "Random-10"]
separate_answer_dict = {}
total_dict = {}
for setting in settings:   
    total_dict[setting] = [] 
    for model in models:
        model_dir = Path("group1-round2/before-asking") / model
        result_df = pd.DataFrame(columns=['code_file', 'result'])
        for benchmark in Benchmarks:
            # print(benchmark)
            benchmark_result_dir = model_dir / benchmark
            testing_file = benchmark_result_dir /"whether_need_pex_info.txt"
            one_df = pd.read_csv(testing_file, sep=":", header=None, names=["code_file", "result"])
            result_df = pd.concat([result_df, one_df], axis=0, ignore_index=True)
            # print(result_df.shape[0])
        model_samples, model_success = prepare4calculate(result_df, setting)
        # print(len(model_samples), len(model_success))
        total_dict[setting].append(model_success)
    # print(len(model_samples), len(model_success))

# 创建一个1x4的图形
fig, axs = plt.subplots(1, 4, figsize=(16, 6))

def plot_multiple_cdfs(data_groups, ax, title, labels):
    for data, label in zip(data_groups, labels):
        pass10 = estimate_pass_at_k(10, data, 1)
        # print(pass10)
        # 将list转换为numpy数组以便处理
        sorted_data = np.sort(np.array(pass10))
        # print(sorted_data)
        zero_count = np.sum(sorted_data == 0) 
        print(label, zero_count / len(sorted_data))
        # 计算CDF
        cdf = np.arange(1, len(sorted_data) + 1) / len(sorted_data)
        # print(cdf)
        # 绘制CDF
        ax.plot(sorted_data, cdf, label=formalize_name(label))
    ax.set_title(title)
    ax.set_xlabel("Pass@1 Value")
    ax.set_ylabel("The Cumulative Distribution of Pass@1 Value")
    ax.legend()
    ax.grid(color='gray', linestyle='--', linewidth=0.5)

# 绘制每组数据的多组CDF
plot_multiple_cdfs(total_dict["Random-3"], axs[0], 'NoE=3', models)
plot_multiple_cdfs(total_dict["Random-5"], axs[1], 'NoE=5', models)
plot_multiple_cdfs(total_dict["Random-7"], axs[2], 'NoE=7', models)
plot_multiple_cdfs(total_dict["Random-10"], axs[3], 'NoE=10', models)

# 调整布局
plt.tight_layout()
plt.show()
# g.set_axis_labels("Number of Correct Attempts", "Cumulative Distribution Function Value")

plt.savefig('ecdf_plot.png', format='png')
plt.savefig('cdf_plots.pdf', format='pdf')

