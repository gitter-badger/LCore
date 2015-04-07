
interface String {
    pad?: (length: number, align?: Direction) => string;
    lower?: () => string;
    upper?: () => string;
    replaceAll?: (find: string, replace?: string) => string;
    removeAll?: (find: string) => string;
    contains?: (search: string) => boolean;
    collapseSpaces? (): string;
    startsWith?: (search: string) => boolean;
    endsWith?: (search: string) => boolean;
    reverse?: () => string;
    repeat?: (times: number) => string;
    words?: () => string[];
    lines?: () => string[];
    surround?: (str: string) => string;
    truncate?: (length: number) => string;

    toStr?: (includeMarkup?: boolean) => string;


    tryToNumber?: (defaultValue?: any) => string | number;

    before?: (search: string) => string;
    after?: (search: string) => string;

    toSlug?: () => string;

    /*
    parse
    first
    last
    containsAny
    containsAll
    isValidEmail
    isGuid
    isDate
    parseJSON
    lastIndexOf
    capitalize
    camelize
    stripTags
    pluralize
    fill
    similarity
    like
    isJSON    
    
    */
}

interface Boolean {
    toStr?: (includeMarkup?: boolean) => string;
}

interface Array<T> {
    joinLines?: () => string;
    toStr?: (includeMarkup?: boolean) => string;
}

interface JQueryStatic {
    toStr?: (obj: any, includeMarkup?: boolean, stack?: any[]) => string;
}


var singString = singExt.addModule(new sing.Module("String", String));

/// <reference path="singularity-core.ts"/>

//////////////////////////////////////////////////////
//
//
// String Extensions
//

singString.method('contains', StringContains,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

function StringContains(str?: string) {
    if (!this || !str || str == '')
        return false;

    return this == str ||
        this.indexOf(str) >= 0;
}

singString.method('replaceAll', StringReplaceAll,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
            ext.addTest('apples', ['s', ' pie'], 'apple pie');
            ext.addTest('apples apples', ['s', ' pie'], 'apple pie apple pie');

            ext.addFailsTest('apples apples', ['s', 'pies'], StringReplaceAll_ErrorReplacementContinsSearch);

            ext.addTest('ababab', ['b', 'c'], 'acacac');
            ext.addTest('ababab', ['b', ''], 'aaa');
            ext.addTest('a', ['', ''], 'a');
            ext.addTest('a', ['a', ''], '');

            ext.addTest('a', [null, null], 'a');
            ext.addTest('a', [undefined, undefined], 'a');
            ext.addTest('a', ['a', null], '');
            ext.addTest('a', ['a', undefined], '');
            ext.addTest('b', [null, 'a'], 'b');
            ext.addTest('b', [undefined, 'a'], 'b');

            // Array tests not quite working
            // sing.addAssertTest(ext.name, 'ababababaab'.replaceAll(['a', 'b'], ''), '');
            // sing.addAssertTest(ext.name, 'ababababaab'.replaceAll(['a', 'b'], null), '');
            // sing.addAssertTest(ext.name, 'ababababaab'.replaceAll(['a', 'b'], undefined), '');
            // sing.addAssertTest(ext.name, 'ababababaab'.replaceAll(['a', 'c'], 'b'), 'bbbbbbbbbbb');
            // sing.addAssertTest(ext.name, 'ababababaab'.replaceAll(['a', 'b'], ['d', 'e']), 'dededededde');
        },
    });

var StringReplaceAll_ErrorReplacementContinsSearch = 'Replace All Error: replacement must not contain search term';

function StringReplaceAll(searchOrSearches: string | string[], replaceOrReplacements: string | string[]) {
    //if replace is null, return original string otherwise it will
    //replace search string with 'undefined'.
    if (replaceOrReplacements == undefined || replaceOrReplacements == null)
        replaceOrReplacements = '';

    if (searchOrSearches == undefined || searchOrSearches == null || searchOrSearches == '')
        return this;

    var out = this;

    if ($.isArray(searchOrSearches)) {
        var searchArray = <string[]>searchOrSearches;

        searchArray.each(function (item, i) {

            var replacestr = $.isArray(replaceOrReplacements) ? replaceOrReplacements[i] : replaceOrReplacements;

            if (replacestr.toString().contains(item.toString()))
                throw StringReplaceAll_ErrorReplacementContinsSearch;

            out = out.replaceAll(item, replacestr).toString();
        });

        return out.toString();
    }
    else {
        if (this == searchOrSearches && (replaceOrReplacements == null || replaceOrReplacements == undefined || replaceOrReplacements == ''))
            return '';

        if (replaceOrReplacements.toString().contains(searchOrSearches.toString()))
            throw StringReplaceAll_ErrorReplacementContinsSearch;

        while (out.indexOf(searchOrSearches) > 0)
            out = out.replace(searchOrSearches, replaceOrReplacements);

        return out.toString();
    }
}

singString.method('upper', StringUpper,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

function StringUpper() {
    return this.toUpperCase();
}

singString.method('lower', StringLower,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

function StringLower() {
    return this.toLowerCase();
}

singString.method('collapseSpaces', StringCollapseSpaces,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

function StringCollapseSpaces() {
    return this.replaceAll('  ', ' ');
}

singString.method('startsWith', StringStartsWith,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

function StringStartsWith(stringOrStrings: string|string[]) {

    var thisString = <string>this;

    if (!stringOrStrings)
        return false;

    if ($.isArray(stringOrStrings)) {

        return (<string[]>stringOrStrings).has(function (s, i) {
            if (thisString.startsWith(s))
                return true;
            return false;
        });
    }

    return this.indexOf(stringOrStrings) == 0;
}

singString.method('endsWith', StringEndsWith,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

function StringEndsWith(stringOrStrings: string|string[]) {
    if (!stringOrStrings)
        return false;

    if ($.isArray(stringOrStrings)) {
        for (var s in <string[]>stringOrStrings) {
            if (this.endsWith(s))
                return true;
        }
        return false;
    }

    var index = this.indexOf(stringOrStrings);

    return index >= 0 && index == this.length - stringOrStrings.length;
}

singString.method('removeAll', StringRemoveAll,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

function StringRemoveAll(stringOrStrings: string|string[]) {
    if ($.isArray(stringOrStrings)) {
        var out = this;
        for (var s in <string[]>stringOrStrings) {
            out = out.removeAll(s);
        }
        return out;
    }

    return this.replaceAll(stringOrStrings, '');
}

singString.method('reverse', StringReverse,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

function StringReverse() {
    if (!this)
        return '';

    var out = '';

    for (var i = 0; i < this.length; i++) {
        out += this[i];
    }
    return out;
}

singString.method('repeat', StringRepeat,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

function StringRepeat(times: number = 0) {
    if (times <= 0)
        return '';

    var out = '';

    for (var i = 0; i < times; i++) {
        out += this;
    }
    return out;
}

singString.method('words', StringWords,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    })

function StringWords() {
    if (!this)
        return [];

    return this.collapseSpaces().split(' ');
}

singString.method('lines', StringLines,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

function StringLines() {
    if (!this)
        return [];

    return this.collapseSpaces().split('\r\n');
}

singString.method('surround', StringSurround,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

function StringSurround(str: string) {
    if (!this || !str)
        return this;

    return str + this + str;
}

singString.method('truncate', StringTruncate,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

function StringTruncate(length: number) {
    if (!this || this.length < 0)
        return '';

    if (this.length > length)
        return this.substr(0, length).toString();

    return this;
}

singString.method('isValidEmail', StringIsValidEmail,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

function StringIsValidEmail(): boolean {
    var thisStr = <string>this;

    return thisStr.hasMatch(/^([a-z0-9_\.-]+)@([\da-z\.-]+)\.([a-z\.]{2,6})$/);
}

singString.method('isHex', StringIsHex,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

function StringIsHex(): boolean {
    var thisStr = <string>this;

    return thisStr.hasMatch(/^#?([a-f0-9]{6}|[a-f0-9]{3})$/);
}

singString.method('isValidURL', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

function StringIsValidURL(): boolean {
    var thisStr = <string>this;
    return thisStr.hasMatch(/^(https?:\/\/)?([\da-z\.-]+)\.([a-z\.]{2,6})([\/\w \.-]*)*\/?$/);
}

singString.method('isIPAddress', StringIsIPAddress,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

function StringIsIPAddress(): boolean {
    var thisStr = <string>this;
    return thisStr.hasMatch(/^(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$/);
}

singString.method('isGuid', StringIsGuid,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

function StringIsGuid(): boolean {
    var thisStr = <string>this;

    return thisStr.hasMatch(/^\{?[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}‌​\}?$/);
}


singString.method('tryToNumber', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

function StringTryToNumber(defaultValue: any = this) {

    var str = this;
    var retValue = defaultValue;

    if (str !== null) {
        if (str.length > 0) {
            if (!isNaN(str)) {
                retValue = parseInt(str);
            }
        }
    }
    return retValue;
}

//
//////////////////////////////////////////////////////
//
// String Array functions
    
singString.method('joinLines', StringJoinLines,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    }, Array.prototype);

function StringJoinLines(asHTML: boolean = true) {
    if (!this)
        return '';

    return this.join(asHTML ? '<br/>' : '\r\n');
}

//
//////////////////////////////////////////////////////
//

singString.method('pad', StringPad,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {

            ext.addTest('a', [5], 'a    ');
            ext.addTest('a', [5, 'left'], 'a    ');
            ext.addTest('a', [5, 'l'], 'a    ');
            ext.addTest('a', [5, 'right'], '    a');
            ext.addTest('a', [5, 'r'], '    a');
            ext.addTest('a', [5, 'left', '-'], 'a----');
            ext.addTest('a', [5, 'l', '-'], 'a----');
            ext.addTest('a', [5, 'wrong'], 'a');

            // Test pad > length
            // Test Nulls
        },
    });

function StringPad(length: number, align: Direction = Direction.left, whitespace: string = ' ') {

    if (align != Direction.left && align != Direction.l &&
        align != Direction.right && align != Direction.r &&
        align != Direction.center && align != Direction.c) {
        return this;
    }

    if (!this)
        return whitespace.repeat(length);

    var out = this;
    var whitespaceIndex = 0;
    var count = 0;

    while (out.length < length) {

        if (align == Direction.left || align == Direction.l)
            out += whitespace[whitespaceIndex];
        else if (align == Direction.right || align == Direction.r)
            out = whitespace[whitespaceIndex] + out;
        else if (align == Direction.center || align == Direction.c)
            out = whitespace[whitespaceIndex] + out;

        whitespaceIndex++;
        if (whitespaceIndex >= whitespace.length)
            whitespaceIndex = 0;
    }

    return out;
}


//
//////////////////////////////////////////////////////
//

singString.method('toStr', BooleanToStr,
    {
        summary: 'Converts the calling Boolean to string.',
        parameters: [
            {
                name: 'includeMarkup',
                types: [Boolean],
                description: 'Set includeMarkup to true to retrieve the actual string representaion of true and false.',
                defaultValue: false,
            }
        ],
        returns: 'A String representation of the boolean value',
        returnType: String,
        examples: ['\
            If you specify a true value for includeMarkup, Booleans will be returned as \'true\' or \'false\' \r\n\
            Otherwise, \'Yes\' or \'No\' will be returned.'],
        tests: function (ext) {
            ext.addTest(true, [], 'Yes');
            ext.addTest(true, [false], 'Yes');
            ext.addTest(true, [true], 'true');
            ext.addTest(false, [], 'No');
            ext.addTest(false, [false], 'No');
            ext.addTest(false, [true], 'false');
        }
    }, Boolean.prototype, "Boolean");

function BooleanToStr(includeMarkup: boolean = false): string {
    if (includeMarkup == false)
        return this.toYesNo();

    return this == false ? "false" : "true";
}

singString.method('toStr', ObjectToStr,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: '',
        examples: null,
        tests: function (ext) {

            ext.addTest($, [null], '');
            ext.addTest($, [null, false], '');
            ext.addTest($, [null, true], 'null');
            ext.addTest($, [undefined], '');
            ext.addTest($, [undefined, false], '');
            ext.addTest($, [undefined, true], 'undefined');

            ext.addTest($, [[]], '');
            ext.addTest($, [[], false], '');
            ext.addTest($, [[], true], '[]');

            ext.addTest($, [[[]]], '');
            ext.addTest($, [[[]], false], '');
            ext.addTest($, [[[]], true], '[[]]');

            ext.addTest($, [[{}]], '');
            ext.addTest($, [[{}], false], '');
            ext.addTest($, [[{}], true], '[{}]');

            ext.addTest($, [{}], '');
            ext.addTest($, [{}, false], '');
            ext.addTest($, [{}, true], '{}');

            ext.addTest($, [NaN], '');
            ext.addTest($, [NaN, false], '');
            ext.addTest($, [NaN, true], 'NaN');


            ext.addTest($, [{ a: 'b', b: 5, c: false, d: [], e: { f: {} } }], 'a: b\r\nb: 5\r\nc: No\r\nd: \r\ne: f: \r\n\r\n');
            ext.addTest($, [{ a: 'b', b: 5, c: false, d: [], e: { f: {} } }, true], '{a: \'b\', b: 5, c: false, d: [], e: {f: {}}}');

            ext.addTest($, [['a']], 'a');
            ext.addTest($, [['a'], false], 'a');
            ext.addTest($, [['a'], true], '[\'a\']');

            ext.addTest($, [[true]], 'Yes');
            ext.addTest($, [[true], false], 'Yes');
            ext.addTest($, [[true], true], '[true]');
            ext.addTest($, [[false]], 'No');
            ext.addTest($, [[false], false], 'No');
            ext.addTest($, [[false], true], '[false]');

            ext.addTest($, [[5]], '5');
            ext.addTest($, [[5], false], '5');
            ext.addTest($, [[5], true], '[5]');

            ext.addTest($, [[false, false, false, false]], 'No\r\nNo\r\nNo\r\nNo');
            ext.addTest($, [[false, false, false, false], false], 'No\r\nNo\r\nNo\r\nNo');
            ext.addTest($, [[false, false, false, false], true], '[false, false, false, false]');

            ext.addTest($, [$], '$');

            ext.addTest($, [sing], 'sing');
        },
    }, $, 'jQuery');

function ObjectToStr(obj: any, includeMarkup: boolean = false, stack: any[] = []) {

    if (obj === undefined)
        return includeMarkup ? 'undefined' : '';
    if (obj === null)
        return includeMarkup ? 'null' : '';
    if (obj === $)
        return '$';
    if (obj === sing)
        return 'sing';

    if (obj.toStr && obj.toStr != ObjectToStr)
        return obj.toStr(includeMarkup);

    if (typeof obj == 'object') {
        // Prevents infinite recursion
        if (stack.has(function (item: any) { return item === obj; })) {
            return '';
        }

        stack = stack.clone();
        stack.push(obj);

        var out = includeMarkup ? '{' : '';

        var keyCount = Object.keys(obj).length;

        $.objEach(obj, function (key, item, index) {
            if (includeMarkup) {
                out += (key || '\'\'') + ': ' + $.toStr(item, true, stack);
                if (index < keyCount - 1)
                    out += ', ';
            }
            else {
                out += key + ': ' + $.toStr(item, false, stack) + '\r\n';
            }
        });

        out += includeMarkup ? '}' : '';
        return out;
    }

    return obj;
}

singString.method('toStr', ArrayToStr,
    {
        summary: null,
        parameters: null,
        returns: null,
        returnType: String,
        examples: null,
        tests: function (ext) {
        },
    }, Array.prototype, "Array");

function ArrayToStr(includeMarkup: boolean = false) {

    var thisArray = <any[]>this;

    var out = includeMarkup ? '[' : '';
    var src = this;

    thisArray.each(function (item, i) {
        if (item === null)
            out += 'null';
        else if (item === undefined)
            out += 'undefined';
        else if (item.toStr)
            out += item.toStr(includeMarkup);  // includeMarkup is passed to child elements
        else if ($.isHash(item))
            out += $.toStr(item, includeMarkup);

        if (i < src.length - 1)
            out += includeMarkup ? ', ' : '\r\n';
    });

    out += includeMarkup ? ']' : '';

    return out;
}

singString.method('toStr', StringToStr,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

function StringToStr(includeMarkup: boolean = false) {
    if (includeMarkup)
        return "'" + this.replaceAll('\r\n', '\\r\\n') + "'";

    return this;
}


singString.method('isString', IsString,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: '',
        examples: null,
        tests: function (ext) {
            ext.addTest($, [], false);
            ext.addTest($, [], false);
            ext.addTest($, [], false);
            ext.addTest($, [5], false);
            ext.addTest($, [''], true);
            ext.addTest($, ['a'], true);
        },
    }, $);

function IsString(str?: any) {
    return typeof str == 'string';
}


singString.method('first', StringFirst,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

function StringFirst(count: number) {

    if (count <= 0)
        return '';

    if (count >= this.length)
        return this;

    return this.substr(0, count);
}

singString.method('last', StringLast,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

function StringLast(count: number) {

    if (count <= 0)
        return '';

    if (count >= this.length)
        return this;

    return this.substr(this.length - count, count);
}

singString.method('containsAny', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

function StringContainsAny(...items: string[]) {
    if (!this)
        return false;
    if (!items || item.length == 0)
        return false;

    return items.has(function (item) {
        return this.contains(item);
    });
}


singString.method('before', StringBefore,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

function StringBefore(search: string) {
    if (!this || !search == null || search == '')
        return this;

    var index = this.indexOf(search);

    if (index < 0)
        return this;

    return this.substr(0, index);
}

singString.method('after', StringAfter,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

function StringAfter(search: string) {
    if (!this || !search == null || search == '')
        return this;

    var index = this.indexOf(search);

    if (index < 0)
        return this;

    return this.substr(index + search.length);
}

singString.method('toSlug', StringToSlug,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

function StringToSlug() {

    var Text = this || '';
    Text = Text.toLowerCase();
    Text = Text.replace(/\./g, '_');
    Text = Text.replace(/\s/g, '-');

    return Text;
}



singString.method('isDate', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
singString.method('containsAll', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
singString.method('parseJSON', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
singString.method('lastIndexOf', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
singString.method('capitalize', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
singString.method('camelize', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
singString.method('pluralize', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
singString.method('fill', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
singString.method('similarity', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
singString.method('like', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
singString.method('isJSON', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

    // Research
    /*
     
    //parse

     */

