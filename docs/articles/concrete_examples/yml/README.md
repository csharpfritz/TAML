# YAML to TAML format samples

In this folder are proposed migrations of YAML files to the TAML format, illustrating the capability of the document format to deliver simple yet easy to read documents without the extra notation and ceremony of the YAML format.

## GitHub Actions

The GitHub action YAML format delivers a series of steps for each action that should be taken, and each step is defined with a `name: <name>` pair.

```yaml
name: github pages

on:
  push:
    branches:
      - main

jobs:
  deploy:
    runs-on: ubuntu-latest
    steps:
      - name: Checkout
        uses: actions/checkout@v2


      - name: docfx-action
        uses: nikeee/docfx-action@v0.1.0
        with:
          args: docs/docfx.json

      - name: Deploy
        uses: peaceiris/actions-gh-pages
@v3.6.1
        with:
          github_token: ${{ secrets.GITH
UB_TOKEN }}
          publish_dir: ./docs/_site
```

When this is converted to TAML, we can eliminte the redundant `name: <name>` pair that opens the step object in YAML and make it clearer that an step is defined:

```
name            github pages

on
        push
                branches
                        main

jobs
        deploy
        runs-on         ubuntu-latest
                steps
                                Checkout
                                        uses            actions/checko ut@v2
                                docfx-action
                                        uses            nikeee/docfx-action@v0.1.0
                                        with
                                                args    docs/docfx.json
                                Deploy
                                        uses    peaceiris/actions-gh-pages@v3.6.1
                                        with
                                                github_token         ${{ secrets.GITHUB_TOKEN }}
                                                publish_dir          ./docs/_site
```
