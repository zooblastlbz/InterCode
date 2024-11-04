from plot_iteration import *
import json

def prepare_success_func():
    total_df = pd.DataFrame(columns=["problem", "model", "shot"])
    for model in models:
        # print("******", model, setting)
        result_file = Path(f"Iteration-result/allround_{model}.csv")
        result_df = pd.read_csv(result_file)
        chosen_df = result_df[~result_df['problem'].isin(remove)]
        
        chosen_df = chosen_df.assign(shot="NO") 
        prompt_groups = chosen_df.groupby('problem')
        for problem, group in prompt_groups:
            if group['label'].str.contains('Su').any():
                chosen_df.loc[chosen_df['problem'] == problem, 'shot'] = "YES"
                # print(succ_answer_df['round'].min())
        prompt_result = chosen_df[["problem", "model", "shot"]].drop_duplicates()
        success_df = prompt_result[prompt_result['shot'].str.contains('YES')]
        success_list = success_df["problem"].tolist()
        print(len(success_list))
        with open(f'{model}-success.json', 'w') as file:  
            json.dump(success_list, file)
    return total_df



if __name__ == "__main__":
    prepare_success_func()