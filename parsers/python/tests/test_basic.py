import pytaml


def test_key_value():
	lines = ["key\tvalue"]
	assert pytaml.parse_lines(lines) == [("key", "value")]


def test_multiples_key_value():
	lines = [
		"key1\tvalue1",
		"key2\tvalue2",
		"key3\tvalue3",
		"key4\tvalue4",
	]
	assert pytaml.parse_lines(lines) == [
		("key1", "value1"),
		("key2", "value2"),
		("key3", "value3"),
		("key4", "value4"),
	]


def test_list_at_root():
	lines = ["item1", "item2"]
	assert pytaml.parse_lines(lines) == ["item1", "item2"]


def test_list_at_first_level():
	lines = ["root", "\titem1", "\titem2"]
	assert pytaml.parse_lines(lines) == [("root", ["item1", "item2"])]


def test_two_lists():
	lines = ["root1", "\titem1", "\titem2", "root2", "\titem3", "\titem4"]
	assert pytaml.parse_lines(lines) == [
											("root1", ["item1", "item2"]),
											("root2", ["item3", "item4"])
										]
