import matplotlib.pyplot as plt
import numpy as np
from pathlib import *
import json


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



def plot_multibars(objects, totals, successes, categories):
    fig, axes = plt.subplots(nrows=3, ncols=2, sharex=True, figsize=(12, 3.5))  # 调整高度
    axes = axes.flatten()

    for i, obj in enumerate(objects):
        ax = axes[i]
        for j, cat in enumerate(categories):
            total = totals[obj][j]
            success = successes[obj][j]

            # 计算成功比例
            success_ratio = success / total

            # 绘制成功部分，用斜纹填充
            ax.barh(cat, success, color='none', edgecolor='black', hatch='//', label='Success' if i == 0 and j == 0 else "")

            # 绘制总量部分
            ax.barh(cat, total, color='none', edgecolor='black', label='Total' if i == 0 and j == 0 else "")

            # 添加比例标签在成功部分旁边
            ax.text(success + 2, j, f'{success_ratio:.0%}', va='center', ha='left')

        # 设置标题
        model_name = formalize_name(obj)
        ax.set_title(model_name)

    # 设置共享的横坐标标签
    for ax in axes[-2:]:
        ax.set_xlabel('Number of Functionalities')

    # 添加图例
    # plt.legend(['Shot', 'Total'], loc='lower center', bbox_to_anchor=(-0.4, -1))

    # 调整布局
    plt.tight_layout()
    plt.show()
    plt.savefig('multibars.pdf', format='pdf')
    plt.savefig('multibars.png', format='png')

def plot_typebars(objects, totals, successes, categories, figure_name, cRow, cCol, width, length):
    fig, axes = plt.subplots(nrows=cRow, ncols=cCol, sharex=True, figsize=(width, length))  # 调整高度  
    axes = axes.flatten()

    for i, obj in enumerate(objects):
        ax = axes[i]
        for j, cat in enumerate(categories):
            total = totals[obj][j]
            success = successes[obj][j]
            # 计算成功比例
            success_ratio = success / total

            # 绘制成功部分，用斜纹填充
            ax.barh(cat, success, color='none', edgecolor='black', hatch='//', label='Success' if i == 0 and j == 0 else "")

            # 绘制总量部分
            ax.barh(cat, total, color='none', edgecolor='black', label='Total' if i == 0 and j == 0 else "")

            # 添加比例标签在成功部分旁边
            ax.text(success + 2, j, f'{success_ratio:.0%}', va='center', ha='left')

        # 设置标题
        model_name = formalize_name(obj)
        ax.set_title(model_name)

    # 设置共享的横坐标标签
    for ax in axes[-2:]:
        ax.set_xlabel('Number of Functionalities')

    # 添加图例
    # plt.legend(['Implemented', 'Total'], loc='lower center', bbox_to_anchor=(-0.4, -0.6))

    # 调整布局
    plt.tight_layout()
    plt.show()
    plt.savefig(f'{figure_name}-typebars.pdf', format='pdf')
    plt.savefig(f'{figure_name}-typebars.png', format='png')


if __name__ == "__main__":
    remove = ["2", "4", "8", "90", "101", "S2L1", "S2L3", "S4L4"]
    NotIn = ["95", "22", "125", "137", "112", "87", "139", "111", "129", "38", "50", "79", "99"]
    
    difficulty_root = Path("../../NLAnswers")
    objects = ["GPT-4o-mini", "deepseek-coder-6.7b-instruct", "gemma-7b-it", "codegemma-7b-it", "Llama-2-7b-chat-hf", "CodeLlama-7b-Instruct"]
    categories = ['NL-Succeed', 'NL-Fail']

    feature_save = Path("features.json")
    with open(feature_save, 'r') as file:  
            features = json.load(file)

    IO_feature_dict = {}
    label_dict = {}
    for problem_feature in features:
        name = problem_feature['name']
        if name in NotIn + remove:
            continue
        types = problem_feature['Outputtype'] + problem_feature['Inputtype']
        algorithm_labels = problem_feature['type']
        
        for typ in types:
            if "array" in typ:
                if not "array" in IO_feature_dict.keys():
                    IO_feature_dict["array"] = []
                IO_feature_dict["array"].append(name)
            else:
                if typ == "long":
                    typ = "int"
                elif typ == "char":
                    typ = "string"
                if not typ in IO_feature_dict.keys():
                    IO_feature_dict[typ] = []
                IO_feature_dict[typ].append(name)
        
        for label in algorithm_labels:
            if label in ["tree", "graph", "hash", "stack"]:
                label = "Complex Manipulation"
            if label in ["cryptography", "math"]:
                label = "Math"
            if label == "sort":
                label = "Sorting"
            if label == "string":
                label = "String Manipulation"
            if label == "array":
                label = "Array Manipulation"
            if not label in label_dict.keys():
                label_dict[label] = []
            label_dict[label].append(name)

    IO_categories = list(IO_feature_dict.keys())
    label_categories = list(label_dict.keys())
    
    totals = dict()
    successes = dict()

    IO_totals = dict()
    IO_successes = dict()

    label_totals = dict()
    label_successes = dict()

    for m in objects:
        print(m)
        simple_save = difficulty_root / f"{m}-simple.json"
        hard_save = difficulty_root / f"{m}-hard.json"
        with open(simple_save, 'r') as file:  
            simple = json.load(file)  
        with open(hard_save, 'r') as file:  
            hard = json.load(file) 
        totals[m] = [len(simple), len(hard)]
        success_save = f"{m}-success.json"
        with open(success_save, 'r') as file:  
            success = json.load(file)
        simple_success = [x for x in simple if x in success]
        hard_success = [x for x in hard if x in success]
        successes[m] = [len(simple_success), len(hard_success)]
        print(hard_success)
        # print(len(simple)+len(hard))

        IO_totals[m] = []
        IO_successes[m] = []
        label_totals[m] = []
        label_successes[m] = []
        for IO_type in IO_categories:
            IO_totals[m].append(len(IO_feature_dict[IO_type]))
            IO_success = [x for x in IO_feature_dict[IO_type] if x in success]
            IO_successes[m].append(len(IO_success))
        for label_type in label_categories:
            label_totals[m].append(len(label_dict[label_type]))
            label_success = [x for x in label_dict[label_type] if x in success]
            label_successes[m].append(len(label_success))  

    # print(IO_totals)
    # print(IO_successes)      

    print("ready to plot")
    # plot_multibars(objects, totals, successes, categories)
    plot_typebars(objects, IO_totals, IO_successes, IO_categories, "IO", 3, 2, 12, 6.5)
    # plot_typebars(objects, label_totals, label_successes, label_categories, "label", 3, 2, 12, 6.5)



    

    


