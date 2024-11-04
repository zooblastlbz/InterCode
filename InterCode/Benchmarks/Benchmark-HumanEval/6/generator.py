import random

def generate_brackets(m, n):
    def generate_single_group(depth):
        if depth == 0:
            return ""
        else:
            return "(" + generate_single_group(depth - 1) + ")"

    for _ in range(n):
        depth = random.randint(1, m)
        yield generate_single_group(depth)

def generate(m, n):
    return ' '.join(generate_brackets(m, n))


def random_generator(num):
    ans = []
    for _ in range(num):
       m = random.randint(1, 5)
       n = random.randint(1, 5)
       bracket = generate(m, n)
       ans.append([bracket])
    return ans

