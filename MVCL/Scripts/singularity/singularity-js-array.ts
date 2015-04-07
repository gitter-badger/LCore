/// <reference path="singularity-core.ts"/>
/// <reference path="singularity-tests.ts"/>


interface Array<T> {

    arrayValues?: (findKeys?: string | string[]) => any[];

    splitAt?: (...indexes: number[]) => T[];

    sortBy?: (arg?: string | string[]| ((item: T) => number)) => T[];
    orderBy?: (arg?: string | string[]| ((item: T) => number)) => T[];

    quickSort?: (sortWith?: any[][], left?: number, right?: number) => any[]| QuickSortResult;

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
            ext.addTest([], [], []);
            ext.addTest([], [null], []);
            ext.addTest([], [undefined], []);
            ext.addTest([], [0], []);
            ext.addTest([1], [0], [[1]]);
            ext.addTest([1, 2], [0], [[1, 2]]);
            ext.addTest([1, 2], [1], [[1], [2]]);
            ext.addTest([1, 2, 3, 4, 5, 6], [1, 3], [[1], [2, 3], [4, 5, 6]]);
        },
    });

function SplitAt<T>(...indexes: number[]): T[][] {

    indexes = indexes.unique();

    indexes.sort();

    var thisArray = <T[]>this;

    var out: T[][] = [];
    var section: T[] = [];
    var indexI = 0;

    for (var i = 0; i < thisArray.length; i++) {
        if (indexes.length >= indexI) {

            if (i == indexes[indexI]) {

                if (section.length > 0)
                    out.push(section);

                section = [];
                indexI++;
            }

            section.push(thisArray[i]);

        }
    }

    if (!$.isEmpty(section))
        out.push(section);

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
            ext.addTest([], [], []);
            ext.addTest([], [null], []);
            ext.addTest([], [undefined], []);
            ext.addTest([], [0], []);
            ext.addTest([1], [0], []);
            ext.addTest([1, 2], [0], [2]);
            ext.addTest([1, 2], [1], [1]);
            ext.addTest([1, 2], [0, 1], []);
            ext.addTest([1, 2, 3, 4, 5, 6], [0, 1], [3, 4, 5, 6]);
            ext.addTest([1, 2, 3, 4, 5, 6], [0, 5], [2, 3, 4, 5]);
        },
    });

function ArrayRemoveAt<T>(...indexes: number[]): T[] {

    var thisArray = <T[]>this;

    return thisArray.select(function (item, index) {
        return !indexes.has(index);
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
            ext.addTest([], [], []);
            ext.addTest([null, undefined], [], []);
            ext.addTest([1, 2, 3], [], [1, 2, 3]);
            ext.addTest([1, 2, 3, 1, 2, 3], [], [1, 2, 3]);
            ext.addTest([1, 2, 3, 'a', 'b', 'c', 1, 2, 3, 'a', 'b', 'c'], [], [1, 2, 3, 'a', 'b', 'c']);
        },
    });

function ArrayUnique<T>(): T[] {

    var thisArray = <T[]>this;

    var out: T[] = [];

    thisArray.each(function (item, index) {
        if (!out.has(item) && $.isDefined(item))
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
            ext.addCustomTest(function () {

                var test = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20];

                var test2 = test.random();

                var test3 = test.random(5);

                if (!test.has(test2))
                    return 'failed';

                if ((<number[]>test3).has(function (a) { return !test.has(a); }))
                    return 'failed';
            })
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
            ext.addCustomTest(function () {

                var test = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20];

                var test2 = test.shuffle();

                if (test == test2 || test2.length != test.length)
                    return 'failed';

                if (test2.has(function (a) { return !test.has(a); }))
                    return 'failed';
            });
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
        tests: function (ext) {
            ext.addTest([], [], []);
            ext.addTest([], [null], []);

            ext.addTest([1, 2, 3], [function (a: any) { }], { '': [1, 2, 3] });
            ext.addTest([1, 2, 3], [function (a: any) { return 'group' + a; }], { group1: [1], group2: [2], group3: [3] });
            ext.addTest([1, 2, 2, 3], [function (a: any) { return 'group' + a; }], { group1: [1], group2: [2, 2], group3: [3] });
        },
    });

function ArrayGroup<T>(keyFunc: (item: T, index: number) => string): Hash<T[]> {

    var thisArray = <T[]>this;

    var out: Hash<T[]> = {};

    thisArray.each(function (item, index) {

        var key = keyFunc(item, index);

        key = key || '';

        if ($.isArray(out[key]))
            out[key].push(item);
        else
            out[key] = [item];

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



