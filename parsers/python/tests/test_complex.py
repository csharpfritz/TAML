import pytaml


def test_complex():
	lines = [
		"root",
		"\tkey1\t\tvalue1",
		"\tkey2\t\tvalue2",
		"\tkey3",
		"\t\titem1",
		"\t\titem2",
		"\t\titem3",
		"\t\titem4",
		"\t\t\tkey41\t\t\tvalue41",
		"\t\t\tkey42\t\t\tvalue42",
		"\t\t\tkey43\t\t\tvalue43",
		"\t\t\tkey44\t\t\tvalue44",
	]
	assert pytaml.parse_lines(lines) == [
		(
			"root",
			[
				("key1", "value1"),
				("key2", "value2"),
				(
					"key3",
					[
						"item1",
						"item2",
						"item3",
						(
							"item4",
							[
								("key41", "value41"),
								("key42", "value42"),
								("key43", "value43"),
								("key44", "value44"),
							],
						),
					],
				),
			],
		)
	]
