/// <reference path="singularity-core.ts"/>

interface String {
    pad?: (length: number, align?: Direction) => string;
    lower?: () => string;
    upper?: () => string;
    replaceAll?: (find: string, replace?: string) => string;
    removeAll?: (find: string) => string;
    contains?: (search: string) => boolean;
    collapseSpaces?(): string;
    startsWith?: (search: string) => boolean;
    endsWith?: (search: string) => boolean;
    reverse?: () => string;
    repeat?: (times: number, separator?: string) => string;
    words?: () => string[];
    lines?: () => string[];
    surround?: (str: string) => string;
    truncate?: (length: number) => string;

    toStr?: (includeMarkup?: boolean) => string;

    tryToNumber?: (defaultValue?: any) => string | number;

    before?: (search: string) => string;
    after?: (search: string) => string;

    afterFirst?: (search: string) => string;
    beforeLast?: (search: string) => string;

    toSlug?: () => string;

    containsAny?: (...items: string[]) => boolean;
    containsAll?: (...items: string[]) => boolean;
    pluralize?: (count?: number) => string;

    /*
    parse
    first
    last
    isValidEmail
    isGuid
    isDate
    parseJSON
    capitalize
    camelize
    stripTags
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

// ReSharper disable once InconsistentNaming
interface JQueryStatic {
    toStr?: (obj: any, includeMarkup?: boolean, stack?: any[]) => string;
}


var singString = singExt.addModule(new sing.Module('String', String));

singString.glyphIcon = '&#xe241;';

/// <reference path="singularity-core.ts"/>

//////////////////////////////////////////////////////
//
//
// String Extensions
//

singString.method('contains', stringContains,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        glyphIcon: '&#xe003;',
        tests(ext) {

            ext.addTest('', [], false);
            ext.addTest('', [''], false);
            ext.addTest('', [' '], false);
            ext.addTest(' ', [''], false);
            ext.addTest(' ', [' '], true);
            ext.addTest('abc', ['a'], true);
            ext.addTest('abc', ['d'], false);
            ext.addTest('abc', ['abc'], true);
        }
    });

function stringContains(str?: string) {
    if (!str || str == '')
        return false;

    return this == str ||
        this.indexOf(str) >= 0;
}

singString.method('replaceAll', stringReplaceAll,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        glyphIcon: '&#xe015;',
        tests(ext) {
            ext.addTest('apples', ['s', ' pie'], 'apple pie');
            ext.addTest('apples apples', ['s', ' pie'], 'apple pie apple pie');

            ext.addFailsTest('apples apples', ['s', 'pies'], stringReplaceAllErrorReplacementContinsSearch);

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
        }
    });

var stringReplaceAllErrorReplacementContinsSearch = 'Replace All Error: replacement must not contain search term';

function stringReplaceAll(searchOrSearches: string | string[], replaceOrReplacements: string | string[]) {
    // if replace is null, return original string otherwise it will
    // replace search string with 'undefined'.
    if (replaceOrReplacements == undefined)
        replaceOrReplacements = '';

    if (searchOrSearches == undefined || searchOrSearches == '')
        return this;

    var out = this;

    if ($.isArray(searchOrSearches)) {
        const searchArray = searchOrSearches as string[];

        searchArray.each((item, i) => {

            var replacestr = $.isArray(replaceOrReplacements) ? replaceOrReplacements[i] : replaceOrReplacements;

            if (replacestr.toString().contains(item.toString()))
                throw stringReplaceAllErrorReplacementContinsSearch;

            out = out.replaceAll(item, replacestr).toString();
        });

        return out.toString();
    }
    else {
        if (this == searchOrSearches &&
            (replaceOrReplacements == ''))
            return '';

        if (replaceOrReplacements.toString().contains(searchOrSearches.toString()))
            throw stringReplaceAllErrorReplacementContinsSearch;

        while (out.indexOf(searchOrSearches) >= 0)
            out = out.replace(searchOrSearches, replaceOrReplacements);

        return out.toString();
    }
}

singString.method('removeAll', stringRemoveAll,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        glyphIcon: '&#xe016;',
        tests(ext) {
            ext.addTest('', [], '');
            ext.addTest('', [''], '');
            ext.addTest('apple pie', [], 'apple pie');
            ext.addTest('apple pie', [null], 'apple pie');
            ext.addTest('apple pie', [undefined], 'apple pie');
            ext.addTest('apple pie', [''], 'apple pie');
            ext.addTest('apple pie', [' '], 'applepie');
            ext.addTest('apple pie', ['p'], 'ale ie');
            ext.addTest('apple pie', ['apple'], ' pie');
            ext.addTest('apple pie', ['pie'], 'apple ');
            ext.addTest('apple pie', ['pies'], 'apple pie');
        }
    });

function stringRemoveAll(stringOrStrings: string | string[]) {
    if ($.isArray(stringOrStrings)) {
        let out = this;
        const array = stringOrStrings as string[];
        for (let s in array) {
            if ((array).hasOwnProperty(s)) {
                out = out.removeAll(s);
            }
        }
        return out;
    }

    return this.replaceAll(stringOrStrings, '');
}

singString.method('upper', stringUpper,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        glyphIcon: '&#xe260;',
        tests(ext) {
            ext.addTest('', [], '');
            ext.addTest('apple', [], 'APPLE');
            ext.addTest('Apple', [], 'APPLE');
            ext.addTest('APPLE', [], 'APPLE');
        }
    });

function stringUpper() {
    return this.toUpperCase();
}

singString.method('lower', stringLower,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        glyphIcon: '&#xe259;',
        tests(ext) {
            ext.addTest('', [], '');
            ext.addTest('apple', [], 'apple');
            ext.addTest('Apple', [], 'apple');
            ext.addTest('APPLE', [], 'apple');
        }
    });

function stringLower() {
    return this.toLowerCase();
}

singString.method('collapseSpaces', stringCollapseSpaces,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        glyphIcon: 'icon-resize-small',
        tests(ext) {
            ext.addTest('', [], '');
            ext.addTest('           ', [], ' ');
            ext.addTest('apple pie', [], 'apple pie');
            ext.addTest('apple       pie', [], 'apple pie');
        }
    });

function stringCollapseSpaces() {
    return this.replaceAll('  ', ' ');
}

singString.method('startsWith', stringStartsWith,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        glyphIcon: '&#xe079;',
        tests(ext) {
            ext.addTest('', [], false);
            ext.addTest('', [''], false);
            ext.addTest('apple pie', [], false);
            ext.addTest('apple pie', [''], false);
            ext.addTest('apple pie', ['apple'], true);
            ext.addTest('apple pie', ['apples'], false);
            ext.addTest('apple pie', ['apple pie'], true);
        }
    });

function stringStartsWith(stringOrStrings: string | string[]) {

    var thisString = this as string;

    if (!stringOrStrings)
        return false;

    if ($.isArray(stringOrStrings)) {

        return (stringOrStrings as string[]).has((s: string) => {
            if (thisString.startsWith(s))
                return true;
            return false;
        });
    }

    return this.indexOf(stringOrStrings) == 0;
}

singString.method('endsWith', stringEndsWith,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        glyphIcon: '&#xe080;',
        tests(ext) {
            ext.addTest('', [], false);
            ext.addTest('', [''], false);
            ext.addTest('apple pie', [], false);
            ext.addTest('apple pie', [''], false);
            ext.addTest('apple pie', ['apple'], false);
            ext.addTest('apple pie', ['pie'], true);
            ext.addTest('apple pie', ['pies'], false);
        }
    });

function stringEndsWith(stringOrStrings: string | string[]) {
    if (!stringOrStrings)
        return false;

    if ($.isArray(stringOrStrings)) {
        const array = stringOrStrings as string[];
        for (let s in array) {
            if ((array).hasOwnProperty(s)) {
                if (this.endsWith(s))
                    return true;
            }
        }
        return false;
    }

    const index = this.indexOf(stringOrStrings);

    return index >= 0 && index == this.length - stringOrStrings.length;
}


singString.method('reverse', stringReverse,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        glyphIcon: '&#xe178;',
        tests(ext) {
            ext.addTest('', [], '');
            ext.addTest('apple pie', [], 'eip elppa');
        }
    });

function stringReverse() {
    let out = '';

    for (let i = this.length - 1; i >= 0; i--) {
        out += this[i];
    }
    return out;
}

singString.method('repeat', stringRepeat,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        glyphIcon: '&#xe031;',
        tests(ext) {
            ext.addTest('', [], '');
            ext.addTest('', [0], '');
            ext.addTest('', [5], '');
            ext.addTest(' ', [5], '     ');
            ext.addTest('apple', [-1], '');
            ext.addTest('apple', [0], '');
            ext.addTest('apple', [1], 'apple');
            ext.addTest('apple', [2], 'appleapple');
            ext.addTest('apple', [3, ' '], 'apple apple apple');
        }
    });

function stringRepeat(times: number = 0, separator: string = '') {
    if (times <= 0)
        return '';

    let out = '';

    for (let i = 0; i < times; i++) {
        out += this;

        if (separator.length > 0 && i < times - 1)
            out += separator;
    }

    return out;
}

singString.method('words', stringWords,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        glyphIcon: '&#xe111;',
        tests(ext) {
            ext.addTest('', [], '');
            ext.addTest('apple', [], ['apple']);
            ext.addTest('apple pie', [], ['apple', 'pie']);
        }
    });

function stringWords() {
    return this.collapseSpaces().split(' ');
}

singString.method('lines', stringLines,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        glyphIcon: '&#xe056;',
        tests(ext) {
            ext.addTest('', [], []);
            ext.addTest('apple pie', [], ['apple pie']);
            ext.addTest('\r\napple pie\r\n', [], ['', 'apple pie', '']);
            ext.addTest('apple pie\r\napple pie', [], ['apple pie', 'apple pie']);
        }
    });

function stringLines() {
    return this.split('\r\n');
}

singString.method('surround', stringSurround,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        glyphIcon: '&#xe065;',
        tests(ext) {
            ext.addTest('', [], '');
            ext.addTest('', [null], '');
            ext.addTest('', [undefined], '');
            ext.addTest('pie', ['---'], '---pie---');
        }
    });

function stringSurround(str: string) {
    if (!str)
        return this;

    return str + this + str;
}

singString.method('truncate', stringTruncate,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        glyphIcon: '&#xe226;',
        tests(ext) {
            ext.addTest('abc', [], '');
            ext.addTest('abc', [null], '');
            ext.addTest('abc', [undefined], '');
            ext.addTest('abc', [NaN], '');
            ext.addTest('abc', [-1], '');
            ext.addTest('abc', [1], 'a');
            ext.addTest('abc', [3], 'abc');
            ext.addTest('abc', [5], 'abc');
        }
    });

function stringTruncate(length: number): string {
    if (this.length < 0 || isNaN(length))
        return '';

    const thisStr = this as string;

    if (length < 0)
        length = 0;

    if (thisStr.length > length)
        return thisStr.substr(0, length).toString();

    return thisStr;
}

singString.method('isValidEmail', stringIsValidEmail,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        glyphIcon: '&#x2709;',
        tests(ext) {
        }
    });

function stringIsValidEmail(): boolean {
    const thisStr = this as string;

    return thisStr.hasMatch(/^([a-z0-9_\.-]+)@([\da-z\.-]+)\.([a-z\.]{2,6})$/);
}

singString.method('isHex', stringIsHex,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        glyphIcon: '&#xe180;',
        tests(ext) {
        }
    });

function stringIsHex(): boolean {
    const thisStr = this as string;

    return thisStr.hasMatch(/^#?([a-f0-9]{6}|[a-f0-9]{3})$/);
}

singString.method('isValidURL', stringIsValidUrl,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        glyphIcon: '&#xe135;',
        tests(ext) {
        }
    });

function stringIsValidUrl(): boolean {
    const thisStr = this as string;
    return thisStr.hasMatch(/^(https?:\/\/)?([\da-z\.-]+)\.([a-z\.]{2,6})([\/\w \.-]*)*\/?$/);
}

singString.method('isIPAddress', stringIsIpAddress,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        glyphIcon: '&#xe135;',
        tests(ext) {
        }
    });

function stringIsIpAddress(): boolean {
    const thisStr = this as string;
    return thisStr.hasMatch(/^(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$/);
}

singString.method('isGuid', stringIsGuid,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        glyphIcon: '&#xe041;',
        tests(ext) {
        }
    });

function stringIsGuid(): boolean {
    const thisStr = this as string;

    return thisStr.hasMatch(/^\{?[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}‌​\}?$/);
}


singString.method('tryToNumber', stringTryToNumber,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        glyphIcon: '&#xe141;',
        tests(ext) {
        }
    });

function stringTryToNumber(defaultValue: any = this) {
    let retValue = defaultValue;

    if (true) {
        const str = this;
        if (str.length > 0) {
            if (!isNaN(str)) {
                retValue = parseInt(str);
            }
        }
    }
    return $.isNumber(retValue) ? retValue : null;
}

//
//////////////////////////////////////////////////////
//
// String Array functions

singString.method('joinLines', stringJoinLines,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        glyphIcon: '&#xe058;',
        tests(ext) {
        }
    }, Array.prototype);

function stringJoinLines(asHTML: boolean = true) {
    return this.join(asHTML ? '<br/>' : '\r\n');
}

//
//////////////////////////////////////////////////////
//

singString.method('pad', stringPad,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        glyphIcon: '&#xe051;',
        tests(ext) {

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
        }
    });

function stringPad(length: number, align: Direction = Direction.left, whitespace: string = ' ') {

    if (align != Direction.left && align != Direction.l &&
        align != Direction.right && align != Direction.r &&
        align != Direction.center && align != Direction.c) {
        return this;
    }
    let out = this;
    let whitespaceIndex = 0;

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

singString.method('toStr', booleanToStr,
    {
        summary: 'Converts the calling Boolean to string.',
        parameters: [
            {
                name: 'includeMarkup',
                types: [Boolean],
                description: 'Set includeMarkup to true to retrieve the actual string representaion of true and false.',
                defaultValue: false
            }
        ],
        returns: 'A String representation of the boolean value',
        returnType: String,
        examples: ['\
            If you specify a true value for includeMarkup, Booleans will be returned as \'true\' or \'false\' \r\n\
            Otherwise, \'Yes\' or \'No\' will be returned.'],
        glyphIcon: '&#xe241;',
        tests(ext) {
            ext.addTest(true, [], 'Yes');
            ext.addTest(true, [false], 'Yes');
            ext.addTest(true, [true], 'true');
            ext.addTest(false, [], 'No');
            ext.addTest(false, [false], 'No');
            ext.addTest(false, [true], 'false');
        }
    }, Boolean.prototype, 'Boolean');

function booleanToStr(includeMarkup: boolean = false): string {
    if (includeMarkup == false)
        return this.toYesNo();

    return this == false ? 'false' : 'true';
}

singString.method('toStr', objectToStr,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: '',
        examples: null,
        glyphIcon: '&#xe241;',
        tests(ext) {

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

            ext.addTest($, [/$^/], '/$^/');
            ext.addTest($, [/$^/, false], '/$^/');
            ext.addTest($, [/$^/, true], '/$^/');


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
        }
    }, $, 'jQuery');

function objectToStr(obj: any, includeMarkup: boolean = false, stack: any[] = []) {

    if (obj === undefined)
        return includeMarkup ? 'undefined' : '';
    if (obj === null)
        return includeMarkup ? 'null' : '';
    if (obj === $)
        return '$';
    if (obj === sing)
        return 'sing';

    if (obj.toStr && obj.toStr != objectToStr)
        return obj.toStr(includeMarkup);

    if (typeof obj == 'object') {
        if (obj.toString && obj.toString !== ({}).toString)
            return obj.toString();

        // Prevents infinite recursion
        if (stack.has((item: any) => (item === obj))) {
            return '';
        }

        stack = stack.clone();
        stack.push(obj);

        var out = includeMarkup ? '{' : '';

        var keyCount = Object.keys(obj).length;

        $.objEach(obj, (key, item, index) => {
            if (includeMarkup) {
                out += `${key || '\'\''}: ${$.toStr(item, true, stack)}`;
                if (index < keyCount - 1)
                    out += ', ';
            }
            else {
                out += `${key}: ${$.toStr(item, false, stack)}\r\n`;
            }
        });

        out += includeMarkup ? '}' : '';
        return out;
    }

    return obj;
}

singString.method('toStr', arrayToStr,
    {
        summary: null,
        parameters: null,
        returns: null,
        returnType: String,
        examples: null,
        glyphIcon: '&#xe241;',
        tests(ext) {
        }
    }, Array.prototype, 'Array');

function arrayToStr(includeMarkup: boolean = false) {

    const thisArray = this as any[];

    var out = includeMarkup ? '[' : '';
    thisArray.each((item, i) => {
        if (item === null)
            out += 'null';
        else if (item === undefined)
            out += 'undefined';
        else if (item.toStr)
            out += item.toStr(includeMarkup);  // includeMarkup is passed to child elements
        else if (objectIsHash(item))
            out += objectToStr(item, includeMarkup);

        if (i < this.length - 1)
            out += includeMarkup ? ', ' : '\r\n';
    });

    out += includeMarkup ? ']' : '';

    return out;
}

singString.method('toStr', stringToStr,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        glyphIcon: '&#xe241;',
        tests(ext) {
        }
    });

function stringToStr(includeMarkup: boolean = false) {
    if (includeMarkup)
        return `'${this.replaceAll('\r\n', '\\r\\n')}'`;

    return this;
}

singString.method('isString', isString,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: '',
        examples: null,
        glyphIcon: '&#xe241;',
        tests(ext) {
            ext.addTest($, [], false);
            ext.addTest($, [], false);
            ext.addTest($, [], false);
            ext.addTest($, [5], false);
            ext.addTest($, [''], true);
            ext.addTest($, ['a'], true);
        }
    }, $);

function isString(str?: any) {
    return typeof str == 'string';
}

singString.method('first', stringFirst,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        glyphIcon: '&#xe070;',
        tests(ext) {
        }
    });

function stringFirst(count: number) {

    if (count <= 0)
        return '';

    if (count >= this.length)
        return this;

    return this.substr(0, count);
}

singString.method('last', stringLast,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        glyphIcon: '&#xe076;',
        tests(ext) {
        }
    });

function stringLast(count: number) {

    if (count <= 0)
        return '';

    if (count >= this.length)
        return this;

    return this.substr(this.length - count, count);
}

singString.method('containsAny', stringContainsAny,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        glyphIcon: '&#xe003;',
        tests(ext) {
        }
    });

function stringContainsAny(...items: string[]) {
    if (!items || items.length == 0)
        return false;

    return items.has(function (item: string) {
        return this.contains(item);
    });
}

singString.method('before', stringBefore,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        glyphIcon: '&#xe071;',
        tests(ext) {
        }
    });

function stringBefore(search: string) {
    if (search == '')
        return this;

    const index = this.indexOf(search);

    if (index < 0)
        return this;

    return this.substr(0, index).before(search);
}

singString.method('after', stringAfter,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        glyphIcon: '&#xe075;',
        tests(ext) {
        }
    });

function stringAfter(search: string) {
    if (search == '')
        return this;

    const index = this.indexOf(search);

    if (index < 0)
        return this;

    return this.substr(index + search.length).after(search);
}


singString.method('beforeLast', stringBeforeLast,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        glyphIcon: null,
        tests(ext) {
        }
    });

function stringBeforeLast(search: string) {
    if (search == '')
        return this;

    const index = this.indexOf(search);

    if (index < 0)
        return this;

    return this.substr(0, index);
}

singString.method('afterFirst', stringAfterFirst,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        glyphIcon: null,
        tests(ext) {
        }
    });

function stringAfterFirst(search: string) {
    if (search == '')
        return this;

    const index = this.indexOf(search);

    if (index < 0)
        return this;

    return this.substr(index + search.length);
}

singString.method('toSlug', stringToSlug,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        glyphIcon: '&#xe135;',
        tests(ext) {
        }
    });

function stringToSlug() {

    // ReSharper disable once ConditionIsAlwaysConst
// ReSharper disable once HeuristicallyUnreachableCode
    let text: string = this || '';
    text = text.toLowerCase();
    text = text.replace(/\./g, '_');
    text = text.replace(/\s/g, '-');

    return text;
}

singString.method('containsAll', stringContainsAll,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        glyphIcon: '&#xe015;',
        tests(ext) {
        }
    });

function stringContainsAll(...items: string[]) {

    if (items.length == 0)
        return false;

    const thisStr = this as string;

    for (let i = 0; i < items.length; i++) {
        if (!thisStr.contains(items[i]))
            return false;
    }

    return true;
}

singString.method('pluralize', stringPluralize,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        glyphIcon: '&#xe256;',
        tests(ext) {
        }
    });

function stringPluralize(count: number) {
    const thisStr = this as string;

    if (count === undefined || count === null)
        return thisStr;

    if (count == 0 || count > 1)
        return `${thisStr}s`;

    return thisStr;
}

singString.method('isJSON', stringIsJson,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        glyphIcon: '&#xe105;',
        tests(ext) {
        }
    });

function stringIsJson(): boolean {
    try {
        const thisStr = this as string;
        const jsonObject = jQuery.parseJSON(thisStr);

        return $.isDefined(jsonObject);
    }
    catch (e) {
        return false;
    }
}

singString.method('parseJSON', stringParseJson,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        glyphIcon: '&#xe105;',
        tests(ext) {
        }
    });

function stringParseJson(): Object {
    const thisStr = this as string;
    const jsonObject = jQuery.parseJSON(thisStr);
    return jsonObject;
}

singString.method('fill', stringFill,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        glyphIcon: '&#xe025;',
        tests(ext) {
        }
    });

function stringFill(fillWith: string) {
    if (this.length == 0)
        return '';

    const thisStr = this as string;

    if (!fillWith || fillWith.length == 0)
        return this;

    let out = '';

    while (out.length < this.length) {
        out += fillWith;
    }

    if (out.length > thisStr.length)
        out = out.substr(0, thisStr.length);

    return out;
}


function test() {
    const bracketStart = '{';
    const bracketEnd = '}';

    /*
    var bracketStart = '[';
    var bracketEnd = ']';

    var bracketStart = '(';
    var bracketEnd = ')';
    */

    const block = this as string;
    let startIndex: number;
// ReSharper disable once UsageOfPossiblyUnassignedValue
    let currPos = startIndex;
    let openBrackets = 0;
    let stillSearching = true;
    let waitForChar: string = null;

    while (stillSearching && currPos <= block.length) {
        const currChar = block.charAt(currPos);

        if (!waitForChar) {
            switch (currChar) {
                case bracketStart:
                    openBrackets++;
                    break;
                case bracketEnd:
                    openBrackets--;
                    break;
                case '"':
                case "'":
                    waitForChar = currChar;
                    break;
                case '/':
                    const nextChar = block.charAt(currPos + 1);
                    if (nextChar === '/') {
                        waitForChar = '\n';
                    } else if (nextChar === '*') {
                        waitForChar = '*/';
                    }
            }
        } else {
            if (currChar === waitForChar) {
                if (waitForChar === '"' || waitForChar === "'") {
                    block.charAt(currPos - 1) !== '\\' && (waitForChar = null);
                } else {
                    waitForChar = null;
                }
            } else if (currChar === '*') {
                block.charAt(currPos + 1) === '/' && (waitForChar = null);
            }
        }

        currPos++;
        if (openBrackets === 0) { stillSearching = false; }
    }

    return block.substring(startIndex, currPos);
}
/*
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
*/


//
