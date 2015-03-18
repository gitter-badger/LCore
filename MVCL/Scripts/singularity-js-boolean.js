/// <reference path="singularity-core.ts"/>
function InitSingularityJS_Boolean() {
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //
    // Boolean Extensions
    //
    //
    sing.addBooleanExt('XOR', BooleanXOR, {
        summary: "\
        XOR acts on a boolean to perform the binary XOR function on the passed Boolean",
        parameters: [
            {
                name: 'b',
                types: [Boolean],
                required: true,
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
            ext.addFailsTest(false, ['a'], 'Boolean.XOR  Parameter: b: \'a\' string did not match input type [\'boolean\'].');
        }
    });
    function BooleanXOR(b) {
        var a = this.valueOf();
        return (a == true && b == false) || (a == false && b == true);
    }
    sing.addBooleanExt('XNOR', BooleanXNOR, {
        summary: "\
        XNOR acts on a boolean to perform the binary XNOR function on the passed Boolean, the inverse of the XOR function",
        parameters: [
            {
                name: 'b',
                types: [Boolean],
                required: true,
                description: 'The value of the Boolean to XNOR with the calling Boolean.'
            }
        ],
        returns: '\
        The Boolean calling the XNOR method XNORed with the passed Boolean \r\n\
        false XNOR false = true \r\n\
        false XNOR true = false \r\n\
        true XNOR false = false \r\n\
        true XNOR true = true',
        returnType: Boolean,
        examples: ['\
        var test = false; \r\n\
        var test2 = true; \r\n\
                             \r\n\
        var out = test.XNOR(test2)       // out == false \r\n\
        var out2 = test2.XNOR(test2)     // out == true \r\n\
        var out3 = (true).XNOR(false)    // out == false'],
        tests: function (ext) {
            ext.addTest(false, [false], true);
            ext.addTest(false, [true], false);
            ext.addTest(true, [false], false);
            ext.addTest(true, [true], true);
            ext.addFailsTest(true, [null], 'Boolean.XNOR Missing Parameter: Boolean b');
            ext.addFailsTest(true, [undefined], 'Boolean.XNOR Missing Parameter: Boolean b');
            ext.addFailsTest(false, [null], 'Boolean.XNOR Missing Parameter: Boolean b');
            ext.addFailsTest(false, [undefined], 'Boolean.XNOR Missing Parameter: Boolean b');
            ext.addFailsTest(false, ['a']);
        }
    });
    function BooleanXNOR(b) {
        return !this.XOR(b);
    }
    sing.addBooleanExt('OR', BooleanOR, {
        summary: "\
        OR acts on a boolean to perform the binary OR function on the passed Booleans",
        parameters: [
            {
                name: 'b',
                types: [Boolean],
                isMulti: true,
                description: 'The values of the Boolean to OR with the calling Boolean.'
            }
        ],
        returns: '\
        The Boolean calling the OR method ORed with the passed Booleans \r\n\
        false OR false = false \r\n\
        false OR true = true \r\n\
        true OR false = true \r\n\
        true OR true = true',
        returnType: Boolean,
        examples: ['\
        var test = false; \r\n\
        var test2 = true; \r\n\
                             \r\n\
        var out = test.OR(test2)       // out == true \r\n\
        var out2 = test2.OR(test2)     // out == true \r\n\
        var out3 = (true).OR(false)    // out == true'],
        tests: function (ext) {
            ext.addTest(false, [false], false);
            ext.addTest(false, [true], true);
            ext.addTest(true, [], true);
            ext.addTest(true, [false], true);
            ext.addTest(true, [true], true);
            ext.addTest(false, [], false);
            ext.addTest(false, [false], false);
            ext.addTest(false, [false, false, false, false, false], false);
            ext.addTest(true, [false, false, false, false, false], true);
            ext.addTest(false, [true, false, false, false, false], true);
            ext.addTest(false, [false, false, false, false, true], true);
        }
    });
    function BooleanOR() {
        var b = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            b[_i - 0] = arguments[_i];
        }
        return this == true || b.contains(true);
    }
    sing.addBooleanExt('AND', BooleanAND, {
        summary: "\
        AND acts on a boolean to perform the binary AND function on the passed Booleans",
        parameters: [
            {
                name: 'b',
                types: [Boolean],
                isMulti: true,
                description: 'The values of the Boolean to AND with the calling Boolean.'
            }
        ],
        returns: '\
        The Boolean calling the AND method ANDed with the passed Booleans \r\n\
        false AND false = false \r\n\
        false AND true = false \r\n\
        true AND false = false \r\n\
        true AND true = true',
        returnType: Boolean,
        examples: ['\
        var test = false; \r\n\
        var test2 = true; \r\n\
                             \r\n\
        var out = test.AND(test2)       // out == false \r\n\
        var out2 = test2.AND(test2)     // out == true \r\n\
        var out3 = (true).AND(false)    // out == false'],
        tests: function (ext) {
            ext.addTest(false, [], false);
            ext.addTest(false, [false], false);
            ext.addTest(false, [true], false);
            ext.addTest(true, [], true);
            ext.addTest(true, [false], false);
            ext.addTest(true, [true], true);
            ext.addTest(false, [false, false, false], false);
            ext.addTest(false, [true, true, true], false);
            ext.addTest(true, [false, false, false], false);
            ext.addTest(true, [true, false, false], false);
            ext.addTest(true, [true, true, false], false);
            ext.addTest(true, [true, true, true], true);
        }
    });
    function BooleanAND() {
        var b = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            b[_i - 0] = arguments[_i];
        }
        return this == true && !b.contains(false);
    }
    sing.addBooleanExt('NAND', BooleanNAND, {
        summary: "\
        NAND acts on a boolean to perform the binary NAND function on the passed Booleans",
        parameters: [
            {
                name: 'b',
                types: [Boolean],
                isMulti: true,
                description: 'The values of the Boolean to NAND with the calling Boolean.'
            }
        ],
        returns: '\
        The Boolean calling the NAND method NANDed with the passed Booleans \r\n\
        false NAND false = true \r\n\
        false NAND true = true \r\n\
        true NAND false = true \r\n\
        true NAND true = false',
        returnType: Boolean,
        examples: ['\
        var test = false; \r\n\
        var test2 = true; \r\n\
                             \r\n\
        var out = test.NAND(test2)       // out == true \r\n\
        var out2 = test2.NAND(test2)     // out == false \r\n\
        var out3 = (true).NAND(false)    // out == true'],
        tests: function (ext) {
            ext.addTest(false, [false], true);
            ext.addTest(false, [true], true);
            ext.addTest(true, [false], true);
            ext.addTest(true, [true], false);
            ext.addTest(false, [false, false, false], true);
            ext.addTest(false, [true, true, true], true);
            ext.addTest(true, [false, false, false], true);
            ext.addTest(true, [true, false, false], true);
            ext.addTest(true, [true, true, false], true);
            ext.addTest(true, [true, true, true], false);
        }
    });
    function BooleanNAND() {
        var b = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            b[_i - 0] = arguments[_i];
        }
        if (b.length == 0)
            return this;
        return !this.AND.apply(this, b);
    }
    sing.addBooleanExt('NOR', BooleanNOR, {
        summary: "\
        NOR acts on a boolean to perform the binary NOR function on the passed Booleans",
        parameters: [
            {
                name: 'b',
                types: [Boolean],
                isMulti: true,
                description: 'The values of the Boolean to NOR with the calling Boolean.'
            }
        ],
        returns: '\
        The Boolean calling the NOR method NORed with the passed Booleans \r\n\
        false NOR false = true \r\n\
        false NOR true = false \r\n\
        true NOR false = false \r\n\
        true NOR true = false',
        returnType: Boolean,
        examples: ['\
        var test = false; \r\n\
        var test2 = true; \r\n\
                             \r\n\
        var out = test.NOR(test2)       // out == false \r\n\
        var out2 = test2.NOR(test2)     // out == false \r\n\
        var out3 = (true).NOR(false)    // out == false'],
        tests: function (ext) {
            ext.addTest(false, [], true);
            ext.addTest(false, [false], true);
            ext.addTest(false, [true], false);
            ext.addTest(true, [], false);
            ext.addTest(true, [false], false);
            ext.addTest(true, [true], false);
            ext.addTest(false, [false, false, false], true);
            ext.addTest(false, [true, true, true], false);
            ext.addTest(true, [false, false, false], false);
            ext.addTest(true, [true, false, false], false);
            ext.addTest(true, [true, true, false], false);
            ext.addTest(true, [true, true, true], false);
        }
    });
    function BooleanNOR() {
        var b = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            b[_i - 0] = arguments[_i];
        }
        return !this.OR.apply(this, b);
    }
    //
    //////////////////////////////////////////////////////
    //
    sing.addBooleanExt('toStr', BooleanToStr, {
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
    });
    function BooleanToStr(includeMarkup) {
        if (includeMarkup === void 0) { includeMarkup = false; }
        if (includeMarkup == false)
            return this.toYesNo();
        return this == false ? "false" : "true";
    }
    sing.addBooleanExt('toYesNo', BooleanToYesNo, {
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
    function BooleanToYesNo() {
        return this == false ? "No" : "Yes";
    }
    //
    //
}
//# sourceMappingURL=singularity-js-boolean.js.map