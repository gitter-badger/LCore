/// <reference path="singularity-core.d.ts" />
interface String {
    bbCodesToHTML?: () => string;
    bbCodesToText?: () => string;
}
interface BBCode {
    name: string;
    tag: string;
    matchStr: RegExp;
    htmlStr: string;
    textStr: string;
    test: string;
}
declare var singBBCode: SingularityModule;
declare function StringBBCodesToHTML(): string;
declare function StringBBCodesToText(): string;
