import { TamlArray } from "./TamlArray";
import { TamlDocument } from "./TamlDocument";
import { TamlKeyValuePair } from "./TamlKeyValuePair";
import { ITamlValue, TamlValue } from "./TamlValue";

export class Parser {

static _SingleValue = /^\t*\S[^\t]*\t*$/gi;

	static SupportedSpecVersion = "1.0";

	static Parse(taml:string) : TamlDocument {

		var outDoc = new TamlDocument();
		var lines = taml.split('\n');

		var value:ITamlValue|null = null;
		for (const line of lines) {

			// This line is a comment if it starts with #
			if (line[0] === "#") continue;

			// Skip empty lines
			if (line.trim() === "") continue;

			if (TamlKeyValuePair.IsKeyValuePair(line)) {
				var newPair = TamlKeyValuePair.fromString(line);
				if (newPair != null) outDoc.KeyValuePairs.push(newPair);
			} else {  // This is JUST a value
				
				if (value === null) {
					const kvp = new TamlKeyValuePair();
					kvp.Key = line.trim();
					value = kvp;
					outDoc.KeyValuePairs.push(kvp);
				} else {
					if (value instanceof TamlKeyValuePair) {
						// console.log("Adding entry to the KVP");
						const kvp:TamlKeyValuePair = value as TamlKeyValuePair;
						if (!kvp.hasValue) {
							kvp.Value = new TamlArray();
						}
						const arr:TamlArray = kvp.Value as TamlArray;
						arr.push(new TamlValue(line.trim()));
					}
				}

			}
		}

		return outDoc;
		
	}

};
