/// <reference path="singularity-core.ts"/>
var singBBCode = sing.addModule(new sing.Module('Singularity.BBCode', String));
singBBCode.requiredDocumentation = false;
singBBCode.requiredUnitTests = false;
singBBCode.addExt('bbCodesToHTML', StringBBCodesToHTML, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    },
});
function StringBBCodesToHTML() {
    var out = this;
    sing.BBCodes.each(function (item, index) {
        out = out.replaceRegExp(item.matchStr, item.htmlStr);
    });
    return out;
}
singBBCode.addExt('bbCodesToText', StringBBCodesToText, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    },
});
function StringBBCodesToText() {
    var out = this;
    sing.BBCodes.each(function (item, index) {
        out = out.replaceRegExp(item.matchStr, item.textStr);
    });
    return out;
}
//# sourceMappingURL=singularity-text-bbcode.js.map