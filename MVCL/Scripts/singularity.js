

//////////////////////////////////////////////////////
//
// Singularity.JS JavaScript, jQuery, HTML, Extension Method Engine & Library
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
                
                // If this value is NOT set then the parameter will be checked before the function is ran. If it's null
                // and no defaultValue is set, then an error will be thrown.
                optional: true,

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

            // Validates the input parameters to ensure they are not empty (based on the parameter.optional flag)
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


global: sing = function () {
    return {

        enableTests: true,

        extensions: {

        },

        func: {
            empty: function () { },

            identity: function (obj) { return obj; },
            equals: function (obj, obj2) { return obj == obj2; },

            increment: function (i) { return i + 1; },

            booleanNot: function (obj) { return !obj; },

            toString: function (obj) { return obj.toString(); },
        },

        types: {
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
        },

        autoDefaults: {
            // On by default
            validateInput: true,
            injectDefaultInputValue: true,

            // All others Off by default
            ignoreErrors: false,
            logErrors: false,
            retryTimes: 0,

            logExecution: false,
            timeExecution: false,

            makeAsync: false,

            cacheResults: false,
            defaultResult: undefined,
            overrideResult: undefined,
            resultAsArray: false,
        },

        extensionTypes: ["Boolean", "Number", "String", "Array", "Function", "Date", "$."],

        addTest: Singularity_AddTest,

        addCustomTest: Singularity_AddCustomTest,

        addMethodTest: Singularity_AddMethodTest,

        addAssertTest: Singularity_AddAssertTest,

        addFailsTest: Singularity_AddFailsTest,

        runTests: Singularity_RunTests,

        listTests: Singularity_ListTests,

        listMissingTests: Singularity_ListMissingTests,

        getDocs: Singularity_GetDocumentation,
        getMissing: Singularity_GetMissingElements,
        getSummary: Singularity_GetSummary,


        addBooleanExt: Singularity_AddBooleanExt,
        addNumberExt: Singularity_AddNumberExt,
        addStringExt: Singularity_AddStringExt,
        addDateExt: Singularity_AddDateExt,
        addFunctionExt: Singularity_AddFunctionExt,
        addArrayExt: Singularity_AddArrayExt,
        addObjectExt: Singularity_AddObjectExt,
        addjQueryExt: Singularity_AddjQueryExt,
        addjQueryFnExt: Singularity_AddjQueryFnExt,
        addExt: Singularity_AddExt,
    };
};

function SingularityExtension(target, name, method, details) {

    var ext = this;

    details = details || {};

    this.name = target.name + '.' + name;
    this.shortName = name;
    this.target = target.name;
    this.details = details;
    this.method = method;

    if (this.details.returnType && !this.details.returnType.name)
        throw name;

    if (details.returnType)
        this.details.returnTypeName = this.details.returnType.name;
    else
        this.details.returnTypeName = 'void';

    this.methodCall = target.name + '.' + name;

    // Configure type-specific defaults or use the global defaults
    var autoDefault = sing.autoDefault;

    if (sing.types[target.name] && sing.types[target.name].autoDefault)
        autoDefault = sing.types[target.name].autoDefault;

    this.auto = new SingularityAutoDefinition(autoDefault);

    // Inherits auto values passed using details
    if (details && details.auto) {
        for (var arg in details.auto) {
            this.auto[arg] = details.auto[arg];
        }

        details.auto = undefined;
    }

    this.methodCall += '(';

    if (details && details.parameters) {
        for (var j = 0; j < details.parameters.length; j++) {
            this.methodCall += '[' + details.parameters[j].types.collect(function (a) { return a.name; }).join(', ') + '] ';
            this.methodCall += details.parameters[j].name;
            if (j < details.parameters.length - 1)
                this.methodCall += ', ';
        }
    }
    this.methodCall += ');';


    var methods = [this.method];

    // Validates input fields based on parameter options set in the details
    // Checks that non-optional fields are included and that the inputs passed match one of the parameter types given

    var auto = this.auto;

    if (this.method &&
        this.details.parameters &&
        this.details.parameters.length > 0 &&
        (auto.validateInput == true || auto.injectDefaultInputValue == true)) {

        var srcThis = this;

        var lastMethod_validateInput = methods[methods.length - 1];

        methods.push(function () {
            ////////////////////////////////////////////////////////////
            // NO Extensions are allowed within this method
            ////////////////////////////////////////////////////////////

            var keys = Object.keys(arguments);

            var args = [];

            for (var j = 0; j < keys.length; j++)
                args.push(arguments[keys[j]])

            for (var i = 0; i < srcThis.details.parameters.length; i++) {
                var param = srcThis.details.parameters[i];
                var testArg = args[i];
                // validate params

                var typeNames = '';

                for (var j = 0; j < param.types.length; j++) {
                    typeNames += param.types[j].name;
                    if (j < param.types.length - 1)
                        typeNames += ', ';
                }

                if (!param.optional) {
                    if (testArg === null ||
                        testArg === undefined) {

                        // If a defaultValue is defined, substitute it and continue
                        if (param.defaultValue != null &&
                            param.defaultValue != undefined &&
                            auto.injectDefaultInputValue == true) {
                            args[i] = testArg = param.defaultValue;
                        }
                        else if (auto.validateInput == true)
                            throw target.name + '.' + name + ' Missing Parameter: ' + typeNames + ' ' + param.name + '';
                    }
                }
                else if (testArg === null || testArg === undefined) {
                    // Missing parameter but it's not required. Do nothing.
                }
                else {
                    if (!param.types ||
                        param.types.length == 0 ||
                        param.types.indexOf(Object) >= 0) {
                        // Don't restrict input for Object type or non-defined types
                    }
                    else if (auto.validateInput == true) {
                        if (param.types.indexOf(testArg.constructor) < 0) {
                            throw target.name + '.' + name + '  Parameter: ' + testArg + ' ' + param.name +
                                ' did not match input type [' + typeNames + '].';
                        }
                    }
                }
            }

            return lastMethod_validateInput.apply(this, arguments)
        });
        /*
        for (i = 0; i < this.details.parameters.length; i++) {

            if (this.details.parameters[i].types &&
                !$.isArray(this.details.parameters[i].types)) {
                this.details.parameters[i].types = [this.details.parameters[i].types];
            }

            var param = this.details.parameters[i];

            var lastMethod = methods[methods.length - 1];

            // We must duplicate i here to avoid invalid i values when the methods are called
            var _i = i;
            var srcThis = null;

            methods.push(function () {
                ////////////////////////////////////////////////////////////
                // NO Extensions are allowed within this method
                ////////////////////////////////////////////////////////////

                srcThis = srcThis || this;

                var keys = Object.keys(arguments);

                var args = [];

                for (var j = 0; j < keys.length; j++)
                    args.push(arguments[keys[j]])

                var testArg = args[_i];

                var typeNames = '';

                for (var j = 0; j < param.types.length; j++) {
                    typeNames += param.types[j].name;
                    if (j < param.types.length - 1)
                        typeNames += ', ';
                }


                if (!param.optional) {
                    if (testArg == null ||
                        testArg == undefined) {
                        // If a defaultValue is defined, substitute it and continue
                        if (param.defaultValue != null &&
                            param.defaultValue != undefined &&
                            auto.injectDefaultInputValue != false)
                            args[_i] = param.defaultValue;
                        else if (auto.validateInput != false)
                            throw target.name + '.' + name + ' Missing Parameter: ' + typeNames + ' ' + param.name + '';
                    }
                }
                else if (testArg == null) {
                    // Missing parameter but it's not required. Do nothing.
                }
                else {
                    if (!param.types ||
                        param.types.length == 0 ||
                        param.types.indexOf(Object) >= 0) {
                        // Don't restrict input for Object type or non-defined types
                    }
                    else if (auto.validateInput != false) {
                        if (param.types.indexOf(testArg.constructor) < 0) {
                            throw target.name + '.' + name + '  Parameter: ' + testArg + ' ' + param.name +
                                ' did not match input type [' + typeNames + '].';
                        }
                    }
                }

                return lastMethod.apply(srcThis, args);
            });
            */
    }


    if (this.auto.ignoreErrors && this.auto.logErrors)
        throw 'Unable to Ignore as well as Log errors.';

    if (this.auto.defaultResult !== undefined &&
        this.auto.overrideResult !== undefined)
        throw 'Unable to set both Default and Override Result.';

    if (this.auto.retryTimes > 0) {
        var lastMethod_retryTimes = methods[methods.length - 1];

        methods.push(function () {
            ////////////////////////////////////////////////////////////
            // NO Extensions are allowed within this method
            ////////////////////////////////////////////////////////////
            for (var attempt = 0; attempt < auto.retryTimes + 1; attempt++) {
                try {
                    return lastMethod_retryTimes.apply(this, arguments);
                }
                catch (ex) {
                    if (attempt == auto.retryTimes - 1)
                        throw 'Failed after ' + (auto.retryTimes + 1) + ' tries. ' + ex;
                }
            }
        });
    }

    if (this.auto.ignoreErrors) {

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
    if (this.auto.logErrors) {
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

    if (this.auto.logExecution) {
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

    if (this.auto.timeExecution) {
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

    if (this.auto.defaultResult !== undefined) {

        var lastMethod_defaultResult = methods[methods.length - 1];
        methods.push(function () {
            ////////////////////////////////////////////////////////////
            // NO Extensions are allowed within this method
            ////////////////////////////////////////////////////////////
            var result = lastMethod_defaultResult.apply(this, arguments);

            if (result === undefined || result === null) {
                result = auto.defaultResult;
            }

            return result;
        });
    }

    if (this.auto.overrideResult !== undefined) {

        var lastMethod_overrideResult = methods[methods.length - 1];

        methods.push(function () {
            ////////////////////////////////////////////////////////////
            // NO Extensions are allowed within this method
            ////////////////////////////////////////////////////////////
            var result = lastMethod_overrideResult.apply(this, arguments);

            return auto.overrideResult;
        });
    }

    if (this.auto.cacheResults) {

    }

    if (this.auto.resultAsArray) {
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

    if (this.auto.makeAsync) {
        this.details.parameters.push(
            {
                name: 'callback',
                types: [Function],
                optional: true,
                description: 'This callback function will be executed when ' + ext.shortName + ' has finished executing. It will be passed the result as its only argument',
            });

        var callbackIndex = this.details.parameters.length - 1;
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

    this.method = methods[methods.length - 1];


    this.addTest = function (caller, args, result) {
        sing.addMethodTest(this, caller, args, result);
    };

    this.addCustomTest = function (caller, testFunc, result) {
        sing.addCustomTest(this.name, caller, testFunc, result);
    };

    this.addFailsTest = function (caller, args, expectedError, requirement) {
        Singularity_AddFailsTestArgs(this, caller, args, expectedError, requirement);
    };

}

function SingularityAutoDefinition(source) {

    source = source || sing.autoDefaults;

    this.validateInput = source.validateInput || sing.autoDefaults.validateInput;
    this.injectDefaultInputValue = source.injectDefaultInputValue || sing.autoDefaults.injectDefaultInputValue;

    // Implement
    this.ignoreErrors = source.ignoreErrors || sing.autoDefaults.ignoreErrors;
    this.logErrors = source.logErrors || sing.autoDefaults.logErrors;
    this.logExecution = source.logExecution || sing.autoDefaults.logExecution;
    this.timeExecution = source.timeExecution || sing.autoDefaults.timeExecution;
    this.makeAsync = source.makeAsync || sing.autoDefaults.makeAsync;
    this.cacheResults = source.cacheResults || sing.autoDefaults.cacheResults;
    this.retryTimes = source.retryTimes || sing.autoDefaults.retryTimes;
    this.defaultResult = source.defaultResult || sing.autoDefaults.defaultResult;
    this.overrideResult = source.overrideResult || sing.autoDefaults.overrideResult;
    this.resultAsArray = source.resultAsArray || sing.autoDefaults.resultAsArray;
}

function Singularity_AddBooleanExt(name, method, details) {
    sing.addExt(name, Boolean, method, details);
}

function Singularity_AddNumberExt(name, method, details) {
    sing.addExt(name, Number, method, details);
}

function Singularity_AddStringExt(name, method, details) {
    sing.addExt(name, String, method, details);
}

function Singularity_AddDateExt(name, method, details) {
    sing.addExt(name, Date, method, details);
}

function Singularity_AddFunctionExt(name, method, details) {
    sing.addExt(name, Function, method, details);
}

function Singularity_AddArrayExt(name, method, details) {

    method = sing.addExt(name, Array, method, details, false);

    // Defines an Array extension method without corrupting 'for-in'
    if (!Array.prototype[name] && method) {
        Object.defineProperty(Array.prototype, name, {
            enumerable: false,
            value: method,
        });
    }
}

function Singularity_AddObjectExt(name, method, details) {

    method = sing.addExt(name, Object, method, details, false);

    // Currently Broken
    if (!Object.prototype[name] && method) {
        Object.defineProperty(Object.prototype, name, {
            enumerable: false,
            value: method,
        });
    }
}

function Singularity_AddjQueryExt(name, method, details) {

    sing.addExt(name, $, method, details, false);

    if (!$[name] && method)
        $[name] = method;
}

function Singularity_AddjQueryFnExt(name, method, details) {

    sing.addExt(name, $.fn, method, details, false);

    if (!$.fn[name] && method)
        $.fn[name] = method;
}

function Singularity_AddExt(name, extendTarget, method, details, performAdd) {

    if (performAdd == undefined || performAdd == null || performAdd != false)
        performAdd = true;

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

        var ext = new SingularityExtension(extendTarget, methods[i].name, methods[i].method, details);

        if (performAdd && !methods[i].target.prototype[methods[i].name] && ext.method)
            methods[i].target.prototype[methods[i].name] = ext.method;

        sing.extensions[methods[i].target.name + '.' + methods[i].name] = ext;

        if (i > 0)
            sing.extensions[methods[i].target.name + '.' + methods[i].name].isAlias = true;
    }

    return method;
}

function Singularity_AddTest(name, testFunc, requirement) {
    if (!$.isString(name))
        throw name + ' was not a string';

    if (!sing.extensions[name])
        throw name + ' not found';

    if (!sing.extensions[name].details.tests)
        throw name + ' tests not found';

    if ($.isFunction(sing.extensions[name].details.tests))
        sing.extensions[name].details.tests = [];

    sing.extensions[name].details.tests = sing.extensions[name].details.tests.concat(
        {
            name: name,
            testFunc: testFunc,
            requirement: requirement,
        });
}

function Singularity_AddCustomTest(name, testFunc, requirement) {
    if (!$.isString(name))
        throw name + ' was not a string';

    if (!sing.extensions[name])
        throw name + ' not found';

    if (!sing.extensions[name].details.tests)
        throw name + ' tests not found';

    if ($.isFunction(sing.extensions[name].details.tests))
        sing.extensions[name].details.tests = [];

    requirement = requirement || '';

    requirement += '\r\n' + testFunc.toString() + '\r\n';

    sing.extensions[name].details.tests = sing.extensions[name].details.tests.concat(
        {
            name: name,
            testFunc: testFunc,
            requirement: requirement,
        });
}

function Singularity_AddMethodTest(ext, target, args, compare, requirement) {
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

    requirement += ' == (' + $.toStr(compare, true) + ')';

    sing.addTest(ext.name, function () {
        var result = ext.method.apply(target, args);

        if (compare == result)
            return true;
        else if ($.toStr(compare) == $.toStr(result))
            return true;
        else
            return requirement + '\r\n' +
                $.toStr(compare, true) + ' expected, result: ' + $.toStr(result, true);
    }, requirement);

}

function Singularity_AddAssertTest(name, result, compare, requirement) {

    requirement = requirement || $.toStr(compare, true) + ' is expected to match result: ' + $.toStr(result, true)

    sing.addTest(name, function () {
        if (compare == result)
            return true;
        else if ($.toStr(compare) == $.toStr(result))
            return true;
        else
            return requirement + '\r\n' +
                ' TEST FAILED \r\n';
    }, requirement);
}

function Singularity_AddFailsTestArgs(ext, target, args, expectedError, requirement) {

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

    sing.addTest(ext.name, function () {

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
}

function Singularity_AddFailsTest(name, testFunc, expectedError, requirement) {

    sing.addTest(name, function () {
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

function Singularity_RunTests(display) {

    Singularity_ResolveTests();

    var result;
    var testCount = 0;

    var displayStr = '';

    for (var i = 0; i < Object.keys(sing.extensions).length; i++) {

        var name = Object.keys(sing.extensions)[i];

        var ext = sing.extensions[name];
        var tests = ext.details.tests;

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
}

function Singularity_ListTests() {

    Singularity_ResolveTests();

    var out = '\r\n';

    for (var i = 0; i < Object.keys(sing.extensions).length; i++) {

        var name = Object.keys(sing.extensions)[i];

        var item = sing.extensions[name];
        var tests = item.details.tests;

        if (tests && tests.length > 0)
            out += ('Extension: ' + name).pad(30) + '      Tests: ' + tests.length + '\r\n';
        else
            ; // out += 'Function: ' + name + '      Tests: 0\r\n';
    }

    return out;
}

function Singularity_ListMissingTests() {

    Singularity_ResolveTests();

    var out = '';

    for (var i = 0; i < Object.keys(sing.extensions).length; i++) {

        var name = Object.keys(sing.extensions)[i];

        var item = sing.extensions[name];
        var tests = item.details.tests;

        if (!tests || tests.length == 0) {
            out += 'Extension: ' + name + '      Tests: 0\r\n';
        }
    }

    return out;
}

function Singularity_ResolveTests() {

    $.objectEach(sing.extensions, function (key, ext, i) {

        if (ext && ext.details.tests && $.isFunction(ext.details.tests)) {

            ext.details.tests(ext);

            // Clear it if it's still a function (no tests)
            if ($.isFunction(ext.details.tests))
                ext.details.tests = [];
        }
    });
}

function Singularity_GetSummary(funcName) {
    funcName = funcName || 'all';

    var out = Singularity_GetDocumentation(funcName, false, false);

    out += '\r\n';

    $.objectEach(sing.extensions, function (key, ext, i) {

        if (funcName &&
            funcName.lower() != '' &&
            funcName.lower() != 'all' &&
            !ext.name.lower().contains(funcName.lower()))
            return;

        out += '\r\n' + (ext.name + ' ').pad(30);

        out += ((ext.details.returnTypeName || '') + ' function(').pad(20, 'r');

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
}

function Singularity_GetDocumentation(funcName, includeCode, includeDocumentation) {

    if (includeDocumentation == undefined)
        includeDocumentation = true;

    Singularity_ResolveTests();

    var featuresCount = 0;
    var featuresFound = 0;

    var documentaionCount = 0;
    var documentaionFound = 0;

    var testsFound = 0;
    var testsPassed = 0;

    var header = 'Singularity JavaScript and jQuery language Extensions\r\n';
    var out = '';

    $.objectEach(sing.extensions, function (key, ext, i) {


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
            if (ext.details.tests && ext.details.tests.length > 0)
                documentaionFound++;
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
                ext.methodCall.pad(40) + (!ext.method ? ' -- NOT IMPLEMENTED' : functionDef).pad(40, 'r'),
                line,

                (ext.details.summary ? ('\r\n    Summary: \r\n' + ext.details.summary) : ''),

                (ext.details.parameters && ext.details.parameters.length == 0 ? '\r\n    Parameters: None\r\n' : ''),

                (ext.details.parameters && ext.details.parameters.length > 0 ? ('\r\n    Parameters:\r\n' + ext.details.parameters.collect(function (item, j) {
                    return (' #' + (j + 1)).pad(10) + 'Name:    ' + item.name + '\r\n' +
                           (item.optional == true ? '              :    OPTIONAL \r\n' : '') +
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

            if (ext.details.tests && ext.details.tests.length > 0) {
                out += '    Test Requirements: \r\n';

                var methodTestsFound = 0;
                var methodTestsPassed = 0;

                for (var i = 0; i < sing.extensions[ext.name].details.tests.length; i++) {

                    methodTestsFound++;
                    testsFound++;

                    var test = sing.extensions[ext.name].details.tests[i];

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
                        out += '----' + methodTestsPassed + ' / ' + methodTestsFound + ' (' + ((methodTestsPassed / methodTestsFound) * (10).pow(3)).round(1) + '%) Test Cases Passed\r\n\r\n';
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

    var totalFound = featuresFound + documentaionFound + testsPassed;
    var totalCount = featuresCount + documentaionCount + testsFound;

    var leftSpace = 40;

    header += '\r\n' +
    'Methods Implemented:      ' + (featuresFound + ' / ' + featuresCount).pad(leftSpace, 'r') + ' (' + Math.round((featuresFound / featuresCount) * 100) + '%)' + '\r\n' +
    'Documentation:            ' + (documentaionFound + ' / ' + documentaionCount).pad(leftSpace, 'r') + ' (' + Math.round((documentaionFound / documentaionCount) * 100) + '%)' + '\r\n' +
    'Test Cases Passed:        ' + (testsPassed + ' / ' + testsFound).pad(leftSpace, 'r') + ' (' + Math.round((testsPassed / testsFound) * 100) + '%)' + '\r\n' +
    '\r\n' +
    'Total:                    ' + (totalFound + ' / ' + totalCount).pad(leftSpace, 'r') + ' (' + Math.round((totalFound / totalCount) * 100) + '%)' + '\r\n';

    return header + out;
}

function Singularity_GetMissingElements(funcName) {
    Singularity_ResolveTests();

    var featuresCount = 0;
    var featuresFound = 0;

    var documentaionCount = 0;
    var documentaionFound = 0;

    var header = 'Singularity.JS JavaScript, jQuery, HTML, Extension Method Engine & Library\r\n';
    var out = '';

    $.objectEach(sing.extensions, function (key, ext, i) {

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

            if (ext.details.tests && ext.details.tests.length > 0)
                documentaionFound++;
            else
                out += ext.name + ' Tests \r\n';
        }
    });

    header += '\r\n' +
        'Methods Implemented:      ' + featuresFound + ' / ' + featuresCount + ' (' + Math.round((featuresFound / featuresCount) * 100) + '%) \r\n' +
        'Documentation:            ' + documentaionFound + ' / ' + documentaionCount + ' (' + Math.round((documentaionFound / documentaionCount) * 100) + '%) \r\n';

    return header + out;

}

function SingularityInit() {

    if (sing.apply && sing.call && sing.bind)
        sing = sing();

    $.noConflict();

    InitSingularityJS();
    InitSingularityJS_jQuery();

    tooltip.init();

    InitHTMLExtensions();

    InitFields();
}





function TryParseInt(str, defaultValue) {
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

function preg_quote(str) {

    return (str + '').replace(/([\\\.\+\*\?\[\^\]\$\(\)\{\}\=\!\<\>\|\:])/g, "\\$1");
}

var LOGGING_ENABLED = true;

function log(message) {
    if (LOGGING_ENABLED)
        console.log(message);
}

$().init(function () {
    SingularityInit();
});