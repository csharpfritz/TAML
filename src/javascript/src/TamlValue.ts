export class TamlValue implements ITamlValue {

	private _Value:string = "";

	constructor(value:string) {
		this._Value = value;
	}

	public toString = () :string => this._Value;

}

export interface ITamlValue {

	toString() :string;

}
