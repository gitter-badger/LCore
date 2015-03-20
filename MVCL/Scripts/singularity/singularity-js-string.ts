
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

    textToHTML?: () => string;


    tryToNumber?: (defaultValue?: any) => string | number;
    /*
    parse
    first
    last
    containsAny
    containsAll
    toNumber
    toBoolean
    isValidEmail
    isGuid
    isDate
    isBoolean
    isNumeric
    parseJSON
    lastIndexOf
    capitalize
    camelize
    stripTags
    pluralize
    fill
    toUrlSlug
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
    toStr?: (obj: any, includeMarkup?: boolean) => string;
}


var singString = sing.addModule(new sing.Module("String", String));

singString.requiredDocumentation = false;

/// <reference path="singularity-core.ts"/>

//////////////////////////////////////////////////////
//
//
// String Extensions
//

singString.addExt('contains', StringContains,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

function StringContains(str) {
    if (!this || !str || str == '')
        return false;

    return this == str ||
        this.indexOf(str) >= 0;
}

singString.addExt('replaceAll', StringReplaceAll,
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

function StringReplaceAll(searchOrSearches, replaceOrReplacements) {
    //if replace is null, return original string otherwise it will
    //replace search string with 'undefined'.
    if (replaceOrReplacements == undefined || replaceOrReplacements == null)
        replaceOrReplacements = '';

    if (searchOrSearches == undefined || searchOrSearches == null || searchOrSearches == '')
        return this;

    var out = this;

    if ($.isArray(searchOrSearches)) {

        searchOrSearches.each(function (item, i) {

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

singString.addExt('upper', StringUpper,
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

singString.addExt('lower', StringLower,
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

singString.addExt('collapseSpaces', StringCollapseSpaces,
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

singString.addExt('startsWith', StringStartsWith,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

function StringStartsWith(stringOrStrings) {
    if (!stringOrStrings)
        return false;

    if ($.isArray(stringOrStrings)) {

        return stringOrStrings.contains(function (s, i) {
            if (this.startsWith(s))
                return true;
        });
    }

    return this.indexOf(stringOrStrings) == 0;
}

singString.addExt('endsWith', StringEndsWith,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

function StringEndsWith(stringOrStrings) {
    if (!stringOrStrings)
        return false;

    if ($.isArray(stringOrStrings)) {
        for (var s in stringOrStrings) {
            if (this.endsWith(s))
                return true;
        }
        return false;
    }

    return this.indexOf(stringOrStrings) == this.length - stringOrStrings.length;
}

singString.addExt('removeAll', StringRemoveAll,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

function StringRemoveAll(stringOrStrings) {
    if ($.isArray(stringOrStrings)) {
        var out = this;
        for (var s in stringOrStrings) {
            out = out.removeAll(s);
        }
        return out;
    }

    return this.replaceAll(stringOrStrings, '');
}

singString.addExt('reverse', StringReverse,
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

singString.addExt('repeat', StringRepeat,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

function StringRepeat(times) {
    if (times <= 0)
        return '';

    var out = '';

    for (var i = 0; i < times; i++) {
        out += this;
    }
    return out;
}

singString.addExt('words', StringWords,
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

singString.addExt('lines', StringLines,
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

singString.addExt('surround', StringSurround,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

function StringSurround(str) {
    if (!this || !str)
        return '';

    return str + this + str;
}

singString.addExt('truncate', StringTruncate,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

function StringTruncate(length) {
    if (!this)
        return ''

    if (this.length > length)
        return this.substr(0, length).toString();

    return this;
}

singString.addExt('isValidEmail', StringIsValidEmail,
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

singString.addExt('isHex', StringIsHex,
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

singString.addExt('isValidURL', null,
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

singString.addExt('isIPAddress', StringIsIPAddress,
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

singString.addExt('isGuid', StringIsGuid,
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


singString.addExt('tryToNumber', null,
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
    
singString.addExt('joinLines', StringJoinLines,
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

singString.addExt('pad', StringPad,
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

singString.addExt('toStr', BooleanToStr,
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

singString.addExt('toStr', ToStr,
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
    }, $, 'jQuery');

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

singString.addExt('toStr', ArrayToStr,
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
    var out = includeMarkup ? '[' : '';
    var src = this;

    this.each(function (item, i) {
        if (item === null)
            out += 'null';
        else if (item === undefined)
            out += 'undefined';
        else if (item.toStr)
            out += item.toStr(includeMarkup);  // includeMarkup is passed to child elements

        if (i < src.length - 1)
            out += includeMarkup ? ', ' : '\r\n';
    });

    out += includeMarkup ? ']' : '';

    return out;
}

singString.addExt('toStr', StringToStr,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

function StringToStr(includeMarkup) {
    if (includeMarkup)
        return "'" + this.replaceAll('\r\n', '\\r\\n') + "'";

    return this;
}


singString.addExt('isString', IsString,
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
    }, $);

function IsString(str) {
    return typeof str == 'string';
}


singString.addExt('isDate', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
singString.addExt('isBoolean', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
singString.addExt('isNumeric', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

singString.addExt('toNumber', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
singString.addExt('toBoolean', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
singString.addExt('toUrlSlug', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

singString.addExt('first', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
singString.addExt('last', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
singString.addExt('containsAny', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
singString.addExt('containsAll', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
singString.addExt('parseJSON', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
singString.addExt('lastIndexOf', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
singString.addExt('capitalize', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
singString.addExt('camelize', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
singString.addExt('pluralize', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
singString.addExt('fill', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

singString.addExt('similarity', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
singString.addExt('like', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

singString.addExt('isJSON', null,
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

