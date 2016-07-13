/// <reference path="singularity-core.ts"/>
/// <reference path="singularity-string.ts"/>


interface String {

    replaceRegExp?: (pattern: RegExp, replace?: RegExp) => string;

    hasMatch?: (pattern: RegExp) => boolean;
    matchCount?: (pattern: RegExp) => number;
    escapeRegExp?: () => string;
}

var singRegExp = singString.addModule(new sing.Module('RegExp', String));

singRegExp.glyphIcon = '&#xe051;';

singRegExp.method('matchCount', stringMatchCount,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests(ext) {
        }
    });

function stringMatchCount(pattern: string) {

    const match = this.match(pattern);

    if (!match)
        return 0;

    return match.length;
}

singRegExp.method('hasMatch', stringHasMatch,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests(ext) {
        }
    });

function stringHasMatch(pattern: string): boolean {

    const match = this.match(pattern);

    if (!match || match.length == 0)
        return false;

    return true;
}

singRegExp.method('replaceRegExp', stringReplaceRegExp,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests(ext) {
        }
    });

function stringReplaceRegExp(pattern: RegExp, replace?: RegExp): string {

    let out = this;

    let match = out.match(pattern);

    let outBefore = '';
    let count = 0;

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

singRegExp.method('escapeRegExp', stringEscapeRegExp,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests(ext) {
        }
    });

function stringEscapeRegExp(): string {

    // ReSharper disable once ConditionIsAlwaysConst
    // ReSharper disable once HeuristicallyUnreachableCode
    const out = (this || '') as string;

    return out.replace(/([\\\.\+\*\?\[\^\]\$\(\)\{\}\=\!\<\>\|\:])/g, '\\$1');
}
