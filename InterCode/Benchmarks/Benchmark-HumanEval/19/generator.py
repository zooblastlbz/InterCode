import random

def number_word_generator():
    number_words = ["zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"]
    while True:
        import random
        yield number_words[random.randint(0, 9)]

def random_generator(num):
    ans = []
    gen = number_word_generator()
    for _ in range(num):
        lenth = random.randint(2, 10)
        generated_words = [next(gen) for _ in range(lenth)]  # Generate 10 words
        result_string = ' '.join(generated_words)
        ans.append([result_string])
    return ans