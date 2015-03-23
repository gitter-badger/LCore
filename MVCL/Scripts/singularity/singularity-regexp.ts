﻿/// <reference path="singularity-core.ts"/>


interface String {

    replaceRegExp?: (pattern: RegExp, replace?: RegExp) => string;

    hasMatch?: (pattern: RegExp) => boolean;
    matchCount?: (pattern: RegExp) => number;
    escapeRegExp?: () => string;
}

var singRegExp = singString.addModule(new sing.Module('RegExp', String));

singRegExp.requiredDocumentation = false;

singRegExp.method('matchCount', StringMatchCount,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

function StringMatchCount(pattern: string) {

    var match = this.match(pattern);

    if (!match)
        return 0;

    return match.length;
}

singRegExp.method('hasMatch', StringHasMatch,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

function StringHasMatch(pattern: string): boolean {

    var match = this.match(pattern);

    if (!match || match.length == 0)
        return false

    return true;
}

singRegExp.method('replaceRegExp', StringReplaceRegExp,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

function StringReplaceRegExp(pattern: RegExp, replace?: RegExp): string {

    var out = this;

    var match = out.match(pattern);

    var outBefore = '';
    var count = 0;

    if (match && match.length > 1 && outBefore != out && count < 10) {
        outBefore = out;
        out = out.replace(pattern, replace);

        match = out.match(pattern);
        count++;
    }

    return out;
}

singRegExp.method('escapeRegExp', StringEscapeRegExp,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

function StringEscapeRegExp(): string {

    var out = <string>this;

    return out;
    out = out.replaceRegExp(/(^|.+)\$/, /\\\$/);
    out = out.replaceRegExp(/(^|.+)\[/, /\\\[/);
    out = out.replaceRegExp(/(^|.+)\]/, /\\\]/);
    out = out.replaceRegExp(/(^|.+)\./, /\\\./);
    out = out.replaceRegExp(/(^|.+)\^/, /\\\^/);
    out = out.replaceRegExp(/(^|.+)\!/, /\\\!/);
    out = out.replaceRegExp(/(^|.+)\?/, /\\\?/);
    out = out.replaceRegExp(/(^|.+)\\/, /\\\\/);
    out = out.replaceRegExp(/(^|.+)\>/, /\\\>/);
    out = out.replaceRegExp(/(^|.+)\</, /\\\</);

    return out;
}