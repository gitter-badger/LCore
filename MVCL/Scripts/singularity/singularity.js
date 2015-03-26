function MNCL_Init() {
    tooltip.init();
}
function preg_quote(str) {
    return (str + '').replace(/([\\\.\+\*\?\[\^\]\$\(\)\{\}\=\!\<\>\|\:])/g, "\\$1");
}
var tooltip;
/// <reference path="singularity-core.ts"/>
var singNumber = singExt.addModule(new sing.Module("Number", Number));
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Number Extensions
//
singNumber.method('max', NumberMax, {
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
function NumberMax() {
    var numbers = [];
    for (var _i = 0; _i < arguments.length; _i++) {
        numbers[_i - 0] = arguments[_i];
    }
    numbers.push(this);
    numbers = numbers.collect();
    return Math.max.apply(null, numbers);
}
singNumber.method('round', NumberRound, {
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
singNumber.method('pow', NumberPower, {
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
        ext.addTest(2, [2], 4);
        ext.addTest(4, [2], 16);
        ext.addTest(4, [1 / 2], 2);
        ext.addTest(2, [1 / 2], 1.4142135623730951);
        ext.addFailsTest(2, [null], 'Singularity.Extensions.Number.pow Missing Parameter: number power');
        ext.addFailsTest(2, [undefined], 'Singularity.Extensions.Number.pow Missing Parameter: number power');
    },
});
function NumberPower(power) {
    return Math.pow(this, power);
}
singNumber.method('ceil', NumberCeiling, {
    summary: 'Extension of the Math.ceil function',
    parameters: [
        {
            name: 'decimalPlaces',
            types: [Number],
            description: 'Specify how many decimal places the output should have',
            defaultValue: 0,
        }
    ],
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
singNumber.method('floor', NumberFloor, {
    summary: 'Extension of the Math.floor function',
    parameters: [
        {
            name: 'decimalPlaces',
            types: [Number],
            description: 'Specify how many decimal places the output should have',
            defaultValue: 0,
        }
    ],
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
singNumber.method('formatFileSize', NumberFormatFileSize, {
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
function NumberFormatFileSize(decimalPlaces, useLongUnit) {
    if (useLongUnit === void 0) { useLongUnit = false; }
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
    if (useLongUnit && (outNumber.floor() > 1 || outNumber.floor() == 0)) {
        out += 's';
    }
    return out;
}
singNumber.method('abs', NumberAbsoluteValue, {
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
function NumberAbsoluteValue() {
    return Math.abs(this);
}
singNumber.method('percentOf', NumberPercentOf, {
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
function NumberPercentOf(of, decimalPlaces, asString) {
    if (decimalPlaces === void 0) { decimalPlaces = 0; }
    if (asString === void 0) { asString = false; }
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
singNumber.method('toStr', NumberToStr, {
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
        ext.addTest(-100.105, [], '-100.105', 'Decimal numbers are supported.');
        ext.addTest(-100.100, [], '-100.1', 'Trailing 0s are not included.');
        ext.addTest(5.5, [], '5.5');
        ext.addTest(NaN, [], '');
        ext.addTest(NaN, [false], '');
        ext.addTest(NaN, [true], 'NaN');
    },
});
function NumberToStr(includeMarkup) {
    if (includeMarkup === void 0) { includeMarkup = false; }
    if (isNaN(this))
        return includeMarkup ? 'NaN' : '';
    return this.toString();
}
singNumber.method('isInt', NumberIsInt, {
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
function NumberIsInt(num) {
    return $.isNumber(num) && num.round().valueOf() == num.valueOf();
}
singNumber.method('isFloat', NumberIsFloat, {
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
function NumberIsFloat(num) {
    return $.isNumber(num) && num.round().valueOf() != num.valueOf();
}
singNumber.method('isNumber', ObjectIsNumber, {
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
function ObjectIsNumber(num) {
    return !isNaN(num) && typeof num == 'number';
}
singNumber.method('numericValueOf', NumberNumericValueOf, {
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
function NumberNumericValueOf() {
    return this;
}
singNumber.method('numericValueOf', StringNumericValueOf, {
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
function StringNumericValueOf() {
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
singNumber.method('numericValueOf', BooleanToNumericValue, {
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
function BooleanToNumericValue() {
    if (this === undefined || this === null)
        return -1;
    if (this.valueOf() === false)
        return 0;
    if (this.valueOf() === true)
        return 1;
}
singNumber.method('random', NumberRandom, {
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
            var randoms = $.random(0, 10, 5);
            if (randoms.length != 5)
                return '5 items were not returned';
        }, 'Returns multiple random numbers correctly');
    },
}, $);
function NumberRandom(minimum, maximum, count) {
    if (count === void 0) { count = 1; }
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
        while (count > 0) {
            out.push($.random(minimum, maximum, 1));
            count--;
        }
    }
    return out;
}
singNumber.method('isNumeric', StringIsNumeric, {
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
singNumber.method('isInteger', StringIsInteger, {
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
singNumber.method('toNumber', StringToNumber, {
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
function StringToNumber() {
    if (this.length == 0)
        return NaN;
    var src = this.trim();
    try {
        return parseFloat(src);
    }
    catch (ex) {
    }
    return NaN;
}
singNumber.method('toInteger', StringToInteger, {
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
function StringToInteger() {
    if (this.length == 0)
        return NaN;
    var src = this.trim();
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
        return stringOrStrings.contains(function (s, i) {
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
    return this.indexOf(stringOrStrings) == this.length - stringOrStrings.length;
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
/// <reference path="singularity-core.ts"/>
var SingularityTests = (function () {
    function SingularityTests() {
        this.testErrors = [];
        this.resolveTests = function () {
            $.objEach(sing.methods, function (key, ext, i) {
                if (ext && ext.details.tests && $.isFunction(ext.details.tests)) {
                    ext.details.tests(ext);
                    // Clear it if it's still a function (no tests)
                    if ($.isFunction(ext.details.tests))
                        ext.details.tests = null;
                }
            });
        };
    }
    return SingularityTests;
})();
var SingularityTest = (function () {
    function SingularityTest(name, testFunc, requirement) {
        this.name = name;
        this.testFunc = testFunc;
        this.requirement = requirement;
        this.testFunc = function () {
            this.testResult = testFunc();
            if (this.testResult == null)
                this.testResult = true;
            if (this.testResult !== true && this.testResult !== undefined && this.testResult !== null) {
                this.testResult = name + ' ' + this.testResult;
                if (!sing.tests.testErrors.contains(this.testResult))
                    sing.tests.testErrors.push(this.testResult);
            }
            return this.testResult;
        };
    }
    return SingularityTest;
})();
sing.tests = new SingularityTests();
var singTests = singCore.addModule(new sing.Module('Tests', SingularityTests));
singTests.method('resolveTests', sing.tests.resolveTests, {});
singTests.method('addTest', SingularityAddTest, {});
function SingularityAddTest(name, testFunc, requirement) {
    if (!sing.methods[name])
        throw name + ' not found';
    if (!sing.methods[name].details.tests)
        throw name + ' tests not found';
    if ($.isFunction(sing.methods[name].details.tests))
        sing.methods[name].details.unitTests = sing.methods[name].details.unitTests || [];
    sing.methods[name].details.unitTests = sing.methods[name].details.unitTests.concat(new SingularityTest(name, testFunc, requirement));
}
;
singTests.method('addCustomTest', SingularityAddCustomTest, {});
function SingularityAddCustomTest(name, testFunc, requirement) {
    if (!$.isString(name))
        throw name + ' was not a string';
    if (!sing.methods[name])
        throw name + ' not found';
    if (!sing.methods[name].details.tests)
        throw name + ' tests not found';
    requirement = requirement || '';
    requirement += '\r\n' + testFunc.toString() + '\r\n';
    sing.methods[name].details.unitTests = sing.methods[name].details.unitTests || [];
    sing.methods[name].details.unitTests = sing.methods[name].details.unitTests.concat(new SingularityTest(name, testFunc, requirement));
}
;
singTests.method('addMethodTest', SingularityAddMethodTest, {});
function SingularityAddMethodTest(ext, target, args, compare, requirement) {
    if (!ext.method)
        throw ext.name + ' method not found';
    requirement = (requirement ? (requirement + '\r\n') : '') + (!!target ? '(' + $.toStr(target, true) + ').' : '') + ext.shortName;
    requirement += '(';
    for (var i = 0; i < args.length; i++) {
        requirement += $.toStr(args[i], true);
        if (i < args.length - 1)
            requirement += ', ';
    }
    requirement += ')';
    requirement = requirement.pad(50);
    requirement += ' == (' + $.toStr(compare, true) + ')';
    this.addTest(ext.name, function () {
        var result = ext.method.apply(target, args);
        if (compare == result)
            return true;
        else if ($.toStr(compare) == $.toStr(result))
            return true;
        else
            return requirement + '\r\n' + $.toStr(compare, true) + ' expected, result: ' + $.toStr(result, true);
    }, requirement);
}
;
singTests.method('addAssertTest', SingularityAddAssertTest, {});
function SingularityAddAssertTest(name, result, compare, requirement) {
    requirement = requirement || $.toStr(compare, true) + ' is expected to match result: ' + $.toStr(result, true);
    this.addTest(name, function () {
        if (compare == result)
            return true;
        else if ($.toStr(compare) == $.toStr(result))
            return true;
        else
            return requirement + '\r\n' + ' TEST FAILED \r\n';
    }, requirement);
}
;
singTests.method('addFailsTest', SingularityAddFailsTest, {});
function SingularityAddFailsTest(ext, target, args, expectedError, requirement) {
    if (target == null || target == undefined)
        throw 'no target';
    requirement = (requirement ? (requirement + '\r\n') : '') + '(' + $.toStr(target, true) + ').' + ext.shortName;
    requirement += '(';
    for (var i = 0; i < args.length; i++) {
        requirement += $.toStr(args[i], true);
        if (i < args.length - 1)
            requirement += ', ';
    }
    requirement += ')';
    requirement = requirement.pad(50);
    requirement += ' THROWS ' + (expectedError ? '\'' + expectedError + '\'' : 'AN ERROR ');
    this.addTest(ext.name, function () {
        try {
            var result = ext.method.apply(target, args);
            return name + ' was expected to fail but it did not. \r\n\r\n' + requirement;
        }
        catch (ex) {
            if (expectedError && ex != expectedError && ex != 'Uncaught ' + expectedError && 'Uncaught ' + ex != expectedError) {
                return name + ' was expected to fail with a message of \'' + expectedError + '\' \r\n' + 'but instead failed with error \'' + ex + '\'' + '\r\n\r\n' + requirement;
            }
            return true;
        }
    }, requirement);
}
;
singTests.method('runTests', SingularityRunTests, {});
function SingularityRunTests(display) {
    if (display === void 0) { display = false; }
    sing.tests.resolveTests();
    var result;
    var testCount = 0;
    var displayStr = '';
    for (var i = 0; i < Object.keys(sing.methods).length; i++) {
        var name = Object.keys(sing.methods)[i];
        var ext = sing.methods[name];
        var tests = ext.details.unitTests;
        if (tests) {
            for (var j = 0; j < tests.length; j++) {
                var test = tests[j];
                // log('running test ' + name + ' ' + (j + 1));
                if (display)
                    displayStr += test.requirement + '\r\n';
                var testFunc = test.testFunc;
                var testResult = testFunc();
                if (testResult != true && testResult !== undefined && testResult !== null) {
                    testResult = testResult || '';
                    result = 'Error testing \'' + name + '\' Test ' + (j + 1) + '\r\n' + testResult;
                    break;
                }
                testCount++;
            }
        }
        ;
    }
    return sing.tests.listTests() + '\r\n' + displayStr + '\r\n' + (result || '\r\n\r\nAll ' + testCount + ' tests succeeded.');
}
;
singTests.method('listTests', SingularityListTests, {});
function SingularityListTests() {
    sing.tests.resolveTests();
    var out = '\r\n';
    for (var i = 0; i < Object.keys(sing.methods).length; i++) {
        var name = Object.keys(sing.methods)[i];
        var item = sing.methods[name];
        var tests = item.details.unitTests;
        if (tests && tests.length > 0)
            out += ('Extension: ' + name).pad(50) + '      Tests: ' + tests.length + '\r\n';
        else
            ; // out += 'Function: ' + name + '      Tests: 0\r\n';
    }
    return out;
}
;
singTests.method('listMissingTests', SingularityListMissingTests, {});
function SingularityListMissingTests() {
    sing.tests.resolveTests();
    var out = '';
    for (var i = 0; i < Object.keys(sing.methods).length; i++) {
        var name = Object.keys(sing.methods)[i];
        var item = sing.methods[name];
        var tests = item.details.unitTests;
        if (!tests || tests.length == 0) {
            out += 'Extension: ' + name + '      Tests: 0\r\n';
        }
    }
    return out;
}
;
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
SingularityMethod.prototype.addFailsTest = MethodAddFailsTest;
singTests.method('addFailsTest', MethodAddFailsTest, {}, SingularityMethod);
function MethodAddFailsTest(caller, args, expectedError, requirement) {
    sing.tests.addFailsTest(this, caller, args, expectedError, requirement);
}
SingularityMethod.prototype.addCustomTest = MethodAddCustomTest;
singTests.method('addCustomTest', MethodAddCustomTest, {}, SingularityMethod);
function MethodAddCustomTest(testFunc, requirement) {
    sing.tests.addCustomTest(this.name, testFunc, requirement);
}
SingularityMethod.prototype.addTest = MethodAddSimpleTest;
singTests.method('addTest', MethodAddSimpleTest, {}, SingularityMethod);
function MethodAddSimpleTest(caller, args, result, requirement) {
    sing.tests.addMethodTest(this, caller, args, result, requirement);
}
/// <reference path="singularity-core.ts"/>
/// <reference path="singularity-tests.ts"/>
var singArray = singExt.addModule(new sing.Module("Array", Array));
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Array Extensions
//
//
//////////////////////////////////////////////////////
//
// Mapping Functions
//
singArray.method('splitAt', SplitAt, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    },
});
function SplitAt() {
    var indexes = [];
    for (var _i = 0; _i < arguments.length; _i++) {
        indexes[_i - 0] = arguments[_i];
    }
    indexes.sort();
    var thisArray = this;
    var out = [];
    var section = [];
    var indexI = 0;
    for (var i = 0; i < thisArray.length; i++) {
        if (indexes.length > indexI) {
            if (i < indexes[indexI])
                section.push(thisArray[i]);
            if (i == indexes[indexI]) {
                out.push(section);
                section = [];
                indexI++;
            }
        }
    }
    return out;
}
singArray.method('removeAt', ArrayRemoveAt, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    },
});
function ArrayRemoveAt() {
    var indexes = [];
    for (var _i = 0; _i < arguments.length; _i++) {
        indexes[_i - 0] = arguments[_i];
    }
    var thisArray = this;
    return thisArray.select(function (item, index) {
        return !indexes.contains(index);
    });
}
singArray.method('unique', ArrayUnique, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    aliases: ['removeDuplicates'],
    tests: function (ext) {
    },
});
function ArrayUnique() {
    var indexes = [];
    for (var _i = 0; _i < arguments.length; _i++) {
        indexes[_i - 0] = arguments[_i];
    }
    var thisArray = this;
    var out = [];
    thisArray.each(function (item, index) {
        if (!out.contains(item))
            out.push(item);
    });
    return out;
}
singArray.method('random', ArrayRandom, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    },
});
function ArrayRandom(count) {
    if (count === void 0) { count = 1; }
    var thisArray = this;
    var out = [];
    // Don't return more random items than we have;
    count = count.min(thisArray.length);
    if (count == thisArray.length)
        return thisArray.shuffle();
    thisArray = thisArray.shuffle();
    while (out.length < count) {
        out.push((thisArray).shift());
    }
    return out;
}
singArray.method('shuffle', ArrayShuffle, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    },
});
function ArrayShuffle() {
    var thisArray = this;
    var out = [];
    while (thisArray.length > 0) {
        var rand = $.random(0, thisArray.length).floor();
        out.push(thisArray[rand]);
        thisArray = thisArray.remove(thisArray[rand]);
    }
    return out;
}
singArray.method('group', ArrayGroup, {});
function ArrayGroup(keyFunc) {
    var thisArray = this;
    var out = {};
    thisArray.each(function (item, index) {
        var key = keyFunc(item, index);
        if (key && key.length > 0) {
            if ($.isArray(out[key]))
                out[key].push(item);
            else
                out[key] = [item];
        }
    });
    return out;
}
singArray.method('toArray', ObjToArray, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    tests: function (ext) {
        ext.addTest(null, [], []);
        ext.addTest(null, [null], []);
        ext.addTest(null, [undefined], []);
        ext.addTest(null, [0], [0]);
        ext.addTest(null, [[0, 1, 2]], [0, 1, 2]);
    },
}, $);
function ObjToArray(obj) {
    if (!$.isDefined(obj))
        return [];
    if ($.isArray(obj))
        return obj;
    else
        return [obj];
}
/*
singEnumerable.method('fill', null,
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
/// <reference path="singularity-core.ts"/>
var singFunction = singExt.addModule(new sing.Module("Function", Function));
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Function Extensions
//
singFunction.method('fn_try', FunctionTry, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    tests: function (ext) {
    },
});
function FunctionTry() {
    var source = this;
    // Redirects to catch with no catchFunction
    return source.fn_catch();
}
singFunction.method('fn_catch', FunctionCatch, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    tests: function (ext) {
    },
});
function FunctionCatch(catchFunction, logFailure) {
    if (logFailure === void 0) { logFailure = false; }
    var source = this;
    return function () {
        var result;
        try {
            result = source.apply(this, arguments);
        }
        catch (ex) {
            if (logFailure) {
                log(['FAILED', source.name, ex]);
                log([arguments]);
            }
            if (catchFunction)
                return catchFunction.apply(this, [ex].concat(arguments));
        }
        return result;
    };
}
singFunction.method('fn_log', FunctionLog, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    tests: function (ext) {
    },
});
function FunctionLog(logAttempt, logSuccess, logFailure) {
    if (logAttempt === void 0) { logAttempt = true; }
    if (logSuccess === void 0) { logSuccess = true; }
    if (logFailure === void 0) { logFailure = true; }
    var thisFunction = this;
    return function () {
        try {
            if (logAttempt) {
                log(['Attempting: ', thisFunction.name, arguments, result]);
            }
            var result = thisFunction.apply(this, arguments);
            if (logSuccess) {
                log(['Completed: ' + thisFunction.name, arguments, result]);
            }
            return result;
        }
        catch (ex) {
            if (logFailure) {
                log(['FAILED', thisFunction.name, ex]);
                log([arguments]);
            }
            throw ex;
        }
    };
}
singFunction.method('fn_count', FunctionCount, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    tests: function (ext) {
    },
});
function FunctionCount(logFailure) {
    if (logFailure === void 0) { logFailure = false; }
    var source = this;
    var functionCallCount = 0;
    return function () {
        try {
            var result = source.apply(this, arguments);
            log([source.name, 'count:' + functionCallCount]);
            log([arguments, result]);
            return result;
        }
        catch (ex) {
            if (logFailure) {
                log(['FAILED', source.name, ex, 'count:' + functionCallCount]);
                log([arguments]);
            }
            throw ex;
        }
    };
}
singFunction.method('fn_cache', FunctionCache, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    tests: function (ext) {
    },
});
function FunctionCache(uniqueCacheID, expiresAfter) {
    if (expiresAfter === void 0) { expiresAfter = 0; }
    var source = this;
    uniqueCacheID = uniqueCacheID || this.name;
    if (!uniqueCacheID)
        throw 'Unique ID not found';
    var ext = sing.methods['Function.fn_cache'];
    if (!ext.data)
        ext.data = {};
    if (!ext.data['cache'])
        ext.data['cache'] = {};
    return function () {
        var cache = sing.methods['Function.fn_cache'].data['cache'];
        if (!cache[uniqueCacheID])
            cache[uniqueCacheID] = {};
        var thisCache = cache[uniqueCacheID];
        var argStr = $.toStr(source) + $.toStr($.objValues(arguments));
        if (thisCache[argStr] != undefined && thisCache[argStr] != null) {
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
        var result = thisCache[argStr].value = source.apply(this, arguments);
        if (expiresAfter > 0) {
            thisCache[argStr].expires = (new Date()).valueOf() + expiresAfter;
        }
        return result;
    };
}
singFunction.method('fn_or', FunctionOR, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    tests: function (ext) {
    },
});
function FunctionOR(orFunc) {
    var source = this;
    return function () {
        var result1 = source.apply(this, arguments);
        var result2 = orFunc.apply(this, arguments);
        return result1 || result2;
    };
}
singFunction.method('fn_if', FunctionIf, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    tests: function (ext) {
    },
});
function FunctionIf(ifFunc) {
    var srcThis = this;
    return function () {
        var items = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            items[_i - 0] = arguments[_i];
        }
        if (ifFunc.apply(this, items) == true) {
            return srcThis.apply(this, items);
        }
    };
}
singFunction.method('fn_unless', FunctionUnless, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    tests: function (ext) {
    },
});
function FunctionUnless(ifFunc) {
    var srcThis = this;
    return function () {
        var items = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            items[_i - 0] = arguments[_i];
        }
        if (ifFunc.apply(this, items) != true) {
            return srcThis.apply(this, items);
        }
    };
}
singFunction.method('fn_then', FunctionThen, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    tests: function (ext) {
    },
});
function FunctionThen(ifFunc) {
    var srcThis = this;
    return function () {
        var items = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            items[_i - 0] = arguments[_i];
        }
        if (ifFunc.apply(this, items) != true) {
            return srcThis.apply(this, items);
        }
    };
}
singFunction.method('fn_repeat', FunctionRepeat, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    tests: function (ext) {
    },
});
function FunctionRepeat(repeatOver) {
    var srcThis = this;
    if ($.isFunction(repeatOver)) {
        return function () {
            var items = [];
            for (var _i = 0; _i < arguments.length; _i++) {
                items[_i - 0] = arguments[_i];
            }
            var out = [];
            var result = repeatOver.apply(this, items);
            while (result != null && result != undefined) {
                out.push(result);
                result = repeatOver.apply(this, items);
            }
            return out;
        };
    }
    if ($.isNumber(repeatOver)) {
        return function () {
            var items = [];
            for (var _i = 0; _i < arguments.length; _i++) {
                items[_i - 0] = arguments[_i];
            }
            return repeatOver.timesDo(srcThis);
        };
    }
    repeatOver = $.toArray(repeatOver);
    return function () {
        var items = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            items[_i - 0] = arguments[_i];
        }
        var out = [];
        for (var repeat in repeatOver) {
            var args = items;
            args.push(repeat);
            var result = srcThis.apply(this, items);
            if (result != null && result != undefined)
                out.push(result);
        }
        return out;
    };
}
singFunction.method('fn_while', FunctionWhile, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    tests: function (ext) {
    },
});
function FunctionWhile(condition) {
    return function () {
        var items = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            items[_i - 0] = arguments[_i];
        }
        return this.fn_repeat(condition).apply(this, items);
    };
}
singFunction.method('fn_retry', FunctionRetry, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    tests: function (ext) {
    },
});
function FunctionRetry(times) {
    if (times === void 0) { times = 1; }
    var srcThis = this;
    return function () {
        var items = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            items[_i - 0] = arguments[_i];
        }
        var exception = null;
        var attempts = 0;
        while (attempts < times) {
            try {
                var result = srcThis.apply(this, items);
                return result;
            }
            catch (ex) {
                exception = ex;
                attempts++;
            }
        }
        throw 'Failed ' + times + ' times with ' + exception;
    };
}
singFunction.method('fn_time', FunctionTime, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    tests: function (ext) {
    },
});
function FunctionTime() {
    var srcThis = this;
    return function () {
        var items = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            items[_i - 0] = arguments[_i];
        }
        var start = new Date().valueOf();
        var result = srcThis.apply(this, items);
        var end = new Date().valueOf();
        var length = (end - start).max(0);
        log('Completed: ' + srcThis.name + ' in ' + length + ' milliseconds');
        return result;
    };
}
singFunction.method('fn_defer', FunctionDefer, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    aliases: ['async'],
    tests: function (ext) {
    },
});
function FunctionDefer(callback) {
    var srcThis = this;
    return function () {
        var items = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            items[_i - 0] = arguments[_i];
        }
        setTimeout(function () {
            var result = srcThis.apply(this, items);
            if (callback)
                callback(result);
        }, 1);
    };
}
singFunction.method('fn_delay', FunctionDelay, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    tests: function (ext) {
    },
});
function FunctionDelay(delayMS, callback) {
    var srcThis = this;
    delayMS = delayMS.max(1);
    return function () {
        var items = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            items[_i - 0] = arguments[_i];
        }
        setTimeout(function () {
            var result = srcThis.apply(this, items);
            if (callback)
                callback(result);
        }, delayMS);
    };
}
singFunction.method('fn_before', FunctionBefore, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    tests: function (ext) {
    },
});
function FunctionBefore(triggerFunc) {
    var srcThis = this;
    return function () {
        var items = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            items[_i - 0] = arguments[_i];
        }
        triggerFunc.apply(this, items);
        var result = srcThis.apply(this, items);
        return result;
    };
}
singFunction.method('fn_after', FunctionAfter, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    tests: function (ext) {
    },
});
function FunctionAfter(triggerFunc) {
    var srcThis = this;
    return function () {
        var items = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            items[_i - 0] = arguments[_i];
        }
        var result = srcThis.apply(this, items);
        items.push(result);
        triggerFunc.apply(this, items);
        return result;
    };
}
singFunction.method('fn_wrap', FunctionWrap, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    tests: function (ext) {
    },
});
function FunctionWrap(triggerFunc) {
    var srcThis = this;
    return function () {
        var items = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            items[_i - 0] = arguments[_i];
        }
        triggerFunc.apply(this, items);
        var result = srcThis.apply(this, items);
        items.push(result);
        triggerFunc.apply(this, items);
        return result;
    };
}
singFunction.method('fn_trace', FunctionTrace, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    tests: function (ext) {
    },
});
function FunctionTrace(traceStr) {
    var srcThis = this;
    return function () {
        var items = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            items[_i - 0] = arguments[_i];
        }
        if (traceStr != null && traceStr.length > 0)
            console.log(traceStr);
        console.trace();
        var result = srcThis.apply(this, items);
        return result;
    };
}
singFunction.method('fn_recurring', FunctionRecurring, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    tests: function (ext) {
    },
});
function FunctionRecurring(intervalMS, breakCondition) {
    var srcThis = this;
    var minimum = 10;
    var runs = 0;
    intervalMS = intervalMS.max(minimum);
    var setTimer = function (src, items) {
        if ($.isNumber(breakCondition) && breakCondition > 0 && runs >= breakCondition)
            return;
        else if ($.isFunction(breakCondition) && breakCondition(items) == true)
            return;
        setTimeout(function () {
            setTimer(src, items);
        }, intervalMS);
        srcThis.apply(src, items);
        runs++;
    };
    return function () {
        var items = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            items[_i - 0] = arguments[_i];
        }
        var src = this;
        setTimer(src, items);
    };
}
singFunction.method('executeAll', ArrayExecuteAll, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    tests: function (ext) {
    },
}, Array.prototype);
function ArrayExecuteAll() {
    var items = [];
    for (var _i = 0; _i < arguments.length; _i++) {
        items[_i - 0] = arguments[_i];
    }
    if (!items.every($.isFunction))
        throw 'Not all items were functions';
    var srcThis = this;
    var out = [];
    out = items.collect(function (item) {
        return item.apply(srcThis, items);
    });
    return out;
}
singFunction.method('fn_not', FunctionNot, {});
function FunctionNot() {
    var srcThis = this;
    return function () {
        var items = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            items[_i - 0] = arguments[_i];
        }
        var result = srcThis.apply(this, items);
        return !result;
    };
}
/*
singFunction.method('fn_supply', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        tests: function (ext) {
        },
    });

singFunction.method('fn_ifElse', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        tests: function (ext) {
        },
    });
*/
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
    return this == true || b.contains(true);
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
    return this == true && !b.contains(false);
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
/// <reference path="singularity-core.ts"/>
var singJQuery = singExt.addModule(new sing.Module("jQuery", [$, $.fn], $));
/*
//////////////////////////////////////////////////////
//
// jQuery Extensions
//
//
*/
singJQuery.method('checked', Checked, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: '',
    examples: null,
    tests: function (ext) {
    },
}, $.fn);
function Checked() {
    var anyChecked = false;
    this.each(function () {
        var thisJQuery = $(this);
        if (thisJQuery && thisJQuery[0] && thisJQuery[0].checked['checked'])
            anyChecked = true;
    });
    return anyChecked;
}
singJQuery.method('allVisible', AllVisible, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: '',
    examples: null,
    tests: function (ext) {
    },
}, $.fn);
function AllVisible() {
    var allVisible = true;
    this.each(function () {
        var opacity = $(this).attr('opacity');
        if (opacity == '0') {
            allVisible = false;
        }
        if ($(this).css('display') == 'none') {
            allVisible = false;
        }
    });
    return allVisible;
}
singJQuery.method('findIDNameSelector', FindIDNameSelector, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: '',
    examples: null,
    tests: function (ext) {
    },
}, $.fn);
function FindIDNameSelector(name) {
    var target = $();
    try {
        target = $(this).find('#' + name);
    }
    catch (ex) {
    }
    if (target.length == 0)
        try {
            target = $(this).find('[name=' + name + ']');
        }
        catch (ex) {
        }
    if (target.length == 0)
        try {
            target = $(this).find(name);
        }
        catch (ex) {
        }
    return target || $();
}
singJQuery.method('actionIf', ActionIf, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: '',
    examples: null,
    tests: function (ext) {
    },
}, $.fn);
function ActionIf(name) {
    var target = $(this);
    var ifTargetName = target.attr(name + '-if');
    // If there's no target, there's no condition to match. Always true.
    if (!ifTargetName)
        return true;
    var ifTarget = $('body').findIDNameSelector(ifTargetName);
    var targetValue = (target.attr(name + '-if-value') || '');
    var operation = function (a, b) {
        return a == b;
    };
    if (targetValue.indexOf('!=') == 0) {
        operation = function (a, b) {
            return a != b;
        };
        targetValue = targetValue.substr(2);
    }
    else if (targetValue.indexOf('>=') == 0) {
        operation = function (a, b) {
            return parseFloat(a) >= parseFloat(b);
        };
        targetValue = parseFloat(targetValue.substr(2));
    }
    else if (targetValue.indexOf('<=') == 0) {
        operation = function (a, b) {
            return parseFloat(a) <= parseFloat(b);
        };
        targetValue = parseFloat(targetValue.substr(2));
    }
    else if (targetValue.indexOf('><') == 0) {
        operation = function (a, b) {
            return parseFloat(a) >= parseFloat(b[0]) && parseFloat(a) <= parseFloat(b[1]);
        };
        targetValue = targetValue.substr(2);
        targetValue = [
            targetValue.split(',')[0],
            targetValue.split(',')[1],
        ];
    }
    else if (targetValue.indexOf('<>') == 0) {
        operation = function (a, b) {
            return parseFloat(a) <= parseFloat(b[0]) || parseFloat(a) >= parseFloat(b[1]);
        };
        targetValue = targetValue.substr(2);
        targetValue = [
            targetValue.split(',')[0],
            targetValue.split(',')[1],
        ];
    }
    else if (targetValue.indexOf(',') > 0) {
        operation = function (a, b) {
            return b.indexOf(a) >= 0;
        };
        targetValue = targetValue.split(',');
    }
    else if (targetValue.indexOf('!') == 0) {
        operation = function (a, b) {
            return parseFloat(a) != parseFloat(b);
        };
        targetValue = targetValue.substr(1);
    }
    else if (targetValue.indexOf('<') == 0) {
        operation = function (a, b) {
            return parseFloat(a) < parseFloat(b);
        };
        targetValue = parseFloat(targetValue.substr(1));
    }
    else if (targetValue.indexOf('>') == 0) {
        operation = function (a, b) {
            return parseFloat(a) > parseFloat(b);
        };
        targetValue = parseFloat(targetValue.substr(1));
    }
    if (ifTarget.length == 0) {
        return false;
    }
    else {
        var val = ifTarget.val();
        if (!targetValue) {
            if (ifTarget.attr('type') == 'checkbox')
                return ifTarget.checked();
            if (ifTarget.attr('type') == 'radio')
                return ifTarget.filter(':checked').length > 0;
            return val != null && val != '';
        }
        else {
            // Radio values can be combined with the use of custom numeric operators
            if (ifTarget.attr('type') == 'radio')
                return operation(ifTarget.filter(':checked').val(), targetValue);
            return operation(val, targetValue);
        }
    }
}
;
singJQuery.method('defer', Defer, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    aliases: ['wait'],
    examples: null,
    tests: function (ext) {
    },
});
function Defer(deferFunc) {
    if (deferFunc)
        setTimeout(deferFunc, 0);
}
singJQuery.method('hasAttr', JQueryHasAttr, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    tests: function (ext) {
    },
}, $.fn);
function JQueryHasAttr(name) {
    return $(this).attr(name) !== undefined;
}
singJQuery.method('outerHtml', JQueryOuterHtml, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    tests: function (ext) {
    },
}, $.fn);
function JQueryOuterHtml() {
    if (!this || this.length == 0) {
        return '';
    }
    else {
        return this[0].outerHTML;
    }
}
singJQuery.method('innerHtml', JQueryInnerHtml, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    tests: function (ext) {
    },
}, $.fn);
function JQueryInnerHtml() {
    if (!this || this.length == 0) {
        return '';
    }
    else {
        return this[0].innerHTML;
    }
}
// https://github.com/moagrius/isOnScreen
singJQuery.method('isOnScreen', JQueryIsOnScreen, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    tests: function (ext) {
    },
}, $.fn);
function JQueryIsOnScreen(x, y) {
    if (x === void 0) { x = 1; }
    if (y === void 0) { y = 1; }
    var win = $(window);
    var viewport = {
        top: win.scrollTop(),
        left: win.scrollLeft(),
        right: 0,
        bottom: 0,
    };
    viewport.right = viewport.left + win.width();
    viewport.bottom = viewport.top + win.height();
    var height = this.outerHeight();
    var width = this.outerWidth();
    if (!width || !height) {
        return false;
    }
    var bounds = this.offset();
    bounds.right = bounds.left + width;
    bounds.bottom = bounds.top + height;
    var visible = (!(viewport.right < bounds.left || viewport.left > bounds.right || viewport.bottom < bounds.top || viewport.top > bounds.bottom));
    if (!visible) {
        return false;
    }
    var deltas = {
        top: Math.min(1, (bounds.bottom - viewport.top) / height),
        bottom: Math.min(1, (viewport.bottom - bounds.top) / height),
        left: Math.min(1, (bounds.right - viewport.left) / width),
        right: Math.min(1, (viewport.right - bounds.left) / width)
    };
    return (deltas.left * deltas.right) >= x && (deltas.top * deltas.bottom) >= y;
}
;
/// <reference path="../definitions/jquery.d.ts" />
/// <reference path="../definitions/jqueryui.d.ts" />
/// <reference path="../definitions/jquery.cookie.d.ts" />
/// <reference path="../definitions/jquery.timepicker.d.ts" />
/// <reference path="../definitions/chance.d.ts" />
// #region Comments
//////////////////////////////////////////////////////
//
// HTML Extensions
//
//
// Action Conditions
// All actions are able to be made conditional using attributes.
//
// *[<action>-if]
// The ID or Name or Selector of the value to look for. If you only want to check for the presence of a value or a checkbox being checked
// use <action>-if without <action>-if-value
// *[<action>-if-value]
// Requires a specific string or value to be present
// 
// ex. by ID        <action>-if="checkfield5"
// ex. by Name      <action>-if="valuename"
// ex. by Selector  <action>-if="form.class .class2 input"
//
// Numeric operations: 
// Prefix a number with an operation to compare it 
//
// >=                           ex. <action>-if-value=">=5"
// >                            ex. <action>-if-value=">5"
// <                            ex. <action>-if-value="<5"
// <=                           ex. <action>-if-value="<=5"
// !=                           ex. <action>-if-value="!=5"
// !                            ex. <action>-if-value="!5"
// (leave blank for == )        ex. <action>-if-value="5"
//
//
// Range operations:
// >< Inclusion                 ex. <action>-if-value="><5,10"
// <> Exclusion                 ex. <action>-if-value="<>2,100"
//
// List operations
// ,                            ex. <action>-if-value="2,4,6,8"
//                              ex. <action>-if-value="eggs,bacon,ham"
//
//////////////////////////////////////////////////////
//
// img[error-src]
// If an image loads with an error its error-src url will be used
//
// *[focus-first]
// When the page loads the first control with this tag will be focesed
//
//////////////////////////////////////////////////////
//
// *[go-to-remember-page]
// Triggers navigation to remembered page (if enabled)
//
// *[enable-remember-page]
// Enables navigation to remembered page (log in screen)
//
// *[remember-page]
// Triggers saving of current page
//
//////////////////////////////////////////////////////
// Click Actions
//
// *[click-show]
// *[click-show-if]                 (optional)
// *[click-show-if-value]           (optional)
// When clicked, the target(s) with the passed ID, Name or Selector will be shown
//
// *[click-hide]
// *[click-hide-if]                 (optional)
// *[click-hide-if-value]           (optional)
// When clicked, the target(s) with the passed ID, Name or Selector will be hidden
//
// *[click-toggle]
// *[click-toggle-if]               (optional)
// *[click-toggle-if-value]         (optional)
// When clicked, the target(s) with the passed ID, Name or Selector visibility will be toggled
//
// *[click-fade-in]
// *[click-fade-in-if]              (optional)
// *[click-fade-in-if-value]        (optional)
// When clicked, the target(s) with the passed ID, Name or Selector will be faded in
//
// *[click-fade-out]
// *[click-fade-out-if]             (optional)
// *[click-fade-out-if-value]       (optional)
// When clicked, the target(s) with the passed ID, Name or Selector will be faded out
//
// *[click-fade-toggle]
// *[click-fade-toggle-if]          (optional)
// *[click-fade-toggle-if-value]    (optional)
// When clicked, the target(s) with the passed ID, Name or Selector visibility will be toggled
//
// *[click-add-class]
// *[click-add-class-target]        (optional, default is self)
// *[click-add-class-if]            (optional)
// *[click-add-class-if-value]      (optional)
// Adds a css class or classes provided in the attribute 'click-add-class'
// The default target is the element itself, optionally 'click-add-class-target' will direct the 
// change to the ID, Name or Selector target.
//
// *[click-remove-class]
// *[click-remove-class-target]     (optional, default is self)
// *[click-remove-class-if]         (optional)
// *[click-remove-class-if-value]   (optional)
// Removes a css class or classes provided in the attribute 'click-remove-class'
// The default target is the element itself, optionally 'click-remove-class-target' will direct the 
// change to the ID, Name or Selector target.
//
// *[click-toggle-class]
// *[click-toggle-class-target]     (optional, default is self)
// *[click-toggle-class-if]         (optional)
// *[click-toggle-class-if-value]   (optional)
// Toggles a css class or classes provided in the attribute 'click-toggle-class'
// The default target is the element itself, optionally 'click-toggle-class-target' will direct the 
// change to the ID, Name or Selector target.
// 
//
// TODO: Write
// *[click-animate]
// *[click-animate-target]          (optional, default is self)
// *[click-animate-duration]        (optional)
// *[click-animate-easing]          (optional)
// *[click-animate-if]              (optional)
// *[click-animate-if-value]        (optional)
//
// TODO: Write
// *[click-scroll-to]
// *[click-scroll-to-if]              (optional)
// *[click-scroll-to-if-value]        (optional)
//
// TODO: Write
// *[click-text]
// *[click-text-target]             (optional, default is self)
// *[click-text-if]                 (optional)
// *[click-text-if-value]           (optional)
// 
// TODO: Write
// *[click-html]
// *[click-html-target]             (optional, default is self)
// *[click-html-if]                 (optional)
// *[click-html-if-value]           (optional)
//
//////////////////////////////////////////////////////
//
// CSS Class Settings
//
// TODO: Write
// *[class-if]
// *[class-if-value]
//
// Attribute setting
//
// TODO: Write
// *[attr]
// *[attr-target]
// *[attr-if]
// *[attr-if-value]
//
//////////////////////////////////////////////////////
//
// Boolean Property Change Actions
//
// *[show-if]
// *[show-if-value]
//
// *[hide-if]
// *[hide-if-value]
//
// *[enabled-if]
// *[enabled-if-value]
//
// *[disabled-if]
// *[disabled-if-value]
// TODO test
//
// *[readonly-if]
// *[readonly-if-value]
// TODO test
//
// *[selected-if]
// *[selected-if-value]
// TODO test
//
// *[checked-if]
// *[checked-if-value]
//
//*[ctrl-href]
//*[shift-href]
//*[alt-href]
//*[double-href]
// TODO: test
//*[key-bind-click]
//#key-bind-page-tip
//////////////////////////////////////////////////////
//
// Field Extensions
// TODO: Test
//.tab-container *[href]
//.datepicker
//.timepicker
//.spinner-int
//.select-list
//.tab-container
//.spinner-money
//.int-range
//.spinner-decimal
//
//////////////////////////////////////////////////////
// #endregion Comments
var singHTML = singString.addModule(new sing.Module('HTML', String));
singHTML.method('textToHTML', StringTextToHTML, {
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
singHTML.method('stripHTML', StringStripHTML, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    },
});
function StringStripHTML() {
    var out = this;
    var pattern = /.*\<(.+)\>.*/;
    out.replaceRegExp(pattern, / /);
    return out;
}
singHTML.method('getAttributes', GetAttributes, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    tests: function (ext) {
    },
}, $.fn);
function GetAttributes() {
    var thisJQuery = this;
    var attrs = [];
    var a = thisJQuery[0];
    thisJQuery.each(function (item) {
        var thisHtml = this;
        var attrOut = [];
        var props = $.objProperties(thisHtml.attributes);
        for (var i = 0; i < props.length; i++) {
            if (props[i].key != 'length')
                attrOut.push({ key: props[i].key, value: (props[i].value) });
        }
        if (attrOut.length > 0)
            attrs.push(attrOut);
    });
    if (attrs.length > 1)
        return attrs.collect(function (item) {
            return item.collect(function (item2) {
                return {
                    name: item2.value.nodeName,
                    value: item2.value.nodeValue,
                };
            });
        });
    if (attrs.length == 1)
        return attrs[0].collect(function (item) {
            return {
                name: item.value.nodeName,
                value: item.value.nodeValue,
            };
        });
    if (attrs.length == 0)
        return [];
}
////////////////////////////////////////////////////////////////////////////////////////////////////
function InitHTMLExtensions() {
    InitKeyBindClick();
    InitRememberPage();
    InitClickActions();
    InitPropertyIf();
    $('ul#menu a').each(function () {
        if (document.URL.indexOf($(this).attr('href')) > 0) {
            $('.active-page').removeClass('active-page');
            $(this).addClass('active-page');
        }
    });
    $('*[focus-first]').each(function () {
        var target = $(this).attr('focus-first');
        var targets = $(this).find(target);
        if (targets && targets.length > 0)
            targets[0].focus();
    });
    $('*[click-animate]').each(function () {
        var element = $(this);
        var animation = element.attr('click-animate');
        var duration = element.attr('click-animate-duration') || null;
        if (duration)
            duration = parseFloat(duration);
        var easing = element.attr('click-animate-easing') || null;
        var targetName = element.attr('click-animate-target');
        var target = $('body').findIDNameSelector(targetName);
        if (!target || target.length == 0 || !target.animate)
            target = element;
        element.click(function () {
            var actionIf = element.actionIf('click-animate');
            if (!actionIf)
                return;
            try {
                // parseJSON can't handle double quotes
                animation = animation.replaceAll('\'', '"');
                var animationObject = $.parseJSON(animation);
                target.animate(animationObject, duration, easing);
            }
            catch (ex) {
            }
        });
    });
    $('.close-dialog').each(function () {
        $(this).prepend($("<div class='close-button'><span class='glyphicon'>&#xe014;</span></div>"));
    });
    $('.close-dialog .close-button').click(function () {
        $(this).parent().fadeOut(300);
    });
}
function PropertyIf(propertyName, changeTrue, changeFalse) {
    $('*[' + propertyName + '-if]').each(function () {
        var propertyTarget = $(this);
        var ifTargetName = propertyTarget.attr(propertyName + '-if');
        var ifTarget = $('body').findIDNameSelector(ifTargetName);
        if (!ifTarget || ifTarget.length == 0) {
        }
        else {
            ifTarget.each(function () {
                var valueTarget = $(this);
                var changeFunction = function () {
                    var visible = propertyTarget.actionIf(propertyName);
                    if (visible && changeTrue)
                        changeTrue(propertyTarget);
                    else if (!visible && changeFalse)
                        changeFalse(propertyTarget);
                };
                var events = 'change paste keyup';
                if (valueTarget.attr('type') == 'radio')
                    events = 'change';
                valueTarget.on(events, changeFunction);
                // Sets the value initially
                changeFunction();
            });
        }
    });
}
function InitPropertyIf() {
    PropertyIf('show', function (target) {
        target.show('fast');
    }, function (target) {
        target.hide('fast');
    });
    PropertyIf('hide', function (target) {
        target.hide('fast');
    }, function (target) {
        target.show('fast');
    });
    PropertyIf('enabled', function (target) {
        target.removeAttr('disabled');
    }, function (target) {
        target.attr('disabled', 'disabled');
    });
    PropertyIf('disabled', function (target) {
        target.attr('disabled', 'disabled');
    }, function (target) {
        target.removeAttr('disabled');
    });
    PropertyIf('readonly', function (target) {
        target.attr('readonly', 'readonly');
    }, function (target) {
        target.removeAttr('readonly');
    });
    PropertyIf('selected', function (target) {
        target.attr('selected', 'selected');
    }, function (target) {
        target.removeAttr('selected');
    });
    PropertyIf('checked', function (target) {
        target.attr('checked', 'checked');
    }, function (target) {
        target.removeAttr('checked');
    });
}
function InitClickActions() {
    $('*[click-show]').each(function () {
        var target = $(this).attr('click-show');
        $(this).click(function () {
            var actionIf = $(this).actionIf('click-show');
            if (!actionIf)
                return;
            $('body').findIDNameSelector(target).show('fast');
        });
    });
    $('*[click-hide]').each(function () {
        var target = $(this).attr('click-hide');
        $(this).click(function () {
            var actionIf = $(this).actionIf('click-hide');
            if (!actionIf)
                return;
            $('body').findIDNameSelector(target).hide('fast');
        });
    });
    $('*[click-toggle]').each(function () {
        var target = $(this).attr('click-toggle');
        $(this).click(function () {
            var actionIf = $(this).actionIf('click-toggle');
            if (!actionIf)
                return;
            $('body').findIDNameSelector(target).toggle('fast');
        });
    });
    $('*[click-fade-in]').each(function () {
        var target = $(this).attr('click-fade-in');
        $(this).click(function () {
            var actionIf = $(this).actionIf('click-fade-in');
            if (!actionIf)
                return;
            $('body').findIDNameSelector(target).fadeIn('fast');
        });
    });
    $('*[click-fade-out]').each(function () {
        var target = $(this).attr('click-fade-out');
        $(this).click(function () {
            var actionIf = $(this).actionIf('click-fade-out');
            if (!actionIf)
                return;
            $('body').findIDNameSelector(target).fadeOut('fast');
        });
    });
    $('*[click-fade-toggle]').each(function () {
        var target = $(this).attr('click-fade-toggle');
        target = $('body').findIDNameSelector(target);
        $(this).click(function () {
            var actionIf = $(this).actionIf('click-fade-toggle');
            if (!actionIf)
                return;
            target.each(function () {
                if ($(this).allVisible())
                    $(this).fadeOut('fast');
                else
                    $(this).fadeIn('fast');
            });
        });
    });
    $('*[click-toggle-class]').each(function () {
        var element = $(this);
        var className = element.attr('click-toggle-class');
        var targetName = element.attr('click-toggle-class-target');
        var target = $('body').findIDNameSelector(targetName);
        if (target && target.length == 0)
            target = element;
        element.click(function () {
            var actionIf = element.actionIf('click-toggle-class');
            if (!actionIf)
                return;
            target.toggleClass(className);
        });
    });
    $('*[click-add-class]').each(function () {
        var element = $(this);
        var className = element.attr('click-add-class');
        var targetName = element.attr('click-add-class-target');
        var target = $('body').findIDNameSelector(targetName);
        if (!target || target.length == 0)
            target = element;
        element.click(function () {
            var actionIf = element.actionIf('click-add-class');
            if (!actionIf)
                return;
            target.addClass(className);
        });
    });
    $('*[click-remove-class]').each(function () {
        var element = $(this);
        var className = element.attr('click-remove-class');
        var targetName = element.attr('click-remove-class-target');
        var target = $('body').findIDNameSelector(targetName);
        if (!target || target.length == 0)
            target = element;
        element.click(function () {
            var actionIf = element.actionIf('click-remove-class');
            if (!actionIf)
                return;
            target.removeClass(className);
        });
    });
}
function InitRememberPage() {
    $('*[go-to-remember-page]').each(function () {
        if (!$.cookie)
            return;
        var lastPage = $.cookie('remember-page');
        var go = $.cookie('enable-remember-page') == 'true';
        if (go && lastPage) {
            $.removeCookie('remember-page');
            $.cookie('enable-remember-page', false, { expires: 7, path: '/' });
            document.location.href = lastPage;
        }
    });
    $('*[enable-remember-page]').each(function () {
        $.cookie('enable-remember-page', true, { expires: 7, path: '/' });
    });
    $('*[remember-page]').each(function () {
        $.cookie('enable-remember-page', false, { expires: 7, path: '/' });
        $.cookie('remember-page', document.URL, { expires: 7, path: '/' });
    });
}
var keyCodeToChar = { 8: "Backspace", 9: "Tab", 13: "Enter", 16: "Shift", 17: "Ctrl", 18: "Alt", 19: "Pause/Break", 20: "Caps Lock", 27: "Esc", 32: "Space", 33: "Page Up", 34: "Page Down", 35: "End", 36: "Home", 37: "Left", 38: "Up", 39: "Right", 40: "Down", 45: "Insert", 46: "Delete", 48: "0", 49: "1", 50: "2", 51: "3", 52: "4", 53: "5", 54: "6", 55: "7", 56: "8", 57: "9", 65: "A", 66: "B", 67: "C", 68: "D", 69: "E", 70: "F", 71: "G", 72: "H", 73: "I", 74: "J", 75: "K", 76: "L", 77: "M", 78: "N", 79: "O", 80: "P", 81: "Q", 82: "R", 83: "S", 84: "T", 85: "U", 86: "V", 87: "W", 88: "X", 89: "Y", 90: "Z", 91: "Windows", 93: "Right Click", 96: "Numpad 0", 97: "Numpad 1", 98: "Numpad 2", 99: "Numpad 3", 100: "Numpad 4", 101: "Numpad 5", 102: "Numpad 6", 103: "Numpad 7", 104: "Numpad 8", 105: "Numpad 9", 106: "Numpad *", 107: "Numpad +", 109: "Numpad -", 110: "Numpad .", 111: "Numpad /", 112: "F1", 113: "F2", 114: "F3", 115: "F4", 116: "F5", 117: "F6", 118: "F7", 119: "F8", 120: "F9", 121: "F10", 122: "F11", 123: "F12", 144: "Num Lock", 145: "Scroll Lock", 182: "My Computer", 183: "My Calculator", 186: ";", 187: "=", 188: ",", 189: "-", 190: ".", 191: "/", 192: "`", 219: "[", 220: "\\", 221: "]", 222: "'" };
var keyCharToCode = { "Backspace": 8, "Tab": 9, "Enter": 13, "Shift": 16, "Ctrl": 17, "Alt": 18, "Pause/Break": 19, "Caps Lock": 20, "Esc": 27, "Space": 32, "Page Up": 33, "Page Down": 34, "End": 35, "Home": 36, "Left": 37, "Up": 38, "Right": 39, "Down": 40, "Insert": 45, "Delete": 46, "0": 48, "1": 49, "2": 50, "3": 51, "4": 52, "5": 53, "6": 54, "7": 55, "8": 56, "9": 57, "A": 65, "B": 66, "C": 67, "D": 68, "E": 69, "F": 70, "G": 71, "H": 72, "I": 73, "J": 74, "K": 75, "L": 76, "M": 77, "N": 78, "O": 79, "P": 80, "Q": 81, "R": 82, "S": 83, "T": 84, "U": 85, "V": 86, "W": 87, "X": 88, "Y": 89, "Z": 90, "Windows": 91, "Right Click": 93, "Numpad 0": 96, "Numpad 1": 97, "Numpad 2": 98, "Numpad 3": 99, "Numpad 4": 100, "Numpad 5": 101, "Numpad 6": 102, "Numpad 7": 103, "Numpad 8": 104, "Numpad 9": 105, "Numpad *": 106, "Numpad +": 107, "Numpad -": 109, "Numpad .": 110, "Numpad /": 111, "F1": 112, "F2": 113, "F3": 114, "F4": 115, "F5": 116, "F6": 117, "F7": 118, "F8": 119, "F9": 120, "F10": 121, "F11": 122, "F12": 123, "Num Lock": 144, "Scroll Lock": 145, "My Computer": 182, "My Calculator": 183, ";": 186, "=": 187, ",": 188, "-": 189, ".": 190, "/": 191, "`": 192, "[": 219, "\\": 220, "]": 221, "'": 222 };
function InitKeyBindClick() {
    var down = [];
    $('*[ctrl-href]').click(function (e) {
        if (down[keyCharToCode['Ctrl']]) {
            location.href = $(this).attr('ctrl-href');
            e.preventDefault();
        }
    });
    $('*[shift-href]').click(function (e) {
        if (down[keyCharToCode['Shift']]) {
            location.href = $(this).attr('shift-href');
            e.preventDefault();
        }
    });
    $('*[alt-href]').click(function (e) {
        if (down[keyCharToCode['Alt']]) {
            location.href = $(this).attr('alt-href');
            e.preventDefault();
        }
    });
    $('*[double-href]').on('dblclick', function (e) {
        if (down[keyCharToCode['Alt']]) {
            location.href = $(this).attr('alt-href');
            e.preventDefault();
        }
    });
    $(document).keydown(function (e) {
        down[e.keyCode] = true;
        $('*[key-bind-click]').each(function () {
            var keyCode = $(this).attr('key-bind-click');
            if (keyCode.indexOf('+') > 0 && keyCode.indexOf('+') < keyCode.length - 1) {
                var key1 = parseInt(keyCode.substr(0, keyCode.indexOf('+')));
                var key2 = parseInt(keyCode.substr(keyCode.indexOf('+') + 1));
                if (!key1)
                    key1 = keyCharToCode[keyCode.substr(0, keyCode.indexOf('+'))];
                if (!key2)
                    key2 = keyCharToCode[keyCode.substr(keyCode.indexOf('+') + 1)];
                if (down[key1] && e.keyCode == key2) {
                    if ($(this).attr('href'))
                        location.href = $(this).attr('href');
                    else
                        $(this).click();
                    e.preventDefault();
                }
            }
            else {
                var key1 = keyCode.tryToNumber(null);
                if (!key1)
                    key1 = keyCharToCode[keyCode];
                if (e.keyCode == key1) {
                    if ($(this).attr('href'))
                        location.href = $(this).attr('href');
                    else
                        $(this).click();
                    e.preventDefault();
                }
            }
        });
    }).keyup(function (e) {
        down[e.keyCode] = false;
    });
    var KeyBindTip = '';
    $('*[key-bind-click]').each(function () {
        var keyCode = $(this).attr('key-bind-click');
        var commandName = $(this).attr('key-bind-click-name');
        var href = $(this).attr('href');
        var id = $(this).attr('id');
        if (!commandName)
            return;
        if (keyCode.indexOf('+') > 0 && keyCode.indexOf('+') < keyCode.length - 1) {
            var key1 = keyCode.substr(0, keyCode.indexOf('+')).tryToNumber(null);
            var key2 = keyCode.substr(keyCode.indexOf('+') + 1).tryToNumber(null);
            if (!key1)
                key1 = keyCharToCode[keyCode.substr(0, keyCode.indexOf('+'))];
            if (!key2)
                key2 = keyCharToCode[keyCode.substr(keyCode.indexOf('+') + 1)];
            if (href)
                commandName = "<a style='cursor: pointer;' onclick='location.href = \"" + href + "\";'>" + commandName + "</a>";
            else if (id)
                commandName = "<a style='cursor: pointer;' onclick='$(\"#" + id + "\").click();'>" + commandName + "</a>";
            KeyBindTip += "<b>" + keyCodeToChar[key1] + "+" + keyCodeToChar[key2] + "</b> - " + commandName;
            KeyBindTip += "<br>";
        }
        else {
            var key1 = keyCode.tryToNumber(null);
            if (!key1)
                key1 = keyCharToCode[keyCode];
            if (href)
                commandName = "<a style='cursor: pointer;' onclick='location.href = \"" + href + "\";'>" + commandName + "</a>";
            else if (id)
                commandName = "<a style='cursor: pointer;' onclick='$(\"#" + id + "\").click();'>" + commandName + "</a>";
            KeyBindTip += "<b>" + keyCodeToChar[key1] + "</b> - " + commandName;
            KeyBindTip += "<br>";
        }
    });
    if (KeyBindTip)
        $("#key-bind-page-tip").html(KeyBindTip);
    else
        $("#key-bind-page-tip").parent().hide();
}
function InitFields() {
    // Adds the tab id to all href in the tab container
    $('.tab-container *[href]').each(function () {
        var href = $(this).attr('href');
        if (href.indexOf('#') < 0) {
            $(this).attr('href', href + '#' + $(this).parent('.ui-tabs-panel').attr('id'));
        }
    });
    $('#randomize-fields').click(function () {
        RandomFields();
    });
    $('.datepicker').datepicker();
    $('.timepicker').timepicker({ 'step': 15 });
    $('.spinner-int').spinner();
    $('.select-list').selectmenu();
    $('.tab-container').tabs();
    $('.spinner-money').spinner({
        min: 0,
        max: 1000000,
        step: 1,
        start: 1000,
        numberFormat: "C"
    });
    $("img[error-src]").error(function () {
        $(this).attr('src', $(this).attr('error-src'));
    });
    $('.int-range').each(function () {
        var val = parseInt($(this).attr('value'));
        var minimum = parseInt($(this).attr('minimum'));
        var maximum = parseInt($(this).attr('maximum'));
        if (val <= minimum || isNaN(val))
            val = minimum;
        if (val >= maximum)
            val = maximum;
        if (val && !isNaN(val)) {
            $('#' + $(this).attr('target')).val(val.toString());
            $('#' + $(this).attr('text-target')).html(val.toString());
            $(this).slider({
                range: "min",
                min: minimum,
                max: maximum,
                value: val,
                slide: function (event, ui) {
                    $('#' + $(this).attr('target')).val(ui.value);
                    $('#' + $(this).attr('text-target')).html(ui.value);
                },
                change: function (event, ui) {
                    $('#' + $(this).attr('target')).val(ui.value);
                    $('#' + $(this).attr('text-target')).html(ui.value);
                }
            });
        }
        //                $('#' + $(this).attr('target')).val($(this).slider("value"));
        //                $('#' + $(this).attr('text-target')).val($(this).slider("value"));
    });
    $(".spinner-decimal").spinner({
        step: 0.01,
        numberFormat: "n"
    });
}
function RandomFields() {
    $('.field[data-type-name]').each(function () {
        var ObjectType = $(this).attr('data-object-type');
        var DataTypeName = $(this).attr('data-type-name');
        var Maximum = parseFloat($(this).attr('maximum'));
        var Minimum = parseFloat($(this).attr('minimum'));
        var Object = null;
        var chance = new Chance(Math.random);
        if (DataTypeName == 'MultilineText') {
            Object = chance.paragraph({ sentences: 6 });
            $(this).find('textarea').val(Object);
            return;
        }
        else if (ObjectType == 'System.String') {
            Object = chance.string();
        }
        if (ObjectType == 'System.Nullable`1[System.Int32]' || ObjectType == 'System.Int32') {
            if (Maximum && Minimum) {
                Object = chance.integer({ min: Minimum, max: Maximum });
                $(this).find('.int-range').slider('value', Object);
                return;
            }
            else
                Object = chance.integer();
        }
        if (ObjectType == 'System.Nullable`1[System.Guid]' || ObjectType == 'System.Guid') {
            Object = chance.guid();
        }
        if (ObjectType == 'System.Nullable`1[System.DateTime]' || ObjectType == 'System.DateTime') {
            if (DataTypeName == 'Date') {
                Object = chance.date({ string: true });
            }
            else if (DataTypeName == 'Time') {
                Object = chance.hour({ twentyfour: true }) + ':' + chance.minute() + ":" + chance.second();
            }
            else if (DataTypeName == 'DateTime') {
                Object = chance.date({ string: true }) + " " + chance.hour({ twentyfour: true }) + ':' + chance.minute() + ":" + chance.second();
            }
        }
        if (DataTypeName == 'PhoneNumber') {
            Object = chance.phone();
        }
        if (DataTypeName == 'EmailAddress') {
            Object = chance.email();
        }
        if (DataTypeName == 'CreditCard') {
            Object = chance.cc();
        }
        if (DataTypeName == 'PostalCode') {
            Object = chance.postal();
        }
        if (DataTypeName == 'ImageUrl') {
            Object = "https://placekitten.com/g/" + chance.integer({ min: 200, max: 500 }) + '/' + chance.integer({ min: 200, max: 500 });
        }
        if (DataTypeName == 'Url') {
            Object = chance.domain();
        }
        if (ObjectType == 'System.Nullable`1[System.TimeSpan]' || ObjectType == 'System.TimeSpan') {
        }
        if (ObjectType == 'System.Nullable`1[System.Boolean]' || ObjectType == 'System.Boolean') {
            $(this).find('input[type=radio]').each(function () {
                if (chance.bool()) {
                    $(this).click();
                }
            });
        }
        if (ObjectType == 'System.Nullable`1[System.Single]' || ObjectType == 'System.Single') {
        }
        if ($(this).find('select option').length > 0) {
            var max = $(this).find('select option').length;
            var selection = chance.integer({ min: 0, max: max - 1 });
            $(this).find('option')[selection].click();
        }
        if ($(this).find('ui-menu ui-menu-item').length > 0) {
            var max = $(this).find('ui-menu ui-menu-item').length;
            var selection = chance.integer({ min: 0, max: max - 1 });
            $(this).find('ui-menu ui-menu-item')[selection].click();
        }
        if (Object) {
            $(this).find('input').val(Object).change();
        }
    });
}
/// <reference path="singularity-core.ts"/>
var singDocs = singCore.addModule(new sing.Module('Documentation', Singularity));
singDocs.ignoreUnknown('ALL');
singDocs.method('getDocs', SingularityGetDocs);
function SingularityGetDocs(funcName, includeCode, includeDocumentation) {
    if (includeCode === void 0) { includeCode = false; }
    if (includeDocumentation === void 0) { includeDocumentation = true; }
    sing.tests.resolveTests();
    var featuresCount = 0;
    var featuresFound = 0;
    var featuresHaveTests = 0;
    var featuresNeedTests = 0;
    var documentaionCount = 0;
    var documentaionFound = 0;
    var testsFound = 0;
    var testsPassed = 0;
    var header = '';
    if (!funcName || funcName == '' || funcName == 'all')
        header = sing.summary + '\r\n\r\n';
    var out = '';
    $.objEach(sing.methods, function (key, ext, index) {
        var mod = sing.modules[ext.moduleName];
        if (funcName && funcName.lower() != '' && funcName.lower() != 'all' && !ext.name.lower().startsWith(funcName.lower()))
            return;
        if (ext.isAlias) {
            return;
        }
        featuresCount += 1; // method
        if (mod.requiredUnitTests)
            featuresNeedTests++;
        if (mod.requiredDocumentation)
            documentaionCount += 5; // documentation
        if (ext.method)
            featuresFound++;
        if (ext.details) {
            if (ext.details.summary && mod.requiredDocumentation)
                documentaionFound++;
            if (ext.details.parameters && mod.requiredDocumentation)
                documentaionFound++;
            if (ext.details.returns && mod.requiredDocumentation)
                documentaionFound++;
            if (ext.details.returnTypeName && mod.requiredDocumentation)
                documentaionFound++;
            if (ext.details.examples && ext.details.examples.length > 0 && mod.requiredDocumentation)
                documentaionFound++;
            if (ext.details.unitTests && ext.details.unitTests.length > 0 && mod.requiredUnitTests) {
                featuresHaveTests++;
            }
        }
        var line = '------------------------------------------------------------------------------------';
        if (ext.details) {
            // Don't display details for alias functions, aliases are listed under the main function
            if (ext.isAlias && includeDocumentation == true) {
                return;
            }
            out += '\r\n';
            var functionDef = '';
            /*
            ((ext.details.returnTypeName || '') + ' function(').pad(20, 'r') +
         ((ext.details && ext.details.parameters) ? ext.details.parameters.collect(function (item, i) {
             var TypeNames = item.types.collect(function (t) { return t.name; }).join(', ');
             return '[' + TypeNames + '] ' + item.name;
         }).join(', ') : '') + ')' +
            ' { ... } ';
            */
            out += [
                line,
                ext.methodCall.pad(40) + (!ext.method ? ' -- NOT IMPLEMENTED' : functionDef).pad(40, Direction.r),
                line,
                (ext.details.summary ? ('\r\n    Summary: \r\n' + ext.details.summary) : ''),
                (ext.details.parameters && ext.details.parameters.length == 0 ? '\r\n    Parameters: None\r\n' : ''),
                (ext.details.parameters && ext.details.parameters.length > 0 ? ('\r\n    Parameters:\r\n' + ext.details.parameters.collect(function (item, j) {
                    return (' #' + (j + 1)).pad(10) + 'Name:    ' + item.name + '\r\n' + (item.required != true ? '              :    OPTIONAL \r\n' : '') + (item.isMulti == true ? '              :    Multi-parameter \r\n' : '') + (item.defaultValue != undefined ? ' Default Value:    ' + $.toStr(item.defaultValue, true) + '\r\n' : '') + '         Types:    [' + item.types.collect(function (a) {
                        return a.name;
                    }).join(', ') + '] \r\n' + '   Description:    ' + item.description + '\r\n\r\n';
                }).joinLines() + '\r\n') : ''),
                ext.details.returnTypeName ? ('\r\n    Return Type: ' + ext.details.returnTypeName + '\r\n') : '',
                (ext.details.aliases && ext.details.aliases.length > 0 ? ('\r\n    Aliases: \r\n' + ext.details.aliases.collect(function (alias, i) {
                    return ''.pad(13) + ext.methodCall + '.' + alias;
                }).join(', ') + '\r\n\r\n') : ''),
                ext.details.returns ? ('\r\n    Returns: \r\n' + ext.details.returns + '\r\n\r\n') : '',
                (ext.details.examples ? ('\r\n    Examples: \r\n' + ext.details.examples.joinLines()) : ''),
                (ext.method && includeCode ? ('\r\n    Method Code: \r\n\r\n' + ext.method.toString()) : '')
            ].joinLines().replaceAll('\r\n\r\n\r\n', '\r\n\r\n');
            out += '\r\n';
            if (ext.details.unitTests && ext.details.unitTests.length > 0) {
                out += '    Test Requirements: \r\n';
                var methodTestsFound = 0;
                var methodTestsPassed = 0;
                for (var i = 0; i < sing.methods[ext.name].details.unitTests.length; i++) {
                    methodTestsFound++;
                    testsFound++;
                    var test = sing.methods[ext.name].details.unitTests[i];
                    if (!test) {
                        continue;
                    }
                    out += '        ' + (test.requirement || '') + '\r\n';
                    try {
                        var testPasses = test.testFunc();
                        if (testPasses == true || testPasses === undefined || testPasses === null) {
                            testsPassed++;
                            methodTestsPassed++;
                        }
                        else {
                            out += '        ' + (testPasses ? "" : "").pad(50) + ' TEST CASE FAILS \r\n\r\n';
                        }
                    }
                    catch (ex) {
                        out += '        ' + ext.name.pad(50) + 'TEST CASE FAILS \r\n\r\n';
                    }
                }
                if (methodTestsFound > 0) {
                    if (methodTestsFound == methodTestsPassed) {
                        out += '----' + '\r\nAll Test Cases Passed\r\n\r\n';
                    }
                    else {
                        out += '----' + methodTestsPassed + ' / ' + methodTestsFound + ' (' + methodTestsPassed.percentOf(methodTestsFound, 0, true) + ') Test Cases Passed\r\n\r\n';
                    }
                }
            }
        }
        else {
            out += '\r\n';
            out += line + '\r\n';
            out += ext.name + '\r\n';
            out += line + '\r\n';
            out += '\r\n';
        }
    });
    if (!includeDocumentation) {
        out = '';
    }
    var totalFound = featuresFound + documentaionFound + testsPassed + featuresHaveTests;
    var totalCount = featuresCount + documentaionCount + testsFound + featuresNeedTests;
    var leftSpace = 40;
    header += '\r\n';
    if (featuresFound != 0 || featuresCount != 0)
        header += 'Methods Implemented:      ' + (featuresFound + ' / ' + featuresCount).pad(leftSpace, Direction.r) + ' (' + featuresFound.percentOf(featuresCount, 0, true) + ')' + '\r\n';
    if (featuresHaveTests != 0 || featuresNeedTests != 0)
        header += 'Unit Tests Implemented:   ' + (featuresHaveTests + ' / ' + featuresNeedTests).pad(leftSpace, Direction.r) + ' (' + featuresHaveTests.percentOf(featuresNeedTests, 0, true) + ')' + '\r\n';
    if (testsPassed != 0 || testsFound != 0)
        header += 'Unit Tests Passed:        ' + (testsPassed + ' / ' + testsFound).pad(leftSpace, Direction.r) + ' (' + testsPassed.percentOf(testsFound, 0, true) + ')' + '\r\n';
    if (documentaionFound != 0 || documentaionCount != 0)
        header += 'Documentation:            ' + (documentaionFound + ' / ' + documentaionCount).pad(leftSpace, Direction.r) + ' (' + documentaionFound.percentOf(documentaionCount, 0, true) + ')' + '\r\n';
    header += '\r\n';
    if (totalFound != 0 || totalCount != 0)
        header += 'Total:                    ' + (totalFound + ' / ' + totalCount).pad(leftSpace, Direction.r) + ' (' + totalFound.percentOf(totalCount, 0, true) + ')' + '\r\n';
    return header + out;
}
;
singDocs.method('getMissing', SingularityGetMissing);
function SingularityGetMissing(funcName) {
    sing.tests.resolveTests();
    var featuresCount = 0;
    var featuresFound = 0;
    var documentaionCount = 0;
    var documentaionFound = 0;
    var header = 'Singularity.TS TypeScript, JavaScript, jQuery, HTML, Extension Method Engine & Library\r\n';
    var out = '';
    $.objEach(sing.methods, function (key, ext, i) {
        if (funcName && funcName.lower() != '' && funcName.lower() != 'all' && !ext.name.lower().contains(funcName.lower()))
            return;
        featuresCount += 1; // method
        documentaionCount += 5 + 1; // test cases
        if (ext.method)
            featuresFound++;
        else
            out += ext.name + ' Method Implementation \r\n';
        if (ext.details) {
            if (ext.details.summary)
                documentaionFound++;
            else
                out += ext.name + ' Summary \r\n';
            if (ext.details.parameters)
                documentaionFound++;
            else
                out += ext.name + ' Parameters \r\n';
            if (ext.details.returnTypeName)
                documentaionFound++;
            else
                out += ext.name + ' Return Type \r\n';
            if (ext.details.returns)
                documentaionFound++;
            else
                out += ext.name + ' Returns \r\n';
            if (ext.details.examples)
                documentaionFound++;
            else
                out += ext.name + ' Examples \r\n';
            if (ext.details.unitTests && ext.details.unitTests.length > 0)
                documentaionFound++;
            else
                out += ext.name + ' Tests \r\n';
        }
    });
    header += '\r\n' + 'Methods Implemented:      ' + featuresFound + ' / ' + featuresCount + ' (' + Math.round((featuresFound / featuresCount) * 100) + '%) \r\n' + 'Documentation:            ' + documentaionFound + ' / ' + documentaionCount + ' (' + Math.round((documentaionFound / documentaionCount) * 100) + '%) \r\n';
    return header + out;
}
;
singDocs.method('getSummary', SingularityGetSummary);
function SingularityGetSummary(funcName, includeFunctions) {
    if (funcName === void 0) { funcName = 'all'; }
    if (includeFunctions === void 0) { includeFunctions = true; }
    var out = sing.getDocs(funcName, false, false);
    out += '\r\n';
    if (includeFunctions) {
        $.objEach(sing.methods, function (key, ext, i) {
            if (funcName && funcName.lower() != '' && funcName.lower() != 'all' && !ext.name.lower().contains(funcName.lower()))
                return;
            out += '\r\n' + (ext.name + ' ').pad(30);
            out += ((ext.details.returnTypeName || '') + ' function(').pad(20, Direction.r);
            out += ((ext.details && ext.details.parameters) ? ext.details.parameters.collect(function (item, i) {
                var TypeNames = item.types.collect(function (a) {
                    return a.name;
                }).join(', ');
                return (i > 0 ? ''.pad(50) : '') + '[' + TypeNames + '] ' + item.name;
            }).join(', \r\n') : '') + ') ' + (ext.details && ext.details.parameters && ext.details.parameters.length > 1 ? '\r\n' + ''.pad(50) : '') + '{ ... } ';
        });
    }
    return out;
}
;
/// <reference path="../definitions/jquery.d.ts" />
/// <reference path="../definitions/jqueryui.d.ts" />
/// <reference path="../definitions/jquery.cookie.d.ts" />
/// <reference path="singularity-enumerable.ts"/>
/// <reference path="singularity-js-number.ts"/>
/// <reference path="singularity-js-string.ts"/>
/// <reference path="singularity-js-array.ts"/>
/// <reference path="singularity-js-function.ts"/>
/// <reference path="singularity-js-boolean.ts"/>
/// <reference path="singularity-jquery.ts"/>
/// <reference path="singularity-html.ts"/>
/// <reference path="singularity-tests.ts"/>
/// <reference path="singularity-doc.ts"/>
// #region Comments
//////////////////////////////////////////////////////
//
// Singularity.TS TypeScript, JavaScript, jQuery, HTML, Extension Method Engine & Library
//
// Unit Tested and Self-Documented -- execute:
//
/*

   // Summary
   sing.getSummary();
   
   // String Summary
   sing.getSummary('String.');

   // All documentation
   sing.getDocs('all');

   // Get documentation for XOR including code.
   sing.getDocs('xor', true);

   // Get documentation for all Array functions
   sing.getDocs('Array.');


*/
//
//////////////////////////////////////////////////////
//
// Code Structure Example 
//
// Extension Structure
//
/*
    {

        name: "[Full Name]",
        shortName: '[Short function name]',
        target: '[Type name]',
        methodCall: '[Type].[Short function Name]([Arguments])' // Ex.  'Boolean.xor([Boolean] b);'

        details: [Extension Details Object],

        // The source method being called
        method: function() { },

        // These are temporarily defined helper methods when passed to the test function
        addTest: function (caller, args, result) { } ,
        addFailsTest:  function (caller, testFunc, result) { },
        addCustomTest: function (caller, args, expectedError, requirement) { },
    }
*/
//
// Extension Details Structure
//
/*
    {
        // Everything is optional.

        // name is set automatically, you don't need to specify it.
        name: '[Method name]'

        summary: '',
        returns: '',
        examples: ['', ...],

        parameters: [
            {
                name: '',

                // List all object types this parameter can accept. If you list Object then validation will be disabled,
                // all values derive from Object
                types: [Object, Array, Number, Function, ...],
                
                // If you set required to true, it will be validated by default.
                // If nothing is passed and no defaultValue is set, then an error will be thrown.
                required: true,

                // If the parameter is null or undefined this value will be automatically substituted
                defaultValue: null,

                description: '',

                auto: {
                    
                    // Triggers the parameter to Resolve. If a function is passed in it will be ran and the result will be used.
                    // See the documentation for $.resolve for more information
                    resolve: false,

                    // Transforms the input parameter based on the function you provide. The return value will be used as the parameter.
                    transform: function(param) { return param; },

                },
            },
            ...
        ],

        // If you specify any aliases they are automatically added to provide identical functionality to the original method.
        aliases: ['Method name alias', ...]

        returnType: Object,
        
        // OPTIONAL Overrides sing.autoDefaults to add automation to the method call
        auto: {

            // Validates the input parameters to ensure they are not empty (based on the parameter.required flag)
            // and that they match one of the types supplied in parameter.types.
            validateInput: true,

            // If you specify a parameter.defaultValue by default it will be used when undefined or null is passed for that parameter
            injectDefaultInputValue: true,

            // If you set this flag to true, this function will ignore all exceptions it generates.
            ignoreErrors: false,
            
            // If you set this flag to true, errors will be logged to the console
            logErrors: false,

            // If you set this value to anything more than 0, the function will be attempted multiple times until it succeeds
            retryTimes: 0,

            // If you set this flag to true, execution start and finish will be logged to the console
            logExecution: false,

            // If you set this flag to true, execution times in milliseconds will be logged to the console
            timeExecution: false,
            
            // If you set this flag to true, method execution will happen asyncronously and an additional callback parameter will be added
            makeAsync: false,

            // If you set this flag to true, method results will be cached based its input values string representaions ($.toStr)
            cacheResults: false,

            // If you set this to anything except undefined, this result will be returned when null or undefined is returned.
            defaultResult: undefined,

            // If you set this to anything except undefined, this result will be returned regardless of the actual return value
            overrideResult: undefined,

            // If you set this flag to true, the result will be returned as either an empty array [] in the case of null or undefined
            // or an array with a single element. If the result is already an array, it won't be modified.
            resultAsArray: false,
        },

        tests: function (ext) {

            ext.addTest(source, [arg1, ...], result, 'Requirement description (optional)');

            ext.addFailsTest(source, [arg1, ...], '[expected error (optional)]', 'Requirement description (optional)');

            ext.addCustomTest(function () {

                // Exmple test [Your Code Here]
                var result = ext.method();

                if (result != 5)
                    return 'Result was not 5';

                // Success: return true or null or undefined
                // Failure: return false or a description of the failure

            }, 'Requirement description (optional)');
        }
    }
*/
//
//
// #endregion Comments
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
var Singularity = (function () {
    function Singularity() {
        this.summary = 'TypeScript, JavaScript, jQuery, HTML Language Extensions';
        this.Module = SingularityModule;
        this.Extension = SingularityMethod;
        this.AutoDefinition = SingularityAutoDefinition;
        this.enableTests = true;
        // Defaults to polyfill behavior, methods won't replace existing ones.
        // Set this to true or 'override: true' in the extension details to enable method overriding
        this.defaultPolyfill = true;
        this.modules = {};
        this.addModule = function (mod) {
            if (this.modules[mod.fullName()] === undefined)
                this.modules[mod.fullName()] = mod;
            return mod;
        };
        this.methods = {};
        this.templates = {};
        this.func = {
            empty: function () {
            },
            identity: function (obj) {
                return obj;
            },
            equals: function (obj, obj2) {
                return obj == obj2;
            },
            increment: function (i) {
                return i + 1;
            },
            booleanNot: function (obj) {
                return !obj;
            },
            toString: function (obj) {
                return obj.toString();
            },
        };
        this.autoDefaults = new SingularityAutoDefinition();
        this.types = {
            Object: {
                typeClass: Object,
                protoType: Object.prototype,
                name: 'Object',
            },
            Boolean: {
                typeClass: Boolean,
                protoType: Boolean.prototype,
                name: 'Boolean',
            },
            Number: {
                typeClass: Number,
                protoType: Number.prototype,
                name: 'Number',
            },
            String: {
                typeClass: String,
                protoType: String.prototype,
                name: 'String',
            },
            Array: {
                typeClass: Array,
                protoType: Array.prototype,
                name: 'Array',
            },
            Function: {
                typeClass: Function,
                protoType: Function.prototype,
                name: 'Function',
            },
            Date: {
                typeClass: Date,
                protoType: Date.prototype,
                name: 'Date',
            },
            $: {
                typeClass: $,
                protoType: $,
                name: 'jQuery',
            }
        };
        this.autoDefault = new SingularityAutoDefinition();
        this.init = function () {
            $.noConflict();
            for (var mod in this.modules) {
                if (this.modules[mod].init)
                    this.modules[mod].init();
            }
        };
        this.ready = function () {
            InitHTMLExtensions();
            InitFields();
        };
        this.getTypeName = function (protoType) {
            if ($.isArray(protoType)) {
                return protoType.collect(sing.getTypeName).join(', ');
            }
            else {
                for (var t in sing.types) {
                    if (sing.types[t].protoType == protoType || sing.types[t].typeClass == protoType)
                        return sing.types[t].name;
                }
                throw 'could not find ' + protoType;
            }
        };
        this.globalResolve = {
            sing: sing,
            '$': $,
        };
        this.templateShownFunctions = [];
        this.templateShown = function (fn) {
            sing.templateShownFunctions.push(fn);
        };
    }
    return Singularity;
})();
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
var SingularityModule = (function () {
    function SingularityModule(name, objectClass, objectPrototype) {
        this.name = name;
        this.objectClass = objectClass;
        this.objectPrototype = objectPrototype;
        this.subModules = [];
        this.methods = [];
        this.ignoreUnknownMembers = [];
        this.addModule = function (mod) {
            mod.parentModule = this;
            this.subModules.push(mod);
            return sing.addModule(mod);
        };
        this.totalMethods = function () {
            var thisModule = this;
            var out = (thisModule.methods || []).count(function (m) {
                if (m.isAlias)
                    return false;
                return true;
            });
            out += thisModule.subModules.count(function (sub) {
                return sub.totalMethods();
            });
            return out;
        };
        this.implementedMethodCount = function () {
            var thisModule = this;
            var out = (thisModule.methods || []).count(function (m) {
                if (m.isAlias)
                    return false;
                return $.isDefined(m.method);
            });
            out += thisModule.subModules.count(function (sub) {
                return sub.implementedMethodCount();
            });
            return out;
        };
        this.implementedMethodTests = function () {
            var thisModule = this;
            sing.tests.resolveTests();
            var out = (thisModule.methods || []).count(function (m) {
                if (m.isAlias)
                    return false;
                if (m.details.unitTests)
                    return (m.details.unitTests.length > 0);
                return false;
            });
            out += thisModule.subModules.count(function (sub) {
                return sub.implementedMethodTests();
            });
            return out;
        };
        this.implementedDocumentation = function () {
            var thisModule = this;
            var out = 0;
            if (thisModule.requiredDocumentation)
                (thisModule.methods || []).each(function (m) {
                    if (m.isAlias)
                        return;
                    out += m.documentationPresent();
                });
            out += thisModule.subModules.count(function (sub) {
                return sub.implementedDocumentation();
            });
            return out;
        };
        this.totalDocumentation = function () {
            var thisModule = this;
            var out = 0;
            if (thisModule.requiredDocumentation)
                (thisModule.methods || []).each(function (m) {
                    if (m.isAlias)
                        return;
                    out += m.documentationTotal();
                });
            out += thisModule.subModules.count(function (sub) {
                return sub.totalDocumentation();
            });
            return out;
        };
        this.passedMethodTests = function () {
            var thisModule = this;
            sing.tests.resolveTests();
            var out = (thisModule.methods || []).count(function (m) {
                if (m.isAlias)
                    return false;
                if (m.details.unitTests)
                    return m.details.unitTests.count(function (test) {
                        if (test.testResult === undefined)
                            test.testFunc();
                        return test.testResult == true;
                    });
                return 0;
            });
            out += thisModule.subModules.count(function (sub) {
                return sub.passedMethodTests();
            });
            return out;
        };
        this.implementedMethodTestsTotal = function () {
            var thisModule = this;
            sing.tests.resolveTests();
            var out = (thisModule.methods || []).count(function (m) {
                if (m.isAlias)
                    return false;
                if (m.details.unitTests)
                    return m.details.unitTests.length;
                return 0;
            });
            out += thisModule.subModules.count(function (sub) {
                return sub.implementedMethodTestsTotal();
            });
            return out;
        };
        this.implementedItems = function () {
            return this.implementedMethodCount() + this.implementedMethodTests() + this.passedMethodTests() + this.implementedDocumentation();
        };
        this.totalItems = function () {
            return this.totalMethods() + this.implementedMethodCount() + this.implementedMethodTestsTotal() + this.totalDocumentation();
        };
        this.uninitializedMethods = [];
        this.requiredDocumentation = true;
        this.requiredUnitTests = true;
        this.method = function (extName, method, details, extendPrototype, prefix) {
            if (extendPrototype === void 0) { extendPrototype = this.objectPrototype; }
            this.uninitializedMethods.push({
                extName: extName,
                method: method,
                details: details,
                extendPrototype: extendPrototype,
                prefix: prefix,
            });
            //    sing.method(this.name, extName, extendPrototype, method, details);
        };
        this.ignoreUnknown = function () {
            var items = [];
            for (var _i = 0; _i < arguments.length; _i++) {
                items[_i - 0] = arguments[_i];
            }
            var thisModule = this;
            thisModule.ignoreUnknownMembers = thisModule.ignoreUnknownMembers || [];
            if (thisModule.ignoreUnknownMembers.length == 1 && thisModule.ignoreUnknownMembers[0] == 'ALL')
                return;
            thisModule.ignoreUnknownMembers = thisModule.ignoreUnknownMembers.concat(items);
            if (items.indexOf('ALL') >= 0)
                thisModule.ignoreUnknownMembers = ['ALL'];
        };
        this.init = function () {
            var thisModule = this;
            for (var i = 0; i < this.uninitializedMethods.length; i++) {
                var methodDetails = this.uninitializedMethods[i];
                var name = methodDetails.extName;
                var extendPrototype = methodDetails.extendPrototype;
                var details = methodDetails.details;
                var prefix = methodDetails.prefix;
                var method = methodDetails.method;
                var fullName = this.fullName();
                if (sing.methods[fullName]) {
                    warn(fullName + '.' + name + ' already exists.');
                    return;
                }
                var methods = [
                    {
                        name: name,
                        target: extendPrototype,
                        method: method
                    }
                ];
                // If there are aliases defined, they will all be added using the same method.
                if (details && details.aliases && details.aliases.length > 0) {
                    for (var j = 0; j < details.aliases.length; j++) {
                        methods.push({
                            name: details.aliases[j],
                            target: extendPrototype,
                            method: method
                        });
                    }
                }
                for (var j = 0; j < methods.length; j++) {
                    var ext = new SingularityMethod(thisModule, details, extendPrototype, fullName, methods[j].name, methods[j].method, prefix);
                    if (!methods[j].target)
                        throw 'could not find target ' + fullName + ' ' + name;
                    if (methods[j].target && (sing.defaultPolyfill || details.override || !methods[j].target[methods[j].name]) && ext.method) {
                        // Defines an Array extension method without corrupting 'for-in'
                        if (methods[j].target === Array.prototype) {
                            if (!Array.prototype[name] && method) {
                                Object.defineProperty(Array.prototype, name, {
                                    enumerable: false,
                                    value: method,
                                });
                            }
                        }
                        else {
                            methods[j].target[methods[j].name] = ext.method;
                        }
                    }
                    sing.methods[fullName + '.' + (!!prefix ? prefix + '.' : '') + methods[j].name] = ext;
                    if (j > 0)
                        sing.methods[fullName + '.' + (!!prefix ? prefix + '.' : '') + methods[j].name].isAlias = true;
                    this.methods.push(ext);
                }
            }
        };
        this.fullName = function () {
            if (this.parentModule)
                return this.parentModule.fullName() + '.' + this.name;
            return this.name;
        };
        if ($.isArray(this.objectClass) && this.objectClass.length > 0) {
            this.trackObjects = this.objectClass;
            this.objectClass = this.objectClass[0];
        }
        this.objectPrototype = this.objectPrototype || (this.objectClass ? this.objectClass.prototype : null);
        this.trackObjects = this.trackObjects || [this.objectPrototype];
        this.methods = this.methods || [];
        this.subModules = this.subModules || [];
    }
    return SingularityModule;
})();
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
var SingularityMethod = (function () {
    function SingularityMethod(methodModule, details, target, moduleName, name, method, prefix) {
        if (details === void 0) { details = {}; }
        this.isAlias = false;
        this.codeLines = 0;
        this.auto = new SingularityAutoDefinition();
        this.toString = function () {
            return this.name;
        };
        this.documentationPresent = function () {
            var out = 0;
            if (!$.isEmpty(this.details.summary))
                out++;
            if (!$.isEmpty(this.details.returns))
                out++;
            if (!$.isEmpty(this.details.returnTypeName))
                out++;
            if (!$.isEmpty(this.details.examples))
                out++;
            if (this.details.parameters != undefined && this.details.parameters != null)
                out++;
            return out;
        };
        this.documentationTotal = function () {
            return 1 + 1 + 1 + 1 + 1; //parameters 
        };
        this.loadAutoIgnoreErrors = function (ext, methods) {
            if (ext.auto.ignoreErrors) {
                var lastMethod_ignoreErrors = methods[methods.length - 1];
                methods.push(function () {
                    try {
                        return lastMethod_ignoreErrors.apply(this, arguments);
                    }
                    catch (ex) {
                        return;
                    }
                });
            }
        };
        this.loadAutoLogErrors = function (ext, methods) {
            if (ext.auto.logErrors) {
                var lastMethod_logErrors = methods[methods.length - 1];
                methods.push(function () {
                    try {
                        return lastMethod_logErrors.apply(this, arguments);
                    }
                    catch (ex) {
                        log(ext.name + ' Error: ' + ex);
                        return;
                    }
                });
            }
        };
        this.loadAutoLogExecution = function (ext, methods) {
            if (ext.auto.logExecution) {
                var lastMethod_logExecution = methods[methods.length - 1];
                methods.push(function () {
                    ////////////////////////////////////////////////////////////
                    // NO Extensions are allowed within this method
                    ////////////////////////////////////////////////////////////
                    var argStr = '';
                    for (var h = 0; h < arguments.length; h++) {
                        argStr += arguments[h];
                        if (h < arguments.length - 1)
                            argStr += ', ';
                    }
                    argStr = '[' + argStr + ']';
                    log('Running:   ' + ext.name + '    Arguments: ' + argStr);
                    var result = lastMethod_logExecution.apply(this, arguments);
                    log('Completed: ' + ext.name + '    Result:    ' + result);
                    return result;
                });
            }
        };
        this.loadAutoTimeExecution = function (ext, methods) {
            if (ext.auto.timeExecution) {
                var lastMethod_timeExecution = methods[methods.length - 1];
                methods.push(function () {
                    ////////////////////////////////////////////////////////////
                    // NO Extensions are allowed within this method
                    ////////////////////////////////////////////////////////////
                    var timeBefore = new Date().valueOf();
                    var result = lastMethod_timeExecution.apply(this, arguments);
                    var timeAfter = new Date().valueOf();
                    var time = timeBefore - timeAfter;
                    if (time < 0)
                        time = 0;
                    log('Completed: ' + ext.name + ' in ' + time + ' MS');
                    return result;
                });
            }
        };
        this.loadAutoDefaultResult = function (ext, methods) {
            if (ext.auto.defaultResult !== undefined) {
                var lastMethod_defaultResult = methods[methods.length - 1];
                methods.push(function () {
                    ////////////////////////////////////////////////////////////
                    // NO Extensions are allowed within this method
                    ////////////////////////////////////////////////////////////
                    var result = lastMethod_defaultResult.apply(this, arguments);
                    if (result === undefined || result === null) {
                        result = ext.auto.defaultResult;
                    }
                    return result;
                });
            }
        };
        this.loadAutoOverrideResult = function (ext, methods) {
            if (ext.auto.overrideResult !== undefined) {
                var lastMethod_overrideResult = methods[methods.length - 1];
                methods.push(function () {
                    ////////////////////////////////////////////////////////////
                    // NO Extensions are allowed within this method
                    ////////////////////////////////////////////////////////////
                    var result = lastMethod_overrideResult.apply(this, arguments);
                    return ext.auto.overrideResult;
                });
            }
        };
        this.loadAutoCacheResults = function (ext, methods) {
            if (this.auto.cacheResults) {
            }
        };
        this.loadAutoResultAsArray = function (ext, methods) {
            if (ext.auto.resultAsArray) {
                var lastMethod_resultAsArray = methods[methods.length - 1];
                methods.push(function () {
                    ////////////////////////////////////////////////////////////
                    // NO Extensions are allowed within this method
                    ////////////////////////////////////////////////////////////
                    var result = lastMethod_resultAsArray.apply(this, arguments);
                    if (!$.isArray(result)) {
                        if (result === null || result === undefined)
                            return [];
                        else
                            return [result];
                    }
                    return result;
                });
            }
        };
        this.loadAutoMakeAsync = function (ext, methods) {
            if (this.auto.makeAsync) {
                this.details.parameters.push({
                    name: 'callback',
                    metod: [Function],
                    description: 'This callback function will be executed when ' + ext.shortName + ' has finished executing. It will be passed the result as its only argument',
                });
                var callbackIndex = ext.details.parameters.length - 1;
                var lastMethod_makeAsync = methods[methods.length - 1];
                methods.push(function () {
                    ////////////////////////////////////////////////////////////
                    // NO Extensions are allowed within this method
                    ////////////////////////////////////////////////////////////
                    var srcThis = this;
                    var args = arguments;
                    setTimeout(function () {
                        var result = lastMethod_makeAsync.apply(srcThis, args);
                        if (args[callbackIndex]) {
                            args[callbackIndex](result);
                        }
                    }, 1);
                });
            }
        };
        this.loadAutoRetry = function (ext, methods) {
            if (this.auto.retryTimes > 0) {
                var lastMethod_retryTimes = methods[methods.length - 1];
                methods.push(function () {
                    for (var attempt = 0; attempt < ext.auto.retryTimes + 1; attempt++) {
                        try {
                            return lastMethod_retryTimes.apply(this, arguments);
                        }
                        catch (ex) {
                            if (attempt == ext.auto.retryTimes - 1)
                                throw 'Failed after ' + (ext.auto.retryTimes + 1) + ' tries. ' + ex;
                        }
                    }
                });
            }
        };
        this.loadInputValidation = function (ext, methods) {
            if (ext.method && ext.details.parameters && ext.details.parameters.length > 0 && (ext.auto.validateInput == true || ext.auto.injectDefaultInputValue == true)) {
                var srcext = ext;
                var lastMethod_validateInput = methods[methods.length - 1];
                methods.push(function () {
                    ////////////////////////////////////////////////////////////
                    // NO Extensions are allowed within ext method
                    ////////////////////////////////////////////////////////////
                    var keys = Object.keys(arguments);
                    var args = [];
                    for (var j = 0; j < keys.length; j++) {
                        var arg = arguments[keys[j]];
                        args.push(arg);
                    }
                    for (var i = 0; i < srcext.details.parameters.length; i++) {
                        var param = srcext.details.parameters[i];
                        var testArg = args[i];
                        // validate params
                        var typeNames = '';
                        var typeNamesArray = [];
                        for (var j = 0; j < param.types.length; j++) {
                            var typeName = sing.getTypeName(param.types[j]).lower();
                            typeNames += typeName;
                            typeNamesArray.push(typeName);
                            if (j < param.types.length - 1)
                                typeNames += ', ';
                        }
                        if (param.required == true) {
                            if (testArg === null || testArg === undefined) {
                                // If a defaultValue is defined, substitute it and continue
                                if (param.defaultValue != null && param.defaultValue != undefined && ext.auto.injectDefaultInputValue == true) {
                                    args[i] = testArg = param.defaultValue;
                                }
                                else if (ext.auto.validateInput == true)
                                    throw ext.moduleName + '.' + ext.shortName + ' Missing Parameter: ' + typeNames + ' ' + param.name + '';
                            }
                        }
                        else if (testArg === null || testArg === undefined) {
                        }
                        if (!param.types || param.types.length == 0 || param.types.indexOf(Object) >= 0) {
                        }
                        else if (ext.auto.validateInput == true) {
                            if ((typeof testArg).lower() == 'object' && typeNamesArray.contains('array') && testArg != null && testArg.length != null && testArg.concat != null) {
                            }
                            else if (!typeNamesArray.contains(typeof testArg)) {
                                if (param.required == true) {
                                    throw ext.moduleName + '.' + ext.shortName + '  Parameter: ' + param.name + ': ' + $.toStr(testArg, true) + ' ' + (typeof testArg).lower() + ' did not match input type ' + $.toStr(typeNamesArray, true) + '.';
                                }
                                else {
                                }
                            }
                        }
                    }
                    return lastMethod_validateInput.apply(this, arguments);
                });
            }
        };
        this.loadMethodCall = function (ext) {
            ext.methodCall = ext.moduleName + '.' + ext.name;
            // Configure type-specific defaults or use the global defaults
            var autoDefault = sing.autoDefault;
            if (sing.types[ext.moduleName] && sing.types[ext.moduleName].autoDefault !== undefined)
                autoDefault = $.extend(true, {}, sing.types[ext.moduleName].autoDefault);
            ext.auto = new SingularityAutoDefinition(autoDefault);
            // Inherits auto values passed using details
            if (ext.details && ext.details.auto) {
                for (var arg in ext.details.auto) {
                    this.auto[arg] = this.details.auto[arg];
                }
                this.details.auto = undefined;
            }
            ext.methodCall += '(';
            if (ext.details && ext.details.parameters) {
                for (var j = 0; j < ext.details.parameters.length; j++) {
                    // TODO FIX
                    // ext.methodCall += '[' + $.toStr(ext.details.parameters[j].types) + '] ';
                    ext.methodCall += ext.details.parameters[j].name;
                    if (j < ext.details.parameters.length - 1)
                        ext.methodCall += ', ';
                }
            }
            ext.methodCall += ');';
        };
        var ext = this;
        this.name = moduleName + '.' + (prefix ? prefix + '.' : '') + name;
        this.shortName = name;
        if (method)
            this.codeLines = method.toString().split('\r\n').length;
        this.moduleName = moduleName;
        this.target = target;
        this.targetType = target;
        this.details = details;
        this.method = method;
        this.methodModule = methodModule;
        this.methodOriginal = method;
        this.prefix = prefix;
        if (this.details.returnType && !this.details.returnType.name) {
            this.details.returnTypeName = sing.getTypeName(this.details.returnType);
        }
        if (details.returnType)
            this.details.returnTypeName = this.details.returnType.name;
        else
            this.details.returnTypeName = 'void';
        this.loadMethodCall(this);
        var methods = [this.method];
        // Validates input fields based on parameter options set in the details
        // Checks that non-optional fields are included and that the inputs passed match one of the parameter types given
        var auto = this.auto;
        this.loadInputValidation(this, methods);
        if (this.auto.ignoreErrors && this.auto.logErrors)
            throw 'Unable to Ignore as well as Log errors.';
        if (this.auto.defaultResult !== undefined && this.auto.overrideResult !== undefined)
            throw 'Unable to set both Default and Override Result.';
        this.loadAutoRetry(this, methods);
        this.loadAutoIgnoreErrors(this, methods);
        this.loadAutoLogErrors(this, methods);
        this.loadAutoLogExecution(this, methods);
        this.loadAutoTimeExecution(this, methods);
        this.loadAutoDefaultResult(this, methods);
        this.loadAutoOverrideResult(this, methods);
        this.loadAutoCacheResults(this, methods);
        this.loadAutoResultAsArray(this, methods);
        this.loadAutoMakeAsync(this, methods);
        this.method = methods[methods.length - 1];
    }
    return SingularityMethod;
})();
var SingularityAutoDefinition = (function () {
    function SingularityAutoDefinition(source) {
        this.validateInput = true;
        this.injectDefaultInputValue = true;
        this.ignoreErrors = false;
        this.logErrors = false;
        this.logExecution = false;
        this.timeExecution = false;
        this.makeAsync = false;
        this.cacheResults = false;
        this.retryTimes = 0;
        this.resultAsArray = false;
        if (source) {
            this.validateInput = source.validateInput;
            this.injectDefaultInputValue = source.injectDefaultInputValue;
            this.ignoreErrors = source.ignoreErrors;
            this.logErrors = source.logErrors;
            this.logExecution = source.logExecution;
            this.timeExecution = source.timeExecution;
            this.cacheResults = source.cacheResults;
            this.retryTimes = source.retryTimes;
            this.resultAsArray = source.resultAsArray;
            this.defaultResult = source.defaultResult;
            this.defaultResult = source.defaultResult;
            this.overrideResult = source.overrideResult;
        }
    }
    return SingularityAutoDefinition;
})();
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
var sing = new Singularity();
sing.globalResolve['sing'] = sing;
var singRoot = sing.addModule(new SingularityModule('Singularity', [Singularity, sing]));
singRoot.method('addModule', sing.addModule);
singRoot.method('totalCodeLines', SingularityTotalCodeLines);
function SingularityTotalCodeLines() {
    var out = 0;
    $.objValues(sing.modules).each(function (mod) {
        if (!mod.parentModule)
            out += mod.totalCodeLines();
    });
    return out;
}
singRoot.method('loadContext', SingularityLoadContext);
function SingularityLoadContext(context) {
    if (context === undefined) {
        context = {};
        context['sing'] = sing;
    }
    context['$context'] = function () {
        return $.objKeys(context);
    };
    context['$global'] = function () {
        return $.objKeys(sing.globalResolve);
    };
    return context;
}
singRoot.method('resolveKey', SingularityResolveKey);
function SingularityResolveKey(key, data, context) {
    var out = undefined;
    try {
        key = key || '';
        key = key.trim();
        if (key == 'sing.tests.testErrors') {
            key = key + '';
            key = key + '';
            key = key + '';
            key = key + ' ';
            key = key + '';
        }
        // fill template, don't resolve;
        if (key.contains(' with '))
            return key;
        var commaSubstitute = '{{;;}}';
        // Empty Array
        if (key == '[]') {
            return [];
        }
        // Empty Object
        if (key == '{}') {
            return {};
        }
        // Numbers
        if (key.isNumeric())
            return key.toNumber();
        // Booleans
        if (key.isBoolean())
            return key.toBoolean();
        // function notation, no arguments
        if (key.hasMatch(/^([^\.\'\",\[\]\(\)]+)\(\)\.?(.*)/)) {
            var methodName = key.match(/^([^\.\'\",\[\]\(\)]+)\(\)\.?(.*)/)[1];
            var theRest = key.match(/^([^\.\'\",\[\]\(\)]+)\(\)\.?(.*)/)[2];
            out = sing.resolveKey(methodName, data, context);
            if (out == null || !out.apply) {
                throw 'could not resolve ' + key;
            }
            var result = out.apply(data, []);
            if (theRest == null || theRest == '')
                return result;
            return sing.resolveKey(theRest, result, context);
        }
        // function notation, some arguments
        if (key.hasMatch(/^([^\.\'\",\[\]\(\)]+)\((.+)\)\.?(.*)$/)) {
            var match = key.match(/^([^\.\'\",\[\]\(\)]+)\((.+)\)\.?(.*)$/);
            var methodName = match[1];
            var argsStr = match[2];
            var theRest = match[3];
            if (argsStr.lastIndexOf('(') > argsStr.lastIndexOf(')')) {
                theRest = argsStr.substr(argsStr.lastIndexOf('(')) + theRest;
                argsStr = argsStr.substr(0, argsStr.lastIndexOf('('));
                if (theRest[0] == '(' && theRest[theRest.length - 1] == ')')
                    theRest = theRest.substr(1, theRest.length - 2);
            }
            out = sing.resolveKey(methodName, data, context);
            var args = sing.resolveKey(argsStr, data, context);
            if (!$.isArray(args))
                args = [args];
            if (out == null || !out.apply) {
                throw 'could not resolve ' + key;
            }
            var result = out.apply(data, args);
            if (theRest == null || theRest == '')
                return result;
            return sing.resolveKey(theRest, out, context);
        }
        // Array navigation
        if (out === undefined && key.hasMatch(/^([^\.\'\",\[\]\(\)]+)\[(.+)\]\.?(.*)$/)) {
            var match = key.match(/^([^\.\'\",\[\]\(\)]+)\[(.+)\]\.?(.*)$/);
            var property = match[1];
            var arrayIndex = match[2];
            var theRest = match[3];
            arrayIndex = sing.resolveKey(arrayIndex, data, context);
            var propData = sing.resolveKey(property, data, context);
            if (!$.isDefined(propData)) {
                throw 'could not resolve ' + key;
            }
            if (!$.isArray(propData)) {
                throw property + ' was not an array';
            }
            out = propData[arrayIndex];
            if (theRest == null || theRest == '')
                return out;
            return sing.resolveKey(theRest, out, context);
        }
        // Dot notation
        if (key.hasMatch(/([^\.\'\",\[\]\(\)]+)\.(.*)$/)) {
            var keyParts = key.split('.');
            var resolveFirst = sing.resolveKey(keyParts.shift(), data, context);
            if (!$.isDefined(resolveFirst) || resolveFirst == '') {
                throw 'could not resolve ' + key;
            }
            data = resolveFirst;
            out = sing.resolveKey(keyParts.join('.'), data, context);
            //console.log('RESOLVE ' + key);
            return out;
        }
        // Array creation
        if (out === undefined && key.hasMatch(/^\[(.+)\](.*)$/)) {
            var match = key.match(/^\[(.+)\](.*)$/);
            var arrayContents = match[1];
            var theRest = match[2];
            arrayContents = sing.resolveKey(arrayContents, data, context);
            if (!$.isArray(arrayContents))
                arrayContents = [arrayContents];
            if (theRest == null || theRest == '')
                return arrayContents;
            out = sing.resolveKey(theRest, arrayContents, context);
            return out;
        }
        // Non-escaped commas
        if (key.contains(',,')) {
            key = key.replaceAll(',,', commaSubstitute);
        }
        // Comma notation
        if (key.hasMatch(/([^\.\'\",\[\]\(\)]*),(.*)$/)) {
            var match = key.match(/([^\.\'\",\[\]\(\)]*),(.*)$/);
            var item = match[1];
            var theRest = match[2];
            if (!item || item == '')
                item = data;
            else
                item = sing.resolveKey(item, data, context);
            var items = [item];
            items = items.concat(sing.resolveKey(theRest, data, context));
            return items;
        }
        // Strings
        if ((key.length > 1 && key[0] == '\'' && key[key.length - 1] == '\'') || (key.length > 1 && key[0] == '"' && key[key.length - 1] == '"')) {
            if (key.length == 2)
                return '';
            else {
                return key.substr(1, key.length - 2);
            }
        }
        var keyPart = key.before(' ');
        if ($.isDefined(data))
            if (data[keyPart] !== undefined) {
                out = data[keyPart];
            }
        if (out == undefined && context && context[keyPart] !== undefined) {
            out = context[keyPart];
        }
        if (out === undefined && sing.globalResolve[keyPart] !== undefined) {
            return sing.globalResolve[keyPart];
        }
        // available context of any object
        if (out === undefined && keyPart.endsWith('$context')) {
            var itemContext = sing.resolveKey(keyPart.substr(0, keyPart.indexOf('$context')));
            var itemKeys = $.objKeys(data);
            return itemKeys.join(', ');
        }
        // OR operation
        if (keyPart == '||') {
            var theRest = key.substr(2);
            var left = data;
            if ($.isEmpty(left) || left == false)
                return sing.resolveKey(theRest, data, context);
            else
                return left;
        }
        // AND operation
        if (keyPart == '&&') {
            var theRest = key.substr(2);
            var left = data;
            if ($.isEmpty(left) || left == false) {
                return false;
            }
            else {
                var right = sing.resolveKey(theRest, data, context);
                return true && !($.isEmpty(left) || left == false);
            }
        }
        else if (keyPart == '+') {
            var theRest = key.substr(1);
            var resolved = sing.resolveKey(theRest, data, context);
            return (data + resolved);
        }
        else if (keyPart == '-') {
            var theRest = key.substr(1);
            var resolved = sing.resolveKey(theRest, data, context);
            return (data - resolved);
        }
        else if (keyPart == '*') {
            var theRest = key.substr(1);
            var resolved = sing.resolveKey(theRest, data, context);
            return (data * resolved);
        }
        else if (keyPart == '/') {
            var theRest = key.substr(1);
            var resolved = sing.resolveKey(theRest, data, context);
            return (data / resolved);
        }
        else if (keyPart == '%') {
            var theRest = key.substr(1);
            var resolved = sing.resolveKey(theRest, data, context);
            return (data % resolved);
        }
        else if (keyPart == '<<') {
            var theRest = key.substr(1);
            var resolved = sing.resolveKey(theRest, data, context);
            return (data << resolved);
        }
        else if (keyPart == '>>') {
            var theRest = key.substr(1);
            var resolved = sing.resolveKey(theRest, data, context);
            return (data >> resolved);
        }
        else if (keyPart == '^') {
            var theRest = key.substr(1);
            var resolved = sing.resolveKey(theRest, data, context);
            return (data ^ resolved);
        }
        else if (keyPart == '&') {
            var theRest = key.substr(1);
            var resolved = sing.resolveKey(theRest, data, context);
            return (data & resolved);
        }
        else if (keyPart == '|') {
            var theRest = key.substr(1);
            var resolved = sing.resolveKey(theRest, data, context);
            return (data | resolved);
        }
        else if (keyPart == '===') {
            var theRest = key.substr(3);
            var resolved = sing.resolveKey(theRest, data, context);
            return (data === resolved);
        }
        else if (keyPart == '!==') {
            var theRest = key.substr(3);
            var resolved = sing.resolveKey(theRest, data, context);
            return (data !== resolved);
        }
        else if (keyPart == '==') {
            var theRest = key.substr(2);
            var resolved = sing.resolveKey(theRest, data, context);
            return (data == resolved);
        }
        else if (keyPart == '!=') {
            var theRest = key.substr(2);
            var resolved = sing.resolveKey(theRest, data, context);
            return (data != resolved);
        }
        else if (keyPart == '>=') {
            var theRest = key.substr(2);
            var resolved = sing.resolveKey(theRest, data, context);
            return (data >= resolved);
        }
        else if (keyPart == '<=') {
            var theRest = key.substr(2);
            var resolved = sing.resolveKey(theRest, data, context);
            return (data <= resolved);
        }
        else if (keyPart == '>') {
            var theRest = key.substr(1);
            var resolved = sing.resolveKey(theRest, data, context);
            return (data > resolved);
        }
        else if (keyPart == '<') {
            var theRest = key.substr(1);
            var resolved = sing.resolveKey(theRest, data, context);
            return (data < resolved);
        }
        else if (keyPart == '=') {
            var theRest = key.substr(1);
        }
        // +=
        // -=
        // *=
        // /=
        // %=
        // ++
        // --
        // ()
        // !
        // !()
        // ? :
        // current data
        if (keyPart == '$data') {
            return data;
        }
    }
    catch (ex) {
        throw ex;
    }
    if (out === undefined) {
        if (key.contains('||'))
            out = sing.resolveKey(key.after('||'), data, context);
        return '<error>could not resolve ' + key + '</error>';
    }
    return out;
}
singRoot.method('init', null);
singRoot.method('ready', null);
singRoot.ignoreUnknown('Module', 'Extension', 'AutoDefinition', 'getDocs', 'getMissing', 'getSummary');
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
var singCore = singRoot.addModule(new SingularityModule('Core', Singularity));
singCore.ignoreUnknown('ALL');
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
var singModule = singCore.addModule(new SingularityModule('Modules', [SingularityModule, new SingularityModule('', null)]));
singModule.method('addModule', singRoot.addModule);
singModule.method('method', singRoot.method);
singModule.method('totalCodeLines', ModuleTotalCodeLines);
singModule.method('fullName', singRoot.fullName);
function ModuleTotalCodeLines() {
    var out = 0;
    var mod = this;
    mod.methods.each(function (ext) {
        out += ext.codeLines;
    });
    mod.subModules.each(function (subMod) {
        out += subMod.totalCodeLines();
    });
    return out;
}
;
singModule.method('getMethods', ModuleGetMethods);
function ModuleGetMethods(extName) {
    var thisModule = this;
    return $.objValues(sing.methods).where(function (ext) {
        return ext.methodModule == thisModule;
    });
}
singModule.method('getUnknownProperties', ModuleGetUnknownProperties);
function ModuleGetUnknownProperties() {
    var thisModule = this;
    thisModule.ignoreUnknownMembers = thisModule.ignoreUnknownMembers || [];
    if (thisModule.ignoreUnknownMembers.length == 1 && thisModule.ignoreUnknownMembers[0] == 'ALL')
        return [];
    var methods = (thisModule.methods || []).arrayValues('shortName');
    var keys = [];
    thisModule.trackObjects.collect(function (obj) {
        if (obj)
            keys = keys.concat($.objKeys(obj).select(function (key) {
                return !$.isFunction(obj[key]);
            }));
        if (obj && obj.prototype)
            keys = keys.concat($.objKeys(obj.prototype).select(function (key) {
                return !$.isFunction(obj.prototype[key]);
            }));
    });
    return keys.select(function (name) {
        return !methods.contains(name) && !thisModule.ignoreUnknownMembers.contains(name);
    });
}
singModule.method('getUnknownMethods', ModuleGetUnknownMethods);
function ModuleGetUnknownMethods() {
    var thisModule = this;
    thisModule.ignoreUnknownMembers = thisModule.ignoreUnknownMembers || [];
    if (thisModule.ignoreUnknownMembers.length == 1 && thisModule.ignoreUnknownMembers[0] == 'ALL')
        return [];
    var methods = (thisModule.methods || []).arrayValues('shortName');
    var keys = [];
    thisModule.trackObjects.collect(function (obj) {
        if (obj)
            keys = keys.concat($.objKeys(obj).select(function (key) {
                return $.isFunction(obj[key]);
            }));
        if (obj && obj.prototype)
            keys = keys.concat($.objKeys(obj.prototype).select(function (key) {
                return $.isFunction(obj.prototype[key]);
            }));
    });
    return keys.select(function (name) {
        return !methods.contains(name) && !thisModule.ignoreUnknownMembers.contains(name);
    });
}
singModule.method('property', null);
singModule.method('ignoreUnknown', singCore.ignoreUnknown);
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
var singMethod = singCore.addModule(new SingularityModule('Methods', [SingularityMethod, new SingularityMethod(null)]));
var singExt = singRoot.addModule(new SingularityModule('Extensions', Singularity));
$().init(function () {
    sing.init();
});
var Direction = (function () {
    function Direction() {
    }
    Direction.left = 'left';
    Direction.right = 'right';
    Direction.center = 'center';
    Direction.l = 'l';
    Direction.r = 'r';
    Direction.c = 'c';
    return Direction;
})();
/// <reference path="singularity-core.ts"/>
var singEnumerable = singExt.addModule(new sing.Module("Enumerable", Array));
//////////////////////////////////////////////////////
//
// Iteration Functions
//
singEnumerable.method('each', EnumerableEach, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
        ext.addTest([], [], undefined);
        ext.addTest([], [null], undefined);
        ext.addTest([], [undefined], undefined);
        ext.addTest([], [function () {
        }], undefined);
        ext.addTest([], [function () {
            return true;
        }], undefined);
        ext.addTest([], [function () {
            return false;
        }], undefined);
        ext.addTest([1], [function (a) {
            return a;
        }], undefined);
        ext.addCustomTest(function () {
            var test = [1, 2, 3];
            var count = 0;
            test.each(function () {
                count++;
            });
            if (count != 3)
                return 'each did not execute 3 times.';
        });
    },
});
function EnumerableEach(action) {
    if (!this)
        return;
    var thisArray = this;
    thisArray.while(function (item, i) {
        action(item, i);
        // each always continues until the end
        return true;
    });
}
singEnumerable.method('while', EnumerableWhile, {
    summary: '',
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
        ext.addTest([], [], true);
        ext.addTest([], [null], true);
        ext.addTest([], [undefined], true);
        ext.addTest([], [function () {
        }], true);
        ext.addTest([], [function () {
            return true;
        }], true);
        ext.addTest([1], [function () {
            return true;
        }], true);
        ext.addTest([], [function () {
            return false;
        }], true);
        ext.addTest([1], [function () {
            return false;
        }], false);
        ext.addTest([1, 2, 3, 4, 5], [function (a) {
            return a < 3;
        }], false);
        ext.addTest([1, 2, 3, 4, 5], [function (item, index) {
            return item == 4 && index == 3;
        }], false);
        // Test broken TODO FIX
        // ext.addTest([1, 2, 3, 4, 5], [function (a) { return a == 3; }], true);
        /*
        ext.addCustomTest(function () {
            var test = [1, 2, 3, 4, 5];
            var count = 0;
            test.while(function (a) {
                count++;
                return a < 3;
            });

            if (count != 3)
                return 'while did not execute 3 times.';
        });
        */
    },
});
function EnumerableWhile(action) {
    if (!this || !action)
        return true;
    var exit = false;
    for (var i = 0; i < this.length; i++) {
        var result = action(this[i], i);
        if (result == false)
            exit = true;
        if (exit)
            break;
    }
    return !exit;
}
singEnumerable.method('until', EnumerableUntil, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
        ext.addTest([], [], false);
        ext.addTest([], [null], false);
        ext.addTest([], [undefined], false);
        ext.addTest([], [function () {
        }], false);
        ext.addTest([], [function () {
            return true;
        }], false);
        ext.addTest([1], [function () {
            return true;
        }], true);
        ext.addTest([1, 2], [function () {
            return true;
        }], true);
        ext.addTest([], [function () {
            return false;
        }], false);
        ext.addTest([1], [function () {
            return false;
        }], false);
        // Test broken TODO FIX
        // ext.addTest([1, 2, 3, 4, 5], [function (a) { return a == 3; }], true);
        /*
        ext.addCustomTest(function () {
            var test = [1, 2, 3, 4, 5];
            var count = 0;
            test.while(function (a) {
                count++;
                return a == 3;
            });

            if (count != 3)
                return 'until did not execute 3 times.';
        });
        */
    },
});
function EnumerableUntil(action) {
    if (!this || !action || this.length == 0)
        return false;
    var thisArray = this;
    var exit = false;
    thisArray.while(function (item, i) {
        var result = action(item, i);
        exit = !(result === false || result === null || result === undefined);
        return exit;
    });
    return exit;
}
//
//////////////////////////////////////////////////////
//
// Lookup Functions
singEnumerable.method('count', EnumerableCount, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    },
});
function EnumerableCount(action) {
    if (!this || !action)
        return 0;
    var thisArray = this;
    var out = 0;
    thisArray.each(function (item, i) {
        var result = action(item, i);
        if (result !== null && result !== undefined && result !== false) {
            if ($.isNumber(result))
                out += result;
            else
                out++;
        }
    });
    return out;
}
singEnumerable.method('contains', EnumerableContains, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    aliases: ['has'],
    tests: function (ext) {
        ext.addTest([], [], false);
        ext.addTest([], [null], false);
        ext.addTest([], [undefined], false);
        ext.addTest([1, 2, 3, undefined], [], false);
        ext.addTest([1, 2, 3, undefined], [undefined], false);
        ext.addTest([1, 2, 3], [null], false);
        ext.addTest([1, 2, 3], [undefined], false);
        ext.addTest([1, 2, 3], [1], true);
        ext.addTest([1, 2, 3], [3, 4, 5], true);
        ext.addTest([1, 2, 3], [[3, 4, 5]], true);
        ext.addTest([1, 2, 3], [4, 5, 3], true);
        ext.addTest([1, 2, 3], [[4, 5, 3]], true);
        ext.addTest([1, 2, 3], [function (a) {
            return a == 2;
        }], true);
        ext.addTest([1, 2, 3], [function (a) {
            return a == 5;
        }], false);
    },
});
function EnumerableContains() {
    var items = [];
    for (var _i = 0; _i < arguments.length; _i++) {
        items[_i - 0] = arguments[_i];
    }
    var srcThis = this;
    if (!srcThis || items == null || items == undefined)
        return false;
    if (items.length == 1) {
        if ($.isFunction(items[0])) {
            return !!this.first(items[0]);
        }
        return this.indexOf(items[0]) >= 0;
    }
    if (items.length > 1) {
        var result = items.first(function (it, i) {
            if (srcThis.contains(it))
                return true;
            return false;
        });
        return result !== undefined;
    }
    return false;
}
singEnumerable.method('select', EnumerableSelect, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    aliases: ['where'],
    tests: function (ext) {
        ext.addTest([], [], []);
        ext.addTest([], [null], []);
        ext.addTest([], [undefined], []);
        ext.addTest([1, 2, 3, undefined], [], []);
        ext.addTest([1, 2, 3, undefined], [function (a) {
            return a == 3;
        }], [3]);
        ext.addTest([1, 2, 3, undefined], [function (a) {
            return a === undefined;
        }], [undefined]);
        ext.addTest([1, 2, 3, undefined], [function (a) {
            return a < 3;
        }], [1, 2]);
    },
});
function EnumerableSelect(action) {
    if (!this || !action)
        return [];
    var thisArray = this;
    var out = [];
    thisArray.each(function (item, i) {
        var result = action(item, i);
        if (result != null && result != undefined && result != false)
            out = out.concat(item);
    });
    return out;
}
singEnumerable.method('collect', EnumerableCollect, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
        ext.addTest([], [], []);
        ext.addTest([], [null], []);
        ext.addTest([], [undefined], []);
        ext.addTest([undefined], [], []);
        ext.addTest([null], [], []);
        ext.addTest([undefined, null], [], []);
        ext.addTest([1, 2, 3, undefined, null], [], [1, 2, 3]);
        ext.addTest([1, 2, 3, undefined, null], [function (a) {
            return a == 3;
        }], [false, false, true, false, false]);
        ext.addTest([1, 2, 3, undefined, null], [function (a) {
            return a <= 2;
        }], [true, true, false, false, true]);
        ext.addTest([1, 2, 3, undefined, null], [function (a) {
            return a + 1;
        }], [2, 3, 4, NaN, 1]);
        ext.addTest([1, 2, 3, undefined, null], [function (a) {
            return $.isDefined(a);
        }], [true, true, true, false, false]);
    },
});
function EnumerableCollect(action) {
    if (!this)
        return [];
    var thisArray = this;
    if (action == null || action == undefined)
        action = sing.func.identity;
    var out = [];
    thisArray.each(function (item, i) {
        var result = action(item, i);
        if (result !== null && result !== undefined)
            out = out.concat(result);
    });
    return out;
}
singEnumerable.method('first', EnumerableFirst, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    },
});
function EnumerableFirst(itemOrAction) {
    if (!this)
        return;
    var thisArray = this;
    if (!itemOrAction && this.length > 0)
        return this[0];
    if (!itemOrAction)
        return;
    if (ObjectIsNumber(itemOrAction))
        itemOrAction = function (item, i) {
            return i < itemOrAction;
        };
    if ($.isFunction(itemOrAction)) {
        itemOrAction = function (item, i) {
            return item == itemOrAction;
        };
        return thisArray.select(itemOrAction);
    }
    var out = undefined;
    thisArray.while(function (item, i) {
        var result = itemOrAction(item, i);
        if (result == true) {
            out = item;
            return false;
        }
    });
    return out;
}
singEnumerable.method('last', EnumerableLast, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    },
});
function EnumerableLast(itemOrAction) {
    if (!this)
        return;
    var thisArray = this;
    if (!itemOrAction && thisArray.length > 0)
        return thisArray[thisArray.length - 1];
    if (!itemOrAction)
        return;
    var out = thisArray.reverse().first(itemOrAction);
    return out;
}
singEnumerable.method('range', EnumerableRange, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    },
});
function EnumerableRange(start, end) {
    if (start === void 0) { start = 0; }
    if (end === void 0) { end = this.length - 1; }
    if (!this || start > end)
        return [];
    var out = [];
    for (var i = start; i < end; i++) {
        out = out.concat(this[i]);
    }
    return out;
}
singEnumerable.method('flatten', EnumerableFlatten, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    },
});
function EnumerableFlatten() {
    if (!this)
        return [];
    var thisArray = this;
    var out = [];
    thisArray.each(function (item, i) {
        if ($.isArray(item))
            out.concat(item.flatten());
        else
            out.concat(item);
    });
    return out;
}
singEnumerable.method('indices', EnumerableIndices, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    aliases: ['indexes'],
    tests: function (ext) {
        ext.addTest(['a'], ['a'], [0]);
        ext.addTest(['a'], ['b'], []);
        ext.addTest(['a'], [[undefined]], []);
        ext.addTest(['a'], [[null]], []);
        ext.addTest(['a'], [null], []);
        ext.addTest(['a', 'b'], ['a', 'b'], [0, 1]);
        ext.addTest(['a', 'a', 'a', 'b', 'b', 'b'], ['a', 'b'], [0, 1, 2, 3, 4, 5]);
    },
});
function EnumerableIndices(itemOrItemsOrFunction) {
    if (!this || itemOrItemsOrFunction == null || itemOrItemsOrFunction == undefined)
        return [];
    var thisArray = this;
    if ($.isArray(itemOrItemsOrFunction)) {
        var itemArray = itemOrItemsOrFunction;
        return thisArray.collect(function (item, i) {
            if (itemArray.contains(item))
                return i;
        });
    }
    if ($.isFunction(itemOrItemsOrFunction)) {
        var itemFunction = itemOrItemsOrFunction;
        return thisArray.collect(function (item, i) {
            if (!!itemFunction(item, i))
                return i;
        });
    }
    var item = itemOrItemsOrFunction;
    var index = thisArray.indexOf(item);
    if (index >= 0)
        return [index];
    else
        return [];
}
singEnumerable.method('remove', EnumerableRemove, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    },
});
function EnumerableRemove(itemOrItemsOrFunction) {
    var thisArray = this;
    if (!itemOrItemsOrFunction)
        return thisArray;
    if ($.isArray(itemOrItemsOrFunction)) {
        var itemArray = itemOrItemsOrFunction;
        return thisArray.select(function (item, i) {
            return !itemArray.contains(item);
        });
    }
    if ($.isFunction(itemOrItemsOrFunction)) {
        var itemFunction = itemOrItemsOrFunction;
        return thisArray.select(itemFunction.fn_not());
    }
    return thisArray.select(function (item, i) {
        return item == itemOrItemsOrFunction;
    });
}
singEnumerable.method('sortBy', EnumerableSortBy, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    aliases: ['orderBy'],
    tests: function (ext) {
    },
});
function EnumerableSortBy(arg) {
    var defaultValueFunc = function (item) {
        return item;
    };
    if (arg == null) {
        arg = defaultValueFunc;
    }
    var indexes = this;
    if ($.isString(arg) && arg.contains('.')) {
        arg = arg.split('.');
    }
    if ($.isString(arg)) {
        indexes = indexes.collect(function (item) {
            return $.objHasKey(item, arg) && item != null ? defaultValueFunc(item[arg]) : -1;
        });
    }
    else if ($.isArray(arg)) {
        var argArray = arg;
        for (var i = 0; i < arg.length; i++) {
            indexes = indexes.collect(function (item) {
                if (!$.objHasKey(item, argArray[i])) {
                    return -1;
                }
                return item[argArray[i]] == null ? -1 : item[argArray[i]];
            });
        }
    }
    else {
        var argFunction = arg;
        indexes = indexes.collect(argFunction);
    }
    /*
    if (!indexes.every($.isNumeric.fn_or($.isString))) {
        indexes = indexes.collect($.toStr)
            .collect(sing.methods['Singularity.Number.String.numericValueOf'].method);
    }
    */
    var items = this;
    return indexes.quickSort([items]);
}
singEnumerable.method('quickSort', EnumerableQuickSort, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    },
});
function EnumerableQuickSort(sortWith, left, right) {
    if (left === void 0) { left = 0; }
    if (right === void 0) { right = (this.length - 1); }
    var items = this;
    if (sortWith && left == 0 && right == this.length - 1) {
        for (var i = 0; i < sortWith.length; i++) {
            if (sortWith[i] && sortWith[i].length != items.length) {
                console.log(this, sortWith);
                throw 'Lengths did not match ' + items.length + ', ' + sortWith[i].length;
            }
        }
    }
    var index;
    if (items.length > 1) {
        var partitionResult = EnumerableQuickSortPartition(items, left, right, sortWith);
        var index = partitionResult.index;
        items = partitionResult.items;
        sortWith = partitionResult.sortWith;
        if (left < index - 1) {
            if (sortWith != null) {
                var sorted = items.quickSort(left, index - 1, sortWith);
                items = sorted[0];
                for (var i = 1; i < sorted.length; i++) {
                    sortWith[i - 1] = sorted[i];
                }
            }
            else {
                items = items.quickSort(left, index - 1);
            }
        }
        if (index < right) {
            if (sortWith != null) {
                var sorted = items.quickSort(index, right, sortWith);
                items = sorted[0];
                for (var i = 1; i < sorted.length; i++) {
                    sortWith[i - 1] = sorted[i];
                }
            }
            else {
                items = items.quickSort(index, right);
            }
        }
    }
    if (sortWith != null) {
        var out = [];
        out.push(items);
        out = out.concat(sortWith);
        return out;
    }
    else {
        return items;
    }
}
function EnumerableQuickSortPartition(items, left, right, sortWith) {
    var pivot = items[Math.floor((right + left) / 2)], i = left, j = right;
    while (i <= j) {
        while (items[i] < pivot) {
            i++;
        }
        while (items[j] > pivot) {
            j--;
        }
        if (i <= j) {
            var swapResult = EnumerableQuickSortSwap(items, i, j, sortWith);
            items = swapResult.items;
            sortWith = swapResult.sortWith;
            i++;
            j--;
        }
    }
    return {
        items: items,
        sortWith: sortWith,
        index: i,
    };
}
function EnumerableQuickSortSwap(items, firstIndex, secondIndex, sortWith) {
    var temp = items[firstIndex];
    items[firstIndex] = items[secondIndex];
    items[secondIndex] = temp;
    if (sortWith != null) {
        for (var i = 0; i < sortWith.length; i++) {
            temp = sortWith[i][firstIndex];
            sortWith[i][firstIndex] = sortWith[i][secondIndex];
            sortWith[i][secondIndex] = temp;
        }
    }
    return {
        items: items,
        sortWith: sortWith,
    };
}
singEnumerable.method('timesDo', EnumerableTimesDo, {
    summary: "Repeats a function a number of times",
    parameters: [
        {
            name: 'executeFunc',
            types: [Function],
            desription: 'The function to execute',
            required: true,
        },
        {
            name: 'args',
            types: [Array],
            defaultValue: [],
            desription: '',
        },
        {
            name: 'caller',
            types: [Object],
            desription: '',
        },
    ],
    returns: 'An array of objects collected from the return values of executeFunc\'s executions.',
    returnType: Object,
    examples: ['\
            (5).timesDo(function() { alert(\'hi\'); });'],
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
}, Number.prototype);
function EnumerableTimesDo(executeFunc, args, caller) {
    if (!this || this <= 0 || !executeFunc)
        return;
    caller = caller || this;
    var out = [];
    for (var i = 0; i < this; i++) {
        if (!this)
            return;
        var result = executeFunc.apply(caller, args);
        if (result != null && result != undefined)
            out.push(result);
    }
    return out;
}
/// <reference path="singularity-core.ts"/>
var LOGGING_INFO_ENABLED = false;
var LOGGING_ERROR_ENABLED = true;
var LOGGING_WARNING_ENABLED = true;
var singLog = singCore.addModule(new sing.Module('Logging', sing, sing));
singLog.ignoreUnknown('ALL');
function log() {
    var message = [];
    for (var _i = 0; _i < arguments.length; _i++) {
        message[_i - 0] = arguments[_i];
    }
    if (LOGGING_INFO_ENABLED) {
        if (false && $.toStr && $.resolve)
            console.log('%c' + $.toStr($.resolve(message), true), 'background: #eee; color: #555');
        else
            console.log('%c' + message, 'background: #eee; color: #555');
    }
}
singLog.method('log', ArrayLog, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    },
}, Array.prototype, "Array");
function ArrayLog() {
    log(this);
}
singLog.method('log', NumberLog, {
    summary: 'Common funciton - Logs the calling Number to the console.',
    parameters: [],
    returns: 'Nothing.',
    returnType: null,
    examples: ['\
            (1).log()   //  logs 1  \r\n\
            (5).log()   //  logs 5  \r\n'],
    tests: function (ext) {
        ext.addTest(true, []);
        ext.addTest(false, []);
    }
}, Number.prototype, "Number");
function NumberLog() {
    log(this);
}
singLog.method('log', StringLog, {
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
}, String.prototype, "String");
function StringLog() {
    log(this);
}
singLog.method('log', BooleanLog, {
    summary: 'Common funciton - Logs the calling Boolean to the console.',
    parameters: [],
    returns: 'Nothing.',
    returnType: null,
    examples: ['\
            (true).log()   //  logs true  \r\n\
            (false).log()   //  logs false  \r\n'],
    tests: function (ext) {
        ext.addTest(true, []);
        ext.addTest(false, []);
    }
}, Boolean.prototype, "Boolean");
function BooleanLog() {
    log(this);
}
function warn() {
    var message = [];
    for (var _i = 0; _i < arguments.length; _i++) {
        message[_i - 0] = arguments[_i];
    }
    if (LOGGING_ERROR_ENABLED) {
        if ($.toStr && $.resolve)
            console.log('%c' + $.toStr($.resolve(message), true), 'background: #555; color: #F7DAA3');
        else
            console.log('%c' + message, 'background: #555; color: #F7DAA3');
    }
}
singLog.method('warn', ArrayWarn, {}, Array.prototype, "Array");
function ArrayWarn() {
    warn(this);
}
singLog.method('warn', NumberWarn, {}, Number.prototype, "Number");
function NumberWarn() {
    warn(this);
}
singLog.method('warn', StringWarn, {}, String.prototype, "String");
function StringWarn() {
    warn(this);
}
singLog.method('warn', BooleanWarn, {}, Boolean.prototype, "Boolean");
function BooleanWarn() {
    warn(this);
}
function error() {
    var message = [];
    for (var _i = 0; _i < arguments.length; _i++) {
        message[_i - 0] = arguments[_i];
    }
    if (LOGGING_ERROR_ENABLED) {
        if ($.toStr && $.resolve)
            console.log('%c ' + $.toStr($.resolve(message), true), 'background: #eee; color: #FF0000');
        else
            console.log('%c ' + message, 'background: #eee; color: #FF0000');
    }
}
singLog.method('error', ArrayError, {}, Array.prototype, "Array");
function ArrayError() {
    error(this);
}
singLog.method('error', NumberError, {}, Number.prototype, "Number");
function NumberError() {
    error(this);
}
singLog.method('error', StringError, {}, String.prototype, "String");
function StringError() {
    error(this);
}
singLog.method('error', BooleanError, {}, Boolean.prototype, "Boolean");
function BooleanError() {
    error(this);
}
/// <reference path="singularity-core.ts"/>
var singTemplates = singString.addModule(new sing.Module('Templates', String));
sing.templatePatternGlobal = /^.*{\{\{(.+)\}\}}+.*/g;
sing.templatePattern = /.*\{\{(.+)\}\}.*/;
sing.templateStart = '{{';
sing.templateEnd = '}}';
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
singTemplates.method('templateInject', StringTemplateInject, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    },
});
function StringTemplateInject(obj, _context) {
    var out = this.toString();
    var matches = out.match(sing.templatePattern) || [];
    while (matches.length > 0) {
        var key = matches[1];
        if (key.contains(' with ')) {
            // sing-fill template. ignore.
            out = out.replace(sing.templateStart + key + sing.templateEnd, '<<' + key + '>>');
            matches = out.match(sing.templatePattern) || [];
            continue;
        }
        var value = null;
        value = sing.resolveKey(key, obj, _context);
        if (value == null)
            throw 'could not find key ' + key;
        if (value != null && value != undefined) {
            out = out.replace(sing.templateStart + key + sing.templateEnd, value.toString());
        }
        else {
            out = out.replace(sing.templateStart + key + sing.templateEnd, '');
        }
        matches = out.match(sing.templatePattern) || [];
    }
    return out;
}
singTemplates.method('templateExtract', StringTemplateExtract, {
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
////////////////////////////////////////////////////////////////////////////////////////////////
singTemplates.method('getTemplate', ObjectGetTemplate, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    tests: function (ext) {
    },
}, $);
function ObjectGetTemplate(name, data) {
    var template = sing.templates[name];
    if (!template || template.length == 0)
        throw 'Template ' + name + ' not found.';
    template = $(template);
    if ($.isDefined(data)) {
        try {
            return template.attr('sing-template-data', 'true').fillTemplate(data);
        }
        catch (ex) {
            return $('<error>' + ex + ' ' + ex.stack + '</error>');
        }
    }
    return template;
}
singTemplates.method('getTemplateFor', ObjectGetTemplateFor, {}, sing);
function ObjectGetTemplateFor(obj) {
}
singTemplates.method('fillTemplate', ObjectFillTemplate, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    tests: function (ext) {
    },
}, $.fn);
var deferred = 0;
var deferredDone = 0;
function ObjectFillTemplate(data, _context, forceFill) {
    if (forceFill === void 0) { forceFill = false; }
    _context = sing.loadContext(_context);
    var template = (this);
    var visible = template.isOnScreen(0.01, 0.01);
    if (!forceFill && !visible && template.attr('sing-deferred') != 'true') {
        // Mark element as deferred to avoid inifinite loop.
        template.attr('sing-deferred', 'true');
        var tempHtml = template.outerHtml();
        var thisDeferredID = deferred;
        template.attr('defer-id', thisDeferredID);
        template.html('DEFERRED');
        deferred++;
        _context = $.extend(true, {}, _context);
        (function () {
            try {
                var deferTemplate = $('*[defer-id=' + thisDeferredID + ']');
                var newTemplate = $(tempHtml);
                deferTemplate.before(newTemplate);
                deferTemplate.remove();
                newTemplate.fillTemplate(data, _context, true);
                deferredDone++;
            }
            catch (ex) {
                error(ex);
            }
        }).fn_defer()();
        return;
    }
    var ifs = template.find('*[sing-if]');
    ifs.each(function () {
        $(this).singIf(data, _context, true);
    });
    var loops = template.find('*[sing-loop]');
    loops.each(function () {
        $(this).singLoop(data, _context, true);
    });
    var fills = template.find('*[sing-fill]');
    fills.each(function () {
        $(this).singFill(data, _context, forceFill);
    });
    if (template.attr('sing-fill') && template.attr('sing-fill').length > 0)
        template.singFill(data, _context, forceFill);
    var html = template[0].outerHTML;
    var templateReplace = html.templateInject(data, _context);
    template.replaceWith($(templateReplace));
    if (sing.templateShownFunctions && sing.templateShownFunctions.length > 0) {
        sing.templateShownFunctions.each(function (fn) {
            fn(template);
        });
    }
}
singTemplates.method('singIf', ElementPerformSingIf, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    tests: function (ext) {
    },
}, $.fn);
function ElementPerformSingIf(data, _context, forceFill) {
    if (forceFill === void 0) { forceFill = false; }
    _context = sing.loadContext(_context);
    var srcThis = this;
    // Don't perform if for elements within templates
    var parent = srcThis.parent('*[sing-template]');
    if (parent.length != 0 && parent.attr('sing-template-data') != 'true')
        return;
    var mode = 'sing-if';
    var condition = '';
    if ($(this).hasAttr('sing-else-if')) {
        mode = 'sing-else-if';
        condition = $(this).attr('sing-else-if');
    }
    else if ($(this).hasAttr('sing-else')) {
        mode = 'sing-else';
        condition = '';
    }
    else {
        condition = $(this).attr('sing-if');
    }
    condition = condition || '';
    if (condition.startsWith(sing.templateStart))
        condition = condition.substr(sing.templateStart.length);
    if (condition.endsWith(sing.templateEnd))
        condition = condition.substr(0, condition.length - sing.templateEnd.length);
    if (mode == 'sing-else') {
        sourceData = true;
    }
    else {
        var sourceData = sing.resolveKey(condition, data, _context);
        if (!$.isDefined(sourceData))
            sourceData = false;
    }
    srcThis.removeAttr(mode);
    var next = srcThis.next();
    if (srcThis.siblings().length > 0) {
        next = next;
    }
    if ($.isEmpty(sourceData) || sourceData === false || sourceData === 0 || sourceData == [] || ($.isString(sourceData) && sourceData && sourceData.startsWith('<error>could not resolve'))) {
        srcThis.remove();
        // Evaluate all subsequent else-if and else tags if the result is false.
        if (next && next.length == 1 && (next.hasAttr('sing-else-if') || next.hasAttr('sing-else'))) {
            next.singIf(data, _context);
        }
        return $();
    }
    else {
        while (next && next.length > 0 && (next.hasAttr('sing-else-if') || next.hasAttr('sing-else'))) {
            var last = next;
            next = last.next();
            last.remove();
        }
        return srcThis;
    }
}
singTemplates.method('singFill', ElementPerformSingFill, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    tests: function (ext) {
    },
}, $.fn);
function ElementPerformSingFill(data, _context, forceFill) {
    if (forceFill === void 0) { forceFill = false; }
    _context = sing.loadContext(_context);
    var srcThis = this;
    // Don't perform fill for elements within templates
    var parent = srcThis.parent('*[sing-template]');
    if (parent.length != 0 && parent.attr('sing-template-data') != 'true')
        return;
    var fillWith = $(this).attr('sing-fill');
    if (fillWith.startsWith(sing.templateStart) || fillWith.startsWith('<<'))
        fillWith = fillWith.substr(sing.templateStart.length);
    if (fillWith.endsWith(sing.templateEnd) || fillWith.endsWith('>>'))
        fillWith = fillWith.substr(0, fillWith.length - sing.templateEnd.length);
    // No template - target self.
    var template = null;
    var source = '';
    if (!fillWith.contains(' with ')) {
        template = srcThis;
        source = fillWith;
    }
    else {
        var fill = fillWith.split(' with ')[0].trim();
        source = fillWith.split(' with ')[1].trim();
        //        console.log('SING-FILL ' + fill + ' WITH ' + source);
        template = $.getTemplate(fill);
        srcThis.html('');
        srcThis.prepend(template);
    }
    if (!template || template.length == 0)
        throw 'could not find template ' + fill;
    var sourceData;
    if (source.contains(' as ')) {
        var after = source.after(' as ');
        var sourceData = sing.resolveKey(source.before(' as '), data, _context);
        // Copy context because a key is duplicated
        if (_context['after'] !== undefined) {
            _context = $.extend(true, {}, _context);
        }
        _context[after] = sourceData;
    }
    else {
        sourceData = sing.resolveKey(source, data, _context);
    }
    if (!$.isDefined(sourceData))
        throw 'could not find data ' + source;
    template.removeAttr('sing-template');
    srcThis.removeAttr('sing-fill');
    srcThis.attr('sing-data-type', $.typeName(sourceData));
    if (fill)
        srcThis.attr('sing-template-name', fill.toSlug());
    try {
        srcThis.fillTemplate(sourceData, _context, forceFill);
    }
    catch (ex) {
        console.trace();
        srcThis.html('<error>' + ex + ' ' + ex.stack + '</error>');
    }
    return srcThis;
}
singTemplates.method('singLoop', ElementPerformSingLoop, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    tests: function (ext) {
    },
}, $.fn);
function ElementPerformSingLoop(data, _context, forceFill) {
    if (forceFill === void 0) { forceFill = false; }
    _context = sing.loadContext(_context);
    var loop = this;
    var loopKey = loop.attr('sing-loop');
    if (loopKey.startsWith(sing.templateStart))
        loopKey = loopKey.substr(sing.templateStart.length);
    if (loopKey.endsWith(sing.templateEnd))
        loopKey = loopKey.substr(0, loopKey.length - sing.templateEnd.length);
    var loopDataKey = itemKey;
    var itemKey = '$item';
    if (loopKey.contains(' in ')) {
        itemKey = loopKey.split(' in ')[0].trim();
        loopKey = loopKey.split(' in ')[1].trim();
    }
    else {
        var tempNumber = 0;
        while (_context[itemKey + (tempNumber == 0 ? '' : tempNumber)] !== undefined) {
            tempNumber++;
        }
    }
    var itemDataIndex = itemKey.length - 1;
    var loopData = sing.resolveKey(loopKey, data, _context);
    //console.log('SING-LOOP ' + itemKey + ' IN ' + loopKey);
    var out = '';
    if (loopData == null || loopData.length == 0) {
    }
    else {
        var loopKeys = [];
        if ($.isHash(loopData)) {
            loopData = $.objValues(loopData);
            loopKeys = $.objKeys(loopData);
        }
        if ($.isArray(loopData)) {
            for (var i = 0; i < loopData.length; i++) {
                //console.log('SING-LOOP ' + (i) + ' ' + itemKey + ' IN ' + loopKey);
                var loopClone;
                if (loop.attr('sing-loop-inner') == 'true') {
                    loopClone = $(loop[0].innerHTML).removeAttr('sing-loop');
                }
                else {
                    loopClone = $(loop[0].outerHTML).removeAttr('sing-loop');
                }
                loop.before(loopClone);
                // Copy context because a key is duplicated
                if (_context[itemKey] !== undefined) {
                    _context = $.extend(true, {}, _context);
                }
                _context[itemKey] = loopData[i];
                _context[itemKey + '$i'] = i;
                _context[itemKey + '$index'] = i;
                _context[itemKey + '$isFirst'] = i == 0;
                _context[itemKey + '$isLast'] = i == loopData.length - 1;
                _context[itemKey + '$isEven'] = i % 2 == 0;
                _context[itemKey + '$isOdd'] = i % 2 == 1;
                if (loopKeys && loopKeys.length > 0)
                    _context[itemKey + '$key'] = loopKeys[i];
                try {
                    loopClone.fillTemplate(data, _context, forceFill);
                }
                catch (ex) {
                    loopClone = $('<error>' + ex + ' ' + ex.stack + '</error>');
                    console.trace();
                }
            }
        }
    }
    loop.remove();
}
sing.loadTemplate = function (url, callback) {
    var data = $.ajax(url, {
        complete: function (data) {
            //console.log(data);
            var templates = $('<div>' + data.responseText + '</div>');
            templates.find('*[sing-template]').each(function () {
                if ($(this).attr('sing-template-data') == 'true')
                    return;
                var name = $(this).attr('sing-template');
                var html = $(this)[0].outerHTML;
                sing.templates[name] = html;
            });
            if (callback)
                callback();
        }
    });
};
$().init(function () {
    $('*[sing-template]').each(function () {
        if ($(this).attr('sing-template-data') == 'true')
            return;
        var name = $(this).attr('sing-template');
        var html = $(this)[0].outerHTML;
        sing.templates[name] = html;
        $(this).remove();
    });
});
sing.initTemplates = function () {
    $('*[sing-if]').each(function () {
        try {
            $(this).hide();
            $(this).singIf();
            $(this).fadeIn('fast');
        }
        catch (ex) {
            console.log(ex);
        }
    });
    $('*[sing-loop]').each(function () {
        try {
            $(this).hide();
            $(this).singLoop();
            $(this).fadeIn('fast');
        }
        catch (ex) {
            console.log(ex);
        }
    });
    $('*[sing-fill]').each(function () {
        try {
            $(this).singFill();
            $(this).hide().fadeIn('fast');
        }
        catch (ex) {
            console.log(ex);
        }
    });
};
// #region Examples 
/*
// These Work

<div sing-template="ListTest">
    <ul>
        <li sing-loop="{{person in items}}">
            <a>{{person.name}}</a>
            <a>{{person.age}}</a>
        </li>
    </ul>
</div>

<div sing-template="ListTest">
    <ul>
        <li sing-loop="{{items}}">
            <a>{{item.name}}</a>
            <a>{{item.age}}</a>
        </li>
    </ul>
</div>
 
<div sing-template="Test">
    <a>{{name}}</a>
    <a>{{age}}</a>
</div>
 
// NESTED LOOPS
<div sing-template="ListTest">
    <ul>
        <li sing-loop="{{person in items}}">
            <a>{{person.name}}</a>
            <a>{{person.age}}</a>

            <ul sing-if="{{person.friends}}">
                <li sing-loop={{friend in person.friends}}">
                    <a>{{friend.name}}</a>
                    <a>{{friend.age}}</a>
                </li>
            </ul>
        </li>
    </ul>
</div>

// IF Conditions
<div sing-if="{{item}}">
    <a>{{item.name}}</a>
    <a>{{item.age}}</a>
</div>

// ELSE-IF Conditions
<div sing-if="{{item}}">
    <a>{{item.name}}</a>
    <a>{{item.age}}</a>
</div>
<div sing-else-if="{{item2}}">
    <a>{{item2.name}}</a>
    <a>{{item2.age}}</a>
</div>

// ELSE Conditions
<div sing-if="{{item}}">
    <a>{{item.name}}</a>
    <a>{{item.age}}</a>
</div>
<div sing-else>
    Item Not Found
</div>
 
// Method Calls
<div sing-template="ListTest">
    <ul>
        <li sing-loop="{{person in items.getPeople()}}">
            {{index}}

            <a>{{person.name}}</a>
            <a>{{person.age}}</a>
        </li>
    </ul>
</div>


// These should work


// IF Operators
<div sing-if="{{item.age}}">
    <a>{{item.name}}</a>
    <a>{{item.age}}</a>
</div>

// IF Operators OR
<div sing-if="{{item.age > 50 || item.age < 5 }}">
    <a>{{item.name}}</a>
    <a>{{item.age}}</a>
</div>

// IF Operators AND
<div sing-if="{{item.age > 50 && item.age != 67 }}">
    <a>{{item.name}}</a>
    <a>{{item.age}}</a>
</div>
 
// FILTERS
<div sing-if="{{item.age : even}}">
    <a>{{item.name}}</a>
    <a>{{item.age}}</a>
</div>
 
// FILTERS With Variables
<div sing-if="{{item.age : even}}">
    <a>{{item.name}}</a>
    <a>{{item.age}}</a>
</div>
 
 
// INDEX (others)
<div sing-template="ListTest">
    <ul>
        <li sing-loop="{{person in items}}">
            {{index}}

            <a>{{person.name}}</a>
            <a>{{person.age}}</a>
        </li>
    </ul>
</div>

// Method Calls with arguments

<div sing-template="ListTest">
    <ul>
        <li sing-loop="{{person in items.getPeople('fred')}}">
            {{index}}

            <a>{{person.name}}</a>
            <a>{{person.age}}</a>
        </li>
    </ul>
</div>
*/
// #endregion Examples
/// <reference path="singularity-core.ts"/>
var singRegExp = singString.addModule(new sing.Module('RegExp', String));
singRegExp.method('matchCount', StringMatchCount, {
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
singRegExp.method('hasMatch', StringHasMatch, {
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
singRegExp.method('replaceRegExp', StringReplaceRegExp, {
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
singRegExp.method('escapeRegExp', StringEscapeRegExp, {
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
/// <reference path="singularity-core.ts"/>
var singBBCode = singString.addModule(new sing.Module('BBCode', String));
singBBCode.method('bbCodesToHTML', StringBBCodesToHTML, {
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
singBBCode.method('bbCodesToText', StringBBCodesToText, {
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
// Tests from http://en.wikipedia.org/wiki/BBCode
sing.BBCodes = [
    {
        name: 'Bold',
        tag: '[b][/b]',
        matchStr: /\[b\](.+)\[\/b\]/,
        htmlStr: '\<b\>$1\</b\>',
        textStr: '$1',
        test: '[b]bolded text[/b]',
    },
    {
        name: 'Italics',
        tag: '[i][/i]',
        matchStr: /\[i\](.+)\[\/i\]/,
        htmlStr: '<i>$1</i>',
        textStr: '$1',
        test: '[i]italicized text[/i]',
    },
    {
        name: 'Underline',
        tag: '[u][/u]',
        matchStr: /\[u\](.+)\[\/u\]/,
        htmlStr: '<u>$1</u>',
        textStr: '$1',
        test: '[u]underlined text[/u]',
    },
    {
        name: 'Strikethrough',
        tag: '[s][/s]',
        matchStr: /\[s\](.+)\[\/s\]/,
        htmlStr: '<s>$1</s>',
        textStr: '$1',
        test: '[s]strikethrough text[/s]',
    },
    {
        name: 'Center',
        tag: '[center][/center]',
        matchStr: /\[center\](.+)\[\/center\]/,
        htmlStr: '<center>$1</center>',
        textStr: '$1',
        test: '[center]centered text[/center]',
    },
    {
        name: 'Font Style Size',
        tag: '[style size={size}][/style]',
        matchStr: /\[style size\=["]*(\d{1,3}).*\](.+)\[\/style\]/,
        htmlStr: '<font size="$1">$2</font>',
        textStr: '$2',
        test: '[style size="20px"]Large Text[/style]',
    },
    {
        name: 'Font Size',
        tag: '[size={size}][/style]',
        matchStr: /\[size\=["]*(\d{1,3}).*\](.+)\[\/size\]/,
        htmlStr: '<font size="$1">$2</font>',
        textStr: '$2',
        test: '[size="28px"]Larger Text[/size]',
    },
    {
        name: 'Font Color',
        tag: '[color={color}][/color]',
        matchStr: /\[color\=["]*([.,\#]+).*\](.+)\[\/color\]/,
        htmlStr: '<font style="color:$1;">$2</font>',
        textStr: '$2',
        test: '[color="red"]Red Text[/style]\r\n[color=#FF0000]Red Text[/color]',
    },
    {
        name: 'Style Color',
        tag: '[style color={color}][/color]',
        matchStr: /\[style color\=["]*([.,#]+).*\](.+)\[\/style\]/,
        htmlStr: '<font style="color:$1;">$2</font>',
        textStr: '$2',
        test: '[style color="red"]Red Text[/style]\r\n[style color=#FF0000]Red Text[/style]',
    },
    {
        name: 'URL',
        tag: '[url]{url}[/url]',
        matchStr: /\[url\](.+)\[\/url\]/,
        htmlStr: '<a href="$1">$1</a>',
        textStr: '$1',
        test: '[url]http://example.org[/url]',
    },
    {
        name: 'Named URL',
        tag: '[url={url}][/url]',
        matchStr: /\[url\=\"?(.+)\"?\](.+)\[\/url\]/,
        htmlStr: '<a href=$1>$2</a>',
        textStr: '$2',
        test: '[url="http://example.com"]Example[/url]',
    },
];
var singObject = singExt.addModule(new sing.Module("Object", $, $));
singObject.method('objEach', ObjectEach, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: '',
    examples: null,
    tests: function (ext) {
        ext.addCustomTest(function () {
            var test = { a: 1, b: 2 };
            var test2 = [];
            $.objEach(test, function (key, item, index) {
                test2.push({ key: key, item: item, index: index });
            });
            if ($.toStr(test2) != $.toStr([{ key: 'a', item: 1, index: 0 }, { key: 'b', item: 2, index: 1 }]))
                return $.toStr(test2) + '\r\n' + $.toStr([{ key: 'a', item: 1, index: 0 }, { key: 'b', item: 2, index: 1 }]);
        }, 'Executes for every element');
    },
});
function ObjectEach(obj, eachFunc) {
    var keys = Object.keys(obj);
    keys.each(function (key, i) {
        eachFunc(key, obj[key], i);
    });
}
singObject.method('objProperties', ObjectProperties, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: '',
    examples: null,
    tests: function (ext) {
        ext.addTest(undefined, [null], []);
        ext.addTest(undefined, [undefined], []);
        ext.addTest(undefined, ['a'], [{ 0: { key: '0', value: 'a' } }]);
        ext.addTest(undefined, [5], []);
        ext.addTest(undefined, [[]], []);
        ext.addTest(undefined, [{}], []);
        ext.addTest(undefined, [{ a: 1, b: 2 }], [{ key: 'a', value: 1 }, { key: 'b', value: 2 }]);
    },
});
function ObjectProperties(obj) {
    if (obj == null || !(typeof obj == 'object'))
        return [];
    var keys = Object.keys(obj);
    var values = keys.collect(function (item, i) {
        return { key: item, value: obj[item] };
    });
    return values;
}
singObject.method('objValues', ObjectValues, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    tests: function (ext) {
        ext.addTest(undefined, [null], []);
        ext.addTest(undefined, [undefined], []);
        ext.addTest(undefined, ['a'], []);
        ext.addTest(undefined, ['a', 'b'], []);
        ext.addTest(undefined, [5], []);
        ext.addTest(undefined, [[]], []);
        ext.addTest(undefined, [{}], []);
        ext.addTest(undefined, [{ a: 1, b: 2 }], [1, 2]);
        ext.addTest(undefined, [{ a: 'b', c: 'd' }, ['a']], 'b');
        ext.addTest(undefined, [{ a: 'b', c: 'd' }, ['b']], null);
        ext.addTest(undefined, [{ a: 'b', c: 'd' }, ['c']], 'd');
    },
});
function ObjectValues(obj, findKeys) {
    if (obj == null || !(typeof obj == 'object'))
        return null;
    if (findKeys != null && findKeys.length > 0) {
        if ($.isArray(obj)) {
            return obj.arrayValues.apply(obj, findKeys);
        }
        else {
            return [obj].arrayValues.apply([obj], findKeys);
        }
    }
    else {
        var keys = Object.keys(obj);
        var values = keys.collect(function (item, i) {
            return obj[item];
        });
        return values;
    }
}
singObject.method('arrayValues', ArrayFindValues, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
        ext.addTest([], [null], []);
        ext.addTest([], [undefined], []);
        ext.addTest([1], [null], []);
        ext.addTest([1], [undefined], []);
        ext.addTest([{ a: 'b', c: 'd' }, { a: 'b2', c: 'd2' }], ['a'], ['b', 'b2']);
        ext.addTest([{ a: 'b', c: 'd' }, { a: 'b2', c: 'd2' }], ['b'], []);
        ext.addTest([{ a: 'b', c: 'd' }, { a: 'b2', c: 'd2' }], ['c'], ['d', 'd2']);
        ext.addTest([{ a: { name: 'a' }, b: { name: 'b' }, c: { name: 'c' } }, { a: { name: 'a2' }, b: { name: 'b2' }, c: { name: 'c2' } }], ['a.name'], ['a', 'a2']);
        ext.addTest([{ a: { name: 'a' }, b: { name: 'b' }, c: { name: 'c' } }, { a: { name: 'a2' }, b: { name: 'b2' }, c: { name: 'c2' } }], ['b.name'], ['b', 'b2']);
        ext.addTest([{ a: { name: 'a' }, b: { name: 'b' }, c: { name: 'c' } }, { a: { name: 'a2' }, b: { name: 'b2' }, c: { name: 'c2' } }], ['c.name'], ['c', 'c2']);
        ext.addTest([{ a: { name: 'a' }, b: { name: 'b' }, c: { name: 'c' } }, { a: { name: 'a2' }, b: { name: 'b2' }, c: { name: 'c2' } }], ['a', 'name'], ['a', 'a2']);
        ext.addTest([{ a: { name: 'a' }, b: { name: 'b' }, c: { name: 'c' } }, { a: { name: 'a2' }, b: { name: 'b2' }, c: { name: 'c2' } }], ['b', 'name'], ['b', 'b2']);
        ext.addTest([{ a: { name: 'a' }, b: { name: 'b' }, c: { name: 'c' } }, { a: { name: 'a2' }, b: { name: 'b2' }, c: { name: 'c2' } }], ['c', 'name'], ['c', 'c2']);
    },
}, Array.prototype);
function ArrayFindValues() {
    var names = [];
    for (var _i = 0; _i < arguments.length; _i++) {
        names[_i - 0] = arguments[_i];
    }
    var thisArray = this;
    if (!names || names.length == 0 || names[0] == null)
        return;
    if (names.length == 1 && names[0].contains('.')) {
        names = names[0].split('.');
    }
    if (names.length > 0) {
        var name = names.shift();
        var out = thisArray.collect(function (item) {
            if (!item || !item[name])
                return null;
            else
                return item[name];
        });
        if (names.length > 0) {
            return out.arrayValues.apply(out, names);
        }
        else {
            return out;
        }
    }
    return [];
}
singObject.method('objKeys', ObjectKeys, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    tests: function (ext) {
        ext.addTest(undefined, [null], []);
        ext.addTest(undefined, [undefined], []);
        ext.addTest(undefined, ['a'], []);
        ext.addTest(undefined, ['a', 'b'], []);
        ext.addTest(undefined, [5], []);
        ext.addTest(undefined, [[]], []);
        ext.addTest(undefined, [{}], []);
        ext.addTest(undefined, [{ a: 1, b: 2 }], ['a', 'b']);
    },
});
function ObjectKeys(obj) {
    if (obj == null || !(typeof obj == 'object'))
        return [];
    var keys = Object.keys(obj);
    return keys;
}
singObject.method('objHasKey', ObjectHasKey, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    tests: function (ext) {
        ext.addTest(null, [], false);
        ext.addTest(null, [null, 'a'], false);
        ext.addTest(null, [{ b: 'a' }, 'a'], false);
        ext.addTest(null, [{ a: 'b' }, 'a'], true);
    },
});
function ObjectHasKey(obj, key) {
    if (obj == null || !(typeof obj == 'object'))
        return false;
    var keys = Object.keys(obj);
    return keys.contains(key);
}
singObject.method('resolve', ObjectResolve, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    tests: function (ext) {
        ext.addTest(undefined, [5], 5);
        ext.addTest(undefined, ['aa'], 'aa');
        ext.addTest(undefined, [['aa', 'bb']], ['aa', 'bb']);
        ext.addTest(undefined, [function () {
            return 5;
        }], 5);
        ext.addTest(undefined, [function () {
            return 'aa';
        }], 'aa');
        ext.addTest(undefined, [function () {
            return ['aa', 'bb'];
        }], ['aa', 'bb']);
    },
});
function ObjectResolve(obj, args) {
    if ($.isFunction(obj))
        return obj.apply(null, args);
    if ($.isArray(obj) && obj.length == 1)
        return obj[0];
    return obj;
}
singObject.method('isDefined', ObjectDefined, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    tests: function (ext) {
        ext.addTest(null, [undefined], false);
        ext.addTest(null, [null], false);
        ext.addTest(null, [0], true);
        ext.addTest(null, ['a'], true);
        ext.addTest(null, [['a']], true);
        ext.addTest(null, [{}], true);
        ext.addTest(null, [{ name: 'a' }], true);
    },
});
function ObjectDefined(obj) {
    if (obj !== undefined && obj !== null)
        return true;
    return false;
}
singObject.method('isHash', ObjectIsHash, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    tests: function (ext) {
        ext.addTest(null, [undefined], false);
        ext.addTest(null, [null], false);
        ext.addTest(null, [0], false);
        ext.addTest(null, ['a'], false);
        ext.addTest(null, [['a']], false);
        ext.addTest(null, [{}], true);
        ext.addTest(null, [{ a: 'a' }], true);
    },
});
function ObjectIsHash(obj) {
    if (!$.isDefined(obj))
        return false;
    if ($.isArray(obj))
        return false;
    if (typeof obj == 'object')
        return true;
    return false;
}
singObject.method('clone', ArrayClone, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    tests: function (ext) {
        ext.addTest([], [], []);
        ext.addTest([undefined], [], []);
        ext.addTest([[]], [], []);
        ext.addTest(['a'], [], ['a']);
        ext.addCustomTest(function () {
            var ary = [1, 2, 3];
            var ary2 = ary.clone();
            ary.push(4);
            if (ary2.length == 4)
                return 'Same array was returned';
        }, 'Arrays must be clones, not the source array');
    },
}, Array.prototype, "Array");
function ArrayClone() {
    return this.collect();
}
singObject.method('clone', NumberClone, {}, Number.prototype, "Number");
function NumberClone() {
    return this.valueOf();
}
singObject.method('clone', NumberClone, {}, Boolean.prototype, "Boolean");
function BooleanClone() {
    return this.valueOf();
}
singObject.method('clone', StringClone, {}, String.prototype, "String");
function StringClone() {
    return this.valueOf();
}
singObject.method('clone', DateClone, {}, Date.prototype, "Date");
function DateClone() {
    return this.valueOf();
}
singObject.method('clone', ObjectClone, {}, $, "jQuery");
function ObjectClone() {
    if (this.clone !== ObjectClone && $.isFunction(this.clone))
        return this.clone();
    // can't clone
    return this;
}
singObject.method('isEmpty', ObjectIsEmpty, {}, $);
function ObjectIsEmpty(obj) {
    return (obj === undefined || obj === null || obj === '' || ($.isNumber(obj) && isNaN(obj)) || ($.isArray(obj) && obj.length == 0) || ($.isString(obj) && obj.trim().length == 0));
}
singObject.method('typeName', ObjectTypeName, {}, $);
function ObjectTypeName(obj) {
    if (typeof obj === "undefined")
        return "undefined";
    if (obj === null)
        return "null";
    if (obj.__proto__ && obj.__proto__.constructor && obj.__proto__.constructor.name)
        return obj.__proto__.constructor.name;
    return Object.prototype.toString.call(obj).match(/^\[object\s(.*)\]$/)[1];
}
/// <reference path="singularity-core.ts"/>
var singDate = singExt.addModule(new sing.Module("Date", Date));
//////////////////////////////////////////////////////
//
//
// Date Extensions
//
singDate.method('add', null, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    },
});
singDate.method('subtract', null, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    },
});
singDate.method('compare', null, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    },
});
singDate.method('isBefore', null, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    },
});
singDate.method('isAfter', null, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    },
});
singDate.method('equals', null, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    },
});
//# sourceMappingURL=singularity.js.map