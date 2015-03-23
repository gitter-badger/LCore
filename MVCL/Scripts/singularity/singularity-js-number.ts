/// <reference path="singularity-core.ts"/>

interface Number {
    pow?: (power: number) => number;
    round?: (decimalPlaces?: number) => number;
    min?: (...items: number[]) => number
    max?: (...items: number[]) => number
    ceil?: (decimalPlaces?: number) => number;
    floor?: (decimalPlaces?: number) => number;
    formatFileSize?: (decimalPlaces: number, useLongUnit: boolean) => string;
    percentOf?: (value: number, decimalPlaces?: number, asPercent?: boolean) => number | string;
    abs?: () => number;

    toStr?: (includeMarkup?: boolean) => string;

    numericValueOf?: () => number;
}

interface JQueryStatic {
    isInt?: (num: any) => boolean;
    isFloat?: (num: any) => boolean;
    isNumber?: (num: any) => boolean;

    random?: (minimum: number, maximum: number, count?: number) => number| number[];
}

interface String {

    toInteger?: () => number;
    toNumber?: () => number;
    isNumeric?: () => number;

    numericValueOf?: () => number;
}

interface Boolean {
    numericValueOf?: () => number;
}

interface Array<T> {

    total?: () => number;
    average?: () => number;
}


var singNumber = singModule.addModule(new sing.Module("Number", Number));


//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Number Extensions
//

singNumber.method('max', NumberMax,
    {
        summary: 'Compares multiple Numbers to find the largest.',
        parameters: [
            {
                name: 'Arguments',
                types: [Object],
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

function NumberMax(...numbers: number[]): number {

    numbers.push(this)

    numbers = numbers.collect();

    return Math.max.apply(null, numbers);
}

singNumber.method('round', NumberRound,
    {
        summary: 'Rounds the calling Number to the nearest whole Number. If a number of decimal places is supplied they will be included',
        parameters: [
            {
                name: 'decimalPlaces',
                types: [Number],
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

singNumber.method('pow', NumberPower,
    {
        summary: 'Returns the calling number raised to the power passed. \r\n\
            Decimal numbers are supported and can be used for calculating fractional powers and roots.',
        parameters: [
            {
                name: 'power',
                types: [Number],
                required: true,
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


            ext.addFailsTest(2, [null], 'Singularity.Number.pow Missing Parameter: number power')
            ext.addFailsTest(2, [undefined], 'Singularity.Number.pow Missing Parameter: number power')
        },
    });

function NumberPower(power) {
    return Math.pow(this, power);
}

singNumber.method('ceil', NumberCeiling,
    {
        summary: 'Extension of the Math.ceil function',
        parameters: [
            {
                name: 'decimalPlaces',
                types: [Number],
                description: 'Specify how many decimal places the output should have',
                defaultValue: 0,
            }],
        returns: 'returns the calling number, rounded up',
        returnType: Number,
        examples: ['\
            (5.5).ceil();   // == (6) \r\n\
            (5.1).ceil();   // == (6) '],
        tests: function (ext) {
            ext.addTest(5.5, [], 6);
            ext.addTest(5.1, [], 6);

            ext.addTest(5.1, [1], 5.1);
            ext.addTest(5.11, [1], 5.2);
        },
    });

function NumberCeiling(decimalPlaces) {
    if (!this)
        return null;

    if (decimalPlaces > 0)
        return Math.ceil(this * ((10).pow(decimalPlaces))) / ((10).pow(decimalPlaces));

    return Math.ceil(this);
}

singNumber.method('floor', NumberFloor,
    {
        summary: 'Extension of the Math.floor function',
        parameters: [
            {
                name: 'decimalPlaces',
                types: [Number],
                description: 'Specify how many decimal places the output should have',
                defaultValue: 0,
            }],
        returns: 'returns the calling number, rounded down',
        returnType: Number,
        examples: ['\
            (5.5).floor();   // == (5) \r\n\
            (5.1).floor();   // == (5) '],
        tests: function (ext) {
            ext.addTest(5.5, [], 5);
            ext.addTest(5.1, [], 5);

            ext.addTest(5.1, [1], 5.1);
            ext.addTest(5.11, [1], 5.1);
            ext.addTest(5.99, [1], 5.9);
        },
    });

function NumberFloor(decimalPlaces) {
    if (!this)
        return null;

    if (decimalPlaces > 0)
        return Math.floor(this * ((10).pow(decimalPlaces))) / ((10).pow(decimalPlaces));

    return Math.floor(this);
}

singNumber.method('formatFileSize', NumberFormatFileSize,
    {
        summary: 'Takes a number (of Bytes) and returns a formatted string of the proper unit (B, KB, MB, etc)',
        parameters: [
            {
                name: 'decimalPlaces',
                types: [Number],
                description: 'Specify how many decimal places the output should have',
                defaultValue: 0,
            },
            {
                name: 'useLongUnit',
                types: [Boolean],
                description: 'Specify a value of true to receive the output unit in long-form (Byte, Kilobyte, etc)',
                defaultValue: false,
            }
        ],
        returns: 'A string representation of the calling number file size.',
        returnType: String,
        examples: ['\
            (1024).formatFileSize()    //  == \'1 KB\' \r\n\
            '],
        tests: function (ext) {
            ext.addTest(0, [], '0 B');
            ext.addTest(0, [1], '0 B');
            ext.addTest(0, [0, true], '0 Bytes');
            ext.addTest(0, [1, true], '0 Bytes');

            ext.addTest(1, [1], '1 B');
            ext.addTest(10, [1], '10 B');
            ext.addTest(100, [1], '100 B');
            ext.addTest(1000, [1], '1000 B');
            ext.addTest(1023, [1], '1023 B');
            ext.addTest(1024, [1], '1 KB');
            ext.addTest(1024, [1, true], '1 Kilobyte');
            ext.addTest(1024 * 2, [1, true], '2 Kilobytes');

            ext.addTest(1025, [1], '1 KB');
            ext.addTest(1520, [1], '1.5 KB');
            ext.addTest(1520, [2], '1.48 KB');
            ext.addTest(1520, [2], '1.48 KB');

            ext.addTest(1024 * 1024, [2], '1 MB');
            ext.addTest(1024 * 1024, [2, true], '1 Megabyte');

            ext.addTest(1024 * 1024 + 500, [5, true], '1.00048 Megabyte');

            ext.addTest(1024 * 1024 * 1024 + 50000000, [5, false], '1.04657 GB');
            ext.addTest(1024 * 1024 * 1024 + 50000000, [5, true], '1.04657 Gigabyte');

            ext.addTest(1024 * 1024 * 1024 * 1024 + 550000000000, [5, false], '1.50022 TB');
            ext.addTest(1024 * 1024 * 1024 * 1024 + 550000000000, [5, true], '1.50022 Terabyte');


            ext.addTest(1024 * 1024 * 1024 * 1024 * 1024 + 550000000000000, [5, false], '1.4885 PB');
            ext.addTest(1024 * 1024 * 1024 * 1024 * 1024 + 550000000000000, [5, true], '1.4885 Petabyte');

            ext.addTest(1024 * 1024 * 1024 * 1024 * 1024 * 1024 + 550000000000000000, [5, false], '1.47705 XB');
            ext.addTest(1024 * 1024 * 1024 * 1024 * 1024 * 1024 + 550000000000000000, [5, true], '1.47705 Exabyte');

            ext.addTest(1024 * 1024 * 1024 * 1024 * 1024 * 1024 * 1024 + 550000000000000000000, [5, false], '1.46587 ZB');
            ext.addTest(1024 * 1024 * 1024 * 1024 * 1024 * 1024 * 1024 + 550000000000000000000, [5, true], '1.46587 Zettabyte');

            ext.addTest(1024 * 1024 * 1024 * 1024 * 1024 * 1024 * 1024 * 1024 + 550000000000000000000000, [5, false], '1.45495 YB');
            ext.addTest(1024 * 1024 * 1024 * 1024 * 1024 * 1024 * 1024 * 1024 + 550000000000000000000000, [5, true], '1.45495 Yottabyte');
        },
    });

function NumberFormatFileSize(decimalPlaces: number, useLongUnit: boolean = false) {

    var units = useLongUnit ? ['Byte', 'Kilobyte', 'Megabyte', 'Gigabyte', 'Terabyte', 'Petabyte', 'Exabyte', 'Zettabyte', 'Yottabyte'] : ['B', 'KB', 'MB', 'GB', 'TB', 'PB', 'XB', 'ZB', 'YB'];

    var magnitude = 0;
    if (this < 0)
        return '0 ' + units[magnitude];

    var outNumber = this;
    while (outNumber >= 1024) {
        outNumber = outNumber / 1024;
        magnitude++;

    }

    var out = outNumber.round(decimalPlaces) + ' ' + units[magnitude];

    if (useLongUnit &&
        (outNumber.floor() > 1 || outNumber.floor() == 0)) {
        out += 's';
    }
    return out;
}

singNumber.method('abs', NumberAbsoluteValue,
    {
        summary: 'Extension of Math.abs',
        parameters: [],
        returns: 'The calling number as a positive value',
        returnType: Number,
        examples: ['\
            (-5).abs()  // == (5) '],
        tests: function (ext) {
            ext.addTest(-5, [], 5);
            ext.addTest(-1, [], 1);
            ext.addTest(0, [], 0);
            ext.addTest(1, [], 1);
            ext.addTest(5, [], 5);

            ext.addTest(-Infinity, [], Infinity);
            ext.addTest(Infinity, [], Infinity);

            ext.addTest(NaN, [], NaN);
        },
    });

function NumberAbsoluteValue(): number {
    return Math.abs(this);
}

singNumber.method('percentOf', NumberPercentOf,
    {
        summary: 'Takes the source number and returns the percent it is of the argument number',
        parameters: [
            {
                name: 'of',
                types: [Number],
                description: 'The number you are dividing by to get the percent',
                required: true,
            },
            {
                name: 'decimalPlaces',
                types: [Number],
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

            ext.addTest(1, [100], 1);
            ext.addTest(1, [100, 0, false], 1);
            ext.addTest(1, [100, 0, true], '1%');
            ext.addTest(50, [100], 50);
            ext.addTest(50, [100, 0, false], 50);
            ext.addTest(50, [100, 0, true], '50%');
            ext.addTest(55, [1000], 6);
            ext.addTest(55, [1000, 0, false], 6);
            ext.addTest(55, [1000, 0, true], '6%');
            ext.addTest(55, [1000, 1], 5.5);
            ext.addTest(55, [1000, 1, false], 5.5);
            ext.addTest(55, [1000, 1, true], '5.5%');
            ext.addTest(242, [286, 5], 84.61538);
            ext.addTest(242, [286, 5, false], 84.61538);
            ext.addTest(242, [286, 5, true], '84.61538%');
            ext.addTest(242, [-286, 5], -84.61538);
            ext.addTest(242, [-286, 5, false], -84.61538);
            ext.addTest(242, [-286, 5, true], '-84.61538%');
            ext.addTest(-242, [286, 5], -84.61538);
            ext.addTest(-242, [286, 5, false], -84.61538);
            ext.addTest(-242, [286, 5, true], '-84.61538%');
            ext.addTest(56465123, [12333, 5], 457837.69561);
            ext.addTest(56465123, [12333, 5, false], 457837.69561);
            ext.addTest(56465123, [12333, 5, true], '457837.69561%');
        },
    });

function NumberPercentOf(of: number, decimalPlaces: number = 0, asString: boolean = false): number | string {

    if (asString) {
        if (of == 0)
            return '(?)%';
        else {
            return ((this / of) * 100).round(decimalPlaces) + '%';
        }
    }
    else {
        if (this == of && of == 0)
            return 0;
        else if (of == 0)
            return this > 0 ? Infinity : -Infinity;
        else {
            return ((this / of) * 100).round(decimalPlaces);
        }
    }
}

singNumber.method('toStr', NumberToStr,
    {
        summary: "\
        Common funciton - toStr is a standardized way of converting Objects to Strings.",
        parameters: [
            {
                name: 'includeMarkup',
                types: [Boolean],
                defaultValue: false,
            }
        ],
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

            ext.addTest(NaN, [], '');
            ext.addTest(NaN, [false], '');
            ext.addTest(NaN, [true], 'NaN');
        },
    });

function NumberToStr(includeMarkup: boolean = false) {

    if (isNaN(this))
        return includeMarkup ? 'NaN' : '';

    return this.toString();
}


singNumber.method('isInt', NumberIsInt,
    {
        summary: null,
        parameters: null,
        validateInput: false,
        returns: '',
        returnType: '',
        examples: null,
        tests: function (ext) {
            ext.addTest(null, [0], true);
            ext.addTest(null, [1], true);
            ext.addTest(null, [1.5], false);
            ext.addTest(null, [-1], true);
            ext.addTest(null, [Infinity], true);
            ext.addTest(null, [-Infinity], true);
            ext.addTest(null, [NaN], false);
            ext.addTest(null, ['a'], false);
        },
    }, $);

function NumberIsInt(num: any) {
    return $.isNumber(num) && num.round().valueOf() == num.valueOf();
}

singNumber.method('isFloat', NumberIsFloat,
    {
        summary: null,
        parameters: null,
        validateInput: false,
        returns: '',
        returnType: '',
        examples: null,
        tests: function (ext) {
            ext.addTest(null, [0], false);
            ext.addTest(null, [1], false);
            ext.addTest(null, [1.5], true);
            ext.addTest(null, [-1], false);
            ext.addTest(null, [Infinity], false);
            ext.addTest(null, [-Infinity], false);
            ext.addTest(null, [NaN], false);
            ext.addTest(null, ['a'], false);
        },
    }, $);

function NumberIsFloat(num: any) {
    return $.isNumber(num) && num.round().valueOf() != num.valueOf();
}

singNumber.method('isNumber', ObjectIsNumber,
    {
        summary: null,
        parameters: null,
        validateInput: false,
        returns: '',
        returnType: '',
        examples: null,
        tests: function (ext) {
            ext.addTest(null, [0], true);
            ext.addTest(null, [1], true);
            ext.addTest(null, [1.5], true);
            ext.addTest(null, [-1], true);
            ext.addTest(null, [Infinity], true);
            ext.addTest(null, [-Infinity], true);
            ext.addTest(null, [NaN], false);
            ext.addTest(null, ['a'], false);
        },
    }, $);

function ObjectIsNumber(num: any) {
    return !isNaN(num) && typeof num == 'number';
}


singNumber.method('numericValueOf', NumberNumericValueOf,
    {
        summary: 'Common funciton - Used for sorting, returns the calling number.',
        parameters: [],
        returns: 'Returnst the calling number.',
        returnType: Number,
        examples: ['\
            (1.6).numericValueOf();                     //  == 1.6  \r\n\
            (1.6555).numericValueOf(2);                 //  == 1.6555  \r\n\
            (1.644999999999999).numericValueOf(2);      //  == 1.644999999999999  '],
        tests: function (ext) {

            ext.addTest(1, [], 1);
            ext.addTest(0, [], 0);
            ext.addTest(Infinity, [], Infinity);
            ext.addTest(-Infinity, [], -Infinity);
        },
    });

function NumberNumericValueOf(): number {
    return (<number>this);
}

singNumber.method('numericValueOf', StringNumericValueOf,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
            ext.addTest('hi', [], 26729);
            ext.addTest('hello', [], 448378203247);
        },
    }, String.prototype, "String");

function StringNumericValueOf(): number {

    if (this.isNumeric())
        return this.toNumber();

    var out = 0;

    for (var i = 0; i < this.length; i++) {

        var char = this[i];

        out += char.charCodeAt(0);

        if (i < this.length - 1)
            out *= (2).pow(8);
    }

    return out;
}

singNumber.method('numericValueOf', BooleanToNumericValue,
    {
        summary: 'Common funciton - Convert all common objects to numeric values',
        parameters: [],
        returns: 'Returns the numeric value of the calling Boolean',
        returnType: Number,
        examples: ['\
            (true).numericValueOf()   //  == (1)  \r\n\
            (false).numericValueOf()   //  == (0)  \r\n'],
        tests: function (ext) {
            ext.addTest(true, [], 1);
            ext.addTest(false, [], 0);
        }
    }, Boolean.prototype, "Boolean");

function BooleanToNumericValue(): number {

    if (this === undefined ||
        this === null)
        return -1;

    if (this.valueOf() === false)
        return 0;

    if (this.valueOf() === true)
        return 1;
}


singNumber.method('random', NumberRandom,
    {
        tests: function (ext) {

            ext.addFailsTest($, [10, 0], 'maximum must be greater than minimum', 'Maxmimum must me greater than minimum');


            ext.addCustomTest(function () {

                var rand1 = $.random(0, 10);

                if (rand1 < 0 || rand1 > 10)
                    return 'invalid random value';

                var rand1 = $.random(-50, -20);

                if (rand1 < -50 || rand1 > -20)
                    return 'invalid random value';

            }, 'Value must be in the correct range.');

            ext.addCustomTest(function () {

                var randoms = <number[]>$.random(0, 10, 5);

                if (randoms.length != 5)
                    return '5 items were not returned';

            }, 'Returns multiple random numbers correctly');
        },
    }, $);

function NumberRandom(minimum: number, maximum: number, count: number = 1): number|number[] {
    if (maximum <= minimum)
        throw 'maximum must be greater than minimum';

    if (count == 0) {
        return;
    }
    if (count == 1) {
        var rand = Math.random();

        var size = maximum - minimum;

        rand = rand * size;

        rand += minimum;

        return rand;
    }
    if (count > 1) {
        var out = [];
        for (var i = 0; i < count; i++) {
            out.push($.random(minimum, maximum, 1));
        }
        return out;
    }
}



singNumber.method('isNumeric', StringIsNumeric,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
            ext.addTest('', [], false);
            ext.addTest('abc', [], false);
            ext.addTest('123', [], true);
            ext.addTest('-123', [], true);
            ext.addTest('123.456', [], true);
            ext.addTest('123.999', [], true);
        },
    }, String.prototype);

function StringIsNumeric() {

    if (this.length == 0)
        return false;

    var src = this.trim();

    try {
        var out = parseFloat(src);

        if (!isNaN(out))
            return true;
    }
    catch (ex) {
    }
    return false;
}

singNumber.method('isInteger', StringIsInteger,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
            ext.addTest('', [], false);
            ext.addTest('abc', [], false);
            ext.addTest('123', [], true);
            ext.addTest('-123', [], true);
            ext.addTest('123.456', [], false);
            ext.addTest('123.999', [], false);
        },
    }, String.prototype);

function StringIsInteger() {

    if (this.length == 0)
        return false;

    var src = this.trim();

    try {
        var out = parseFloat(src);

        if (!isNaN(out)) {

            if (out === out.round())
                return true;
        }
    }
    catch (ex) {
    }
    return false;
}

singNumber.method('toNumber', StringToNumber,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
            ext.addTest('', [], NaN);
            ext.addTest('abc', [], NaN);
            ext.addTest('123', [], 123);
            ext.addTest('-123', [], -123);
            ext.addTest('123.456', [], 123.456);
            ext.addTest('123.999', [], 123.999);
        },
    }, String.prototype);

function StringToNumber(): number {

    if (this.length == 0)
        return NaN;

    var src = (<string>this).trim();

    try {
        return parseFloat(src);
    }
    catch (ex) {
    }

    return NaN;
}

singNumber.method('toInteger', StringToInteger,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
            ext.addTest('', [], NaN);
            ext.addTest('abc', [], NaN);
            ext.addTest('123', [], 123);
            ext.addTest('-123', [], -123);
            ext.addTest('123.456', [], 123);
            ext.addTest('123.999', [], 123);
        },
    }, String.prototype);

function StringToInteger(): number {

    if (this.length == 0)
        return NaN;

    var src = (<string>this).trim();

    try {
        return parseFloat(src).floor();
    }
    catch (ex) {
    }

    return NaN;
}

/////////////////////////////////////////////

singNumber.method('total', ArrayTotal, {}, Array.prototype);

function ArrayTotal() {

    if (this.length == 0)
        return;

    var out = 0;

    for (var i = 0; i < this.length; i++) {

        var item = this[i];

        if ($.isNumber(item)) {
            out += item;
        }
    }

    return out;

}

singNumber.method('average', ArrayAverage, {}, Array.prototype);

function ArrayAverage() {

    function ArrayTotal() {

        if (this.length == 0)
            return;

        var out = 0;

        for (var i = 0; i < this.length; i++) {

            var item = this[i];

            if ($.isNumber(item)) {
                out += item;
            }
        }

        return out / this.length;

    }

}