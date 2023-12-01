# Debug mode
# path = "example_input.txt"
path = "input.txt"

# Using readlines()
file1 = open(path, "r")
Lines = file1.readlines()

calibration_number = 0
for line in Lines:
    numbers = []
    for character in line:
        if str.isnumeric(character):
            numbers.append(character)
            print(character, end=" ")
    print(numbers)
    print(f"First: {numbers[0]}, Last: {numbers[-1]}")
    cal_number = int(numbers[0] + numbers[-1])
    print(f"Calibration Number: {cal_number}")
    calibration_number += cal_number
print(f"Sum of all: {calibration_number}")
