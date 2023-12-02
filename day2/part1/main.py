# Debug mode
# path = "example_input.txt"
path = "input.txt"

# Using readlines()
file1 = open(path, "r")
Lines = file1.readlines()

limits = {"red": 12, "green": 13, "blue": 14}

id_sum = 0
for line in Lines:
    print(line)
    identifier = line.split(":")[0]
    # [print(identifier) for identifier in line.split(":")]
    game_id = int(identifier.split(" ")[1])
    print(game_id)
    # [print(game_id) for game_id in identifier.split(" ")]
    grabs = line.split(":")[1].split(";")
    game_possible = True
    for grab in grabs:
        print(grab.strip())
        for cube in grab.split(","):
            print(cube)
            amount = int(cube.strip().split(" ")[0])
            print(amount)
            color = cube.strip().split(" ")[1]
            print(color)
            if amount > limits[color]:
                game_possible = False
    if game_possible:
        id_sum += game_id
print(f"Sum: {id_sum}")
