import random

def random_word_generator(word_list, num_words):
    while True:
        words = random.choices(word_list, k=num_words)
        yield ' '.join(words)

# 示例单词列表
word_list = ['apple', 'banana', 'cherry', 'date', 'elderberry', 'fig', 'grape', 'honeydew']

def random_generator(num):
    ans = []
    for _ in range(num):
        lenth = random.randint(3, 10)
        target = random.randint(1, 6)
        generator = random_word_generator(word_list, lenth)
        ans.append([next(generator), target])
    return ans
