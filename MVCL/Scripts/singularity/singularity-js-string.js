var singString = singExt.addModule(new sing.Module("String", String));
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
    tests: function (ext) {
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
        while (out.indexOf(searchOrSearches) > 0)
            out = out.replace(searchOrSearches, replaceOrReplacements);
        return out.toString();
    }
}
singString.method('upper', StringUpper, {
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
singString.method('lower', StringLower, {
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
singString.method('collapseSpaces', StringCollapseSpaces, {
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
singString.method('startsWith', StringStartsWith, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
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
    var index = this.indexOf(stringOrStrings);
    return index >= 0 && index == this.length - stringOrStrings.length;
}
singString.method('removeAll', StringRemoveAll, {
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
singString.method('reverse', StringReverse, {
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
singString.method('repeat', StringRepeat, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    },
});
function StringRepeat(times) {
    if (times === void 0) { times = 0; }
    if (times <= 0)
        return '';
    var out = '';
    for (var i = 0; i < times; i++) {
        out += this;
    }
    return out;
}
singString.method('words', StringWords, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
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
    tests: function (ext) {
    },
});
function StringLines() {
    if (!this)
        return [];
    return this.collapseSpaces().split('\r\n');
}
singString.method('surround', StringSurround, {
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
        return this;
    return str + this + str;
}
singString.method('truncate', StringTruncate, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    },
});
function StringTruncate(length) {
    if (!this || this.length < 0)
        return '';
    if (this.length > length)
        return this.substr(0, length).toString();
    return this;
}
singString.method('isValidEmail', StringIsValidEmail, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
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
    tests: function (ext) {
    },
});
function StringIsHex() {
    var thisStr = this;
    return thisStr.hasMatch(/^#?([a-f0-9]{6}|[a-f0-9]{3})$/);
}
singString.method('isValidURL', null, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
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
    tests: function (ext) {
    },
});
function StringIsGuid() {
    var thisStr = this;
    return thisStr.hasMatch(/^\{?[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}‌​\}?$/);
}
singString.method('tryToNumber', null, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
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
singString.method('toStr', ToStr, {
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
function ToStr(obj, includeMarkup) {
    if (includeMarkup === void 0) { includeMarkup = false; }
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
singString.method('toStr', ArrayToStr, {
    summary: null,
    parameters: null,
    returns: null,
    returnType: String,
    examples: null,
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
        else if (item['toStr'])
            out += item['toStr'](includeMarkup); // includeMarkup is passed to child elements
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
singString.method('first', StringFirst, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
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
singString.method('containsAny', null, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
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
singString.method('isDate', null, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    },
});
singString.method('containsAll', null, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    },
});
singString.method('parseJSON', null, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    },
});
singString.method('lastIndexOf', null, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    },
});
singString.method('capitalize', null, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    },
});
singString.method('camelize', null, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    },
});
singString.method('pluralize', null, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    },
});
singString.method('fill', null, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    },
});
singString.method('similarity', null, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    },
});
singString.method('like', null, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    },
});
singString.method('isJSON', null, {
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
//# sourceMappingURL=singularity-js-string.js.map