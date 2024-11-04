import random

def generate_random_2d_array(n):
    numbers = list(range(1, n*n + 1))
    random.shuffle(numbers)
    
    def array_generator():
        for i in range(n):
            yield numbers[i*n:(i+1)*n]
    
    return array_generator()

# 示例用法
# n = 4
# random_2d_array = generate_random_2d_array(n)
# print(next(random_2d_array))
# def random_generator(num):
#     for _ in range(num):
def random_generator(num):
    ans = []
    for _ in range(num):
        size = random.randint(2, 5)
        lenth = random.randint(2, size*size)
        random_2d_array = generate_random_2d_array(size)
        matrix = []
        for _ in range(size):
            matrix.append(next(random_2d_array))
        ans.append([matrix, lenth])
    return ans