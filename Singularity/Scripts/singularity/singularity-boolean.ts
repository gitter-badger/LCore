/// <reference path="singularity-core.ts"/>

interface Boolean {
    toYesNo?: () => string;

    // ReSharper disable InconsistentNaming
    XOR?: (b: boolean) => boolean;
    XNOR?: (b: boolean) => boolean;
    OR?: (...b: boolean[]) => boolean;
    AND?: (...b: boolean[]) => boolean;
    NAND?: (...b: boolean[]) => boolean;
    NOR?: (...b: boolean[]) => boolean;
    // ReSharper restore InconsistentNaming

    ternary?: (obj?: any, obj2?: any) => any;
}

interface String {
    isBoolean?: () => boolean;
    toBoolean?: () => boolean;
}

var singBoolean = singExt.addModule(new sing.Module('Boolean', Boolean));

singBoolean.glyphIcon = '&#xe063;';

singBoolean.summaryShort = 'Extensions on Boolean.prototype';
singBoolean.summaryLong = 'Perform boolean operations using extension methods instead of operators.';

singBoolean.features = ['Multi-variable operations',
    'Ternary operation',
    'toYesNo'];


///////////////////////////////////////////////////////////////////////////////////////////////////
//
// Boolean Extensions
//
//

singBoolean.method('XOR', booleanXor,
    {
        summary: '\
        XOR acts on a boolean to perform the binary XOR function on the passed Boolean',
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
        glyphIcon: '&#xe083;',
        tests: ext => {

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

function booleanXor(b: boolean): boolean {
    const a = this.valueOf();

    return (a == true && b == false) ||
        (a == false && b);
}

singBoolean.method('XNOR', booleanXNOR,
    {
        summary: '\
        XNOR acts on a boolean to perform the binary XNOR function on the passed Boolean, the inverse of the XOR function',
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
        glyphIcon: '&#xe088;',
        tests: ext => {

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

function booleanXNOR(b: boolean): boolean {
    return !this.XOR(b);
}

singBoolean.method('OR', booleanOR,
    {
        summary: '\
        OR acts on a boolean to perform the binary OR function on the passed Booleans',
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
        glyphIcon: '&#xe063;',
        tests: ext => {

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

function booleanOR(...b: boolean[]): boolean {
    return this == true || b.has(true);
}

singBoolean.method('NOR', booleanNOR,
    {
        summary: '\
        NOR acts on a boolean to perform the binary NOR function on the passed Booleans',
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
        glyphIcon: '&#xe088;',
        tests: ext => {

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

function booleanNOR(...b: boolean[]): boolean {
    return !this.OR.apply(this, b);
}

singBoolean.method('AND', booleanAND,
    {
        summary: '\
        AND acts on a boolean to perform the binary AND function on the passed Booleans',
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
        glyphIcon: '&#xe081;',
        tests: ext => {

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

function booleanAND(...b: boolean[]): boolean {
    return this == true && !b.has(false);
}

singBoolean.method('NAND', booleanNAND,
    {
        summary: '\
        NAND acts on a boolean to perform the binary NAND function on the passed Booleans',
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
        glyphIcon: '&#x2b;',
        tests: ext => {

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

function booleanNAND(...b: boolean[]): boolean {
    if (b.length == 0)
        return this;
    return !this.AND.apply(this, b);
}

singBoolean.method('toYesNo', booleanToYesNo,
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
        glyphIcon: '&#xe150;',
        tests: ext => {
            ext.addTest(true, [], 'Yes');
            ext.addTest(false, [], 'No');
        }
    });

function booleanToYesNo(): string {
    return this == false ? 'No' : 'Yes';
}

singBoolean.method('ternary', booleanTernary,
    {
        summary: 'Performs the ternary operation using the calling boolean.',
        parameters: [
            {
                name: 'obj',
                types: [Object],
                description: 'The first object, returned if the caller is true'
            },
            {
                name: 'obj2',
                types: [Object],
                description: 'The second object, returned if the caller is false'
            }
        ],
        returns: 'Returns the first argument if the calling boolean is true, otherwise the second argument is returned.',
        returnType: Object,
        examples: ['(true).ternary(1,2)   // == 1'],
        glyphIcon: 'icon-share',
        tests: ext => {
            ext.addTest(true, ['a', 'b'], 'a');
            ext.addTest(false, ['a', 'b'], 'b');
        }
    }, String.prototype);

function booleanTernary(obj?: any, obj2?: any): any {

    return this.valueOf() ? obj : obj2;
}


singBoolean.method('isBoolean', stringIsBoolean,
    {
        summary: 'Determines if the calling string is a Boolean format.',
        parameters: [],
        returns: 'true if the calling String is a form of a Boolean. isBoolean is Case Insensitive. \r\n\
            All valid boolean strings: y, n, yes, no, t, f, true, false, 0, 1',
        returnType: Boolean,
        examples: ['\
        \'no\'.isBoolean()  // == true \r\n\
        \'hi\'.isBoolean()  // == false \r\n\''],
        glyphIcon: '&#xe003;',
        tests: ext => {
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
        }
    }, String.prototype);

function stringIsBoolean() {
    const lower = this.lower().trim();
    if (lower == 'y' || lower == 'yes' || lower == 'true' || lower == '1' || lower == 't')
        return true;
    if (lower == 'n' || lower == 'no' || lower == 'false' || lower == '0' || lower == 'f')
        return true;

    return false;

}

singBoolean.method('toBoolean', stringToBoolean,
    {
        summary: 'Converts the calling string to a Boolean format. ',
        parameters: [],
        returns: 'true if the calling String is a form of a Boolean. isBoolean is Case Insensitive. \r\n\
            All valid boolean strings: y, n, yes, no, t, f, true, false, 0, 1 \r\n\
            If the calling string is not in a boolean format, undefined is returned.',
        returnType: Boolean,
        examples: ['\
        \'no\'.toBoolean()  // == false \r\n\
        \'hi\'.toBoolean()  // == undefined \r\n\''],
        glyphIcon: '&#xe063;',
        tests: ext => {
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

        }
    }, String.prototype);

function stringToBoolean() {

    const lower = this.lower().trim();

    if (lower == 'y' || lower == 'yes' || lower == 'true' || lower == '1' || lower == 't')
        return true;
    if (lower == 'n' || lower == 'no' || lower == 'false' || lower == '0' || lower == 'f')
        return false;

}