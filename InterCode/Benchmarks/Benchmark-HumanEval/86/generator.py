import random

def sentence_generator():
    subjects = ["The cat", "A dog", "The bird", "A fish", "The person"]
    verbs = ["ate", "watched", "chased", "listened to", "bumped into"]
    objects = ["an apple", "a movie", "a car", "some music", "a tree"]

    while True:
        subject = random.choice(subjects)
        verb = random.choice(verbs)
        obj = random.choice(objects)
        sentence = f"{subject} {verb} {obj}."
        yield sentence

# 使用生成器
def random_generator(num):
    ans = []
    gen = sentence_generator()
    for _ in range(num):
        ans.append([next(gen)])
    return ans