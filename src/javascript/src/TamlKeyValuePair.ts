import { ITamlValue, TamlValue } from "./TamlValue";

export class TamlKeyValuePair implements ITamlValue {

	Key:string = "";
	Value?:ITamlValue;

	get hasValue(): boolean { return this.Value !== undefined };

	public toString = () :string => {

		return `${this.Key}: ${this.Value?.toString()}`;

	}

}
