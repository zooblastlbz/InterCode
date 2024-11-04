import random

def random_fruit_generator(n):
    while True:
        x = random.randint(0, n-1)
        y = random.randint(0, n-1)
        if x + y < n:
            return f"{x} apples and {y} oranges"

# 示例用法
def random_generator(num):
    ans = []
    for _ in range(num):
        total = random.randint(5, 100)
        fruit_string = random_fruit_generator(total)
        ans.append([fruit_string, total])
    return ans