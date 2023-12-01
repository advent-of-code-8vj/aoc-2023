import re

# Debug mode
# path = "example_input.txt"
path = "input.txt"

# Using readlines()
file1 = open(path, "r")
Lines = file1.readlines()

numbers = {
    "one": "1",
    "two": "2",
    "three": "3",
    "four": "4",
    "five": "5",
    "six": "6",
    "seven": "7",
    "eight": "8",
    "nine": "9",
}

numbers_array = list(numbers.keys()) + list(numbers.values())

calibration_number = 0
for line in Lines:
    print(line)
    # Match Start
    found_start = False
    i = 0
    while found_start == False and i < len(line):
        i += 1
        segment = line[0:i]
        for key in numbers_array:
            if segment.find(key) != -1:
                print(f"Start: {key}")
                found_start = True
                if key in numbers.keys():
                    start = numbers[key]
                else:
                    start = key

    found_end = False
    i = 0
    while found_end == False and i < len(line):
        i += 1
        segment = line[-1 - i : -1]
        for key in numbers_array:
            if segment.find(key) != -1:
                print(f"End: {key}")
                found_end = True
                if key in numbers.keys():
                    end = numbers[key]
                else:
                    end = key
    print()
    cal = int(start + end)
    calibration_number += cal

print(f"Sum of all: {calibration_number}")
