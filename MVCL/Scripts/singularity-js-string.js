var singString = sing.addModule(new sing.Module("String", String, String.prototype));
singString.requiredDocumentation = false;
/// <reference path="singularity-core.ts"/>
function InitSingularityJS_String() {
    //////////////////////////////////////////////////////
    //
    //
    // String Extensions
    //
    singString.addExt('contains', StringContains, {
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
    singString.addExt('replaceAll', StringReplaceAll, {
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
    singString.addExt('upper', StringUpper, {
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
    singString.addExt('lower', StringLower, {
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
    singString.addExt('collapseSpaces', StringCollapseSpaces, {
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
    singString.addExt('startsWith', StringStartsWith, {
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
    singString.addExt('endsWith', StringEndsWith, {
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
    singString.addExt('removeAll', StringRemoveAll, {
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
    singString.addExt('reverse', StringReverse, {
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
    singString.addExt('repeat', StringRepeat, {
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
    singString.addExt('words', StringWords, {
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
    singString.addExt('lines', StringLines, {
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
    singString.addExt('surround', StringSurround, {
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
    singString.addExt('truncate', StringTruncate, {
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
            return '';
        if (this.length > length)
            return this.substr(0, length).toString();
        return this;
    }
    singString.addExt('toStr', StringToStr, {
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
    singString.addExt('matchCount', StringMatchCount, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    function StringMatchCount(pattern) {
        var match = this.match(pattern);
        if (!match)
            return 0;
        return match.length;
    }
    singString.addExt('hasMatch', StringHasMatch, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    function StringHasMatch(pattern) {
        var match = this.match(pattern);
        if (!match || match.length == 0)
            return false;
        return true;
    }
    singString.addExt('isValidEmail', StringIsValidEmail, {
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
    singString.addExt('isHex', StringIsHex, {
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
    singString.addExt('isValidURL', null, {
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
    singString.addExt('isIPAddress', StringIsIPAddress, {
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
    singString.addExt('isGuid', StringIsGuid, {
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
    singString.addExt('numericValueOf', StringNumericValueOf, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    function StringNumericValueOf() {
        return this.valueOf();
    }
    singString.addExt('textToHTML', StringTextToHTML, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    function StringTextToHTML() {
        return this.replaceAll('\r\n', '\n').replaceAll('\r\n', '<br/>').replaceAll(' ', '&nbsp;');
    }
    singString.addExt('replaceRegExp', StringReplaceRegExp, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    function StringReplaceRegExp(pattern, replace) {
        var out = this;
        var match = out.match(pattern);
        var outBefore = '';
        var count = 0;
        if (match && match.length > 1 && outBefore != out && count < 10) {
            outBefore = out;
            out = out.replace(pattern, replace);
            match = out.match(pattern);
            count++;
        }
        return out;
    }
    singString.addExt('extract', StringExtract, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    function StringExtract(template, obj) {
        var matches = this.match(/\[()\]/);
        /*
        $.objEach(function (key: string, item: any, index: number):any {

            if (template.contains('{' + key + '}')) {
            }
            return null;
        });
        */
    }
    singString.addExt('bbCodesToHTML', StringBBCodesToHTML, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    function StringBBCodesToHTML() {
        var out = this;
        sing.BBCodes.each(function (item, index) {
            out = out.replaceRegExp(item.matchStr, item.htmlStr);
        });
        return out;
    }
    singString.addExt('bbCodesToText', StringBBCodesToText, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    function StringBBCodesToText() {
        var out = this;
        sing.BBCodes.each(function (item, index) {
            out = out.replaceRegExp(item.matchStr, item.textStr);
        });
        return out;
    }
    singString.addExt('escapeRegExp', StringEscapeRegExp, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    function StringEscapeRegExp() {
        var out = this;
        return out;
        out = out.replaceRegExp(/(^|.+)\$/, /\\\$/);
        out = out.replaceRegExp(/(^|.+)\[/, /\\\[/);
        out = out.replaceRegExp(/(^|.+)\]/, /\\\]/);
        out = out.replaceRegExp(/(^|.+)\./, /\\\./);
        out = out.replaceRegExp(/(^|.+)\^/, /\\\^/);
        out = out.replaceRegExp(/(^|.+)\!/, /\\\!/);
        out = out.replaceRegExp(/(^|.+)\?/, /\\\?/);
        out = out.replaceRegExp(/(^|.+)\\/, /\\\\/);
        out = out.replaceRegExp(/(^|.+)\>/, /\\\>/);
        out = out.replaceRegExp(/(^|.+)\</, /\\\</);
        return out;
    }
    singString.addExt('templateInject', StringTemplateInject, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    function StringTemplateInject(obj, itemKey, itemObj) {
        var out = this.toString();
        var match = out.match(sing.templatePattern);
        log(out.toString(), match, sing.templatePattern);
        while (match != null && match.length > 0) {
            var key = match[1];
            var values = [obj].findValues(key);
            if (itemKey != null && itemKey.length > 0 && key.startsWith(itemKey + '.')) {
                values = [itemObj].findValues(key.substr(itemKey.length + 1));
                if (!$.isArray(values))
                    values = [values];
            }
            log(key, values, itemKey, itemObj, (itemKey != null && itemKey.length > 0 && key.startsWith(itemKey + '.')), key.substr(itemKey.length + 1), (values != null && values != undefined));
            if ($.isArray(values) && values.length > 0)
                values = values[0];
            if (values != null && values != undefined) {
                out = out.replace(sing.templateStart + key + sing.templateEnd, values.toString());
            }
            else {
                out = out.replace(sing.templateStart + key + sing.templateEnd, '');
            }
            match = out.match(sing.templatePattern);
        }
        log(out);
        return out;
    }
    singString.addExt('templateExtract', StringTemplateExtract, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    function StringTemplateExtract(template) {
        var src = this;
        var templateValues = [];
        var templateKeys = [];
        while (src.length > 0) {
            if (template.length > 1 && template[0] == '{' && template[1] == '{') {
                var templateValue = '';
                var templateKey = '';
                while (template.length > 0) {
                    if (template[0] == '}' && template.length > 1 && template[1] != '}') {
                        template = template.substr(1);
                        break;
                    }
                    else if (template[0] != '{' && template[0] != '}') {
                        templateKey += template[0];
                    }
                    template = template.substr(1);
                }
                while (src.length > 1 && src[0] != template[0] && src[1] != template[1]) {
                    templateValue += src[0];
                    src = src.substr(1);
                }
                templateValues.push(templateValue);
                templateKeys.push(templateKey);
            }
            src = src.substr(1);
            template = template.substr(1);
        }
        if (templateKeys.length != templateValues.length) {
            throw 'Template did not match.';
        }
        var out = {};
        for (var i = 0; i < templateKeys.length; i++) {
            var key = templateKeys[i];
            if (key.contains('.')) {
                var keyParts = key.split('.');
                var cursor = out;
                for (var j = 0; j < keyParts.length; j++) {
                    if (cursor[keyParts[j]] === undefined) {
                        cursor[keyParts[j]] = j == keyParts.length - 1 ? templateValues[i].tryToNumber() : {};
                    }
                    cursor = cursor[keyParts[j]];
                }
            }
        }
        return out;
    }
    singString.addExt('log', StringLog, {
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
    function StringLog() {
        log(this);
    }
    singString.addExt('tryToNumber', null, {
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
    singString.addExt('joinLines', StringJoinLines, {
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
    singString.addExt('pad', StringPad, {
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
    singString.addExt('isDate', null, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    singString.addExt('isBoolean', null, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    singString.addExt('isNumeric', null, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    singString.addExt('toNumber', null, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    singString.addExt('toBoolean', null, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    singString.addExt('toUrlSlug', null, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    singString.addExt('parse', null, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    singString.addExt('first', null, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    singString.addExt('last', null, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    singString.addExt('containsAny', null, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    singString.addExt('containsAll', null, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    singString.addExt('parseJSON', null, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    singString.addExt('lastIndexOf', null, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    singString.addExt('capitalize', null, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    singString.addExt('camelize', null, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    singString.addExt('stripTags', null, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    singString.addExt('pluralize', null, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    singString.addExt('fill', null, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    singString.addExt('similarity', null, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    singString.addExt('like', null, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    singString.addExt('isJSON', null, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
}
//# sourceMappingURL=singularity-js-string.js.map