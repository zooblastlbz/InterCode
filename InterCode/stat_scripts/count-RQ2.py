
from pathlib import *
from typing import List, Union
import numpy as np
import itertools
import pandas as pd
from collections import Counter  

models = ["GPT-4o-mini", "deepseek-coder-6.7b-instruct", "gemma-7b-it", "codegemma-7b-it", "Llama-2-7b-chat-hf", "CodeLlama-7b-Instruct"] # "GPT-4o-mini"
mode_list = ["Random-3", "Random-5", "Random-7", "Random-10"]
benchmarks = ["HumanEval", "HumanEval-2", "CodeHunt"]
start_result_root = Path("round2/before-asking")
save_csv_root = Path("Iteration-result")
if not save_csv_root.exists():
    Path.mkdir(save_csv_root)


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

# Compiling CodeHunt/code/Random-10/S1L6/Random-2-10.answer-611/Random-2-10.answer-6110.cs
# Compiling CodeHunt/code/Random-10/S4L6/Random-1-10.answer.answer1/Random-1-10.answer.answer11.cs
def extract_key(s):
    # print(s)
    parts = s.split('/')
    setting = parts[2]
    problem = parts[3]
    seed_answer_code = parts[5]
    # print(seed_answer_code)
    arrs = seed_answer_code.split('-')
    seed = arrs[1]
    if len(arrs) > 3:
        answer_idx = arrs[3][0]
        code_idx = arrs[3][1]
    else: 
        tmp_arrs = arrs[-1].split('answer.answer')
        answer_idx = tmp_arrs[-1][0]
        code_idx = tmp_arrs[-1][1]
    tmp_key = "_".join([setting, problem, seed, answer_idx, code_idx])
    return tmp_key
    
def extract_setting(s):
    parts = s.split('/')
    setting = parts[2]
    return setting

def extract_problem(s):
    parts = s.split('/')
    problem = parts[3]
    return problem

def extract_seed(s):
    parts = s.split('/')
    seed_answer_code = parts[5]
    arrs = seed_answer_code.split('-')
    seed = arrs[1]
    return seed

def extract_answer_idx(s):
    parts = s.split('/')
    seed_answer_code = parts[5]
    arrs = seed_answer_code.split('-')
    if len(arrs) > 3:
        answer_idx = arrs[3][0]
    else: 
        tmp_arrs = arrs[-1].split('answer.answer')
        answer_idx = tmp_arrs[-1][0]
    return answer_idx

def extract_code_idx(s):
    parts = s.split('/')
    seed_answer_code = parts[5]
    arrs = seed_answer_code.split('-')
    if len(arrs) > 3:
        code_idx = arrs[3][1]
    else: 
        tmp_arrs = arrs[-1].split('answer.answer')
        code_idx = tmp_arrs[-1][1]
    return code_idx



#  Fail! on given tests
def translation(s):
    s = s.strip()
    if s.startswith("Success! then ask"):
        return "Uk"
    elif s.startswith("Success! by Pex") or s.startswith("Success! special case"):
        return "Su"
    elif s.startswith("Fail!"):
        return "Fa"
    else:
        # print("need handle! ", s)
        return ""

def update_start_df(df, model_name, benchmark_name, round_idx):
    df["key"] = df["code_file"].apply(extract_key)
    df["model"] = model_name
    df["benchmark"] = benchmark_name 
    df["problem"] = df["code_file"].apply(extract_problem)
    df["setting"] = df["code_file"].apply(extract_setting)
    df["seed"] = df["code_file"].apply(extract_seed)
    df["answer_idx"] = df["code_file"].apply(extract_answer_idx)
    df["code_idx"] = df["code_file"].apply(extract_code_idx)
    df["label"] = df["result"].apply(translation)
    df["round"] = 0
    df["key"] += f"_{benchmark_name}"

    df.loc[df['label'] == 'Fa', 'round'] = round_idx
    df.loc[df['label'] == 'Su', 'round'] = round_idx
    ans_result = df[final_columns]
    return ans_result


def get_next_df(df, model_name, benchmark_name, round_idx):
    df["key"] = df["code_file"].apply(extract_key)
    df["label"] = df["result"].apply(translation)
    df["key"] += f"_{benchmark_name}"

    answer_groups = df.groupby('key')
    for key, group in answer_groups:
        if group['label'].str.contains('Su').any():
            df.loc[df['key'] == key, 'label'] = 'Su'
            
        if group['label'].str.contains('Uk').any():
            df.loc[df['key'] == key, 'label'] = 'Uk'
        
    ans_result = df[next_columns].drop_duplicates()

    # df["round"] = df.apply(get_round, axis=1)
    return ans_result


def update_next(total_df, next_dict, round_num):
    for k, v in next_dict.items():
        if not v == 'Uk':
            total_df.loc[(total_df['key'] == k) & (total_df['label'] == 'Uk'), 'label'] = v
            total_df.loc[(total_df['key'] == k) & (total_df['round'] == 0), 'round'] = round_num
    return total_df

def update_group_succ(group):
    if len(group) == 1:
        return group
    if 'Su' in group['label'].values:
        min_round = group.loc[group['label'] == 'Su', 'round'].min()
        group['label'] = 'Su'
        group['round'] = min_round
    return group


def update_group_uk(group):
    if len(group) == 1:
        return group
    if 'Uk' in group['label'].values:
        group['label'] = 'Uk'
        group['round'] = 0
    
    return group


def update_group_fail(group):
    if len(group) == 1:
        return group
    if all(group['label'] == 'Fa'):
        # 找到最大 'round' 值
        max_round = group['round'].max()
        # 更新整个组的 'round'
        group['round'] = max_round
    return group


def merge_code(total_df):
    # print(total_df['round'].dtype)
    total_df['answer_key'] = total_df['benchmark'] + '_' + total_df['problem'] + '_' + total_df['setting'] + '_' + total_df['seed'] + '_' + total_df['answer_idx'] 
    total_df = total_df[["answer_key", "model", "benchmark", "problem", "setting", "seed", "answer_idx",  "label", "round"]].drop_duplicates()
    after_suc_df = total_df.groupby('answer_key', group_keys=False).apply(update_group_succ).reset_index(drop=True)
    after_uk_df = after_suc_df.groupby('answer_key', group_keys=False).apply(update_group_uk).reset_index(drop=True)
    after_fail_df = after_uk_df.groupby('answer_key', group_keys=False).apply(update_group_fail).reset_index(drop=True)


    ans_df = after_fail_df.drop_duplicates()
    return ans_df

if __name__ == "__main__":
    final_columns = ["key", "model", "benchmark", "problem", "setting", "seed", "answer_idx", "code_idx", "label", "round"]
    next_columns = ["key", "label"]
    for model in models:
        final_df = pd.DataFrame(columns=final_columns)
        model_start_result = start_result_root / model
        for benchmark in benchmarks:
            benchmark_start_result = model_start_result / benchmark
            result_file = benchmark_start_result / "info_after_pex_and_special.txt"
            if not result_file.exists():
                print(f"{model} on {benchmark} has not result")
                continue
            with open(result_file) as f:
                lines = f.readlines()
            code_file_list = [x.split(".cs:")[0] for x in lines]
            result_list = [x.split(".cs:")[1] for x in lines]
            start_df = pd.DataFrame({  
                "code_file": code_file_list,  
                "result": result_list ,
            })  
            updated_df = update_start_df(start_df, model, benchmark, 1)
            # print("start", benchmark, updated_df.shape[0])
            final_df = pd.concat([final_df, updated_df], axis=0, ignore_index=True)
        final_df.to_csv(save_csv_root / f"round1_{model}.csv", index=False)
        finish_rounds = [3, 4, 5, 6]
        for the_round in finish_rounds:
            next_round_df = pd.DataFrame(columns=next_columns)
            model_next_result = Path(f"round{the_round}/before-asking") / model
            for benchmark in benchmarks:
                benchmark_next_result = model_next_result / benchmark
                result_file = benchmark_next_result / "info_after_pex_and_special.txt"
                if not result_file.exists():
                    print(f"{result_file} has not result")
                    continue
                with open(result_file) as f:
                    lines = f.readlines()
                code_file_list = [x.split(".cs:")[0] for x in lines]
                result_list = [x.split(".cs:")[1] for x in lines]
                next_df = pd.DataFrame({  
                    "code_file": code_file_list,  
                    "result": result_list ,
                    # "current": [str(the_round)] * len(code_file_list)
                })  
                next_df = get_next_df(next_df, model, benchmark, the_round-1)
                print(benchmark, next_df.shape[0])
                next_round_df = pd.concat([next_round_df, next_df], axis=0, ignore_index=True)

            next_round_df.to_csv(save_csv_root / f"round{the_round-1}_{model}.csv", index=False)
            new_result_dict = {k: v for k, v in zip(next_round_df['key'], next_round_df['label'])} 
            final_df = update_next(final_df, new_result_dict, the_round-1)

        final_df = merge_code(final_df)    
        final_df.to_csv(save_csv_root / f"allround_{model}.csv", index=False)