﻿/// <reference path="singularity-core.ts"/>

interface Array<T> {
    each?: (action: (item?: T, index?: number) => void) => void;
    'while'?: (action: (item?: T, index?: number) => boolean) => void;
    indices?: (item: T | T[]) => T[];


    collect(): T[];
    collect<U>(convertFunc?: (item?: T, index?: number) => U): U[];
    collect(collectFunc?: (item?: T, index?: number) => any): any[];

    select(condition: (...items: any[]) => boolean): T[];
    select(condition: (item?: T) => boolean): T[];
    select(condition: (item?: T, index?: number) => boolean): T[];

    where?: (condition: (item?: T, index?: number) => boolean) => T[];

    range?: (start: number, finish: number) => T[];
    flatten?: () => T[];

    remove?: (item: T | T[]| ((a: T, b: number) => boolean)) => T[];

    count?: (item: T | T[]| ((arg: T, index: number) => boolean | number)) => number;

    contains?: (item: T | T[]| ((arg: T, index: number) => boolean)) => boolean;
    has?: (item: T | T[]| ((arg: T, index: number) => boolean)) => boolean;

    shuffle?: () => T[];


    first<T>(count: number): T[];
    first<T>(item: T): T;
    first<T>(condition: Function): T;
    first<T>(condition: ((item: T, index: number) => boolean)): T;
    first<T>(itemOrCountOrAction: number | T | ((item: T, index: number) => boolean)): T | T[];

    last<T>(count: number): T[];
    last<T>(item: T): T;
    last<T>(condition: ((item: T, index: number) => boolean)): T;
    last<T>(itemOrCountOrAction: number | T | ((item: T, index: number) => boolean)): T | T[];
}

interface Number {
    timesDo?: (executeFunc: () => void, args?: any[], caller?: any) => any[];
}

var singEnumerable = singExt.addModule(new sing.Module("Enumerable", Array));

//////////////////////////////////////////////////////
//
// Iteration Functions
//

singEnumerable.method('each', EnumerableEach,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {

            ext.addTest([], [], undefined);
            ext.addTest([], [null], undefined);
            ext.addTest([], [undefined], undefined);
            ext.addTest([], [function () { }], undefined);
            ext.addTest([], [function () { return true; }], undefined);
            ext.addTest([], [function () { return false; }], undefined);
            ext.addTest([1], [function (a: any) { return a; }], undefined);

            ext.addCustomTest(function () {
                var test = [1, 2, 3];
                var count = 0;
                test.each(function () {
                    count++;
                });

                if (count != 3)
                    return 'each did not execute 3 times.';
            });

        },
    });

function EnumerableEach<T>(action: (item: T, i: number) => void) {
    if (!this)
        return;

    var thisArray = <Array<T>>this;

    thisArray.while(function (item: T, i: number) {
        action(item, i);

        // each always continues until the end
        return true;
    });
}

singEnumerable.method('while', EnumerableWhile,
    {
        summary: '',
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {

            ext.addTest([], [], true);
            ext.addTest([], [null], true);
            ext.addTest([], [undefined], true);
            ext.addTest([], [function () { }], true);
            ext.addTest([], [function () { return true; }], true);
            ext.addTest([1], [function () { return true; }], true);
            ext.addTest([], [function () { return false; }], true);
            ext.addTest([1], [function () { return false; }], false);
            ext.addTest([1, 2, 3, 4, 5], [function (a: any) { return a < 3; }], false);
            ext.addTest([1, 2, 3, 4, 5], [function (item: any, index: number) { return item == 4 && index == 3; }], false);
            
            // Test broken TODO FIX
            // ext.addTest([1, 2, 3, 4, 5], [function (a) { return a == 3; }], true);
            /*
            ext.addCustomTest(function () {
                var test = [1, 2, 3, 4, 5];
                var count = 0;
                test.while(function (a) {
                    count++;
                    return a < 3;
                });

                if (count != 3)
                    return 'while did not execute 3 times.';
            });
            */
        },
    });

function EnumerableWhile<T>(action: (item: T, index: number) => any) {
    if (!this || !action)
        return true;

    var exit = false;

    for (var i = 0; i < this.length; i++) {
        var result = action(this[i], i);

        if (result == false)
            exit = true;

        if (exit)
            break;
    }

    return !exit;
}


singEnumerable.method('until', EnumerableUntil,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
            ext.addTest([], [], false);
            ext.addTest([], [null], false);
            ext.addTest([], [undefined], false);
            ext.addTest([], [function () { }], false);
            ext.addTest([], [function () { return true; }], false);
            ext.addTest([1], [function () { return true; }], true);
            ext.addTest([1, 2], [function () { return true; }], true);
            ext.addTest([], [function () { return false; }], false);
            ext.addTest([1], [function () { return false; }], false);
            
            // Test broken TODO FIX
            // ext.addTest([1, 2, 3, 4, 5], [function (a) { return a == 3; }], true);
            /*
            ext.addCustomTest(function () {
                var test = [1, 2, 3, 4, 5];
                var count = 0;
                test.while(function (a) {
                    count++;
                    return a == 3;
                });

                if (count != 3)
                    return 'until did not execute 3 times.';
            });
            */
        },
    });

function EnumerableUntil<T>(action: (item: T, index: number) => any) {
    if (!this || !action || this.length == 0)
        return false;

    var thisArray = <Array<T>>this;

    var exit = false;

    thisArray.while(function (item, i) {
        var result = action(item, i);

        exit = !(result === false || result === null || result === undefined);

        return exit;
    });

    return exit;
}

//
//////////////////////////////////////////////////////
//
// Lookup Functions

singEnumerable.method('count', EnumerableCount,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

function EnumerableCount<T>(action: (item: T, index: number) => any) {
    if (!this || !action)
        return 0;

    var thisArray = <Array<T>>this;

    var out = 0;

    thisArray.each(function (item, i) {
        var result = action(item, i);

        if (result !== null &&
            result !== undefined &&
            result !== false) {

            if ($.isNumber(result))
                out += result;
            else
                out++;
        }
    });
    return out;
}

singEnumerable.method('contains', EnumerableContains,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        aliases: ['has'],
        tests: function (ext) {
            ext.addTest([], [], false);
            ext.addTest([], [null], false);
            ext.addTest([], [undefined], false);
            ext.addTest([1, 2, 3, undefined], [], false);
            ext.addTest([1, 2, 3, undefined], [undefined], false);
            ext.addTest([1, 2, 3], [null], false);
            ext.addTest([1, 2, 3], [undefined], false);
            ext.addTest([1, 2, 3], [1], true);
            ext.addTest([1, 2, 3], [3, 4, 5], true);
            ext.addTest([1, 2, 3], [[3, 4, 5]], true);
            ext.addTest([1, 2, 3], [4, 5, 3], true);
            ext.addTest([1, 2, 3], [[4, 5, 3]], true);

            ext.addTest([1, 2, 3], [function (a: any) { return a == 2; }], true);
            ext.addTest([1, 2, 3], [function (a: any) { return a == 5; }], false);
        },
    });

function EnumerableContains<T>(...items: T[]) {

    var srcThis = <T[]>this;

    if (!srcThis ||
        items == null ||
        items == undefined)
        return false;

    if (items.length == 1) {

        if ($.isFunction(items[0])) {
            return !!this.first(items[0]);
        }

        return this.indexOf(items[0]) >= 0;
    }

    if (items.length > 1) {

        var result = items.first(function (it: T, i: number) {
            if (srcThis.contains(it))
                return true;
            return false;
        });

        return result !== undefined;
    }

    return false;
}

singEnumerable.method('select', EnumerableSelect,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        aliases: ['where'],
        tests: function (ext) {
            ext.addTest([], [], []);
            ext.addTest([], [null], []);
            ext.addTest([], [undefined], []);
            ext.addTest([1, 2, 3, undefined], [], []);
            ext.addTest([1, 2, 3, undefined], [function (a: any) { return a == 3; }], [3]);
            ext.addTest([1, 2, 3, undefined], [function (a: any) { return a === undefined; }], [undefined]);
            ext.addTest([1, 2, 3, undefined], [function (a: any) { return a < 3; }], [1, 2]);
        },
    });

function EnumerableSelect<T>(action: (item: T, index: number) => boolean): T[] {
    if (!this || !action)
        return [];

    var thisArray = <T[]>this;

    var out: T[] = [];

    thisArray.each(function (item, i) {
        var result = action(item, i);

        if (result != null &&
            result != undefined &&
            result != false)
            out = out.concat(item);
    });

    return out;
}

singEnumerable.method('collect', EnumerableCollect,
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
            ext.addTest([undefined], [], []);
            ext.addTest([null], [], []);
            ext.addTest([undefined, null], [], []);
            ext.addTest([1, 2, 3, undefined, null], [], [1, 2, 3]);
            ext.addTest([1, 2, 3, undefined, null], [function (a: any) { return a == 3; }], [false, false, true, false, false]);
            ext.addTest([1, 2, 3, undefined, null], [function (a: any) { return a <= 2; }], [true, true, false, false, true]);
            ext.addTest([1, 2, 3, undefined, null], [function (a: any) { return a + 1; }], [2, 3, 4, NaN, 1]);
            ext.addTest([1, 2, 3, undefined, null], [function (a: any) { return $.isDefined(a); }], [true, true, true, false, false]);
        },
    });

function EnumerableCollect<T>(action: (item: T, index: number) => any) {
    if (!this)
        return [];

    var thisArray = <T[]>this;

    if (action == null ||
        action == undefined)
        action = sing.func.identity;

    var out: T[] = [];
    thisArray.each(function (item, i) {
        var result = action(item, i);

        if (result !== null &&
            result !== undefined)
            out = out.concat(result);
    });
    return out;
}

singEnumerable.method('first', EnumerableFirst,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

function EnumerableFirst<T>(itemOrAction: number | T | ((item: T, index: number) => boolean)): T | T[] {
    if (!this)
        return;

    var thisArray = <T[]>this;

    if (!itemOrAction && this.length > 0)
        return this[0];

    if (!itemOrAction)
        return;

    if (ObjectIsNumber(itemOrAction))
        itemOrAction = function (item, i) { return i < <number>itemOrAction; };

    if ($.isFunction(itemOrAction)) {
        itemOrAction = function (item, i) { return item == itemOrAction; };
        return thisArray.select(<(item: T, index: number) => boolean>itemOrAction);
    }
    var out: any = undefined;

    thisArray.while(function (item, i) {
        var result = (<(item: T, index: number) => boolean>itemOrAction)(item, i);

        if (result == true) {
            out = item;
            return false;
        }
    });
    return out;
}

singEnumerable.method('last', EnumerableLast,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

function EnumerableLast<T>(itemOrAction: number | T | ((item: T, index: number) => boolean)): T | T[] {
    if (!this)
        return;

    var thisArray = <T[]> this;

    if (!itemOrAction && thisArray.length > 0)
        return thisArray[thisArray.length - 1];

    if (!itemOrAction)
        return;

    var out = <any>thisArray.reverse().first(<number | T | ((item: T, index: number) => boolean) >itemOrAction);

    return <T | T[]>out;
}

singEnumerable.method('range', EnumerableRange,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

function EnumerableRange<T>(start: number = 0, end: number = this.length - 1): T[] {
    if (!this || start > end)
        return [];

    var out: T[] = [];
    for (var i = start; i < end; i++) {
        out = out.concat(this[i]);
    }
    return out;
}

singEnumerable.method('flatten', EnumerableFlatten,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

function EnumerableFlatten(): any[] {
    if (!this)
        return [];

    var thisArray = <any[]>this;

    var out: any[] = [];

    thisArray.each(function (item, i) {
        if ($.isArray(item))
            out.concat(item.flatten());
        else
            out.concat(item);
    });

    return out;
}

singEnumerable.method('indices', EnumerableIndices,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        aliases: ['indexes'],
        tests: function (ext) {

            ext.addTest(['a'], ['a'], [0]);
            ext.addTest(['a'], ['b'], []);
            ext.addTest(['a'], [[undefined]], []);
            ext.addTest(['a'], [[null]], []);
            ext.addTest(['a'], [null], []);
            ext.addTest(['a', 'b'], ['a', 'b'], [0, 1]);

            ext.addTest(['a', 'a', 'a', 'b', 'b', 'b'], ['a', 'b'], [0, 1, 2, 3, 4, 5]);
        },
    });

function EnumerableIndices<T>(itemOrItemsOrFunction: T | T[]|((item: T, index: number) => boolean)): number[] {
    if (!this ||
        itemOrItemsOrFunction == null ||
        itemOrItemsOrFunction == undefined)
        return [];

    var thisArray = <T[]>this;

    if ($.isArray(itemOrItemsOrFunction)) {

        var itemArray = <T[]>itemOrItemsOrFunction;

        return thisArray.collect(function (item, i) {
            if (itemArray.contains(item))
                return i;
        });
    }

    if ($.isFunction(itemOrItemsOrFunction)) {

        var itemFunction = <(item: T, index: number) => boolean>itemOrItemsOrFunction;

        return thisArray.collect(function (item, i) {
            if (!!itemFunction(item, i))
                return i;
        });
    }

    var item = <T>itemOrItemsOrFunction;

    var index = thisArray.indexOf(item);

    if (index >= 0)
        return [index];
    else
        return [];
}

singEnumerable.method('remove', EnumerableRemove,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

function EnumerableRemove<T>(itemOrItemsOrFunction: T | T[]|((item: T, index: number) => boolean)): T[] {

    var thisArray = <T[]>this;

    if (!itemOrItemsOrFunction)
        return thisArray;

    if ($.isArray(itemOrItemsOrFunction)) {

        var itemArray = <T[]>itemOrItemsOrFunction;

        return thisArray.select(function (item, i) {
            return !itemArray.contains(item);
        });
    }

    if ($.isFunction(itemOrItemsOrFunction)) {

        var itemFunction = <(item: T, index: number) => boolean>itemOrItemsOrFunction;

        return thisArray.select(itemFunction.fn_not());
    }

    return thisArray.select(function (item, i) {
        return item == itemOrItemsOrFunction;
    });
}

singEnumerable.method('sortBy', EnumerableSortBy,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        aliases: ['orderBy'],
        tests: function (ext) {
        },
    });

function EnumerableSortBy<T>(arg?: string | string[]| ((item: T) => any)): T[] {

    var defaultValueFunc = function (item: T): any {
        return item;
    };

    if (arg == null) {
        arg = defaultValueFunc;
    }

    var indexes = <any[]>this;

    if ($.isString(arg) && (<string>arg).contains('.')) {
        arg = (<string>arg).split('.');
    }

    if ($.isString(arg)) {
        indexes = indexes.collect(function (item) {
            return $.objHasKey(item, <string>arg) && item != null ?
                defaultValueFunc(item[<string>arg]) : -1;
        });
    }
    else if ($.isArray(arg)) {

        var argArray = <string[]>arg;

        for (var i = 0; i < arg.length; i++) {

            indexes = indexes.collect(function (item) {
                if (!$.objHasKey(item, argArray[i])) {
                    return -1;
                }
                return item[argArray[i]] == null ? -1 : item[argArray[i]];
            });

        }

    }
    else {
        var argFunction = <(item: T) => number>arg;

        indexes = indexes.collect(argFunction);
    }
    /*
    if (!indexes.every($.isNumeric.fn_or($.isString))) {
        indexes = indexes.collect($.toStr)
            .collect(sing.methods['Singularity.Number.String.numericValueOf'].method);
    }
    */

    var items = this;

    return <T[]>indexes.quickSort([items]);
}

singEnumerable.method('quickSort', EnumerableQuickSort,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

function EnumerableQuickSort(sortWith?: any[][], left: number = 0, right: number = (this.length - 1)): any[]| any[][] {

    var items = this;

    if (sortWith && left == 0 && right == this.length - 1) {
        for (var i = 0; i < sortWith.length; i++) {
            if (sortWith[i] && sortWith[i].length != items.length) {
                console.log(this, sortWith);
                throw 'Lengths did not match ' + items.length + ', ' + sortWith[i].length;
            }
        }
    }

    var index: number;

    if (items.length > 1) {

        var partitionResult = EnumerableQuickSortPartition(items, left, right, sortWith);

        var index = partitionResult.index;
        items = partitionResult.items;
        sortWith = partitionResult.sortWith;

        if (left < index - 1) {
            if (sortWith != null) {
                var sorted = items.quickSort(left, index - 1, sortWith);
                items = sorted[0];
                for (var i = 1; i < sorted.length; i++) {
                    sortWith[i - 1] = sorted[i];
                }

            }
            else {
                items = items.quickSort(left, index - 1);
            }
        }

        if (index < right) {
            if (sortWith != null) {
                var sorted = items.quickSort(index, right, sortWith);

                items = sorted[0];
                for (var i = 1; i < sorted.length; i++) {
                    sortWith[i - 1] = sorted[i];
                }

            }
            else {
                items = items.quickSort(index, right);
            }
        }

    }

    if (sortWith != null) {
        var out: any[] = [];
        out.push(items);
        out = out.concat(sortWith);
        return out;
    }
    else {
        return items;
    }
}

function EnumerableQuickSortPartition(items: any[], left?: number, right?: number, sortWith?: any[][])
    : {
        items: any[];
        sortWith: any[][];
        index: number;
    } {

    var pivot = items[Math.floor((right + left) / 2)],
        i = left,
        j = right;


    while (i <= j) {

        while (items[i] < pivot) {
            i++;
        }

        while (items[j] > pivot) {
            j--;
        }

        if (i <= j) {
            var swapResult = EnumerableQuickSortSwap(items, i, j, sortWith);
            items = swapResult.items;
            sortWith = swapResult.sortWith;

            i++;
            j--;
        }
    }

    return {
        items: items,
        sortWith: sortWith,
        index: i,
    };
}

function EnumerableQuickSortSwap(items: any[], firstIndex: number, secondIndex: number, sortWith?: any[][]) {

    var temp = items[firstIndex];
    items[firstIndex] = items[secondIndex];
    items[secondIndex] = temp;

    if (sortWith != null) {
        for (var i = 0; i < sortWith.length; i++) {

            temp = sortWith[i][firstIndex];
            sortWith[i][firstIndex] = sortWith[i][secondIndex];
            sortWith[i][secondIndex] = temp;
        }
    }

    return {
        items: items,
        sortWith: sortWith,
    };
}

singEnumerable.method('timesDo', EnumerableTimesDo,
    {
        summary: "Repeats a function a number of times",
        parameters: [
            {
                name: 'executeFunc',
                types: [Function],
                desription: 'The function to execute',
                required: true,
            },
            {
                name: 'args',
                types: [Array],
                defaultValue: [],
                desription: '',
            },
            {
                name: 'caller',
                types: [Object],
                desription: '',
            },
        ],
        returns: 'An array of objects collected from the return values of executeFunc\'s executions.',
        returnType: Object,
        examples: ['\
            (5).timesDo(function() { alert(\'hi\'); });'],
        tests: function (ext) {
            /* TODO: FIX timesDo is causing a stack overflow
 
            ext.addCustomTest(function () {
                var test = 0;
                (5).timesDo(function () { test++; });
 
                if (test != 5)
                    return false;
            }, 'Must execute the function the correct number of times.');
            
            ext.addTest(1, [null], undefined, 'Passing a null function does nothing.');
            ext.addTest(1, [undefined], undefined, 'Passing an undefined function does nothing.');
 
            */
            ext.addTest(5, [sing.func.increment, [5]], [6, 6, 6, 6, 6]);
        },
    }, Number.prototype);

function EnumerableTimesDo(executeFunc: (...args: any[]) => any, args: any[], caller: any): any[] {

    if (!this || this <= 0 || !executeFunc)
        return;

    caller = caller || this;

    var out: any[] = [];

    for (var i = 0; i < this; i++) {
        if (!this)
            return;

        var result = executeFunc.apply(caller, args);

        if (result != null &&
            result != undefined)
            out.push(result);
    }

    return out;
}

