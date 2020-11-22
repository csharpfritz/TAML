"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Parser = void 0;
var TamlDocument_1 = require("./TamlDocument");
var Parser = /** @class */ (function () {
    function Parser() {
        this.SupportedSpecVersion = "1.0";
    }
    Parser.prototype.Parse = function (taml) {
        return new TamlDocument_1.TamlDocument();
    };
    return Parser;
}());
exports.Parser = Parser;
;
