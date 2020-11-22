import { TamlDocument } from "./TamlDocument";
import { TamlKeyValuePair } from "./TamlKeyValuePair";
import { TamlValue, ITamlValue } from "./TamlValue";
import { TamlArray } from "./TamlArray";

const Parser = require ("parser");

export class TAML {
	get Parser() : typeof Parser { return new Parser() }
}

module.exports = { TAML , TamlDocument, TamlKeyValuePair, TamlValue, TamlArray };
