/// <reference path="singularity-core.ts"/>

interface Date {
    /*
    add
    subtract
    comare
    isBefore
    isAfter
    equals

    log?: () => void;
    toStr?: (includeMarkup?: boolean) => string;
    numericValueOf?: () => number;
    */
}

var singDate = sing.addModule(new sing.Module("Date", Date));

singDate.requiredDocumentation = false;

//////////////////////////////////////////////////////
//
//
// Date Extensions
//

singDate.addExt('add', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
singDate.addExt('subtract', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
singDate.addExt('compare', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
singDate.addExt('isBefore', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
singDate.addExt('isAfter', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
singDate.addExt('equals', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
