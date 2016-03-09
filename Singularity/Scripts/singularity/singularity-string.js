/// <reference path="singularity-core.ts"/>
var singString = singExt.addModule(new sing.Module("String", String));
singString.glyphIcon = '&#xe241;';
/// <reference path="singularity-core.ts"/>
//////////////////////////////////////////////////////
//
//
// String Extensions
//
singString.method('contains', StringContains, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe003;',
    tests: function (ext) {
        ext.addTest('', [], false);
        ext.addTest('', [''], false);
        ext.addTest('', [' '], false);
        ext.addTest(' ', [''], false);
        ext.addTest(' ', [' '], true);
        ext.addTest('abc', ['a'], true);
        ext.addTest('abc', ['d'], false);
        ext.addTest('abc', ['abc'], true);
    },
});
function StringContains(str) {
    if (!this || !str || str == '')
        return false;
    return this == str || this.indexOf(str) >= 0;
}
singString.method('replaceAll', StringReplaceAll, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe015;',
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
    // if replace is null, return original string otherwise it will
    // replace search string with 'undefined'.
    if (replaceOrReplacements == undefined || replaceOrReplacements == null)
        replaceOrReplacements = '';
    if (searchOrSearches == undefined || searchOrSearches == null || searchOrSearches == '')
        return this;
    var out = this;
    if ($.isArray(searchOrSearches)) {
        var searchArray = searchOrSearches;
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
        while (out.indexOf(searchOrSearches) >= 0)
            out = out.replace(searchOrSearches, replaceOrReplacements);
        return out.toString();
    }
}
singString.method('removeAll', StringRemoveAll, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe016;',
    tests: function (ext) {
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
singString.method('upper', StringUpper, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe260;',
    tests: function (ext) {
        ext.addTest('', [], '');
        ext.addTest('apple', [], 'APPLE');
        ext.addTest('Apple', [], 'APPLE');
        ext.addTest('APPLE', [], 'APPLE');
    },
});
function StringUpper() {
    return this.toUpperCase();
}
singString.method('lower', StringLower, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe259;',
    tests: function (ext) {
        ext.addTest('', [], '');
        ext.addTest('apple', [], 'apple');
        ext.addTest('Apple', [], 'apple');
        ext.addTest('APPLE', [], 'apple');
    },
});
function StringLower() {
    return this.toLowerCase();
}
singString.method('collapseSpaces', StringCollapseSpaces, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: 'icon-resize-small',
    tests: function (ext) {
        ext.addTest('', [], '');
        ext.addTest('           ', [], ' ');
        ext.addTest('apple pie', [], 'apple pie');
        ext.addTest('apple       pie', [], 'apple pie');
    },
});
function StringCollapseSpaces() {
    return this.replaceAll('  ', ' ');
}
singString.method('startsWith', StringStartsWith, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe079;',
    tests: function (ext) {
        ext.addTest('', [], false);
        ext.addTest('', [''], false);
        ext.addTest('apple pie', [], false);
        ext.addTest('apple pie', [''], false);
        ext.addTest('apple pie', ['apple'], true);
        ext.addTest('apple pie', ['apples'], false);
        ext.addTest('apple pie', ['apple pie'], true);
    },
});
function StringStartsWith(stringOrStrings) {
    var thisString = this;
    if (!stringOrStrings)
        return false;
    if ($.isArray(stringOrStrings)) {
        return stringOrStrings.has(function (s, i) {
            if (thisString.startsWith(s))
                return true;
            return false;
        });
    }
    return this.indexOf(stringOrStrings) == 0;
}
singString.method('endsWith', StringEndsWith, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe080;',
    tests: function (ext) {
        ext.addTest('', [], false);
        ext.addTest('', [''], false);
        ext.addTest('apple pie', [], false);
        ext.addTest('apple pie', [''], false);
        ext.addTest('apple pie', ['apple'], false);
        ext.addTest('apple pie', ['pie'], true);
        ext.addTest('apple pie', ['pies'], false);
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
    var index = this.indexOf(stringOrStrings);
    return index >= 0 && index == this.length - stringOrStrings.length;
}
singString.method('reverse', StringReverse, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe178;',
    tests: function (ext) {
        ext.addTest('', [], '');
        ext.addTest('apple pie', [], 'eip elppa');
    },
});
function StringReverse() {
    if (!this)
        return '';
    var out = '';
    for (var i = this.length - 1; i >= 0; i--) {
        out += this[i];
    }
    return out;
}
singString.method('repeat', StringRepeat, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe031;',
    tests: function (ext) {
        ext.addTest('', [], '');
        ext.addTest('', [0], '');
        ext.addTest('', [5], '');
        ext.addTest(' ', [5], '     ');
        ext.addTest('apple', [-1], '');
        ext.addTest('apple', [0], '');
        ext.addTest('apple', [1], 'apple');
        ext.addTest('apple', [2], 'appleapple');
        ext.addTest('apple', [3, ' '], 'apple apple apple');
    },
});
function StringRepeat(times, separator) {
    if (times === void 0) { times = 0; }
    if (separator === void 0) { separator = ''; }
    if (times <= 0)
        return '';
    var out = '';
    for (var i = 0; i < times; i++) {
        out += this;
        if (separator.length > 0 && i < times - 1)
            out += separator;
    }
    return out;
}
singString.method('words', StringWords, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe111;',
    tests: function (ext) {
        ext.addTest('', [], '');
        ext.addTest('apple', [], ['apple']);
        ext.addTest('apple pie', [], ['apple', 'pie']);
    },
});
function StringWords() {
    if (!this)
        return [];
    return this.collapseSpaces().split(' ');
}
singString.method('lines', StringLines, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe056;',
    tests: function (ext) {
        ext.addTest('', [], []);
        ext.addTest('apple pie', [], ['apple pie']);
        ext.addTest('\r\napple pie\r\n', [], ['', 'apple pie', '']);
        ext.addTest('apple pie\r\napple pie', [], ['apple pie', 'apple pie']);
    },
});
function StringLines() {
    if (!this)
        return [];
    return this.split('\r\n');
}
singString.method('surround', StringSurround, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe065;',
    tests: function (ext) {
        ext.addTest('', [], '');
        ext.addTest('', [null], '');
        ext.addTest('', [undefined], '');
        ext.addTest('pie', ['---'], '---pie---');
    },
});
function StringSurround(str) {
    if (!this || !str)
        return this;
    return str + this + str;
}
singString.method('truncate', StringTruncate, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe226;',
    tests: function (ext) {
        ext.addTest('abc', [], '');
        ext.addTest('abc', [null], '');
        ext.addTest('abc', [undefined], '');
        ext.addTest('abc', [NaN], '');
        ext.addTest('abc', [-1], '');
        ext.addTest('abc', [1], 'a');
        ext.addTest('abc', [3], 'abc');
        ext.addTest('abc', [5], 'abc');
    },
});
function StringTruncate(length) {
    if (!this || this.length < 0 || isNaN(length))
        return '';
    var thisStr = this;
    if (length < 0)
        length = 0;
    if (thisStr.length > length)
        return thisStr.substr(0, length).toString();
    return thisStr;
}
singString.method('isValidEmail', StringIsValidEmail, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#x2709;',
    tests: function (ext) {
    },
});
function StringIsValidEmail() {
    var thisStr = this;
    return thisStr.hasMatch(/^([a-z0-9_\.-]+)@([\da-z\.-]+)\.([a-z\.]{2,6})$/);
}
singString.method('isHex', StringIsHex, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe180;',
    tests: function (ext) {
    },
});
function StringIsHex() {
    var thisStr = this;
    return thisStr.hasMatch(/^#?([a-f0-9]{6}|[a-f0-9]{3})$/);
}
singString.method('isValidURL', StringIsValidURL, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe135;',
    tests: function (ext) {
    },
});
function StringIsValidURL() {
    var thisStr = this;
    return thisStr.hasMatch(/^(https?:\/\/)?([\da-z\.-]+)\.([a-z\.]{2,6})([\/\w \.-]*)*\/?$/);
}
singString.method('isIPAddress', StringIsIPAddress, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe135;',
    tests: function (ext) {
    },
});
function StringIsIPAddress() {
    var thisStr = this;
    return thisStr.hasMatch(/^(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$/);
}
singString.method('isGuid', StringIsGuid, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe041;',
    tests: function (ext) {
    },
});
function StringIsGuid() {
    var thisStr = this;
    return thisStr.hasMatch(/^\{?[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}‌​\}?$/);
}
singString.method('tryToNumber', StringTryToNumber, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe141;',
    tests: function (ext) {
    },
});
function StringTryToNumber(defaultValue) {
    if (defaultValue === void 0) { defaultValue = this; }
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
singString.method('joinLines', StringJoinLines, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe058;',
    tests: function (ext) {
    },
}, Array.prototype);
function StringJoinLines(asHTML) {
    if (asHTML === void 0) { asHTML = true; }
    if (!this)
        return '';
    return this.join(asHTML ? '<br/>' : '\r\n');
}
//
//////////////////////////////////////////////////////
//
singString.method('pad', StringPad, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe051;',
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
function StringPad(length, align, whitespace) {
    if (align === void 0) { align = Direction.left; }
    if (whitespace === void 0) { whitespace = ' '; }
    if (align != Direction.left && align != Direction.l && align != Direction.right && align != Direction.r && align != Direction.center && align != Direction.c) {
        return this;
    }
    if (!this)
        return whitespace.repeat(length);
    var out = this;
    var whitespaceIndex = 0;
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
singString.method('toStr', BooleanToStr, {
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
    glyphIcon: '&#xe241;',
    tests: function (ext) {
        ext.addTest(true, [], 'Yes');
        ext.addTest(true, [false], 'Yes');
        ext.addTest(true, [true], 'true');
        ext.addTest(false, [], 'No');
        ext.addTest(false, [false], 'No');
        ext.addTest(false, [true], 'false');
    }
}, Boolean.prototype, "Boolean");
function BooleanToStr(includeMarkup) {
    if (includeMarkup === void 0) { includeMarkup = false; }
    if (includeMarkup == false)
        return this.toYesNo();
    return this == false ? "false" : "true";
}
singString.method('toStr', ObjectToStr, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: '',
    examples: null,
    glyphIcon: '&#xe241;',
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
    },
}, $, 'jQuery');
function ObjectToStr(obj, includeMarkup, stack) {
    if (includeMarkup === void 0) { includeMarkup = false; }
    if (stack === void 0) { stack = []; }
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
        if (obj.toString && obj.toString !== ({}).toString)
            return obj.toString();
        // Prevents infinite recursion
        if (stack.has(function (item) {
            return item === obj;
        })) {
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
singString.method('toStr', ArrayToStr, {
    summary: null,
    parameters: null,
    returns: null,
    returnType: String,
    examples: null,
    glyphIcon: '&#xe241;',
    tests: function (ext) {
    },
}, Array.prototype, "Array");
function ArrayToStr(includeMarkup) {
    if (includeMarkup === void 0) { includeMarkup = false; }
    var thisArray = this;
    var out = includeMarkup ? '[' : '';
    var src = this;
    thisArray.each(function (item, i) {
        if (item === null)
            out += 'null';
        else if (item === undefined)
            out += 'undefined';
        else if (item.toStr)
            out += item.toStr(includeMarkup); // includeMarkup is passed to child elements
        else if ($.isHash(item))
            out += $.toStr(item, includeMarkup);
        if (i < src.length - 1)
            out += includeMarkup ? ', ' : '\r\n';
    });
    out += includeMarkup ? ']' : '';
    return out;
}
singString.method('toStr', StringToStr, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe241;',
    tests: function (ext) {
    },
});
function StringToStr(includeMarkup) {
    if (includeMarkup === void 0) { includeMarkup = false; }
    if (includeMarkup)
        return "'" + this.replaceAll('\r\n', '\\r\\n') + "'";
    return this;
}
singString.method('isString', IsString, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: '',
    examples: null,
    glyphIcon: '&#xe241;',
    tests: function (ext) {
        ext.addTest($, [], false);
        ext.addTest($, [], false);
        ext.addTest($, [], false);
        ext.addTest($, [5], false);
        ext.addTest($, [''], true);
        ext.addTest($, ['a'], true);
    },
}, $);
function IsString(str) {
    return typeof str == 'string';
}
singString.method('first', StringFirst, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe070;',
    tests: function (ext) {
    },
});
function StringFirst(count) {
    if (count <= 0)
        return '';
    if (count >= this.length)
        return this;
    return this.substr(0, count);
}
singString.method('last', StringLast, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe076;',
    tests: function (ext) {
    },
});
function StringLast(count) {
    if (count <= 0)
        return '';
    if (count >= this.length)
        return this;
    return this.substr(this.length - count, count);
}
singString.method('containsAny', StringContainsAny, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe003;',
    tests: function (ext) {
    },
});
function StringContainsAny() {
    var items = [];
    for (var _i = 0; _i < arguments.length; _i++) {
        items[_i - 0] = arguments[_i];
    }
    if (!this)
        return false;
    if (!items || item.length == 0)
        return false;
    return items.has(function (item) {
        return this.contains(item);
    });
}
singString.method('before', StringBefore, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe071;',
    tests: function (ext) {
    },
});
function StringBefore(search) {
    if (!this || !search == null || search == '')
        return this;
    var index = this.indexOf(search);
    if (index < 0)
        return this;
    return this.substr(0, index);
}
singString.method('after', StringAfter, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe075;',
    tests: function (ext) {
    },
});
function StringAfter(search) {
    if (!this || !search == null || search == '')
        return this;
    var index = this.indexOf(search);
    if (index < 0)
        return this;
    return this.substr(index + search.length);
}
singString.method('toSlug', StringToSlug, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe135;',
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
singString.method('containsAll', StringContainsAll, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe015;',
    tests: function (ext) {
    },
});
function StringContainsAll() {
    var items = [];
    for (var _i = 0; _i < arguments.length; _i++) {
        items[_i - 0] = arguments[_i];
    }
    if (!this || items.length == 0)
        return false;
    var thisStr = this;
    for (var i = 0; i < items.length; i++) {
        if (!thisStr.contains(items[i]))
            return false;
    }
    return true;
}
singString.method('pluralize', StringPluralize, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe256;',
    tests: function (ext) {
    },
});
function StringPluralize(count) {
    if (!this)
        return '';
    var thisStr = this;
    if (count === undefined || count === null)
        return thisStr;
    if (count == 0 || count > 1)
        return thisStr + 's';
    return thisStr;
}
singString.method('isJSON', StringIsJSON, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe105;',
    tests: function (ext) {
    },
});
function StringIsJSON() {
    try {
        var thisStr = this;
        var jsonObject = jQuery.parseJSON(thisStr);
        return $.isDefined(jsonObject);
    }
    catch (e) {
        return false;
    }
}
singString.method('parseJSON', StringParseJSON, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe105;',
    tests: function (ext) {
    },
});
function StringParseJSON() {
    var thisStr = this;
    var jsonObject = jQuery.parseJSON(thisStr);
    return jsonObject;
}
singString.method('fill', StringFill, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe025;',
    tests: function (ext) {
    },
});
function StringFill(fillWith) {
    if (!this || this.length == 0)
        return '';
    var thisStr = this;
    if (!fillWith || fillWith.length == 0)
        return this;
    var out = '';
    while (out.length < this.length) {
        out += fillWith;
    }
    if (out.length > thisStr.length)
        out = out.substr(0, thisStr.length);
    return out;
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
//# sourceMappingURL=singularity-string.js.map