import random

def random_sentence_generator():
    subjects = ["The cat", "A dog", "A bird", "The boy", "The girl", "I"]
    verbs = ["jumps", "run", "fly", "sit", "stand", "play"]
    objects = ["on the roof", "in the garden", "over the fence", "by the lake", "in the park", "with my friends"]
    punctuations = [".", "?", "!"]

    while True:
        subject = random.choice(subjects)
        verb = random.choice(verbs)
        obj = random.choice(objects)
        punctuation = random.choice(punctuations)
        sentence = f"{subject} {verb} {obj}{punctuation}"
        yield sentence

def generate_random_paragraph(num_sentences):
    sentences = []
    generator = random_sentence_generator()
    for _ in range(num_sentences):
        sentences.append(next(generator))
    return " ".join(sentences)

# Example usage
def random_generator(num):
    ans = []
    for _ in range(num):
        lenth = random.randint(1, 5)
        random_paragraph = generate_random_paragraph(lenth)
        ans.append([random_paragraph])
    return ans