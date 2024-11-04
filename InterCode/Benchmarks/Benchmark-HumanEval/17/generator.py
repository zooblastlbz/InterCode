import random

def generate(num_notes):
    # Define the possible note symbols
    note_symbols = ['o', 'o|', '.|']
    
    # Generate a random sequence of notes
    notes = [random.choice(note_symbols) for _ in range(num_notes)]
    
    # Join the notes with a space in between each
    note_string = ' '.join(notes)
    
    return note_string

# # Example usage
# num_notes = 8
# generated_string = note_string_generator(num_notes)
# print(generated_string)  # Example output: 'o o| .| o o| o o .| o| .|'

def random_generator(num):
    ans = []
    for _ in range(num):
       lenth = random.randint(1, 10)
       bracket = generate(lenth)
       ans.append([bracket])
    return ans