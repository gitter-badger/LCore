
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

    numericValueOf?: () => number;
    toStr?: (includeMarkup?: boolean) => string;
    log?: () => void;

    textToHTML?: () => string;

    templateInject?: (obj: Object, itemKey?: string, itemObj?: Object) => string;
    templateExtract?: (template: string) => Object;

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

interface Array<T> {
    joinLines?: () => string;
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

singString.addExt('numericValueOf', StringNumericValueOf,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

function StringNumericValueOf(): string {
    return this.valueOf();
}

singString.addExt('textToHTML', StringTextToHTML,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

function StringTextToHTML(): string {

    return this.replaceAll('\r\n', '\n')
        .replaceAll('\r\n', '<br/>')
        .replaceAll(' ', '&nbsp;');
}


singString.addExt('log', StringLog,
    {
        summary: 'Common funciton - Logs the calling Boolean to the console.',
        parameters: [],
        returns: 'Nothing.',
        returnType: null,
        examples: ['\
            (\'a\').log()   //  logs a  \r\n\
            (\'hello\').log()   //  logs hello  \r\n'],
        tests: function (ext) {
            ext.addTest('', []);
            ext.addTest('a', []);
            ext.addTest('hello', []);
        }
    });

function StringLog(): void {
    log(this);
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

singString.addExt('stripHTML', StringStripHTML,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

function StringStripHTML() {

    var out = <string>this;

    var pattern = /.*\<(.+)\>.*/

    out.replaceRegExp(pattern, / /);

    return out;
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

