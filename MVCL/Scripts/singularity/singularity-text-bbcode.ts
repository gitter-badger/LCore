/// <reference path="singularity-core.ts"/>


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

var singBBCode = sing.addModule(new sing.Module('Singularity.BBCode', String));

singBBCode.requiredDocumentation = false;
singBBCode.requiredUnitTests = false;


singBBCode.addExt('bbCodesToHTML', StringBBCodesToHTML,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

function StringBBCodesToHTML(): string {
    var out = this;

    sing.BBCodes.each(function (item, index) {
        out = out.replaceRegExp(item.matchStr, item.htmlStr);
    });

    return (<string>out);
}

singBBCode.addExt('bbCodesToText', StringBBCodesToText,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

function StringBBCodesToText(): string {
    var out = this;

    sing.BBCodes.each(function (item, index) {
        out = out.replaceRegExp(item.matchStr, item.textStr);
    });
    return out;
}