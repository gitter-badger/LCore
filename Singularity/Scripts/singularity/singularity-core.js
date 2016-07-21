/// <reference path="../definitions/jquery.d.ts" />
/// <reference path="../definitions/jqueryui.d.ts" />
/// <reference path="../definitions/jquery.cookie.d.ts" />
var Singularity = (function () {
    function Singularity() {
        this.summary = 'TypeScript, JavaScript, jQuery, HTML Language Extensions';
        // ReSharper disable InconsistentNaming
        this.Module = SingularityModule;
        this.Extension = SingularityMethod;
        this.AutoDefinition = SingularityAutoDefinition;
        // ReSharper restore InconsistentNaming
        this.enableTests = true;
        // Defaults to polyfill behavior, methods won't replace existing ones.
        // Set this to true or 'override: true' in the extension details to enable method overriding
        this.defaultPolyfill = true;
        this.topLevelMethod = true;
        this.modules = {};
        this.methods = {};
        this.templates = {};
        this.constants = {
            IncludeURLs: {
                Style: 'http://sing.azurewebsites.net/Content/singularity.css',
                StyleMin: 'http://sing.azurewebsites.net/Content/singularity.min.css',
                Script: 'http://sing.azurewebsites.net/Scripts/singularity.js',
                ScriptMin: 'http://sing.azurewebsites.net/Scripts/singularity.min.js',
                templateCommon: 'http://sing.azurewebsites.net/Templates/Common.html',
                jsFiddleRoot: 'http://jsfiddle.net/sing/'
            },
            TemplatePatternStart: '{{',
            TemplatePatternEnd: '}}',
            TemplatePatternRegExpGlobal: /^.*{\{\{(.+)\}\}}+.*/g,
            TemplatePatternRegExp: /.*\{\{(.+)\}\}.*/,
            specialTokens: {
                Context: '$context',
                Data: '$data',
                Global: '$global',
                Key: '$key',
                I: '$i',
                It: '$it',
                Item: '$item',
                Index: '$index',
                IsLast: '$isFirst',
                IsFirst: '$isLast',
                Length: '$length'
            },
            htmlElement: {
                Error: 'error',
                Templates: {
                    Element: 'sing',
                    Try: 'sing-try',
                    Catch: 'sing-catch'
                }
            },
            htmlAttr: {
                GoToRememberPage: 'go-to-remember-page',
                EnableRememberPage: 'enable-remember-page',
                RememberPage: 'remember-page',
                ErrorSrc: 'error-src',
                HoverSrc: 'hover-src',
                FocusFirst: 'focus-first',
                // internal
                StaticSrc: 'static-src',
                Templates: {
                    Template: 'sing-template',
                    Content: 'sing-content',
                    Loop: 'sing-loop',
                    Fill: 'sing-fill',
                    If: 'sing-if',
                    ElseIf: 'sing-else-if',
                    Else: 'sing-else',
                    Data: 'sing-data',
                    ShortIf: 'if',
                    ShortElseIf: 'else-if',
                    ShortElse: 'else',
                    ShortFill: 'fill',
                    ShortLoop: 'loop',
                    ShortTemplate: 'template',
                    ShortContent: 'content',
                    ShortData: 'data',
                    // internal
                    Filled: 'sing-filled',
                    Deferred: 'sing-deferred',
                    TemplateName: 'sing-template-name',
                    TemplateData: 'sing-template-data',
                    LoopInner: 'sing-loop-inner',
                    DataType: 'sing-data-type',
                    DeferID: 'sing-defer-id'
                },
                Click: {
                    Animate: 'click-animate',
                    AnimateDuration: 'click-animate-duration',
                    AnimateEasing: 'click-animate-easing',
                    AnimateTarget: 'click-animate-target',
                    Show: 'click-show',
                    Hide: 'click-hide',
                    Toggle: 'click-toggle',
                    FadeIn: 'click-fade-in',
                    FadeOut: 'click-fade-out',
                    FadeToggle: 'click-fade-toggle',
                    AddClass: 'click-add-class',
                    AddClassTarget: 'click-add-class-target',
                    RemoveClass: 'click-remove-class',
                    RemoveClassTarget: 'click-remove-class-target',
                    ToggleClass: 'click-toggle-class',
                    ToggleClassTarget: 'click-toggle-class-target',
                    CtrlHref: 'ctrl-href',
                    ShiftHref: 'shift-href',
                    AltHref: 'alt-href',
                    DoubleHref: 'double-href',
                    KeyBindClick: 'key-bind-click',
                    KeyBindClickName: 'key-bind-click-name'
                }
            }
        };
        this.func = {
            empty: function () { },
            identity: function (obj) { return obj; },
            equals: function (obj, obj2) { return obj == obj2; },
            increment: function (i) { return i + 1; },
            booleanNot: function (obj) { return !obj; },
            toString: function (obj) { return obj.toString(); }
        };
        this.autoDefaults = new SingularityAutoDefinition();
        this.types = {
            Boolean: {
                typeClass: Boolean,
                protoType: Boolean.prototype,
                name: 'Boolean',
                autoDefault: this.autoDefaults,
                templateName: 'Boolean',
                typeOfName: 'boolean',
                glyphIcon: '&#xe063;'
            },
            Number: {
                typeClass: Number,
                protoType: Number.prototype,
                name: 'Number',
                autoDefault: this.autoDefaults,
                templateName: null,
                typeOfName: 'number',
                glyphIcon: 'icon-calculator'
            },
            String: {
                typeClass: String,
                protoType: String.prototype,
                name: 'String',
                autoDefault: this.autoDefaults,
                templateName: null,
                typeOfName: 'string',
                glyphIcon: '&#xe241;'
            },
            Array: {
                typeClass: Array,
                protoType: Array.prototype,
                name: 'Array',
                autoDefault: this.autoDefaults,
                templateName: 'List',
                glyphIcon: '&#xe236;'
            },
            Function: {
                typeClass: Function,
                protoType: Function.prototype,
                name: 'Function',
                autoDefault: this.autoDefaults,
                templateName: null,
                typeOfName: 'function',
                glyphIcon: '&#xe019;'
            },
            Date: {
                typeClass: Date,
                protoType: Date.prototype,
                name: 'Date',
                autoDefault: this.autoDefaults,
                templateName: null,
                typeOfName: 'date',
                glyphIcon: '&#xe109;'
            },
            $: {
                typeClass: $,
                protoType: $,
                name: 'jQuery',
                autoDefault: this.autoDefaults,
                glyphIcon: '&#xe148;'
            },
            Singularity: {
                typeClass: Singularity,
                protoType: Singularity.prototype,
                name: 'Singularity',
                autoDefault: this.autoDefaults,
                glyphIcon: '&#xe201;'
            },
            SingularityModule: {
                typeClass: SingularityModule,
                protoType: SingularityModule.prototype,
                name: 'SingularityModule',
                autoDefault: this.autoDefaults,
                glyphIcon: '&#xe201;'
            },
            SingularityMethod: {
                typeClass: SingularityMethod,
                protoType: SingularityMethod.prototype,
                name: 'SingularityMethod',
                autoDefault: this.autoDefaults,
                glyphIcon: '&#xe019;'
            },
            Object: {
                typeClass: Object,
                protoType: Object.prototype,
                name: 'Object',
                autoDefault: this.autoDefaults,
                // templateName: 'ObjectTable',
                typeOfName: 'object',
                glyphIcon: '&#xe165;'
            }
        };
        this.defaultSettings = {
            requiredDocumentation: true,
            requiredGlyphIcons: true,
            requiredUnitTests: true,
            requiredJSFiddle: false
        };
        this.getType = function (protoType) {
            for (var t in sing.types) {
                if (sing.types.hasOwnProperty(t)) {
                    if (sing.types[t].name == protoType ||
                        sing.types[t].protoType == protoType ||
                        sing.types[t].typeClass == protoType)
                        return sing.types[t];
                }
            }
            return null;
        };
        this.globalResolve = {
            sing: sing,
            '$': $
        };
        this.templateShownFunctions = [];
    }
    Singularity.prototype.addModule = function (mod) {
        if (mod.requiredDocumentation == null)
            mod.requiredDocumentation = this.defaultSettings.requiredDocumentation;
        if (mod.requiredGlyphIcons == null)
            mod.requiredGlyphIcons = this.defaultSettings.requiredGlyphIcons;
        if (mod.requiredJSFiddle == null)
            mod.requiredJSFiddle = this.defaultSettings.requiredJSFiddle;
        if (mod.requiredUnitTests == null)
            mod.requiredUnitTests = this.defaultSettings.requiredUnitTests;
        mod.glyphIcon = mod.glyphIcon || '';
        if (this.modules[mod.fullName()] === undefined)
            this.modules[mod.fullName()] = mod;
        return mod;
    };
    Singularity.prototype.addType = function (name, addType) {
        this.types[name] = addType;
    };
    Singularity.prototype.init = function () {
        var temp = $;
        $.noConflict();
        if ($ == null) {
            $ = temp;
        }
        for (var mod in this.modules) {
            if (this.modules.hasOwnProperty(mod)) {
                if (this.modules[mod].init)
                    this.modules[mod].init();
            }
        }
        String.prototype['match'] = String.prototype['match'].fnCache('regexMatch');
    };
    Singularity.prototype.ready = function () {
        initHTMLExtensions();
        initFields();
    };
    Singularity.prototype.getTypeName = function (protoType) {
        if ($.isArray(protoType) && protoType.length > 0) {
            return protoType.collect(sing.getTypeName).join(', ');
        }
        else {
            for (var t in sing.types) {
                if (sing.types.hasOwnProperty(t)) {
                    if (sing.types[t].protoType == protoType ||
                        sing.types[t].typeClass == protoType ||
                        sing.types[t].protoType == protoType.protoType ||
                        sing.types[t].typeClass == protoType.protoType)
                        return sing.types[t].name;
                }
            }
            return 'Object'; // this.types.Object.name;
        }
    };
    Singularity.prototype.getTemplateName = function (protoType) {
        if (protoType.prototype)
            protoType = protoType.prototype;
        for (var t in sing.types) {
            if (sing.types.hasOwnProperty(t)) {
                if ((typeof protoType) == sing.types[t].typeOfName ||
                    sing.types[t].protoType === protoType ||
                    protoType instanceof sing.types[t].typeClass ||
                    sing.types[t].typeClass === protoType) {
                    if (sing.types[t].templateName === null)
                        return null;
                    return sing.types[t].templateName || sing.types[t].name;
                }
            }
        }
        throw "could not find " + protoType;
    };
    Singularity.prototype.templateShown = function (fn) {
        sing.templateShownFunctions.push(fn);
    };
    return Singularity;
}());
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
var SingularityModule = (function () {
    function SingularityModule(name, objectClass, objectPrototype) {
        this.name = name;
        this.objectClass = objectClass;
        this.objectPrototype = objectPrototype;
        this.version = null;
        this.features = [];
        this.resources = {};
        this.subModules = [];
        this.methods = [];
        this.properties = [];
        this.ignoreUnknownMembers = [];
        this.jsFiddleLinks = {};
        this.rootModule = function () {
            var thisModule = this;
            if (thisModule.parentModule)
                return thisModule.parentModule.rootModule();
            else
                return thisModule;
        };
        this.uninitializedMethods = [];
        if ($.isArray(this.objectClass) && this.objectClass.length > 0) {
            this.trackObjects = this.objectClass;
            this.objectClass = this.objectClass[0];
        }
        this.objectPrototype = this.objectPrototype || (this.objectClass ? this.objectClass.prototype : null);
        this.trackObjects = this.trackObjects || [this.objectPrototype];
        this.methods = this.methods || [];
        this.subModules = this.subModules || [];
    }
    SingularityModule.prototype.addModule = function (mod) {
        mod.parentModule = this;
        if (mod.requiredDocumentation == null) {
            mod.requiredDocumentation = this.requiredDocumentation;
        }
        if (mod.requiredGlyphIcons == null) {
            mod.requiredGlyphIcons = this.requiredGlyphIcons;
        }
        if (mod.requiredJSFiddle == null) {
            mod.requiredJSFiddle = this.requiredJSFiddle;
        }
        if (mod.requiredUnitTests == null) {
            mod.requiredUnitTests = this.requiredUnitTests;
        }
        this.subModules.push(mod);
        return sing.addModule(mod);
    };
    SingularityModule.prototype.totalMethods = function () {
        var thisModule = this;
        var out = (thisModule.methods || []).count(function (m) {
            if (m.isAlias)
                return false;
            return true;
        });
        out += thisModule.getUnknownMethods().length;
        out += thisModule.subModules.count(function (sub) { return sub.totalMethods(); });
        return out;
    };
    SingularityModule.prototype.implementedMethodCount = function () {
        var thisModule = this;
        var out = (thisModule.methods || []).count(function (m) {
            if (m.isAlias)
                return false;
            return $.isDefined(m.method);
        });
        out += thisModule.subModules.count(function (sub) { return sub.implementedMethodCount(); });
        return out;
    };
    SingularityModule.prototype.implementedMethodTests = function () {
        var thisModule = this;
        sing.tests.resolveTests();
        var out = (thisModule.methods || []).count(function (m) {
            if (m.isAlias)
                return false;
            if (m.details.manuallyTested !== undefined) {
                return m.details.manuallyTestedVersion === undefined ||
                    m.details.manuallyTestedVersion == m.methodModule.rootModule().version;
            }
            if (m.details.unitTests)
                return (m.details.unitTests.length > 0);
            return false;
        });
        out += thisModule.subModules.count(function (sub) { return sub.implementedMethodTests(); });
        return out;
    };
    SingularityModule.prototype.implementedDocumentation = function () {
        var thisModule = this;
        var out = 0;
        if (thisModule.requiredDocumentation) {
            (thisModule.methods || []).each(function (m) {
                if (m.isAlias)
                    return;
                out += m.documentationPresent();
            });
            if (!$.isEmpty(thisModule.summaryShort))
                out++;
            if (!$.isEmpty(thisModule.summaryLong))
                out++;
            out += thisModule.properties.count(function (prop) { return (!$.isEmpty(prop.description)); });
            out += thisModule.subModules.count(function (sub) { return sub.implementedDocumentation(); });
        }
        if (thisModule.requiredGlyphIcons) {
            if (!$.isEmpty(thisModule.glyphIcon))
                out++;
        }
        return out;
    };
    SingularityModule.prototype.implementedProperties = function () {
        var thisModule = this;
        var out = 0;
        out += thisModule.subModules.count(function (sub) { return sub.implementedProperties(); });
        out += thisModule.properties.length;
        return out;
    };
    SingularityModule.prototype.totalProperties = function () {
        var thisModule = this;
        var out = 0;
        out += thisModule.subModules.count(function (sub) { return sub.totalProperties(); });
        out += thisModule.properties.length;
        out += thisModule.getUnknownProperties().length;
        return out;
    };
    SingularityModule.prototype.totalDocumentation = function () {
        var thisModule = this;
        var out = 0;
        if (thisModule.requiredDocumentation) {
            (thisModule.methods || []).each(function (m) {
                if (m.isAlias)
                    return;
                out += m.documentationTotal();
            });
            out += 1; // Module shortSummary
            out += 1; // Module longSummary
            out += thisModule.properties.length;
            out += thisModule.getUnknownProperties().length;
            out += thisModule.subModules.count(function (sub) { return sub.totalDocumentation(); });
        }
        if (thisModule.requiredGlyphIcons) {
            out += 1; // Module glyphicon
        }
        return out;
    };
    SingularityModule.prototype.passedMethodTests = function () {
        var thisModule = this;
        sing.tests.resolveTests();
        var out = (thisModule.methods || []).count(function (m) {
            if (m.isAlias)
                return false;
            if (m.details.manuallyTested !== undefined) {
                return m.details.manuallyTestedVersion === undefined ||
                    m.details.manuallyTestedVersion == m.methodModule.rootModule().version;
            }
            if (m.details.unitTests)
                return m.details.unitTests.count(function (test) {
                    if (test.testResult === undefined)
                        test.testFunc();
                    return test.testResult == true || !$.isDefined(test.testResult);
                });
            return 0;
        });
        out += thisModule.subModules.count(function (sub) { return sub.passedMethodTests(); });
        return out;
    };
    SingularityModule.prototype.implementedMethodTestsTotal = function () {
        var thisModule = this;
        sing.tests.resolveTests();
        var out = (thisModule.methods || []).count(function (m) {
            if (m.isAlias)
                return false;
            if (m.details.manuallyTested !== undefined) {
                return m.details.manuallyTestedVersion === undefined ||
                    m.details.manuallyTestedVersion == m.methodModule.rootModule().version;
            }
            if (m.details.unitTests)
                return m.details.unitTests.length;
            return 0;
        });
        out += thisModule.subModules.count(function (sub) { return sub.implementedMethodTestsTotal(); });
        return out;
    };
    SingularityModule.prototype.implementedJSFiddle = function () {
        var thisModule = this;
        var out = 0;
        if (thisModule.requiredJSFiddle) {
            out += thisModule.methods.count(function (m) { return (m.details && !$.isEmpty(m.details.jsFiddleLinks)); });
            out += thisModule.subModules.count(function (sub) { return sub.implementedJSFiddle(); });
        }
        return out;
    };
    SingularityModule.prototype.totalJSFiddle = function () {
        var thisModule = this;
        var out = 0;
        if (thisModule.requiredJSFiddle) {
            out += thisModule.methods.length;
            out += thisModule.subModules.count(function (sub) { return sub.totalJSFiddle(); });
        }
        return out;
    };
    SingularityModule.prototype.implementedItems = function () {
        return this.implementedMethodCount() +
            this.implementedMethodTests() +
            this.implementedProperties() +
            this.passedMethodTests() +
            this.implementedJSFiddle() +
            this.implementedDocumentation();
    };
    SingularityModule.prototype.totalItems = function () {
        return this.totalMethods() +
            this.implementedMethodCount() +
            this.totalProperties() +
            this.implementedMethodTestsTotal() +
            this.totalJSFiddle() +
            this.totalDocumentation();
    };
    SingularityModule.prototype.method = function (extName, method, details, extendPrototype, prefix) {
        if (extendPrototype === void 0) { extendPrototype = this.objectPrototype; }
        this.uninitializedMethods.push({
            extName: extName,
            method: method,
            details: details,
            extendPrototype: extendPrototype,
            prefix: prefix
        });
        //    sing.method(this.name, extName, extendPrototype, method, details);
    };
    SingularityModule.prototype.property = function (name, param) {
        if (param === void 0) { param = {}; }
        var thisModule = this;
        param.name = name;
        thisModule.properties.push(param);
    };
    SingularityModule.prototype.ignoreUnknown = function () {
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
    SingularityModule.prototype.init = function () {
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
                warn(fullName + "." + name + " already exists.");
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
                    methods.push({
                        name: details.aliases[j],
                        target: extendPrototype,
                        method: method
                    });
                }
            }
            for (var k = 0; k < methods.length; k++) {
                var ext = new SingularityMethod(thisModule, details, extendPrototype, fullName, methods[k].name, methods[k].method, prefix);
                if (!methods[k].target)
                    throw "could not find target " + fullName + " " + name;
                if (methods[k].target &&
                    (sing.defaultPolyfill || details.override || !methods[k].target[methods[k].name]) &&
                    ext.method) {
                    // Defines an Array extension method without corrupting 'for-in'
                    if (methods[k].target === Array.prototype) {
                        if (!Array.prototype[name] && method) {
                            Object.defineProperty(Array.prototype, methods[k].name, {
                                enumerable: false,
                                value: method
                            });
                        }
                    }
                    else {
                        methods[k].target[methods[k].name] = ext.method;
                    }
                }
                sing.methods[(fullName + "." + (!!prefix ? prefix + "." : '') + methods[k].name)] = ext;
                if (k > 0)
                    sing.methods[(fullName + "." + (!!prefix ? prefix + "." : '') + methods[k].name)].isAlias = true;
                this.methods.push(ext);
            }
        }
    };
    SingularityModule.prototype.fullName = function () {
        if (this.parentModule)
            return this.parentModule.fullName() + "." + this.name;
        return this.name;
    };
    return SingularityModule;
}());
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
var SingularityMethod = (function () {
    function SingularityMethod(methodModule, details, target, moduleName, name, method, prefix) {
        if (details === void 0) { details = {}; }
        this.isAlias = false;
        this.codeLines = 0;
        this.data = {};
        this.auto = new SingularityAutoDefinition();
        this.name = moduleName + "." + (prefix ? prefix + "." : '') + name;
        this.shortName = name;
        if (method)
            this.codeLines = method.toString().split('\r\n').length;
        this.moduleName = moduleName;
        if (target !== undefined) {
            this.target = sing.getTypeName(target);
            this.targetType = target;
        }
        this.details = details;
        this.method = method;
        this.methodModule = methodModule;
        this.methodOriginal = method;
        this.prefix = prefix;
        this.details.glyphIcon = this.details.glyphIcon || '';
        if (this.details.returnType && !this.details.returnType.name) {
            this.details.returnTypeName = sing.getTypeName(this.details.returnType);
        }
        if (details.returnType)
            this.details.returnTypeName = this.details.returnType.name;
        else
            this.details.returnTypeName = 'void';
        this.loadMethodCall(this);
        if (this.method) {
            var methods = [this.method];
            // Validates input fields based on parameter options set in the details
            // Checks that non-optional fields are included and that the inputs passed match one of the parameter types given
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
    }
    SingularityMethod.prototype.toString = function () {
        return this.name;
    };
    SingularityMethod.prototype.passedTests = function () {
        var thisMethod = this;
        if (thisMethod.details && thisMethod.details.manuallyTested !== undefined && (thisMethod.details.manuallyTestedVersion === undefined ||
            thisMethod.details.manuallyTestedVersion == thisMethod.methodModule.rootModule().version)) {
            return 1;
        }
        if (thisMethod.details && thisMethod.details.unitTests) {
            return thisMethod.details.unitTests.count(function (a) { return (a.testResult == true); });
        }
        return 0;
    };
    SingularityMethod.prototype.passesAllTests = function () {
        var thisMethod = this;
        if (thisMethod.details && thisMethod.details.manuallyTested)
            return true;
        if (thisMethod.details && thisMethod.details.unitTests) {
            return thisMethod.details.unitTests.every(function (a) { return (a.testResult == true); });
        }
        return false;
    };
    SingularityMethod.prototype.documentationComplete = function () {
        return this.documentationPresent() == this.documentationTotal();
    };
    SingularityMethod.prototype.documentationPresent = function () {
        var thisMethod = this;
        var out = 0;
        if (!$.isEmpty(thisMethod.details.summary))
            out++;
        if (!$.isEmpty(thisMethod.details.returns))
            out++;
        if (!$.isEmpty(thisMethod.details.returnTypeName))
            out++;
        if (thisMethod.methodModule.requiredGlyphIcons) {
            if (!$.isEmpty(thisMethod.details.glyphIcon))
                out++;
        }
        if (!$.isEmpty(thisMethod.details.examples) || !$.isEmpty(thisMethod.details.unitTests))
            out++;
        if (thisMethod.details.parameters != undefined && thisMethod.details.parameters != null)
            out++;
        return out;
    };
    SingularityMethod.prototype.documentationTotal = function () {
        var thisMethod = this;
        var out = 1 // summary
            + 1 // returns
            + 1 // return type
            + 1 // examples
            + 1; // parameters 
        if (thisMethod.methodModule.requiredGlyphIcons)
            out++; // glyphicon
        return out;
    };
    SingularityMethod.prototype.loadAutoIgnoreErrors = function (ext, methods) {
        if (ext.auto.ignoreErrors) {
            var lastMethodIgnoreErrors = methods[methods.length - 1];
            methods.push(function () {
                ////////////////////////////////////////////////////////////
                // NO Extensions are allowed within this method
                ////////////////////////////////////////////////////////////
                try {
                    return lastMethodIgnoreErrors.apply(this, arguments);
                }
                catch (ex) {
                }
            });
        }
    };
    SingularityMethod.prototype.loadAutoLogErrors = function (ext, methods) {
        if (ext.auto.logErrors) {
            var lastMethodLogErrors = methods[methods.length - 1];
            methods.push(function () {
                ////////////////////////////////////////////////////////////
                // NO Extensions are allowed within this method
                ////////////////////////////////////////////////////////////
                try {
                    return lastMethodLogErrors.apply(this, arguments);
                }
                catch (ex) {
                    log(ext.name + " Error: " + ex);
                }
            });
        }
    };
    SingularityMethod.prototype.loadAutoLogExecution = function (ext, methods) {
        if (ext.auto.logExecution) {
            var lastMethodLogExecution = methods[methods.length - 1];
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
                argStr = "[" + argStr + "]";
                log("Running:   " + ext.name + "    Arguments: " + argStr);
                var result = lastMethodLogExecution.apply(this, arguments);
                log("Completed: " + ext.name + "    Result:    " + result);
                return result;
            });
        }
    };
    SingularityMethod.prototype.loadAutoTimeExecution = function (ext, methods) {
        if (ext.auto.timeExecution) {
            var lastMethodTimeExecution = methods[methods.length - 1];
            methods.push(function () {
                ////////////////////////////////////////////////////////////
                // NO Extensions are allowed within this method
                ////////////////////////////////////////////////////////////
                var timeBefore = new Date().valueOf();
                sing.totalExecutions = sing.totalExecutions || 0;
                sing.totalExecutionTime = sing.totalExecutionTime || 0;
                sing.totalExecutions = sing.totalExecutions + 1;
                var subExecutions = sing.totalExecutions;
                var executionTimeBefore = sing.totalExecutionTime;
                var result = lastMethodTimeExecution.apply(this, arguments);
                var executionTimeAfter = sing.totalExecutionTime;
                var subExecutionTime = executionTimeAfter - executionTimeBefore;
                subExecutions -= sing.totalExecutions;
                var timeAfter = new Date().valueOf();
                var time = timeAfter - timeBefore - subExecutionTime;
                if (time < 0)
                    time = 0;
                sing.totalExecutionTime += time;
                ext.data['executions'] = ext.data['executions'] || [];
                ext.data['executionTotal'] = ext.data['executionTotal'] || 0;
                ext.data['executions'].push({
                    duration: time,
                    // args: ObjectToStr(arguments),
                    // result: ObjectToStr(result),
                    subMethods: subExecutions
                });
                ext.data['executionTotal'] = ext.data['executionTotal'] + time;
                return result;
            });
        }
    };
    SingularityMethod.prototype.loadAutoDefaultResult = function (ext, methods) {
        if (ext.auto.defaultResult !== undefined) {
            var lastMethodDefaultResult = methods[methods.length - 1];
            methods.push(function () {
                ////////////////////////////////////////////////////////////
                // NO Extensions are allowed within this method
                ////////////////////////////////////////////////////////////
                var result = lastMethodDefaultResult.apply(this, arguments);
                if (result === undefined || result === null) {
                    result = ext.auto.defaultResult;
                }
                return result;
            });
        }
    };
    SingularityMethod.prototype.loadAutoOverrideResult = function (ext, methods) {
        if (ext.auto.overrideResult !== undefined) {
            var lastMethodOverrideResult = methods[methods.length - 1];
            methods.push(function () {
                ////////////////////////////////////////////////////////////
                // NO Extensions are allowed within this method
                ////////////////////////////////////////////////////////////
                lastMethodOverrideResult.apply(this, arguments);
                return ext.auto.overrideResult;
            });
        }
    };
    SingularityMethod.prototype.loadAutoCacheResults = function (ext, methods) {
        if (this.auto.cacheResults) {
        }
    };
    SingularityMethod.prototype.loadAutoResultAsArray = function (ext, methods) {
        if (ext.auto.resultAsArray) {
            var lastMethodResultAsArray = methods[methods.length - 1];
            methods.push(function () {
                ////////////////////////////////////////////////////////////
                // NO Extensions are allowed within this method
                ////////////////////////////////////////////////////////////
                var result = lastMethodResultAsArray.apply(this, arguments);
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
    SingularityMethod.prototype.loadAutoMakeAsync = function (ext, methods) {
        if (this.auto.makeAsync) {
            this.details.parameters.push({
                name: 'callback',
                //    method: [Function],
                description: "This callback function will be executed when " + ext.shortName + " has finished executing. It will be passed the result as its only argument"
            });
            var callbackIndex = ext.details.parameters.length - 1;
            var lastMethodMakeAsync = methods[methods.length - 1];
            methods.push(function () {
                ////////////////////////////////////////////////////////////
                // NO Extensions are allowed within this method
                ////////////////////////////////////////////////////////////
                var _this = this;
                var args = arguments;
                setTimeout(function () {
                    var result = lastMethodMakeAsync.apply(_this, args);
                    if (args[callbackIndex]) {
                        args[callbackIndex](result);
                    }
                }, 1);
            });
        }
    };
    SingularityMethod.prototype.loadAutoRetry = function (ext, methods) {
        if (this.auto.retryTimes > 0) {
            var lastMethodRetryTimes = methods[methods.length - 1];
            methods.push(function () {
                ////////////////////////////////////////////////////////////
                // NO Extensions are allowed within this method
                ////////////////////////////////////////////////////////////
                for (var attempt = 0; attempt < ext.auto.retryTimes + 1; attempt++) {
                    try {
                        return lastMethodRetryTimes.apply(this, arguments);
                    }
                    catch (ex) {
                        if (attempt == ext.auto.retryTimes - 1)
                            throw "Failed after " + (ext.auto.retryTimes + 1) + " tries. " + ex;
                    }
                }
            });
        }
    };
    SingularityMethod.prototype.loadInputValidation = function (ext, methods) {
        if (ext.method &&
            ext.details.parameters &&
            ext.details.parameters.length > 0 &&
            (ext.auto.validateInput || ext.auto.injectDefaultInputValue)) {
            var srcext = ext;
            var lastMethodValidateInput = methods[methods.length - 1];
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
                    if (param.types) {
                        for (var k = 0; k < param.types.length; k++) {
                            var typeName = sing.getTypeName(param.types[k]).lower();
                            typeNames += typeName;
                            typeNamesArray.push(typeName);
                            if (k < param.types.length - 1)
                                typeNames += ', ';
                        }
                    }
                    if (param.required) {
                        if (testArg === null ||
                            testArg === undefined) {
                            // If a defaultValue is defined, substitute it and continue
                            if (param.defaultValue != null &&
                                param.defaultValue != undefined &&
                                ext.auto.injectDefaultInputValue) {
                                args[i] = testArg = param.defaultValue;
                            }
                            else if (ext.auto.validateInput)
                                throw ext.moduleName + "." + ext.shortName + " Missing Parameter: " + typeNames + " " + param.name;
                        }
                    }
                    else if (testArg === null || testArg === undefined) {
                    }
                    if (!param.types ||
                        param.types.length == 0 ||
                        param.types.indexOf(Object) >= 0) {
                    }
                    else if (ext.auto.validateInput) {
                        if ((typeof testArg).lower() == 'object' &&
                            typeNamesArray.has('array') &&
                            testArg != null &&
                            testArg.length != null &&
                            testArg.concat != null) {
                        }
                        else if (!typeNamesArray.has(typeof testArg)) {
                            if (param.required) {
                                throw ext.moduleName + "." + ext.shortName + "  Parameter: " + param.name + ": " + $.toStr(testArg, true) + " " + (typeof testArg).lower() + " did not match input type " + $.toStr(typeNamesArray, true) + ".";
                            }
                        }
                    }
                }
                return lastMethodValidateInput.apply(this, arguments);
            });
        }
    };
    SingularityMethod.prototype.loadMethodCall = function (ext) {
        ext.methodCall = ext.moduleName + "." + ext.shortName;
        // Configure type-specific defaults or use the global defaults
        var autoDefaults = sing.autoDefaults;
        if (sing.types[ext.moduleName] && sing.types[ext.moduleName].autoDefault !== undefined)
            autoDefaults = $.extend(true, {}, sing.types[ext.moduleName].autoDefault);
        ext.auto = new SingularityAutoDefinition(autoDefaults);
        // Inherits auto values passed using details
        if (ext && ext.details && ext.details.auto) {
            for (var arg in ext.details.auto) {
                if (ext.details.auto.hasOwnProperty(arg)) {
                    this.auto[arg] = this.details.auto[arg];
                }
            }
            this.details.auto = undefined;
        }
        ext.methodCall += '(';
        if (ext.details && ext.details.parameters) {
            for (var j = 0; j < ext.details.parameters.length; j++) {
                // TODO: TS: FIX
                // ext.methodCall += `[${$.toStr(ext.details.parameters[j].types)}] `;
                ext.methodCall += ext.details.parameters[j].name;
                if (j < ext.details.parameters.length - 1)
                    ext.methodCall += ', ';
            }
        }
        ext.methodCall += ');';
    };
    SingularityMethod.prototype.isTested = function () {
        var thisMethod = this;
        if (thisMethod.details && thisMethod.details.unitTests && thisMethod.details.unitTests.length > 0)
            return true;
        if (thisMethod.details && thisMethod.details.manuallyTested)
            return true;
    };
    return SingularityMethod;
}());
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
}());
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
var sing = new Singularity();
// sing.autoDefaults.timeExecution = true;
sing.globalResolve['sing'] = sing;
var singRoot = sing.addModule(new SingularityModule('Singularity', [Singularity, sing]));
singRoot.glyphIcon = '&#xe201;';
singRoot.summaryShort = 'Let your code sing.';
singRoot.summaryLong = 'Singularity is a TypeScript (and JavaScript) library of extension methods and more. \r\n\r\n';
singRoot.features = [
    'Language Extensions (Enumerable, String, Number, Boolean, Function)',
    'Code documentation & Unit Testing engine',
    'Templating Engine'];
singRoot.resources = {
    'http://www.typescriptlang.org/': 'TypeScript'
};
singRoot.jsFiddleLinks = {
    'Singularity Example': 'e7b7sxze'
};
// singRoot.requiredJSFiddle = true;
singRoot.method('addModule', sing.addModule, {
    manuallyTested: true
});
singRoot.method('totalCodeLines', singularityTotalCodeLines);
function singularityTotalCodeLines() {
    var out = 0;
    $.objValues(sing.modules).each(function (mod) {
        if (!mod.parentModule)
            out += mod.totalCodeLines();
    });
    return out;
}
singRoot.method('loadContext', singularityLoadContext);
function singularityLoadContext(context) {
    if (context === undefined) {
        context = {};
        context['sing'] = sing;
    }
    context[sing.constants.specialTokens.Context] = function () { return $.objKeys(context); };
    context[sing.constants.specialTokens.Global] = function () { return $.objKeys(sing.globalResolve); };
    return context;
}
singRoot.method('resolve', singularityResolve);
function singularityResolve(key, data, context, rootKey) {
    if (context === void 0) { context = {}; }
    if (!rootKey)
        rootKey = key.trim();
    log([rootKey, key]);
    var out = undefined;
    try {
        key = key || '';
        key = key.trim();
        if (context[sing.constants.specialTokens.Data] === undefined)
            context[sing.constants.specialTokens.Data] = data;
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
        var negateOutput = false;
        if (key.length > 2 && key[0] == '!' && key[1] != '!') {
            negateOutput = true;
            key = key.substr(1);
        }
        // Numbers
        if (key.isNumeric())
            return key.toNumber();
        // Booleans
        if (key.isBoolean())
            return key.toBoolean();
        var firstPart;
        var theRest;
        var resolved;
        var result;
        var left;
        var right;
        var matches;
        var methodName;
        var arrayIndex;
        var property;
        // #region Assignment notation
        if (key.hasMatch(/^([^ ><]+)[\s]?(=|\+=|\-=|\*=|\/=|\+\+|--|%\/)([^><]+)?$/)) {
            matches = key.match(/^([^ ><]+)[\s]?(=|\+=|\-=|\*=|\/=|\+\+|--|%\/)([^><]+)?$/);
            var assign = matches[1].trim();
            var operator;
            operator = matches[2], theRest = matches[3];
            var setObj = null;
            if (assign.endsWith(']')) {
                firstPart = assign.substr(0, assign.lastIndexOf('['));
                arrayIndex = assign.substr(assign.lastIndexOf('[') + 1);
                setObj = sing.resolve(firstPart, data, context, rootKey);
                assign = sing.resolve(arrayIndex, data, context, rootKey);
            }
            else if (assign.contains('.')) {
                firstPart = assign.substr(0, assign.lastIndexOf('.'));
                var lastPart = assign.substr(assign.lastIndexOf('.') + 1);
                setObj = sing.resolve(firstPart, data, context, rootKey);
                assign = lastPart;
            }
            else {
                if (sing.globalResolve[assign] !== undefined) {
                    setObj = sing.globalResolve;
                }
                else {
                    setObj = context;
                }
            }
            var value = sing.resolve(theRest, data, context, rootKey);
            if (operator == '=')
                setObj[assign] = value;
            else if (operator == '+=')
                setObj[assign] += value;
            else if (operator == '-=')
                setObj[assign] -= value;
            else if (operator == '*=')
                setObj[assign] *= value;
            else if (operator == '/=')
                setObj[assign] /= value;
            else if (operator == '%=')
                setObj[assign] %= value;
            else if (operator == '++')
                setObj[assign]++;
            else if (operator == '--')
                setObj[assign]--;
            else
                throw "unknown operator " + operator;
            return '';
        }
        // #endregion
        // #region function notation, no arguments
        if (key.hasMatch(/^\.?([^\.\'\",\[\]\(\)]+)\(\)\.?(.*)/)) {
            matches = key.match(/^\.?([^\.\'\",\[\]\(\)]+)\(\)\.?(.*)/);
            methodName = matches[1];
            theRest = matches[2];
            out = sing.resolve(methodName, data, context, rootKey);
            if (out == null || !out.apply) {
                throw "could not resolve " + rootKey;
            }
            result = out.apply(data, []);
            if (theRest == null || theRest == '')
                return result;
            if (negateOutput)
                result = !result;
            return sing.resolve(theRest, result, context, rootKey);
        }
        // #endregion
        // #region function notation, some arguments
        if (key.hasMatch(/^\.?([^\.\'\",\[\]\(\)]+)\((.+)\)(.*)$/)) {
            var index = key.indexOf('(');
            var indexPair = findMate(key, index);
            methodName = key.substr(0, index);
            var argsStr = key.slice(index + 1, indexPair);
            if (indexPair < key.length - 1)
                theRest = key.substr(indexPair + 1);
            else
                theRest = '';
            if (methodName.startsWith('.'))
                methodName = methodName.substr(1);
            /*
            var match = key.match(/^\.?([^\.\'\",\[\]\(\)]+)\((.+)\)(.*)$/);
            methodName = match[1];
            var argsStr = match[2];
            theRest = match[3];
            */
            out = sing.resolve(methodName, data, context, rootKey);
            var args = sing.resolve(argsStr, data, context, rootKey);
            if (!$.isArray(args))
                args = [args];
            if (out == null || !out.apply) {
                throw "could not resolve " + rootKey;
            }
            result = out.apply(data, args);
            if (negateOutput)
                result = !result;
            if (theRest == null || theRest == '')
                return result;
            return sing.resolve(theRest, result, context, rootKey);
        }
        // #endregion
        // #region Array 'super-navigation'
        // sing.resolve('sing.methods[].details.unitTests[].requirement')
        // Works for arrays and hash tables.
        if (out === undefined && key.hasMatch(/^\.?([^\.\'\",\[\]\(\)]+)(\[[^\[\]]*\])\.?(.*)$/)) {
            matches = key.match(/^\.?([^\.\'\",\[\]\(\)]+)(\[[^\[\]]*\])\.?(.*)$/);
            property = matches[1];
            arrayIndex = matches[2];
            theRest = matches[3];
            /*
            var openBraceCount = 0;
            var closeBraceCount = 0;

            do {

                if (theRest[0] == '[')
                    openBraceCount++;
                if (theRest[0] == ']')
                    closeBraceCount++;

                theRest = theRest.substr(1);

            } while (openBraceCount != closeBraceCount && theRest.length > 0)
            */
            arrayIndex = arrayIndex.substr(1, arrayIndex.length - 2);
            var arrayProperty = sing.resolve(property, data, context, rootKey);
            var conditionFunc;
            // Array super-navigation, condition
            if (arrayIndex.contains(sing.constants.specialTokens.It) ||
                arrayIndex.contains(sing.constants.specialTokens.I)) {
                conditionFunc = function (item, index) {
                    context[sing.constants.specialTokens.It] = item;
                    context[sing.constants.specialTokens.I] = index;
                    var result = sing.resolve(arrayIndex, data, context, rootKey);
                    if ($.isDefined(result) &&
                        !$.isEmpty(result))
                        return true;
                    else
                        return false;
                };
            }
            else if (!$.isEmpty(arrayIndex)) {
                var resultIndex = sing.resolve(arrayIndex, data, context, rootKey);
                if (theRest == null || theRest == '')
                    return arrayProperty[resultIndex];
                out = sing.resolve(theRest, arrayProperty[resultIndex], context, rootKey);
                return out;
            }
            else {
                conditionFunc = function () { return true; };
            }
            if (!$.isDefined(arrayProperty))
                return null;
            if ($.isHash(arrayProperty))
                arrayProperty = $.objValues(arrayProperty);
            if (!$.isArray(arrayProperty))
                throw property + " was not an array.";
            var outArray = [];
            // Recursive array handling allows for multiple levels of super-navigation
            outArray = arrayProperty.collect(function (item, index) {
                try {
                    var condition = conditionFunc(item, index);
                    if (condition)
                        return sing.resolve(theRest, item, context, rootKey);
                    else
                        return undefined;
                }
                catch (ex) {
                    return undefined;
                }
            });
            return outArray;
        }
        // #endregion
        // #region Hash 'super-navigation'. Similar to Array 'super-navigation' but key values are kept.
        // sing.resolve('sing.methods{}.details.unitTests[].requirement')
        if (out === undefined && key.hasMatch(/^\.?([^\.\'\",\[\]\(\)\{\}]+)\{\}\.(.*)$/)) {
            matches = key.match(/^\.?([^\.\'\",\[\]\(\)\{\}]+)\{\}\.(.*)$/);
            property = matches[1];
            theRest = matches[2];
            var hashProperty = sing.resolve(property, data, context, rootKey);
            if (!$.isDefined(hashProperty))
                return null;
            if (!$.isHash(hashProperty))
                throw property + " was not a hash object.";
            var outHash = {};
            // Recursive hash handling allows for multiple levels of super-navigation
            $.objProperties(hashProperty).each(function (item) {
                try {
                    var result_1 = sing.resolve(theRest, item.value, context, rootKey);
                    if (result_1 !== undefined)
                        outHash[item.key] = result_1;
                }
                catch (ex) {
                }
            });
            return outHash;
        }
        // #endregion
        // #region Dot notation
        if (key.hasMatch(/^\.?([^\.\'\",\[\]\(\)]+)\.(.*)$/)) {
            var keyParts = key.split('.');
            var resolveFirst = sing.resolve(keyParts.shift(), data, context, rootKey);
            if (!$.isDefined(resolveFirst)) {
                throw "could not resolve " + rootKey;
            }
            data = resolveFirst;
            out = sing.resolve(keyParts.join('.'), data, context, rootKey);
            //console.log(`RESOLVE ${key}`);
            if (negateOutput)
                out = !out;
            return out;
        }
        // #endregion
        // #region Array creation
        if (out === undefined && key.hasMatch(/^\[(.+)\](.*)$/)) {
            matches = key.match(/^\[(.+)\](.*)$/);
            var arrayContents = matches[1];
            theRest = matches[2];
            arrayContents = sing.resolve(arrayContents, data, context, rootKey);
            if (!$.isArray(arrayContents))
                arrayContents = [arrayContents];
            if (theRest == null || theRest == '')
                return arrayContents;
            out = sing.resolve(theRest, arrayContents, context, rootKey);
            return out;
        }
        // #endregion
        // #region Non-escaped commas
        if (key.contains(',,')) {
            key = key.replaceAll(',,', commaSubstitute);
        }
        // #endregion
        // #region Comma notation
        if (key.hasMatch(/([^\.\'\",\[\]\(\)]*),(.*)$/)) {
            matches = key.match(/([^\.\'\",\[\]\(\)]*),(.*)$/);
            var item = matches[1];
            theRest = matches[2];
            if (!item || item == '')
                item = data;
            else
                item = sing.resolve(item, data, context, rootKey);
            var items = [item];
            items = items.concat(sing.resolve(theRest, data, context, rootKey));
            return items;
        }
        // #endregion
        // #region Strings
        if ((key.length > 1 && key[0] == '\'') ||
            (key.length > 1 && key[0] == '"')) {
            // Whole strings
            if (key[key.length - 1] == '\'' && key[key.length - 1] == '"') {
                if (key.length == 2)
                    return '';
                else {
                    return key.substr(1, key.length - 2);
                }
            }
            else {
                var quotePair = findMate(key, 0);
                // let quote = key.slice(1, quotePair);
                theRest = key.substr(quotePair + 1);
            }
        }
        // #endregion
        var keyPart = key.before(' ');
        // #region current data
        if (keyPart == sing.constants.specialTokens.Data) {
            out = context[sing.constants.specialTokens.Data];
            theRest = key.after(sing.constants.specialTokens.Data);
            if (!$.isEmpty(theRest)) {
                return sing.resolve(theRest, out, context, rootKey);
            }
            else {
                return out;
            }
        }
        if ($.isDefined(data))
            if (data[keyPart] !== undefined) {
                out = data[keyPart];
                theRest = key.after(keyPart);
                if (!$.isEmpty(theRest)) {
                    return sing.resolve(theRest, out, context, rootKey);
                }
                else {
                    return out;
                }
            }
        // #endregion
        // #region context
        if (out == undefined && context && context[keyPart] !== undefined) {
            out = context[keyPart];
            theRest = key.after(keyPart);
            if (!$.isEmpty(theRest)) {
                return sing.resolve(theRest, out, context, rootKey);
            }
            else {
                return out;
            }
        }
        // #endregion
        // #region global resolve
        if (out === undefined && sing.globalResolve[keyPart] !== undefined) {
            out = sing.globalResolve[keyPart];
            theRest = key.after(keyPart);
            if (!$.isEmpty(theRest)) {
                return sing.resolve(theRest, out, context, rootKey);
            }
            else {
                return out;
            }
        }
        // #endregion
        // #region available context of any object
        if (out === undefined && keyPart.endsWith(sing.constants.specialTokens.Context)) {
            var itemContext = sing.resolve(keyPart.before(sing.constants.specialTokens.Context), data, context, rootKey);
            var itemKeys = $.objKeys(itemContext);
            return itemKeys.join(', ');
        }
        // #endregion
        // #region Numbers
        if (keyPart.isNumeric()) {
            out = keyPart.toNumber();
            theRest = key.after(keyPart);
            if (!$.isEmpty(theRest)) {
                return sing.resolve(theRest, out, context, rootKey);
            }
            else {
                return out;
            }
        }
        // #endregion
        // #region Booleans
        if (keyPart.isBoolean()) {
            out = keyPart.toBoolean();
            theRest = key.after(keyPart);
            if (!$.isEmpty(theRest)) {
                return sing.resolve(theRest, out, context, rootKey);
            }
            else {
                return out;
            }
        }
        // #endregion
        // #region OR operation
        if (keyPart == '||') {
            theRest = key.substr(2);
            left = data;
            if ($.isEmpty(left) || left == false)
                return sing.resolve(theRest, data, context, rootKey);
            else
                return left;
        }
        // #endregion
        // #region AND operation
        if (keyPart == '&&') {
            theRest = key.substr(2);
            left = data;
            if ($.isEmpty(left) || left == false) {
                return false;
            }
            else {
                right = sing.resolve(theRest, data, context, rootKey);
                return true && !($.isEmpty(left) || left == false);
            }
        }
        else if (keyPart == '+') {
            theRest = key.substr(1);
            resolved = sing.resolve(theRest, data, context, rootKey);
            return (data + resolved);
        }
        else if (keyPart == '-') {
            theRest = key.substr(1);
            resolved = sing.resolve(theRest, data, context, rootKey);
            return (data - resolved);
        }
        else if (keyPart == '*') {
            theRest = key.substr(1);
            resolved = sing.resolve(theRest, data, context, rootKey);
            return (data * resolved);
        }
        else if (keyPart == '/') {
            theRest = key.substr(1);
            resolved = sing.resolve(theRest, data, context, rootKey);
            return (data / resolved);
        }
        else if (keyPart == '%') {
            theRest = key.substr(1);
            resolved = sing.resolve(theRest, data, context, rootKey);
            return (data % resolved);
        }
        else if (keyPart == '<<') {
            theRest = key.substr(1);
            resolved = sing.resolve(theRest, data, context, rootKey);
            return (data << resolved);
        }
        else if (keyPart == '>>') {
            theRest = key.substr(1);
            resolved = sing.resolve(theRest, data, context, rootKey);
            return (data >> resolved);
        }
        else if (keyPart == '^') {
            theRest = key.substr(1);
            resolved = sing.resolve(theRest, data, context, rootKey);
            return (data ^ resolved);
        }
        else if (keyPart == '&') {
            theRest = key.substr(1);
            resolved = sing.resolve(theRest, data, context, rootKey);
            return (data & resolved);
        }
        else if (keyPart == '|') {
            theRest = key.substr(1);
            resolved = sing.resolve(theRest, data, context, rootKey);
            return (data | resolved);
        }
        else if (keyPart == '===') {
            theRest = key.substr(3);
            resolved = sing.resolve(theRest, data, context, rootKey);
            return (data === resolved);
        }
        else if (keyPart == '!==') {
            theRest = key.substr(3);
            resolved = sing.resolve(theRest, data, context, rootKey);
            return (data !== resolved);
        }
        else if (keyPart == '==') {
            theRest = key.substr(2);
            resolved = sing.resolve(theRest, data, context, rootKey);
            return (data == resolved);
        }
        else if (keyPart == '!=') {
            theRest = key.substr(2);
            resolved = sing.resolve(theRest, data, context, rootKey);
            return (data != resolved);
        }
        else if (keyPart == '>=') {
            theRest = key.substr(2);
            resolved = sing.resolve(theRest, data, context, rootKey);
            return (data >= resolved);
        }
        else if (keyPart == '<=') {
            theRest = key.substr(2);
            resolved = sing.resolve(theRest, data, context, rootKey);
            return (data <= resolved);
        }
        else if (keyPart == '>') {
            theRest = key.substr(1);
            resolved = sing.resolve(theRest, data, context, rootKey);
            return (data > resolved);
        }
        else if (keyPart == '<') {
            theRest = key.substr(1);
            resolved = sing.resolve(theRest, data, context, rootKey);
            return (data < resolved);
        }
        // #endregion
        // ()
        // !
        // !()
        // ? :
        console.log("UNRESOLVED " + key);
    }
    catch (ex) {
        if (key != rootKey) {
            throw ex;
        }
        else {
            if (out === undefined && key.contains('||'))
                return sing.resolve(key.after('||'), data, context, key.after('||'));
            throw "could not resolve " + rootKey;
        }
    }
    if (out === undefined && key.contains('||'))
        out = sing.resolve(key.after('||'), data, context, key.after('||'));
    return out;
}
singRoot.method('init', null);
singRoot.method('ready', null);
singRoot.property('summary', {});
singRoot.property('defaultPolyfill', {});
singRoot.property('modules', {});
singRoot.property('methods', {});
singRoot.property('templates', {});
singRoot.property('func', {});
singRoot.property('autoDefaults', {});
singRoot.property('autoDefault', {});
singRoot.property('types', {});
singRoot.property('globalResolve', {});
singRoot.property('templateShownFunctions', {});
singRoot.ignoreUnknown('Module', 'Extension', 'AutoDefinition');
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
var singCore = singRoot.addModule(new SingularityModule('Core', Singularity));
singCore.glyphIcon = '&#xe201;';
singCore.ignoreUnknown('ALL');
singCore.summaryShort = '&nbsp;';
singCore.summaryLong = '&nbsp;';
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
var singModule = singCore.addModule(new SingularityModule('Modules', [SingularityModule, new SingularityModule('', null)]));
singModule.glyphIcon = '&#xe011;';
singModule.summaryShort = '&nbsp;';
singModule.summaryLong = '&nbsp;';
singModule.method('addModule', singRoot.addModule, {
    manuallyTested: true
});
singModule.method('method', singRoot.method, {
    manuallyTested: true
});
singModule.method('totalCodeLines', moduleTotalCodeLines);
singModule.method('fullName', singRoot.fullName);
function moduleTotalCodeLines() {
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
singModule.method('getMethods', moduleGetMethods, {
    manuallyTested: true
});
function moduleGetMethods(extName) {
    var _this = this;
    return $.objValues(sing.methods).where(function (ext) { return (ext.methodModule == _this &&
        (extName == null || ext.moduleName.contains(extName))); });
}
singModule.method('getUnknownProperties', moduleGetUnknownProperties);
function moduleGetUnknownProperties() {
    var thisModule = this;
    thisModule.ignoreUnknownMembers = thisModule.ignoreUnknownMembers || [];
    if (thisModule.ignoreUnknownMembers.length == 1 && thisModule.ignoreUnknownMembers[0] == 'ALL')
        return [];
    var methods = (thisModule.methods || []).arrayValues('shortName');
    var properties = (thisModule.properties || []).arrayValues('name');
    var keys = [];
    thisModule.trackObjects.collect(function (obj) {
        if (obj)
            keys = keys.concat($.objKeys(obj).select(function (key) { return (!$.isFunction(obj[key])); }));
        if (obj && obj.prototype)
            keys = keys.concat($.objKeys(obj.prototype).select(function (key) { return (!$.isFunction(obj.prototype[key])); }));
    });
    thisModule.subModules.each(function (sub) {
        if (sub.properties.has(function (prop) {
            if (keys.has(prop.name))
                keys = keys.remove(prop.name);
        })) {
        }
    });
    return keys.select(function (name) { return (!properties.has(name) &&
        !methods.has(name) &&
        !thisModule.ignoreUnknownMembers.has(name)); });
}
singModule.method('getUnknownMethods', moduleGetUnknownMethods);
function moduleGetUnknownMethods() {
    var thisModule = this;
    thisModule.ignoreUnknownMembers = thisModule.ignoreUnknownMembers || [];
    if (thisModule.ignoreUnknownMembers.length == 1 && thisModule.ignoreUnknownMembers[0] == 'ALL')
        return [];
    var methods = (thisModule.methods || []).arrayValues('shortName');
    var keys = [];
    thisModule.trackObjects.collect(function (obj) {
        if (obj)
            keys = keys.concat($.objKeys(obj).select(function (key) { return $.isFunction(obj[key]); }));
        if (obj && obj.prototype)
            keys = keys.concat($.objKeys(obj.prototype).select(function (key) { return $.isFunction(obj.prototype[key]); }));
    });
    return keys.select(function (name) { return (!methods.has(name) &&
        !$.objValues(sing.methods).has(function (m) { return (m.shortName == name &&
            m.methodModule.name != thisModule.name); }) &&
        !thisModule.ignoreUnknownMembers.has(name)); });
}
singModule.method('property', singRoot.property);
singModule.method('ignoreUnknown', singCore.ignoreUnknown);
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
var singMethod = singCore.addModule(new SingularityModule('Methods', [SingularityMethod, new SingularityMethod(null)]));
singMethod.glyphIcon = '&#xe019;';
singMethod.summaryShort = '&nbsp;';
singMethod.summaryLong = '&nbsp;';
var singExt = singRoot.addModule(new SingularityModule('Extensions', Singularity));
singExt.glyphIcon = '&#xe144;';
singExt.summaryShort = '&nbsp;';
singExt.summaryLong = '&nbsp;';
$(document).init(function () {
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
}());
function findMate(key, index) {
    if ($.isEmpty(key) || index < 0 || index >= key.length)
        return -1;
    var startingChars = ['(', '[', '{'];
    var matchingChars = {
        '(': ')',
        ')': '(',
        '[': ']',
        ']': '[',
        '{': '}',
        '}': '{'
    };
    var char = key[index];
    var charEnd = matchingChars[char];
    if (char == '\'')
        charEnd = '\'';
    if (char == '"')
        charEnd = '"';
    if ($.isEmpty(charEnd))
        return -1;
    var nestedChars = [];
    var isWithinStringSingle = false;
    var isWithinStringDouble = false;
    for (var i = index + 1; i < key.length; i++) {
        var lastChar = key[i - 1];
        var cursorChar = key[i];
        var cursorCharMatch = matchingChars[cursorChar];
        var commented = lastChar == '\\';
        if (!commented && cursorChar == '\'') {
            isWithinStringSingle = !isWithinStringSingle;
            continue;
        }
        if (!commented && cursorChar == '"') {
            isWithinStringDouble = !isWithinStringDouble;
            continue;
        }
        if (isWithinStringSingle || isWithinStringDouble)
            continue;
        if (!commented && !$.isEmpty(cursorCharMatch) && startingChars.has(cursorChar)) {
            nestedChars.push(cursorChar);
        }
        else {
            var lookingFor = charEnd;
            if (nestedChars.length > 0)
                lookingFor = matchingChars[nestedChars[nestedChars.length - 1]];
            if (!commented && cursorChar == lookingFor) {
                if (nestedChars.length > 0) {
                    nestedChars.pop();
                }
                else {
                    return i;
                }
            }
        }
    }
}
function insertAtCaret(areaId, text) {
    var txtarea = document.getElementById(areaId);
    var scrollPos = txtarea.scrollTop;
    var strPos = 0;
    var range;
    var br = ((txtarea.selectionStart || txtarea.selectionStart == 0) ?
        'ff' : (document.selection ? 'ie' : false));
    if (br == 'ie') {
        txtarea.focus();
        range = document.selection.createRange();
        range.moveStart('character', -txtarea.value.length);
        strPos = range.text.length;
    }
    else if (br == 'ff')
        strPos = txtarea.selectionStart;
    var front = (txtarea.value).substring(0, strPos);
    var back = (txtarea.value).substring(strPos, txtarea.value.length);
    txtarea.value = front + text + back;
    strPos = strPos + text.length;
    if (br == 'ie') {
        txtarea.focus();
        range = document.selection.createRange();
        range.moveStart('character', -txtarea.value.length);
        range.moveStart('character', strPos);
        range.moveEnd('character', 0);
        range.select();
    }
    else if (br == 'ff') {
        txtarea.selectionStart = strPos;
        txtarea.selectionEnd = strPos;
        txtarea.focus();
    }
    txtarea.scrollTop = scrollPos;
}
//# sourceMappingURL=singularity-core.js.map