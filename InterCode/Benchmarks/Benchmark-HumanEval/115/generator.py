import random

def generate_intint_matrix(num_rows, row_length):
    while True:
        matrix = []
        for _ in range(num_rows):
            row = [random.choice([0, 1]) for _ in range(row_length)]
            matrix.append(row)
        yield matrix

def random_generator(num):
    ans = []
    for _ in range(num):
       m = random.randint(1, 10)
       n = random.randint(1, 10)
       intint_array = next(generate_intint_matrix(m, n))
       capa = m = random.randint(1, 10)
       ans.append([intint_array, capa])
    print(ans)
    return ans

random_generator(1)