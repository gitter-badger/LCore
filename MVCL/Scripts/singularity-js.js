
function InitSingularityJS() {

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //
    //
    // JavaScript Extensions /////////////////////////////
    //
    //

    // Initialize functions first so that other extensions can utilize them automatically
    InitSingularityJS_Function();

    InitSingularityJS_Array();

    InitSingularityJS_Boolean();
    InitSingularityJS_Number();
    InitSingularityJS_String();
    InitSingularityJS_Date();

}

function InitSingularityJS_Boolean() {
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //
    // Boolean Extensions
    //
    //

    sing.addBooleanExt('XOR', BooleanXOR,
    {
        summary: "\
        XOR acts on a boolean to perform the binary XOR command on the passed Boolean",
        parameters: [
            {
                name: 'b',
                types: [Boolean],
                description: 'The value of the Boolean to XOR with the calling Boolean.'
            }
        ],
        returns: '\
        The Boolean calling the XOR method XORed with the passed Boolean \r\n\
        false XOR false = false \r\n\
        false XOR true = true \r\n\
        true XOR false = true \r\n\
        true XOR true = false',
        returnType: Boolean,
        examples: ['\
        var test = false; \r\n\
        var test2 = true; \r\n\
                             \r\n\
        var out = test.XOR(test2)       // out == true \r\n\
        var out2 = test2.XOR(test2)     // out == false \r\n\
        var out3 = (true).XOR(false)    // out == true'],
        tests: function (ext) {

            ext.addTest(false, [false], false);
            ext.addTest(false, [true], true);
            ext.addTest(true, [false], true);
            ext.addTest(true, [true], false);

            ext.addFailsTest(true, [null], 'Boolean.XOR Missing Parameter: Boolean b');
            ext.addFailsTest(true, [undefined], 'Boolean.XOR Missing Parameter: Boolean b');
            ext.addFailsTest(false, [null], 'Boolean.XOR Missing Parameter: Boolean b');
            ext.addFailsTest(false, [undefined], 'Boolean.XOR Missing Parameter: Boolean b');
            ext.addFailsTest(false, ['a'], 'Boolean.XOR Missing Parameter: Boolean b');
        }
    });

    function BooleanXOR(b) {
        var a = this.valueOf();

        return (a == true && b == false) ||
            (a == false && b == true);
    }

    sing.addBooleanExt('XNOR', null);

    function BooleanXNOR(b) {

    }

    sing.addBooleanExt('OR', null);

    function BooleanOR(b) {

    }

    sing.addBooleanExt('AND', null);

    function BooleanAND(b) {

    }

    sing.addBooleanExt('NAND', null);

    function BooleanNAND(b) {

    }

    sing.addBooleanExt('NOR', null);

    function BooleanNOR(b) {

    }

    //
    //////////////////////////////////////////////////////
    //

    sing.addBooleanExt('toYesNo', BooleanToYesNo,
    {
        summary: "\
        toYesNo converts a Boolean to a string of 'Yes' or 'No'",
        parameters: [],
        returns: "\
        A string of 'Yes' or 'No'",
        returnType: String,
        examples: ["\
        var test = false; \r\n\
        var test2 = true; \r\n\
                             \r\n\
        var out = test.toYesNo()       // out == 'Yes' \r\n\
        var out2 = test2.toYesNo()     // out == 'No'"],
        tests: function (ext) {
            ext.addTest(true, [], 'Yes');
            ext.addTest(false, [], 'No');
        }
    });

    function BooleanToYesNo(b) {
        return this == false ? "No" : "Yes";
    }

    //
    //
}

function InitSingularityJS_Number() {
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //
    // Number Extensions
    //

    sing.addNumberExt('toStr', NumberToStr,
    {
        summary: "\
        toStr is a standardized way of converting Objects to Strings.",
        parameters: [],
        returns: 'A string representation of the Number toStr is called on.',
        returnType: String,
        examples: ["\
        var test = 1; \r\n\
        var test2 = 2.5; \r\n\
                             \r\n\
        var out = test.toStr()       // out == '1' \r\n\
        var out2 = test2.toStr()     // out == '2.5' \r\n\
        "],
        tests: function (ext) {
            ext.addTest(0, [], '0');
            ext.addTest(5, [], '5');
            ext.addTest(-100.105, [], '-100.105',
                'Decimal numbers are supported.');
            ext.addTest(-100.100, [], '-100.1',
                'Trailing 0s are not included.');
            ext.addTest(5.5, [], '5.5');
        },
    });

    function NumberToStr() {
        return this;
    }


    sing.addNumberExt('max', NumberMax,
    {
        summary: 'Compares multiple Numbers to find the largest.',
        parameters: [
            {
                name: 'Arguments',
                types: [Object],
                optional: true,
                description: 'pass multiple arguments to compare them all to find the largest'
            }
        ],
        returns: 'The largest Number of all arguments and the calling Number',
        returnType: Number,
        examples: ['\
            (1).max(2);              // = 2 \r\n\
            (1).max(2,3,4,5);        // = 5 \r\n\
            (1.00025).max(1.00026);  // = 1.00026 \r\n\
            '],
        tests: function (ext) {

            ext.addTest(100, [200], 200);
            ext.addTest(0, [1, 2, 3, 4, 5], 5);
            ext.addTest(10, [1, 2, 3, 4, 5], 10);
            ext.addTest(4.26354, [4.26355], 4.26355);

            ext.addTest(100, [], 100);
            ext.addTest(100, [null], 100);
            ext.addTest(100, [undefined], 100);
        },
    });

    function NumberMax() {
        if (arguments == null || arguments == undefined)
            return this;

        var args = $.objValues(arguments).collect();

        args.push(this.valueOf());

        return Math.max.apply(null, args);
    }

    sing.addNumberExt('round', NumberRound,
    {
        summary: 'Rounds the calling Number to the nearest whole Number. If a number of decimal places is supplied they will be included',
        parameters: [
            {
                name: 'decimalPlaces',
                types: [Number],
                optional: true,
                description: 'Specify how many decimal places the output should have',
                defaultValue: 0,
            }
        ],
        returns: 'A number rounded to the supplied number of decimal places',
        returnType: Number,
        examples: ['\
            (1.6).round();                     //  == 2  \r\n\
            (1.6555).round(2);                 //  == 1.66  \r\n\
            (1.644999999999999).round(2);      //  == 1.64  '],
        tests: function (ext) {

            ext.addTest(1.6, [], 2);
            ext.addTest(1.5, [], 2);
            ext.addTest(1.499999999999999, [], 1);
            ext.addTest(1.00001, [], 1);
            ext.addTest(1.6555, [2], 1.66);
            ext.addTest(1.644999999999999, [2], 1.64);

            ext.addTest(1.644999999999999, [null], 2);
            ext.addTest(1.644999999999999, [undefined], 2);
        },
    });

    function NumberRound(decimalPlaces) {
        if (!this)
            return null;

        if (decimalPlaces > 0)
            return Math.round(this * ((10).pow(decimalPlaces))) / ((10).pow(decimalPlaces));

        return Math.round(this);
    }

    sing.addNumberExt('pow', NumberPower,
    {
        summary: 'Returns the calling number raised to the power passed. \r\n\
            Decimal numbers are supported and can be used for calculating fractional powers and roots.',
        parameters: [
            {
                name: 'power',
                types: [Number],
                description: 'The power to raise the calling number to',
            }
        ],
        returns: 'Returns the calling number raised to the power passed.',
        returnType: Number,
        examples: ['\r\n\
            (2).pow(2);   // == 4 \r\n\
            (4).pow(2);   // == 16 \r\n\
            (4).pow(1/2);   // == 2 \r\n\
            (2).pow(1/2);   // == 1.4142135623730951 \r\n\
            '],
        tests: function (ext) {

            ext.addTest(2, [2], 4)
            ext.addTest(4, [2], 16)
            ext.addTest(4, [1 / 2], 2)
            ext.addTest(2, [1 / 2], 1.4142135623730951)


            ext.addFailsTest(2, [null], 'Number.pow Missing Parameter: Number power')
            ext.addFailsTest(2, [undefined], 'Number.pow Missing Parameter: Number power')
        },
    });

    function NumberPower(power) {
        return Math.pow(this, power);
    }


    sing.addNumberExt('timesDo', NumberTimesDo,
    {
        summary: "Repeats a function a number of times",
        parameters: [
            {
                name: 'executeFunc',
                types: [Function],
                desription: 'The function to execute',
            },
            {
                name: 'args',
                types: [Array],
                optional: true,
                defaultValue: [],
                desription: '',
            },
            {
                name: 'caller',
                types: [Object],
                optional: true,
                desription: '',
            },
        ],
        returns: '',
        returnType: Object,
        examples: null,
        tests: function (ext) {
            /* TODO: FIX timesDo is causing a stack overflow

            ext.addCustomTest(function () {
                var test = 0;
                (5).timesDo(function () { test++; });

                if (test != 5)
                    return false;
            }, 'Must execute the function the correct number of times.');
            
            ext.addTest(1, [null], undefined, 'Passing a null function does nothing.');
            ext.addTest(1, [undefined], undefined, 'Passing an undefined function does nothing.');

            */
            ext.addTest(5, [sing.func.increment, [5]], [6, 6, 6, 6, 6]);
        },
    });

    function NumberTimesDo(executeFunc, args, caller) {

        if (!this || this <= 0 || !executeFunc)
            return;

        caller = caller || this;

        var out = [];

        for (var i = 0; i < this; i++) {
            if (!this)
                return;

            var result = executeFunc.apply(caller, args);

            if (result != null &&
                result != undefined)
                out.push(result);
        }

        return out;
    }

    sing.addNumberExt('ceil', NumberCeiling,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

    function NumberCeiling(decimalPlaces) {
        if (!this)
            return null;

        if (decimalPlaces > 0)
            return Math.ceil(this * ((10).pow(decimalPlaces))) / ((10).pow(decimalPlaces));

        return Math.ceil(this);
    }

    sing.addNumberExt('floor', NumberFloor,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

    function NumberFloor(decimalPlaces) {
        if (!this)
            return null;

        if (decimalPlaces > 0)
            return Math.floor(this * ((10).pow(decimalPlaces))) / ((10).pow(decimalPlaces));

        return Math.floor(this);
    }

    sing.addNumberExt('formatFileSize', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

    sing.addNumberExt('percentOf', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

    sing.addNumberExt('abs', null,
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

            sing.addFailsTest(ext.name,
                function () {
                    'apples apples'.replaceAll('s', 'pies');
                }, StringReplaceAll_ErrorReplacementContinsSearch);

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

    var StringReplaceAll_ErrorReplacementContinsSearch = 'Replace All Error: replacement must not contain search term'
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

    sing.addStringExt('trim', StringTrim,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

    function StringTrim() {
        return this.replace(/^\s+|\s+$/g, "");
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

    function StringToStr(includeQuotes) {
        if (includeQuotes)
            return "'" + this + "'";

        return this;
    }

    //
    //////////////////////////////////////////////////////
    //
    // String Array functions

    sing.addArrayExt('join', StringJoin,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: String,
        examples: null,
        tests: function (ext) {
        },
    });

    function StringJoin(separator) {
        if (!this)
            return '';

        separator = separator || ', ';

        var out = '';
        this.each(function (item, i) {
            out += item
            if (i < this.length - 1)
                out += separator;
        });

        return out;
    }

    //
    //////////////////////////////////////////////////////
    //

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

            // Test pad > length
            // Test Nulls
        },
    });

    function StringPad(length, align, whitespace) {

        whitespace = whitespace || ' ';
        align = align || 'left';

        if (!this)
            return whitespace.repeat(length);

        var out = this;
        var whitespaceIndex = 0;

        while (out.length < length) {

            if (align == 'left' || align == 'l')
                out += whitespace[whitespaceIndex];
            else if (align == 'right' || align == 'r')
                out = whitespace[whitespaceIndex] + out;
            else if (align == 'center' || align == 'c')
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
    sing.addStringExt('toInt', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    sing.addStringExt('toFloat', null,
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
    sing.addStringExt('isValidEmail', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
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
    sing.addStringExt('isGuid', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
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
    sing.addStringExt('formatfilesize', null,
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

function InitSingularityJS_Date() {
    //////////////////////////////////////////////////////
    //
    //
    // Date Extensions
    //

    sing.addDateExt('add', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    sing.addDateExt('subtract', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    sing.addDateExt('compare', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    sing.addDateExt('isBefore', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    sing.addDateExt('isAfter', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    sing.addDateExt('equals', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
}

function InitSingularityJS_Array() {
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //
    // Array Extensions
    //
    //
    // Iteration Functions

    sing.addArrayExt('each', ArrayEach,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

    function ArrayEach(action) {
        if (!this || !action)
            return;

        this.while(function (item, i) {
            action(item, i);

            // each always continues until the end
            return true;
        });
    }

    //
    //////////////////////////////////////////////////////
    //

    sing.addArrayExt('while', ArrayWhile,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

    function ArrayWhile(action) {
        if (!this || !action)
            return true;

        var exit = false;

        for (var i = 0 ; i < this.length; i++) {
            var result = action(this[i], i);

            if (result == false)
                exit = true;

            if (exit)
                break;
        }

        return !exit;
    }

    //
    //////////////////////////////////////////////////////
    //

    sing.addArrayExt('until', ArrayUntil,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

    function ArrayUntil(action) {
        if (!this || !action)
            return true;

        return this.while(function (item, i) {
            var result = action(item, i);

            return (result !== null && result !== undefined && result !== false);
        });
    }

    //
    //////////////////////////////////////////////////////
    //
    // Lookup Functions

    sing.addArrayExt('count', ArrayCount,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

    function ArrayCount(action) {
        if (!this || !action)
            return 0;

        var out = 0;
        this.each(function (item, i) {
            var result = action(item, i);

            if (result != null &&
                result != undefined &&
                result != false) {
                out++;
            }
        });
        return out;
    }

    //
    //////////////////////////////////////////////////////
    //

    sing.addArrayExt('contains', ArrayContains,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        aliases: ['has'],
        tests: function (ext) {
        },
    });

    function ArrayContains(itemOrItemsOrFunction) {
        if (!this ||
            itemOrItemsOrFunction == null ||
            itemOrItemsOrFunction == undefined)
            return false;

        if ($.isArray(itemOrItemsOrFunction)) {

            return itemOrItemsOrFunction.contains(function (it, i) {
                if (this.contains(it))
                    return true;
            });

        }


        if ($.isFunction(itemOrItemsOrFunction)) {
            return !!this.first(itemOrItemsOrFunction);
        }

        return this.indexOf(itemOrItemsOrFunction) >= 0;
    }

    //
    //////////////////////////////////////////////////////
    //

    sing.addArrayExt('select', ArraySelect,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        aliases: ['where'],
        tests: function (ext) {
        },
    });

    function ArraySelect(action) {
        if (!this || !action)
            return [];

        var out = [];
        this.each(function (item, i) {
            var result = action(item, i);

            if (result != null &&
                result != undefined)
                out = out.concat(item);
        });
        return out;
    }

    //
    //////////////////////////////////////////////////////
    //

    sing.addArrayExt('every', ArrayEvery,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

    function ArrayEvery(itemOrFunction) {
        if (!this || !itemOrFunction)
            return false;

        if ($.isFunction(itemOrFunction)) {
            return this.while(function (item, i) {
                var result = itemOrFunction(item, i);

                return (result != null &&
                    result != undefined &&
                    result != false);
            });
        }
        else {
            return this.length > 0 &&
                this.count(itemOrFunction) == this.length;
        }
    }

    //
    //////////////////////////////////////////////////////
    //
    // Mapping Functions

    sing.addArrayExt('collect', ArrayCollect,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

    function ArrayCollect(action) {
        if (!this)
            return [];

        if (action == null ||
            action == undefined)
            action = sing.func.identity;

        var out = [];
        this.each(function (item, i) {
            var result = action(item, i);

            if (result !== null &&
                result !== undefined)
                out = out.concat(result);
        });
        return out;
    }

    //
    //////////////////////////////////////////////////////
    //

    sing.addArrayExt('first', ArrayFirst,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

    function ArrayFirst(itemOrAction) {
        if (!this)
            return;

        if (!itemOrAction && this.length > 0)
            return this[0];

        if (!itemOrAction)
            return;

        if (!$.isFunction(itemOrAction))
            itemOrAction = function (item, i) { return item == itemOrAction; };

        var out = undefined;

        this.while(function (item, i) {
            var result = itemOrAction(item, i);

            if (result == true) {
                out = result;
                return false;
            }
        });
        return out;
    }

    //
    //////////////////////////////////////////////////////
    //

    sing.addArrayExt('last', ArrayLast,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

    function ArrayLast(action) {
        if (!this)
            return;

        if (!action && this.length > 0)
            return this[this.length - 1];

        if (!action)
            return;

        return this.reverse.first(action);
    }

    //
    //////////////////////////////////////////////////////
    //

    sing.addArrayExt('range', ArrayRange,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

    function ArrayRange(start, end) {
        if (!this || start > end)
            return [];

        var out = [];
        for (var i = start; i < end; i++) {
            out = out.concat(this[i]);
        }
        return out;
    }

    //
    //////////////////////////////////////////////////////
    //

    sing.addArrayExt('flatten', ArrayFlatten,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

    function ArrayFlatten() {
        if (!this)
            return [];

        var out = [];

        this.each(function (item, i) {
            if ($.isArray(item))
                out.concat(item.flatten());
            else
                out.concat(item);
        });

        return out;
    }

    //
    //////////////////////////////////////////////////////
    //

    sing.addArrayExt('indices', ArrayIndices,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        aliases: ['indexes'],
        tests: function (ext) {
            sing.addAssertTest(ext.name, ['a'].indices('a'), [0]);
            sing.addAssertTest(ext.name, ['a'].indices(['b']), []);
            sing.addAssertTest(ext.name, ['a'].indices(['']), []);
            sing.addAssertTest(ext.name, ['a'].indices([undefined]), []);
            sing.addAssertTest(ext.name, ['a'].indices([null]), []);
            sing.addAssertTest(ext.name, ['a'].indices(null), []);
            sing.addAssertTest(ext.name, ['a', 'b'].indices(['a', 'b']), [0, 1]);

            sing.addAssertTest(ext.name, ['a', 'a', 'a', 'b', 'b', 'b'].indices(['a', 'b']), [0, 1, 2, 3, 4, 5]);
        },
    });

    function ArrayIndices(itemOrItemsOrFunction) {
        if (!this ||
            itemOrItemsOrFunction == null ||
            itemOrItemsOrFunction == undefined)
            return [];

        var src = this;

        if ($.isArray(itemOrItemsOrFunction)) {
            return src.collect(function (item, i) {
                if (itemOrItemsOrFunction.contains(item))
                    return i;
            });
        }

        if ($.isFunction(itemOrItemsOrFunction)) {
            return src.collect(function (item, i) {
                if (!!itemOrItemsOrFunction(item, i))
                    return i;
            });
        }

        var index = src.indexOf(itemOrItemsOrFunction);

        if (index >= 0)
            return [index];
        else
            return [];
    }

    //
    //////////////////////////////////////////////////////
    //

    sing.addArrayExt('log', ArrayLog,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

    function ArrayLog(itemOrItemsOrFunction) {
        log(this);
    }

    //
    //////////////////////////////////////////////////////
    //

    sing.addArrayExt('toStr', ArrayToStr,
    {
        summary: null,
        parameters: null,
        returns: String,
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

    function ArrayToStr(includeMarkup) {
        var out = '[';
        var src = this;

        this.each(function (item, i) {
            if (item === null)
                out += 'null';
            else if (item === undefined)
                out += 'undefined';
            else if ($.isString(item))
                out += '\'' + item + '\'';
            else if (item.toStr)
                out += '\'' + item.toStr(includeMarkup) + '\'';  // includeMarkup is passed to child elements

            if (i < src.length - 1)
                out += ', ';
        });

        out += ']';

        return out;
    }

    //
    //////////////////////////////////////////////////////
    //

    sing.addArrayExt('remove', ArrayRemove,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

    function ArrayRemove(itemOrItemsOrFunction) {

        var src = this;

        if (!itemOrItemsOrFunction)
            return src;

        if ($.isArray(itemOrItemsOrFunction)) {
            return src.select(function (item, i) {
                return !itemOrItemsOrFunction.contains(item);
            });
        }

        if ($.isFunction(itemOrItemsOrFunction)) {
            return src.select(itemOrItemsOrFunction.not());
        }

        return src.select(function (item, i) {
            return item == itemOrItemsOrFunction;
        });
    }

    //
    //////////////////////////////////////////////////////
    //

    sing.addArrayExt('splitAt', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    sing.addArrayExt('sort', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        aliases: ['order'],
        tests: function (ext) {
        },
    });
    sing.addArrayExt('exfiltrate', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    sing.addArrayExt('removeAt', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    sing.addArrayExt('unique', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    sing.addArrayExt('random', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    sing.addArrayExt('shuffle', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    sing.addArrayExt('fill', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    sing.addArrayExt('index', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    sing.addArrayExt('group', null,
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

function InitSingularityJS_Function() {
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //
    // Function Extensions
    //

    sing.addFunctionExt('fn_try', FunctionTry,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        tests: function (ext) {
        },
    });

    function FunctionTry(logFailure) {
        var source = this;
        // Redirects to catch with no catchFunction
        return source.fn_catch();
    }

    //
    //////////////////////////////////////////////////////
    //

    sing.addFunctionExt('fn_catch', FunctionCatch,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        tests: function (ext) {
        },
    });

    function FunctionCatch(catchFunction, logFailure) {
        var source = this;

        return function () {
            var result;

            try {
                result = source.apply(this.prototype, arguments);
            }
            catch (ex) {
                if (logFailure) {
                    log(['FAILED', source.name, ex]);
                    log([arguments]);
                }

                if (catchFunction)
                    return catchFunction.apply(this.prototype, [ex].concat(arguments));
            }

            return result;
        };
    }

    //
    //////////////////////////////////////////////////////
    //

    sing.addFunctionExt('fn_log', FunctionLog,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        tests: function (ext) {
        },
    });

    function FunctionLog(logAttempt, logSuccess, logFailure) {
        logAttempt = logAttempt != false ? true : false;
        logSuccess = logSuccess != false ? true : false;
        logFailure = logFailure != false ? true : false;

        var source = this;

        return (function () {
            if (logAttempt) {
                log(['Attempting: ', source.name, arguments, result]);
            }

            var result = source.apply(this.prototype, arguments);

            if (logSuccess) {
                log(['Completed: ' + source.name, arguments, result]);
            }

            return result;
        }).fn_catch(function (ex) {
            if (logFailure) {
                log(['FAILED', source.name, ex]);
                log([arguments]);
            }

            throw ex;
        });
    }

    //
    //////////////////////////////////////////////////////
    //

    sing.addFunctionExt('fn_count', FunctionCount,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        tests: function (ext) {
        },
    });

    function FunctionCount(logFailure) {
        var source = this;
        var functionCallCount = 0;

        return (function () {
            var result = source.apply(this.prototype, arguments);

            log([source.name, 'count:' + functionCallCount]);
            log([arguments, result]);

            return result;
        }).catch(function (ex) {
            if (logFailure) {
                log(['FAILED', source.name, ex, 'count:' + functionCallCount]);
                log([arguments]);
            }

            throw ex;
        });
    }

    //
    //////////////////////////////////////////////////////
    //

    sing.addFunctionExt('fn_cache', FunctionCache,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        tests: function (ext) {
        },
    });

    function FunctionCache(uniqueCacheID, expiresAfter) {
        var source = this;

        uniqueCacheID = uniqueCacheID || this.name;

        if (!uniqueCacheID)
            throw 'Unique ID not found'

        var ext = sing.extensions['Function.fn_cache'];
        if (!ext.data)
            ext.data = {
            };

        if (!ext.data.cache)
            ext.data.cache = {
            };

        cache = ext.data.cache;

        return function () {

            var cache = sing.extensions['Function.fn_cache'].data.cache;

            if (!cache[uniqueCacheID])
                cache[uniqueCacheID] = {};

            var thisCache = cache[uniqueCacheID];

            var argStr = $.toStr($.objValues(arguments));

            if (thisCache[argStr] != undefined &&
                thisCache[argStr] != null) {

                if (thisCache[argStr].expires < (new Date()).valueOf()) {
                    // Expired
                    thisCache[argStr] = {};
                }
                else {
                    return thisCache[argStr].value;
                }
            }
            else {
                thisCache[argStr] = {};
            }

            var result = thisCache[argStr].value = source.apply(this.prototype, arguments);

            if (expiresAfter > 0) {
                thisCache[argStr].expires = (new Date()).valueOf() + expiresAfter;
            }

            return result;
        }
    }

    //
    //////////////////////////////////////////////////////
    //


    sing.addFunctionExt('fn_trace', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        tests: function (ext) {
        },
    });

    function FunctionTrace() {
    }

    sing.addFunctionExt('fn_if', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        tests: function (ext) {
        },
    });

    sing.addFunctionExt('fn_unless', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        tests: function (ext) {
        },
    });

    sing.addFunctionExt('fn_ifElse', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        tests: function (ext) {
        },
    });

    sing.addFunctionExt('fn_then', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        tests: function (ext) {
        },
    });

    sing.addFunctionExt('fn_repeat', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        tests: function (ext) {
        },
    });

    sing.addFunctionExt('fn_while', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        tests: function (ext) {
        },
    });

    sing.addFunctionExt('fn_repeatEvery', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        tests: function (ext) {
        },
    });

    sing.addFunctionExt('fn_retry', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        tests: function (ext) {
        },
    });

    sing.addFunctionExt('fn_time', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        tests: function (ext) {
        },
    });
    sing.addFunctionExt('fn_defer', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        tests: function (ext) {
        },
    });
    sing.addFunctionExt('fn_delay', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        tests: function (ext) {
        },
    });
    sing.addFunctionExt('fn_async', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        tests: function (ext) {
        },
    });

    sing.addFunctionExt('fn_wrap', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        tests: function (ext) {
        },
    });

    sing.addFunctionExt('fn_onExecute', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        tests: function (ext) {
        },
    });
    sing.addFunctionExt('fn_onExecuted', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        tests: function (ext) {
        },
    });
    sing.addFunctionExt('fn_supply', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        tests: function (ext) {
        },
    });

    //
    //////////////////////////////////////////////////////
    //
    // Object Extensions
    //
    /*
    sing.addObjectExt('isFunction', IsFunction,
    {
        summary: null,
        parameters: null,
        returns: '',
        examples: null,
        tests: function (ext) {
        },
    });
    
    function IsFunction() {
        return !!(this && this.constructor && this.call && this.apply);
    }
    */


}