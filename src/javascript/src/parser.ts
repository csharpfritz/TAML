import { TamlDocument } from "./TamlDocument";
import { TamlKeyValuePair } from "./TamlKeyValuePair";

export class Parser {

static _SingleValue = /^\t*\S[^\t]*\t*$/gi;

	static SupportedSpecVersion = "1.0";

	static Parse(taml:string) : TamlDocument {

		var outDoc = new TamlDocument();
		var lines = taml.split('\n');

		for (const line of lines) {
			if (TamlKeyValuePair.IsKeyValuePair(line)) {
				var newPair = TamlKeyValuePair.fromString(line);
				if (newPair != null) outDoc.KeyValuePairs.push(newPair);
			}
		}

		console.log("I did a thing!");

		return outDoc;
		
	}

};
