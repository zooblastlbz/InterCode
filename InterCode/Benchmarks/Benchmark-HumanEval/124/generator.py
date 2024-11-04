import random

def random_string_generator():
    while True:
        part1 = random.randint(1, 40)
        part2 = random.randint(1, 20)
        part3 = random.randint(2000, 2100)
        separator = random.choice(['-', ' ', '/'])
        yield f"{part1}{separator}{part2}{separator}{part3}"

# 示例：生成并打印10个随机字符串
def random_generator(num):
    ans = []
    generator = random_string_generator()
    for _ in range(num):
        ans.append([next(generator)])
    return ans