import random
import string

# 八大行星的英文名称
planets = ["Mercury", "Venus", "Earth", "Mars", "Jupiter", "Saturn", "Uranus", "Neptune"]

def random_string(length):
    return ''.join(random.choice(string.ascii_letters) for _ in range(length))

def planet_or_random(minx, maxx):
    while True:
        choice1 = random.choice(planets + [random_string(random.randint(minx, maxx))])
        choice2 = random.choice(planets + [random_string(random.randint(minx, maxx))])
        yield choice1, choice2


def random_generator(num):
    ans =[]
    gen = planet_or_random(0, 8)

    for _ in range(num):
        ps = next(gen)
        ans.append([ps[0], ps[1]])
    return ans
