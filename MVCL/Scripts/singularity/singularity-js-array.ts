/// <reference path="singularity-core.ts"/>
/// <reference path="singularity-tests.ts"/>


interface Array<T> {

    arrayValues?: (findKeys?: string | string[]) => any[];

    splitAt?: (...indexes: number[]) => T[];

    sortBy?: (arg?: string | string[]| ((item: T) => number)) => T[];
    orderBy?: (arg?: string | string[]| ((item: T) => number)) => T[];

    quickSort?: (sortWith?: any[][], left?: number, right?: number) => any[]| any[][]

    removeAt?: (...indexes: number[]) => T[];
    unique?: (...indexes: number[]) => T[];

    random?: (count?: number) => T | T[];

    group?: (keyFunc: (item: any, index: number) => string) => Hash<T>;

}

interface JQueryStatic {
    toArray?: (obj: any) => any[];
}

var singArray = singExt.addModule(new sing.Module("Array", Array));

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Array Extensions
//

//
//////////////////////////////////////////////////////
//
// Mapping Functions
//


singArray.method('splitAt', SplitAt,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

function SplitAt<T>(...indexes: number[]): T[][] {

    indexes.sort();

    var thisArray = <T[]>this;

    var out: T[][] = [];
    var section: T[] = [];
    var indexI = 0;

    for (var i = 0; i < thisArray.length; i++) {
        if (indexes.length > indexI) {
            if (i < indexes[indexI])
                section.push(thisArray[i]);

            if (i == indexes[indexI]) {
                out.push(section);
                section = [];
                indexI++;
            }
        }
    }

    return out;
}

singArray.method('removeAt', ArrayRemoveAt,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

function ArrayRemoveAt<T>(...indexes: number[]): T[] {

    var thisArray = <T[]>this;

    return thisArray.select(function (item, index) {
        return !indexes.contains(index);
    });
}

singArray.method('unique', ArrayUnique,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        aliases: ['removeDuplicates'],
        tests: function (ext) {
        },
    });

function ArrayUnique<T>(...indexes: number[]): T[] {

    var thisArray = <T[]>this;

    var out: T[] = [];

    thisArray.each(function (item, index) {
        if (!out.contains(item))
            out.push(item);
    });

    return out;
}

singArray.method('random', ArrayRandom,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

function ArrayRandom<T>(count: number = 1): T[] {

    var thisArray = <T[]>this;

    var out: T[] = [];

    // Don't return more random items than we have;
    count = count.min(thisArray.length);

    if (count == thisArray.length)
        return thisArray.shuffle();

    thisArray = thisArray.shuffle();

    while (out.length < count) {
        out.push((thisArray).shift());
    }

    return out;
}

singArray.method('shuffle', ArrayShuffle,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

function ArrayShuffle<T>(): T[] {

    var thisArray = <T[]>this;

    var out: T[] = [];

    while (thisArray.length > 0) {
        var rand = (<number>$.random(0, thisArray.length)).floor();

        out.push(thisArray[rand]);

        thisArray = thisArray.remove(thisArray[rand]);
    }

    return out;

}

singArray.method('group', ArrayGroup,
    {
    });

function ArrayGroup<T>(keyFunc: (item: T, index: number) => string): Hash<T[]> {

    var thisArray = <T[]>this;

    var out: Hash<T[]> = {};

    thisArray.each(function (item, index) {

        var key = keyFunc(item, index);

        if (key && key.length > 0) {

            if ($.isArray(out[key]))
                out[key].push(item);
            else
                out[key] = [item];
        }

    });

    return out;
}


singArray.method('toArray', ObjToArray,
    {
        summary: null,
        parameters: null,
        validateInput: false,
        returns: '',
        returnType: '',
        examples: null,
        tests: function (ext) {
            ext.addTest(null, [], []);
            ext.addTest(null, [null], []);
            ext.addTest(null, [undefined], []);
            ext.addTest(null, [0], [0]);
            ext.addTest(null, [[0, 1, 2]], [0, 1, 2]);
        },
    }, $);

function ObjToArray(obj: any) {

    if (!$.isDefined(obj))
        return [];

    if ($.isArray(obj))
        return obj;
    else
        return [obj];
}


/*
singEnumerable.method('fill', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

*/          



