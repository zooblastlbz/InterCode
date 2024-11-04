import random

def random_fraction_generator(minx, maxx):
    while True:
        numerator = random.randint(minx, maxx)  # 生成1到100之间的随机正整数作为分子
        denominator = random.randint(minx, maxx)  # 生成1到100之间的随机正整数作为分母
        yield f"{numerator}/{denominator}"


def random_generator(num):
    fraction_gen = random_fraction_generator(1, 20)
    ans = []
    for _ in range(num):
        ans.append([next(fraction_gen), next(fraction_gen)])
    return ans