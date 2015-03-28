/// <reference path="singularity-core.d.ts" />
interface String {
    replaceRegExp?: (pattern: RegExp, replace?: RegExp) => string;
    hasMatch?: (pattern: RegExp) => boolean;
    matchCount?: (pattern: RegExp) => number;
    escapeRegExp?: () => string;
}
declare var singRegExp: SingularityModule;
declare function StringMatchCount(pattern: string): any;
declare function StringHasMatch(pattern: string): boolean;
declare function StringReplaceRegExp(pattern: RegExp, replace?: RegExp): string;
declare function StringEscapeRegExp(): string;
