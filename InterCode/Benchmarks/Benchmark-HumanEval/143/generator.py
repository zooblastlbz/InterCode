import random

def random_word_generator(word_list, min_words=5, max_words=10):
    """
    A generator function that yields a random string of words.
    
    :param word_list: List of words to choose from.
    :param min_words: Minimum number of words in the generated string.
    :param max_words: Maximum number of words in the generated string.
    """
    while True:
        num_words = random.randint(min_words, max_words)
        random_words = random.choices(word_list, k=num_words)
        yield ' '.join(random_words)

word_list = ["apple", "banana", "cherry", "date", "elderberry", 
                 "fig", "grape", "honeydew", "kiwi", "lemon", "mango"]

# Example usage
def random_generator(num):
    ans = []
    generator = random_word_generator(word_list, 1, 15)
    for _ in range(num):
        ans.append([next(generator)])
    return ans