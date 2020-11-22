import { ITamlValue, TamlValue } from "./TamlValue";

export class TamlArray extends Array<TamlValue> implements ITamlValue
{ 

	public toString = () :string => `[ ${this.join(", ")} ]`;

}
