/// <reference path="definitions/jquery.d.ts" />
/// <reference path="definitions/jqueryui.d.ts" />
/// <reference path="definitions/jquery.cookie.d.ts" />
/// <reference path="singularity-js-boolean.ts"/>
/// <reference path="singularity-js-number.ts"/>
/// <reference path="singularity-js-string.ts"/>
/// <reference path="singularity-js-array.ts"/>
/// <reference path="singularity-js-function.ts"/>
/// <reference path="singularity-jquery.ts"/>
/// <reference path="singularity-html.ts"/>


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

interface Hash<T> { [index: string]: T }

interface INamed {
    name: string;
}

interface Object extends INamed {

}

class Singularity {

    AutoDefinition = SingularityAutoDefinition;
    Extension = SingularityExtension;

    enableTests: boolean = true;

    extensions: Hash<SingularityExtension> = {

    };

    func = {
        empty: function () { },

        identity: function (obj) { return obj; },
        equals: function (obj, obj2) { return obj == obj2; },

        increment: function (i) { return i + 1; },
        booleanNot: function (obj) { return !obj; },

        toString: function (obj) { return obj.toString(); },
    };

    autoDefaults: SingularityAutoDefinition = new SingularityAutoDefinition();

    types = {
        Boolean: {

        },
        Number: {

        },
        String: {

        },
        Array: {

        },
        Function: {

        },
        Date: {

        },
        $: {

        }
    };

    autoDefault = new SingularityAutoDefinition();

    addTest = function (name: string, testFunc: () => any, requirement?: string) {

        if (!sing.extensions[name])
            throw name + ' not found';

        if (!sing.extensions[name].details.tests)
            throw name + ' tests not found';

        if ($.isFunction(sing.extensions[name].details.tests))
            sing.extensions[name].details.unitTests = sing.extensions[name].details.unitTests || [];

        sing.extensions[name].details.unitTests = sing.extensions[name].details.unitTests.concat(new SingularityTest(name, testFunc, requirement));
    };

    addCustomTest = function (name: string, testFunc: Function, requirement?: string) {
        if (!$.isString(name))
            throw name + ' was not a string';

        if (!sing.extensions[name])
            throw name + ' not found';

        if (!sing.extensions[name].details.tests)
            throw name + ' tests not found';

        requirement = requirement || '';

        requirement += '\r\n' + testFunc.toString() + '\r\n';

        sing.extensions[name].details.unitTests = sing.extensions[name].details.unitTests || [];

        sing.extensions[name].details.unitTests = sing.extensions[name].details.unitTests.concat(new SingularityTest(name, testFunc, requirement));
    };

    addMethodTest = function (ext: SingularityExtension, target?: any, args?: any[], compare?: any, requirement?: string) {

        if (!ext.method)
            throw ext.name + ' method not found';

        requirement = (requirement ? (requirement + '\r\n') : '') +
        '(' + $.toStr(target, true) + ').' + ext.shortName;

        requirement += '(';
        for (var i = 0; i < args.length; i++) {
            requirement += $.toStr(args[i], true);
            if (i < args.length - 1)
                requirement += ', ';
        }
        requirement += ')';

        requirement = requirement.pad(50);

        requirement += ' == (' + $.toStr(compare, true) + ')';

        this.addTest(ext.name, function (): any {
            var result = ext.method.apply(target, args);

            if (compare == result)
                return true;
            else if ($.toStr(compare) == $.toStr(result))
                return true;
            else
                return requirement + '\r\n' +
                    $.toStr(compare, true) + ' expected, result: ' + $.toStr(result, true);
        }, requirement);

    };

    addAssertTest = function (name: string, result: any, compare: any, requirement?: string) {

        requirement = requirement || $.toStr(compare, true) + ' is expected to match result: ' + $.toStr(result, true)

        this.addTest(name, function (): any {
            if (compare == result)
                return true;
            else if ($.toStr(compare) == $.toStr(result))
                return true;
            else
                return requirement + '\r\n' +
                    ' TEST FAILED \r\n';
        }, requirement);
    };

    addFailsTest = function (ext: SingularityExtension, target: any, args: any[], expectedError?: string, requirement?: string) {

        if (target == null || target == undefined)
            throw 'no target';

        requirement = (requirement ? (requirement + '\r\n') : '') +
        '(' + $.toStr(target, true) + ').' + ext.shortName;

        requirement += '(';
        for (var i = 0; i < args.length; i++) {
            requirement += $.toStr(args[i], true);
            if (i < args.length - 1)
                requirement += ', ';
        }
        requirement += ')';

        requirement = requirement.pad(50);

        requirement += ' THROWS ' + (expectedError ? '\'' + expectedError + '\'' : 'AN ERROR ');

        this.addTest(ext.name, function (): any {

            try {

                var result = ext.method.apply(target, args);

                return name + ' was expected to fail but it did not. \r\n\r\n' +
                    requirement;

            }
            catch (ex) {

                if (expectedError && ex != expectedError &&
                    ex != 'Uncaught ' + expectedError &&
                    'Uncaught ' + ex != expectedError) {

                    return name + ' was expected to fail with a message of \'' + expectedError + '\' \r\n' +
                        'but instead failed with error \'' + ex + '\'' + '\r\n\r\n' +
                        requirement;
                }

                return true;
            }
        }, requirement);
    };


    runTests = function (display: boolean = false) {

        this.resolveTests();

        var result;
        var testCount = 0;

        var displayStr = '';

        for (var i = 0; i < Object.keys(sing.extensions).length; i++) {

            var name = Object.keys(sing.extensions)[i];

            var ext = sing.extensions[name];
            var tests = ext.details.unitTests;

            if (tests) {
                for (var j = 0; j < tests.length; j++) {
                    var test = tests[j];

                    log('running test ' + name + ' ' + (j + 1));

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
            };
        }

        return sing.listTests() + '\r\n' +
            displayStr + '\r\n' +
            (result || 'All ' + testCount + ' tests succeeded.');
    };

    listTests = function () {

        this.resolveTests();

        var out = '\r\n';

        for (var i = 0; i < Object.keys(sing.extensions).length; i++) {

            var name = Object.keys(sing.extensions)[i];

            var item = sing.extensions[name];
            var tests = item.details.unitTests;

            if (tests && tests.length > 0)
                out += ('Extension: ' + name).pad(30) + '      Tests: ' + tests.length + '\r\n';
            else
                ; // out += 'Function: ' + name + '      Tests: 0\r\n';
        }

        return out;
    };

    listMissingTests = function () {

        this.resolveTests();

        var out = '';

        for (var i = 0; i < Object.keys(sing.extensions).length; i++) {

            var name = Object.keys(sing.extensions)[i];

            var item = sing.extensions[name];
            var tests = item.details.unitTests;

            if (!tests || tests.length == 0) {
                out += 'Extension: ' + name + '      Tests: 0\r\n';
            }
        }

        return out;
    };

    getDocs = function (funcName?: string, includeCode: boolean = false, includeDocumentation: boolean = true) {

        this.resolveTests();

        var featuresCount = 0;
        var featuresFound = 0;
        var featuresHaveTests = 0;

        var documentaionCount = 0;
        var documentaionFound = 0;

        var testsFound = 0;
        var testsPassed = 0;

        var header = 'Singularity TypeScript, JavaScript, and jQuery language Extensions\r\n';
        var out = '';

        $.objEach(sing.extensions, function (key, ext: SingularityExtension, index) {

            if (funcName &&
                funcName.lower() != '' &&
                funcName.lower() != 'all' &&
                !ext.name.lower().contains(funcName.lower()))
                return;

            featuresCount += 1; // method
            documentaionCount += 5; // documentation

            if (ext.method)
                featuresFound++;

            if (ext.details) {
                if (ext.details.summary)
                    documentaionFound++;
                if (ext.details.parameters)
                    documentaionFound++;
                if (ext.details.returns)
                    documentaionFound++;
                if (ext.details.returnTypeName)
                    documentaionFound++;
                if (ext.details.examples)
                    documentaionFound++;
                if (ext.details.unitTests && ext.details.unitTests.length > 0) {
                    featuresHaveTests++;
                }
            }

            var line = '------------------------------------------------------------------------------------';


            if (ext.details) {

                // Don't display details for alias functions, aliases are listed under the main function
                if (ext.isAlias && includeDocumentation == true)
                    return;

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

                out +=
                [
                    line,
                    ext.methodCall.pad(40) + (!ext.method ? ' -- NOT IMPLEMENTED' : functionDef).pad(40, Direction.r),
                    line,

                    (ext.details.summary ? ('\r\n    Summary: \r\n' + ext.details.summary) : ''),

                    (ext.details.parameters && ext.details.parameters.length == 0 ? '\r\n    Parameters: None\r\n' : ''),

                    (ext.details.parameters && ext.details.parameters.length > 0 ? ('\r\n    Parameters:\r\n' + ext.details.parameters.collect(function (item, j) {
                        return (' #' + (j + 1)).pad(10) + 'Name:    ' + item.name + '\r\n' +
                            (item.required != true ? '              :    OPTIONAL \r\n' : '') +
                            (item.isMulti == true ? '              :    Multi-parameter \r\n' : '') +
                            (item.defaultValue != undefined ? ' Default Value:    ' + $.toStr(item.defaultValue, true) + '\r\n' : '') +
                            '         Types:    [' + item.types.collect(function (a) { return a.name; }).join(', ') + '] \r\n' +
                            '   Description:    ' + item.description + '\r\n\r\n';
                    }).joinLines() + '\r\n') : ''),

                    ext.details.returnTypeName ? ('\r\n    Return Type: ' + ext.details.returnTypeName + '\r\n') : '',
                    (ext.details.aliases && ext.details.aliases.length > 0 ? ('\r\n    Aliases: \r\n' +
                        ext.details.aliases.collect(function (alias, i) {
                            return ''.pad(13) + ext.target + '.' + alias;
                        }).join(', ') + '\r\n\r\n') : ''),

                    ext.details.returns ? ('\r\n    Returns: \r\n' + ext.details.returns + '\r\n\r\n') : '',

                    (ext.details.examples ? ('\r\n    Examples: \r\n' + ext.details.examples.joinLines()) : ''),

                    (ext.method && includeCode ? ('\r\n    Method Code: \r\n\r\n' + ext.method.toString()) : '')]
                    .joinLines()
                    .replaceAll('\r\n\r\n\r\n', '\r\n\r\n');

                out += '\r\n';

                if (ext.details.unitTests && ext.details.unitTests.length > 0) {
                    out += '    Test Requirements: \r\n';

                    var methodTestsFound = 0;
                    var methodTestsPassed = 0;

                    for (var i = 0; i < sing.extensions[ext.name].details.unitTests.length; i++) {

                        methodTestsFound++;
                        testsFound++;

                        var test = sing.extensions[ext.name].details.unitTests[i];

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
                                out += '        ' + (testPasses ? "" : "").pad(50) +
                                ' TEST CASE FAILS \r\n\r\n';
                            }

                        }
                        catch (ex) {
                            out += '        ' + ext.name.pad(50) + 'TEST CASE FAILS \r\n\r\n';
                        }
                    }
                    if (methodTestsFound > 0) {
                        if (methodTestsFound == methodTestsPassed) {
                            out += '----' + 'All Test Cases Passed\r\n\r\n';
                        }
                        else {
                            out += '----' + methodTestsPassed + ' / ' + methodTestsFound + ' (' + ((methodTestsPassed / methodTestsFound) * 100).round(1) + '%) Test Cases Passed\r\n\r\n';
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
        var totalCount = featuresCount + documentaionCount + testsFound + featuresCount;

        var leftSpace = 40;

        header += '\r\n' +
        'Methods Implemented:      ' + (featuresFound + ' / ' + featuresCount).pad(leftSpace, Direction.r) + ' (' + Math.round((featuresFound / featuresCount) * 100) + '%)' + '\r\n' +
        'Unit Tests Implemented:   ' + (featuresHaveTests + ' / ' + featuresCount).pad(leftSpace, Direction.r) + ' (' + Math.round((featuresHaveTests / featuresCount) * 100) + '%)' + '\r\n' +
        'Unit Tests Passed:        ' + (testsPassed + ' / ' + testsFound).pad(leftSpace, Direction.r) + ' (' + Math.round((testsPassed / testsFound) * 100) + '%)' + '\r\n' +
        'Documentation:            ' + (documentaionFound + ' / ' + documentaionCount).pad(leftSpace, Direction.r) + ' (' + Math.round((documentaionFound / documentaionCount) * 100) + '%)' + '\r\n' +
        '\r\n' +
        'Total:                    ' + (totalFound + ' / ' + totalCount).pad(leftSpace, Direction.r) + ' (' + Math.round((totalFound / totalCount) * 100) + '%)' + '\r\n';

        return header + out;
    };

    getMissing = function (funcName?: string) {

        this.resolveTests();

        var featuresCount = 0;
        var featuresFound = 0;

        var documentaionCount = 0;
        var documentaionFound = 0;

        var header = 'Singularity.TS TypeScript, JavaScript, jQuery, HTML, Extension Method Engine & Library\r\n';
        var out = '';

        $.objEach(sing.extensions, function (key: string, ext: SingularityExtension, i: number) {

            if (funcName &&
                funcName.lower() != '' &&
                funcName.lower() != 'all' &&
                !ext.name.lower().contains(funcName.lower()))
                return;

            featuresCount += 1; // method
            documentaionCount += 5 + // documentation
            1;  // test cases

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

        header += '\r\n' +
        'Methods Implemented:      ' + featuresFound + ' / ' + featuresCount + ' (' + Math.round((featuresFound / featuresCount) * 100) + '%) \r\n' +
        'Documentation:            ' + documentaionFound + ' / ' + documentaionCount + ' (' + Math.round((documentaionFound / documentaionCount) * 100) + '%) \r\n';

        return header + out;

    };

    getSummary = function (funcName?: string) {
        funcName = funcName || 'all';

        var out = sing.getDocs(funcName, false, false);

        out += '\r\n';

        $.objEach(sing.extensions, function (key, ext, i) {

            if (funcName &&
                funcName.lower() != '' &&
                funcName.lower() != 'all' &&
                !ext.name.lower().contains(funcName.lower()))
                return;

            out += '\r\n' + (ext.name + ' ').pad(30);

            out += ((ext.details.returnTypeName || '') + ' function(').pad(20, Direction.r);

            out += ((ext.details && ext.details.parameters) ? ext.details.parameters.collect(function (item, i) {
                var TypeNames = item.types.collect(function (a) { return a.name }).join(', ');
                return (i > 0 ? ''.pad(50) : '') +
                    '[' + TypeNames + '] ' + item.name;
            }).join(', \r\n') : '') +
            ') ' +
            (ext.details && ext.details.parameters && ext.details.parameters.length > 1 ? '\r\n' + ''.pad(50) : '') +
            '{ ... } ';
        });

        return out;
    };

    resolveTests = function () {

        $.objEach(sing.extensions, function (key, ext, i) {

            if (ext && ext.details.tests && $.isFunction(ext.details.tests)) {

                ext.details.tests(ext);

                // Clear it if it's still a function (no tests)
                if ($.isFunction(ext.details.tests))
                    ext.details.tests = [];
            }
        });
    };


    addBooleanExt = function (name: string, method?: Function, details?: SingularityExtensionDetails) {
        this.addExt(name, Boolean, method, details);
    };

    addNumberExt = function (name: string, method?: Function, details?: SingularityExtensionDetails) {
        this.addExt(name, Number, method, details);
    };

    addStringExt = function (name: string, method?: Function, details?: SingularityExtensionDetails) {
        this.addExt(name, String, method, details);
    };

    addDateExt = function (name: string, method?: Function, details?: SingularityExtensionDetails) {
        sing.addExt(name, Date, method, details);
    };

    addFunctionExt = function (name: string, method?: Function, details?: SingularityExtensionDetails) {
        this.addExt(name, Function, method, details);
    };

    addArrayExt = function (name: string, method?: Function, details?: SingularityExtensionDetails) {

        method = sing.addExt(name, Array, method, details, false);

        // Defines an Array extension method without corrupting 'for-in'
        if (!Array.prototype[name] && method) {
            Object.defineProperty(Array.prototype, name, {
                enumerable: false,
                value: method,
            });
        }
    };

    addObjectExt = function (name: string, method?: Function, details?: SingularityExtensionDetails) {

        method = sing.addExt(name, Object, method, details, false);

        // Currently Broken
        if (!Object.prototype[name] && method) {
            Object.defineProperty(Object.prototype, name, {
                enumerable: false,
                value: method,
            });
        }
    };

    addjQueryExt = function (name: string, method?: Function, details?: SingularityExtensionDetails) {

        sing.addExt(name, $, method, details, false);

        if (!$[name] && method)
            $[name] = method;
    };

    addjQueryFnExt = function (name: string, method: Function, details: SingularityExtensionDetails) {

        sing.addExt(name, $.fn, method, details, false);

        if (!$.fn[name] && method)
            $.fn[name] = method;
    };

    addExt = function (name: string, extendTarget: any, method: Function, details: SingularityExtensionDetails, performAdd: boolean = true) {

        if (sing.extensions[extendTarget.name + '.' + name])
            throw extendTarget.name + '.' + name + ' already exists.';

        var methods = [
            {
                name: name,
                target: extendTarget,
                method: method
            }];

        // If there are aliases defined, they will all be added using the same method.
        if (details && details.aliases && details.aliases.length > 0) {
            for (var i = 0; i < details.aliases.length; i++) {
                methods.push(
                    {
                        name: details.aliases[i],
                        target: extendTarget,
                        method: method
                    });
            }
        }


        for (var i = 0; i < methods.length; i++) {

            var ext = new SingularityExtension(details, extendTarget, methods[i].name, methods[i].method);

            if (performAdd && !methods[i].target.prototype[methods[i].name] && ext.method)
                methods[i].target.prototype[methods[i].name] = ext.method;

            sing.extensions[methods[i].target.name + '.' + methods[i].name] = ext;

            if (i > 0)
                sing.extensions[methods[i].target.name + '.' + methods[i].name].isAlias = true;
        }

        return method;
    };


}

class SingularityAutoDefinition {

    validateInput: boolean = true;
    injectDefaultInputValue: boolean = true;

    ignoreErrors: boolean = false;
    logErrors: boolean = false;

    logExecution: boolean = false;
    timeExecution: boolean = false;
    makeAsync: boolean = false;
    cacheResults: boolean = false;
    retryTimes: number = 0;

    resultAsArray: boolean = false;
    defaultResult: any;
    overrideResult: any;

    constructor(source?: SingularityAutoDefinition) {

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
}

class SingularityExtension {
    details: SingularityExtensionDetails;

    isAlias: boolean = false;

    shortName: string;
    name: string;
    target: string;
    targetType: INamed;
    methodCall: string;

    method: Function;

    data: Object;

    auto: SingularityAutoDefinition = new SingularityAutoDefinition();

    constructor(details: SingularityExtensionDetails = {},
        target?: any,
        name?: string,
        method?: Function) {
        var ext = this;

        this.name = target.name + '.' + name;
        this.shortName = name;
        this.target = target.name;
        this.targetType = target;
        this.details = details;
        this.method = method;

        if (this.details.returnType && !this.details.returnType.name)
            throw name;

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

        if (this.auto.defaultResult !== undefined &&
            this.auto.overrideResult !== undefined)
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

    private loadAutoIgnoreErrors = function (ext: SingularityExtension, methods: Function[]) {
        if (ext.auto.ignoreErrors) {

            var lastMethod_ignoreErrors = methods[methods.length - 1];

            methods.push(function () {
                ////////////////////////////////////////////////////////////
                // NO Extensions are allowed within this method
                ////////////////////////////////////////////////////////////
                try {
                    return lastMethod_ignoreErrors.apply(this, arguments);
                }
                catch (ex) {
                    return;
                }
            });
        }
    }
    private loadAutoLogErrors = function (ext: SingularityExtension, methods: Function[]) {

        if (ext.auto.logErrors) {
            var lastMethod_logErrors = methods[methods.length - 1];

            methods.push(function () {
                ////////////////////////////////////////////////////////////
                // NO Extensions are allowed within this method
                ////////////////////////////////////////////////////////////
                try {
                    return lastMethod_logErrors.apply(this, arguments);
                }
                catch (ex) {
                    log(ext.name + ' Error: ' + ex);
                    return;
                }
            });
        }
    }
    private loadAutoLogExecution = function (ext: SingularityExtension, methods: Function[]) {
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
    }
    private loadAutoTimeExecution = function (ext: SingularityExtension, methods: Function[]) {

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
    }
    private loadAutoDefaultResult = function (ext: SingularityExtension, methods: Function[]) {

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
    }
    private loadAutoOverrideResult = function (ext: SingularityExtension, methods: Function[]) {

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
    }
    private loadAutoCacheResults = function (ext: SingularityExtension, methods: Function[]) {

        if (this.auto.cacheResults) {

        }
    }
    private loadAutoResultAsArray = function (ext: SingularityExtension, methods: Function[]) {

        if (ext.auto.resultAsArray) {
            var lastMethod_resultAsArray = methods[methods.length - 1];

            methods.push(function () {
                ////////////////////////////////////////////////////////////
                // NO Extensions are allowed within this method
                ////////////////////////////////////////////////////////////
                var result = lastMethod_resultAsArray.apply(this, arguments);

                if (!$.isArray(result)) {
                    if (result === null || result === undefined)
                        return []
                    else
                        return [result]
                }

                return result;
            });
        }
    }
    private loadAutoMakeAsync = function (ext: SingularityExtension, methods: Function[]) {


        if (this.auto.makeAsync) {

            this.details.parameters.push(
                {
                    name: 'callback',
                    metod: [Function],
                    description: 'This callback function will be executed when ' + ext.shortName +
                    ' has finished executing. It will be passed the result as its only argument',
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
    }
    private loadAutoRetry = function (ext: SingularityExtension, methods: Function[]) {

        if (this.auto.retryTimes > 0) {
            var lastMethod_retryTimes = methods[methods.length - 1];

            methods.push(function () {
                ////////////////////////////////////////////////////////////
                // NO Extensions are allowed within this method
                ////////////////////////////////////////////////////////////
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
    }
    private loadInputValidation = function (ext: SingularityExtension, methods: Function[]) {

        if (ext.method &&
            ext.details.parameters &&
            ext.details.parameters.length > 0 &&
            (ext.auto.validateInput == true || ext.auto.injectDefaultInputValue == true)) {

            var srcext = ext;

            var lastMethod_validateInput = methods[methods.length - 1];

            methods.push(function () {
                ////////////////////////////////////////////////////////////
                // NO Extensions are allowed within ext method
                ////////////////////////////////////////////////////////////

                var keys = Object.keys(arguments);

                var args = [];

                for (var j = 0; j < keys.length; j++)
                    args.push(arguments[keys[j]])

                for (var i = 0; i < srcext.details.parameters.length; i++) {
                    var param = srcext.details.parameters[i];
                    var testArg = args[i];
                    // validate params

                    var typeNames: string = '';
                    var typeNamesArray = [];

                    for (var j = 0; j < param.types.length; j++) {
                        typeNames += param.types[j].name;
                        typeNamesArray.push(param.types[j].name.lower());
                        if (j < param.types.length - 1)
                            typeNames += ', ';
                    }

                    if (param.required == true) {
                        if (testArg === null ||
                            testArg === undefined) {

                            // If a defaultValue is defined, substitute it and continue
                            if (param.defaultValue != null &&
                                param.defaultValue != undefined &&
                                ext.auto.injectDefaultInputValue == true) {
                                args[i] = testArg = param.defaultValue;
                            }
                            else if (ext.auto.validateInput == true)
                                throw ext.target + '.' + ext.shortName + ' Missing Parameter: ' + typeNames + ' ' + param.name + '';
                        }
                    }
                    else if (testArg === null || testArg === undefined) {
                        // Missing parameter but it's not required. Do nothing.
                    }


                    if (!param.types ||
                        param.types.length == 0 ||
                        param.types.indexOf(Object) >= 0) {
                        // Don't restrict input for Object type or non-defined types
                    }
                    else if (ext.auto.validateInput == true) {
                        if ((typeof testArg).lower() == 'object' &&
                            typeNamesArray.contains('array') &&
                            testArg != null &&
                            testArg.length != null &&
                            testArg.concat != null) {
                            // Array matches type of object
                        }
                        else if (!typeNamesArray.contains(typeof testArg)) {
                            if (param.required == true) {
                                throw ext.target + '.' + ext.shortName + '  Parameter: ' + param.name + ': ' + $.toStr(testArg, true) + ' ' +
                                (typeof testArg).lower() + ' did not match input type ' + $.toStr(typeNamesArray, true) + '.';
                            }
                            else {
                                // Wrong type but it's not required. Do nothing.
                            }
                        }
                    }
                }

                return lastMethod_validateInput.apply(this, arguments)
            });
        }
    }

    private loadMethodCall = function (ext: SingularityExtension) {

        ext.methodCall = ext.targetType.name + '.' + ext.name;

        // Configure type-specific defaults or use the global defaults
        var autoDefault = sing.autoDefault;

        if (sing.types[ext.targetType.name] && sing.types[ext.targetType.name].autoDefault)
            autoDefault = sing.types[ext.targetType.name].autoDefault;

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
                ext.methodCall += '[' + ext.details.parameters[j].types.collect(function (a) { return a.name; }).join(', ') + '] ';
                ext.methodCall += ext.details.parameters[j].name;
                if (j < ext.details.parameters.length - 1)
                    ext.methodCall += ', ';
            }
        }
        ext.methodCall += ');';
    }

    addTest = function (caller: any, args: any[], result: any, requirement?: string) {
        sing.addMethodTest(this, caller, args, result, requirement);
    };

    addCustomTest = function (caller: any, testFunc: () => any, requirement?: string) {
        sing.addCustomTest(this.name, testFunc, requirement);
    };

    addFailsTest = function (caller: any, args: any[], expectedError?: string, requirement?: string) {
        sing.addFailsTest(this, caller, args, expectedError, requirement);
    };
}

interface SingularityExtensionDetails {

    summary?: string;

    returns?: string;
    returnType?: INamed;
    returnTypeName?: string;

    examples?: string[];

    aliases?: string[];

    auto?: SingularityAutoDefinition;

    parameters?: SingularityParameter[];

    tests?: (ext: SingularityExtension) => void;
    unitTests?: SingularityTest[];
}

interface SingularityParameter {

    name: string;

    defaultValue?: any;
    required?: boolean;

    isMulti?: boolean;

    types?: INamed[];
    description?: string;
}

class SingularityTest {

    constructor(public name: string,
        public testFunc: Function,
        public requirement?: string) {
    }
}

var sing = new Singularity();

class Direction {
    static left = 'left';
    static right = 'right';
    static center = 'center';
    static l = 'l';
    static r = 'r';
    static c = 'c';
}


var LOGGING_ENABLED = true;

function log(message) {
    if (LOGGING_ENABLED)
        console.log(message);
}

function Singularity_AddCustomFailsTest(name, testFunc, expectedError, requirement) {

    sing.addTest(name, function (): any {
        try {

            testFunc();
            return name + ' was expected to fail but it did not. \r\n\r\n' +
                testFunc.toString() + '\r\n';

        }
        catch (ex) {

            if (expectedError && ex != expectedError)
                return name + ' was expected to fail with a message of \'' + expectedError + '\' \r\n' +
                    'but instead failed with error \'' + ex + '\'';

            testFunc.toString() + '\r\n';

            return true;
        }
    }, requirement);
}


$().init(function () {
    SingularityInit();
});

function SingularityInit() {

    $.noConflict();

    InitSingularityJS();
    InitSingularityJS_jQuery();

    InitHTMLExtensions();

    InitFields();
}


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
