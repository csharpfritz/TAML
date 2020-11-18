import os

import pytaml


print(os.path.join(os.path.dirname(__file__), 'complex1.taml'))

def test_complex1():
	filename = os.path.join(os.path.dirname(__file__), 'complex1.taml')
	assert pytaml.parse(filename) == [
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

