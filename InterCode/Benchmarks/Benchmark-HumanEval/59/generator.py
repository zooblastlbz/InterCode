import random

def is_prime(num):
    """Check if a number is prime."""
    if num <= 1:
        return False
    if num <= 3:
        return True
    if num % 2 == 0 or num % 3 == 0:
        return False
    i = 5
    while i * i <= num:
        if num % i == 0 or num % (i + 2) == 0:
            return False
        i += 6
    return True

def non_prime_generator(n):
    """A generator that yields random non-prime numbers between 1 and n."""
    while True:
        num = random.randint(1, n)
        if not is_prime(num):
            yield num

# Example usage:
def random_generator(num):
    ans = []
    for _ in range(num):
        lenth = random.randint(100, 10000)
        gen = non_prime_generator(lenth)
        ans.append([next(gen)])
    return ans