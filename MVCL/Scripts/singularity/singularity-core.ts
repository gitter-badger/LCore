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

interface Hash<T> { [index: string]: T }

interface INamed {
    name: string;
}

interface IKeyValue<TKey, TValue> {
    key: TKey;
    value: TValue;
}

interface Object extends INamed {

}

class Direction {
    static left = 'left';
    static right = 'right';
    static center = 'center';
    static l = 'l';
    static r = 'r';
    static c = 'c';
}

interface ISingularity {
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

class Singularity implements ISingularity {

    Module = SingularityModule;
    Extension = SingularityExtension;
    AutoDefinition = SingularityAutoDefinition;

    enableTests: boolean = true;


    // Defaults to polyfill behavior, methods won't replace existing ones.
    // Set this to true or 'override: true' in the extension details to enable method overriding
    defaultPolyfill = true;

    modules: Hash<SingularityModule> = {

    };

    addModule = function (mod: SingularityModule) {

        if (this.modules[mod.name] === undefined)
            this.modules[mod.name] = mod;

        return mod;
    };

    extensions: Hash<SingularityExtension> = {

    };

    getExt = function (name: string, mod?: string) {

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

    addExt = function (moduleName: string, name: string, extendPrototype: any, method: Function, details: SingularityExtensionDetails, performAdd: boolean = true, prefix?: string) {

        var fullName = moduleName + '.' + (!!prefix ? prefix + '.' : '') + name;

        if (sing.extensions[fullName])
            throw moduleName + '.' + name + ' already exists.';

        var methods = [
            {
                name: name,
                target: extendPrototype,
                method: method
            }];

        // If there are aliases defined, they will all be added using the same method.
        if (details && details.aliases && details.aliases.length > 0) {
            for (var i = 0; i < details.aliases.length; i++) {
                methods.push(
                    {
                        name: details.aliases[i],
                        target: extendPrototype,
                        method: method
                    });
            }
        }

        for (var i = 0; i < methods.length; i++) {

            var ext = new SingularityExtension(details, extendPrototype, moduleName, methods[i].name, methods[i].method, prefix);

            if (!methods[i].target)
                throw 'could not find target ' + moduleName + ' ' + name;


            if (performAdd &&
                methods[i].target &&
                (sing.defaultPolyfill || details.override || !methods[i].target[methods[i].name]) &&
                ext.method) {

                // Defines an Array extension method without corrupting 'for-in'
                if (moduleName == 'Array' || methods[i].target === Array.prototype) {
                    if (!Array.prototype[name] && method) {
                        Object.defineProperty(Array.prototype, name, {
                            enumerable: false,
                            value: method,
                        });
                    }
                }
                else {
                    methods[i].target[methods[i].name] = ext.method;
                }
            }

            sing.extensions[moduleName + '.' + (!!prefix ? prefix + '.' : '') + methods[i].name] = ext;

            if (i > 0)
                sing.extensions[moduleName + '.' + (!!prefix ? prefix + '.' : '') + methods[i].name].isAlias = true;
        }

        return method;
    };

    init = function () {
        $.noConflict();

        for (var mod in this.modules) {
            if (this.modules[mod].init)
                this.modules[mod].init();
        }

        InitHTMLExtensions();

        InitFields();
    };

    // From ISingularityTests

    addTest: (name: string, testFunc: () => any, requirement?: string) => void;
    addCustomTest: (name: string, testFunc: () => any, requirement?: string) => void;
    addMethodTest: (ext: SingularityExtension, target?: any, args?: any[], compare?: any, requirement?: string) => void;
    addAssertTest: (name: string, result: any, compare: any, requirement?: string) => void;
    addFailsTest: (ext: SingularityExtension, target: any, args: any[], expectedError?: string, requirement?: string) => void;
    runTests: (display: boolean) => string;
    listTests: () => string;
    listMissingTests: () => string;
    
    // From ISingularityDocs

    getDocs: (funcName?: string, includeCode?: boolean, includeDocumentation?: boolean) => string;
    getSummary: (funcName?: string, includeFunctions?: boolean) => string;
    getMissing: (funcName?: string) => string;

    BBCodes: BBCode[];

    // From Singularity.Templates

    templatePattern: RegExp;
    templateStart: string;
    templateEnd: string;
}

class SingularityModule {

    uninitializedMethods: { extName: string; method?: Function; details?: SingularityExtensionDetails; extendPrototype: any; prefix: string }[] = [];

    addExt = function (extName: string, method?: Function, details?: SingularityExtensionDetails, extendPrototype: any = this.objectPrototype, prefix?: string) {

        this.uninitializedMethods.push({
            extName: extName,
            method: method,
            details: details,
            extendPrototype: extendPrototype,
            prefix: prefix,
        });
        //    sing.addExt(this.name, extName, extendPrototype, method, details);
    };

    getExtensions = function (extName?: string) {

        return $.objValues(sing.extensions).where(function (ext) {
            return ext.moduleName == this.name;
        });
    };

    requiredDocumentation: boolean = true;
    requiredUnitTests: boolean = true;

    init = function () {
        for (var i = 0; i < this.uninitializedMethods.length; i++) {
            var method = this.uninitializedMethods[i];
            sing.addExt(this.name, method.extName, method.extendPrototype, method.method, method.details, true, method.prefix);
        }
    };

    constructor(public name: string, public objectClass: any, public objectPrototype = objectClass.prototype) {

    }
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
    moduleName: string;
    target: string;
    targetType: INamed;
    methodCall: string;

    prefix: string;

    method: Function;

    data: Object;

    auto: SingularityAutoDefinition = new SingularityAutoDefinition();

    toString = function () {
        return this.name;
    };

    constructor(details: SingularityExtensionDetails = {},
        target?: any,
        moduleName?: string,
        name?: string,
        method?: Function,
        prefix?: string) {
        var ext = this;

        this.name = moduleName + '.' + (prefix ? prefix + '.' : '') + name;
        this.shortName = name;
        this.moduleName = moduleName;
        this.target = target;
        this.targetType = target;
        this.details = details;
        this.method = method;
        this.prefix = prefix;


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
                                throw ext.moduleName + '.' + ext.shortName + ' Missing Parameter: ' + typeNames + ' ' + param.name + '';
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
                                throw ext.moduleName + '.' + ext.shortName + '  Parameter: ' + param.name + ': ' + $.toStr(testArg, true) + ' ' +
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

        ext.methodCall = ext.moduleName + '.' + ext.name;

        // Configure type-specific defaults or use the global defaults
        var autoDefault = sing.autoDefault;

        if (sing.types[ext.moduleName] && sing.types[ext.moduleName].autoDefault)
            autoDefault = sing.types[ext.moduleName].autoDefault;

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
    }

    addTest = function (caller: any, args: any[], result?: any, requirement?: string) {
        sing.addMethodTest(this, caller, args, result, requirement);
    };

    addCustomTest = function (caller: any, testFunc: () => any, requirement?: string) {
        sing.addCustomTest(this.name, testFunc, requirement);
    };

    addFailsTest = function (caller: any, args: any[], expectedError?: string, requirement?: string) {
        sing.addFailsTest(this, caller, args, expectedError, requirement);
    };

}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

interface SingularityExtensionDetails {

    summary?: string;

    returns?: string;
    returnType?: INamed;
    returnTypeName?: string;

    examples?: string[];

    aliases?: string[];

    override?: boolean;

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

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

var sing = new Singularity();

var singModule = sing.addModule(new SingularityModule('Singularity', Singularity));

$().init(function () {
    sing.init();
});