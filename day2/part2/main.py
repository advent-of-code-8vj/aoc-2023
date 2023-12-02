# Debug mode
# path = "example_input.txt"
path = "input.txt"

# Using readlines()
file1 = open(path, "r")
Lines = file1.readlines()

limits = {"red": 12, "green": 13, "blue": 14}

powers = 0
for line in Lines:
    print(line)
    identifier = line.split(":")[0]
    # [print(identifier) for identifier in line.split(":")]
    game_id = int(identifier.split(" ")[1])
    print(game_id)
    # [print(game_id) for game_id in identifier.split(" ")]
    grabs = line.split(":")[1].split(";")
    current = {"red": 0, "green": 0, "blue": 0}
    for grab in grabs:
        print(grab.strip())
        for cube in grab.split(","):
            # print(cube)
            amount = int(cube.strip().split(" ")[0])
            # print(amount)
            color = cube.strip().split(" ")[1]
            # print(color)
            if amount > current[color]:
                current[color] = amount
    power = current["red"] * current["green"] * current["blue"]
    print(current)
    print(f"Power: {power}")
    powers += power

print(f"Sum: {powers}")
