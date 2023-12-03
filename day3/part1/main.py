# Debug mode
# path = "example_input.txt"
path = "input.txt"

# Using readlines()
file1 = open(path, "r")
lines = file1.readlines()

limits = {"red": 12, "green": 13, "blue": 14}
numbers = ["0", "1", "2", "3", "4", "5", "6", "7", "8", "9"]

line_length = len(lines[0].strip())  # unpadded
pad_line = ""
for i in range(line_length + 2):
    pad_line += "."

rows = []
rows.append(pad_line)
for line in lines:
    # print(line)
    rows.append("." + line.strip() + ".")
rows.append(pad_line)

print("Padded:")
for i in range(len(rows)):
    for j in range(len(rows[0])):
        print(rows[i][j], end=" ")
    print()
print()

print("Unpadded:")
for i in range(1, len(rows) - 1):
    for j in range(1, line_length + 1):
        print(rows[i][j], end=" ")
    print(" ")
print()

sum = 0
startrow = 1  # len(rows) - 3
maxrow = len(rows) - 1
valid_numbers = []
non_valid_numbers = []
print(f"Start: {startrow}, Stop: {maxrow}")
for i in range(startrow, maxrow):
    digits = ""
    has_adjacent_symbol = False
    for j in range(1, line_length + 1):
        # print(rows[i][j], end=" ")
        current = rows[i][j]
        print(f"Row: {i}, Column: {j}")
        print(f"Value: {current}")

        if current in numbers:
            # add digit
            digits = digits + current
            print(f"Adding {current} to buffer: {digits}.")
            # check adjacency
            for k in [-1, 0, 1]:
                for l in [-1, 0, 1]:
                    adj_val = rows[i + k][j + l]
                    if not (k == 0 and l == 0):
                        if adj_val not in numbers + ["."]:
                            has_adjacent_symbol = True
        else:
            print(f"Not a number.")
            if len(digits) > 0:
                if has_adjacent_symbol:
                    # print(int(digits), end=" ")
                    sum += int(digits)
                    valid_numbers.append(int(digits))
                    print(f"Added {digits} to sum, clearing buffer.")
                    digits = ""
                else:
                    print(
                        f"{digits} in buffer, but no adjacent symbol. Clearing buffer."
                    )
                    non_valid_numbers.append(int(digits))
                    digits = ""
            else:
                print("Buffer empty.")

            has_adjacent_symbol = False

        # print(f"Buffer has adjacent: {has_adjacent_symbol}")
        print()

    # End of row
    print("End of row")
    if len(digits) > 0:
        if has_adjacent_symbol:
            # print(int(digits), end=" ")
            sum += int(digits)
            valid_numbers.append(int(digits))
            print(f"Added {digits} to sum, clearing buffer.")
            digits = ""
        else:
            print(f"{digits} in buffer, but no adjacent symbol. Clearing buffer.")
            non_valid_numbers.append(int(digits))
            digits = ""
    else:
        print("Buffer empty.")


print(f"Result: {sum}")
print(f"Valid numbers: {valid_numbers}")
print(f"Max valid number: {max(valid_numbers)}")
print(f"Non-valid numbers: {non_valid_numbers}")
