# Debug mode
# path = "example_input.txt"
path = "input.txt"

# Using readlines()
file1 = open(path, "r")
lines = file1.readlines()

result = 0
cards = {}
for line in lines:
    # Parsing
    my_numbers_string = line.split("|")[1]
    card_id_string = line.split("|")[0].split(":")[0].split()[1]
    winning_numbers_string = line.split("|")[0].split(":")[1]
    my_numbers = {int(item.strip()) for item in my_numbers_string.split()}
    winning_numbers = {int(item.strip()) for item in winning_numbers_string.split()}
    card_id = int(card_id_string.strip())

    # Matches
    matches = len(my_numbers & winning_numbers)
    cards[card_id] = {"matches": matches, "amount": 1}

    # Print card
    print(f"Card: {card_id}, Matches: {matches}")
print(cards)

for card_id in cards.keys():
    for amount in range(cards[card_id]["amount"]):
        matches = cards[card_id]["matches"]
        # print(f"Processing Card ID: {card_id}")
        if matches > 0:
            for i in range(matches):
                cards[card_id + i + 1]["amount"] += 1
        # print(cards)

for card in cards.values():
    result += card["amount"]

print(f"Result: {result}")
assert result == 30
