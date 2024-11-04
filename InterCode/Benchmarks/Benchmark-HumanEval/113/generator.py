import random
import string

def generate_string_array(array_length, string_length_max):
    while True:
        array = []
        for _ in range(array_length):
            string_length = random.randint(1, string_length_max)
            random_str = ''.join(random.choices(string.digits, k=string_length))
            array.append(random_str)
        yield array

def random_generator(num):
    ans = []
    for _ in range(num):
       m = random.randint(1, 10)
       string_array = next(generate_string_array(m, 10))
       ans.append([string_array])
    return ans
