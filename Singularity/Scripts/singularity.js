var Singularity = (function () {
    function Singularity() {
        this.summary = 'TypeScript, JavaScript, jQuery, HTML Language Extensions';
        this.Module = SingularityModule;
        this.Extension = SingularityMethod;
        this.AutoDefinition = SingularityAutoDefinition;
        this.enableTests = true;
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
            return 'Object';
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
            out += 1;
            out += 1;
            out += thisModule.properties.length;
            out += thisModule.getUnknownProperties().length;
            out += thisModule.subModules.count(function (sub) { return sub.totalDocumentation(); });
        }
        if (thisModule.requiredGlyphIcons) {
            out += 1;
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
        var out = 1
            + 1
            + 1
            + 1
            + 1;
        if (thisMethod.methodModule.requiredGlyphIcons)
            out++;
        return out;
    };
    SingularityMethod.prototype.loadAutoIgnoreErrors = function (ext, methods) {
        if (ext.auto.ignoreErrors) {
            var lastMethodIgnoreErrors = methods[methods.length - 1];
            methods.push(function () {
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
                description: "This callback function will be executed when " + ext.shortName + " has finished executing. It will be passed the result as its only argument"
            });
            var callbackIndex = ext.details.parameters.length - 1;
            var lastMethodMakeAsync = methods[methods.length - 1];
            methods.push(function () {
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
                var keys = Object.keys(arguments);
                var args = [];
                for (var j = 0; j < keys.length; j++) {
                    var arg = arguments[keys[j]];
                    args.push(arg);
                }
                for (var i = 0; i < srcext.details.parameters.length; i++) {
                    var param = srcext.details.parameters[i];
                    var testArg = args[i];
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
        var autoDefaults = sing.autoDefaults;
        if (sing.types[ext.moduleName] && sing.types[ext.moduleName].autoDefault !== undefined)
            autoDefaults = $.extend(true, {}, sing.types[ext.moduleName].autoDefault);
        ext.auto = new SingularityAutoDefinition(autoDefaults);
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
var sing = new Singularity();
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
        if (key.contains(' with '))
            return key;
        var commaSubstitute = '{{;;}}';
        if (key == '[]') {
            return [];
        }
        if (key == '{}') {
            return {};
        }
        var negateOutput = false;
        if (key.length > 2 && key[0] == '!' && key[1] != '!') {
            negateOutput = true;
            key = key.substr(1);
        }
        if (key.isNumeric())
            return key.toNumber();
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
        if (out === undefined && key.hasMatch(/^\.?([^\.\'\",\[\]\(\)]+)(\[[^\[\]]*\])\.?(.*)$/)) {
            matches = key.match(/^\.?([^\.\'\",\[\]\(\)]+)(\[[^\[\]]*\])\.?(.*)$/);
            property = matches[1];
            arrayIndex = matches[2];
            theRest = matches[3];
            arrayIndex = arrayIndex.substr(1, arrayIndex.length - 2);
            var arrayProperty = sing.resolve(property, data, context, rootKey);
            var conditionFunc;
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
        if (key.hasMatch(/^\.?([^\.\'\",\[\]\(\)]+)\.(.*)$/)) {
            var keyParts = key.split('.');
            var resolveFirst = sing.resolve(keyParts.shift(), data, context, rootKey);
            if (!$.isDefined(resolveFirst)) {
                throw "could not resolve " + rootKey;
            }
            data = resolveFirst;
            out = sing.resolve(keyParts.join('.'), data, context, rootKey);
            if (negateOutput)
                out = !out;
            return out;
        }
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
        if (key.contains(',,')) {
            key = key.replaceAll(',,', commaSubstitute);
        }
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
        if ((key.length > 1 && key[0] == '\'') ||
            (key.length > 1 && key[0] == '"')) {
            if (key[key.length - 1] == '\'' && key[key.length - 1] == '"') {
                if (key.length == 2)
                    return '';
                else {
                    return key.substr(1, key.length - 2);
                }
            }
            else {
                var quotePair = findMate(key, 0);
                theRest = key.substr(quotePair + 1);
            }
        }
        var keyPart = key.before(' ');
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
        if (out === undefined && keyPart.endsWith(sing.constants.specialTokens.Context)) {
            var itemContext = sing.resolve(keyPart.before(sing.constants.specialTokens.Context), data, context, rootKey);
            var itemKeys = $.objKeys(itemContext);
            return itemKeys.join(', ');
        }
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
        if (keyPart == '||') {
            theRest = key.substr(2);
            left = data;
            if ($.isEmpty(left) || left == false)
                return sing.resolve(theRest, data, context, rootKey);
            else
                return left;
        }
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
var singCore = singRoot.addModule(new SingularityModule('Core', Singularity));
singCore.glyphIcon = '&#xe201;';
singCore.ignoreUnknown('ALL');
singCore.summaryShort = '&nbsp;';
singCore.summaryLong = '&nbsp;';
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
var singEnumerable = singExt.addModule(new sing.Module('Enumerable', Array));
singEnumerable.glyphIcon = '&#xe012;';
singEnumerable.summaryShort = '&nbsp;';
singEnumerable.summaryLong = '&nbsp;';
singEnumerable.method('each', enumerableEach, {
    summary: 'Call each on an array to enumerate the contents of the array.',
    parameters: [
        {
            name: 'action',
            description: 'The function to call on each item of the array. The object and the index are passed as parameters to this function',
            types: [Function]
        }
    ],
    returns: 'Nothing.',
    returnType: null,
    glyphIcon: '&#xe153;',
    tests: function (ext) {
        ext.addTest([], [], undefined);
        ext.addTest([], [null], undefined);
        ext.addTest([], [undefined], undefined);
        ext.addTest([], [function () { }], undefined);
        ext.addTest([], [function () { return true; }], undefined);
        ext.addTest([], [function () { return false; }], undefined);
        ext.addTest([1], [function (a) { return a; }], undefined);
        ext.addCustomTest(function () {
            var test = [1, 2, 3];
            var count = 0;
            test.each(function (a, i) {
                if (a == test[i])
                    count++;
            });
            if (count != 3)
                return 'each did not execute 3 times.';
        });
    }
});
function enumerableEach(action) {
    var thisArray = this;
    thisArray.while(function (item, i) {
        action(item, i);
        return true;
    });
}
singEnumerable.method('while', enumerableWhile, {
    summary: 'Call each on an array to enumerate the contents of the array. Return any non-null value to continue enumeration otherwise returning false will stop the enumeration.',
    parameters: [
        {
            name: 'action',
            description: 'The function to call on each item of the array. The object and the index are passed as parameters to this function',
            types: [Function]
        }
    ],
    returns: 'True if the function was able to complete or False if it was aborted prematurely.',
    returnType: Boolean,
    glyphIcon: '&#xe156;',
    tests: function (ext) {
        ext.addTest([], [], true);
        ext.addTest([], [null], true);
        ext.addTest([], [undefined], true);
        ext.addTest([], [function () { }], true);
        ext.addTest([], [function () { return true; }], true);
        ext.addTest([1], [function () { return true; }], true);
        ext.addTest([], [function () { return false; }], true);
        ext.addTest([1], [function () { return false; }], false);
        ext.addTest([1, 2, 3, 4, 5], [function (a) { return (a < 3); }], false);
        ext.addTest([1, 2, 3, 4, 5], [function (item, index) { return (item == 4 && index == 3); }], false);
    }
});
function enumerableWhile(action) {
    if (!action)
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
singEnumerable.method('until', enumerableUntil, {
    summary: 'Call each on an array to enumerate the contents of the array. Return any non-null value to stop enumeration otherwise it will continue until the end of the array.',
    parameters: [
        {
            name: 'action',
            description: 'The function to call on each item of the array. The object and the index are passed as parameters to this function',
            types: [Function]
        }
    ],
    returns: 'True if the function was able to complete or False if it was aborted prematurely.',
    returnType: Boolean,
    glyphIcon: '&#xe155;',
    tests: function (ext) {
        ext.addTest([], [], false);
        ext.addTest([], [null], false);
        ext.addTest([], [undefined], false);
        ext.addTest([], [function () { }], false);
        ext.addTest([], [function () { return true; }], false);
        ext.addTest([1], [function () { return true; }], true);
        ext.addTest([1, 2], [function () { return true; }], true);
        ext.addTest([], [function () { return false; }], false);
        ext.addTest([1], [function () { return false; }], false);
    }
});
function enumerableUntil(action) {
    if (!action || this.length == 0)
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
singEnumerable.method('count', enumerableCount, {
    summary: 'count enumerates through an array counting how many objects match or satisfy a custom condition.',
    parameters: [
        {
            name: 'itemOrAction',
            description: 'Object or function to be evaluated. If a function is passed it will be evaluated, any non-null value will be added to the result. If anything other than a function is passed the number of occurences of the object will be counted. If this function returns a number, it will be added to the total result.',
            types: [Function, Object]
        }
    ],
    returns: 'The number of items that match the passed value or satisfy the given condition.',
    returnType: Number,
    glyphIcon: '&#xe141;',
    tests: function (ext) {
        ext.addTest([], [], 0);
        ext.addTest([null], [null], 1);
        ext.addTest(['a'], ['a'], 1);
        ext.addTest(['a'], [], 0);
        ext.addTest(['a', 'a'], ['a'], 2);
        ext.addTest(['a', 'a'], [function (a) { return (a == 'a'); }], 2);
        ext.addTest(['a', 'a'], [function (a) { return (a == 'b'); }], 0);
        ext.addTest([5, 6, 7], [function (a) { return a; }], 18);
    }
});
function enumerableCount(itemOrAction) {
    if (itemOrAction === undefined)
        return 0;
    var thisArray = this;
    var out = 0;
    if (!$.isFunction(itemOrAction)) {
        var itemValue = itemOrAction;
        itemOrAction = function (item) { return (item == itemValue); };
    }
    thisArray.each(function (item, i) {
        var result = itemOrAction(item, i);
        if (result !== null &&
            result !== undefined &&
            result !== false) {
            if ($.isNumber(result))
                out += result;
            else
                out++;
        }
    });
    return out;
}
singEnumerable.method('has', enumerableHas, {
    summary: 'has enumerates through an array and returns whether it contains an item, or items, or matches the passed condition.',
    parameters: [
        {
            name: 'itemOrItemsOrAction',
            description: 'An item, array of items, or condition function to determine whether a match has been found.',
            types: [Object, Array, Function]
        }
    ],
    returns: 'Whether a match was found.',
    returnType: Boolean,
    examples: null,
    glyphIcon: '&#xe003;',
    aliases: ['contains'],
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
        ext.addTest([1, 2, 3], [function (a) { return (a == 2); }], true);
        ext.addTest([1, 2, 3], [function (a) { return (a == 5); }], false);
    }
});
function enumerableHas() {
    var items = [];
    for (var _i = 0; _i < arguments.length; _i++) {
        items[_i - 0] = arguments[_i];
    }
    var srcThis = this;
    if (items == null)
        return false;
    if (items.length == 1) {
        if ($.isFunction(items[0])) {
            var result = this.first(items[0]);
            return result !== undefined &&
                (!$.isArray(result) || result.length > 0);
        }
        if ($.isArray(items[0])) {
            return srcThis.has.apply(srcThis, items[0]);
        }
        return items[0] !== undefined && this.indexOf(items[0]) >= 0;
    }
    if (items.length > 1) {
        var result2 = items.first(function (it) {
            if (it === undefined)
                return false;
            if (srcThis.has(it))
                return true;
            return false;
        });
        return !!result2;
    }
    return false;
}
singEnumerable.method('select', enumerableSelect, {
    summary: 'select enumerates a list and filters its contents based on the filter function you provide.',
    parameters: [
        {
            name: 'filter',
            description: 'A function that takes the item and index as parameters. Any return value that isn\'t undefined, null, or false will cause the item to be included in the final result.',
            types: [Function]
        }
    ],
    returns: 'A filtered array.',
    returnType: Array,
    glyphIcon: '&#xe057;',
    aliases: ['where'],
    tests: function (ext) {
        ext.addTest([], [], []);
        ext.addTest([], [null], []);
        ext.addTest([], [undefined], []);
        ext.addTest([1, 2, 3, undefined], [], []);
        ext.addTest([1, 2, 3, undefined], [function (a) { return (a == 3); }], [3]);
        ext.addTest([1, 2, 3, undefined], [function (a) { return (a === undefined); }], [undefined]);
        ext.addTest([1, 2, 3, undefined], [function (a) { return (a < 3); }], [1, 2]);
    }
});
function enumerableSelect(filter) {
    if (!filter)
        return [];
    var thisArray = this;
    var out = [];
    thisArray.each(function (item, i) {
        var result = filter(item, i);
        if (result != null &&
            result != false)
            out = out.concat(item);
    });
    return out;
}
singEnumerable.method('collect', enumerableCollect, {
    summary: 'collect acts on an array and passes its values to the collection function you provide.',
    parameters: [
        {
            name: 'collector',
            description: 'This function is passed the item and index. Its return values will be included in the final result. If the return value is undefined or null, it will not be included.',
            types: [Function]
        }
    ],
    returns: 'A filtered array of the values you return from the collection function.',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe058;',
    tests: function (ext) {
        ext.addTest([], [], []);
        ext.addTest([], [null], []);
        ext.addTest([], [undefined], []);
        ext.addTest([undefined], [], []);
        ext.addTest([null], [], []);
        ext.addTest([undefined, null], [], []);
        ext.addTest([1, 2, 3, undefined, null], [], [1, 2, 3]);
        ext.addTest([1, 2, 3, [4, 5, 6]], [], [1, 2, 3, [4, 5, 6]]);
        ext.addTest([1, 2, 3, undefined, null], [function (a) { return (a == 3); }], [false, false, true, false, false]);
        ext.addTest([1, 2, 3, undefined, null], [function (a) { return (a <= 2); }], [true, true, false, false, true]);
        ext.addTest([1, 2, 3, undefined, null], [function (a) { return (a + 1); }], [2, 3, 4, NaN, 1]);
        ext.addTest([1, 2, 3, undefined, null], [function (a) { return $.isDefined(a); }], [true, true, true, false, false]);
    }
});
function enumerableCollect(collector) {
    var thisArray = this;
    if (collector == null)
        collector = sing.func.identity;
    var out = [];
    thisArray.each(function (item, i) {
        var result = collector(item, i);
        if (result !== null &&
            result !== undefined)
            out.push(result);
    });
    return out;
}
singEnumerable.method('first', enumerableFirst, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe070;',
    tests: function (ext) {
        ext.addTest([], [], []);
        ext.addTest([], [null], []);
        ext.addTest([], [undefined], []);
        ext.addTest([], [5], []);
        ext.addTest([1, 2, 3, 4, 5], [0], []);
        ext.addTest([1, 2, 3, 4, 5], [2], [1, 2]);
        ext.addTest([1, 2, 3, 4, 5], [5], [1, 2, 3, 4, 5]);
        ext.addTest([1, 2, 3, 4, 5], [8], [1, 2, 3, 4, 5]);
        ext.addTest([1, 2, 3, 'a', 5], ['a'], []);
        ext.addTest([1, 2, 3, 4, 5], [function (a) { return (a == 3); }], [3]);
        ext.addTest([1, 2, 3, 4, 5], [function (a) { return (a != 3); }], [1]);
    }
});
function enumerableFirst(countOrCondition) {
    if (countOrCondition <= 0)
        return [];
    var thisArray = this;
    if (!countOrCondition && this.length > 0)
        return this[0];
    if (!countOrCondition)
        return [];
    if (objectIsNumber(countOrCondition)) {
        var itemNumber = countOrCondition;
        var outArray = [];
        thisArray.while(function (item) {
            outArray.push(item);
            if (outArray.length == itemNumber)
                return false;
        });
        return outArray;
    }
    if (!$.isFunction(countOrCondition)) {
        return [];
    }
    var out = undefined;
    thisArray.while(function (item, i) {
        var result = countOrCondition(item, i);
        if (result) {
            out = item;
            return false;
        }
    });
    return out;
}
singEnumerable.method('last', enumerableLast, {
    summary: null,
    parameters: [
        {
            name: 'countOrCondition',
            types: [Number, Function],
            description: 'If a number is passed, '
        }
    ],
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe076;',
    tests: function (ext) {
        ext.addTest([], [], []);
        ext.addTest([], [null], []);
        ext.addTest([], [undefined], []);
        ext.addTest([], [5], []);
        ext.addTest([1, 2, 3, 4, 5], [0], []);
        ext.addTest([1, 2, 3, 4, 5], [2], [4, 5]);
        ext.addTest([1, 2, 3, 4, 5], [5], [1, 2, 3, 4, 5]);
        ext.addTest([1, 2, 3, 4, 5], [8], [1, 2, 3, 4, 5]);
        ext.addTest([1, 2, 3, 'a', 5], ['a'], []);
        ext.addTest([1, 2, 3, 4, 5], [function (a) { return (a > 3); }], [5]);
        ext.addTest([1, 2, 3, 4, 5], [function (a) { return (a < 3); }], [2]);
        ext.addTest([1, 2, 3, 4, 5], [function (a) { return (a != 3); }], [5]);
    }
});
function enumerableLast(countOrCondition) {
    if (countOrCondition <= 0)
        return [];
    var thisArray = this;
    if (!countOrCondition && thisArray.length > 0)
        return thisArray[thisArray.length - 1];
    if (!countOrCondition)
        return [];
    var out = thisArray.clone().reverse().first(countOrCondition);
    if ($.isArray(out))
        out = out.reverse();
    return out;
}
singEnumerable.method('range', enumerableRange, {
    summary: 'Retrieves a range of items from an array.',
    parameters: [
        {
            name: 'start',
            description: ''
        },
        {
            name: 'end',
            description: ''
        }
    ],
    returns: 'A range of items as an array.',
    returnType: Array,
    examples: null,
    glyphIcon: '&#xe120;',
    tests: function (ext) {
        ext.addTest([], [], []);
        ext.addTest([], [0, 1], []);
        ext.addTest([], [null], []);
        ext.addTest([], [undefined], []);
        ext.addTest([1, 2, 3, 4, 5], [0, 1], [1, 2]);
        ext.addTest([1, 2, 3, 4, 5], [0, 1, null], [1, 2]);
        ext.addTest([1, 2, 3, 4, 5], [0, 1, undefined], [1, 2]);
        ext.addTest([1, 2, 3, 4, 5], [0, 4], [1, 2, 3, 4, 5]);
        ext.addTest([1, 2, 3, 4, 5], [3, 4], [4, 5]);
        ext.addTest([1, 2, 3, 4, 5], [4, 3], []);
    }
});
function enumerableRange(start, end) {
    if (start === void 0) { start = 0; }
    if (end === void 0) { end = this.length - 1; }
    if (start > end)
        return [];
    if (start < 0)
        start = 0;
    if (end < 0)
        end = 0;
    var out = [];
    for (var i = start; i <= end && i >= 0 && i < this.length; i++) {
        out.push(this[i]);
    }
    return out;
}
singEnumerable.method('flatten', enumerableFlatten, {
    summary: 'Traverses an array of possibly nested items.',
    parameters: [],
    returns: 'A \'flattened\' single-level array of all items.',
    returnType: Array,
    glyphIcon: '&#xe245;',
    tests: function (ext) {
        ext.addTest([], [], []);
        ext.addTest([1], [], [1]);
        ext.addTest([1, 2, 3], [], [1, 2, 3]);
        ext.addTest([1, 2, [3, 4, 5]], [], [1, 2, 3, 4, 5]);
        ext.addTest([1, 2, [3, 4, [5, 6, 7, 8]]], [], [1, 2, 3, 4, 5, 6, 7, 8]);
        ext.addTest([[[1, 2, 3], 4], 5, 6, 7, 8], [], [1, 2, 3, 4, 5, 6, 7, 8]);
    }
});
function enumerableFlatten() {
    var thisArray = this;
    var out = [];
    thisArray.each(function (item) {
        if ($.isArray(item))
            out = out.concat(item.flatten());
        else
            out.push(item);
    });
    return out;
}
singEnumerable.method('indices', enumerableIndices, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe056;',
    aliases: ['indexes'],
    tests: function (ext) {
        ext.addTest(['a'], ['a'], [0]);
        ext.addTest(['a'], ['b'], []);
        ext.addTest(['a'], [[undefined]], []);
        ext.addTest(['a'], [[null]], []);
        ext.addTest(['a'], [null], []);
        ext.addTest(['a', 'b'], ['a', 'b'], [0, 1]);
        ext.addTest(['a', 'b'], [['a', 'b']], [0, 1]);
        ext.addTest(['a', 'a', 'a', 'b', 'b', 'b'], ['a', 'b'], [0, 1, 2, 3, 4, 5]);
    }
});
function enumerableIndices() {
    var items = [];
    for (var _i = 0; _i < arguments.length; _i++) {
        items[_i - 0] = arguments[_i];
    }
    var thisArray = this;
    var item;
    if (items.length == 1) {
        item = items[0];
    }
    else {
        item = items;
    }
    if ($.isArray(item)) {
        var itemArray = item;
        return thisArray.collect(function (arrayItem, i) {
            if (itemArray.has(arrayItem))
                return i;
        });
    }
    if ($.isFunction(item)) {
        var itemFunction = item;
        return thisArray.collect(function (item, i) {
            if (!!itemFunction(item, i))
                return i;
        });
    }
    var index = thisArray.indexOf(item);
    if (index >= 0)
        return [index];
    else
        return [];
}
singEnumerable.method('remove', enumerableRemove, {
    summary: 'Enumerates an array removing items that match the provided values.',
    parameters: [
        {
            name: 'itemOrItemsOrFunction',
            description: 'Passing a single item or array of items will exclude the items from the result. Passing a function will evaluate each item, a true value will cause the item to be excluded from the result.',
            types: [Function]
        }
    ],
    returns: 'A filtered array with matching item(s) excluded.',
    returnType: Array,
    glyphIcon: '&#xe163;',
    tests: function (ext) {
        ext.addTest([], [], []);
        ext.addTest([], [null], []);
        ext.addTest([null, undefined], [null], []);
        ext.addTest([], [undefined], []);
        ext.addTest([null, undefined], [undefined], []);
        ext.addTest([null, undefined], [], []);
        ext.addTest([], [1], []);
        ext.addTest([1], [1], []);
        ext.addTest([1, 2], [1], [2]);
        ext.addTest([1, 2], [[1, 2]], []);
        ext.addTest([1, 2], [[1, 2, null]], []);
        ext.addTest([1, 2], [[1, 2, undefined]], []);
    }
});
function enumerableRemove(itemOrItemsOrFunction) {
    var thisArray = this;
    if (!itemOrItemsOrFunction)
        return thisArray.collect();
    if ($.isArray(itemOrItemsOrFunction)) {
        var itemArray = itemOrItemsOrFunction;
        return thisArray.select(function (item) { return (!itemArray.has(item)); });
    }
    if ($.isFunction(itemOrItemsOrFunction)) {
        var itemFunction = itemOrItemsOrFunction;
        return thisArray.select(itemFunction.fnNot());
    }
    return thisArray.select(function (item) { return (item != itemOrItemsOrFunction); });
}
singEnumerable.method('sortBy', enumerableSortBy, {
    summary: 'Sorts the source array by a custom property or function accessor.',
    parameters: [
        {
            name: 'arg',
            description: 'An optional argument ',
            types: [Array]
        }
    ],
    returns: 'A sorted array.',
    returnType: Array,
    glyphIcon: '&#xe150;',
    aliases: ['orderBy'],
    tests: function (ext) {
        ext.addTest([], [], []);
        ext.addTest(['a', 'b', 'c', 'd', 'e'], [], ['a', 'b', 'c', 'd', 'e']);
        ext.addTest(['e', 'd', 'c', 'b', 'a'], [], ['a', 'b', 'c', 'd', 'e']);
        ext.addTest(['d', 'a', 'c', 'e', 'b'], [], ['a', 'b', 'c', 'd', 'e']);
        ext.addTest(['bananas', 'apples', 'apple pie', 'apple', 'pears', 'grapefruit', 'eggs'], [], ['apple', 'apple pie', 'apples', 'bananas', 'eggs', 'grapefruit', 'pears']);
        ext.addTest(['bananas', 'apples', 'apple pie', 'apple', 'pears', 'grapefruit', 'eggs'], ['length'], ['eggs', 'apple', 'pears', 'apples', 'bananas', 'apple pie', 'grapefruit']);
        ext.addTest([{ name: 'frank', age: 111 }, { name: 'steve', age: 12 }, { name: 'bob', age: 52 }], ['name'], [{ name: 'bob', age: 52 }, { name: 'frank', age: 111 }, { name: 'steve', age: 12 }]);
        ext.addTest([{ name: 'frank', age: 111 }, { name: 'steve', age: 12 }, { name: 'bob', age: 52 }], ['age'], [{ name: 'steve', age: 12 }, { name: 'bob', age: 52 }, { name: 'frank', age: 111 }]);
        ext.addTest([{ name: 'frank', age: 111 }, { name: 'steve', age: 12 }, { name: 'bob', age: 52 }], [function (a) { return a.name; }], [{ name: 'bob', age: 52 }, { name: 'frank', age: 111 },
            { name: 'steve', age: 12 }]);
        ext.addTest([{ name: 'frank', age: 111 }, { name: 'steve', age: 12 }, { name: 'bob', age: 52 }], [function (a) { return a.age; }], [{ name: 'steve', age: 12 }, { name: 'bob', age: 52 },
            { name: 'frank', age: 111 }]);
    }
});
function enumerableSortBy(arg) {
    var defaultValueFunc = function (item) { return item; };
    if (arg == null) {
        arg = defaultValueFunc;
    }
    var customIndex = false;
    var indexes = this.clone();
    if ($.isString(arg) && arg.contains('.')) {
        arg = arg.split('.');
    }
    if ($.isString(arg)) {
        customIndex = true;
        indexes = indexes.collect(function (item) { return ($.objHasKey(item, arg) && item != null ?
            defaultValueFunc(item[arg]) : -1); });
    }
    else if ($.isArray(arg)) {
        var argArray = arg;
        for (var i = 0; i < arg.length; i++) {
            customIndex = true;
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
        customIndex = true;
        indexes = indexes.collect(argFunction);
    }
    var items = this.clone();
    if (customIndex) {
        var out = indexes.quickSort([items]);
        if (out.sortWith)
            return out.sortWith[0];
        else
            return out.items;
    }
    else
        return indexes.quickSort([items]);
}
singEnumerable.method('quickSort', enumerableQuickSort, {
    summary: 'Performs the built-in JavaScript comparison to sort the items in the source array.',
    parameters: [
        {
            name: 'sortWith',
            description: 'Optional companion array(s) which will be reordered along with the source array.',
            types: [Array]
        }
    ],
    returns: 'A sorted array.',
    returnType: Array,
    glyphIcon: '&#xe150;',
    tests: function (ext) {
        ext.addTest([], [], []);
        ext.addTest(['a', 'b', 'c', 'd', 'e'], [], ['a', 'b', 'c', 'd', 'e']);
        ext.addTest(['e', 'd', 'c', 'b', 'a'], [], ['a', 'b', 'c', 'd', 'e']);
        ext.addTest(['d', 'a', 'c', 'e', 'b'], [], ['a', 'b', 'c', 'd', 'e']);
        ext.addTest(['bananas', 'apples', 'apple pie', 'apple', 'pears', 'grapefruit', 'eggs'], [], ['apple', 'apple pie', 'apples', 'bananas', 'eggs', 'grapefruit', 'pears']);
        ext.addTest([5, 4, 3, 2, 1], [], [1, 2, 3, 4, 5]);
        ext.addCustomTest(function () {
            var test = [1, 2, 3, 4, 5];
            var result = ['d', 'a', 'c', 'e', 'b'].quickSort([test]);
            test = result.sortWith[0];
            if ($.toStr(test) != $.toStr([2, 5, 3, 1, 4]))
                return 'test failed.';
        });
    }
});
function enumerableQuickSort(sortWith, left, right) {
    if (left === void 0) { left = 0; }
    if (right === void 0) { right = (this.length - 1); }
    var thisArray = this;
    if (sortWith && left == 0 && right == this.length - 1) {
        for (var i = 0; i < sortWith.length; i++) {
            if (sortWith[i] && sortWith[i].length != thisArray.length) {
                console.log(this, sortWith);
                throw "Lengths did not match " + thisArray.length + ", " + sortWith[i].length;
            }
        }
    }
    if (thisArray.length > 1) {
        var partitionResult = enumerableQuickSortPartition(thisArray, left, right, sortWith);
        var index = partitionResult.index;
        thisArray = partitionResult.items;
        sortWith = partitionResult.sortWith;
        var sorted = void 0;
        if (left < index - 1) {
            if (!$.isEmpty(sortWith)) {
                sorted = thisArray.quickSort(sortWith, left, index - 1);
                if ($.isHash(sorted)) {
                    thisArray = sorted.items;
                    sortWith = sorted.sortWith;
                }
                else {
                    thisArray = sorted;
                }
            }
            else {
                thisArray = thisArray.quickSort(sortWith, left, index - 1);
            }
        }
        if (index < right) {
            if (!$.isEmpty(sortWith)) {
                sorted = thisArray.quickSort(sortWith, index, right);
                if ($.isHash(sorted)) {
                    thisArray = sorted.items;
                    sortWith = sorted.sortWith;
                }
                else {
                    thisArray = sorted;
                }
            }
            else {
                thisArray = thisArray.quickSort(sortWith, index, right);
            }
        }
    }
    if (sortWith != null && !$.isEmpty(sortWith)) {
        return {
            items: thisArray,
            sortWith: sortWith
        };
    }
    else {
        return thisArray;
    }
}
function enumerableQuickSortPartition(items, left, right, sortWith) {
    var pivot = items[Math.floor((right + left) / 2)];
    var i = left;
    var j = right;
    while (i <= j) {
        while (items[i] < pivot) {
            i++;
        }
        while (items[j] > pivot) {
            j--;
        }
        if (i <= j) {
            var swapResult = enumerableQuickSortSwap(items, i, j, sortWith);
            items = swapResult.items;
            if ($.toStr(swapResult.sortWith) == '0')
                swapResult.sortWith = swapResult.sortWith;
            sortWith = swapResult.sortWith;
            i++;
            j--;
        }
    }
    return {
        items: items,
        sortWith: sortWith,
        index: i
    };
}
function enumerableQuickSortSwap(items, firstIndex, secondIndex, sortWith) {
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
        sortWith: sortWith
    };
}
singEnumerable.method('timesDo', enumerableTimesDo, {
    summary: 'Repeats a function a number of times',
    parameters: [
        {
            name: 'executeFunc',
            types: [Function],
            description: 'The function to execute',
            required: true
        },
        {
            name: 'args',
            types: [Array],
            defaultValue: [],
            description: ''
        },
        {
            name: 'caller',
            types: [Object],
            description: ''
        }
    ],
    returns: 'An array of objects collected from the return values of executeFunc\'s executions.',
    returnType: Object,
    examples: ['\
            (5).timesDo(function() { alert(\'hi\'); });'],
    glyphIcon: '&#xe137;',
    tests: function (ext) {
        ext.addTest(5, [sing.func.increment, [5]], [6, 6, 6, 6, 6]);
    }
}, Number.prototype);
function enumerableTimesDo(executeFunc, args, caller) {
    if (!$.isDefined(this) ||
        this <= 0 ||
        !$.isDefined(executeFunc))
        return [];
    caller = caller || this;
    var out = [];
    for (var i = 0; i < this; i++) {
        var result = executeFunc.apply(caller, args);
        if (result != null)
            out.push(result);
    }
    return out;
}
var loggingInfoEnabled = true;
var loggingErrorEnabled = true;
var loggingWarningEnabled = true;
var singLog = singCore.addModule(new sing.Module('Logging', sing, sing));
singLog.glyphIcon = '&#xe105;';
singLog.ignoreUnknown('ALL');
function log() {
    var message = [];
    for (var _i = 0; _i < arguments.length; _i++) {
        message[_i - 0] = arguments[_i];
    }
    if (loggingInfoEnabled) {
        console.log("%c" + message, 'background: #eee; color: #555');
    }
}
singLog.method('log', arrayLog, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    }
}, Array.prototype, 'Array');
function arrayLog() {
    log(this);
}
singLog.method('log', numberLog, {
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
}, Number.prototype, 'Number');
function numberLog() {
    log(this);
}
singLog.method('log', stringLog, {
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
}, String.prototype, 'String');
function stringLog() {
    log(this);
}
singLog.method('log', booleanLog, {
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
}, Boolean.prototype, 'Boolean');
function booleanLog() {
    log(this);
}
function warn() {
    var message = [];
    for (var _i = 0; _i < arguments.length; _i++) {
        message[_i - 0] = arguments[_i];
    }
    if (loggingWarningEnabled) {
        if ($.toStr && $.resolve)
            console.log("%c" + $.toStr($.resolve(message), true), 'background: #555; color: #F7DAA3');
        else
            console.log("%c" + message, 'background: #555; color: #F7DAA3');
    }
}
singLog.method('warn', arrayWarn, {}, Array.prototype, 'Array');
function arrayWarn() {
    warn(this);
}
singLog.method('warn', numberWarn, {}, Number.prototype, 'Number');
function numberWarn() {
    warn(this);
}
singLog.method('warn', stringWarn, {}, String.prototype, 'String');
function stringWarn() {
    warn(this);
}
singLog.method('warn', booleanWarn, {}, Boolean.prototype, 'Boolean');
function booleanWarn() {
    warn(this);
}
function error() {
    var message = [];
    for (var _i = 0; _i < arguments.length; _i++) {
        message[_i - 0] = arguments[_i];
    }
    if (loggingErrorEnabled) {
        console.log(message);
    }
}
singLog.method('error', arrayError, {}, Array.prototype, 'Array');
function arrayError() {
    error(this);
}
singLog.method('error', numberError, {}, Number.prototype, 'Number');
function numberError() {
    error(this);
}
singLog.method('error', stringError, {}, String.prototype, 'String');
function stringError() {
    error(this);
}
singLog.method('error', booleanError, {}, Boolean.prototype, 'Boolean');
function booleanError() {
    error(this);
}
var singString = singExt.addModule(new sing.Module('String', String));
singString.glyphIcon = '&#xe241;';
singString.method('contains', stringContains, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe003;',
    tests: function (ext) {
        ext.addTest('', [], false);
        ext.addTest('', [''], false);
        ext.addTest('', [' '], false);
        ext.addTest(' ', [''], false);
        ext.addTest(' ', [' '], true);
        ext.addTest('abc', ['a'], true);
        ext.addTest('abc', ['d'], false);
        ext.addTest('abc', ['abc'], true);
    }
});
function stringContains(str) {
    if (!str || str == '')
        return false;
    return this == str ||
        this.indexOf(str) >= 0;
}
singString.method('replaceAll', stringReplaceAll, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe015;',
    tests: function (ext) {
        ext.addTest('apples', ['s', ' pie'], 'apple pie');
        ext.addTest('apples apples', ['s', ' pie'], 'apple pie apple pie');
        ext.addFailsTest('apples apples', ['s', 'pies'], stringReplaceAllErrorReplacementContinsSearch);
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
    }
});
var stringReplaceAllErrorReplacementContinsSearch = 'Replace All Error: replacement must not contain search term';
function stringReplaceAll(searchOrSearches, replaceOrReplacements) {
    if (replaceOrReplacements == undefined)
        replaceOrReplacements = '';
    if (searchOrSearches == undefined || searchOrSearches == '')
        return this;
    var out = this;
    if ($.isArray(searchOrSearches)) {
        var searchArray = searchOrSearches;
        searchArray.each(function (item, i) {
            var replacestr = $.isArray(replaceOrReplacements) ? replaceOrReplacements[i] : replaceOrReplacements;
            if (replacestr.toString().contains(item.toString()))
                throw stringReplaceAllErrorReplacementContinsSearch;
            out = out.replaceAll(item, replacestr).toString();
        });
        return out.toString();
    }
    else {
        if (this == searchOrSearches &&
            (replaceOrReplacements == ''))
            return '';
        if (replaceOrReplacements.toString().contains(searchOrSearches.toString()))
            throw stringReplaceAllErrorReplacementContinsSearch;
        while (out.indexOf(searchOrSearches) >= 0)
            out = out.replace(searchOrSearches, replaceOrReplacements);
        return out.toString();
    }
}
singString.method('removeAll', stringRemoveAll, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe016;',
    tests: function (ext) {
        ext.addTest('', [], '');
        ext.addTest('', [''], '');
        ext.addTest('apple pie', [], 'apple pie');
        ext.addTest('apple pie', [null], 'apple pie');
        ext.addTest('apple pie', [undefined], 'apple pie');
        ext.addTest('apple pie', [''], 'apple pie');
        ext.addTest('apple pie', [' '], 'applepie');
        ext.addTest('apple pie', ['p'], 'ale ie');
        ext.addTest('apple pie', ['apple'], ' pie');
        ext.addTest('apple pie', ['pie'], 'apple ');
        ext.addTest('apple pie', ['pies'], 'apple pie');
    }
});
function stringRemoveAll(stringOrStrings) {
    if ($.isArray(stringOrStrings)) {
        var out = this;
        var array = stringOrStrings;
        for (var s in array) {
            if ((array).hasOwnProperty(s)) {
                out = out.removeAll(s);
            }
        }
        return out;
    }
    return this.replaceAll(stringOrStrings, '');
}
singString.method('upper', stringUpper, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe260;',
    tests: function (ext) {
        ext.addTest('', [], '');
        ext.addTest('apple', [], 'APPLE');
        ext.addTest('Apple', [], 'APPLE');
        ext.addTest('APPLE', [], 'APPLE');
    }
});
function stringUpper() {
    return this.toUpperCase();
}
singString.method('lower', stringLower, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe259;',
    tests: function (ext) {
        ext.addTest('', [], '');
        ext.addTest('apple', [], 'apple');
        ext.addTest('Apple', [], 'apple');
        ext.addTest('APPLE', [], 'apple');
    }
});
function stringLower() {
    return this.toLowerCase();
}
singString.method('collapseSpaces', stringCollapseSpaces, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: 'icon-resize-small',
    tests: function (ext) {
        ext.addTest('', [], '');
        ext.addTest('           ', [], ' ');
        ext.addTest('apple pie', [], 'apple pie');
        ext.addTest('apple       pie', [], 'apple pie');
    }
});
function stringCollapseSpaces() {
    return this.replaceAll('  ', ' ');
}
singString.method('startsWith', stringStartsWith, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe079;',
    tests: function (ext) {
        ext.addTest('', [], false);
        ext.addTest('', [''], false);
        ext.addTest('apple pie', [], false);
        ext.addTest('apple pie', [''], false);
        ext.addTest('apple pie', ['apple'], true);
        ext.addTest('apple pie', ['apples'], false);
        ext.addTest('apple pie', ['apple pie'], true);
    }
});
function stringStartsWith(stringOrStrings) {
    var thisString = this;
    if (!stringOrStrings)
        return false;
    if ($.isArray(stringOrStrings)) {
        return stringOrStrings.has(function (s) {
            if (thisString.startsWith(s))
                return true;
            return false;
        });
    }
    return this.indexOf(stringOrStrings) == 0;
}
singString.method('endsWith', stringEndsWith, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe080;',
    tests: function (ext) {
        ext.addTest('', [], false);
        ext.addTest('', [''], false);
        ext.addTest('apple pie', [], false);
        ext.addTest('apple pie', [''], false);
        ext.addTest('apple pie', ['apple'], false);
        ext.addTest('apple pie', ['pie'], true);
        ext.addTest('apple pie', ['pies'], false);
    }
});
function stringEndsWith(stringOrStrings) {
    if (!stringOrStrings)
        return false;
    if ($.isArray(stringOrStrings)) {
        var array = stringOrStrings;
        for (var s in array) {
            if ((array).hasOwnProperty(s)) {
                if (this.endsWith(s))
                    return true;
            }
        }
        return false;
    }
    var index = this.indexOf(stringOrStrings);
    return index >= 0 && index == this.length - stringOrStrings.length;
}
singString.method('reverse', stringReverse, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe178;',
    tests: function (ext) {
        ext.addTest('', [], '');
        ext.addTest('apple pie', [], 'eip elppa');
    }
});
function stringReverse() {
    var out = '';
    for (var i = this.length - 1; i >= 0; i--) {
        out += this[i];
    }
    return out;
}
singString.method('repeat', stringRepeat, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe031;',
    tests: function (ext) {
        ext.addTest('', [], '');
        ext.addTest('', [0], '');
        ext.addTest('', [5], '');
        ext.addTest(' ', [5], '     ');
        ext.addTest('apple', [-1], '');
        ext.addTest('apple', [0], '');
        ext.addTest('apple', [1], 'apple');
        ext.addTest('apple', [2], 'appleapple');
        ext.addTest('apple', [3, ' '], 'apple apple apple');
    }
});
function stringRepeat(times, separator) {
    if (times === void 0) { times = 0; }
    if (separator === void 0) { separator = ''; }
    if (times <= 0)
        return '';
    var out = '';
    for (var i = 0; i < times; i++) {
        out += this;
        if (separator.length > 0 && i < times - 1)
            out += separator;
    }
    return out;
}
singString.method('words', stringWords, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe111;',
    tests: function (ext) {
        ext.addTest('', [], '');
        ext.addTest('apple', [], ['apple']);
        ext.addTest('apple pie', [], ['apple', 'pie']);
    }
});
function stringWords() {
    return this.collapseSpaces().split(' ');
}
singString.method('lines', stringLines, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe056;',
    tests: function (ext) {
        ext.addTest('', [], []);
        ext.addTest('apple pie', [], ['apple pie']);
        ext.addTest('\r\napple pie\r\n', [], ['', 'apple pie', '']);
        ext.addTest('apple pie\r\napple pie', [], ['apple pie', 'apple pie']);
    }
});
function stringLines() {
    return this.split('\r\n');
}
singString.method('surround', stringSurround, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe065;',
    tests: function (ext) {
        ext.addTest('', [], '');
        ext.addTest('', [null], '');
        ext.addTest('', [undefined], '');
        ext.addTest('pie', ['---'], '---pie---');
    }
});
function stringSurround(str) {
    if (!str)
        return this;
    return str + this + str;
}
singString.method('truncate', stringTruncate, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe226;',
    tests: function (ext) {
        ext.addTest('abc', [], '');
        ext.addTest('abc', [null], '');
        ext.addTest('abc', [undefined], '');
        ext.addTest('abc', [NaN], '');
        ext.addTest('abc', [-1], '');
        ext.addTest('abc', [1], 'a');
        ext.addTest('abc', [3], 'abc');
        ext.addTest('abc', [5], 'abc');
    }
});
function stringTruncate(length) {
    if (this.length < 0 || isNaN(length))
        return '';
    var thisStr = this;
    if (length < 0)
        length = 0;
    if (thisStr.length > length)
        return thisStr.substr(0, length).toString();
    return thisStr;
}
singString.method('isValidEmail', stringIsValidEmail, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#x2709;',
    tests: function (ext) {
    }
});
function stringIsValidEmail() {
    var thisStr = this;
    return thisStr.hasMatch(/^([a-z0-9_\.-]+)@([\da-z\.-]+)\.([a-z\.]{2,6})$/);
}
singString.method('isHex', stringIsHex, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe180;',
    tests: function (ext) {
    }
});
function stringIsHex() {
    var thisStr = this;
    return thisStr.hasMatch(/^#?([a-f0-9]{6}|[a-f0-9]{3})$/);
}
singString.method('isValidURL', stringIsValidUrl, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe135;',
    tests: function (ext) {
    }
});
function stringIsValidUrl() {
    var thisStr = this;
    return thisStr.hasMatch(/^(https?:\/\/)?([\da-z\.-]+)\.([a-z\.]{2,6})([\/\w \.-]*)*\/?$/);
}
singString.method('isIPAddress', stringIsIpAddress, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe135;',
    tests: function (ext) {
    }
});
function stringIsIpAddress() {
    var thisStr = this;
    return thisStr.hasMatch(/^(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$/);
}
singString.method('isGuid', stringIsGuid, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe041;',
    tests: function (ext) {
    }
});
function stringIsGuid() {
    var thisStr = this;
    return thisStr.hasMatch(/^\{?[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}‌​\}?$/);
}
singString.method('tryToNumber', stringTryToNumber, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe141;',
    tests: function (ext) {
    }
});
function stringTryToNumber(defaultValue) {
    if (defaultValue === void 0) { defaultValue = this; }
    var retValue = defaultValue;
    if (true) {
        var str = this;
        if (str.length > 0) {
            if (!isNaN(str)) {
                retValue = parseInt(str);
            }
        }
    }
    return $.isNumber(retValue) ? retValue : null;
}
singString.method('joinLines', stringJoinLines, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe058;',
    tests: function (ext) {
    }
}, Array.prototype);
function stringJoinLines(asHTML) {
    if (asHTML === void 0) { asHTML = true; }
    return this.join(asHTML ? '<br/>' : '\r\n');
}
singString.method('pad', stringPad, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe051;',
    tests: function (ext) {
        ext.addTest('a', [5], 'a    ');
        ext.addTest('a', [5, 'left'], 'a    ');
        ext.addTest('a', [5, 'l'], 'a    ');
        ext.addTest('a', [5, 'right'], '    a');
        ext.addTest('a', [5, 'r'], '    a');
        ext.addTest('a', [5, 'left', '-'], 'a----');
        ext.addTest('a', [5, 'l', '-'], 'a----');
        ext.addTest('a', [5, 'wrong'], 'a');
    }
});
function stringPad(length, align, whitespace) {
    if (align === void 0) { align = Direction.left; }
    if (whitespace === void 0) { whitespace = ' '; }
    if (align != Direction.left && align != Direction.l &&
        align != Direction.right && align != Direction.r &&
        align != Direction.center && align != Direction.c) {
        return this;
    }
    var out = this;
    var whitespaceIndex = 0;
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
singString.method('toStr', booleanToStr, {
    summary: 'Converts the calling Boolean to string.',
    parameters: [
        {
            name: 'includeMarkup',
            types: [Boolean],
            description: 'Set includeMarkup to true to retrieve the actual string representaion of true and false.',
            defaultValue: false
        }
    ],
    returns: 'A String representation of the boolean value',
    returnType: String,
    examples: ['\
            If you specify a true value for includeMarkup, Booleans will be returned as \'true\' or \'false\' \r\n\
            Otherwise, \'Yes\' or \'No\' will be returned.'],
    glyphIcon: '&#xe241;',
    tests: function (ext) {
        ext.addTest(true, [], 'Yes');
        ext.addTest(true, [false], 'Yes');
        ext.addTest(true, [true], 'true');
        ext.addTest(false, [], 'No');
        ext.addTest(false, [false], 'No');
        ext.addTest(false, [true], 'false');
    }
}, Boolean.prototype, 'Boolean');
function booleanToStr(includeMarkup) {
    if (includeMarkup === void 0) { includeMarkup = false; }
    if (includeMarkup == false)
        return this.toYesNo();
    return this == false ? 'false' : 'true';
}
singString.method('toStr', objectToStr, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: '',
    examples: null,
    glyphIcon: '&#xe241;',
    tests: function (ext) {
        ext.addTest($, [null], '');
        ext.addTest($, [null, false], '');
        ext.addTest($, [null, true], 'null');
        ext.addTest($, [undefined], '');
        ext.addTest($, [undefined, false], '');
        ext.addTest($, [undefined, true], 'undefined');
        ext.addTest($, [[]], '');
        ext.addTest($, [[], false], '');
        ext.addTest($, [[], true], '[]');
        ext.addTest($, [[[]]], '');
        ext.addTest($, [[[]], false], '');
        ext.addTest($, [[[]], true], '[[]]');
        ext.addTest($, [[{}]], '');
        ext.addTest($, [[{}], false], '');
        ext.addTest($, [[{}], true], '[{}]');
        ext.addTest($, [{}], '');
        ext.addTest($, [{}, false], '');
        ext.addTest($, [{}, true], '{}');
        ext.addTest($, [NaN], '');
        ext.addTest($, [NaN, false], '');
        ext.addTest($, [NaN, true], 'NaN');
        ext.addTest($, [/$^/], '/$^/');
        ext.addTest($, [/$^/, false], '/$^/');
        ext.addTest($, [/$^/, true], '/$^/');
        ext.addTest($, [{ a: 'b', b: 5, c: false, d: [], e: { f: {} } }], 'a: b\r\nb: 5\r\nc: No\r\nd: \r\ne: f: \r\n\r\n');
        ext.addTest($, [{ a: 'b', b: 5, c: false, d: [], e: { f: {} } }, true], '{a: \'b\', b: 5, c: false, d: [], e: {f: {}}}');
        ext.addTest($, [['a']], 'a');
        ext.addTest($, [['a'], false], 'a');
        ext.addTest($, [['a'], true], '[\'a\']');
        ext.addTest($, [[true]], 'Yes');
        ext.addTest($, [[true], false], 'Yes');
        ext.addTest($, [[true], true], '[true]');
        ext.addTest($, [[false]], 'No');
        ext.addTest($, [[false], false], 'No');
        ext.addTest($, [[false], true], '[false]');
        ext.addTest($, [[5]], '5');
        ext.addTest($, [[5], false], '5');
        ext.addTest($, [[5], true], '[5]');
        ext.addTest($, [[false, false, false, false]], 'No\r\nNo\r\nNo\r\nNo');
        ext.addTest($, [[false, false, false, false], false], 'No\r\nNo\r\nNo\r\nNo');
        ext.addTest($, [[false, false, false, false], true], '[false, false, false, false]');
        ext.addTest($, [$], '$');
        ext.addTest($, [sing], 'sing');
    }
}, $, 'jQuery');
function objectToStr(obj, includeMarkup, stack) {
    if (includeMarkup === void 0) { includeMarkup = false; }
    if (stack === void 0) { stack = []; }
    if (obj === undefined)
        return includeMarkup ? 'undefined' : '';
    if (obj === null)
        return includeMarkup ? 'null' : '';
    if (obj === $)
        return '$';
    if (obj === sing)
        return 'sing';
    if (obj.toStr && obj.toStr != objectToStr)
        return obj.toStr(includeMarkup);
    if (typeof obj == 'object') {
        if (obj.toString && obj.toString !== ({}).toString)
            return obj.toString();
        if (stack.has(function (item) { return (item === obj); })) {
            return '';
        }
        stack = stack.clone();
        stack.push(obj);
        var out = includeMarkup ? '{' : '';
        var keyCount = Object.keys(obj).length;
        $.objEach(obj, function (key, item, index) {
            if (includeMarkup) {
                out += (key || '\'\'') + ": " + $.toStr(item, true, stack);
                if (index < keyCount - 1)
                    out += ', ';
            }
            else {
                out += key + ": " + $.toStr(item, false, stack) + "\r\n";
            }
        });
        out += includeMarkup ? '}' : '';
        return out;
    }
    return obj;
}
singString.method('toStr', arrayToStr, {
    summary: null,
    parameters: null,
    returns: null,
    returnType: String,
    examples: null,
    glyphIcon: '&#xe241;',
    tests: function (ext) {
    }
}, Array.prototype, 'Array');
function arrayToStr(includeMarkup) {
    var _this = this;
    if (includeMarkup === void 0) { includeMarkup = false; }
    var thisArray = this;
    var out = includeMarkup ? '[' : '';
    thisArray.each(function (item, i) {
        if (item === null)
            out += 'null';
        else if (item === undefined)
            out += 'undefined';
        else if (item.toStr)
            out += item.toStr(includeMarkup);
        else if (objectIsHash(item))
            out += objectToStr(item, includeMarkup);
        if (i < _this.length - 1)
            out += includeMarkup ? ', ' : '\r\n';
    });
    out += includeMarkup ? ']' : '';
    return out;
}
singString.method('toStr', stringToStr, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe241;',
    tests: function (ext) {
    }
});
function stringToStr(includeMarkup) {
    if (includeMarkup === void 0) { includeMarkup = false; }
    if (includeMarkup)
        return "'" + this.replaceAll('\r\n', '\\r\\n') + "'";
    return this;
}
singString.method('isString', isString, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: '',
    examples: null,
    glyphIcon: '&#xe241;',
    tests: function (ext) {
        ext.addTest($, [], false);
        ext.addTest($, [], false);
        ext.addTest($, [], false);
        ext.addTest($, [5], false);
        ext.addTest($, [''], true);
        ext.addTest($, ['a'], true);
    }
}, $);
function isString(str) {
    return typeof str == 'string';
}
singString.method('first', stringFirst, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe070;',
    tests: function (ext) {
    }
});
function stringFirst(count) {
    if (count <= 0)
        return '';
    if (count >= this.length)
        return this;
    return this.substr(0, count);
}
singString.method('last', stringLast, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe076;',
    tests: function (ext) {
    }
});
function stringLast(count) {
    if (count <= 0)
        return '';
    if (count >= this.length)
        return this;
    return this.substr(this.length - count, count);
}
singString.method('containsAny', stringContainsAny, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe003;',
    tests: function (ext) {
    }
});
function stringContainsAny() {
    var items = [];
    for (var _i = 0; _i < arguments.length; _i++) {
        items[_i - 0] = arguments[_i];
    }
    if (!items || items.length == 0)
        return false;
    return items.has(function (item) {
        return this.contains(item);
    });
}
singString.method('before', stringBefore, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe071;',
    tests: function (ext) {
    }
});
function stringBefore(search) {
    if (search == '')
        return this;
    var index = this.indexOf(search);
    if (index < 0)
        return this;
    return this.substr(0, index).before(search);
}
singString.method('after', stringAfter, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe075;',
    tests: function (ext) {
    }
});
function stringAfter(search) {
    if (search == '')
        return this;
    var index = this.indexOf(search);
    if (index < 0)
        return this;
    return this.substr(index + search.length).after(search);
}
singString.method('beforeLast', stringBeforeLast, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: null,
    tests: function (ext) {
    }
});
function stringBeforeLast(search) {
    if (search == '')
        return this;
    var index = this.indexOf(search);
    if (index < 0)
        return this;
    return this.substr(0, index);
}
singString.method('afterFirst', stringAfterFirst, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: null,
    tests: function (ext) {
    }
});
function stringAfterFirst(search) {
    if (search == '')
        return this;
    var index = this.indexOf(search);
    if (index < 0)
        return this;
    return this.substr(index + search.length);
}
singString.method('toSlug', stringToSlug, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe135;',
    tests: function (ext) {
    }
});
function stringToSlug() {
    var text = this || '';
    text = text.toLowerCase();
    text = text.replace(/\./g, '_');
    text = text.replace(/\s/g, '-');
    return text;
}
singString.method('containsAll', stringContainsAll, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe015;',
    tests: function (ext) {
    }
});
function stringContainsAll() {
    var items = [];
    for (var _i = 0; _i < arguments.length; _i++) {
        items[_i - 0] = arguments[_i];
    }
    if (items.length == 0)
        return false;
    var thisStr = this;
    for (var i = 0; i < items.length; i++) {
        if (!thisStr.contains(items[i]))
            return false;
    }
    return true;
}
singString.method('pluralize', stringPluralize, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe256;',
    tests: function (ext) {
    }
});
function stringPluralize(count) {
    var thisStr = this;
    if (count === undefined || count === null)
        return thisStr;
    if (count == 0 || count > 1)
        return thisStr + "s";
    return thisStr;
}
singString.method('isJSON', stringIsJson, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe105;',
    tests: function (ext) {
    }
});
function stringIsJson() {
    try {
        var thisStr = this;
        var jsonObject = jQuery.parseJSON(thisStr);
        return $.isDefined(jsonObject);
    }
    catch (e) {
        return false;
    }
}
singString.method('parseJSON', stringParseJson, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe105;',
    tests: function (ext) {
    }
});
function stringParseJson() {
    var thisStr = this;
    var jsonObject = jQuery.parseJSON(thisStr);
    return jsonObject;
}
singString.method('fill', stringFill, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe025;',
    tests: function (ext) {
    }
});
function stringFill(fillWith) {
    if (this.length == 0)
        return '';
    var thisStr = this;
    if (!fillWith || fillWith.length == 0)
        return this;
    var out = '';
    while (out.length < this.length) {
        out += fillWith;
    }
    if (out.length > thisStr.length)
        out = out.substr(0, thisStr.length);
    return out;
}
function test() {
    var bracketStart = '{';
    var bracketEnd = '}';
    var block = this;
    var startIndex;
    var currPos = startIndex;
    var openBrackets = 0;
    var stillSearching = true;
    var waitForChar = null;
    while (stillSearching && currPos <= block.length) {
        var currChar = block.charAt(currPos);
        if (!waitForChar) {
            switch (currChar) {
                case bracketStart:
                    openBrackets++;
                    break;
                case bracketEnd:
                    openBrackets--;
                    break;
                case '"':
                case "'":
                    waitForChar = currChar;
                    break;
                case '/':
                    var nextChar = block.charAt(currPos + 1);
                    if (nextChar === '/') {
                        waitForChar = '\n';
                    }
                    else if (nextChar === '*') {
                        waitForChar = '*/';
                    }
            }
        }
        else {
            if (currChar === waitForChar) {
                if (waitForChar === '"' || waitForChar === "'") {
                    block.charAt(currPos - 1) !== '\\' && (waitForChar = null);
                }
                else {
                    waitForChar = null;
                }
            }
            else if (currChar === '*') {
                block.charAt(currPos + 1) === '/' && (waitForChar = null);
            }
        }
        currPos++;
        if (openBrackets === 0) {
            stillSearching = false;
        }
    }
    return block.substring(startIndex, currPos);
}
var singHTML = singString.addModule(new sing.Module('HTML', String));
singHTML.glyphIcon = '&#xe022;';
singHTML.method('textToHTML', stringTextToHTML, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    }
});
function stringTextToHTML() {
    return this.replaceAll('\r\n', '\n')
        .replaceAll('\n', '<br/>')
        .replaceAll('  ', '&nbsp;&nbsp;');
}
singHTML.method('stripHTML', stringStripHTML, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    }
});
function stringStripHTML() {
    var out = this;
    var pattern = /.*\<(.+)\>.*/;
    out.replaceRegExp(pattern, / /);
    return out;
}
singHTML.method('getAttributes', getAttributes, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    tests: function (ext) {
    }
}, $.fn);
function getAttributes() {
    var thisJQuery = this;
    var attrs = [];
    thisJQuery.each(function () {
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
        return attrs.collect(function (item) { return item.collect(function (item2) { return ({
            name: item2.value.nodeName,
            value: item2.value.nodeValue
        }); }); });
    if (attrs.length == 1)
        return attrs[0].collect(function (item) { return ({
            name: item.value.nodeName,
            value: item.value.nodeValue
        }); });
    if (attrs.length == 0)
        return [];
}
function initHTMLExtensions() {
    initKeyBindClick();
    initRememberPage();
    initClickActions();
    initPropertyIf();
    initIdent();
    initHoverSrc();
    $('ul#menu a').each(function () {
        if (document.URL.indexOf($(this).attr('href')) > 0) {
            $('.active-page').removeClass('active-page');
            $(this).addClass('active-page');
        }
    });
    $("*[" + sing.constants.htmlAttr.FocusFirst + "]").each(function () {
        var target = $(this).attr(sing.constants.htmlAttr.FocusFirst);
        var targets = $(this).find(target);
        var emptyTargets = targets.select(function (t) { return ($(t).val() == ''); });
        if (emptyTargets && emptyTargets.length > 0)
            emptyTargets[0].focus();
        if (targets && targets.length > 0)
            targets[0].focus();
    });
    $("*[" + sing.constants.htmlAttr.Click.Animate + "]").each(function () {
        var element = $(this);
        var animation = element.attr(sing.constants.htmlAttr.Click.Animate);
        var duration = element.attr(sing.constants.htmlAttr.Click.AnimateDuration) || null;
        if (duration)
            duration = parseFloat(duration);
        var easing = element.attr(sing.constants.htmlAttr.Click.AnimateEasing) || null;
        var targetName = element.attr(sing.constants.htmlAttr.Click.AnimateTarget);
        var target = $('body').findIDNameSelector(targetName);
        if (!target || target.length == 0 || !target.animate)
            target = element;
        element.click(function () {
            var actionIf = element.actionIf(sing.constants.htmlAttr.Click.Animate);
            if (!actionIf)
                return;
            try {
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
        $(this).parent().superFadeOut();
    });
    if ($('#UpdateButton').length > 0) {
        $('.field-update-refresh-page').each(function () {
            $(this).find('input, select, textarea').each(function () {
                $(this).change(function () {
                    $(this).parents('.wide-form').find('.view-updating-shade').fadeIn();
                    $('#UpdateButton').click();
                });
            });
        });
    }
    $('.field-list-add-drag').each(function () {
        var listParent = $(this);
        $(this).find('.field-list-row').mousedown(function (e) {
            e.stopPropagation();
            listParent.find('.field-name').show();
            listParent.find('.field-token').hide();
            $(this).data('toggled', 'true');
            $(this).find('.field-name').hide();
            $(this).find('.field-token').show();
            $(this).find('.field-token input')[0].select();
        });
    });
    $('.field-list-add').each(function () {
        var targetAttr = $(this).attr('target');
        var position = $(this).attr('position') || 'cursor';
        var tokenBraces = !!($(this).attr('token-braces') == 'true');
        $(this).find('.field-list-row').mousedown(function (e) {
            e.stopPropagation();
            var fieldName = $(this).data('field-name');
            if (tokenBraces)
                fieldName = "[" + fieldName + "]";
            var target = null;
            if (targetAttr == 'focused') {
                target = $(document.activeElement);
            }
            else {
                target = $(targetAttr);
            }
            if (target.length > 0) {
                if (target[0].type == 'textarea') {
                    if (position == 'end') {
                        target.val(target.val() + "\r\n" + fieldName);
                    }
                    else if (position == 'beginning') {
                        target.val(fieldName + "\r\n" + target.val());
                    }
                    else if (position == 'cursor') {
                        insertAtCaret(target.attr('id'), fieldName);
                    }
                }
                else if (target[0].type == 'input') {
                    if (position == 'end') {
                        target.val(target.val() + fieldName);
                    }
                    else if (position == 'beginning') {
                        target.val(fieldName + target.val());
                    }
                    else if (position == 'cursor') {
                        insertAtCaret(target.attr('id'), fieldName);
                    }
                }
                else if (target[0].type == 'iframe') {
                    var value = wysihtml5Editor.getValue();
                    wysihtml5Editor.setValue(value + fieldName, true);
                }
            }
        });
    });
    $('.manage-view-show-similar').click(function () {
        var fieldName = $(this).data('field-name');
        var fieldValue = $(this).data('field-value');
        $('#GlobalSearchTerm').val(fieldName + ":" + fieldValue);
        $('.manage-global-search input[type=submit]').click();
    });
    try {
        $('select').sortable();
    }
    catch (ex) {
    }
}
var Identicon;
var jsSha;
function initIdent() {
    if (Identicon && jsSha) {
        var ident = $('ident');
        ident.each(function () {
            var thisJQuery = $(this);
            var hash = thisJQuery.html();
            var size = (thisJQuery.attr('size') || '').tryToNumber() || 36;
            var classes = (thisJQuery.attr('class') || '');
            var styles = (thisJQuery.attr('style') || '');
            var icon = new Identicon(hash, size);
            var salt = 'SingularitySalt';
            var shaObj = new jsSha(hash + salt, 'TEXT');
            var hash2 = shaObj.getHash('SHA-256', 'HEX', 1);
            var data = new Identicon(hash2, size);
            $(this).html("<img width=\"" + size + "\" height=\"" + size + "\" src=\"data:image/png;base64," + data + "\" class=\"" + classes + "\" style=\"" + styles + "\">");
        });
    }
}
function initHoverSrc() {
    var animated = $("img[" + sing.constants.htmlAttr.HoverSrc + "]");
    animated.each(function () {
        var thisElement = $(this);
        thisElement.on('mouseover', function () {
            thisElement.attr(thisElement.attr(sing.constants.htmlAttr.StaticSrc, thisElement.attr('src')));
            thisElement.attr('src', thisElement.attr(sing.constants.htmlAttr.HoverSrc));
        });
        thisElement.on('mouseout', function () {
            if (thisElement.hasAttr(thisElement.attr(sing.constants.htmlAttr.StaticSrc))) {
                thisElement.attr('src', thisElement.attr(thisElement.attr(sing.constants.htmlAttr.StaticSrc)));
                thisElement.removeAttr('static-src');
            }
        });
    });
}
function propertyIf(propertyName, changeTrue, changeFalse) {
    $("*[" + propertyName + "-if]").each(function () {
        var propertyTarget = $(this);
        var ifTargetName = propertyTarget.attr(propertyName + "-if");
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
                changeFunction();
            });
        }
    });
}
function initPropertyIf() {
    propertyIf('show', function (target) {
        target.show('fast');
    }, function (target) {
        target.hide('fast');
    });
    propertyIf('hide', function (target) {
        target.hide('fast');
    }, function (target) {
        target.show('fast');
    });
    propertyIf('enabled', function (target) {
        target.removeAttr('disabled');
    }, function (target) {
        target.attr('disabled', 'disabled');
    });
    propertyIf('disabled', function (target) {
        target.attr('disabled', 'disabled');
    }, function (target) {
        target.removeAttr('disabled');
    });
    propertyIf('readonly', function (target) {
        target.attr('readonly', 'readonly');
    }, function (target) {
        target.removeAttr('readonly');
    });
    propertyIf('selected', function (target) {
        target.attr('selected', 'selected');
    }, function (target) {
        target.removeAttr('selected');
    });
    propertyIf('checked', function (target) {
        target.attr('checked', 'checked');
    }, function (target) {
        target.removeAttr('checked');
    });
}
function initClickActions() {
    $("*[" + sing.constants.htmlAttr.Click.Show + "]").each(function () {
        var target = $(this).attr(sing.constants.htmlAttr.Click.Show);
        $(this).click(function () {
            var actionIf = $(this).actionIf(sing.constants.htmlAttr.Click.Show);
            if (!actionIf)
                return;
            $('body').findIDNameSelector(target).show('fast');
        });
    });
    $("*[" + sing.constants.htmlAttr.Click.Hide + "]").each(function () {
        var target = $(this).attr(sing.constants.htmlAttr.Click.Hide);
        $(this).click(function () {
            var actionIf = $(this).actionIf(sing.constants.htmlAttr.Click.Hide);
            if (!actionIf)
                return;
            $('body').findIDNameSelector(target).hide('fast');
        });
    });
    $("*[" + sing.constants.htmlAttr.Click.Toggle + "]").each(function () {
        var target = $(this).attr(sing.constants.htmlAttr.Click.Toggle);
        $(this).click(function () {
            var actionIf = $(this).actionIf(sing.constants.htmlAttr.Click.Toggle);
            if (!actionIf)
                return;
            $('body').findIDNameSelector(target).toggle('fast');
        });
    });
    $("*[" + sing.constants.htmlAttr.Click.FadeIn + "]").each(function () {
        var target = $(this).attr(sing.constants.htmlAttr.Click.FadeIn);
        $(this).click(function () {
            var actionIf = $(this).actionIf(sing.constants.htmlAttr.Click.FadeIn);
            if (!actionIf)
                return;
            $('body').findIDNameSelector(target).fadeIn('fast');
        });
    });
    $("*[" + sing.constants.htmlAttr.Click.FadeOut + "]").each(function () {
        var target = $(this).attr(sing.constants.htmlAttr.Click.FadeOut);
        $(this).click(function () {
            var actionIf = $(this).actionIf(sing.constants.htmlAttr.Click.FadeOut);
            if (!actionIf)
                return;
            $('body').findIDNameSelector(target).fadeOut('fast');
        });
    });
    $("*[" + sing.constants.htmlAttr.Click.FadeToggle + "]").each(function () {
        var target = $(this).attr(sing.constants.htmlAttr.Click.FadeToggle);
        target = $('body').findIDNameSelector(target);
        $(this).click(function () {
            var actionIf = $(this).actionIf(sing.constants.htmlAttr.Click.FadeToggle);
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
    $("*[" + sing.constants.htmlAttr.Click.ToggleClass + "]").each(function () {
        var element = $(this);
        var className = element.attr(sing.constants.htmlAttr.Click.ToggleClass);
        var targetName = element.attr(sing.constants.htmlAttr.Click.ToggleClassTarget);
        var target = $('body').findIDNameSelector(targetName);
        if (target && target.length == 0)
            target = element;
        element.click(function () {
            var actionIf = element.actionIf(sing.constants.htmlAttr.Click.ToggleClass);
            if (!actionIf)
                return;
            target.toggleClass(className);
        });
    });
    $("*[" + sing.constants.htmlAttr.Click.AddClass + "]").each(function () {
        var element = $(this);
        var className = element.attr(sing.constants.htmlAttr.Click.AddClass);
        var targetName = element.attr(sing.constants.htmlAttr.Click.AddClassTarget);
        var target = $('body').findIDNameSelector(targetName);
        if (!target || target.length == 0)
            target = element;
        element.click(function () {
            var actionIf = element.actionIf(sing.constants.htmlAttr.Click.AddClass);
            if (!actionIf)
                return;
            target.addClass(className);
        });
    });
    $("*[" + sing.constants.htmlAttr.Click.RemoveClass + "]").each(function () {
        var element = $(this);
        var className = element.attr(sing.constants.htmlAttr.Click.RemoveClass);
        var targetName = element.attr(sing.constants.htmlAttr.Click.RemoveClassTarget);
        var target = $('body').findIDNameSelector(targetName);
        if (!target || target.length == 0)
            target = element;
        element.click(function () {
            var actionIf = element.actionIf(sing.constants.htmlAttr.Click.RemoveClassTarget);
            if (!actionIf)
                return;
            target.removeClass(className);
        });
    });
}
function initRememberPage() {
    $("*[" + sing.constants.htmlAttr.GoToRememberPage + "]").each(function () {
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
    $("*[" + sing.constants.htmlAttr.EnableRememberPage + "]").each(function () {
        $.cookie('enable-remember-page', true, { expires: 7, path: '/' });
    });
    $("*[" + sing.constants.htmlAttr.RememberPage + "]").each(function () {
        $.cookie('enable-remember-page', false, { expires: 7, path: '/' });
        $.cookie('remember-page', document.URL, { expires: 7, path: '/' });
    });
}
var keyCodeToChar = {
    8: 'Backspace', 9: 'Tab', 13: 'Enter', 16: 'Shift', 17: 'Ctrl', 18: 'Alt', 19: 'Pause/Break',
    20: 'Caps Lock', 27: 'Esc', 32: 'Space', 33: 'Page Up', 34: 'Page Down', 35: 'End', 36: 'Home',
    37: 'Left', 38: 'Up', 39: 'Right', 40: 'Down', 45: 'Insert', 46: 'Delete', 48: '0', 49: '1',
    50: '2', 51: '3', 52: '4', 53: '5', 54: '6', 55: '7', 56: '8', 57: '9', 65: 'A', 66: 'B', 67: 'C',
    68: 'D', 69: 'E', 70: 'F', 71: 'G', 72: 'H', 73: 'I', 74: 'J', 75: 'K', 76: 'L', 77: 'M', 78: 'N',
    79: 'O', 80: 'P', 81: 'Q', 82: 'R', 83: 'S', 84: 'T', 85: 'U', 86: 'V', 87: 'W', 88: 'X', 89: 'Y',
    90: 'Z', 91: 'Windows', 93: 'Right Click', 96: 'Numpad 0', 97: 'Numpad 1', 98: 'Numpad 2', 99: 'Numpad 3',
    100: 'Numpad 4', 101: 'Numpad 5', 102: 'Numpad 6', 103: 'Numpad 7', 104: 'Numpad 8', 105: 'Numpad 9',
    106: 'Numpad *', 107: 'Numpad +', 109: 'Numpad -', 110: 'Numpad .', 111: 'Numpad /', 112: 'F1', 113: 'F2',
    114: 'F3', 115: 'F4', 116: 'F5', 117: 'F6', 118: 'F7', 119: 'F8', 120: 'F9', 121: 'F10', 122: 'F11',
    123: 'F12', 144: 'Num Lock', 145: 'Scroll Lock', 182: 'My Computer', 183: 'My Calculator', 186: ';',
    187: '=', 188: ',', 189: '-', 190: '.', 191: '/', 192: '`', 219: '[', 220: '\\', 221: ']', 222: "'"
};
var keyCharToCode = {
    "Backspace": 8, "Tab": 9, "Enter": 13, "Shift": 16, "Ctrl": 17, "Alt": 18, "Pause/Break": 19, "Caps Lock": 20,
    "Esc": 27, "Space": 32, "Page Up": 33, "Page Down": 34, "End": 35, "Home": 36, "Left": 37, "Up": 38,
    "Right": 39, "Down": 40, "Insert": 45, "Delete": 46, "0": 48, "1": 49, "2": 50, "3": 51, "4": 52, "5": 53,
    "6": 54, "7": 55, "8": 56, "9": 57, "A": 65, "B": 66, "C": 67, "D": 68, "E": 69, "F": 70, "G": 71, "H": 72,
    "I": 73, "J": 74, "K": 75, "L": 76, "M": 77, "N": 78, "O": 79, "P": 80, "Q": 81, "R": 82, "S": 83, "T": 84,
    "U": 85, "V": 86, "W": 87, "X": 88, "Y": 89, "Z": 90, "Windows": 91, "Right Click": 93, "Numpad 0": 96,
    "Numpad 1": 97, "Numpad 2": 98, "Numpad 3": 99, "Numpad 4": 100, "Numpad 5": 101, "Numpad 6": 102, "Numpad 7": 103,
    "Numpad 8": 104, "Numpad 9": 105, "Numpad *": 106, "Numpad +": 107, "Numpad -": 109, "Numpad .": 110, "Numpad /": 111,
    "F1": 112, "F2": 113, "F3": 114, "F4": 115, "F5": 116, "F6": 117, "F7": 118, "F8": 119, "F9": 120, "F10": 121,
    "F11": 122, "F12": 123, "Num Lock": 144, "Scroll Lock": 145, "My Computer": 182, "My Calculator": 183, ";": 186,
    "=": 187, ",": 188, "-": 189, ".": 190, "/": 191, "`": 192, "[": 219, "\\": 220, "]": 221, "'": 222
};
var wysihtml5Editor;
function initKeyBindClick() {
    var down = [];
    $("*[" + sing.constants.htmlAttr.Click.CtrlHref + "]").click(function (e) {
        if (down[keyCharToCode['Ctrl']]) {
            location.href = $(this).attr(sing.constants.htmlAttr.Click.CtrlHref);
            e.preventDefault();
        }
    });
    $("*[" + sing.constants.htmlAttr.Click.ShiftHref + "]").click(function (e) {
        if (down[keyCharToCode['Shift']]) {
            location.href = $(this).attr(sing.constants.htmlAttr.Click.ShiftHref);
            e.preventDefault();
        }
    });
    $("*[" + sing.constants.htmlAttr.Click.AltHref + "]").click(function (e) {
        if (down[keyCharToCode['Alt']]) {
            location.href = $(this).attr(sing.constants.htmlAttr.Click.AltHref);
            e.preventDefault();
        }
    });
    $("*[" + sing.constants.htmlAttr.Click.DoubleHref + "]").on('dblclick', function (e) {
        if (down[keyCharToCode['Alt']]) {
            location.href = $(this).attr(sing.constants.htmlAttr.Click.DoubleHref);
            e.preventDefault();
        }
    });
    $(document).keydown(function (e) {
        down[e.keyCode] = true;
        $("*[" + sing.constants.htmlAttr.Click.KeyBindClick + "]").each(function () {
            var keyCode = $(this).attr(sing.constants.htmlAttr.Click.KeyBindClick);
            var key1;
            var key2;
            if (keyCode.indexOf('+') > 0 && keyCode.indexOf('+') < keyCode.length - 1) {
                key1 = parseInt(keyCode.substr(0, keyCode.indexOf('+')));
                key2 = parseInt(keyCode.substr(keyCode.indexOf('+') + 1));
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
                key1 = keyCode.tryToNumber(null);
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
    var keyBindTip = '';
    $("*[" + sing.constants.htmlAttr.Click.KeyBindClick + "]").each(function () {
        var keyCode = $(this).attr(sing.constants.htmlAttr.Click.KeyBindClick);
        var commandName = $(this).attr(sing.constants.htmlAttr.Click.KeyBindClickName);
        var href = $(this).attr('href');
        var id = $(this).attr('id');
        if (!commandName)
            return;
        var key1;
        if (keyCode.indexOf('+') > 0 && keyCode.indexOf('+') < keyCode.length - 1) {
            console.log(keyCode);
            key1 = stringTryToNumber(keyCode.substr(0, keyCode.indexOf('+')));
            var key2 = stringTryToNumber(keyCode.substr(keyCode.indexOf('+') + 1));
            if (!key1)
                key1 = keyCharToCode[keyCode.substr(0, keyCode.indexOf('+'))];
            if (!key2)
                key2 = keyCharToCode[keyCode.substr(keyCode.indexOf('+') + 1)];
            if (href)
                commandName = "<a style='cursor: pointer;' onclick='location.href = \"" + href + "\";'>" + commandName + "</a>";
            else if (id)
                commandName = "<a style='cursor: pointer;' onclick='$(\"#" + id + "\").click();'>" + commandName + "</a>";
            keyBindTip += "<b>" + keyCode.substr(0, keyCode.indexOf('+')) + "+" + keyCode.substr(keyCode.indexOf('+') + 1) + "</b> - " + commandName;
            keyBindTip += '<br>';
        }
        else {
            key1 = stringTryToNumber(keyCode);
            if (!key1)
                key1 = keyCharToCode[keyCode];
            if (href)
                commandName = "<a style='cursor: pointer;' onclick='location.href = \"" + href + "\";'>" + commandName + "</a>";
            else if (id)
                commandName = "<a style='cursor: pointer;' onclick='$(\"#" + id + "\").click();'>" + commandName + "</a>";
            keyBindTip += "<b>" + keyCode + "</b> - " + commandName;
            keyBindTip += '<br>';
        }
    });
    if (keyBindTip)
        $('#key-bind-page-tip').html(keyBindTip);
    else
        $('#key-bind-page-tip').parent().hide();
}
function initFields() {
    $('.tab-container *[href]').each(function () {
        var href = $(this).attr('href');
        if (href.indexOf('#') < 0) {
            $(this).attr('href', href + "#" + $(this).parent('.ui-tabs-panel').attr('id'));
        }
    });
    $('#randomize-fields').click(function () {
        randomFields();
    });
    try {
        $('.datepicker').datepicker();
    }
    catch (ex) {
    }
    try {
        $('.select-list').selectmenu();
    }
    catch (ex) {
    }
    try {
        $('.tab-container').tabs();
    }
    catch (ex) {
    }
    try {
        $('.spinner-money').spinner({
            min: 0,
            max: 1000000,
            step: 1,
            numberFormat: 'C'
        });
    }
    catch (ex) {
    }
    $('img[error-src]').error(function () {
        $(this).attr('src', $(this).attr(sing.constants.htmlAttr.ErrorSrc));
    });
    try {
        $('.int-range').each(function () {
            var val = parseInt($(this).attr('value'));
            var minimum = parseInt($(this).attr('minimum'));
            var maximum = parseInt($(this).attr('maximum'));
            if (val <= minimum || isNaN(val))
                val = minimum;
            if (val >= maximum)
                val = maximum;
            if (val && !isNaN(val)) {
                $("#" + $(this).attr('target')).val(val.toString());
                $("#" + $(this).attr('text-target')).html(val.toString());
                ;
            }
        });
    }
    catch (ex) {
    }
    try {
        $('.spinner-decimal').spinner({
            step: 0.01,
            numberFormat: 'n'
        });
    }
    catch (ex) {
    }
}
function randomFields() {
    $('.field[data-type-name]').each(function () {
        var objectType = $(this).attr('data-object-type');
        var dataTypeName = $(this).attr('data-type-name');
        var maximum = parseFloat($(this).attr('maximum'));
        var minimum = parseFloat($(this).attr('minimum'));
        var object = null;
        var chance = new Chance(Math.random);
        if (dataTypeName == 'MultilineText') {
            object = chance.paragraph({ sentences: 6 });
            $(this).find('textarea').val(object);
            return;
        }
        else if (objectType == 'System.String') {
            object = chance.string();
        }
        if (objectType == 'System.Nullable`1[System.Int32]' ||
            objectType == 'System.Int32') {
            if (maximum && minimum) {
                object = chance.integer({ min: minimum, max: maximum });
                $(this).find('.int-range').slider('value', object);
                return;
            }
            else
                object = chance.integer();
        }
        if (objectType == 'System.Nullable`1[System.Guid]' ||
            objectType == 'System.Guid') {
            object = chance.guid();
        }
        if (objectType == 'System.Nullable`1[System.DateTime]' ||
            objectType == 'System.DateTime') {
            if (dataTypeName == 'Date') {
                object = chance.date({ string: true });
            }
            else if (dataTypeName == 'Time') {
                object = chance.hour({ twentyfour: true }) + ":" + chance.minute() + ":" + chance.second();
            }
            else if (dataTypeName == 'DateTime') {
                object = chance.date({ string: true }) + " " + chance.hour({ twentyfour: true }) + ":" + chance.minute() + ":" + chance.second();
            }
        }
        if (dataTypeName == 'PhoneNumber') {
            object = chance.phone();
        }
        if (dataTypeName == 'EmailAddress') {
            object = chance.email();
        }
        if (dataTypeName == 'CreditCard') {
            object = chance.cc();
        }
        if (dataTypeName == 'PostalCode') {
            object = chance.postal();
        }
        if (dataTypeName == 'ImageUrl') {
            object = "https://placekitten.com/g/" + chance.integer({ min: 200, max: 500 }) + "/" + chance.integer({ min: 200, max: 500 });
        }
        if (dataTypeName == 'Url') {
            object = chance.domain();
        }
        if (objectType == 'System.Nullable`1[System.TimeSpan]' ||
            objectType == 'System.TimeSpan') {
        }
        if (objectType == 'System.Nullable`1[System.Boolean]' ||
            objectType == 'System.Boolean') {
            $(this).find('input[type=radio]').each(function () {
                if (chance.bool()) {
                    $(this).click();
                }
            });
        }
        if (objectType == 'System.Nullable`1[System.Single]' ||
            objectType == 'System.Single') {
        }
        var max;
        var selection;
        if ($(this).find('select option').length > 0) {
            max = $(this).find('select option').length;
            selection = chance.integer({ min: 0, max: max - 1 });
            $(this).find('option')[selection].click();
        }
        if ($(this).find('ui-menu ui-menu-item').length > 0) {
            max = $(this).find('ui-menu ui-menu-item').length;
            selection = chance.integer({ min: 0, max: max - 1 });
            $(this).find('ui-menu ui-menu-item')[selection].click();
        }
        if (object) {
            $(this).find('input').val(object).change();
        }
    });
}
function objectToHtml(obj, parentKey, context) {
    if (parentKey === void 0) { parentKey = null; }
    if (context === void 0) { context = null; }
    if (!obj)
        return '';
    var out = '';
    if (parentKey) {
        var parentElement = parentKey.before('.').before('#');
        var parentClasses = parentKey.afterFirst('.');
        var parentID = parentKey.after('#');
    }
    if ($.isFunction(obj)) {
        out += obj(context);
    }
    else if ($.isString(obj)) {
    }
    else if ($.isArray(obj)) {
    }
    else if ($.isHash(obj)) {
        var objKeys = $.objKeys(obj);
        for (var key in objKeys) {
            if (objKeys.hasOwnProperty(key)) {
                var objValue = obj[key];
                if ($.isNumber(key)) {
                }
                else if ($.isString(key)) {
                    if (key.startsWith('_')) {
                    }
                }
            }
        }
    }
    if (parentKey) {
    }
    return out;
}
function htmlToObject(html) {
    if (!html || html.trim().length == 0)
        return '';
}
var testStructure = {
    html: {
        head: {
            title: ''
        },
        body: {
            '_example-attr': 'value',
            '_example-attr2': function () { return 'evaluate'; },
            'span': {
                _class: 'example1'
            },
            'span.example1': {},
            'div': {
                _classes: ['class1', 'class2']
            },
            'div.class1.class2': {},
            'div.example2': {
                _id: 'example2'
            },
            'div.example2#example2': {},
            'div#example3': {
                _content: {}
            },
            'div#example4': {
                0: {},
                1: [],
                2: '',
                3: function () { return ''; }
            },
            'div#example5': 'content',
            'div#example6': function () {
                return 'content';
            },
            'div#example7': function () {
                return { 'ul': { 'li': ['1', '2', '3'] } };
            },
            'div#example9': [
                'content1',
                'content2'
            ],
            'div.all-class#example10': [
                'content1',
                'content2'
            ],
            'div.all-class#example11': [
                'content1',
                function () { return 'content2'; },
                {
                    _class: 'special',
                    _content: 'content3'
                }
            ],
            'ul#example12': {
                'li': [
                    {
                        _class: 'example',
                        _content: '1'
                    },
                    {
                        _class: 'example',
                        _content: '2'
                    }
                ]
            },
            'ul.example13': {
                'li.example': [
                    {
                        _class: 'active',
                        _content: '1'
                    },
                    {
                        _content: '2'
                    }
                ]
            },
            'div#example14': {
                _content: function (c) {
                    return (c && c.name) ? c.name : '';
                }
            },
            'div#example15': function (c) {
                if (c.items) {
                    return c.items.collect(function (item) { return ({
                        span: {
                            _value: item.value
                        }
                    }); });
                }
            }
        }
    }
};
var singJQuery = singExt.addModule(new sing.Module('jQuery', [$, $.fn], $));
singJQuery.glyphIcon = '&#xe148;';
singJQuery.ignoreUnknown('ALL');
singJQuery.method('checked', checked, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: '',
    examples: null,
    glyphIcon: '&#xe013;',
    tests: function (ext) {
    }
}, $.fn);
function checked() {
    var anyChecked = false;
    this.each(function () {
        var thisJQuery = $(this);
        if (thisJQuery && thisJQuery[0] && thisJQuery[0].checked['checked'])
            anyChecked = true;
    });
    return anyChecked;
}
singJQuery.method('allVisible', allVisible, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: '',
    examples: null,
    glyphIcon: '&#xe105;',
    tests: function (ext) {
    }
}, $.fn);
function allVisible() {
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
singJQuery.method('findIDNameSelector', findIDNameSelector, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: '',
    examples: null,
    glyphIcon: '&#xe003;',
    tests: function (ext) {
    }
}, $.fn);
function findIDNameSelector(name) {
    var target = $();
    try {
        target = $(this).find("#" + name);
    }
    catch (ex) { }
    if (target.length == 0)
        try {
            target = $(this).find("[name=" + name + "]");
        }
        catch (ex) { }
    if (target.length == 0)
        try {
            target = $(this).find(name);
        }
        catch (ex) { }
    return target || $();
}
singJQuery.method('actionIf', actionIf, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: '',
    examples: null,
    glyphIcon: '&#xe162;',
    tests: function (ext) {
    }
}, $.fn);
function actionIf(name) {
    var target = $(this);
    var ifTargetName = target.attr(name + "-if");
    if (!ifTargetName)
        return true;
    var ifTarget = $('body').findIDNameSelector(ifTargetName);
    var targetValue = (target.attr(name + "-if-value") || '');
    var operation = function (a, b) { return (a == b); };
    if (targetValue.indexOf('!=') == 0) {
        operation = function (a, b) { return (a != b); };
        targetValue = targetValue.substr(2);
    }
    else if (targetValue.indexOf('>=') == 0) {
        operation = function (a, b) { return (parseFloat(a) >= parseFloat(b)); };
        targetValue = parseFloat(targetValue.substr(2));
    }
    else if (targetValue.indexOf('<=') == 0) {
        operation = function (a, b) { return (parseFloat(a) <= parseFloat(b)); };
        targetValue = parseFloat(targetValue.substr(2));
    }
    else if (targetValue.indexOf('><') == 0) {
        operation = function (a, b) { return (parseFloat(a) >= parseFloat(b[0]) && parseFloat(a) <= parseFloat(b[1])); };
        targetValue = targetValue.substr(2);
        targetValue = [
            targetValue.split(',')[0],
            targetValue.split(',')[1]
        ];
    }
    else if (targetValue.indexOf('<>') == 0) {
        operation = function (a, b) { return (parseFloat(a) <= parseFloat(b[0]) || parseFloat(a) >= parseFloat(b[1])); };
        targetValue = targetValue.substr(2);
        targetValue = [
            targetValue.split(',')[0],
            targetValue.split(',')[1]
        ];
    }
    else if (targetValue.indexOf(',') > 0) {
        operation = function (a, b) { return (b.indexOf(a) >= 0); };
        targetValue = targetValue.split(',');
    }
    else if (targetValue.indexOf('!') == 0) {
        operation = function (a, b) { return (parseFloat(a) != parseFloat(b)); };
        targetValue = targetValue.substr(1);
    }
    else if (targetValue.indexOf('<') == 0) {
        operation = function (a, b) { return (parseFloat(a) < parseFloat(b)); };
        targetValue = parseFloat(targetValue.substr(1));
    }
    else if (targetValue.indexOf('>') == 0) {
        operation = function (a, b) { return (parseFloat(a) > parseFloat(b)); };
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
            if (ifTarget.attr('type') == 'radio')
                return operation(ifTarget.filter(':checked').val(), targetValue);
            return operation(val, targetValue);
        }
    }
}
;
singJQuery.method('defer', defer, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    aliases: ['wait'],
    examples: null,
    glyphIcon: '&#xe095;',
    tests: function (ext) {
    }
});
function defer(deferFunc) {
    if (deferFunc)
        setTimeout(deferFunc, 0);
}
singJQuery.method('hasAttr', jQueryHasAttr, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    glyphIcon: '&#xe042;',
    tests: function (ext) {
    }
}, $.fn);
function jQueryHasAttr(name) {
    return $(this).attr(name) !== undefined;
}
singJQuery.method('outerHtml', jQueryOuterHtml, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    glyphIcon: '&#xe140;',
    tests: function (ext) {
    }
}, $.fn);
function jQueryOuterHtml() {
    if (this.length == 0) {
        return '';
    }
    else {
        return this[0].outerHTML;
    }
}
singJQuery.method('innerHtml', jQueryInnerHtml, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    glyphIcon: '&#xe087;',
    tests: function (ext) {
    }
}, $.fn);
function jQueryInnerHtml() {
    if (this.length == 0) {
        return '';
    }
    else {
        return this[0].innerHTML;
    }
}
singJQuery.method('isOnScreen', jQueryIsOnScreen, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    glyphIcon: '&#xe106;',
    tests: function (ext) {
    }
}, $.fn);
function jQueryIsOnScreen(x, y) {
    if (x === void 0) { x = 1; }
    if (y === void 0) { y = 1; }
    var win = $(window);
    var viewport = {
        top: win.scrollTop(),
        left: win.scrollLeft(),
        right: 0,
        bottom: 0
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
    var visible = (!(viewport.right < bounds.left ||
        viewport.left > bounds.right ||
        viewport.bottom < bounds.top ||
        viewport.top > bounds.bottom));
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
singJQuery.method('swapClasses', jQuerySwapClass, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    glyphIcon: '&#xe110;',
    tests: function (ext) {
    }
}, $.fn);
function jQuerySwapClass(class1, class2) {
    var thisJQuery = this;
    if (true) {
        if (thisJQuery.hasClass(class1)) {
            thisJQuery.removeClass(class1);
            thisJQuery.addClass(class2);
        }
        else if (thisJQuery.hasClass(class2)) {
            thisJQuery.removeClass(class2);
            thisJQuery.addClass(class1);
        }
        else {
            thisJQuery.addClass(class1);
        }
    }
    return thisJQuery;
}
;
singJQuery.method('fadeClasses', jQueryFadeClass, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    glyphIcon: '',
    tests: function (ext) {
    }
}, $.fn);
function jQueryFadeClass(class1, class2, speed, callback) {
    if (speed === void 0) { speed = 'fast'; }
    var thisJQuery = this;
    if (true) {
        if (thisJQuery.hasClass(class1)) {
            thisJQuery.fadeOut(speed, function () {
                thisJQuery.removeClass(class1);
                thisJQuery.addClass(class2);
                thisJQuery.fadeIn(speed, function () {
                    if (callback)
                        callback();
                });
            });
        }
        else if (thisJQuery.hasClass(class2)) {
            thisJQuery.fadeOut(speed, function () {
                thisJQuery.removeClass(class2);
                thisJQuery.addClass(class1);
                thisJQuery.fadeIn(speed, function () {
                    if (callback)
                        callback();
                });
            });
        }
        else {
            thisJQuery.fadeOut(speed, function () {
                thisJQuery.addClass(class1);
                thisJQuery.fadeIn(speed, function () {
                    if (callback)
                        callback();
                });
            });
        }
    }
    return thisJQuery;
}
;
singJQuery.method('superFadeOut', jQuerySuperFadeOut, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    glyphIcon: '',
    tests: function (ext) {
    }
}, $.fn);
function jQuerySuperFadeOut(speed) {
    if (speed === void 0) { speed = 'fast'; }
    var thisJQuery = this;
    thisJQuery.each(function () {
        var jElement = $(this);
        jElement.data('old-opacity', jElement.css('opacity'));
        jElement.data('old-height', jElement.css('height'));
        jElement.data('old-margin-top', jElement.css('margin-top'));
        jElement.data('old-margin-bottom', jElement.css('margin-bottom'));
        jElement.data('old-margin-left', jElement.css('margin-left'));
        jElement.data('old-margin-right', jElement.css('margin-right'));
        jElement.data('old-padding-top', jElement.css('padding-top'));
        jElement.data('old-padding-bottom', jElement.css('padding-bottom'));
        jElement.data('old-padding-left', jElement.css('padding-left'));
        jElement.data('old-padding-right', jElement.css('padding-right'));
        jElement.animate({
            opacity: 0,
            height: 0,
            padding: 0,
            margin: 0
        }, speed);
    });
    return thisJQuery;
}
;
singJQuery.method('superFadeIn', jQuerySuperFadeIn, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    glyphIcon: '',
    tests: function (ext) {
    }
}, $.fn);
function jQuerySuperFadeIn(speed) {
    if (speed === void 0) { speed = 'fast'; }
    var thisJQuery = this;
    thisJQuery.each(function () {
        var jElement = $(this);
        var opacity = jElement.data('old-opacity');
        opacity = (opacity == '') ? jElement.css('opacity') : opacity;
        var height = jElement.data('old-height');
        height = (height == '') ? 'auto' : height;
        var marginTop = jElement.data('old-margin-top');
        marginTop = (marginTop == '') ? jElement.css('margin-top') : marginTop;
        var marginBottom = jElement.data('old-margin-bottom');
        marginBottom = (marginBottom == '') ? jElement.css('margin-bottom') : marginBottom;
        var marginLeft = jElement.data('old-margin-left');
        marginLeft = (marginLeft == '') ? jElement.css('margin-left') : marginLeft;
        var marginRight = jElement.data('old-margin-right');
        marginRight = (marginRight == '') ? jElement.css('margin-right') : marginRight;
        var paddingTop = jElement.data('old-padding-top');
        paddingTop = (paddingTop == '') ? jElement.css('padding-top') : paddingTop;
        var paddingBottom = jElement.data('old-padding-bottom');
        paddingBottom = (paddingBottom == '') ? jElement.css('padding-bottom') : paddingBottom;
        var paddingLeft = jElement.data('old-padding-left');
        paddingLeft = (paddingLeft == '') ? jElement.css('padding-left') : paddingLeft;
        var paddingRight = jElement.data('old-padding-right');
        paddingRight = (paddingRight == '') ? jElement.css('padding-right') : paddingRight;
        jElement.data('old-opacity', '');
        jElement.data('old-height', '');
        jElement.data('old-margin-top', '');
        jElement.data('old-margin-bottom', '');
        jElement.data('old-margin-left', '');
        jElement.data('old-margin-right', '');
        jElement.data('old-padding-top', '');
        jElement.data('old-padding-bottom', '');
        jElement.data('old-padding-left', '');
        jElement.data('old-padding-right', '');
        jElement.animate({
            opacity: opacity,
            height: height,
            'padding-top': paddingTop,
            'padding-bottom': paddingBottom,
            'padding-left': paddingLeft,
            'padding-right': paddingRight,
            'margin-top': marginTop,
            'margin-bottom': marginBottom,
            'margin-left': marginLeft,
            'margin-right': marginRight
        }, speed, function () {
            jElement.css('height', '');
            jElement.css('padding-top', '');
            jElement.css('padding-bottom', '');
            jElement.css('padding-left', '');
            jElement.css('padding-right', '');
            jElement.css('margin-top', '');
            jElement.css('margin-bottom', '');
            jElement.css('margin-left', '');
            jElement.css('margin-right', '');
        });
    });
    return thisJQuery;
}
;
var singTemplates = singCore.addModule(new sing.Module('Templates', String));
singTemplates.glyphIcon = '&#xe224;';
singTemplates.method('templateInject', stringTemplateInject, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    }
});
function stringTemplateInject(obj, _context) {
    var out = this.toString();
    var matches = out.match(sing.constants.TemplatePatternRegExp) || [];
    while (matches.length > 0) {
        var key = matches[1];
        if (key.contains(' with ')) {
            out = out.replace(sing.constants.TemplatePatternStart + key + sing.constants.TemplatePatternEnd, "<<" + key + ">>");
            matches = out.match(sing.constants.TemplatePatternRegExp) || [];
            continue;
        }
        var value = void 0;
        value = null;
        value = sing.resolve(key, obj, _context);
        if (!$.isDefined(value))
            value = '';
        var valueTemplate = sing.getTemplateName(value);
        if (valueTemplate != null) {
            var valueTemplateHtml = $.getTemplate(valueTemplate);
            if (valueTemplateHtml) {
                var valueTemplateStr = valueTemplateHtml.outerHtml().templateInject(value, _context);
                return valueTemplateStr;
            }
        }
        if (value != null) {
            out = out.replace(sing.constants.TemplatePatternStart + key + sing.constants.TemplatePatternEnd, value.toString());
        }
        else {
            out = out.replace(sing.constants.TemplatePatternStart + key + sing.constants.TemplatePatternEnd, '');
        }
        matches = out.match(sing.constants.TemplatePatternRegExp) || [];
    }
    return out;
}
singTemplates.method('templateExtract', stringTemplateExtract, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    }
});
function stringTemplateExtract(template) {
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
singTemplates.method('getTemplate', objectGetTemplate, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    tests: function (ext) {
    }
}, $);
function objectGetTemplate(name, data) {
    var template = sing.templates[name];
    if (!template || template.length == 0)
        return null;
    template = $(template);
    if ($.isDefined(data)) {
        try {
            return template.attr(sing.constants.htmlAttr.Templates.TemplateData, 'true').fillTemplate(data);
        }
        catch (ex) {
            return $("<error>" + ex + "</error>");
        }
    }
    return template;
}
singTemplates.method('getTemplateFor', objectGetTemplateFor, {}, sing);
function objectGetTemplateFor() {
}
singTemplates.method('fillTemplate', jQueryFillTemplate, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    tests: function (ext) {
    }
}, $.fn);
var deferred = 0;
var deferredDone = 0;
function jQueryFillTemplate(data, _context, forceFill) {
    if (forceFill === void 0) { forceFill = false; }
    _context = sing.loadContext(_context);
    var template = (this);
    var visible = template.isOnScreen(0.01, 0.01);
    if (!forceFill && !visible && template.attr(sing.constants.htmlAttr.Templates.Deferred) != 'true') {
        template.attr(sing.constants.htmlAttr.Templates.Deferred, 'true');
        var tempHtml = template.outerHtml();
        var thisDeferredID = deferred;
        template.attr(sing.constants.htmlAttr.Templates.DeferID, thisDeferredID);
        template.html('DEFERRED');
        deferred++;
        _context = $.extend(true, {}, _context);
        (function () {
            try {
                var deferTemplate = $("*[" + sing.constants.htmlAttr.Templates.DeferID + "=" + thisDeferredID + "]");
                var newTemplate = $(tempHtml);
                deferTemplate.before(newTemplate);
                deferTemplate.remove();
                newTemplate.fillTemplate(data, _context, true);
                deferredDone++;
            }
            catch (ex) {
                error(ex);
            }
        }).fnDefer()();
        return;
    }
    var loops = template.find("*[" + sing.constants.htmlAttr.Templates.Loop + "]");
    loops.each(function () {
        $(this).singLoop(data, _context, true);
    });
    var ifs = template.find("*[" + sing.constants.htmlAttr.Templates.If + "]");
    ifs.each(function () {
        $(this).singIf(data, _context, true);
    });
    var fills = template.find("*[" + sing.constants.htmlAttr.Templates.Fill + "]");
    fills.each(function () {
        $(this).singFill(data, _context, forceFill);
    });
    if (template.attr(sing.constants.htmlAttr.Templates.Fill) &&
        template.attr(sing.constants.htmlAttr.Templates.Fill).length > 0)
        template.singFill(data, _context, forceFill);
    try {
        var html = template[0].outerHTML;
        var templateReplace = html.templateInject(data, _context);
        template.replaceWith($(templateReplace));
    }
    catch (ex) {
        jQueryTemplateError(ex, template, data, _context);
    }
    $(sing.constants.htmlElement.Templates.Element).each(function () {
    });
    if (sing.templateShownFunctions && sing.templateShownFunctions.length > 0) {
        sing.templateShownFunctions.each(function (fn) {
            fn(template);
        });
    }
}
singTemplates.method('singIf', jQueryPerformSingIf, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    tests: function (ext) {
    }
}, $.fn);
function jQueryPerformSingIf(data, _context) {
    _context = sing.loadContext(_context);
    var srcThis = this;
    var parent = srcThis.parent("*[" + sing.constants.htmlAttr.Templates.Template + "]");
    if (parent.length != 0 && parent.attr(sing.constants.htmlAttr.Templates.TemplateData) != 'true')
        return null;
    var mode = sing.constants.htmlAttr.Templates.If;
    var condition = '';
    if ($(this).hasAttr(sing.constants.htmlAttr.Templates.ElseIf)) {
        mode = sing.constants.htmlAttr.Templates.ElseIf;
        condition = $(this).attr(sing.constants.htmlAttr.Templates.ElseIf);
    }
    else if ($(this).hasAttr(sing.constants.htmlAttr.Templates.Else)) {
        mode = sing.constants.htmlAttr.Templates.Else;
        condition = '';
    }
    else {
        condition = $(this).attr(sing.constants.htmlAttr.Templates.If);
    }
    condition = condition || '';
    if (condition.startsWith(sing.constants.TemplatePatternStart))
        condition = condition.substr(sing.constants.TemplatePatternStart.length);
    if (condition.endsWith(sing.constants.TemplatePatternEnd))
        condition = condition.substr(0, condition.length - sing.constants.TemplatePatternEnd.length);
    var sourceData = null;
    if (mode == sing.constants.htmlAttr.Templates.Else) {
        sourceData = true;
    }
    else {
        try {
            sourceData = sing.resolve(condition, data, _context);
        }
        catch (ex) {
            sourceData = false;
        }
        if (!$.isDefined(sourceData))
            sourceData = false;
    }
    srcThis.removeAttr(mode);
    var next = srcThis.next();
    if (srcThis.siblings().length > 0) {
    }
    if ($.isEmpty(sourceData) ||
        sourceData === false ||
        sourceData === 0 ||
        sourceData == []) {
        srcThis.remove();
        if (next && next.length == 1 && (next.hasAttr(sing.constants.htmlAttr.Templates.ElseIf) ||
            next.hasAttr(sing.constants.htmlAttr.Templates.Else))) {
            next.singIf(data, _context);
        }
        return false;
    }
    else {
        while (next && next.length > 0 && (next.hasAttr(sing.constants.htmlAttr.Templates.ElseIf) ||
            next.hasAttr(sing.constants.htmlAttr.Templates.Else))) {
            var last = next;
            next = last.next();
            last.remove();
        }
        return true;
    }
}
singTemplates.method('singFill', jQueryPerformSingFill, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    tests: function (ext) {
    }
}, $.fn);
function jQueryPerformSingFill(data, _context, forceFill, fillInside) {
    if (forceFill === void 0) { forceFill = false; }
    if (fillInside === void 0) { fillInside = true; }
    _context = sing.loadContext(_context);
    var srcThis = this;
    var parent = srcThis.parent("*[" + sing.constants.htmlAttr.Templates.Template + "]");
    if (parent.length != 0 && parent.attr(sing.constants.htmlAttr.Templates.TemplateData) != 'true')
        return null;
    var fillWith = srcThis.attr(sing.constants.htmlAttr.Templates.Fill);
    if (fillWith.startsWith(sing.constants.TemplatePatternStart) || fillWith.startsWith('<<'))
        fillWith = fillWith.substr(sing.constants.TemplatePatternStart.length);
    if (fillWith.endsWith(sing.constants.TemplatePatternEnd) || fillWith.endsWith('>>'))
        fillWith = fillWith.substr(0, fillWith.length - sing.constants.TemplatePatternEnd.length);
    var template = null;
    var source = '';
    var fill;
    if (!fillWith.contains(' with ')) {
        template = srcThis;
        source = fillWith;
    }
    else {
        fill = fillWith.split(' with ')[0].trim();
        source = fillWith.split(' with ')[1].trim();
        template = $.getTemplate(fill);
        srcThis.html('');
        srcThis.prepend(template);
    }
    if (!template || template.length == 0)
        throw "could not find template " + fill;
    var sourceData;
    if (source.contains(' as ')) {
        var after = source.after(' as ').trim();
        sourceData = sing.resolve(source.before(' as '), data, _context);
        if (_context[after] !== undefined) {
            _context = $.extend(true, {}, _context);
        }
        _context[after] = sourceData;
    }
    else {
        sourceData = sing.resolve(source, data, _context);
    }
    if (!$.isDefined(sourceData))
        throw "could not find data " + source;
    template.removeAttr(sing.constants.htmlAttr.Templates.Template);
    srcThis.removeAttr(sing.constants.htmlAttr.Templates.Fill);
    srcThis.attr(sing.constants.htmlAttr.Templates.DataType, $.typeName(sourceData));
    if (fill)
        srcThis.attr(sing.constants.htmlAttr.Templates.TemplateName, fill.toSlug());
    var content = srcThis.children("." + sing.constants.htmlAttr.Templates.Content + ", " + sing.constants.htmlElement.Templates.Element + "[" + sing.constants.htmlAttr.Templates.ShortContent + "]");
    if (content.length > 0) {
        content.each(function (c) {
            var contentName = $(c).attr(sing.constants.htmlAttr.Templates.Content) || $(c).attr(sing.constants.htmlAttr.Templates.ShortContent);
            var contentCode = $(c).outerHtml();
            var contentNamed = !$.isEmpty(contentName);
            _context['content'] = sourceData['content'] || {};
            if (contentNamed) {
                _context['content']['unnamed'] = sourceData['content']['unnamed'] || [];
                _context['content']['unnamed'].push(contentCode);
            }
            else {
                if (_context['content'][contentName] == null) {
                    _context['content'][contentName] = contentCode;
                }
                else if ($.isArray(sourceData['content'][contentName])) {
                    _context['content'][contentName].push(contentCode);
                }
                else {
                    var temp = sourceData['content'][contentName];
                    _context['content'][contentName] = [temp, contentCode];
                }
            }
            $(c).remove();
        });
    }
    var dataElements = srcThis.children("[" + sing.constants.htmlAttr.Templates.Data + "], " + sing.constants.htmlElement.Templates.Element + "[" + sing.constants.htmlAttr.Templates.ShortData + "]");
    if (dataElements.length > 0) {
        dataElements.each(function (d) {
            var dataName = $(d).attr(sing.constants.htmlAttr.Templates.Content) || $(d).attr(sing.constants.htmlAttr.Templates.ShortContent);
            var contentValue = $(d).innerHtml();
            _context[dataName] = contentValue;
            $(d).remove();
        });
    }
    var inner = srcThis.innerHtml().trim();
    if (!$.isEmpty((inner))) {
        _context['content'] = inner;
    }
    if (fillInside) {
        try {
            _context[sing.constants.specialTokens.Data] = undefined;
            fillTemplateTraverse(srcThis, srcThis, sourceData, _context);
        }
        catch (ex) {
            jQueryTemplateError(ex, srcThis, data, _context);
        }
    }
    return srcThis;
}
singTemplates.method('singLoop', jQueryPerformSingLoop, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    tests: function (ext) {
    }
}, $.fn);
function jQueryPerformSingLoop(data, _context, forceFill, fillInside) {
    if (forceFill === void 0) { forceFill = false; }
    if (fillInside === void 0) { fillInside = true; }
    _context = sing.loadContext(_context);
    var loop = this;
    var loopKey = loop.attr(sing.constants.htmlAttr.Templates.Loop);
    if (loopKey.startsWith(sing.constants.TemplatePatternStart))
        loopKey = loopKey.substr(sing.constants.TemplatePatternStart.length);
    if (loopKey.endsWith(sing.constants.TemplatePatternEnd))
        loopKey = loopKey.substr(0, loopKey.length - sing.constants.TemplatePatternEnd.length);
    var itemKey = sing.constants.specialTokens.Item;
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
    var loopData;
    var ex;
    try {
        loopData = sing.resolve(loopKey, data, _context);
    }
    catch (ex) {
        loopData = [];
    }
    if (loopData == null || loopData.length == 0) {
    }
    else {
        var loopKeys = [];
        if ($.isHash(loopData)) {
            loopKeys = $.objKeys(loopData);
            loopData = $.objValues(loopData);
        }
        if ($.isArray(loopData)) {
            _context[itemKey + sing.constants.specialTokens.Length] = loopData.length;
            for (var i = 0; i < loopData.length; i++) {
                var loopClone;
                if (loop.attr(sing.constants.htmlAttr.Templates.LoopInner) == 'true') {
                    loopClone = $(loop[0].innerHTML);
                }
                else {
                    loopClone = $(loop[0].outerHTML);
                }
                loopClone.removeAttr(sing.constants.htmlAttr.Templates.Loop);
                loop.before(loopClone);
                if (_context[itemKey] !== undefined) {
                    _context = $.extend(true, {}, _context);
                }
                _context[itemKey] = loopData[i];
                _context[itemKey + sing.constants.specialTokens.I] = i;
                _context[itemKey + sing.constants.specialTokens.Index] = i;
                _context[itemKey + sing.constants.specialTokens.IsFirst] = i == 0;
                _context[itemKey + sing.constants.specialTokens.IsLast] = i == loopData.length - 1;
                if (loopKeys && loopKeys.length > 0)
                    _context[itemKey + sing.constants.specialTokens.Key] = loopKeys[i];
                if (fillInside) {
                    try {
                        fillTemplateTraverse(loopClone, loop, data, _context);
                    }
                    catch (ex) {
                        jQueryTemplateError(ex, loopClone, data, _context);
                    }
                }
            }
        }
    }
    loop.remove();
}
sing.loadTemplate = function (url, callback) {
    if ($.isArray(url)) {
        for (var i = 0; i < url.length; i++) {
            var last = i == url.length - 1;
            sing.loadTemplate(url[i], last ? callback : function () { });
        }
    }
    else {
        var start = new Date().valueOf();
        $.ajax(url, {
            complete: function (data) {
                var templates = $("<div>" + data.responseText + "</div>");
                templates.find("*[" + sing.constants.htmlAttr.Templates.Template + "]").each(function () {
                    if ($(this).attr(sing.constants.htmlAttr.Templates.TemplateData) == 'true')
                        return;
                    var name = $(this).attr(sing.constants.htmlAttr.Templates.Template);
                    var html = $(this)[0].outerHTML;
                    sing.templates[name] = html;
                });
                var end = new Date().valueOf();
                var length = (end - start).max(0);
                if (callback)
                    callback(length);
            }
        });
    }
};
$().init(function () {
    $("*[" + sing.constants.htmlAttr.Templates.Template + "]").each(function () {
        var thisElement = $(this);
        if (thisElement.attr(sing.constants.htmlAttr.Templates.TemplateData) == 'true')
            return;
        var name = thisElement.attr(sing.constants.htmlAttr.Templates.Template);
        var html = thisElement[0].outerHTML;
        sing.templates[name] = html;
        thisElement.remove();
    });
});
sing.initTemplates = function () {
    $(sing.constants.htmlElement.Templates.Element).each(function () {
        var thisElement = this;
        if (thisElement != null) {
            if (thisElement.hasAttr(sing.constants.htmlAttr.Templates.ShortIf)) {
                thisElement.attr(sing.constants.htmlAttr.Templates.If, thisElement.attr(sing.constants.htmlAttr.Templates.ShortIf));
                thisElement.removeAttr(sing.constants.htmlAttr.Templates.ShortIf);
            }
            if (thisElement.hasAttr(sing.constants.htmlAttr.Templates.ShortElseIf)) {
                thisElement.attr(sing.constants.htmlAttr.Templates.ElseIf, thisElement.attr(sing.constants.htmlAttr.Templates.ShortElseIf));
                thisElement.removeAttr(sing.constants.htmlAttr.Templates.ShortElseIf);
            }
            if (thisElement.hasAttr(sing.constants.htmlAttr.Templates.ShortElse)) {
                thisElement.attr(sing.constants.htmlAttr.Templates.Else, thisElement.attr(sing.constants.htmlAttr.Templates.ShortElse));
                thisElement.removeAttr(sing.constants.htmlAttr.Templates.ShortElse);
            }
            if (thisElement.hasAttr(sing.constants.htmlAttr.Templates.ShortLoop)) {
                thisElement.attr(sing.constants.htmlAttr.Templates.Loop, thisElement.attr(sing.constants.htmlAttr.Templates.ShortLoop));
                thisElement.removeAttr(sing.constants.htmlAttr.Templates.ShortLoop);
            }
            if (thisElement.hasAttr(sing.constants.htmlAttr.Templates.ShortFill)) {
                thisElement.attr(sing.constants.htmlAttr.Templates.Fill, thisElement.attr(sing.constants.htmlAttr.Templates.ShortFill));
                thisElement.removeAttr(sing.constants.htmlAttr.Templates.ShortFill);
            }
        }
    });
    fillTemplateTraverse($('body'), $('body'), null, {});
};
function jQueryTemplateError(ex, target, data, _context) {
    var singTry = target.parents(sing.constants.htmlElement.Templates.Try);
    if (singTry == null || singTry.length == 0) {
        target.html("<" + sing.constants.htmlElement.Error + ">" + ex + "</" + sing.constants.htmlElement.Error + ">");
        console.log(ex);
    }
    else {
        target.hide();
        var singCatch = singTry.next();
        if (singCatch != null &&
            singCatch.length > 0 &&
            singCatch[0].localName == sing.constants.htmlElement.Templates.Catch) {
            _context['$ex'] = ex;
            singCatch.replaceWith(singCatch[0].innerHTML);
            singCatch.fillTemplate(data, _context, true);
            singCatch.show();
        }
    }
}
function htmlTraverse(target, action, root) {
    if (root === void 0) { root = target; }
    if (target != null &&
        target.children != null &&
        target.children.length > 0) {
        for (var i = 0; i < target.children.length; i++) {
            log(target.children[i].nodeType);
            action(target.children[i], root);
            htmlTraverse(target.children[i], action, root);
        }
    }
}
function jQueryTraverse(target, action, root) {
    if (root === void 0) { root = target; }
    var contents = target.contents();
    for (var i = 0; i < contents.length; i++) {
        action($(contents[i]), root);
        if (contents[i] != null &&
            !$.isString(contents[i])) {
            jQueryTraverse($(contents[i]), action, root);
        }
    }
}
function jQueryTraverseReplace(target, action, root) {
    if (root === void 0) { root = target; }
    var contents = target.contents();
    for (var i = 0; i < contents.length; i++) {
        action($(contents[i]), root);
        if (contents[i] != null &&
            !$.isString(contents[i])) {
            jQueryTraverse($(contents[i]), action, root);
        }
    }
}
function fillTemplateTraverse(target, root, data, _context) {
    if (data === void 0) { data = {}; }
    if (_context === void 0) { _context = {}; }
    _context = sing.loadContext(_context);
    if (!objectDefined(target))
        return;
    try {
        if (target &&
            target.length > 0 &&
            target[0].attributes) {
            var attributes = target[0].attributes;
            for (var i = 0; i < attributes.length; i++) {
                var value = attributes[i];
                if (value.name == sing.constants.htmlAttr.Templates.Fill ||
                    value.name == sing.constants.htmlAttr.Templates.If ||
                    value.name == sing.constants.htmlAttr.Templates.Loop) { }
                else if (value.specified) {
                    var newValue = value.value.templateInject(data, _context);
                    if (value.value != newValue) {
                        target.attr(value.name, newValue);
                    }
                }
            }
        }
        if (target.hasAttr(sing.constants.htmlAttr.Templates.Fill)) {
            target.singFill(data, _context, true, true);
            return;
        }
        if (target.hasAttr(sing.constants.htmlAttr.Templates.If)) {
            var ifResult = target.singIf(data, _context, true);
            if (ifResult == false)
                return;
        }
        if (target.hasAttr(sing.constants.htmlAttr.Templates.Loop)) {
            target.singLoop(data, _context, true, true);
            return;
        }
        target.contents().each(function () {
            if (this.nodeType == 3) {
                $(this).before((this.textContent || '').templateInject(data, _context));
                this.textContent = '';
            }
            else {
                var thisElement = $(this);
                fillTemplateTraverse(thisElement, root, data, _context);
            }
        });
    }
    catch (ex) {
        jQueryTemplateError(ex, target, data, _context);
    }
}
var singRegExp = singString.addModule(new sing.Module('RegExp', String));
singRegExp.glyphIcon = '&#xe051;';
singRegExp.method('matchCount', stringMatchCount, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    }
});
function stringMatchCount(pattern) {
    var match = this.match(pattern);
    if (!match)
        return 0;
    return match.length;
}
singRegExp.method('hasMatch', stringHasMatch, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    }
});
function stringHasMatch(pattern) {
    var match = this.match(pattern);
    if (!match || match.length == 0)
        return false;
    return true;
}
singRegExp.method('replaceRegExp', stringReplaceRegExp, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    }
});
function stringReplaceRegExp(pattern, replace) {
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
singRegExp.method('escapeRegExp', stringEscapeRegExp, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    }
});
function stringEscapeRegExp() {
    var out = (this || '');
    return out.replace(/([\\\.\+\*\?\[\^\]\$\(\)\{\}\=\!\<\>\|\:])/g, '\\$1');
}
var singBBCode = singString.addModule(new sing.Module('BBCode', String));
singBBCode.glyphIcon = '&#xe242;';
singBBCode.method('bbCodesToHTML', stringBBCodesToHTML, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    }
});
function stringBBCodesToHTML() {
    var out = this;
    sing.bbCodes.each(function (item) {
        out = out.replaceRegExp(item.matchStr, item.htmlStr);
    });
    return out;
}
singBBCode.method('bbCodesToText', stringBBCodesToText, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    }
});
function stringBBCodesToText() {
    var out = this;
    sing.bbCodes.each(function (item) {
        out = out.replaceRegExp(item.matchStr, item.textStr);
    });
    return out;
}
sing.bbCodes = [
    {
        name: 'Bold',
        tag: '[b][/b]',
        matchStr: /\[b\](.+)\[\/b\]/,
        htmlStr: '\<b\>$1\</b\>',
        textStr: '$1',
        test: '[b]bolded text[/b]'
    },
    {
        name: 'Italics',
        tag: '[i][/i]',
        matchStr: /\[i\](.+)\[\/i\]/,
        htmlStr: '<i>$1</i>',
        textStr: '$1',
        test: '[i]italicized text[/i]'
    },
    {
        name: 'Underline',
        tag: '[u][/u]',
        matchStr: /\[u\](.+)\[\/u\]/,
        htmlStr: '<u>$1</u>',
        textStr: '$1',
        test: '[u]underlined text[/u]'
    },
    {
        name: 'Strikethrough',
        tag: '[s][/s]',
        matchStr: /\[s\](.+)\[\/s\]/,
        htmlStr: '<s>$1</s>',
        textStr: '$1',
        test: '[s]strikethrough text[/s]'
    },
    {
        name: 'Center',
        tag: '[center][/center]',
        matchStr: /\[center\](.+)\[\/center\]/,
        htmlStr: '<center>$1</center>',
        textStr: '$1',
        test: '[center]centered text[/center]'
    },
    {
        name: 'Font Style Size',
        tag: '[style size={size}][/style]',
        matchStr: /\[style size\=["]*(\d{1,3}).*\](.+)\[\/style\]/,
        htmlStr: '<font size="$1">$2</font>',
        textStr: '$2',
        test: '[style size="20px"]Large Text[/style]'
    },
    {
        name: 'Font Size',
        tag: '[size={size}][/style]',
        matchStr: /\[size\=["]*(\d{1,3}).*\](.+)\[\/size\]/,
        htmlStr: '<font size="$1">$2</font>',
        textStr: '$2',
        test: '[size="28px"]Larger Text[/size]'
    },
    {
        name: 'Font Color',
        tag: '[color={color}][/color]',
        matchStr: /\[color\=["]*([.,\#]+).*\](.+)\[\/color\]/,
        htmlStr: '<font style="color:$1;">$2</font>',
        textStr: '$2',
        test: '[color="red"]Red Text[/style]\r\n[color=#FF0000]Red Text[/color]'
    },
    {
        name: 'Style Color',
        tag: '[style color={color}][/color]',
        matchStr: /\[style color\=["]*([.,#]+).*\](.+)\[\/style\]/,
        htmlStr: '<font style="color:$1;">$2</font>',
        textStr: '$2',
        test: '[style color="red"]Red Text[/style]\r\n[style color=#FF0000]Red Text[/style]'
    },
    {
        name: 'URL',
        tag: '[url]{url}[/url]',
        matchStr: /\[url\](.+)\[\/url\]/,
        htmlStr: '<a href="$1">$1</a>',
        textStr: '$1',
        test: '[url]http://example.org[/url]'
    },
    {
        name: 'Named URL',
        tag: '[url={url}][/url]',
        matchStr: /\[url\=\"?(.+)\"?\](.+)\[\/url\]/,
        htmlStr: '<a href=$1>$2</a>',
        textStr: '$2',
        test: '[url="http://example.com"]Example[/url]'
    }
];
var singDocs = singCore.addModule(new sing.Module('Documentation', Singularity));
singDocs.glyphIcon = '&#xe086;';
singDocs.ignoreUnknown('ALL');
singDocs.method('getDocs', singularityGetDocs);
function singularityGetDocs(funcName, includeCode, includeDocumentation) {
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
    if (!funcName ||
        funcName == '' ||
        funcName == 'all')
        header = sing.summary + "\r\n\r\n";
    var out = '';
    $.objEach(sing.methods, function (key, ext) {
        var mod = sing.modules[ext.moduleName];
        if (funcName &&
            funcName.lower() != '' &&
            funcName.lower() != 'all' &&
            !ext.name.lower().startsWith(funcName.lower()))
            return;
        if (ext.isAlias) {
            return;
        }
        featuresCount += 1;
        if (mod.requiredUnitTests)
            featuresNeedTests++;
        if (mod.requiredDocumentation)
            documentaionCount += 5;
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
            if (ext.isAlias && includeDocumentation) {
                return;
            }
            out += '\r\n';
            var functionDef = '';
            out +=
                [
                    line,
                    ext.methodCall.pad(40) + (!ext.method ? ' -- NOT IMPLEMENTED' : functionDef).pad(40, Direction.r),
                    line,
                    (ext.details.summary ? ("\r\n    Summary: \r\n" + ext.details.summary) : ''),
                    (ext.details.parameters && ext.details.parameters.length == 0 ? '\r\n    Parameters: None\r\n' : ''),
                    (ext.details.parameters && ext.details.parameters.length > 0 ? ("\r\n    Parameters:\r\n" + ext.details.parameters.collect(function (item, j) { return ((" #" + (j + 1)).pad(10) + "Name:    " + item.name + "\r\n" + (!item.required ? '              :    OPTIONAL \r\n' : '') + (item.isMulti ? '              :    Multi-parameter \r\n' : '') + (item.defaultValue != undefined ? " Default Value:    " + $.toStr(item.defaultValue, true) + "\r\n" : '') + "         Types:    [" + item.types.collect(function (a) { return a.name; }).join(', ') + "] \r\n   Description:    " + item.description + "\r\n\r\n"); }).joinLines() + "\r\n") : ''),
                    ext.details.returnTypeName ? ("\r\n    Return Type: " + ext.details.returnTypeName + "\r\n") : '',
                    (ext.details.aliases && ext.details.aliases.length > 0 ? ("\r\n    Aliases: \r\n" + ext.details.aliases.collect(function (alias) { return ("" + ''.pad(13) + ext.methodCall + "." + alias); }).join(', ') + "\r\n\r\n") : ''),
                    ext.details.returns ? ("\r\n    Returns: \r\n" + ext.details.returns + "\r\n\r\n") : '',
                    (ext.details.examples ? ("\r\n    Examples: \r\n" + ext.details.examples.joinLines()) : ''),
                    (ext.method && includeCode ? ("\r\n    Method Code: \r\n\r\n" + ext.method.toString()) : '')]
                    .joinLines()
                    .replaceAll('\r\n\r\n\r\n', '\r\n\r\n');
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
                    out += "        " + (test.requirement || '') + "\r\n";
                    try {
                        var testPasses = test.testFunc();
                        if (testPasses == true || testPasses === undefined || testPasses === null) {
                            testsPassed++;
                            methodTestsPassed++;
                        }
                        else {
                            out += "        " + ('').pad(50) + " TEST CASE FAILS \r\n\r\n";
                        }
                    }
                    catch (ex) {
                        out += "        " + ext.name.pad(50) + "TEST CASE FAILS \r\n\r\n";
                    }
                }
                if (methodTestsFound > 0) {
                    if (methodTestsFound == methodTestsPassed) {
                        out += '----\r\nAll Test Cases Passed\r\n\r\n';
                    }
                    else {
                        out += "----" + methodTestsPassed + " / " + methodTestsFound + " (" + methodTestsPassed.percentOf(methodTestsFound, 0, true) + ") Test Cases Passed\r\n\r\n";
                    }
                }
            }
        }
        else {
            out += '\r\n';
            out += line + "\r\n";
            out += ext.name + "\r\n";
            out += line + "\r\n";
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
        header += "Methods Implemented:      " + (featuresFound + " / " + featuresCount).pad(leftSpace, Direction.r) + " (" + featuresFound.percentOf(featuresCount, 0, true) + ")\r\n";
    if (featuresHaveTests != 0 || featuresNeedTests != 0)
        header += "Unit Tests Implemented:   " + (featuresHaveTests + " / " + featuresNeedTests).pad(leftSpace, Direction.r) + " (" + featuresHaveTests.percentOf(featuresNeedTests, 0, true) + ")\r\n";
    if (testsPassed != 0 || testsFound != 0)
        header += "Unit Tests Passed:        " + (testsPassed + " / " + testsFound).pad(leftSpace, Direction.r) + " (" + testsPassed.percentOf(testsFound, 0, true) + ")\r\n";
    if (documentaionFound != 0 || documentaionCount != 0)
        header += "Documentation:            " + (documentaionFound + " / " + documentaionCount).pad(leftSpace, Direction.r) + " (" + documentaionFound.percentOf(documentaionCount, 0, true) + ")\r\n";
    header += '\r\n';
    if (totalFound != 0 || totalCount != 0)
        header += "Total:                    " + (totalFound + " / " + totalCount).pad(leftSpace, Direction.r) + " (" + totalFound.percentOf(totalCount, 0, true) + ")\r\n";
    return header + out;
}
;
singDocs.method('getMissing', singularityGetMissing);
function singularityGetMissing(funcName) {
    sing.tests.resolveTests();
    var featuresCount = 0;
    var featuresFound = 0;
    var documentaionCount = 0;
    var documentaionFound = 0;
    var header = 'Singularity.TS TypeScript, JavaScript, jQuery, HTML, Extension Method Engine & Library\r\n';
    var out = '';
    $.objEach(sing.methods, function (key, ext) {
        if (funcName &&
            funcName.lower() != '' &&
            funcName.lower() != 'all' &&
            !ext.name.lower().contains(funcName.lower()))
            return;
        featuresCount += 1;
        documentaionCount += 5 +
            1;
        if (ext.method)
            featuresFound++;
        else
            out += ext.name + " Method Implementation \r\n";
        if (ext.details) {
            if (ext.details.summary)
                documentaionFound++;
            else
                out += ext.name + " Summary \r\n";
            if (ext.details.parameters)
                documentaionFound++;
            else
                out += ext.name + " Parameters \r\n";
            if (ext.details.returnTypeName)
                documentaionFound++;
            else
                out += ext.name + " Return Type \r\n";
            if (ext.details.returns)
                documentaionFound++;
            else
                out += ext.name + " Returns \r\n";
            if (ext.details.examples)
                documentaionFound++;
            else
                out += ext.name + " Examples \r\n";
            if (ext.details.unitTests && ext.details.unitTests.length > 0)
                documentaionFound++;
            else
                out += ext.name + " Tests \r\n";
        }
    });
    header += "\r\nMethods Implemented:      " + featuresFound + " / " + featuresCount + " (" + Math.round((featuresFound / featuresCount) * 100) + "%) \r\nDocumentation:            " + documentaionFound + " / " + documentaionCount + " (" + Math.round((documentaionFound / documentaionCount) * 100) + "%) \r\n";
    return header + out;
}
;
singDocs.method('getSummary', singularityGetSummary);
function singularityGetSummary(funcName, includeFunctions) {
    if (funcName === void 0) { funcName = 'all'; }
    if (includeFunctions === void 0) { includeFunctions = true; }
    var out = sing.getDocs(funcName, false, false);
    out += '\r\n';
    if (includeFunctions) {
        $.objEach(sing.methods, function (key, ext) {
            if (funcName &&
                funcName.lower() != '' &&
                funcName.lower() != 'all' &&
                !ext.name.lower().contains(funcName.lower()))
                return;
            out += "\r\n" + (ext.name + " ").pad(30);
            out += ((ext.details.returnTypeName || '') + " function(").pad(20, Direction.r);
            out += ((ext.details && ext.details.parameters) ? ext.details.parameters.collect(function (item, i) {
                var typeNames = item.types.collect(function (a) { return a.name; }).join(', ');
                return (i > 0 ? ''.pad(50) : '') + "[" + typeNames + "] " + item.name;
            }).join(', \r\n') : '') + ") " + (ext.details && ext.details.parameters && ext.details.parameters.length > 1 ? "\r\n" + ''.pad(50) : '') + "{ ... } ";
        });
    }
    return out;
}
;
var singObject = singExt.addModule(new sing.Module('Object', $, $));
singObject.glyphIcon = '&#xe165;';
singObject.srcLink = '/Scripts/singularity/singularity-object.ts';
singObject.ignoreUnknown('ALL');
singObject.method('objEach', objectEach, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: '',
    examples: null,
    glyphIcon: '&#xe153;',
    tests: function (ext) {
        ext.addCustomTest(function () {
            var test = { a: 1, b: 2 };
            var test2 = [];
            $.objEach(test, function (key, item, index) {
                test2.push({ key: key, item: item, index: index });
            });
            if ($.toStr(test2) != $.toStr([{ key: 'a', item: 1, index: 0 },
                { key: 'b', item: 2, index: 1 }]))
                return $.toStr(test2) + "\r\n" + $.toStr([{ key: 'a', item: 1, index: 0 },
                    { key: 'b', item: 2, index: 1 }]);
        }, 'Executes for every element');
    }
});
function objectEach(obj, eachFunc) {
    var keys = Object.keys(obj);
    keys.each(function (key, i) {
        eachFunc(key, obj[key], i);
    });
}
singObject.method('objProperties', objectProperties, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: '',
    examples: null,
    glyphIcon: '&#xe056;',
    tests: function (ext) {
        ext.addTest($, [null], []);
        ext.addTest($, [undefined], []);
        ext.addTest($, [['a']], [{ key: '0', value: 'a' }]);
        ext.addTest($, [5], []);
        ext.addTest($, [[]], []);
        ext.addTest($, [{}], []);
        ext.addTest($, [{ a: 1, b: 2 }], [{ key: 'a', value: 1 }, { key: 'b', value: 2 }]);
    }
});
function objectProperties(obj) {
    if (obj == null || !(typeof obj == 'object'))
        return [];
    var keys = Object.keys(obj);
    var values = keys.collect(function (item) { return ({ key: item, value: obj[item] }); });
    return values;
}
singObject.method('objValues', objectValues, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    glyphIcon: '&#xe055;',
    tests: function (ext) {
        ext.addTest($, [null], []);
        ext.addTest($, [undefined], []);
        ext.addTest($, ['a'], []);
        ext.addTest($, ['a', 'b'], []);
        ext.addTest($, [5], []);
        ext.addTest($, [[]], []);
        ext.addTest($, [{}], []);
        ext.addTest($, [{ a: 1, b: 2 }], [1, 2]);
        ext.addTest($, [{ a: 'b', c: 'd' }, ['a']], 'b');
        ext.addTest($, [{ a: 'b', c: 'd' }, ['b']], null);
        ext.addTest($, [{ a: 'b', c: 'd' }, ['c']], 'd');
    }
});
function objectValues(obj, findKeys) {
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
        var values = keys.collect(function (item) { return obj[item]; });
        return values;
    }
}
singObject.method('arrayValues', arrayFindValues, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe055;',
    tests: function (ext) {
        ext.addTest([], [null], []);
        ext.addTest([], [undefined], []);
        ext.addTest([1], [null], []);
        ext.addTest([1], [undefined], []);
        ext.addTest([{ a: 'b', c: 'd' }, { a: 'b2', c: 'd2' }], ['a'], ['b', 'b2']);
        ext.addTest([{ a: 'b', c: 'd' }, { a: 'b2', c: 'd2' }], ['b'], []);
        ext.addTest([{ a: 'b', c: 'd' }, { a: 'b2', c: 'd2' }], ['c'], ['d', 'd2']);
        ext.addTest([{ a: { name: 'a' }, b: { name: 'b' }, c: { name: 'c' } },
            { a: { name: 'a2' }, b: { name: 'b2' }, c: { name: 'c2' } }], ['a.name'], ['a', 'a2']);
        ext.addTest([{ a: { name: 'a' }, b: { name: 'b' }, c: { name: 'c' } },
            { a: { name: 'a2' }, b: { name: 'b2' }, c: { name: 'c2' } }], ['b.name'], ['b', 'b2']);
        ext.addTest([{ a: { name: 'a' }, b: { name: 'b' }, c: { name: 'c' } },
            { a: { name: 'a2' }, b: { name: 'b2' }, c: { name: 'c2' } }], ['c.name'], ['c', 'c2']);
        ext.addTest([{ a: { name: 'a' }, b: { name: 'b' }, c: { name: 'c' } },
            { a: { name: 'a2' }, b: { name: 'b2' }, c: { name: 'c2' } }], ['a', 'name'], ['a', 'a2']);
        ext.addTest([{ a: { name: 'a' }, b: { name: 'b' }, c: { name: 'c' } },
            { a: { name: 'a2' }, b: { name: 'b2' }, c: { name: 'c2' } }], ['b', 'name'], ['b', 'b2']);
        ext.addTest([{ a: { name: 'a' }, b: { name: 'b' }, c: { name: 'c' } },
            { a: { name: 'a2' }, b: { name: 'b2' }, c: { name: 'c2' } }], ['c', 'name'], ['c', 'c2']);
    }
}, Array.prototype);
function arrayFindValues() {
    var names = [];
    for (var _i = 0; _i < arguments.length; _i++) {
        names[_i - 0] = arguments[_i];
    }
    if (!names || names.length == 0 || names[0] == null)
        return [];
    if (names.length == 1 && names[0].contains('.')) {
        names = names[0].split('.');
    }
    if (names.length > 0) {
        var name = names.shift();
        var thisArray = this;
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
singObject.method('objKeys', objectKeys, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    glyphIcon: 'icon-keys',
    tests: function (ext) {
        ext.addTest($, [null], []);
        ext.addTest($, [undefined], []);
        ext.addTest($, ['a'], []);
        ext.addTest($, ['a', 'b'], []);
        ext.addTest($, [5], []);
        ext.addTest($, [[]], []);
        ext.addTest($, [{}], []);
        ext.addTest($, [{ a: 1, b: 2 }], ['a', 'b']);
    }
}, $);
function objectKeys(obj) {
    if (obj == null || !(typeof obj == 'object'))
        return [];
    var keys = Object.keys(obj);
    return keys;
}
singObject.method('objHasKey', objectHasKey, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    glyphIcon: '&#xe003;',
    tests: function (ext) {
        ext.addTest(null, [], false);
        ext.addTest(null, [null, 'a'], false);
        ext.addTest(null, [{ b: 'a' }, 'a'], false);
        ext.addTest(null, [{ a: 'b' }, 'a'], true);
    }
});
function objectHasKey(obj, key) {
    if (!$.isDefined(obj))
        return false;
    return $.isDefined(obj[key]) || Object.keys(obj).has(key);
}
singObject.method('resolve', objectResolve, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    glyphIcon: '&#xe162;',
    tests: function (ext) {
        ext.addTest($, [5], 5);
        ext.addTest($, ['aa'], 'aa');
        ext.addTest($, [['aa', 'bb']], ['aa', 'bb']);
        ext.addTest($, [function () { return 5; }], 5);
        ext.addTest($, [function () { return 'aa'; }], 'aa');
        ext.addTest($, [function () { return ['aa', 'bb']; }], ['aa', 'bb']);
    }
});
function objectResolve(obj, args) {
    if ($.isFunction(obj))
        return obj.apply(null, args);
    if ($.isArray(obj) && obj.length == 1)
        return obj[0];
    return obj;
}
singObject.method('isDefined', objectDefined, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    glyphIcon: '&#xe003;',
    tests: function (ext) {
        ext.addTest(null, [undefined], false);
        ext.addTest(null, [null], false);
        ext.addTest(null, [0], true);
        ext.addTest(null, ['a'], true);
        ext.addTest(null, [['a']], true);
        ext.addTest(null, [{}], true);
        ext.addTest(null, [{ name: 'a' }], true);
    }
});
function objectDefined(obj) {
    if (obj !== undefined && obj !== null)
        return true;
    return false;
}
singObject.method('isHash', objectIsHash, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    glyphIcon: 'icon-show-thumbnails',
    tests: function (ext) {
        ext.addTest(null, [undefined], false);
        ext.addTest(null, [null], false);
        ext.addTest(null, [0], false);
        ext.addTest(null, ['a'], false);
        ext.addTest(null, [['a']], false);
        ext.addTest(null, [{}], true);
        ext.addTest(null, [{ a: 'a' }], true);
    }
});
function objectIsHash(obj) {
    if (!objectDefined(obj))
        return false;
    if ($.isArray(obj))
        return false;
    if (typeof obj == 'object')
        return true;
    return false;
}
singObject.method('clone', arrayClone, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    glyphIcon: '&#xe224;',
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
    }
}, Array.prototype, 'Array');
function arrayClone(deepClone) {
    if (deepClone === void 0) { deepClone = false; }
    var thisArray = this;
    if (deepClone) {
        return thisArray.collect(function (item) { return $.clone(item, true); });
    }
    else {
        return thisArray.collect();
    }
}
singObject.method('clone', numberClone, {
    glyphIcon: '&#xe224;',
    tests: function (ext) {
        ext.addTest(0, [], 0);
        ext.addTest(1, [], 1);
        ext.addTest(NaN, [], NaN);
        ext.addTest(Infinity, [], Infinity);
        ext.addTest(-Infinity, [], -Infinity);
        ext.addCustomTest(function () {
            var src = 1;
            var src2;
            src2 = src.clone();
            src2 = 2;
            if (src == 2)
                return 'Same number was returned';
        }, 'Numbers must be clones, not the source number');
    }
}, Number.prototype, 'Number');
function numberClone() {
    return this.valueOf();
}
singObject.method('clone', booleanClone, {
    glyphIcon: '&#xe224;',
    tests: function (ext) {
        ext.addTest(false, [], false);
        ext.addTest(true, [], true);
        ext.addCustomTest(function () {
            var src = false;
            var src2 = src.clone();
            src2 = true;
            if (src == true)
                return 'Same boolean was returned';
        }, 'Booleans must be clones, not the source boolean');
    }
}, Boolean.prototype, 'Boolean');
function booleanClone() {
    return this.valueOf();
}
singObject.method('clone', stringClone, {
    glyphIcon: '&#xe224;',
    tests: function (ext) {
        ext.addTest('', [], '');
        ext.addTest('a', [], 'a');
        ext.addCustomTest(function () {
            var src = 'a';
            var src2 = src.clone();
            src2 = 'b';
            if (src == 'b')
                return 'Same string was returned';
        }, 'Strings must be clones, not the source string');
    }
}, String.prototype, 'String');
function stringClone() {
    return this.valueOf();
}
singObject.method('clone', dateClone, {
    glyphIcon: '&#xe224;',
    tests: function (ext) {
        var testDate = new Date();
        ext.addTest(testDate, [], testDate);
        ext.addCustomTest(function () {
            var src = new Date();
            var src2 = src.clone();
            src2.setMinutes(0);
            src2.setSeconds(0);
            src2.setMilliseconds(777);
            if (src.getSeconds() == 0)
                return 'Same date was returned';
        }, 'Dates must be clones, not the source date');
    }
}, Date.prototype, 'Date');
function dateClone() {
    return new Date(this.valueOf());
}
singObject.method('clone', objectClone, {
    glyphIcon: '&#xe224;',
    tests: function (ext) {
        ext.addTest($, [0], 0);
        ext.addTest($, [1], 1);
        ext.addTest($, [NaN], NaN);
        ext.addTest($, [Infinity], Infinity);
        ext.addTest($, [-Infinity], -Infinity);
        ext.addTest($, [false], false);
        ext.addTest($, [true], true);
        ext.addTest($, [''], '');
        ext.addTest($, ['a'], 'a');
        var testDate = new Date();
        ext.addTest($, [testDate], testDate);
        ext.addTest($, [{}], {});
        ext.addTest($, [[]], []);
        ext.addTest($, [[[]]], [[]]);
        ext.addTest($, [['a']], ['a']);
        ext.addTest($, [[['a']]], [['a']]);
    }
}, $, 'jQuery');
function objectClone(obj, deepClone) {
    if (deepClone === void 0) { deepClone = false; }
    if (obj.clone !== objectClone && $.isFunction(obj.clone))
        return obj.clone(deepClone);
    var out = {};
    var key;
    var objKeys = $.objKeys(obj);
    if (deepClone) {
        for (key in objKeys) {
            if (objKeys.hasOwnProperty(key)) {
                out[key] = obj[key];
            }
        }
    }
    else {
        for (key in objKeys) {
            if (objKeys.hasOwnProperty(key)) {
                out[key] = $.clone(obj[key]);
            }
        }
    }
    return out;
}
singObject.method('isEmpty', objectIsEmpty, {
    glyphIcon: '&#xe118;',
    tests: function (ext) {
        ext.addTest($, [0], false);
        ext.addTest($, [1], false);
        ext.addTest($, [NaN], true);
        ext.addTest($, [Infinity], false);
        ext.addTest($, [-Infinity], false);
        ext.addTest($, [''], true);
        ext.addTest($, ['  '], true);
        ext.addTest($, ['a'], false);
        ext.addTest($, [null], true);
        ext.addTest($, [undefined], true);
        ext.addTest($, [], true);
        ext.addTest($, [[]], true);
        ext.addTest($, [{}], true);
        ext.addTest($, [[{}]], true);
        ext.addTest($, [[1]], false);
        ext.addTest($, [[[1]]], false);
        ext.addTest($, [[[], [1]]], false);
    }
}, $);
function objectIsEmpty(obj) {
    return (obj === undefined ||
        obj === null ||
        obj === '' ||
        (typeof obj == 'number' && isNaN(obj)) ||
        ($.isString(obj) && obj.trim().length == 0) ||
        ($.isHash(obj) && $.objKeys(obj).length == 0)) ||
        ($.isArray(obj) && (obj.length == 0 || !obj.has(function (item) { return (!$.isEmpty(item)); }))) ||
        ($.isHash(obj) && !$.objValues(obj).has(function (item) { return (!$.isEmpty(item)); }));
}
singObject.method('typeName', objectTypeName, {
    glyphIcon: '&#xe041;',
    tests: function (ext) {
        ext.addTest($, [0], 'Number');
        ext.addTest($, [1], 'Number');
        ext.addTest($, [NaN], 'Number');
        ext.addTest($, [Infinity], 'Number');
        ext.addTest($, [-Infinity], 'Number');
        ext.addTest($, [''], 'String');
        ext.addTest($, ['a'], 'String');
        ext.addTest($, [true], 'Boolean');
        ext.addTest($, [false], 'Boolean');
        ext.addTest($, [null], 'Null');
        ext.addTest($, [undefined], 'Undefined');
        ext.addTest($, [[]], 'Array');
        ext.addTest($, [{}], 'Object');
        ext.addTest($, [sing], 'Singularity');
    }
}, $);
function objectTypeName(obj) {
    if (typeof obj === 'undefined')
        return 'Undefined';
    if (obj === null)
        return 'Null';
    if (obj.__proto__ && obj.__proto__.constructor && obj.__proto__.constructor.name)
        return obj.__proto__.constructor.name;
    return Object.prototype.toString.call(obj)
        .match(/^\[object\s(.*)\]$/)[1];
}
var SingularityTests = (function () {
    function SingularityTests() {
        this.testErrors = [];
    }
    SingularityTests.prototype.resolveTests = function () {
        $.objEach(sing.modules, function (key, mod) {
            if (!$.isEmpty(mod.features)) {
                mod.features.each(function (item) {
                    if ($.isFunction(item.tests))
                        item.tests(null);
                    if ($.isFunction(item.tests))
                        item.tests = null;
                });
            }
        });
        $.objEach(sing.methods, function (key, ext) {
            if (ext.isAlias)
                return;
            if (ext && ext.details.features) {
                ext.details.features.each(function (item) {
                    if ($.isFunction(item.tests))
                        item.tests(ext);
                    if ($.isFunction(item.tests))
                        item.tests = null;
                });
            }
            if (ext && ext.details.tests && $.isFunction(ext.details.tests)) {
                ext.details.tests(ext);
                if ($.isFunction(ext.details.tests))
                    ext.details.tests = null;
            }
        });
    };
    return SingularityTests;
}());
var SingularityTest = (function () {
    function SingularityTest(name, tempFunc, index, requirement) {
        this.name = name;
        this.tempFunc = tempFunc;
        this.index = index;
        this.requirement = requirement;
        this.testFunc = null;
        this.testResult = null;
        var thisTest = this;
        this.testFunc = function () {
            thisTest.testResult = tempFunc();
            if (thisTest.testResult == null)
                thisTest.testResult = true;
            if (thisTest.testResult !== true &&
                thisTest.testResult !== undefined &&
                thisTest.testResult !== null) {
                thisTest.testResult = "#" + index + ": " + name + " " + thisTest.testResult + (thisTest.requirement ? " " + thisTest.requirement : '');
                if (!sing.tests.testErrors.has(thisTest.testResult))
                    sing.tests.testErrors.push(thisTest.testResult);
                else {
                    sing.tests = sing.tests;
                }
            }
            return thisTest.testResult;
        };
    }
    return SingularityTest;
}());
sing.addType('SingularityTests', {
    typeClass: SingularityTests,
    protoType: SingularityTests.prototype,
    name: 'SingularityTests',
    autoDefault: this.autoDefaults,
    glyphIcon: '&#xe067;'
});
sing.tests = new SingularityTests();
var singTests = singCore.addModule(new sing.Module('Tests', SingularityTests));
singTests.glyphIcon = '&#xe067;';
singTests.method('resolveTests', sing.tests.resolveTests, {
    manuallyTested: true
});
singTests.method('addTest', singularityAddTest, {
    manuallyTested: true
});
function singularityAddTest(name, testFunc, requirement) {
    if (!sing.methods[name])
        throw name + " not found";
    if (!sing.methods[name].details.tests)
        throw name + " tests not found";
    if ($.isFunction(sing.methods[name].details.tests))
        sing.methods[name].details.unitTests = sing.methods[name].details.unitTests || [];
    sing.methods[name].details.unitTests = sing.methods[name].details.unitTests.concat(new SingularityTest(name, testFunc, sing.methods[name].details.unitTests.length + 1, requirement));
}
;
singTests.method('addCustomTest', singularityAddCustomTest, {
    manuallyTested: true
});
function singularityAddCustomTest(name, testFunc, requirement) {
    if (!$.isString(name))
        throw name + " was not a string";
    if (!sing.methods[name])
        throw name + " not found";
    if (!sing.methods[name].details.tests)
        throw name + " tests not found";
    requirement = requirement || '';
    requirement += "\r\n" + testFunc.toString() + "\r\n";
    sing.methods[name].details.unitTests = sing.methods[name].details.unitTests || [];
    sing.methods[name].details.unitTests = sing.methods[name].details.unitTests.concat(new SingularityTest(name, testFunc, sing.methods[name].details.unitTests.length + 1, requirement));
}
;
singTests.method('addMethodTest', singularityAddMethodTest, {
    manuallyTested: true
});
function singularityAddMethodTest(ext, target, args, compare, requirement) {
    if (!ext.method)
        throw ext.name + " method not found";
    requirement = (requirement ? (requirement + "\r\n") : '') +
        (!!target ? "(" + $.toStr(target, true) + ")." : '') + ext.shortName;
    requirement += '(';
    for (var i = 0; i < args.length; i++) {
        requirement += $.toStr(args[i], true);
        if (i < args.length - 1)
            requirement += ', ';
    }
    requirement += ')';
    requirement = requirement.pad(50);
    requirement += "// == (" + $.toStr(compare, true) + ")";
    this.addTest(ext.name, function () {
        var result = ext.method.apply(target, args);
        if (compare == result)
            return true;
        else if ($.toStr(compare) == $.toStr(result))
            return true;
        else
            return requirement + "\r\n \r\n" + $.toStr(compare, true) + " expected, result: " + $.toStr(result, true);
    }, requirement);
}
;
singTests.method('addAssertTest', singularityAddAssertTest, {
    manuallyTested: true
});
function singularityAddAssertTest(name, result, compare, requirement) {
    requirement = requirement || $.toStr(compare, true) + " is expected to match result: " + $.toStr(result, true);
    this.addTest(name, function () {
        if (compare == result)
            return true;
        else if ($.toStr(compare) == $.toStr(result))
            return true;
        else
            return requirement + "\r\n TEST FAILED \r\n";
    }, requirement);
}
;
singTests.method('addFailsTest', singularityAddFailsTest, {
    manuallyTested: true
});
function singularityAddFailsTest(ext, target, args, expectedError, requirement) {
    if (target == null)
        throw 'no target';
    requirement = (requirement ? (requirement + "\r\n") : '') + "(" + $.toStr(target, true) + ")." + ext.shortName;
    requirement += '(';
    for (var i = 0; i < args.length; i++) {
        requirement += $.toStr(args[i], true);
        if (i < args.length - 1)
            requirement += ', ';
    }
    requirement += ')';
    requirement = requirement.pad(50);
    requirement += " THROWS " + (expectedError ? "'" + expectedError + "'" : 'AN ERROR ');
    this.addTest(ext.name, function () {
        try {
            ext.method.apply(target, args);
            return name + " was expected to fail but it did not. \r\n\r\n" + requirement;
        }
        catch (ex) {
            if (expectedError && ex != expectedError &&
                ex != "Uncaught " + expectedError &&
                "Uncaught " + ex != expectedError) {
                return name + " was expected to fail with a message of '" + expectedError + "' \r\nbut instead failed with error '" + ex + "'\r\n\r\n" + requirement;
            }
            return true;
        }
    }, requirement);
}
;
singTests.method('runTests', singularityRunTests, {
    manuallyTested: true
});
function singularityRunTests(display) {
    if (display === void 0) { display = false; }
    sing.tests.resolveTests();
    var result = '';
    var testCount = 0;
    var displayStr = '';
    var testGroups = {};
    $.objValues(sing.modules).each(function (mod) {
        if (mod.features)
            mod.features.each(function (feature) {
                if (feature.unitTests) {
                    if (testGroups[mod.fullName()])
                        testGroups[mod.fullName()] = testGroups[mod.fullName()].concat(feature.unitTests);
                    else
                        testGroups[mod.fullName()] = feature.unitTests;
                }
            });
    });
    $.objValues(sing.methods).each(function (method) {
        if (method.details.features)
            method.details.features.each(function (feature) {
                if (feature.unitTests) {
                    if (testGroups[(method + " " + feature.name)])
                        testGroups[(method + " " + feature.name)] = testGroups[(method + " " + feature.name)].concat(feature.unitTests);
                    else
                        testGroups[(method + " " + feature.name)] = feature.unitTests;
                }
            });
        if (method.details) {
            testGroups[method.name] = method.details.unitTests;
            if (testGroups[method.name])
                testGroups[method.name] = testGroups[method.name].concat(method.details.unitTests);
            else
                testGroups[method.name] = method.details.unitTests;
        }
    });
    $.objProperties(testGroups).each(function (testGroup) {
        var name = testGroup.key;
        var tests = testGroup.value;
        if (tests) {
            tests.each(function (test, i) {
                if (display)
                    displayStr += test.requirement + "\r\n";
                var testFunc = test.testFunc;
                if (test && test.testFunc) {
                    var testResult = testFunc();
                    if (testResult != true &&
                        testResult !== undefined &&
                        testResult !== null) {
                        testResult = testResult || '';
                        result += "Error testing '" + name + "' Test " + (i + 1) + "\r\n" + testResult;
                    }
                    testCount++;
                }
            });
        }
    });
    return sing.tests.listTests() + "\r\n" + displayStr + "\r\n" + (result || ("\r\n\r\nAll " + testCount + " tests succeeded."));
}
;
singTests.method('listTests', singularityListTests, {
    manuallyTested: true
});
function singularityListTests() {
    sing.tests.resolveTests();
    var out = '\r\n';
    for (var i = 0; i < Object.keys(sing.methods).length; i++) {
        var name_1 = Object.keys(sing.methods)[i];
        var item = sing.methods[name_1];
        var tests = item.details.unitTests;
        if (tests && tests.length > 0)
            out += ("Extension: " + name_1).pad(50) + "      Tests: " + tests.length + "\r\n";
        else
            ;
    }
    return out;
}
;
singTests.method('listMissingTests', singularityListMissingTests, {
    manuallyTested: true
});
function singularityListMissingTests() {
    sing.tests.resolveTests();
    var out = '';
    for (var i = 0; i < Object.keys(sing.methods).length; i++) {
        var name_2 = Object.keys(sing.methods)[i];
        var item = sing.methods[name_2];
        var tests = item.details.unitTests;
        if (!tests || tests.length == 0) {
            out += "Extension: " + name_2 + "      Tests: 0\r\n";
        }
    }
    return out;
}
;
SingularityMethod.prototype.addFailsTest = methodAddFailsTest;
singTests.method('addFailsTest', methodAddFailsTest, {
    manuallyTested: true
}, SingularityMethod);
function methodAddFailsTest(caller, args, expectedError, requirement) {
    sing.tests.addFailsTest(this, caller, args, expectedError, requirement);
}
SingularityMethod.prototype.addCustomTest = methodAddCustomTest;
singTests.method('addCustomTest', methodAddCustomTest, {
    manuallyTested: true
}, SingularityMethod);
function methodAddCustomTest(testFunc, requirement) {
    sing.tests.addCustomTest(this.name, testFunc, requirement);
}
SingularityMethod.prototype.addTest = methodAddSimpleTest;
singTests.method('addTest', methodAddSimpleTest, {
    manuallyTested: true
}, SingularityMethod);
function methodAddSimpleTest(caller, args, result, requirement) {
    var thisSingularityMethod = this;
    sing.tests.addMethodTest(thisSingularityMethod, caller, args, result, requirement);
}
var singBoolean = singExt.addModule(new sing.Module('Boolean', Boolean));
singBoolean.glyphIcon = '&#xe063;';
singBoolean.summaryShort = 'Extensions on Boolean.prototype';
singBoolean.summaryLong = 'Perform boolean operations using extension methods instead of operators.';
singBoolean.features = ['Multi-variable operations',
    'Ternary operation',
    'toYesNo'];
singBoolean.method('XOR', booleanXor, {
    summary: '\
        XOR acts on a boolean to perform the binary XOR function on the passed Boolean',
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
    glyphIcon: '&#xe083;',
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
function booleanXor(b) {
    var a = this.valueOf();
    return (a == true && b == false) ||
        (a == false && b);
}
singBoolean.method('XNOR', booleanXNOR, {
    summary: '\
        XNOR acts on a boolean to perform the binary XNOR function on the passed Boolean, the inverse of the XOR function',
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
    glyphIcon: '&#xe088;',
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
function booleanXNOR(b) {
    return !this.XOR(b);
}
singBoolean.method('OR', booleanOR, {
    summary: '\
        OR acts on a boolean to perform the binary OR function on the passed Booleans',
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
    glyphIcon: '&#xe063;',
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
function booleanOR() {
    var b = [];
    for (var _i = 0; _i < arguments.length; _i++) {
        b[_i - 0] = arguments[_i];
    }
    return this == true || b.has(true);
}
singBoolean.method('NOR', booleanNOR, {
    summary: '\
        NOR acts on a boolean to perform the binary NOR function on the passed Booleans',
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
    glyphIcon: '&#xe088;',
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
function booleanNOR() {
    var b = [];
    for (var _i = 0; _i < arguments.length; _i++) {
        b[_i - 0] = arguments[_i];
    }
    return !this.OR.apply(this, b);
}
singBoolean.method('AND', booleanAND, {
    summary: '\
        AND acts on a boolean to perform the binary AND function on the passed Booleans',
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
    glyphIcon: '&#xe081;',
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
function booleanAND() {
    var b = [];
    for (var _i = 0; _i < arguments.length; _i++) {
        b[_i - 0] = arguments[_i];
    }
    return this == true && !b.has(false);
}
singBoolean.method('NAND', booleanNAND, {
    summary: '\
        NAND acts on a boolean to perform the binary NAND function on the passed Booleans',
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
    glyphIcon: '&#x2b;',
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
function booleanNAND() {
    var b = [];
    for (var _i = 0; _i < arguments.length; _i++) {
        b[_i - 0] = arguments[_i];
    }
    if (b.length == 0)
        return this;
    return !this.AND.apply(this, b);
}
singBoolean.method('toYesNo', booleanToYesNo, {
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
    glyphIcon: '&#xe150;',
    tests: function (ext) {
        ext.addTest(true, [], 'Yes');
        ext.addTest(false, [], 'No');
    }
});
function booleanToYesNo() {
    return this == false ? 'No' : 'Yes';
}
singBoolean.method('ternary', booleanTernary, {
    summary: 'Performs the ternary operation using the calling boolean.',
    parameters: [
        {
            name: 'obj',
            types: [Object],
            description: 'The first object, returned if the caller is true'
        },
        {
            name: 'obj2',
            types: [Object],
            description: 'The second object, returned if the caller is false'
        }
    ],
    returns: 'Returns the first argument if the calling boolean is true, otherwise the second argument is returned.',
    returnType: Object,
    examples: ['(true).ternary(1,2)   // == 1'],
    glyphIcon: 'icon-share',
    tests: function (ext) {
        ext.addTest(true, ['a', 'b'], 'a');
        ext.addTest(false, ['a', 'b'], 'b');
    }
}, String.prototype);
function booleanTernary(obj, obj2) {
    return this.valueOf() ? obj : obj2;
}
singBoolean.method('isBoolean', stringIsBoolean, {
    summary: 'Determines if the calling string is a Boolean format.',
    parameters: [],
    returns: 'true if the calling String is a form of a Boolean. isBoolean is Case Insensitive. \r\n\
            All valid boolean strings: y, n, yes, no, t, f, true, false, 0, 1',
    returnType: Boolean,
    examples: ['\
        \'no\'.isBoolean()  // == true \r\n\
        \'hi\'.isBoolean()  // == false \r\n\''],
    glyphIcon: '&#xe003;',
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
    }
}, String.prototype);
function stringIsBoolean() {
    var lower = this.lower().trim();
    if (lower == 'y' || lower == 'yes' || lower == 'true' || lower == '1' || lower == 't')
        return true;
    if (lower == 'n' || lower == 'no' || lower == 'false' || lower == '0' || lower == 'f')
        return true;
    return false;
}
singBoolean.method('toBoolean', stringToBoolean, {
    summary: 'Converts the calling string to a Boolean format. ',
    parameters: [],
    returns: 'true if the calling String is a form of a Boolean. isBoolean is Case Insensitive. \r\n\
            All valid boolean strings: y, n, yes, no, t, f, true, false, 0, 1 \r\n\
            If the calling string is not in a boolean format, undefined is returned.',
    returnType: Boolean,
    examples: ['\
        \'no\'.toBoolean()  // == false \r\n\
        \'hi\'.toBoolean()  // == undefined \r\n\''],
    glyphIcon: '&#xe063;',
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
    }
}, String.prototype);
function stringToBoolean() {
    var lower = this.lower().trim();
    if (lower == 'y' || lower == 'yes' || lower == 'true' || lower == '1' || lower == 't')
        return true;
    if (lower == 'n' || lower == 'no' || lower == 'false' || lower == '0' || lower == 'f')
        return false;
}
var singNumber = singExt.addModule(new sing.Module('Number', Number));
singNumber.glyphIcon = 'icon-calculator';
singNumber.summaryShort = 'Extensions on Number.prototype and others';
singNumber.summaryLong = '&nbsp;';
singNumber.features = ['Math object extensions: max, min, round, pow, ceil, floor, abs',
    'Friendly file sizes: formatFileSize',
    'String extensions: isNumeric, isInteger, toNumber, toInteger',
    'Number array extensions: total, average',
    'JQuery $ extensions: isInt, isFloat, isNumber'];
singNumber.method('max', numberMax, {
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
    glyphIcon: '&#xe244;',
    tests: function (ext) {
        ext.addTest(100, [200], 200);
        ext.addTest(0, [1, 2, 3, 4, 5], 5);
        ext.addTest(10, [1, 2, 3, 4, 5], 10);
        ext.addTest(4.26354, [4.26355], 4.26355);
        ext.addTest(100, [], 100);
        ext.addTest(100, [null], 100);
        ext.addTest(100, [undefined], 100);
    }
});
function numberMax() {
    var numbers = [];
    for (var _i = 0; _i < arguments.length; _i++) {
        numbers[_i - 0] = arguments[_i];
    }
    numbers.push(this);
    numbers = numbers.collect();
    return Math.max.apply(null, numbers);
}
singNumber.method('min', numberMin, {
    summary: 'Compares multiple Numbers to find the smallest.',
    parameters: [
        {
            name: 'Arguments',
            types: [Object],
            description: 'pass multiple arguments to compare them all to find the smallest'
        }
    ],
    returns: 'The smallest Number of all arguments and the calling Number',
    returnType: Number,
    examples: ['\
            (1).min(2);              // = 1 \r\n\
            (1).min(2,3,4,5);        // = 1 \r\n\
            (1.00025).min(1.00026);  // = 1.00025 \r\n\
            '],
    glyphIcon: '&#xe245;',
    tests: function (ext) {
        ext.addTest(100, [200], 100);
        ext.addTest(0, [1, 2, 3, 4, 5], 0);
        ext.addTest(10, [1, 2, 3, 4, 5], 1);
        ext.addTest(4.26354, [4.26355], 4.26354);
        ext.addTest(100, [], 100);
        ext.addTest(100, [null], 100);
        ext.addTest(100, [undefined], 100);
    }
});
function numberMin() {
    var numbers = [];
    for (var _i = 0; _i < arguments.length; _i++) {
        numbers[_i - 0] = arguments[_i];
    }
    numbers.push(this);
    numbers = numbers.collect();
    return Math.min.apply(null, numbers);
}
singNumber.method('round', numberRound, {
    summary: 'Rounds the calling Number to the nearest whole Number. If a number of decimal places is supplied they will be included',
    parameters: [
        {
            name: 'decimalPlaces',
            types: [Number],
            description: 'Specify how many decimal places the output should have',
            defaultValue: 0
        }
    ],
    returns: 'A number rounded to the supplied number of decimal places',
    returnType: Number,
    examples: ['\
            (1.6).round();                     //  == 2  \r\n\
            (1.6555).round(2);                 //  == 1.66  \r\n\
            (1.644999999999999).round(2);      //  == 1.64  '],
    glyphIcon: '&#xe165;',
    tests: function (ext) {
        ext.addTest(1.6, [], 2);
        ext.addTest(1.5, [], 2);
        ext.addTest(1.499999999999999, [], 1);
        ext.addTest(1.00001, [], 1);
        ext.addTest(1.6555, [2], 1.66);
        ext.addTest(1.644999999999999, [2], 1.64);
        ext.addTest(1.644999999999999, [null], 2);
        ext.addTest(1.644999999999999, [undefined], 2);
    }
});
function numberRound(decimalPlaces) {
    if (decimalPlaces > 0)
        return Math.round(this * ((10).pow(decimalPlaces))) / ((10).pow(decimalPlaces));
    return Math.round(this);
}
singNumber.method('ceil', numberCeiling, {
    summary: 'Extension of the Math.ceil function',
    parameters: [
        {
            name: 'decimalPlaces',
            types: [Number],
            description: 'Specify how many decimal places the output should have',
            defaultValue: 0
        }],
    returns: 'returns the calling number, rounded up',
    returnType: Number,
    examples: ['\
            (5.5).ceil();   // == (6) \r\n\
            (5.1).ceil();   // == (6) '],
    glyphIcon: '&#xe133;',
    tests: function (ext) {
        ext.addTest(5.5, [], 6);
        ext.addTest(5.1, [], 6);
        ext.addTest(5.1, [1], 5.1);
        ext.addTest(5.11, [1], 5.2);
    }
});
function numberCeiling(decimalPlaces) {
    if (decimalPlaces > 0)
        return Math.ceil(this * ((10).pow(decimalPlaces))) / ((10).pow(decimalPlaces));
    return Math.ceil(this);
}
singNumber.method('floor', numberFloor, {
    summary: 'Extension of the Math.floor function',
    parameters: [
        {
            name: 'decimalPlaces',
            types: [Number],
            description: 'Specify how many decimal places the output should have',
            defaultValue: 0
        }],
    returns: 'returns the calling number, rounded down',
    returnType: Number,
    examples: ['\
            (5.5).floor();   // == (5) \r\n\
            (5.1).floor();   // == (5) '],
    glyphIcon: '&#xe134;',
    tests: function (ext) {
        ext.addTest(5.5, [], 5);
        ext.addTest(5.1, [], 5);
        ext.addTest(5.1, [1], 5.1);
        ext.addTest(5.11, [1], 5.1);
        ext.addTest(5.99, [1], 5.9);
    }
});
function numberFloor(decimalPlaces) {
    if (decimalPlaces > 0)
        return Math.floor(this * ((10).pow(decimalPlaces))) / ((10).pow(decimalPlaces));
    return Math.floor(this);
}
singNumber.method('pow', numberPower, {
    summary: 'Returns the calling number raised to the power passed. \r\n\
            Decimal numbers are supported and can be used for calculating fractional powers and roots.',
    parameters: [
        {
            name: 'power',
            types: [Number],
            required: true,
            description: 'The power to raise the calling number to'
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
    glyphIcon: '&#xe255;',
    tests: function (ext) {
        ext.addTest(2, [2], 4);
        ext.addTest(4, [2], 16);
        ext.addTest(4, [1 / 2], 2);
        ext.addTest(2, [1 / 2], 1.4142135623730951);
        ext.addFailsTest(2, [null], 'Singularity.Extensions.Number.pow Missing Parameter: number power');
        ext.addFailsTest(2, [undefined], 'Singularity.Extensions.Number.pow Missing Parameter: number power');
    }
});
function numberPower(power) {
    return Math.pow(this, power);
}
singNumber.method('abs', numberAbsoluteValue, {
    summary: 'Extension of Math.abs',
    parameters: [],
    returns: 'The calling number as a positive value',
    returnType: Number,
    examples: ['\
            (-5).abs()  // == (5) '],
    glyphIcon: '&#xe081;',
    tests: function (ext) {
        ext.addTest(-5, [], 5);
        ext.addTest(-1, [], 1);
        ext.addTest(0, [], 0);
        ext.addTest(1, [], 1);
        ext.addTest(5, [], 5);
        ext.addTest(-Infinity, [], Infinity);
        ext.addTest(Infinity, [], Infinity);
        ext.addTest(NaN, [], NaN);
    }
});
function numberAbsoluteValue() {
    return Math.abs(this);
}
singNumber.method('percentOf', numberPercentOf, {
    summary: 'Takes the source number and returns the percent it is of the argument number',
    parameters: [
        {
            name: 'of',
            types: [Number],
            description: 'The number you are dividing by to get the percent',
            required: true
        },
        {
            name: 'decimalPlaces',
            types: [Number],
            description: 'Specify how many decimal places the output should have',
            defaultValue: 0
        }
    ],
    returns: 'A number rounded to the supplied number of decimal places',
    returnType: Number,
    examples: [],
    glyphIcon: 'icon-divide',
    tests: function (ext) {
        ext.addTest(1, [100], 1);
        ext.addTest(1, [100, 0, false], 1);
        ext.addTest(1, [100, 0, true], '1%');
        ext.addTest(50, [100], 50);
        ext.addTest(50, [100, 0, false], 50);
        ext.addTest(50, [100, 0, true], '50%');
        ext.addTest(55, [1000], 5);
        ext.addTest(55, [1000, 0, false], 5);
        ext.addTest(55, [1000, 0, true], '5%');
        ext.addTest(55, [1000, 1], 5.5);
        ext.addTest(55, [1000, 1, false], 5.5);
        ext.addTest(55, [1000, 1, true], '5.5%');
        ext.addTest(242, [286, 5], 84.61538);
        ext.addTest(242, [286, 5, false], 84.61538);
        ext.addTest(242, [286, 5, true], '84.61538%');
        ext.addTest(242, [-286, 5], -84.61539);
        ext.addTest(242, [-286, 5, false], -84.61539);
        ext.addTest(242, [-286, 5, true], '-84.61539%');
        ext.addTest(-242, [286, 5], -84.61539);
        ext.addTest(-242, [286, 5, false], -84.61539);
        ext.addTest(-242, [286, 5, true], '-84.61539%');
        ext.addTest(56465123, [12333, 5], 457837.69561);
        ext.addTest(56465123, [12333, 5, false], 457837.69561);
        ext.addTest(56465123, [12333, 5, true], '457837.69561%');
        ext.addTest(56122, [56123, 0], 99);
        ext.addTest(56122, [56123, 5], 99.99821);
        ext.addTest(56122, [56123, 5, false], 99.99821);
        ext.addTest(56122, [56123, 5, true], '99.99821%');
    }
});
function numberPercentOf(of, decimalPlaces, asString) {
    if (decimalPlaces === void 0) { decimalPlaces = 0; }
    if (asString === void 0) { asString = false; }
    if (asString) {
        if (of == 0)
            return '(?)%';
        else {
            return ((this / of) * 100).floor(decimalPlaces) + "%";
        }
    }
    else {
        if (this == of && of == 0)
            return 0;
        else if (of == 0)
            return this > 0 ? Infinity : -Infinity;
        else {
            return ((this / of) * 100).floor(decimalPlaces);
        }
    }
}
singNumber.method('formatFileSize', numberFormatFileSize, {
    summary: 'Takes a number (of Bytes) and returns a formatted string of the proper unit (B, KB, MB, etc)',
    parameters: [
        {
            name: 'decimalPlaces',
            types: [Number],
            description: 'Specify how many decimal places the output should have',
            defaultValue: 0
        },
        {
            name: 'useLongUnit',
            types: [Boolean],
            description: 'Specify a value of true to receive the output unit in long-form (Byte, Kilobyte, etc)',
            defaultValue: false
        }
    ],
    returns: 'A string representation of the calling number file size.',
    returnType: String,
    examples: ['\
            (1024).formatFileSize()    //  == \'1 KB\' \r\n\
            '],
    glyphIcon: '&#xe022;',
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
    }
});
function numberFormatFileSize(decimalPlaces, useLongUnit) {
    if (useLongUnit === void 0) { useLongUnit = false; }
    var units = useLongUnit ? ['Byte', 'Kilobyte', 'Megabyte', 'Gigabyte', 'Terabyte', 'Petabyte', 'Exabyte', 'Zettabyte', 'Yottabyte'] :
        ['B', 'KB', 'MB', 'GB', 'TB', 'PB', 'XB', 'ZB', 'YB'];
    var magnitude = 0;
    if (this < 0)
        return "0 " + units[magnitude];
    var outNumber = this;
    while (outNumber >= 1024) {
        outNumber = outNumber / 1024;
        magnitude++;
    }
    var out = outNumber.round(decimalPlaces) + " " + units[magnitude];
    if (useLongUnit &&
        (outNumber.floor() > 1 || outNumber.floor() == 0)) {
        out += 's';
    }
    return out;
}
singNumber.method('toStr', numberToStr, {
    summary: '\
        Common funciton - toStr is a standardized way of converting Objects to Strings.',
    parameters: [
        {
            name: 'includeMarkup',
            types: [Boolean],
            defaultValue: false
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
    glyphIcon: '&#xe047;',
    tests: function (ext) {
        ext.addTest(0, [], '0');
        ext.addTest(5, [], '5');
        ext.addTest(-100.105, [], '-100.105', 'Decimal numbers are supported.');
        ext.addTest(-100.100, [], '-100.1', 'Trailing 0s are not included.');
        ext.addTest(5.5, [], '5.5');
        ext.addTest(NaN, [], '');
        ext.addTest(NaN, [false], '');
        ext.addTest(NaN, [true], 'NaN');
    }
});
function numberToStr(includeMarkup) {
    if (includeMarkup === void 0) { includeMarkup = false; }
    if (isNaN(this))
        return includeMarkup ? 'NaN' : '';
    return this.toString();
}
singNumber.method('numericValueOf', numberNumericValueOf, {
    summary: 'Common funciton - Used for sorting, returns the calling number.',
    parameters: [],
    returns: 'Returns the calling number.',
    returnType: Number,
    examples: ['\
            (1.6).numericValueOf();                     //  == 1.6  \r\n\
            (1.6555).numericValueOf(2);                 //  == 1.6555  \r\n\
            (1.644999999999999).numericValueOf(2);      //  == 1.644999999999999  '],
    glyphIcon: '&#xe141;',
    tests: function (ext) {
        ext.addTest(1, [], 1);
        ext.addTest(0, [], 0);
        ext.addTest(Infinity, [], Infinity);
        ext.addTest(-Infinity, [], -Infinity);
    }
});
function numberNumericValueOf() {
    return this;
}
singNumber.method('numericValueOf', stringNumericValueOf, {
    summary: 'Common funciton - Convert all common objects to numeric values',
    parameters: [],
    returns: 'Returns the numeric value of the calling String',
    returnType: Number,
    examples: [],
    glyphIcon: '&#xe141;',
    tests: function (ext) {
        ext.addTest('hi', [], 26729);
        ext.addTest('hello', [], 448378203247);
    }
}, String.prototype, 'String');
function stringNumericValueOf() {
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
singNumber.method('numericValueOf', booleanToNumericValue, {
    summary: 'Common funciton - Convert all common objects to numeric values',
    parameters: [],
    returns: 'Returns the numeric value of the calling Boolean',
    returnType: Number,
    examples: [],
    glyphIcon: '&#xe141;',
    tests: function (ext) {
        ext.addTest(true, [], 1);
        ext.addTest(false, [], 0);
    }
}, Boolean.prototype, 'Boolean');
function booleanToNumericValue() {
    if (this.valueOf() === false)
        return 0;
    if (this.valueOf() === true)
        return 1;
}
singNumber.method('isInt', numberIsInt, {
    summary: 'Determine whether an object is an Integer.',
    parameters: [{
            name: 'obj',
            types: [Object],
            description: 'The object you want to test'
        }],
    returns: 'Returns whether the calling Object is an Integer. Returns false for Floats and non-numbers.',
    returnType: Boolean,
    examples: [],
    glyphIcon: '&#xe063;',
    tests: function (ext) {
        ext.addTest(null, [null], false);
        ext.addTest(null, [undefined], false);
        ext.addTest(null, [NaN], false);
        ext.addTest(null, ['a'], false);
        ext.addTest(null, ['1.5'], false);
        ext.addTest(null, [0], true);
        ext.addTest(null, [1], true);
        ext.addTest(null, [1.5], false);
        ext.addTest(null, [-1], true);
        ext.addTest(null, [Infinity], true);
        ext.addTest(null, [-Infinity], true);
    }
}, $);
function numberIsInt(obj) {
    return $.isNumber(obj) && obj.round().valueOf() == obj.valueOf();
}
singNumber.method('isFloat', numberIsFloat, {
    summary: 'Determine whether an object is a Float.',
    parameters: [{
            name: 'obj',
            types: [Object],
            description: 'The object you want to test'
        }],
    returns: 'Returns whether the calling Object is a Float. Returns false for Integers and non-numbers.',
    returnType: Boolean,
    examples: [],
    glyphIcon: '&#xe063;',
    tests: function (ext) {
        ext.addTest(null, [null], false);
        ext.addTest(null, [undefined], false);
        ext.addTest(null, [NaN], false);
        ext.addTest(null, ['a'], false);
        ext.addTest(null, ['1.5'], false);
        ext.addTest(null, [0], false);
        ext.addTest(null, [1], false);
        ext.addTest(null, [1.5], true);
        ext.addTest(null, [-1], false);
        ext.addTest(null, [Infinity], false);
        ext.addTest(null, [-Infinity], false);
    }
}, $);
function numberIsFloat(obj) {
    return $.isNumber(obj) && obj.round().valueOf() != obj.valueOf();
}
singNumber.method('isNumber', objectIsNumber, {
    summary: 'Determine whether an object is a number.',
    parameters: [{
            name: 'obj',
            types: [Object],
            description: 'The object you want to test'
        }],
    returns: 'Returns whether the calling Object is a Number',
    returnType: Boolean,
    examples: [],
    glyphIcon: '&#xe063;',
    tests: function (ext) {
        ext.addTest(null, [null], false);
        ext.addTest(null, [undefined], false);
        ext.addTest(null, [NaN], false);
        ext.addTest(null, ['a'], false);
        ext.addTest(null, ['1.5'], false);
        ext.addTest(null, [0], true);
        ext.addTest(null, [1], true);
        ext.addTest(null, [1.5], true);
        ext.addTest(null, [-1], true);
        ext.addTest(null, [Infinity], true);
        ext.addTest(null, [-Infinity], true);
    }
}, $);
function objectIsNumber(obj) {
    return !isNaN(obj) && typeof obj == 'number';
}
singNumber.method('random', numberRandom, {
    summary: 'Call $.random to produce a number of random numbers.',
    parameters: [
        {
            name: 'minimum',
            types: [Number],
            description: 'The minimum random value to be returned.',
            required: true
        },
        {
            name: 'maximum',
            types: [Number],
            description: 'The maximum random value to be returned.',
            required: true
        },
        {
            name: 'count',
            types: [Number],
            description: 'The number of random values to be returned'
        }
    ],
    returns: 'An array containing [count] of random numbers between [minimum] and [maximum]',
    returnType: Array,
    examples: ['$.random(1,10, 5)  // Returns an array of 5 numbers from 1 to 10.'],
    glyphIcon: '&#xe110;',
    tests: function (ext) {
        ext.addFailsTest($, [10, 0], 'maximum must be greater than minimum', 'Maxmimum must me greater than minimum');
        ext.addCustomTest(function () {
            var rand1 = $.random(0, 10);
            if (rand1 < 0 || rand1 > 10)
                return 'invalid random value';
            rand1 = $.random(-50, -20);
            if (rand1 < -50 || rand1 > -20)
                return 'invalid random value';
        }, 'Value must be in the correct range.');
        ext.addCustomTest(function () {
            var randoms = $.random(0, 10, 5);
            if (randoms.length != 5)
                return '5 items were not returned';
        }, 'Returns multiple random numbers correctly');
    }
}, $);
function numberRandom(minimum, maximum, count) {
    if (count === void 0) { count = 1; }
    if (maximum <= minimum)
        throw 'maximum must be greater than minimum';
    if (count == 0) {
        return null;
    }
    if (count == 1) {
        var rand = Math.random();
        var size = maximum - minimum;
        rand = rand * size;
        rand += minimum;
        return rand;
    }
    var out;
    if (count > 1) {
        out = [];
        while (count > 0) {
            out.push($.random(minimum, maximum, 1));
            count--;
        }
    }
    return out;
}
singNumber.method('isNumeric', stringIsNumeric, {
    summary: 'Call isNumeric on a String to determine if the string is in Numeric form. If the string is not a number false will be returned.',
    parameters: [],
    returns: 'A true value if the string represents a valid Number, otherwise false is returned.',
    returnType: Boolean,
    examples: [],
    glyphIcon: '&#xe063;',
    tests: function (ext) {
        ext.addTest('', [], false);
        ext.addTest('abc', [], false);
        ext.addTest('123', [], true);
        ext.addTest('-123', [], true);
        ext.addTest('123.456', [], true);
        ext.addTest('123.999', [], true);
        ext.addTest('2 > 5', [], false);
    }
}, String.prototype);
function stringIsNumeric() {
    if (this.length == 0)
        return false;
    var src = this.trim();
    if (src.hasMatch(/^.*([^\.\d\s-]).*$/))
        return false;
    try {
        var out = parseFloat(src);
        if (!isNaN(out))
            return true;
    }
    catch (ex) {
    }
    return false;
}
singNumber.method('isInteger', stringIsInteger, {
    summary: 'Call isInteger on a String to determine if the string is in Integer form. If the string is not a number or has a decimal value, false will be returned.',
    parameters: [],
    returns: 'A true value if the string represents a valid Integer, otherwise false is returned.',
    returnType: Boolean,
    examples: [],
    glyphIcon: '&#xe063;',
    tests: function (ext) {
        ext.addTest('', [], false);
        ext.addTest('abc', [], false);
        ext.addTest('123', [], true);
        ext.addTest('-123', [], true);
        ext.addTest('123.456', [], false);
        ext.addTest('123.999', [], false);
    }
}, String.prototype);
function stringIsInteger() {
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
singNumber.method('isEven', numberIsEven, {
    summary: 'Call isEven on a Number to determine if the number is an even Integer.',
    parameters: [],
    returns: 'A true value if the number is an even integer, false otherwise.',
    returnType: Boolean,
    glyphIcon: '&#xe063;',
    tests: function (ext) {
        ext.addTest((0), [], true);
        ext.addTest((0.00001), [], false);
        ext.addTest((1), [], false);
        ext.addTest((-1), [], false);
        ext.addTest((2), [], true);
        ext.addTest((-2), [], true);
        ext.addTest((2.000000000000001), [], false);
        ext.addTest((-2.000000000000001), [], false);
    }
});
function numberIsEven() {
    var thisNumber = this;
    return thisNumber % 2 == 0;
}
singNumber.method('isOdd', numberIsOdd, {
    summary: 'Call isOdd on a Number to determine if the number is an odd Integer.',
    parameters: [],
    returns: 'A true value if the number is an odd integer, false otherwise.',
    returnType: Boolean,
    glyphIcon: '&#xe063;',
    tests: function (ext) {
        ext.addTest((0), [], false);
        ext.addTest((1), [], true);
        ext.addTest((-1), [], true);
        ext.addTest((2), [], false);
        ext.addTest((-2), [], false);
        ext.addTest((3), [], true);
        ext.addTest((-3), [], true);
        ext.addTest((3.000000000000001), [], false);
        ext.addTest((-3.000000000000001), [], false);
    }
});
function numberIsOdd() {
    var thisNumber = this;
    return (thisNumber % 2).abs() == 1;
}
singNumber.method('toNumber', stringToNumber, {
    summary: 'Call toNumber on a String to try to convert the string to number form. If any decimal values are given they will be included in the result.',
    parameters: [],
    returns: 'A number value if the string represents a valid Number, otherwise NaN is returned.',
    returnType: Number,
    examples: [],
    glyphIcon: '&#xe141;',
    tests: function (ext) {
        ext.addTest('', [], NaN);
        ext.addTest('abc', [], NaN);
        ext.addTest('123', [], 123);
        ext.addTest('-123', [], -123);
        ext.addTest('123.456', [], 123.456);
        ext.addTest('123.999', [], 123.999);
    }
}, String.prototype);
function stringToNumber() {
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
singNumber.method('toInteger', stringToInteger, {
    summary: 'Call toInteger on a String to try to convert the string to integer form. If any decimal values are given they will be rounded down (floor).',
    parameters: [],
    returns: 'A number value if the string represents a valid Number, otherwise NaN is returned.',
    returnType: Number,
    examples: [],
    glyphIcon: '&#xe141;',
    tests: function (ext) {
        ext.addTest('', [], NaN);
        ext.addTest('abc', [], NaN);
        ext.addTest('123', [], 123);
        ext.addTest('-123', [], -123);
        ext.addTest('123.456', [], 123);
        ext.addTest('123.999', [], 123);
    }
}, String.prototype);
function stringToInteger() {
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
singNumber.method('total', arrayTotal, {
    summary: 'Call total on an array of numbers to get the total.',
    parameters: [],
    returns: 'The total of all the numbers in the array.',
    returnType: Number,
    examples: [],
    glyphIcon: '&#xe081;',
    tests: function (ext) {
        ext.addTest([], [], 0);
        ext.addTest([null], [], 0);
        ext.addTest([undefined], [], 0);
        ext.addTest([1.5], [], 1.5);
        ext.addTest([1, 2, 3], [], 6);
        ext.addTest([1, 2, 3, null], [], 6);
        ext.addTest([1, 2, 3, undefined], [], 6);
        ext.addTest([1, 2, 3, 'a'], [], 6);
        ext.addTest([1, 2, 3, -6], [], 0);
    }
}, Array.prototype);
function arrayTotal() {
    var thisArray = this;
    thisArray = thisArray.select(function (a) { return $.isNumber(a); });
    if (thisArray.length == 0)
        return 0;
    var out = 0;
    for (var i = 0; i < thisArray.length; i++) {
        var item = thisArray[i];
        if ($.isNumber(item)) {
            out += item;
        }
    }
    return out;
}
singNumber.method('average', arrayAverage, {
    summary: 'Call average on an array of numbers to get the average value',
    parameters: [],
    returns: 'The average of all the numbers in the array.',
    returnType: Number,
    examples: [],
    glyphIcon: '&#xe052;',
    tests: function (ext) {
        ext.addTest([], [], undefined);
        ext.addTest(['a'], [], undefined);
        ext.addTest([null], [], undefined);
        ext.addTest([1.5], [], 1.5);
        ext.addTest([1, 2, 3], [], 2);
        ext.addTest([1, 2, 3, 4, 5], [], 3);
        ext.addTest([1, 2, 3, 4, 5, 5], [], 3.3333333333333335);
        ext.addTest([1, 2, 3, 4, 5, 5, null], [], 3.3333333333333335);
        ext.addTest([1, 2, 3, 4, 5, 5, undefined], [], 3.3333333333333335);
        ext.addTest([1, 2, 3, -6], [], 0);
    }
}, Array.prototype);
function arrayAverage() {
    var thisArray = this;
    thisArray = thisArray.select(function (a) { return $.isNumber(a); });
    if (thisArray.length == 0)
        return null;
    var out = 0;
    for (var i = 0; i < thisArray.length; i++) {
        var item = thisArray[i];
        if ($.isNumber(item)) {
            out += item;
        }
    }
    return out / thisArray.length;
}
var singFunction = singExt.addModule(new sing.Module('Function', Function));
singFunction.glyphIcon = '&#xe019;';
singFunction.method('fnTry', functionTry, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    glyphIcon: '&#xe029;',
    tests: function (ext) {
        ext.addCustomTest(function () {
            (function () {
                throw 'fail';
            }).fnTry()();
        });
    }
});
function functionTry() {
    var source = this;
    return source.fnCatch();
}
singFunction.method('fnCatch', functionCatch, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    glyphIcon: '&#xe029;',
    tests: function (ext) {
        ext.addCustomTest(function () {
            var test = '';
            (function () {
                throw 'fail';
            }).fnCatch(function (ex) {
                test = ex;
            })();
            if (test != 'fail')
                return 'failed';
        });
    }
});
function functionCatch(catchFunction, logFailure) {
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
singFunction.method('fnLog', functionLog, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    manuallyTested: true,
    glyphIcon: '&#xe105;'
});
function functionLog(logAttempt, logSuccess, logFailure) {
    if (logAttempt === void 0) { logAttempt = true; }
    if (logSuccess === void 0) { logSuccess = true; }
    if (logFailure === void 0) { logFailure = true; }
    var thisFunction = this;
    return function () {
        try {
            if (logAttempt) {
                log(['Attempting: ', thisFunction.name, arguments]);
            }
            var result = thisFunction.apply(this, arguments);
            if (logSuccess) {
                log([("Completed: " + thisFunction.name), arguments, result]);
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
singFunction.method('fnCount', functionCount, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    glyphIcon: '&#xe141;',
    examples: null
});
function functionCount(logFailure) {
    if (logFailure === void 0) { logFailure = false; }
    var source = this;
    var functionCallCount = 0;
    return function () {
        try {
            var result = source.apply(this, arguments);
            log([source.name, ("count:" + functionCallCount)]);
            log([arguments, result]);
            return result;
        }
        catch (ex) {
            if (logFailure) {
                log(['FAILED', source.name, ex, ("count:" + functionCallCount)]);
                log([arguments]);
            }
            throw ex;
        }
    };
}
singFunction.method('fnCache', functionCache, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    glyphIcon: '&#xe121;',
    manuallyTested: true
});
function functionCache(uniqueCacheID, expiresAfter) {
    if (expiresAfter === void 0) { expiresAfter = 0; }
    var source = this;
    var cacheKeyLimit = 300;
    uniqueCacheID = uniqueCacheID || this.name;
    if (!uniqueCacheID)
        throw 'Unique ID not found';
    var ext = sing.methods['Singularity.Extensions.Function.fn_cache'];
    if (!ext.data)
        ext.data = {};
    if (!ext.data['cache'])
        ext.data['cache'] = {};
    return function () {
        var items = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            items[_i - 0] = arguments[_i];
        }
        var thisCaller = this;
        var cache = ext.data['cache'];
        if (!cache[uniqueCacheID])
            cache[uniqueCacheID] = {};
        var thisCache = cache[uniqueCacheID];
        var argStr = objectToStr(thisCaller) + "|||||||" + objectToStr(items);
        if (argStr.length > cacheKeyLimit) {
            return source.apply(thisCaller, items);
        }
        else {
            if (thisCache[argStr] != undefined &&
                thisCache[argStr] != null) {
                if (thisCache[argStr].expires < (new Date()).valueOf()) {
                    thisCache[argStr] = {};
                }
                else {
                    return thisCache[argStr].value;
                }
            }
            else {
                thisCache[argStr] = {};
            }
            var result = thisCache[argStr].value = source.apply(thisCaller, items);
            if (expiresAfter > 0) {
                thisCache[argStr].expires = (new Date()).valueOf() + expiresAfter;
            }
            return result;
        }
    };
}
singFunction.method('fnOr', functionOR, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    glyphIcon: '&#xe110;',
    tests: function (ext) {
        ext.addCustomTest(function () {
            var fnTest = (function (a) { return (a > 5); }).fnOR((function (a) { return (a < 0); }));
            if (!fnTest(-50) || !fnTest(50) || fnTest(2))
                return 'failed';
        });
    }
});
function functionOR(orFunc) {
    var source = this;
    return function () {
        var result1 = source.apply(this, arguments);
        var result2 = orFunc.apply(this, arguments);
        return result1 || result2;
    };
}
singFunction.method('fnIf', functionIf, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    glyphIcon: '&#xe063;',
    tests: function (ext) {
        ext.addCustomTest(function () {
            var a = 0;
            var fnTest = (function () {
                a++;
            }).fnIf((function (a) { return (a == 'GO'); }));
            fnTest('NO');
            if (a != 0)
                return 'failed';
            fnTest('GO');
            fnTest('GO');
            fnTest('GO');
            if (a != 3)
                return 'failed';
        });
    }
});
function functionIf(ifFunc) {
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
singFunction.method('fnUnless', functionUnless, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    glyphIcon: '&#xe063;',
    tests: function (ext) {
        ext.addCustomTest(function () {
            var a = 0;
            var fnTest = (function () {
                a++;
            }).fnUnless((function (a) { return (a == 'NO'); }));
            fnTest('NO');
            if (a != 0)
                return 'failed';
            fnTest('GO');
            fnTest('GO');
            fnTest('GO');
            if (a != 3)
                return 'failed';
        });
    }
});
function functionUnless(ifFunc) {
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
singFunction.method('fnThen', functionThen, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    glyphIcon: '&#xe095;',
    tests: function (ext) {
    }
});
function functionThen(thenFunc) {
    var srcThis = this;
    return function () {
        var items = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            items[_i - 0] = arguments[_i];
        }
        var out = srcThis.apply(this, items);
        if ($.isDefined(out))
            items.push(out);
        var out2 = thenFunc.apply(this, items);
        if ($.isDefined(out2))
            return out2;
        return out;
    };
}
singFunction.method('fnRepeat', functionRepeat, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    glyphIcon: '&#xe115;',
    tests: function (ext) {
    }
});
function functionRepeat(repeatOver) {
    var _this = this;
    var srcThis = this;
    if ($.isFunction(repeatOver)) {
        return function () {
            var items = [];
            for (var _i = 0; _i < arguments.length; _i++) {
                items[_i - 0] = arguments[_i];
            }
            var out = [];
            var result = repeatOver.apply(this, items);
            while (result != null) {
                out.push(result);
                result = repeatOver.apply(this, items);
            }
            return out;
        };
    }
    if ($.isNumber(repeatOver)) {
        return function () { return repeatOver.timesDo(_this); };
    }
    repeatOver = $.toArray(repeatOver);
    return function () {
        var items = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            items[_i - 0] = arguments[_i];
        }
        var out = [];
        var array = repeatOver;
        for (var repeat in array) {
            if ((array).hasOwnProperty(repeat)) {
                var args = items;
                args.push(repeat);
                var result = srcThis.apply(this, items);
                if (result != null)
                    out.push(result);
            }
        }
        return out;
    };
}
singFunction.method('fnWhile', functionWhile, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    glyphIcon: '&#xe030;',
    tests: function (ext) {
    }
});
function functionWhile(condition) {
    return function () {
        var items = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            items[_i - 0] = arguments[_i];
        }
        return this.fn_repeat(condition).apply(this, items);
    };
}
singFunction.method('fnRetry', functionRetry, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    glyphIcon: '&#xe031;',
    tests: function (ext) {
    }
});
function functionRetry(times) {
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
        throw "Failed " + times + " times with " + exception;
    };
}
singFunction.method('fnTime', functionTime, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    glyphIcon: '&#x231b;',
    tests: function (ext) {
    }
});
function functionTime() {
    var srcThis = this;
    return function () {
        var items = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            items[_i - 0] = arguments[_i];
        }
        var start = new Date().valueOf();
        srcThis.apply(this, items);
        var end = new Date().valueOf();
        var length = (end - start).max(0);
        log("Completed: " + srcThis.name + " in " + length + " milliseconds");
        return length;
    };
}
singFunction.method('fnDefer', functionDefer, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    glyphIcon: '&#xe234;',
    aliases: ['async'],
    tests: function (ext) {
    }
});
function functionDefer(callback) {
    var srcThis = this;
    return function () {
        var items = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            items[_i - 0] = arguments[_i];
        }
        setTimeout(function () {
            var result = srcThis.apply(srcThis, items);
            if (callback)
                callback(result);
        }, 1);
    };
}
singFunction.method('fnDelay', functionDelay, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    glyphIcon: '&#xe234;',
    tests: function (ext) {
    }
});
function functionDelay(delayMS, callback) {
    delayMS = delayMS.max(1);
    return function () {
        var items = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            items[_i - 0] = arguments[_i];
        }
        setTimeout(function () {
            var result = this.apply(this, items);
            if (callback)
                callback(result);
        }, delayMS);
    };
}
singFunction.method('fnBefore', functionBefore, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    glyphIcon: '&#xe070;',
    tests: function (ext) {
    }
});
function functionBefore(triggerFunc) {
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
singFunction.method('fnAfter', functionAfter, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    glyphIcon: '&#xe076;',
    tests: function (ext) {
    }
});
function functionAfter(triggerFunc) {
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
singFunction.method('fnWrap', functionWrap, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    glyphIcon: '&#xe102;',
    tests: function (ext) {
    }
});
function functionWrap(triggerFunc) {
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
singFunction.method('fnTrace', functionTrace, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    glyphIcon: '&#xe105;',
    tests: function (ext) {
    }
});
function functionTrace(traceStr) {
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
singFunction.method('fnRecurring', functionRecurring, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    glyphIcon: '&#xe031;',
    tests: function (ext) {
    }
});
function functionRecurring(intervalMS, breakCondition) {
    var srcThis = this;
    var minimum = 10;
    var runs = 0;
    intervalMS = intervalMS.max(minimum);
    var setTimer = function (src, items) {
        if ($.isNumber(breakCondition) && breakCondition > 0 && runs >= breakCondition)
            return;
        else if ($.isFunction(breakCondition) && breakCondition(items))
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
singFunction.method('executeAll', arrayExecuteAll, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    glyphIcon: '&#xe162;',
    tests: function (ext) {
    }
}, Array.prototype);
function arrayExecuteAll() {
    var _this = this;
    var items = [];
    for (var _i = 0; _i < arguments.length; _i++) {
        items[_i - 0] = arguments[_i];
    }
    if (!items.every($.isFunction))
        throw 'Not all items were functions';
    var out = items.collect(function (item) { return item.apply(_this, items); });
    return out;
}
singFunction.method('fnNot', functionNot, {
    glyphIcon: '&#xe126;'
});
function functionNot() {
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
var singArray = singExt.addModule(new sing.Module('Array', Array));
singArray.summaryShort = 'Extensions on the Array prototype';
singArray.summaryLong = 'Performs array manipulation functions on any type of Javascript Array.';
singArray.features = ['Shuffling arrays',
    'Random elements',
    'De-duplication',
    'Array indexing'];
singArray.glyphIcon = '&#xe236;';
singArray.method('splitAt', splitAt, {
    summary: 'Takes an array and splits it at the specified indexes.',
    parameters: [
        {
            name: 'indexes',
            description: 'The indexes to split the source Array.',
            isMulti: true,
            types: [Number],
            required: false
        }
    ],
    returns: 'A split group of arrays',
    returnType: Array,
    glyphIcon: '&#xe226;',
    tests: function (ext) {
        ext.addTest([], [], []);
        ext.addTest([], [null], []);
        ext.addTest([], [undefined], []);
        ext.addTest([], [0], []);
        ext.addTest([1], [0], [[1]]);
        ext.addTest([1, 2], [0], [[1, 2]]);
        ext.addTest([1, 2], [1], [[1], [2]]);
        ext.addTest([1, 2, 3, 4, 5, 6], [1, 3], [[1], [2, 3], [4, 5, 6]]);
    }
});
function splitAt() {
    var indexes = [];
    for (var _i = 0; _i < arguments.length; _i++) {
        indexes[_i - 0] = arguments[_i];
    }
    indexes = indexes.unique();
    indexes.sort();
    var thisArray = this;
    var out = [];
    var section = [];
    var indexI = 0;
    for (var i = 0; i < thisArray.length; i++) {
        if (indexes.length >= indexI) {
            if (i == indexes[indexI]) {
                if (section.length > 0)
                    out.push(section);
                section = [];
                indexI++;
            }
            section.push(thisArray[i]);
        }
    }
    if (!$.isEmpty(section))
        out.push(section);
    return out;
}
singArray.method('removeAt', arrayRemoveAt, {
    summary: 'Takes an array and returns a new array with the passed indexes removed.',
    parameters: [
        {
            name: 'indexes',
            description: 'The indexes to remove from the source Array.',
            isMulti: true,
            types: [Number],
            required: false
        }
    ],
    returns: 'An array with the passed indexes removed',
    returnType: Array,
    glyphIcon: '&#xe163;',
    tests: function (ext) {
        ext.addTest([], [], []);
        ext.addTest([], [null], []);
        ext.addTest([], [undefined], []);
        ext.addTest([], [0], []);
        ext.addTest([1], [0], []);
        ext.addTest([1, 2], [0], [2]);
        ext.addTest([1, 2], [1], [1]);
        ext.addTest([1, 2], [0, 1], []);
        ext.addTest([1, 2, 3, 4, 5, 6], [0, 1], [3, 4, 5, 6]);
        ext.addTest([1, 2, 3, 4, 5, 6], [0, 5], [2, 3, 4, 5]);
    }
});
function arrayRemoveAt() {
    var indexes = [];
    for (var _i = 0; _i < arguments.length; _i++) {
        indexes[_i - 0] = arguments[_i];
    }
    var thisArray = this;
    return thisArray.select(function (item, index) { return (!indexes.has(index)); });
}
singArray.method('unique', arrayUnique, {
    summary: 'Takes an array and returns only unique values, discarding duplicates.',
    parameters: [],
    returns: 'An array with unique values.',
    returnType: Array,
    glyphIcon: 'icon-snowflake',
    aliases: ['removeDuplicates'],
    tests: function (ext) {
        ext.addTest([], [], []);
        ext.addTest([null, undefined], [], []);
        ext.addTest([1, 2, 3], [], [1, 2, 3]);
        ext.addTest([1, 2, 3, 1, 2, 3], [], [1, 2, 3]);
        ext.addTest([1, 2, 3, 'a', 'b', 'c', 1, 2, 3, 'a', 'b', 'c'], [], [1, 2, 3, 'a', 'b', 'c']);
    }
});
function arrayUnique() {
    var thisArray = this;
    var out = [];
    thisArray.each(function (item) {
        if (!out.has(item) && $.isDefined(item))
            out.push(item);
    });
    return out;
}
singArray.method('random', arrayRandom, {
    summary: 'Takes an array and returns one or more random values from the source array.',
    parameters: [
        {
            name: 'count',
            defaultValue: 1,
            types: [Number]
        }
    ],
    returns: 'A single item if no count is supplied or count is 1. Otherwise an array of items is returned.',
    returnType: Object,
    glyphIcon: 'icon-playing-dices',
    tests: function (ext) {
        ext.addCustomTest(function () {
            var test = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20];
            var test2 = test.random();
            var test3 = test.random(5);
            if (!test.has(test2))
                return 'failed';
            if (test3.has(function (a) { return (!test.has(a)); }))
                return 'failed';
        });
    }
});
function arrayRandom(count) {
    if (count === void 0) { count = 1; }
    var thisArray = this;
    var out = [];
    count = count.min(thisArray.length);
    if (count == thisArray.length)
        return thisArray.shuffle();
    thisArray = thisArray.shuffle();
    while (out.length < count) {
        out.push((thisArray).shift());
    }
    return out;
}
singArray.method('shuffle', arrayShuffle, {
    summary: 'Takes an array and returns a new array with the original array values, shuffled.',
    parameters: [],
    returns: 'A new array with the original array values, shuffled',
    returnType: Array,
    glyphIcon: '&#xe110;',
    tests: function (ext) {
        ext.addCustomTest(function () {
            var test = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20];
            var test2 = test.shuffle();
            if (test == test2 || test2.length != test.length)
                return 'failed';
            if (test2.has(function (a) { return (!test.has(a)); }))
                return 'failed';
        });
    }
});
function arrayShuffle() {
    var thisArray = this;
    var out = [];
    while (thisArray.length > 0) {
        var rand = $.random(0, thisArray.length).floor();
        out.push(thisArray[rand]);
        thisArray = thisArray.remove(thisArray[rand]);
    }
    return out;
}
singArray.method('group', arrayGroup, {
    summary: 'Takes an array and groups the items using the key returned from the indexing function',
    returns: 'A Javascript hash object grouped by the indexing function.',
    returnType: Object,
    parameters: [
        {
            name: 'indexFunc',
            types: [Function]
        }
    ],
    glyphIcon: '&#xe032;',
    tests: function (ext) {
        ext.addTest([], [], []);
        ext.addTest([], [null], []);
        ext.addTest([1, 2, 3], [function () { }], { '': [1, 2, 3] });
        ext.addTest([1, 2, 3], [function (a) { return ("group" + a); }], { group1: [1], group2: [2], group3: [3] });
        ext.addTest([1, 2, 2, 3], [function (a) { return ("group" + a); }], { group1: [1], group2: [2, 2], group3: [3] });
    }
});
function arrayGroup(indexFunc) {
    var thisArray = this;
    var out = {};
    thisArray.each(function (item, index) {
        var key = indexFunc(item, index);
        key = key || '';
        if ($.isArray(out[key]))
            out[key].push(item);
        else
            out[key] = [item];
    });
    return out;
}
singArray.method('toArray', objToArray, {
    summary: 'Takes an object of any kind and returns it as an array. If no object is passed an empty array will be returned. \
            If an array is passed, it will be returned.',
    parameters: [
        {
            name: 'obj',
            types: [Object]
        }
    ],
    validateInput: false,
    returns: 'An array',
    returnType: Array,
    glyphIcon: '&#xe055;',
    tests: function (ext) {
        ext.addTest(null, [], []);
        ext.addTest(null, [null], []);
        ext.addTest(null, [undefined], []);
        ext.addTest(null, [0], [0]);
        ext.addTest(null, [[0, 1, 2]], [0, 1, 2]);
    }
}, $);
function objToArray(obj) {
    if (!$.isDefined(obj))
        return [];
    if ($.isArray(obj))
        return obj;
    else
        return [obj];
}
//# sourceMappingURL=singularity.js.map