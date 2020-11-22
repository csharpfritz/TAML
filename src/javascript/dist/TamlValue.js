"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.TamlValue = void 0;
var TamlValue = /** @class */ (function () {
    function TamlValue(value) {
        var _this = this;
        this._Value = "";
        this.toString = function () { return _this._Value; };
        this._Value = value;
    }
    return TamlValue;
}());
exports.TamlValue = TamlValue;
