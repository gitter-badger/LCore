/// <reference path="singularity-core.ts"/>


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

    remove?: (item: T | T[] | ((a: T, b: number) => boolean)) => T[];

    count?: (item: T | T[] | ((arg: T, index: number) => boolean | number)) => number;

    //  contains?: (item: T | T[]| ((arg: T, index: number) => boolean)) => boolean;
    has?: (item: T | T[] | ((arg: T, index: number) => boolean)) => boolean;

    shuffle?: () => T[];


    first(count: number): T[];
    first(item: T): T;
    first(condition: Function): T;
    first(condition: ((item: T, index: number) => boolean)): T;
    first(itemOrCountOrAction: number | T | ((item: T, index: number) => boolean)): T | T[];

    last(count: number): T[];
    last(item: T): T;
    last(condition: ((item: T, index: number) => boolean)): T;
    last(itemOrCountOrAction: number | T | ((item: T, index: number) => boolean)): T | T[];
}

interface Number {
    timesDo?: (executeFunc: () => void, args?: any[], caller?: any) => any[];
}

var singEnumerable = singExt.addModule(new sing.Module('Enumerable', Array));

singEnumerable.glyphIcon = '&#xe012;';

singEnumerable.summaryShort = '&nbsp;';
singEnumerable.summaryLong = '&nbsp;';

//////////////////////////////////////////////////////
//
// Iteration Functions
//

singEnumerable.method('each', EnumerableEach,
    {
        summary: 'Call each on an array to enumerate the contents of the array.',
        parameters: [
            {
                name: 'action',
                description: 'The function to call on each item of the array. The object and the index are passed as parameters ' +
                'to this function',
                types: [Function]
            }
        ],
        returns: 'Nothing.',
        returnType: null,
        glyphIcon: '&#xe153;',
        tests(ext) {

            ext.addTest([], [], undefined);
            ext.addTest([], [null], undefined);
            ext.addTest([], [undefined], undefined);
            ext.addTest([], [() => { }], undefined);
            ext.addTest([], [() => true], undefined);
            ext.addTest([], [() => false], undefined);
            ext.addTest([1], [(a: any) => a], undefined);

            ext.addCustomTest(() => {
                var test = [1, 2, 3];
                var count = 0;
                test.each((a, i) => {
                    if (a == test[i])
                        count++;
                });

                if (count != 3)
                    return 'each did not execute 3 times.';
            });

        }
    });

function EnumerableEach<T>(action: (item: T, i: number) => void) {
    const thisArray = this as Array<T>;

    thisArray.while((item: T, i: number) => {
        action(item, i);

        // each always continues until the end
        return true;
    });
}

singEnumerable.method('while', EnumerableWhile,
    {
        summary: 'Call each on an array to enumerate the contents of the array. Return any non-null value to continue enumeration otherwise ' +
        'returning false will stop the enumeration.',
        parameters: [
            {
                name: 'action',
                description: 'The function to call on each item of the array. The object and the index are passed as parameters ' +
                'to this function',
                types: [Function]
            }
        ],
        returns: 'True if the function was able to complete or False if it was aborted prematurely.',
        returnType: Boolean,
        glyphIcon: '&#xe156;',
        tests(ext) {

            ext.addTest([], [], true);
            ext.addTest([], [null], true);
            ext.addTest([], [undefined], true);
            ext.addTest([], [() => { }], true);
            ext.addTest([], [() => true], true);
            ext.addTest([1], [() => true], true);
            ext.addTest([], [() => false], true);
            ext.addTest([1], [() => false], false);
            ext.addTest([1, 2, 3, 4, 5], [(a: any) => (a < 3)], false);
            ext.addTest([1, 2, 3, 4, 5], [(item: any, index: number) => (item == 4 && index == 3)], false);

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
        }
    });

function EnumerableWhile<T>(action: (item: T, index: number) => any) {
    if (!action)
        return true;

    let exit = false;

    for (let i = 0; i < this.length; i++) {
        const result = action(this[i], i);

        if (result == false)
            exit = true;

        if (exit)
            break;
    }

    return !exit;
}


singEnumerable.method('until', EnumerableUntil,
    {
        summary: 'Call each on an array to enumerate the contents of the array. Return any non-null value to stop enumeration otherwise ' +
        'it will continue until the end of the array.',
        parameters: [
            {
                name: 'action',
                description: 'The function to call on each item of the array. The object and the index are passed as parameters ' +
                'to this function',
                types: [Function]
            }
        ],
        returns: 'True if the function was able to complete or False if it was aborted prematurely.',
        returnType: Boolean,
        glyphIcon: '&#xe155;',
        tests(ext) {
            ext.addTest([], [], false);
            ext.addTest([], [null], false);
            ext.addTest([], [undefined], false);
            ext.addTest([], [() => { }], false);
            ext.addTest([], [() => true], false);
            ext.addTest([1], [() => true], true);
            ext.addTest([1, 2], [() => true], true);
            ext.addTest([], [() => false], false);
            ext.addTest([1], [() => false], false);

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
        }
    });

function EnumerableUntil<T>(action: (item: T, index: number) => any) {
    if (!action || this.length == 0)
        return false;

    const thisArray = this as Array<T>;

    var exit = false;

    thisArray.while((item, i) => {
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
        summary: 'count enumerates through an array counting how many objects match or satisfy a custom condition.',
        parameters: [
            {
                name: 'itemOrAction',
                description: 'Object or function to be evaluated. If a function is passed it will be evaluated, any non-null ' +
                'value will be added to the result. If anything other than a function is passed the number of occurences of ' +
                'the object will be counted. If this function returns a number, it will be added to the total result.',
                types: [Function, Object]
            }
        ],
        returns: 'The number of items that match the passed value or satisfy the given condition.',
        returnType: Number,
        glyphIcon: '&#xe141;',
        tests(ext) {
            ext.addTest([], [], 0);
            ext.addTest([null], [null], 1);
            ext.addTest(['a'], ['a'], 1);
            ext.addTest(['a'], [], 0);
            ext.addTest(['a', 'a'], ['a'], 2);
            ext.addTest(['a', 'a'], [(a: any) => (a == 'a')], 2);
            ext.addTest(['a', 'a'], [(a: any) => (a == 'b')], 0);

            ext.addTest([5, 6, 7], [(a: any) => a], 18);
        }
    });

function EnumerableCount<T>(itemOrAction: T | ((item: T, index: number) => any)) {
    if (itemOrAction === undefined)
        return 0;

    const thisArray = this as Array<T>;

    var out = 0;

    if (!$.isFunction(itemOrAction)) {
        var itemValue = itemOrAction as T;

        itemOrAction = (item: T) => (item == itemValue);
    }

    thisArray.each((item, i) => {
        var result = (itemOrAction as (item: T, index: number) => any)(item, i);

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

singEnumerable.method('has', EnumerableHas,
    {
        summary: 'has enumerates through an array and returns whether it contains an item, or items, or matches the passed condition.',
        parameters: [
            {
                name: 'itemOrItemsOrAction',
                description: 'An item, array of items, or condition function to determine whether a match has been found.',
                types: [Object, Array, Function]
            }
        ],
        returns: 'Whether a match was found.',
        returnType: Boolean,
        examples: null,
        glyphIcon: '&#xe003;',
        aliases: ['contains'],
        tests(ext) {
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

            ext.addTest([1, 2, 3], [(a: any) => (a == 2)], true);
            ext.addTest([1, 2, 3], [(a: any) => (a == 5)], false);
        }
    });

function EnumerableHas<T>(...items: T[]) {

    var srcThis = this as T[];

    if (items == null)
        return false;

    if (items.length == 1) {

        if ($.isFunction(items[0])) {
            const result = this.first(items[0]);
            return result !== undefined &&
                // ReSharper disable once QualifiedExpressionMaybeNull
                (!$.isArray(result) || result.length > 0);
        }

        if ($.isArray(items[0])) {
            return srcThis.has.apply(srcThis, items[0]);
        }

        return items[0] !== undefined && this.indexOf(items[0]) >= 0;
    }

    if (items.length > 1) {
        const result2 = items.first((it: T) => {
            if (it === undefined)
                return false;

            if (srcThis.has(it))
                return true;
            return false;
        });

        return !!result2;
    }

    return false;
}

singEnumerable.method('select', EnumerableSelect,
    {
        summary: 'select enumerates a list and filters its contents based on the filter function you provide.',
        parameters: [
            {
                name: 'filter',
                description: 'A function that takes the item and index as parameters. ' +
                'Any return value that isn\'t undefined, null, or false will cause the item to be included in the final result.',
                types: [Function]
            }
        ],
        returns: 'A filtered array.',
        returnType: Array,
        glyphIcon: '&#xe057;',
        aliases: ['where'],
        tests(ext) {
            ext.addTest([], [], []);
            ext.addTest([], [null], []);
            ext.addTest([], [undefined], []);
            ext.addTest([1, 2, 3, undefined], [], []);
            ext.addTest([1, 2, 3, undefined], [(a: any) => (a == 3)], [3]);
            ext.addTest([1, 2, 3, undefined], [(a: any) => (a === undefined)], [undefined]);
            ext.addTest([1, 2, 3, undefined], [(a: any) => (a < 3)], [1, 2]);
        }
    });

function EnumerableSelect<T>(filter: (item: T, index: number) => boolean): T[] {
    if (!filter)
        return [];

    const thisArray = this as T[];

    var out: T[] = [];

    thisArray.each((item, i) => {
        var result = filter(item, i);

        if (result != null &&
            result != false)
            out = out.concat(item);
    });

    return out;
}

singEnumerable.method('collect', EnumerableCollect,
    {
        summary: 'collect acts on an array and passes its values to the collection function you provide.',
        parameters: [
            {
                name: 'collector',
                description: 'This function is passed the item and index. Its return values will be included in the ' +
                'final result. If the return value is undefined or null, it will not be included.',
                types: [Function]
            }
        ],
        returns: 'A filtered array of the values you return from the collection function.',
        returnType: null,
        examples: null,
        glyphIcon: '&#xe058;',
        tests(ext) {
            ext.addTest([], [], []);
            ext.addTest([], [null], []);
            ext.addTest([], [undefined], []);
            ext.addTest([undefined], [], []);
            ext.addTest([null], [], []);
            ext.addTest([undefined, null], [], []);
            ext.addTest([1, 2, 3, undefined, null], [], [1, 2, 3]);
            ext.addTest([1, 2, 3, [4, 5, 6]], [], [1, 2, 3, [4, 5, 6]]);
            ext.addTest([1, 2, 3, undefined, null], [(a: any) => (a == 3)], [false, false, true, false, false]);
            ext.addTest([1, 2, 3, undefined, null], [(a: any) => (a <= 2)], [true, true, false, false, true]);
            ext.addTest([1, 2, 3, undefined, null], [(a: any) => (a + 1)], [2, 3, 4, NaN, 1]);
            ext.addTest([1, 2, 3, undefined, null], [(a: any) => $.isDefined(a)], [true, true, true, false, false]);
        }
    });

function EnumerableCollect<T>(collector: (item: T, index: number) => any) {
    const thisArray = this as T[];

    if (collector == null)
        collector = sing.func.identity;

    var out: T[] = [];
    thisArray.each((item, i) => {
        var result = collector(item, i);

        if (result !== null &&
            result !== undefined)
            out.push(result);
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
        glyphIcon: '&#xe070;',
        tests(ext) {
            ext.addTest([], [], []);
            ext.addTest([], [null], []);
            ext.addTest([], [undefined], []);
            ext.addTest([], [5], []);
            ext.addTest([1, 2, 3, 4, 5], [0], []);
            ext.addTest([1, 2, 3, 4, 5], [2], [1, 2]);
            ext.addTest([1, 2, 3, 4, 5], [5], [1, 2, 3, 4, 5]);
            ext.addTest([1, 2, 3, 4, 5], [8], [1, 2, 3, 4, 5]);

            ext.addTest([1, 2, 3, 'a', 5], ['a'], []);

            ext.addTest([1, 2, 3, 4, 5], [(a: number) => (a == 3)], [3]);
            ext.addTest([1, 2, 3, 4, 5], [(a: number) => (a != 3)], [1]);
        }
    });

function EnumerableFirst<T>(countOrCondition: number | ((item: T, index: number) => boolean)): T | T[] {

    if (countOrCondition <= 0)
        return [];

    const thisArray = this as T[];

    if (!countOrCondition && this.length > 0)
        return this[0];

    if (!countOrCondition)
        return [];

    if (ObjectIsNumber(countOrCondition)) {
        var itemNumber = countOrCondition as number;

        var outArray: any[] = [];

        thisArray.while((item) => {
            outArray.push(item);
            if (outArray.length == itemNumber)
                return false;
        });
        return outArray;
    }
    if (!$.isFunction(countOrCondition)) {
        return [];
    }

    var out: any = undefined;

    thisArray.while((item, i) => {
        var result = (countOrCondition as (item: T, index: number) => boolean)(item, i);

        if (result) {
            out = item;
            return false;
        }
    });
    return out;
}

singEnumerable.method('last', EnumerableLast,
    {
        summary: null,
        parameters: [
            {
                name: 'countOrCondition',
                types: [Number, Function],
                description: 'If a number is passed, '
            }
        ],
        returns: '',
        returnType: null,
        examples: null,
        glyphIcon: '&#xe076;',
        tests(ext) {
            ext.addTest([], [], []);
            ext.addTest([], [null], []);
            ext.addTest([], [undefined], []);
            ext.addTest([], [5], []);
            ext.addTest([1, 2, 3, 4, 5], [0], []);
            ext.addTest([1, 2, 3, 4, 5], [2], [4, 5]);
            ext.addTest([1, 2, 3, 4, 5], [5], [1, 2, 3, 4, 5]);
            ext.addTest([1, 2, 3, 4, 5], [8], [1, 2, 3, 4, 5]);

            ext.addTest([1, 2, 3, 'a', 5], ['a'], []);

            ext.addTest([1, 2, 3, 4, 5], [(a: number) => (a > 3)], [5]);
            ext.addTest([1, 2, 3, 4, 5], [(a: number) => (a < 3)], [2]);
            ext.addTest([1, 2, 3, 4, 5], [(a: number) => (a != 3)], [5]);
        }
    });

function EnumerableLast<T>(countOrCondition: number | ((item: T, index: number) => boolean)): T | T[] {

    if (countOrCondition <= 0)
        return [];

    const thisArray = this as T[];

    if (!countOrCondition && thisArray.length > 0)
        return thisArray[thisArray.length - 1];

    if (!countOrCondition)
        return [];

    let out = thisArray.clone().reverse().first(countOrCondition) as any;

    if ($.isArray(out))
        out = out.reverse();

    return out as T | T[];
}

singEnumerable.method('range', EnumerableRange,
    {
        summary: 'Retrieves a range of items from an array.',
        parameters: [
            {
                name: 'start',
                description: ''
            },
            {
                name: 'end',
                description: ''
            }
        ],
        returns: 'A range of items as an array.',
        returnType: Array,
        examples: null,
        glyphIcon: '&#xe120;',
        tests(ext) {
            ext.addTest([], [], []);
            ext.addTest([], [0, 1], []);
            ext.addTest([], [null], []);
            ext.addTest([], [undefined], []);
            ext.addTest([1, 2, 3, 4, 5], [0, 1], [1, 2]);
            ext.addTest([1, 2, 3, 4, 5], [0, 1, null], [1, 2]);
            ext.addTest([1, 2, 3, 4, 5], [0, 1, undefined], [1, 2]);

            ext.addTest([1, 2, 3, 4, 5], [0, 4], [1, 2, 3, 4, 5]);
            ext.addTest([1, 2, 3, 4, 5], [3, 4], [4, 5]);

            ext.addTest([1, 2, 3, 4, 5], [4, 3], []);
        }
    });

function EnumerableRange<T>(start: number = 0, end: number = this.length - 1): T[] {
    if (start > end)
        return [];

    if (start < 0)
        start = 0;

    if (end < 0)
        end = 0;

    const out: T[] = [];
    for (let i = start; i <= end && i >= 0 && i < this.length; i++) {
        out.push(this[i]);
    }
    return out;
}

singEnumerable.method('flatten', EnumerableFlatten,
    {
        summary: 'Traverses an array of possibly nested items.',
        parameters: [],
        returns: 'A \'flattened\' single-level array of all items.',
        returnType: Array,
        glyphIcon: '&#xe245;',
        tests(ext) {
            ext.addTest([], [], []);
            ext.addTest([1], [], [1]);
            ext.addTest([1, 2, 3], [], [1, 2, 3]);
            ext.addTest([1, 2, [3, 4, 5]], [], [1, 2, 3, 4, 5]);
            ext.addTest([1, 2, [3, 4, [5, 6, 7, 8]]], [], [1, 2, 3, 4, 5, 6, 7, 8]);
            ext.addTest([[[1, 2, 3], 4], 5, 6, 7, 8], [], [1, 2, 3, 4, 5, 6, 7, 8]);
        }
    });

function EnumerableFlatten(): any[] {
    const thisArray = this as any[];

    var out: any[] = [];

    thisArray.each((item) => {
        if ($.isArray(item))
            out = out.concat(item.flatten());
        else
            out.push(item);
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
        glyphIcon: '&#xe056;',
        aliases: ['indexes'],
        tests(ext) {

            ext.addTest(['a'], ['a'], [0]);
            ext.addTest(['a'], ['b'], []);
            ext.addTest(['a'], [[undefined]], []);
            ext.addTest(['a'], [[null]], []);
            ext.addTest(['a'], [null], []);
            ext.addTest(['a', 'b'], ['a', 'b'], [0, 1]);
            ext.addTest(['a', 'b'], [['a', 'b']], [0, 1]);

            ext.addTest(['a', 'a', 'a', 'b', 'b', 'b'], ['a', 'b'], [0, 1, 2, 3, 4, 5]);
        }
    });

function EnumerableIndices<T>(...items: any[]): number[] {

    const thisArray = this as T[];

    let item: any;

    if (items.length == 1) {
        item = items[0];
    }
    else {
        item = items;
    }

    if ($.isArray(item)) {

        var itemArray = item as T[];

        return thisArray.collect((arrayItem, i) => {
            if (itemArray.has(arrayItem))
                return i;
        });
    }

    if ($.isFunction(item)) {

        var itemFunction = item as (item: T, index: number) => boolean;

        return thisArray.collect((item, i) => {
            // ReSharper disable once DoubleNegationOfBoolean
            if (!!itemFunction(item, i))
                return i;
        });
    }

    const index = thisArray.indexOf(item);

    if (index >= 0)
        return [index];
    else
        return [];
}

singEnumerable.method('remove', EnumerableRemove,
    {
        summary: 'Enumerates an array removing items that match the provided values.',
        parameters: [
            {
                name: 'itemOrItemsOrFunction',
                description: 'Passing a single item or array of items will exclude the items from the result. ' +
                'Passing a function will evaluate each item, a true value will cause the item to be excluded from the result.',
                types: [Function]
            }
        ],
        returns: 'A filtered array with matching item(s) excluded.',
        returnType: Array,
        glyphIcon: '&#xe163;',
        tests(ext) {
            ext.addTest([], [], []);
            ext.addTest([], [null], []);
            ext.addTest([null, undefined], [null], []);
            ext.addTest([], [undefined], []);
            ext.addTest([null, undefined], [undefined], []);
            ext.addTest([null, undefined], [], []);
            ext.addTest([], [1], []);
            ext.addTest([1], [1], []);
            ext.addTest([1, 2], [1], [2]);
            ext.addTest([1, 2], [[1, 2]], []);
            ext.addTest([1, 2], [[1, 2, null]], []);
            ext.addTest([1, 2], [[1, 2, undefined]], []);
        }
    });

function EnumerableRemove<T>(itemOrItemsOrFunction: T | T[] | ((item: T, index: number) => boolean)): T[] {

    const thisArray = this as T[];

    if (!itemOrItemsOrFunction)
        return thisArray.collect();

    if ($.isArray(itemOrItemsOrFunction)) {

        var itemArray = itemOrItemsOrFunction as T[];

        return thisArray.select((item) => (!itemArray.has(item)));
    }

    if ($.isFunction(itemOrItemsOrFunction)) {

        const itemFunction = itemOrItemsOrFunction as (item: T, index: number) => boolean;

        return thisArray.select(itemFunction.fn_not());
    }

    return thisArray.select((item) => (item != itemOrItemsOrFunction));
}

singEnumerable.method('sortBy', EnumerableSortBy,
    {
        summary: 'Sorts the source array by a custom property or function accessor.',
        parameters: [
            {
                name: 'arg',
                description: 'An optional argument ',
                types: [Array]
            }
        ],
        returns: 'A sorted array.',
        returnType: Array,
        glyphIcon: '&#xe150;',
        aliases: ['orderBy'],
        tests(ext) {
            ext.addTest([], [], []);
            ext.addTest(['a', 'b', 'c', 'd', 'e'], [], ['a', 'b', 'c', 'd', 'e']);
            ext.addTest(['e', 'd', 'c', 'b', 'a'], [], ['a', 'b', 'c', 'd', 'e']);
            ext.addTest(['d', 'a', 'c', 'e', 'b'], [], ['a', 'b', 'c', 'd', 'e']);
            ext.addTest(['bananas', 'apples', 'apple pie', 'apple', 'pears', 'grapefruit', 'eggs'],
                [], ['apple', 'apple pie', 'apples', 'bananas', 'eggs', 'grapefruit', 'pears']);

            ext.addTest(['bananas', 'apples', 'apple pie', 'apple', 'pears', 'grapefruit', 'eggs'],
                ['length'], ['eggs', 'apple', 'pears', 'apples', 'bananas', 'apple pie', 'grapefruit']);

            ext.addTest([{ name: 'frank', age: 111 }, { name: 'steve', age: 12 }, { name: 'bob', age: 52 }],
                ['name'], [{ name: 'bob', age: 52 }, { name: 'frank', age: 111 }, { name: 'steve', age: 12 }]);
            ext.addTest([{ name: 'frank', age: 111 }, { name: 'steve', age: 12 }, { name: 'bob', age: 52 }],
                ['age'], [{ name: 'steve', age: 12 }, { name: 'bob', age: 52 }, { name: 'frank', age: 111 }]);

            ext.addTest([{ name: 'frank', age: 111 }, { name: 'steve', age: 12 }, { name: 'bob', age: 52 }],
                [(a: any) => a.name], [{ name: 'bob', age: 52 }, { name: 'frank', age: 111 },
                    { name: 'steve', age: 12 }]);
            ext.addTest([{ name: 'frank', age: 111 }, { name: 'steve', age: 12 }, { name: 'bob', age: 52 }],
                [(a: any) => a.age], [{ name: 'steve', age: 12 }, { name: 'bob', age: 52 },
                    { name: 'frank', age: 111 }]);
        }
    });

function EnumerableSortBy<T>(arg?: string | string[] | ((item: T) => any)): T[] {

    var defaultValueFunc = (item: T): any => item;

    if (arg == null) {
        arg = defaultValueFunc;
    }

    let customIndex = false;

    let indexes = this.clone() as any[];

    if ($.isString(arg) && (arg as string).contains('.')) {
        arg = (arg as string).split('.');
    }

    if ($.isString(arg)) {
        customIndex = true;
        indexes = indexes.collect(item => ($.objHasKey(item, arg as string) && item != null ?
            defaultValueFunc(item[arg as string]) : -1));
    }
    else if ($.isArray(arg)) {

        var argArray = arg as string[];

        for (var i = 0; i < arg.length; i++) {

            customIndex = true;

            indexes = indexes.collect(item => {
                // ReSharper disable once ClosureOnModifiedVariable
                if (!$.objHasKey(item, argArray[i])) {
                    return -1;
                }
                // ReSharper disable ClosureOnModifiedVariable
                return item[argArray[i]] == null ? -1 : item[argArray[i]];
                // ReSharper restore ClosureOnModifiedVariable
            });

        }

    }
    else {
        const argFunction = arg as (item: T) => number;

        customIndex = true;

        indexes = indexes.collect(argFunction);
    }
    /*
    if (!indexes.every($.isNumeric.fn_or($.isString))) {
        indexes = indexes.collect($.toStr)
            .collect(sing.methods['Singularity.Number.String.numericValueOf'].method);
    }
    */

    const items = this.clone();

    if (customIndex) {
        const out = (indexes.quickSort([items]) as QuickSortResult);

        if (out.sortWith)
            return out.sortWith[0] as T[];
        else
            return out.items;
    } else
        return indexes.quickSort([items]) as T[];
}

singEnumerable.method('quickSort', EnumerableQuickSort,
    {
        summary: 'Performs the built-in JavaScript comparison to sort the items in the source array.',
        parameters: [
            {
                name: 'sortWith',
                description: 'Optional companion array(s) which will be reordered along with the source array.',
                types: [Array]
            }
        ],
        returns: 'A sorted array.',
        returnType: Array,
        glyphIcon: '&#xe150;',
        tests(ext) {
            ext.addTest([], [], []);
            ext.addTest(['a', 'b', 'c', 'd', 'e'], [], ['a', 'b', 'c', 'd', 'e']);
            ext.addTest(['e', 'd', 'c', 'b', 'a'], [], ['a', 'b', 'c', 'd', 'e']);
            ext.addTest(['d', 'a', 'c', 'e', 'b'], [], ['a', 'b', 'c', 'd', 'e']);
            ext.addTest(['bananas', 'apples', 'apple pie', 'apple', 'pears', 'grapefruit', 'eggs'],
                [], ['apple', 'apple pie', 'apples', 'bananas', 'eggs', 'grapefruit', 'pears']);

            ext.addTest([5, 4, 3, 2, 1], [], [1, 2, 3, 4, 5]);

            ext.addCustomTest(() => {
                var test = [1, 2, 3, 4, 5];

                var result = ['d', 'a', 'c', 'e', 'b'].quickSort([test]);

                test = (result as QuickSortResult).sortWith[0];

                if ($.toStr(test) != $.toStr([2, 5, 3, 1, 4]))
                    return 'test failed.';
            });
        }
    });

function EnumerableQuickSort(sortWith?: any[][], left: number = 0, right: number = (this.length - 1)): any[] | QuickSortResult {

    let thisArray = this as any[];

    if (sortWith && left == 0 && right == this.length - 1) {
        for (let i = 0; i < sortWith.length; i++) {
            if (sortWith[i] && sortWith[i].length != thisArray.length) {
                console.log(this, sortWith);
                throw `Lengths did not match ${thisArray.length}, ${sortWith[i].length}`;
            }
        }
    }
    if (thisArray.length > 1) {

        const partitionResult = EnumerableQuickSortPartition(thisArray, left, right, sortWith);
        const index = partitionResult.index;
        thisArray = partitionResult.items;
        sortWith = partitionResult.sortWith;
        let sorted: any[] | QuickSortResult;
        if (left < index - 1) {
            if (!$.isEmpty(sortWith)) {
                sorted = thisArray.quickSort(sortWith, left, index - 1);
                if ($.isHash(sorted)) {
                    thisArray = (sorted as QuickSortResult).items;
                    sortWith = (sorted as QuickSortResult).sortWith;
                }
                else {
                    thisArray = (sorted as any[]);
                }

            }
            else {
                thisArray = (thisArray.quickSort(sortWith, left, index - 1) as any[]);
            }
        }

        if (index < right) {
            if (!$.isEmpty(sortWith)) {
                sorted = thisArray.quickSort(sortWith, index, right);
                if ($.isHash(sorted)) {
                    thisArray = (sorted as QuickSortResult).items;
                    sortWith = (sorted as QuickSortResult).sortWith;
                }
                else {
                    thisArray = (sorted as any[]);
                }
            }
            else {
                thisArray = (thisArray.quickSort(sortWith, index, right) as any[]);
            }
        }

    }

    if (sortWith != null && !$.isEmpty(sortWith)) {

        return {
            items: thisArray,
            sortWith: sortWith
        };
    }
    else {
        return thisArray;
    }
}

interface QuickSortResult {
    items: any[];
    sortWith: any[][];
}

function EnumerableQuickSortPartition(items: any[], left?: number, right?: number, sortWith?: any[][])
    : {
        items: any[];
        sortWith: any[][];
        index: number;
    } {
    const pivot = items[Math.floor((right + left) / 2)];
    let i = left;
    let j = right;


    while (i <= j) {

        while (items[i] < pivot) {
            i++;
        }

        while (items[j] > pivot) {
            j--;
        }

        if (i <= j) {
            const swapResult = EnumerableQuickSortSwap(items, i, j, sortWith);
            items = swapResult.items;

            if ($.toStr(swapResult.sortWith) == '0')
                swapResult.sortWith = swapResult.sortWith;

            sortWith = swapResult.sortWith;

            i++;
            j--;
        }
    }

    return {
        items: items,
        sortWith: sortWith,
        index: i
    };
}

function EnumerableQuickSortSwap(items: any[], firstIndex: number, secondIndex: number, sortWith?: any[][]) {

    let temp = items[firstIndex];
    items[firstIndex] = items[secondIndex];
    items[secondIndex] = temp;

    if (sortWith != null) {
        for (let i = 0; i < sortWith.length; i++) {

            temp = sortWith[i][firstIndex];
            sortWith[i][firstIndex] = sortWith[i][secondIndex];
            sortWith[i][secondIndex] = temp;
        }
    }

    return {
        items: items,
        sortWith: sortWith
    };
}

singEnumerable.method('timesDo', EnumerableTimesDo,
    {
        summary: 'Repeats a function a number of times',
        parameters: [
            {
                name: 'executeFunc',
                types: [Function],
                description: 'The function to execute',
                required: true
            },
            {
                name: 'args',
                types: [Array],
                defaultValue: [],
                description: ''
            },
            {
                name: 'caller',
                types: [Object],
                description: ''
            }
        ],
        returns: 'An array of objects collected from the return values of executeFunc\'s executions.',
        returnType: Object,
        examples: ['\
            (5).timesDo(function() { alert(\'hi\'); });'],
        glyphIcon: '&#xe137;',
        tests(ext) {
            /*
            ext.addCustomTest(function () {
                var test = 0;
                (5).timesDo(function () { test++; });
    
                if (test != 5)
                    return false;
            }, 'Must execute the function the correct number of times.');
    
            ext.addFailsTest(1, [null], undefined, 'Singularity.Extensions.Enumerable.timesDo Missing Parameter: function executeFunc');
            ext.addFailsTest(1, [undefined], undefined, 
            'Singularity.Extensions.Enumerable.timesDo Missing Parameter: function executeFunc');
            */
            ext.addTest(5, [sing.func.increment, [5]], [6, 6, 6, 6, 6]);
        }
    }, Number.prototype);

function EnumerableTimesDo(executeFunc: (...args: any[]) => any, args: any[], caller: any): any[] {

    if (!$.isDefined(this) ||
        this <= 0 ||
        !$.isDefined(executeFunc))
        return [];

    caller = caller || this;

    const out: any[] = [];

    for (let i = 0; i < this; i++) {
        const result = executeFunc.apply(caller, args);

        if (result != null)
            out.push(result);
    }

    return out;
}

