
/// <reference path="singularity-core.ts"/>

interface JQueryStatic {
    isString? (obj: any): boolean;

    toStr? (obj: any, includeMarkup?: boolean): string;
    objEach? (obj: any, eachFunc: (key: string, item: any, i: number) => any): any[];

    objProperties? (obj?): [{ name: string; value: any; }];
    objValues? (obj?): any[];
    objKeys? (obj?): string[];
    resolve? (obj?: Object | Function): Object;
    
    // numericValueOf
    // $.isArray()
    // $.isHash()
    // $.isInt()
    // $.isFloat()
    // $.isNumber()
    // $.toArray()
    // $.wait();
    // $.sleep();
}

interface JQuery {
    // Missing from definition
    selectmenu(): JQuery;


    init?: (initFunc: () => void) => void;
    findIDNameSelector?: (name: string) => JQuery;
    checked?: () => boolean;
    allVisible?: () => boolean;
    actionIf?: (name: string) => boolean;
}

/*
//////////////////////////////////////////////////////
//
// jQuery Extensions
//
//
*/

function InitSingularityJS_jQuery() {

    sing.addjQueryFnExt('checked', Checked,
        {
            summary: null,
            parameters: null,
            returns: '',
            returnType: '',
            examples: null,
            tests: function (ext) {
            },
        });

    function Checked() {
        var anyChecked = false;

        this.each(function () {
            if ($(this)[0]['checked'])
                anyChecked = true;
        });

        return anyChecked;
    }


    sing.addjQueryFnExt('allVisible', AllVisible,
        {
            summary: null,
            parameters: null,
            returns: '',
            returnType: '',
            examples: null,
            tests: function (ext) {
            },
        });

    function AllVisible() {

        var allVisible = true;

        this.each(function () {
            var opacity = $(this).attr('opacity');

            if (opacity == '0') {
                allVisible = false;
            }

            if ($(this).css('display') == 'none') {
                allVisible = false;
            }
        });

        return allVisible;
    }

    sing.addjQueryFnExt('findIDNameSelector', FindIDNameSelector,
        {
            summary: null,
            parameters: null,
            returns: '',
            returnType: '',
            examples: null,
            tests: function (ext) {
            },
        });

    function FindIDNameSelector(name) {

        var target = $();

        try {
            target = $(this).find('#' + name);
        } catch (ex) { }

        if (target.length == 0)
            try {
                target = $(this).find('[name=' + name + ']');
            } catch (ex) { }

        if (target.length == 0)
            try {
                target = $(this).find(name);
            } catch (ex) { }

        return target || $();
    }

    sing.addjQueryFnExt('actionIf', ActionIf,
        {
            summary: null,
            parameters: null,
            returns: '',
            returnType: '',
            examples: null,
            tests: function (ext) {
            },
        });

    function ActionIf(name) {

        var target = $(this);

        var ifTargetName = target.attr(name + '-if');

        // If there's no target, there's no condition to match. Always true.
        if (!ifTargetName)
            return true;

        var ifTarget = $('body').findIDNameSelector(ifTargetName);

        var targetValue = <any>(target.attr(name + '-if-value') || '');

        var operation = function (a, b) {
            return a == b;
        };

        if (targetValue.indexOf('!=') == 0) {
            operation = function (a, b) {
                return a != b;
            };
            targetValue = targetValue.substr(2);
        }
        else if (targetValue.indexOf('>=') == 0) {
            operation = function (a, b) {
                return parseFloat(a) >= parseFloat(b);
            };
            targetValue = parseFloat(targetValue.substr(2));
        }
        else if (targetValue.indexOf('<=') == 0) {
            operation = function (a, b) {
                return parseFloat(a) <= parseFloat(b);
            };
            targetValue = parseFloat(targetValue.substr(2));
        }
        else if (targetValue.indexOf('><') == 0) {
            operation = function (a, b) {
                return parseFloat(a) >= parseFloat(b[0]) && parseFloat(a) <= parseFloat(b[1]);
            };
            targetValue = targetValue.substr(2);
            targetValue = [
                targetValue.split(',')[0],
                targetValue.split(',')[1],
            ];
        }
        else if (targetValue.indexOf('<>') == 0) {
            operation = function (a, b) {
                return parseFloat(a) <= parseFloat(b[0]) || parseFloat(a) >= parseFloat(b[1]);
            };
            targetValue = targetValue.substr(2);
            targetValue = [
                targetValue.split(',')[0],
                targetValue.split(',')[1],
            ];
        }
        else if (targetValue.indexOf(',') > 0) {
            operation = function (a, b) {
                return b.indexOf(a) >= 0;
            };
            targetValue = targetValue.split(',');
        }
        else if (targetValue.indexOf('!') == 0) {
            operation = function (a, b) {
                return parseFloat(a) != parseFloat(b);
            };
            targetValue = targetValue.substr(1);
        }
        else if (targetValue.indexOf('<') == 0) {
            operation = function (a, b) {
                return parseFloat(a) < parseFloat(b);
            };
            targetValue = parseFloat(targetValue.substr(1));
        }
        else if (targetValue.indexOf('>') == 0) {
            operation = function (a, b) {

                return parseFloat(a) > parseFloat(b);
            };
            targetValue = parseFloat(targetValue.substr(1));
        }

        if (ifTarget.length == 0) {
            return false;
        }
        else {
            var val = ifTarget.val();

            if (!targetValue) {
                if (ifTarget.attr('type') == 'checkbox')
                    return ifTarget.checked();

                if (ifTarget.attr('type') == 'radio')
                    return ifTarget.filter(':checked').length > 0;

                return val != null && val != '';
            }
            else {
                // Radio values can be combined with the use of custom numeric operators
                if (ifTarget.attr('type') == 'radio')
                    return operation(ifTarget.filter(':checked').val(), targetValue);

                return operation(val, targetValue);
            }
        }
    };

    //
    //////////////////////////////////////////////////////
    // MOVE to object extensions
    //

    sing.addjQueryExt('toStr', ToStr,
        {
            summary: null,
            parameters: null,
            returns: '',
            returnType: '',
            examples: null,
            tests: function (ext) {

                ext.addTest(undefined, [null], '');
                ext.addTest(undefined, [null, false], '');
                ext.addTest(undefined, [null, true], 'null');
                ext.addTest(undefined, [undefined], '');
                ext.addTest(undefined, [undefined, false], '');
                ext.addTest(undefined, [undefined, true], 'undefined');

                ext.addTest(undefined, [[]], '');
                ext.addTest(undefined, [[], false], '');
                ext.addTest(undefined, [[], true], '[]');

                ext.addTest(undefined, [{}], '');
                ext.addTest(undefined, [{}, false], '');
                ext.addTest(undefined, [{}, true], '{}');

                ext.addTest(undefined, [NaN], '');
                ext.addTest(undefined, [NaN, false], '');
                ext.addTest(undefined, [NaN, true], 'NaN');


                ext.addTest(undefined, [{ a: 'b', b: 5, c: false, d: [], e: { f: {} } }], 'a: b\r\nb: 5\r\nc: No\r\nd: \r\ne: f: \r\n\r\n');
                ext.addTest(undefined, [{ a: 'b', b: 5, c: false, d: [], e: { f: {} } }, true], '{a: \'b\', b: 5, c: false, d: [], e: {f: {}}}');

                ext.addTest(undefined, [['a']], 'a');
                ext.addTest(undefined, [['a'], false], 'a');
                ext.addTest(undefined, [['a'], true], '[\'a\']');

                ext.addTest(undefined, [[true]], 'Yes');
                ext.addTest(undefined, [[true], false], 'Yes');
                ext.addTest(undefined, [[true], true], '[true]');
                ext.addTest(undefined, [[false]], 'No');
                ext.addTest(undefined, [[false], false], 'No');
                ext.addTest(undefined, [[false], true], '[false]');

                ext.addTest(undefined, [[5]], '5');
                ext.addTest(undefined, [[5], false], '5');
                ext.addTest(undefined, [[5], true], '[5]');

                ext.addTest(undefined, [[false, false, false, false]], 'No\r\nNo\r\nNo\r\nNo');
                ext.addTest(undefined, [[false, false, false, false], false], 'No\r\nNo\r\nNo\r\nNo');
                ext.addTest(undefined, [[false, false, false, false], true], '[false, false, false, false]');
            },
        });

    function ToStr(obj: any, includeMarkup: boolean = false) {

        if (obj === undefined)
            return includeMarkup ? 'undefined' : '';
        if (obj === null)
            return includeMarkup ? 'null' : '';

        if (obj.toStr)
            return obj.toStr(includeMarkup);

        if (typeof obj == 'object') {
            var out = includeMarkup ? '{' : '';

            var keyCount = Object.keys(obj).length;

            $.objEach(obj, function (key, item, index) {
                if (includeMarkup) {
                    out += key + ': ' + $.toStr(item, true);
                    if (index < keyCount - 1)
                        out += ', ';
                }
                else {
                    out += key + ': ' + $.toStr(item) + '\r\n';
                }
            });

            out += includeMarkup ? '}' : '';
            return out;
        }

        return obj;
    }

    sing.addjQueryExt('isString', IsString,
        {
            summary: null,
            parameters: null,
            returns: '',
            returnType: '',
            examples: null,
            tests: function (ext) {
                ext.addTest(undefined, [], false);
                ext.addTest(undefined, [], false);
                ext.addTest(undefined, [], false);
                ext.addTest(undefined, [5], false);
                ext.addTest(undefined, [''], true);
                ext.addTest(undefined, ['a'], true);
            },
        });

    function IsString(str) {
        return typeof str == 'string';
    }

    sing.addjQueryExt('objEach', ObjectEach,
        {
            summary: null,
            parameters: null,
            returns: '',
            returnType: '',
            examples: null,
            tests: function (ext) {

                ext.addCustomTest(undefined, function () {

                    var test = { a: 1, b: 2 };
                    var test2 = [];

                    $.objEach(test, function (key, item, index) {
                        test2.push({ key: key, item: item, index: index });
                    });

                    if ($.toStr(test2) != $.toStr([{ key: 'a', item: 1, index: 0 },
                        { key: 'b', item: 2, index: 1 }]))
                        return $.toStr(test2) + '\r\n' + $.toStr([{ key: 'a', item: 1, index: 0 },
                            { key: 'b', item: 2, index: 1 }]);

                }, 'Executes for every element');
            },
        });

    function ObjectEach(src: Object, eachFunc: (key: string, item: any, index: number) => void): void {

        var keys = Object.keys(src);

        keys.each(function (key, i) {
            eachFunc(key, src[key], i);
        });
    }

    sing.addjQueryExt('objProperties', ObjectProperties,
        {
            summary: null,
            parameters: null,
            returns: '',
            returnType: '',
            examples: null,
            tests: function (ext) {
                ext.addTest(undefined, [null], []);
                ext.addTest(undefined, [undefined], []);
                ext.addTest(undefined, ['a'], [{ 0: { key: '0', value: 'a' } }]);
                ext.addTest(undefined, [5], []);
                ext.addTest(undefined, [[]], []);
                ext.addTest(undefined, [{}], []);
                ext.addTest(undefined, [{ a: 1, b: 2 }], [{ key: 'a', value: 1 }, { key: 'b', value: 2 }]);
            },
        });

    function ObjectProperties(src?: Object): { key: string; value: any }[] {
        if (src == null || !(typeof src == 'object'))
            return [];

        var keys = Object.keys(src);

        var values = <[{ key: string; value: any }]>keys.collect(function (item, i) {
            return { key: item, value: src[item] };
        });

        return values;
    }

    sing.addjQueryExt('objValues', ObjectValues,
        {
            summary: null,
            parameters: null,
            validateInput: false,
            returns: '',
            returnType: '',
            examples: null,
            tests: function (ext) {
                ext.addTest(undefined, [null], []);
                ext.addTest(undefined, [undefined], []);
                ext.addTest(undefined, ['a'], []);
                ext.addTest(undefined, ['a', 'b'], []);
                ext.addTest(undefined, [5], []);
                ext.addTest(undefined, [[]], []);
                ext.addTest(undefined, [{}], []);
                ext.addTest(undefined, [{ a: 1, b: 2 }], [1, 2]);
            },
        });

    function ObjectValues(src?: Object): any[] {
        if (src == null || !(typeof src == 'object'))
            return [];

        var keys = Object.keys(src);

        var values = keys.collect(function (item, i) { return src[item]; });

        return values;
    }


    sing.addjQueryExt('objKeys', ObjectKeys,
        {
            summary: null,
            parameters: null,
            validateInput: false,
            returns: '',
            returnType: '',
            examples: null,
            tests: function (ext) {
                ext.addTest(undefined, [null], []);
                ext.addTest(undefined, [undefined], []);
                ext.addTest(undefined, ['a'], []);
                ext.addTest(undefined, ['a', 'b'], []);
                ext.addTest(undefined, [5], []);
                ext.addTest(undefined, [[]], []);
                ext.addTest(undefined, [{}], []);
                ext.addTest(undefined, [{ a: 1, b: 2 }], ['a', 'b']);
            },
        });

    function ObjectKeys(src?: Object): string[] {
        if (src == null || !(typeof src == 'object'))
            return [];

        var keys = Object.keys(src);

        return keys;
    }

    sing.addjQueryExt('resolve', ObjectResolve,
        {
            summary: null,
            parameters: null,
            validateInput: false,
            returns: '',
            returnType: '',
            examples: null,
            tests: function (ext) {
                ext.addTest(undefined, [5], 5);
                ext.addTest(undefined, ['aa'], 'aa');
                ext.addTest(undefined, [['aa', 'bb']], ['aa', 'bb']);
                ext.addTest(undefined, [function () { return 5; }], 5);
                ext.addTest(undefined, [function () { return 'aa'; }], 'aa');
                ext.addTest(undefined, [function () { return ['aa', 'bb']; }], ['aa', 'bb']);
            },
        });

    function ObjectResolve(src: any, args: any[]): any {

        if ($.isFunction(src))
            return src.apply(null, args);

        if ($.isArray(src) && src.length == 1)
            return src[0];

        return src;
    }


    // $.isArray()
    // $.isHash()
    // $.isInt()
    // $.isFloat()
    // $.isNumber()
    // $.toArray()
    // $.wait();
    // $.sleep();
}