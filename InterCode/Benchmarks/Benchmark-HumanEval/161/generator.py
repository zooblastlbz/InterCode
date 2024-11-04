import random
import string

def random_string_generator(n):
    characters = string.ascii_letters + string.digits + '#@/'
    while True:
        yield ''.join(random.choice(characters) for _ in range(n))

def random_generator(num):
    ans = []
    for _ in range(num):
        lenth = random.randint(1, 10)
        gen = random_string_generator(lenth)
        ans.append([next(gen)])
    return ans


