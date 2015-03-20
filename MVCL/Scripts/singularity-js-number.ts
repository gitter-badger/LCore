/// <reference path="singularity-core.ts"/>

interface Number {
    pow?: (power: number) => number;
    round?: (decimalPlaces?: number) => number;
    max?: (...items: number[]) => number
    timesDo?: (executeFunc: (any) => void, args?: any[], caller?: any) => any[];
    ceil?: (decimalPlaces?: number) => number;
    floor?: (decimalPlaces?: number) => number;
    formatFileSize?: (decimalPlaces: number, useLongUnit: boolean) => string;
    percentOf?: (value: number, decimalPlaces?: number, asPercent?: boolean) => number | string;
    abs?: () => number;

    toStr?: (includeMarkup?: boolean) => string;
    log?: () => void;
    numericValueOf?: () => number;
}

var singNumber = sing.addModule(new sing.Module("Number", Number));


function InitSingularityJS_Number() {
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //
    // Number Extensions
    //

    singNumber.addExt('max', NumberMax,
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

    singNumber.addExt('round', NumberRound,
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

    singNumber.addExt('pow', NumberPower,
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


                ext.addFailsTest(2, [null], 'Number.pow Missing Parameter: Number power')
                ext.addFailsTest(2, [undefined], 'Number.pow Missing Parameter: Number power')
            },
        });

    function NumberPower(power) {
        return Math.pow(this, power);
    }

    singNumber.addExt('timesDo', NumberTimesDo,
        {
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
        });

    function NumberTimesDo(executeFunc: (...args: any[]) => any, args: any[], caller: any): any[] {

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

    singNumber.addExt('ceil', NumberCeiling,
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

    singNumber.addExt('floor', NumberFloor,
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

    singNumber.addExt('formatFileSize', NumberFormatFileSize,
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

    singNumber.addExt('abs', NumberAbsoluteValue,
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

    singNumber.addExt('percentOf', NumberPercentOf,
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
            if (of == 0)
                return this > 0 ? Infinity : -Infinity;
            else {
                return ((this / of) * 100).round(decimalPlaces);
            }
        }
    }

    singNumber.addExt('toStr', NumberToStr,
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

    singNumber.addExt('numericValueOf', NumberNumericValueOf,
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

    singNumber.addExt('log', NumberLog,
        {
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
        });

    function NumberLog(): void {
        log(this);
    }

}