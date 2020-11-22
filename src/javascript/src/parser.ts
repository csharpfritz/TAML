import { TamlDocument } from "./TamlDocument";

export class Parser {

	SupportedSpecVersion = "1.0";

	Parse(taml:string) : TamlDocument {

		return new TamlDocument();
		
	}

};
