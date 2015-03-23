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

    summary = 'TypeScript, JavaScript, and jQuery language Extensions';

    Module = SingularityModule;
    Extension = SingularityMethod;
    AutoDefinition = SingularityAutoDefinition;

    enableTests: boolean = true;

    // Defaults to polyfill behavior, methods won't replace existing ones.
    // Set this to true or 'override: true' in the extension details to enable method overriding
    defaultPolyfill = true;

    modules: Hash<SingularityModule> = {

    };

    addModule = function (mod: SingularityModule) {

        if (this.modules[mod.fullName()] === undefined)
            this.modules[mod.fullName()] = mod;

        return mod;
    };

    methods: Hash<SingularityMethod> = {

    };

    templates: Hash<string> = {

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

    autoDefault = new SingularityAutoDefinition();

    init = function () {
        $.noConflict();

        for (var mod in this.modules) {
            if (this.modules[mod].init)
                this.modules[mod].init();
        }

    };

    ready = function () {

        InitHTMLExtensions();

        InitFields();
    };

    getTypeName = function (protoType) {

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
    }

    globalResolve = {
        sing: sing,
        '$': $,
    };

    resolveKey = function (key: string, data?: any, context?: Object): any {

        var out = <any>undefined;

        try {
            key = key || '';

            key = key.trim();

            if (key == '$data') {
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

                var arrayContents = <any>match[1];
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
                    item = sing.resolveKey(item, data, context)

                var items = [item];

                items = items.concat(sing.resolveKey(theRest, data, context))

                return items;
            }

            // Strings
            if ((key.length > 1 && key[0] == '\'' && key[key.length - 1] == '\'') ||
                (key.length > 1 && key[0] == '"' && key[key.length - 1] == '"')) {

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
                return sing.globalResolve[keyPart]
            }

            // available context of any object
            if (out === undefined && keyPart.endsWith('$context')) {

                var itemContext = sing.resolveKey(keyPart.substr(0, keyPart.indexOf('$context')));

                var itemKeys = $.objKeys(data);

                return itemKeys.join(', ');
            }

            // OR operation
            if (keyPart == '||') {

                var theRest = <string>key.substr(2);

                var left = data;

                if ($.isEmpty(left) || left == false)
                    return sing.resolveKey(theRest, data, context);
                else
                    return left;
            }
        
            // AND operation
            if (keyPart == '&&') {

                var theRest = <string>key.substr(2);

                var left = data;

                if ($.isEmpty(left) || left == false) {
                    return false;
                }
                else {
                    var right = sing.resolveKey(theRest, data, context);

                    return true && !($.isEmpty(left) || left == false);
                }
            }

            // Number operations
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


            // Boolean Operators
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
                

            // Assignment
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

            //console.log('RESOLVE ' + key);

        }
        catch (ex) {
            error(ex);
        }
        if (out === undefined) {

            if (key.contains('||'))
                out = sing.resolveKey(key.after('||'), data, context);

            return '<error>could not resolve ' + key + '</error>';
        }

        return out;
    }

    loadContext = function (context: Object) {

        if (context === undefined) {

            context = {};

            context['sing'] = sing;

        }

        context['$context'] = function () { return $.objKeys(context); };
        context['$global'] = function () { return $.objKeys(sing.globalResolve); };

        return context;
    }

    loadTemplate: (url: string, callback: Function) => void;
    initTemplates: () => void;

    // From ISingularityTests

    addTest: (name: string, testFunc: () => any, requirement?: string) => void;
    addCustomTest: (name: string, testFunc: () => any, requirement?: string) => void;
    addMethodTest: (ext: SingularityMethod, target?: any, args?: any[], compare?: any, requirement?: string) => void;
    addAssertTest: (name: string, result: any, compare: any, requirement?: string) => void;
    addFailsTest: (ext: SingularityMethod, target: any, args: any[], expectedError?: string, requirement?: string) => void;
    runTests: (display: boolean) => string;
    listTests: () => string;
    listMissingTests: () => string;
    resolveTests: () => void;
    testErrors: string[];
    
    // From ISingularityDocs

    getDocs: (funcName?: string, includeCode?: boolean, includeDocumentation?: boolean) => string;
    getSummary: (funcName?: string, includeFunctions?: boolean) => string;
    getMissing: (funcName?: string) => string;

    BBCodes: BBCode[];

    // From Singularity.Templates

    templatePatternGlobal: RegExp;
    templatePattern: RegExp;
    templateStart: string;
    templateEnd: string;

    totalCodeLines = function () {

        var out = 0;

        $.objValues(sing.modules).each(function (mod) {
            if (!mod.parentModule)
                out += mod.totalCodeLines();
        });

        return out;
    };

}

class SingularityModule {

    parentModule: SingularityModule;

    subModules: SingularityModule[] = [];
    methods: SingularityMethod[] = [];

    addModule = function (mod: SingularityModule) {

        mod.parentModule = this;

        this.subModules.push(mod);

        return sing.addModule(mod);
    };

    totalMethods = function () {
        var out = (this.methods || []).count(function (m) {
            if (m.isAlias)
                return false;

            return true;
        });

        out += this.subModules.count(function (sub) {
            return sub.totalMethods();
        });

        return out;
    }

    implementedMethodCount = function () {

        var out = (this.methods || []).count(function (m) {
            if (m.isAlias)
                return false;

            return $.isDefined(m.method);
        });
        out += this.subModules.count(function (sub) {
            return sub.implementedMethodCount();
        });

        return out;
    };

    implementedMethodTests = function () {

        sing.resolveTests();

        var out = (this.methods || []).count(function (m) {
            if (m.isAlias)
                return false;
            if (m.details.unitTests)
                return (m.details.unitTests.length > 0);
            return false;
        });

        out += this.subModules.count(function (sub) {
            return sub.implementedMethodTests();
        });


        return out;
    };

    implementedDocumentation = function () {
        var out = 0;

        if (this.requiredDocumentation)
            (this.methods || []).each(function (m) {
                if (m.isAlias)
                    return;

                out += m.documentationPresent();
            });

        out += this.subModules.count(function (sub) {
            return sub.implementedDocumentation();
        });

        return out;
    };

    totalDocumentation = function () {
        var out = 0;

        if (this.requiredDocumentation)
            (this.methods || []).each(function (m) {
                if (m.isAlias)
                    return;

                out += m.documentationTotal();
            });

        out += this.subModules.count(function (sub) {
            return sub.totalDocumentation();
        });

        return out;
    };


    passedMethodTests = function () {

        sing.resolveTests();

        var out = (this.methods || []).count(function (m) {
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

        out += this.subModules.count(function (sub) {
            return sub.passedMethodTests();
        });

        return out;
    };

    implementedMethodTestsTotal = function () {

        sing.resolveTests();

        var out = (this.methods || []).count(function (m) {
            if (m.isAlias)
                return false;
            if (m.details.unitTests)
                return m.details.unitTests.length;
            return 0;
        });
        out += this.subModules.count(function (sub) {
            return sub.implementedMethodTestsTotal();
        });


        return out;
    };


    implementedItems = function () {
        return this.implementedMethodCount() +
            this.implementedMethodTests() +
            this.passedMethodTests() +
            this.implementedDocumentation();
    };

    totalItems = function () {
        return this.totalMethods() +
            this.implementedMethodCount() +
            this.implementedMethodTestsTotal() +
            this.totalDocumentation();
    };


    uninitializedMethods: { extName: string; method?: Function; details?: SingularityMethodDetails; extendPrototype: any; prefix: string }[] = [];

    method = function (extName: string, method?: Function, details?: SingularityMethodDetails, extendPrototype: any = this.objectPrototype, prefix?: string) {

        this.uninitializedMethods.push({
            extName: extName,
            method: method,
            details: details,
            extendPrototype: extendPrototype,
            prefix: prefix,
        });
        //    sing.method(this.name, extName, extendPrototype, method, details);
    };

    getMethods = function (extName?: string) {

        return $.objValues(sing.methods).where(function (ext) {
            return ext.moduleName == this.name;
        });
    };

    requiredDocumentation: boolean = true;
    requiredUnitTests: boolean = true;

    init = function () {
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
                }];

            // If there are aliases defined, they will all be added using the same method.
            if (details && details.aliases && details.aliases.length > 0) {
                for (var j = 0; j < details.aliases.length; j++) {
                    methods.push(
                        {
                            name: details.aliases[j],
                            target: extendPrototype,
                            method: method
                        });
                }
            }

            for (var j = 0; j < methods.length; j++) {

                var ext = new SingularityMethod(details, extendPrototype, fullName, methods[j].name, methods[j].method, prefix);

                if (!methods[j].target)
                    throw 'could not find target ' + fullName + ' ' + name;


                if (methods[j].target &&
                    (sing.defaultPolyfill || details.override || !methods[j].target[methods[j].name]) &&
                    ext.method) {

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

    fullName = function () {
        if (this.parentModule)
            return this.parentModule.fullName() + '.' + this.name;
        return this.name;
    }

    totalCodeLines = function () {

        var out = 0;
        var mod = <SingularityModule>this;

        mod.methods.each(function (ext) {
            out += ext.codeLines;
        });

        mod.subModules.each(function (subMod) {

            out += subMod.totalCodeLines();
        });

        return out;
    };

    constructor(public name: string, public objectClass: any, public objectPrototype = objectClass.prototype) {
        this.methods = this.methods || [];
        this.subModules = this.subModules || [];
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

class SingularityMethod {
    details: SingularityMethodDetails;

    isAlias: boolean = false;

    shortName: string;
    name: string;
    moduleName: string;
    target: string;
    targetType: INamed;
    methodCall: string;

    codeLines = 0;

    prefix: string;

    method: Function;
    methodOriginal: Function;

    data: Object;

    auto: SingularityAutoDefinition = new SingularityAutoDefinition();

    toString = function () {
        return this.name;
    };

    documentationPresent = function () {
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

    documentationTotal = function () {
        return 1 // summary
            + 1 // returns
            + 1 // return type
            + 1 // examples
            + 1; //parameters 
    };

    constructor(details: SingularityMethodDetails = {},
        target?: any,
        moduleName?: string,
        name?: string,
        method?: Function,
        prefix?: string) {
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

    private loadAutoIgnoreErrors = function (ext: SingularityMethod, methods: Function[]) {
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
    private loadAutoLogErrors = function (ext: SingularityMethod, methods: Function[]) {

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
    private loadAutoLogExecution = function (ext: SingularityMethod, methods: Function[]) {
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
    private loadAutoTimeExecution = function (ext: SingularityMethod, methods: Function[]) {

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
    private loadAutoDefaultResult = function (ext: SingularityMethod, methods: Function[]) {

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
    private loadAutoOverrideResult = function (ext: SingularityMethod, methods: Function[]) {

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
    private loadAutoCacheResults = function (ext: SingularityMethod, methods: Function[]) {

        if (this.auto.cacheResults) {

        }
    }
    private loadAutoResultAsArray = function (ext: SingularityMethod, methods: Function[]) {

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
    private loadAutoMakeAsync = function (ext: SingularityMethod, methods: Function[]) {


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
    private loadAutoRetry = function (ext: SingularityMethod, methods: Function[]) {

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
    private loadInputValidation = function (ext: SingularityMethod, methods: Function[]) {

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
                        var typeName = sing.getTypeName(param.types[j]).lower();
                        typeNames += typeName
                        typeNamesArray.push(typeName);
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

    private loadMethodCall = function (ext: SingularityMethod) {

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

    addCustomTest = function (testFunc: () => any, requirement?: string) {
        sing.addCustomTest(this.name, testFunc, requirement);
    };

    addFailsTest = function (caller: any, args: any[], expectedError?: string, requirement?: string) {
        sing.addFailsTest(this, caller, args, expectedError, requirement);
    };

}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

interface SingularityMethodDetails {

    summary?: string;

    returns?: string;
    returnType?: INamed;
    returnTypeName?: string;

    examples?: string[];

    aliases?: string[];

    override?: boolean;

    auto?: SingularityAutoDefinition;

    parameters?: SingularityParameter[];

    tests?: (ext: SingularityMethod) => void;
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

sing.globalResolve['sing'] = sing;

var singModule = sing.addModule(new SingularityModule('Singularity', Singularity));
var singCore = singModule.addModule(new SingularityModule('Core', Singularity));
var singExt = singModule.addModule(new SingularityModule('Extensions', Singularity));

$().init(function () {
    sing.init();
});
