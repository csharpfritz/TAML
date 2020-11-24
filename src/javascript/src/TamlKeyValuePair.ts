import { ITamlValue, TamlValue } from "./TamlValue";

export class TamlKeyValuePair implements ITamlValue {

	static _KeyValuePair = /(?<key>\S[^\t]*)\t+(?<value>\S[^\t]*)/i;

	Key:string = "";
	Value?:ITamlValue;

	public static IsKeyValuePair(taml : string) : boolean {

		// console.log(`Testing if "${taml}" is a keyValuePair: ${this._KeyValuePair.test(taml)}"`);
		return this._KeyValuePair.test(taml);

	}

	public static fromString(taml : string) : TamlKeyValuePair | null {

		if (!this.IsKeyValuePair(taml)) return null;

		const matches = this._KeyValuePair.exec(taml);
		// console.log("Matches: " + matches);
		
		if (matches === null || matches.groups === undefined) {
			// console.log("No matches found when converting to KeyValuePair");
			return null;
		}

		const outValue = new TamlKeyValuePair();
		outValue.Key = matches.groups["key"];
		outValue.Value = matches.groups["value"];
		return outValue;

	}

	get hasValue(): boolean { return this.Value !== undefined };

	public toString = () :string => {

		return `${this.Key}: ${this.Value?.toString()}`;

	}

}
