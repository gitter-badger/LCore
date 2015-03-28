/// <reference path="singularity-core.ts"/>
var singBoolean = singExt.addModule(new sing.Module("Boolean", Boolean));
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Boolean Extensions
//
//
singBoolean.method('XOR', BooleanXOR, {
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
        ext.addFailsTest(true, [null], 'Singularity.Extensions.Boolean.XOR Missing Parameter: boolean b');
        ext.addFailsTest(true, [undefined], 'Singularity.Extensions.Boolean.XOR Missing Parameter: boolean b');
        ext.addFailsTest(false, [null], 'Singularity.Extensions.Boolean.XOR Missing Parameter: boolean b');
        ext.addFailsTest(false, [undefined], 'Singularity.Extensions.Boolean.XOR Missing Parameter: boolean b');
        ext.addFailsTest(false, ['a'], 'Singularity.Extensions.Boolean.XOR  Parameter: b: \'a\' string did not match input type [\'boolean\'].');
    }
});
function BooleanXOR(b) {
    var a = this.valueOf();
    return (a == true && b == false) || (a == false && b == true);
}
singBoolean.method('XNOR', BooleanXNOR, {
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
        ext.addFailsTest(true, [null], 'Singularity.Extensions.Boolean.XNOR Missing Parameter: boolean b');
        ext.addFailsTest(true, [undefined], 'Singularity.Extensions.Boolean.XNOR Missing Parameter: boolean b');
        ext.addFailsTest(false, [null], 'Singularity.Extensions.Boolean.XNOR Missing Parameter: boolean b');
        ext.addFailsTest(false, [undefined], 'Singularity.Extensions.Boolean.XNOR Missing Parameter: boolean b');
        ext.addFailsTest(false, ['a']);
    }
});
function BooleanXNOR(b) {
    return !this.XOR(b);
}
singBoolean.method('OR', BooleanOR, {
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
    return this == true || b.has(true);
}
singBoolean.method('AND', BooleanAND, {
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
    return this == true && !b.has(false);
}
singBoolean.method('NAND', BooleanNAND, {
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
singBoolean.method('NOR', BooleanNOR, {
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
singBoolean.method('toYesNo', BooleanToYesNo, {
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
singBoolean.method('unary', BooleanUnary, {
    summary: 'Performs the unary operation using the calling boolean.',
    parameters: [
        {
            name: 'obj',
            types: [Object],
            description: 'The first object, returned if the caller is true',
        },
        {
            name: 'obj2',
            types: [Object],
            description: 'The second object, returned if the caller is false',
        }
    ],
    returns: 'Returns the first argument if the calling boolean is true, otherwise the second argument is returned.',
    returnType: Object,
    examples: ['(true).unary(1,2)   // == 1'],
    tests: function (ext) {
        ext.addTest(true, ['a', 'b'], 'a');
        ext.addTest(false, ['a', 'b'], 'b');
    },
}, String.prototype);
function BooleanUnary(obj, obj2) {
    return this.valueOf() ? obj : obj2;
}
singBoolean.method('isBoolean', StringIsBoolean, {
    summary: 'Determines if the calling string is a Boolean format.',
    parameters: [],
    returns: 'true if the calling String is a form of a Boolean. isBoolean is Case Insensitive. \r\n\
            All valid boolean strings: y, n, yes, no, t, f, true, false, 0, 1',
    returnType: Boolean,
    examples: ['\
        \'no\'.isBoolean()  // == true \r\n\
        \'hi\'.isBoolean()  // == false \r\n\''],
    tests: function (ext) {
        ext.addTest('', [], false);
        ext.addTest('n', [], true);
        ext.addTest('N', [], true);
        ext.addTest('no', [], true);
        ext.addTest('No', [], true);
        ext.addTest('NO', [], true);
        ext.addTest('f', [], true);
        ext.addTest('false', [], true);
        ext.addTest('False', [], true);
        ext.addTest('False', [], true);
        ext.addTest('y', [], true);
        ext.addTest('Y', [], true);
        ext.addTest('yes', [], true);
        ext.addTest('Yes', [], true);
        ext.addTest('YES', [], true);
        ext.addTest('t', [], true);
        ext.addTest('true', [], true);
        ext.addTest('True', [], true);
        ext.addTest('TRUE', [], true);
        ext.addTest('   TRUE    ', [], true, 'Handles whitespace');
        ext.addTest('   FALSE    ', [], true, 'Handles whitespace');
        ext.addTest('0', [], true);
        ext.addTest('1', [], true);
        ext.addTest('Anything else', [], false);
    },
}, String.prototype);
function StringIsBoolean() {
    if (!this)
        return false;
    var lower = this.lower().trim();
    if (lower == 'y' || lower == 'yes' || lower == 'true' || lower == '1' || lower == 't')
        return true;
    if (lower == 'n' || lower == 'no' || lower == 'false' || lower == '0' || lower == 'f')
        return true;
    return false;
}
singBoolean.method('toBoolean', StringToBoolean, {
    summary: 'Converts the calling string to a Boolean format. ',
    parameters: [],
    returns: 'true if the calling String is a form of a Boolean. isBoolean is Case Insensitive. \r\n\
            All valid boolean strings: y, n, yes, no, t, f, true, false, 0, 1 \r\n\
            If the calling string is not in a boolean format, undefined is returned.',
    returnType: Boolean,
    examples: ['\
        \'no\'.toBoolean()  // == false \r\n\
        \'hi\'.toBoolean()  // == undefined \r\n\''],
    tests: function (ext) {
        ext.addTest('', [], undefined);
        ext.addTest('n', [], false);
        ext.addTest('N', [], false);
        ext.addTest('no', [], false);
        ext.addTest('No', [], false);
        ext.addTest('NO', [], false);
        ext.addTest('false', [], false);
        ext.addTest('False', [], false);
        ext.addTest('False', [], false);
        ext.addTest('0', [], false);
        ext.addTest('y', [], true);
        ext.addTest('Y', [], true);
        ext.addTest('yes', [], true);
        ext.addTest('Yes', [], true);
        ext.addTest('YES', [], true);
        ext.addTest('true', [], true);
        ext.addTest('True', [], true);
        ext.addTest('TRUE', [], true);
        ext.addTest('1', [], true);
        ext.addTest('   TRUE    ', [], true, 'Handles whitespace');
        ext.addTest('   FALSE    ', [], false, 'Handles whitespace');
        ext.addTest('Anything else', [], undefined);
    },
}, String.prototype);
function StringToBoolean() {
    if (!this)
        return;
    var lower = this.lower().trim();
    if (lower == 'y' || lower == 'yes' || lower == 'true' || lower == '1' || lower == 't')
        return true;
    if (lower == 'n' || lower == 'no' || lower == 'false' || lower == '0' || lower == 'f')
        return false;
}
//# sourceMappingURL=singularity-js-boolean.js.map