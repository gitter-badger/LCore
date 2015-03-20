/// <reference path="singularity-core.ts"/>
/// <reference path="singularity-tests.ts"/>
var singArray = sing.addModule(new sing.Module("Array", Array));
singArray.requiredDocumentation = false;
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Array Extensions
//
//
//////////////////////////////////////////////////////
//
// Mapping Functions
//
singArray.addExt('log', ArrayLog, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    },
});
function ArrayLog(itemOrItemsOrFunction) {
    log(this);
}
singArray.addExt('toStr', ArrayToStr, {
    summary: null,
    parameters: null,
    returns: null,
    returnType: String,
    examples: null,
    tests: function (ext) {
    },
});
function ArrayToStr(includeMarkup) {
    if (includeMarkup === void 0) { includeMarkup = false; }
    var out = includeMarkup ? '[' : '';
    var src = this;
    this.each(function (item, i) {
        if (item === null)
            out += 'null';
        else if (item === undefined)
            out += 'undefined';
        else if (item.toStr)
            out += item.toStr(includeMarkup); // includeMarkup is passed to child elements
        if (i < src.length - 1)
            out += includeMarkup ? ', ' : '\r\n';
    });
    out += includeMarkup ? ']' : '';
    return out;
}
//
//# sourceMappingURL=singularity-js-array.js.map