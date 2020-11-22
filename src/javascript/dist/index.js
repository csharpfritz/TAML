"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.TAML = void 0;
var TamlDocument_1 = require("./TamlDocument");
var TamlKeyValuePair_1 = require("./TamlKeyValuePair");
var TamlValue_1 = require("./TamlValue");
var TamlArray_1 = require("./TamlArray");
var Parser = require("parser");
var TAML = /** @class */ (function () {
    function TAML() {
    }
    Object.defineProperty(TAML.prototype, "Parser", {
        get: function () { return new Parser(); },
        enumerable: false,
        configurable: true
    });
    return TAML;
}());
exports.TAML = TAML;
module.exports = { TAML: TAML, TamlDocument: TamlDocument_1.TamlDocument, TamlKeyValuePair: TamlKeyValuePair_1.TamlKeyValuePair, TamlValue: TamlValue_1.TamlValue, TamlArray: TamlArray_1.TamlArray };
