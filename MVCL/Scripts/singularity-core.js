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
var Singularity = (function () {
    function Singularity() {
        this.AutoDefinition = SingularityAutoDefinition;
        this.Extension = SingularityExtension;
        this.enableTests = true;
        this.extensions = {};
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
            Boolean: {},
            Number: {},
            String: {},
            Array: {},
            Function: {},
            Date: {},
            $: {}
        };
        this.autoDefault = new SingularityAutoDefinition();
        this.addTest = function (name, testFunc, requirement) {
            if (!sing.extensions[name])
                throw name + ' not found';
            if (!sing.extensions[name].details.tests)
                throw name + ' tests not found';
            if ($.isFunction(sing.extensions[name].details.tests))
                sing.extensions[name].details.unitTests = sing.extensions[name].details.unitTests || [];
            sing.extensions[name].details.unitTests = sing.extensions[name].details.unitTests.concat(new SingularityTest(name, testFunc, requirement));
        };
        this.addCustomTest = function (name, testFunc, requirement) {
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
        this.addMethodTest = function (ext, target, args, compare, requirement) {
            if (!ext.method)
                throw ext.name + ' method not found';
            requirement = (requirement ? (requirement + '\r\n') : '') + '(' + $.toStr(target, true) + ').' + ext.shortName;
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
        };
        this.addAssertTest = function (name, result, compare, requirement) {
            requirement = requirement || $.toStr(compare, true) + ' is expected to match result: ' + $.toStr(result, true);
            this.addTest(name, function () {
                if (compare == result)
                    return true;
                else if ($.toStr(compare) == $.toStr(result))
                    return true;
                else
                    return requirement + '\r\n' + ' TEST FAILED \r\n';
            }, requirement);
        };
        this.addFailsTest = function (ext, target, args, expectedError, requirement) {
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
        };
        this.runTests = function (display) {
            if (display === void 0) { display = false; }
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
                }
                ;
            }
            return sing.listTests() + '\r\n' + displayStr + '\r\n' + (result || '\r\n\r\nAll ' + testCount + ' tests succeeded.');
        };
        this.listTests = function () {
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
        this.listMissingTests = function () {
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
        this.getDocs = function (funcName, includeCode, includeDocumentation) {
            if (includeCode === void 0) { includeCode = false; }
            if (includeDocumentation === void 0) { includeDocumentation = true; }
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
            $.objEach(sing.extensions, function (key, ext, index) {
                if (funcName && funcName.lower() != '' && funcName.lower() != 'all' && !ext.name.lower().contains(funcName.lower()))
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
                            return ''.pad(13) + ext.target + '.' + alias;
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
            header += '\r\n' + 'Methods Implemented:      ' + (featuresFound + ' / ' + featuresCount).pad(leftSpace, Direction.r) + ' (' + Math.round((featuresFound / featuresCount) * 100) + '%)' + '\r\n' + 'Unit Tests Implemented:   ' + (featuresHaveTests + ' / ' + featuresCount).pad(leftSpace, Direction.r) + ' (' + Math.round((featuresHaveTests / featuresCount) * 100) + '%)' + '\r\n' + 'Unit Tests Passed:        ' + (testsPassed + ' / ' + testsFound).pad(leftSpace, Direction.r) + ' (' + Math.round((testsPassed / testsFound) * 100) + '%)' + '\r\n' + 'Documentation:            ' + (documentaionFound + ' / ' + documentaionCount).pad(leftSpace, Direction.r) + ' (' + Math.round((documentaionFound / documentaionCount) * 100) + '%)' + '\r\n' + '\r\n' + 'Total:                    ' + (totalFound + ' / ' + totalCount).pad(leftSpace, Direction.r) + ' (' + Math.round((totalFound / totalCount) * 100) + '%)' + '\r\n';
            return header + out;
        };
        this.getMissing = function (funcName) {
            this.resolveTests();
            var featuresCount = 0;
            var featuresFound = 0;
            var documentaionCount = 0;
            var documentaionFound = 0;
            var header = 'Singularity.TS TypeScript, JavaScript, jQuery, HTML, Extension Method Engine & Library\r\n';
            var out = '';
            $.objEach(sing.extensions, function (key, ext, i) {
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
        };
        this.getSummary = function (funcName, includeFunctions) {
            if (funcName === void 0) { funcName = 'all'; }
            if (includeFunctions === void 0) { includeFunctions = true; }
            var out = sing.getDocs(funcName, false, false);
            out += '\r\n';
            if (funcName != '' && funcName != 'all') {
                out += 'Search: ' + funcName;
            }
            if (includeFunctions) {
                $.objEach(sing.extensions, function (key, ext, i) {
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
        };
        this.resolveTests = function () {
            $.objEach(sing.extensions, function (key, ext, i) {
                if (ext && ext.details.tests && $.isFunction(ext.details.tests)) {
                    ext.details.tests(ext);
                    // Clear it if it's still a function (no tests)
                    if ($.isFunction(ext.details.tests))
                        ext.details.tests = [];
                }
            });
        };
        this.addBooleanExt = function (name, method, details) {
            this.addExt(name, Boolean, method, details);
        };
        this.addNumberExt = function (name, method, details) {
            this.addExt(name, Number, method, details);
        };
        this.addStringExt = function (name, method, details) {
            this.addExt(name, String, method, details);
        };
        this.addDateExt = function (name, method, details) {
            sing.addExt(name, Date, method, details);
        };
        this.addFunctionExt = function (name, method, details) {
            this.addExt(name, Function, method, details);
        };
        this.addArrayExt = function (name, method, details) {
            method = sing.addExt(name, Array, method, details, false);
            // Defines an Array extension method without corrupting 'for-in'
            if (!Array.prototype[name] && method) {
                Object.defineProperty(Array.prototype, name, {
                    enumerable: false,
                    value: method,
                });
            }
        };
        this.addObjectExt = function (name, method, details) {
            method = sing.addExt(name, Object, method, details, false);
            // Currently Broken
            if (!Object.prototype[name] && method) {
                Object.defineProperty(Object.prototype, name, {
                    enumerable: false,
                    value: method,
                });
            }
        };
        this.addjQueryExt = function (name, method, details) {
            sing.addExt(name, $, method, details, false);
            if (!$[name] && method)
                $[name] = method;
        };
        this.addjQueryFnExt = function (name, method, details) {
            sing.addExt(name, $.fn, method, details, false);
            if (!$.fn[name] && method)
                $.fn[name] = method;
        };
        this.addExt = function (name, extendTarget, method, details, performAdd) {
            if (performAdd === void 0) { performAdd = true; }
            if (sing.extensions[extendTarget.name + '.' + name])
                throw extendTarget.name + '.' + name + ' already exists.';
            var methods = [
                {
                    name: name,
                    target: extendTarget,
                    method: method
                }
            ];
            // If there are aliases defined, they will all be added using the same method.
            if (details && details.aliases && details.aliases.length > 0) {
                for (var i = 0; i < details.aliases.length; i++) {
                    methods.push({
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
    return Singularity;
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
var SingularityExtension = (function () {
    function SingularityExtension(details, target, name, method) {
        if (details === void 0) { details = {}; }
        this.isAlias = false;
        this.auto = new SingularityAutoDefinition();
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
                    for (var j = 0; j < keys.length; j++)
                        args.push(arguments[keys[j]]);
                    for (var i = 0; i < srcext.details.parameters.length; i++) {
                        var param = srcext.details.parameters[i];
                        var testArg = args[i];
                        // validate params
                        var typeNames = '';
                        var typeNamesArray = [];
                        for (var j = 0; j < param.types.length; j++) {
                            typeNames += param.types[j].name;
                            typeNamesArray.push(param.types[j].name.lower());
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
                                    throw ext.target + '.' + ext.shortName + ' Missing Parameter: ' + typeNames + ' ' + param.name + '';
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
                                    throw ext.target + '.' + ext.shortName + '  Parameter: ' + param.name + ': ' + $.toStr(testArg, true) + ' ' + (typeof testArg).lower() + ' did not match input type ' + $.toStr(typeNamesArray, true) + '.';
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
                    ext.methodCall += '[' + ext.details.parameters[j].types.collect(function (a) {
                        return a.name;
                    }).join(', ') + '] ';
                    ext.methodCall += ext.details.parameters[j].name;
                    if (j < ext.details.parameters.length - 1)
                        ext.methodCall += ', ';
                }
            }
            ext.methodCall += ');';
        };
        this.addTest = function (caller, args, result, requirement) {
            sing.addMethodTest(this, caller, args, result, requirement);
        };
        this.addCustomTest = function (caller, testFunc, requirement) {
            sing.addCustomTest(this.name, testFunc, requirement);
        };
        this.addFailsTest = function (caller, args, expectedError, requirement) {
            sing.addFailsTest(this, caller, args, expectedError, requirement);
        };
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
    return SingularityExtension;
})();
var SingularityTest = (function () {
    function SingularityTest(name, testFunc, requirement) {
        this.name = name;
        this.testFunc = testFunc;
        this.requirement = requirement;
    }
    return SingularityTest;
})();
var sing = new Singularity();
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
var LOGGING_ENABLED = true;
function log(message) {
    if (LOGGING_ENABLED)
        console.log(message);
}
function Singularity_AddCustomFailsTest(name, testFunc, expectedError, requirement) {
    sing.addTest(name, function () {
        try {
            testFunc();
            return name + ' was expected to fail but it did not. \r\n\r\n' + testFunc.toString() + '\r\n';
        }
        catch (ex) {
            if (expectedError && ex != expectedError)
                return name + ' was expected to fail with a message of \'' + expectedError + '\' \r\n' + 'but instead failed with error \'' + ex + '\'';
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
//# sourceMappingURL=singularity-core.js.map