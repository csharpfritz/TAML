"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.TamlKeyValuePair = void 0;
var TamlKeyValuePair = /** @class */ (function () {
    function TamlKeyValuePair() {
        var _this = this;
        this.Key = "";
        this.toString = function () {
            var _a;
            return _this.Key + ": " + ((_a = _this.Value) === null || _a === void 0 ? void 0 : _a.toString());
        };
    }
    Object.defineProperty(TamlKeyValuePair.prototype, "hasValue", {
        get: function () { return this.Value !== undefined; },
        enumerable: false,
        configurable: true
    });
    ;
    return TamlKeyValuePair;
}());
exports.TamlKeyValuePair = TamlKeyValuePair;
