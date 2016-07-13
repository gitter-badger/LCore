/// <reference path="singularity-core.ts"/>

// ReSharper disable once InconsistentNaming
interface JQueryStatic {

    objEach<T>(objHash: IHash<T>, eachFunc: (key: string, item: T, i: number) => any): any[];
    objEach(obj: any, eachFunc: (key: string, item: any, i: number) => any): any[];

    objProperties<T>(objHash?: IHash<T>): [{ key: string; value: T; }];
    objProperties(obj?: any): [{ key: string; value: any; }];

    objValues<T>(objHash?: IHash<T>): T[];
    objValues(obj?: any): any[];

    objKeys?: (obj?: any) => string[];

    objHasKey?: (obj: Object, key: string) => boolean;
    resolve?: (obj?: Object | any[] | Function) => Object;

    isDefined?: (obj?: any) => boolean;
    isHash?: (obj?: any) => boolean;

    isEmpty?: (obj?: any) => boolean;

    typeName?: (obj?: any) => string;

    clone(obj: any, deepClone?: boolean): any;
    clone<T>(obj: T, deepClone?: boolean): T;
}


// ReSharper disable once InconsistentNaming
interface JQuery {
}

interface Array<T> {

    clone?: (deepClone?: boolean) => T[];

}

interface String {
    clone?: () => string;
}

interface Number {
    clone?: () => number;
}

interface Boolean {
    clone?: () => boolean;
}

interface Date {
    clone?: () => Date;
}

var singObject = singExt.addModule(new sing.Module('Object', $, $));

singObject.glyphIcon = '&#xe165;';

singObject.srcLink = '/Scripts/singularity/singularity-object.ts';

singObject.ignoreUnknown('ALL');

singObject.method('objEach', objectEach,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: '',
        examples: null,
        glyphIcon: '&#xe153;',
        tests(ext) {

            ext.addCustomTest(() => {

                var test = { a: 1, b: 2 };
                var test2: any[] = [];

                $.objEach(test, (key, item, index) => {
                    test2.push({ key: key, item: item, index: index });
                });

                if ($.toStr(test2) != $.toStr([{ key: 'a', item: 1, index: 0 },
                    { key: 'b', item: 2, index: 1 }]))
                    return `${$.toStr(test2)}\r\n${$.toStr([{ key: 'a', item: 1, index: 0 },
                    { key: 'b', item: 2, index: 1 }])}`;

            }, 'Executes for every element');
        }
    });

function objectEach(obj: IHash<any>, eachFunc: (key: string, item: any, index: number) => void): void {

    const keys = Object.keys(obj);

    keys.each((key, i) => {
        eachFunc(key, obj[key], i);
    });
}

singObject.method('objProperties', objectProperties,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: '',
        examples: null,
        glyphIcon: '&#xe056;',
        tests(ext) {
            ext.addTest($, [null], []);
            ext.addTest($, [undefined], []);
            ext.addTest($, [['a']], [{ key: '0', value: 'a' }]);
            ext.addTest($, [5], []);
            ext.addTest($, [[]], []);
            ext.addTest($, [{}], []);
            ext.addTest($, [{ a: 1, b: 2 }], [{ key: 'a', value: 1 }, { key: 'b', value: 2 }]);
        }
    });

function objectProperties(obj?: IHash<any>): { key: string; value: any }[] {
    if (obj == null || !(typeof obj == 'object'))
        return [];

    const keys = Object.keys(obj);

    const values = keys.collect((item) => ({ key: item, value: obj[item] })) as [{ key: string; value: any }];

    return values;
}

singObject.method('objValues', objectValues,
    {
        summary: null,
        parameters: null,
        validateInput: false,
        returns: '',
        returnType: '',
        examples: null,
        glyphIcon: '&#xe055;',
        tests(ext) {
            ext.addTest($, [null], []);
            ext.addTest($, [undefined], []);
            ext.addTest($, ['a'], []);
            ext.addTest($, ['a', 'b'], []);
            ext.addTest($, [5], []);
            ext.addTest($, [[]], []);
            ext.addTest($, [{}], []);
            ext.addTest($, [{ a: 1, b: 2 }], [1, 2]);


            ext.addTest($, [{ a: 'b', c: 'd' }, ['a']], 'b');
            ext.addTest($, [{ a: 'b', c: 'd' }, ['b']], null);
            ext.addTest($, [{ a: 'b', c: 'd' }, ['c']], 'd');
        }
    });

function objectValues(obj?: IHash<any> | any[], findKeys?: string[]): any[] {
    if (obj == null || !(typeof obj == 'object'))
        return null;

    if (findKeys != null && findKeys.length > 0) {
        if ($.isArray(obj)) {
            return (obj as any[]).arrayValues.apply(obj, findKeys);
        }
        else {
            return [obj].arrayValues.apply([obj], findKeys);
        }
    }
    else {
        const keys = Object.keys(obj);

        const values = keys.collect((item) => (obj as any)[item]);

        return values;
    }
}

singObject.method('arrayValues', arrayFindValues,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        glyphIcon: '&#xe055;',
        tests(ext) {
            ext.addTest([], [null], []);
            ext.addTest([], [undefined], []);
            ext.addTest([1], [null], []);
            ext.addTest([1], [undefined], []);
            ext.addTest([{ a: 'b', c: 'd' }, { a: 'b2', c: 'd2' }], ['a'], ['b', 'b2']);
            ext.addTest([{ a: 'b', c: 'd' }, { a: 'b2', c: 'd2' }], ['b'], []);
            ext.addTest([{ a: 'b', c: 'd' }, { a: 'b2', c: 'd2' }], ['c'], ['d', 'd2']);
            ext.addTest([{ a: { name: 'a' }, b: { name: 'b' }, c: { name: 'c' } },
                { a: { name: 'a2' }, b: { name: 'b2' }, c: { name: 'c2' } }], ['a.name'], ['a', 'a2']);
            ext.addTest([{ a: { name: 'a' }, b: { name: 'b' }, c: { name: 'c' } },
                { a: { name: 'a2' }, b: { name: 'b2' }, c: { name: 'c2' } }], ['b.name'], ['b', 'b2']);
            ext.addTest([{ a: { name: 'a' }, b: { name: 'b' }, c: { name: 'c' } },
                { a: { name: 'a2' }, b: { name: 'b2' }, c: { name: 'c2' } }], ['c.name'], ['c', 'c2']);
            ext.addTest([{ a: { name: 'a' }, b: { name: 'b' }, c: { name: 'c' } },
                { a: { name: 'a2' }, b: { name: 'b2' }, c: { name: 'c2' } }], ['a', 'name'], ['a', 'a2']);
            ext.addTest([{ a: { name: 'a' }, b: { name: 'b' }, c: { name: 'c' } },
                { a: { name: 'a2' }, b: { name: 'b2' }, c: { name: 'c2' } }], ['b', 'name'], ['b', 'b2']);
            ext.addTest([{ a: { name: 'a' }, b: { name: 'b' }, c: { name: 'c' } },
                { a: { name: 'a2' }, b: { name: 'b2' }, c: { name: 'c2' } }], ['c', 'name'], ['c', 'c2']);
        }
    }, Array.prototype);

function arrayFindValues<T>(...names: string[]): any[] {
    if (!names || names.length == 0 || names[0] == null)
        return [];

    if (names.length == 1 && names[0].contains('.')) {
        names = names[0].split('.');
    }
    if (names.length > 0) {
        var name = names.shift();
        const thisArray = this as IHash<any>[];
        const out = thisArray.collect(item => {

            if (!item || !item[name])
                return null;
            else
                return item[name];
        });

        if (names.length > 0) {
            return out.arrayValues.apply(out, names);
        }
        else {
            return out;
        }
    }

    return [];
}

singObject.method('objKeys', objectKeys,
    {
        summary: null,
        parameters: null,
        validateInput: false,
        returns: '',
        returnType: '',
        examples: null,
        glyphIcon: 'icon-keys',
        tests(ext) {
            ext.addTest($, [null], []);
            ext.addTest($, [undefined], []);
            ext.addTest($, ['a'], []);
            ext.addTest($, ['a', 'b'], []);
            ext.addTest($, [5], []);
            ext.addTest($, [[]], []);
            ext.addTest($, [{}], []);
            ext.addTest($, [{ a: 1, b: 2 }], ['a', 'b']);
        }
    }, $);

function objectKeys(obj?: Object): string[] {
    if (obj == null || !(typeof obj == 'object'))
        return [];

    const keys = Object.keys(obj);

    return keys;
}

singObject.method('objHasKey', objectHasKey,
    {
        summary: null,
        parameters: null,
        validateInput: false,
        returns: '',
        returnType: '',
        examples: null,
        glyphIcon: '&#xe003;',
        tests(ext) {
            ext.addTest(null, [], false);
            ext.addTest(null, [null, 'a'], false);
            ext.addTest(null, [{ b: 'a' }, 'a'], false);
            ext.addTest(null, [{ a: 'b' }, 'a'], true);
        }
    });

function objectHasKey(obj: any, key: string): boolean {
    if (!$.isDefined(obj))
        return false;

    return $.isDefined(obj[key]) || Object.keys(obj).has(key);
}

singObject.method('resolve', objectResolve,
    {
        summary: null,
        parameters: null,
        validateInput: false,
        returns: '',
        returnType: '',
        examples: null,
        glyphIcon: '&#xe162;',
        tests(ext) {
            ext.addTest($, [5], 5);
            ext.addTest($, ['aa'], 'aa');
            ext.addTest($, [['aa', 'bb']], ['aa', 'bb']);
            ext.addTest($, [() => 5], 5);
            ext.addTest($, [() => 'aa'], 'aa');
            ext.addTest($, [() => ['aa', 'bb']], ['aa', 'bb']);
        }
    });

function objectResolve(obj: any, args: any[]): any {

    if ($.isFunction(obj))
        return obj.apply(null, args);

    if ($.isArray(obj) && obj.length == 1)
        return obj[0];

    return obj;
}

singObject.method('isDefined', objectDefined,
    {
        summary: null,
        parameters: null,
        validateInput: false,
        returns: '',
        returnType: '',
        examples: null,
        glyphIcon: '&#xe003;',
        tests(ext) {

            ext.addTest(null, [undefined], false);
            ext.addTest(null, [null], false);
            ext.addTest(null, [0], true);
            ext.addTest(null, ['a'], true);
            ext.addTest(null, [['a']], true);
            ext.addTest(null, [{}], true);
            ext.addTest(null, [{ name: 'a' }], true);
        }
    });

function objectDefined(obj?: any) {
    if (obj !== undefined && obj !== null)
        return true;

    return false;
}

singObject.method('isHash', objectIsHash,
    {
        summary: null,
        parameters: null,
        validateInput: false,
        returns: '',
        returnType: '',
        examples: null,
        glyphIcon: 'icon-show-thumbnails',
        tests(ext) {

            ext.addTest(null, [undefined], false);
            ext.addTest(null, [null], false);
            ext.addTest(null, [0], false);
            ext.addTest(null, ['a'], false);
            ext.addTest(null, [['a']], false);
            ext.addTest(null, [{}], true);
            ext.addTest(null, [{ a: 'a' }], true);
        }
    });

function objectIsHash(obj?: any) {

    if (! objectDefined(obj))
        return false;

    if ($.isArray(obj))
        return false;

    if (typeof obj == 'object')
        return true;

    return false;
}

singObject.method('clone', arrayClone,
    {
        summary: null,
        parameters: null,
        validateInput: false,
        returns: '',
        returnType: '',
        examples: null,
        glyphIcon: '&#xe224;',
        tests(ext) {
            ext.addTest([], [], []);
            ext.addTest([undefined], [], []);
            ext.addTest([[]], [], []);
            ext.addTest(['a'], [], ['a']);

            ext.addCustomTest(() => {

                var ary = [1, 2, 3];
                var ary2 = ary.clone();

                ary.push(4);

                if (ary2.length == 4)
                    return 'Same array was returned';

            }, 'Arrays must be clones, not the source array');
        }
    }, Array.prototype, 'Array');

function arrayClone<T>(deepClone: boolean = false): any[] {

    const thisArray = this as T[];

    if (deepClone) {
        return thisArray.collect(item => $.clone(item, true));
    }
    else {
        return thisArray.collect();
    }
}

singObject.method('clone', numberClone, {
    glyphIcon: '&#xe224;',
    tests(ext) {
        ext.addTest(0, [], 0);
        ext.addTest(1, [], 1);
        ext.addTest(NaN, [], NaN);
        ext.addTest(Infinity, [], Infinity);
        ext.addTest(-Infinity, [], -Infinity);

        ext.addCustomTest(() => {

            var src = 1;
            var src2: number;
// ReSharper disable once AssignedValueIsNeverUsed
            src2 = src.clone();
// ReSharper disable once AssignedValueIsNeverUsed
            src2 = 2;

            if (src == 2)
                return 'Same number was returned';

        }, 'Numbers must be clones, not the source number');
    }
}, Number.prototype, 'Number');

function numberClone() {
    return this.valueOf();
}

singObject.method('clone', booleanClone, {
    glyphIcon: '&#xe224;',
    tests(ext) {
        ext.addTest(false, [], false);
        ext.addTest(true, [], true);

        ext.addCustomTest(() => {

            var src = false;
// ReSharper disable once AssignedValueIsNeverUsed
// ReSharper disable once ExpressionIsAlwaysConst
            var src2 = src.clone();

// ReSharper disable once AssignedValueIsNeverUsed
            src2 = true;

// ReSharper disable once RedundantComparisonWithBoolean
// ReSharper disable once ConditionIsAlwaysConst
// ReSharper disable once ExpressionIsAlwaysConst
            if (src == true)
// ReSharper disable once HeuristicallyUnreachableCode
                return 'Same boolean was returned';

        }, 'Booleans must be clones, not the source boolean');
    }
}, Boolean.prototype, 'Boolean');

function booleanClone() {
    return this.valueOf();
}

singObject.method('clone', stringClone, {
    glyphIcon: '&#xe224;',
    tests(ext) {
        ext.addTest('', [], '');
        ext.addTest('a', [], 'a');

        ext.addCustomTest(() => {

            var src = 'a';
// ReSharper disable once AssignedValueIsNeverUsed
            var src2 = src.clone();

// ReSharper disable once AssignedValueIsNeverUsed
            src2 = 'b';

            if (src == 'b')
                return 'Same string was returned';

        }, 'Strings must be clones, not the source string');
    }
}, String.prototype, 'String');

function stringClone() {
    return this.valueOf();
}

singObject.method('clone', dateClone, {
    glyphIcon: '&#xe224;',
    tests(ext) {

        const testDate = new Date();

        ext.addTest(testDate, [], testDate);

        ext.addCustomTest(() => {

            var src = new Date();
            var src2 = src.clone();

            src2.setMinutes(0);
            src2.setSeconds(0);
            src2.setMilliseconds(777);

            // This has 1/360,000 probability of failing
            // if (src.getMinutes() == 0 && src.getSeconds() == 0 && src.getMilliseconds() == 777)
            //    return 'Same date was returned';

            // This has 1/60 probability of failing
            if (src.getSeconds() == 0)
                return 'Same date was returned';

        }, 'Dates must be clones, not the source date');
    }
}, Date.prototype, 'Date');

function dateClone() {
    return new Date(this.valueOf());
}

singObject.method('clone', objectClone, {
    glyphIcon: '&#xe224;',
    tests(ext) {

        ext.addTest($, [0], 0);
        ext.addTest($, [1], 1);
        ext.addTest($, [NaN], NaN);
        ext.addTest($, [Infinity], Infinity);
        ext.addTest($, [-Infinity], -Infinity);

        ext.addTest($, [false], false);
        ext.addTest($, [true], true);

        ext.addTest($, [''], '');
        ext.addTest($, ['a'], 'a');

        const testDate = new Date();

        ext.addTest($, [testDate], testDate);

        ext.addTest($, [{}], {});
        ext.addTest($, [[]], []);
        ext.addTest($, [[[]]], [[]]);
        ext.addTest($, [['a']], ['a']);
        ext.addTest($, [[['a']]], [['a']]);
    }
}, $, 'jQuery');

function objectClone(obj: any, deepClone: boolean = false) {

    if (obj.clone !== objectClone && $.isFunction(obj.clone))
        return obj.clone(deepClone);

    const out: IHash<any> = {};

    let key: any;
    const objKeys = $.objKeys(obj);
    if (deepClone) {
        for (key in objKeys) {
            if (objKeys.hasOwnProperty(key)) {
                out[key] = obj[key];
            }
        }
    }
    else {
        for (key in objKeys) {
            if (objKeys.hasOwnProperty(key)) {
                out[key] = $.clone(obj[key]);
            }
        }
    }
    return out;
}

singObject.method('isEmpty', objectIsEmpty, {
    glyphIcon: '&#xe118;',
    tests(ext) {
        ext.addTest($, [0], false);
        ext.addTest($, [1], false);
        ext.addTest($, [NaN], true);
        ext.addTest($, [Infinity], false);
        ext.addTest($, [-Infinity], false);
        ext.addTest($, [''], true);
        ext.addTest($, ['  '], true);
        ext.addTest($, ['a'], false);
        ext.addTest($, [null], true);
        ext.addTest($, [undefined], true);
        ext.addTest($, [], true);
        ext.addTest($, [[]], true);
        ext.addTest($, [{}], true);
        ext.addTest($, [[{}]], true);
        ext.addTest($, [[1]], false);
        ext.addTest($, [[[1]]], false);
        ext.addTest($, [[[], [1]]], false);
    }
}, $);

function objectIsEmpty(obj?: any): boolean {

    return (obj === undefined ||
        obj === null ||
        obj === '' ||
        (typeof obj == 'number' && isNaN(obj)) ||
        ($.isString(obj) && obj.trim().length == 0) ||
        ($.isHash(obj) && $.objKeys(obj).length == 0)) ||
        ($.isArray(obj) && (obj.length == 0 || !(obj as any[]).has((item: any) => (!$.isEmpty(item))))) ||
        ($.isHash(obj) && !$.objValues(obj as any[]).has((item: any) => (!$.isEmpty(item))));
}


singObject.method('typeName', objectTypeName, {
    glyphIcon: '&#xe041;',
    tests(ext) {

        ext.addTest($, [0], 'Number');
        ext.addTest($, [1], 'Number');
        ext.addTest($, [NaN], 'Number');
        ext.addTest($, [Infinity], 'Number');
        ext.addTest($, [-Infinity], 'Number');

        ext.addTest($, [''], 'String');
        ext.addTest($, ['a'], 'String');

        ext.addTest($, [true], 'Boolean');
        ext.addTest($, [false], 'Boolean');

        ext.addTest($, [null], 'Null');
        ext.addTest($, [undefined], 'Undefined');

        ext.addTest($, [[]], 'Array');
        ext.addTest($, [{}], 'Object');

        ext.addTest($, [sing], 'Singularity');
    }
}, $);

function objectTypeName(obj?: any) {
    if (typeof obj === 'undefined')
        return 'Undefined';
    if (obj === null)
        return 'Null';
    if (obj.__proto__ && obj.__proto__.constructor && obj.__proto__.constructor.name)
        return obj.__proto__.constructor.name;
    return Object.prototype.toString.call(obj)
        .match(/^\[object\s(.*)\]$/)[1];
}
