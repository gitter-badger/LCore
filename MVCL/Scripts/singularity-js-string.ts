
interface String {
    pad?: (length: number, align?: Direction) => string;
    lower?: () => string;
    upper?: () => string;
    replaceAll?: (find: string, replace?: string) => string;
    removeAll?: (find: string) => string;
    contains?: (search: string) => boolean;
    collapseSpaces? (): string;
    log?: () => void;
    startsWith?: (search: string) => boolean;
    endsWith?: (search: string) => boolean;
    reverse?: () => string;
    repeat?: (times: number) => string;
    words?: () => string[];
    lines?: () => string[];
    surround?: (str: string) => string;
    truncate?: (length: number) => string;

    hasMatch?: (pattern: RegExp) => boolean;
    matchCount?: (pattern: RegExp) => number;

    numericValueOf?: () => number;
    toStr?: (includeMarkup?: boolean) => string;
    // log?: () => void;

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

/// <reference path="singularity-core.ts"/>

function InitSingularityJS_String() {
    //////////////////////////////////////////////////////
    //
    //
    // String Extensions
    //

    sing.addStringExt('contains', StringContains,
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

    //
    //////////////////////////////////////////////////////
    //

    sing.addStringExt('replaceAll', StringReplaceAll,
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
    

    //
    //////////////////////////////////////////////////////
    //

    sing.addStringExt('upper', StringUpper,
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

    //
    //////////////////////////////////////////////////////
    //

    sing.addStringExt('lower', StringLower,
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

    //
    //////////////////////////////////////////////////////
    //

    sing.addStringExt('collapseSpaces', StringCollapseSpaces,
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

    //
    //////////////////////////////////////////////////////
    //

    sing.addStringExt('startsWith', StringStartsWith,
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

    //
    //////////////////////////////////////////////////////
    //

    sing.addStringExt('log', StringLog,
        {
            summary: null,
            parameters: null,
            returns: '',
            returnType: null,
            examples: null,
            tests: function (ext) {
            },
        });

    function StringLog() {
        log(this);
    }

    //
    //////////////////////////////////////////////////////
    //

    sing.addStringExt('endsWith', StringEndsWith,
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

    //
    //////////////////////////////////////////////////////
    //

    sing.addStringExt('removeAll', StringRemoveAll,
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

    //
    //////////////////////////////////////////////////////
    //

    sing.addStringExt('reverse', StringReverse,
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

    //
    //////////////////////////////////////////////////////
    //

    sing.addStringExt('repeat', StringRepeat,
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

    //
    //////////////////////////////////////////////////////
    //

    sing.addStringExt('words', StringWords,
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

    //
    //////////////////////////////////////////////////////
    //

    sing.addStringExt('lines', StringLines,
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

    //
    //////////////////////////////////////////////////////
    //

    sing.addStringExt('surround', StringSurround,
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

    //
    //////////////////////////////////////////////////////
    //

    sing.addStringExt('truncate', StringTruncate,
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

    //
    //////////////////////////////////////////////////////
    //

    sing.addStringExt('toStr', StringToStr,
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

    //
    //////////////////////////////////////////////////////
    //
    // String Array functions
    
    sing.addArrayExt('joinLines', StringJoinLines,
        {
            summary: null,
            parameters: null,
            returns: '',
            returnType: null,
            examples: null,
            tests: function (ext) {
            },
        });

    function StringJoinLines() {
        if (!this)
            return '';

        return this.join('\r\n');
    }

    //
    //////////////////////////////////////////////////////
    //

    sing.addStringExt('pad', StringPad,
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
    sing.addStringExt('matchCount', StringMatchCount,
        {
            summary: null,
            parameters: null,
            returns: '',
            returnType: null,
            examples: null,
            tests: function (ext) {
            },
        });

    function StringMatchCount(pattern: string) {

        var match = this.match(pattern);

        if (!match)
            return 0;

        return match.length;
    }

    sing.addStringExt('hasMatch', StringHasMatch,
        {
            summary: null,
            parameters: null,
            returns: '',
            returnType: null,
            examples: null,
            tests: function (ext) {
            },
        });

    function StringHasMatch(pattern: string): boolean {

        var match = this.match(pattern);

        if (!match || match.length == 0)
            return false

        return true;
    }

    sing.addStringExt('isValidEmail', StringIsValidEmail,
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

    sing.addStringExt('isHex', StringIsHex,
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

    sing.addStringExt('isValidURL', null,
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

    sing.addStringExt('isIPAddress', StringIsIPAddress,
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

    sing.addStringExt('isGuid', StringIsGuid,
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
    sing.addStringExt('numericValueOf', StringNumericValueOf,
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

    sing.addStringExt('isDate', null,
        {
            summary: null,
            parameters: null,
            returns: '',
            returnType: null,
            examples: null,
            tests: function (ext) {
            },
        });
    sing.addStringExt('isBoolean', null,
        {
            summary: null,
            parameters: null,
            returns: '',
            returnType: null,
            examples: null,
            tests: function (ext) {
            },
        });
    sing.addStringExt('isNumeric', null,
        {
            summary: null,
            parameters: null,
            returns: '',
            returnType: null,
            examples: null,
            tests: function (ext) {
            },
        });

    sing.addStringExt('toNumber', null,
        {
            summary: null,
            parameters: null,
            returns: '',
            returnType: null,
            examples: null,
            tests: function (ext) {
            },
        });
    sing.addStringExt('toBoolean', null,
        {
            summary: null,
            parameters: null,
            returns: '',
            returnType: null,
            examples: null,
            tests: function (ext) {
            },
        });
    sing.addStringExt('toUrlSlug', null,
        {
            summary: null,
            parameters: null,
            returns: '',
            returnType: null,
            examples: null,
            tests: function (ext) {
            },
        });

    sing.addStringExt('parse', null,
        {
            summary: null,
            parameters: null,
            returns: '',
            returnType: null,
            examples: null,
            tests: function (ext) {
            },
        });
    sing.addStringExt('first', null,
        {
            summary: null,
            parameters: null,
            returns: '',
            returnType: null,
            examples: null,
            tests: function (ext) {
            },
        });
    sing.addStringExt('last', null,
        {
            summary: null,
            parameters: null,
            returns: '',
            returnType: null,
            examples: null,
            tests: function (ext) {
            },
        });
    sing.addStringExt('containsAny', null,
        {
            summary: null,
            parameters: null,
            returns: '',
            returnType: null,
            examples: null,
            tests: function (ext) {
            },
        });
    sing.addStringExt('containsAll', null,
        {
            summary: null,
            parameters: null,
            returns: '',
            returnType: null,
            examples: null,
            tests: function (ext) {
            },
        });
    sing.addStringExt('parseJSON', null,
        {
            summary: null,
            parameters: null,
            returns: '',
            returnType: null,
            examples: null,
            tests: function (ext) {
            },
        });
    sing.addStringExt('lastIndexOf', null,
        {
            summary: null,
            parameters: null,
            returns: '',
            returnType: null,
            examples: null,
            tests: function (ext) {
            },
        });
    sing.addStringExt('capitalize', null,
        {
            summary: null,
            parameters: null,
            returns: '',
            returnType: null,
            examples: null,
            tests: function (ext) {
            },
        });
    sing.addStringExt('camelize', null,
        {
            summary: null,
            parameters: null,
            returns: '',
            returnType: null,
            examples: null,
            tests: function (ext) {
            },
        });
    sing.addStringExt('stripTags', null,
        {
            summary: null,
            parameters: null,
            returns: '',
            returnType: null,
            examples: null,
            tests: function (ext) {
            },
        });
    sing.addStringExt('pluralize', null,
        {
            summary: null,
            parameters: null,
            returns: '',
            returnType: null,
            examples: null,
            tests: function (ext) {
            },
        });
    sing.addStringExt('fill', null,
        {
            summary: null,
            parameters: null,
            returns: '',
            returnType: null,
            examples: null,
            tests: function (ext) {
            },
        });
    sing.addStringExt('similarity', null,
        {
            summary: null,
            parameters: null,
            returns: '',
            returnType: null,
            examples: null,
            tests: function (ext) {
            },
        });
    sing.addStringExt('like', null,
        {
            summary: null,
            parameters: null,
            returns: '',
            returnType: null,
            examples: null,
            tests: function (ext) {
            },
        });
    sing.addStringExt('isJSON', null,
        {
            summary: null,
            parameters: null,
            returns: '',
            returnType: null,
            examples: null,
            tests: function (ext) {
            },
        });

    //
}
