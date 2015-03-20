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
var Singularity = (function () {
    function Singularity() {
        this.Module = SingularityModule;
        this.Extension = SingularityExtension;
        this.AutoDefinition = SingularityAutoDefinition;
        this.enableTests = true;
        // Defaults to polyfill behavior, methods won't replace existing ones.
        // Set this to true or 'override: true' in the extension details to enable method overriding
        this.defaultPolyfill = true;
        this.modules = {};
        this.addModule = function (mod) {
            if (this.modules[mod.name] === undefined)
                this.modules[mod.name] = mod;
            return mod;
        };
        this.extensions = {};
        this.getExt = function (name, mod) {
        };
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
        this.addExt = function (moduleName, name, extendPrototype, method, details, performAdd) {
            if (performAdd === void 0) { performAdd = true; }
            if (sing.extensions[moduleName + '.' + name])
                throw moduleName + '.' + name + ' already exists.';
            var methods = [
                {
                    name: name,
                    target: extendPrototype,
                    method: method
                }
            ];
            // If there are aliases defined, they will all be added using the same method.
            if (details && details.aliases && details.aliases.length > 0) {
                for (var i = 0; i < details.aliases.length; i++) {
                    methods.push({
                        name: details.aliases[i],
                        target: extendPrototype,
                        method: method
                    });
                }
            }
            for (var i = 0; i < methods.length; i++) {
                var ext = new SingularityExtension(details, extendPrototype, moduleName, methods[i].name, methods[i].method);
                if (!methods[i].target)
                    throw 'could not find target ' + moduleName + ' ' + name;
                if (performAdd && methods[i].target && (sing.defaultPolyfill || details.override || !methods[i].target[methods[i].name]) && ext.method) {
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
                sing.extensions[moduleName + '.' + methods[i].name] = ext;
                if (i > 0)
                    sing.extensions[moduleName + '.' + methods[i].name].isAlias = true;
            }
            return method;
        };
        this.init = function () {
            $.noConflict();
            for (var mod in this.modules) {
                if (this.modules[mod].init)
                    this.modules[mod].init();
            }
            InitHTMLExtensions();
            InitFields();
        };
    }
    return Singularity;
})();
var SingularityModule = (function () {
    function SingularityModule(name, objectClass, objectPrototype) {
        if (objectPrototype === void 0) { objectPrototype = objectClass.prototype; }
        this.name = name;
        this.objectClass = objectClass;
        this.objectPrototype = objectPrototype;
        this.uninitializedMethods = [];
        this.addExt = function (extName, method, details, extendPrototype) {
            if (extendPrototype === void 0) { extendPrototype = this.objectPrototype; }
            this.uninitializedMethods.push({
                extName: extName,
                method: method,
                details: details,
                extendPrototype: extendPrototype,
            });
            //    sing.addExt(this.name, extName, extendPrototype, method, details);
        };
        this.getExtensions = function (extName) {
            return $.objValues(sing.extensions).where(function (ext) {
                return ext.moduleName == this.name;
            });
        };
        this.requiredDocumentation = true;
        this.requiredUnitTests = true;
        this.init = function () {
            for (var i = 0; i < this.uninitializedMethods.length; i++) {
                var method = this.uninitializedMethods[i];
                sing.addExt(this.name, method.extName, method.extendPrototype, method.method, method.details);
            }
        };
    }
    return SingularityModule;
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
    function SingularityExtension(details, target, moduleName, name, method) {
        if (details === void 0) { details = {}; }
        this.isAlias = false;
        this.auto = new SingularityAutoDefinition();
        this.toString = function () {
            return this.name;
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
        this.name = moduleName + '.' + name;
        this.shortName = name;
        this.moduleName = moduleName;
        this.target = target;
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
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
var sing = new Singularity();
var singModule = sing.addModule(new SingularityModule('Singularity', Singularity));
$().init(function () {
    sing.init();
});
//# sourceMappingURL=singularity-core.js.map