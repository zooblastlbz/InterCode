import random

def generate(pairs):
    if pairs == 0:
        return ""
    if pairs == 1:
        return "()"
    
    result = "("
    left_pairs = random.randint(0, pairs - 1)
    right_pairs = pairs - 1 - left_pairs
    result += generate(left_pairs)
    result += ")"
    result += generate(right_pairs)
    
    return result
    
def random_generator(num):
    ans = []
    for _ in range(num):
       lenth = random.randint(2, 10)
       bracket = generate(lenth)
       ans.append([bracket])
    return ans