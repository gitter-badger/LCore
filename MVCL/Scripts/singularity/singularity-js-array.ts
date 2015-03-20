/// <reference path="singularity-core.ts"/>
/// <reference path="singularity-tests.ts"/>


interface Array<T> {

    arrayValues?: (findKeys?: string | string[]) => any[];

    clone?: () => T[];

}

interface JQueryStatic {
    toArray?: (obj: any) => any[];
}

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


singArray.addExt('toArray', ObjToArray,
    {
        summary: null,
        parameters: null,
        validateInput: false,
        returns: '',
        returnType: '',
        examples: null,
        tests: function (ext) {
        },
    }, $);

function ObjToArray(obj: any) {
    if ($.isArray(obj))
        return obj;
    else
        return [obj];
}

singArray.addExt('clone', ArrayClone,
    {
        summary: null,
        parameters: null,
        validateInput: false,
        returns: '',
        returnType: '',
        examples: null,
        tests: function (ext) {
        },
    });

function ArrayClone() {
    return this.collect();
}
