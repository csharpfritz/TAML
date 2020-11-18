



====================
Install and run test
====================

Install pytaml in dev mode with testing packages:

.. code-block:: bash

	virtualenv .env
	source .env/bin/activate
	pip install -e .\[testing\]

Run mypy for type check:

.. code-block:: bash

	mypy --config-file=setup.cfg

Run tests:

.. code-block:: bash

	python -m pytest tests

Runs tests with coverages:

.. code-block:: bash

	python -m pytest --cov-branch --cov=pytaml --cov-report html --html=report/report.html tests

Use pytaml to parse taml file:

.. code-block:: python

	import pytaml
	data = pytaml.parse(filename)


