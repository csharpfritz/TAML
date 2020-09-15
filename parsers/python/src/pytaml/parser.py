"""
recursive parse


"""

from typing import List, Any, Union, Tuple


def parse(filename: str) -> List[Any]:
	with open(filename, "r") as file:
		lines = [line.rstrip() for line in file.readlines()] # remove newline character
		lines = [line for line in lines if len(line) > 0] # remove empty lines
		return parse_lines(lines)


def parse_lines(lines: List[str]) -> List[Any]:
	"""Iterate over each line to parse it.
	If it find a list it will capture the corresponding lines
	and recursively call itself on the captured lines to parse the list"""
	parsed:List[Any] = []
	if len(lines) == 0:
		return parsed
	tabs = find_tabs(lines[0])
	while len(lines) > 0:
		line = lines.pop(0)
		key, end = find_group(line, tabs)
		if end == len(line) and (len(lines) == 0 or lines[0][tabs] != "\t"):
			# On this line we found a list item
			parsed.append(key)
		elif end < len(line):
			# On this line we found a key value pair
			start = find_tabs(line, end)
			value, _ = find_group(line, start)
			parsed.append((key, value))
		else:
			# On this line we found the start of a list
			next_level = []
			while len(lines) > 0 and lines[0][tabs] == "\t":
				next_level.append(lines.pop(0))
			parsed.append((key, parse_lines(next_level)))
	return parsed


def find_group(line: str, start: int) -> Tuple[str, int]:
	"""Capture the group of non tabs character
	return the capture group and the end position of the group"""
	end = start
	length = len(line)
	while end < length and line[end].isalnum():
		end += 1
	return line[start:end], end


def find_tabs(line: str, start: int = 0) -> int:
	"""return the position of the next non tabs character in the string"""
	while line[start] == "\t":
		start += 1
	return start
