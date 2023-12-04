# Debug mode
# path = "example_input.txt"
path = "input.txt"

# Using readlines()
file1 = open(path, "r")
lines = file1.readlines()

result = 0
for line in lines:
    # print(line)

    # Parsing
    my_numbers_string = line.split("|")[1]
    card_id_string = line.split("|")[0].split(":")[0].split()[1]
    winning_numbers_string = line.split("|")[0].split(":")[1]
    my_numbers = {int(item.strip()) for item in my_numbers_string.split()}
    winning_numbers = {int(item.strip()) for item in winning_numbers_string.split()}
    card_id = int(card_id_string.strip())
    # print(card_id)
    # print(winning_numbers)
    # print(my_numbers)

    # Matches
    matches = my_numbers & winning_numbers
    # print(matches)

    # Score
    score = 0
    if len(matches) > 0:
        score = pow(2, len(matches) - 1)

    # Add up result
    result += score

    # Print card
    print(f"Card: {card_id}, Matches: {matches}, Score: {score}")

print(f"Result: {result}")
assert result == 13
