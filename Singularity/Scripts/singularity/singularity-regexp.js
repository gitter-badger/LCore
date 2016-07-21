/// <reference path="singularity-core.ts"/>
/// <reference path="singularity-string.ts"/>
var singRegExp = singString.addModule(new sing.Module('RegExp', String));
singRegExp.glyphIcon = '&#xe051;';
singRegExp.method('matchCount', stringMatchCount, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    }
});
function stringMatchCount(pattern) {
    var match = this.match(pattern);
    if (!match)
        return 0;
    return match.length;
}
singRegExp.method('hasMatch', stringHasMatch, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    }
});
function stringHasMatch(pattern) {
    var match = this.match(pattern);
    if (!match || match.length == 0)
        return false;
    return true;
}
singRegExp.method('replaceRegExp', stringReplaceRegExp, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    }
});
function stringReplaceRegExp(pattern, replace) {
    var out = this;
    var match = out.match(pattern);
    var outBefore = '';
    var count = 0;
    if (match && match.length > 1 && outBefore != out && count < 10) {
        // ReSharper disable once AssignedValueIsNeverUsed
        outBefore = out;
        out = out.replace(pattern, replace);
        // ReSharper disable once AssignedValueIsNeverUsed
        match = out.match(pattern);
        count++;
    }
    return out;
}
singRegExp.method('escapeRegExp', stringEscapeRegExp, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    }
});
function stringEscapeRegExp() {
    // ReSharper disable once ConditionIsAlwaysConst
    // ReSharper disable once HeuristicallyUnreachableCode
    var out = (this || '');
    return out.replace(/([\\\.\+\*\?\[\^\]\$\(\)\{\}\=\!\<\>\|\:])/g, '\\$1');
}
//# sourceMappingURL=singularity-regexp.js.map