/// <reference path="../definitions/jquery.d.ts" />
/// <reference path="../definitions/jqueryui.d.ts" />
/// <reference path="../definitions/jquery.cookie.d.ts" />
/// <reference path="singularity-enumerable.d.ts" />
/// <reference path="singularity-js-number.d.ts" />
/// <reference path="singularity-js-string.d.ts" />
/// <reference path="singularity-js-array.d.ts" />
/// <reference path="singularity-js-function.d.ts" />
/// <reference path="singularity-js-boolean.d.ts" />
/// <reference path="singularity-jquery.d.ts" />
/// <reference path="singularity-html.d.ts" />
/// <reference path="singularity-tests.d.ts" />
/// <reference path="singularity-doc.d.ts" />
declare class Singularity {
    summary: string;
    Module: typeof SingularityModule;
    Extension: typeof SingularityMethod;
    AutoDefinition: typeof SingularityAutoDefinition;
    enableTests: boolean;
    defaultPolyfill: boolean;
    modules: Hash<SingularityModule>;
    addModule: (mod: SingularityModule) => SingularityModule;
    methods: Hash<SingularityMethod>;
    templates: Hash<string>;
    func: {
        empty: () => void;
        identity: (obj: any) => any;
        equals: (obj: any, obj2: any) => boolean;
        increment: (i: number) => number;
        booleanNot: (obj: any) => boolean;
        toString: (obj: any) => any;
    };
    autoDefaults: SingularityAutoDefinition;
    types: Hash<SingularityType>;
    autoDefault: SingularityAutoDefinition;
    defaultSettings: {
        requiredDocumentation: boolean;
        requiredUnitTests: boolean;
        requiredJSFiddle: boolean;
    };
    init: () => void;
    ready: () => void;
    getTypeName: (protoType: any) => any;
    getTemplateName: (protoType: any) => string;
    globalResolve: Hash<any>;
    resolveKey: (key: string, data?: any, context?: Object, rootKey?: string) => any;
    loadContext: (context: Hash<any>) => Hash<any>;
    loadTemplate: (url: string, callback: Function) => void;
    initTemplates: () => void;
    totalCodeLines: () => number;
    templateShownFunctions: ((item: JQuery) => void)[];
    templateShown: (fn: (item: JQuery) => void) => void;
    tests: SingularityTests;
    getDocs: (funcName?: string, includeCode?: boolean, includeDocumentation?: boolean) => string;
    getSummary: (funcName?: string, includeFunctions?: boolean) => string;
    getMissing: (funcName?: string) => string;
    BBCodes: BBCode[];
    templatePatternGlobal: RegExp;
    templatePattern: RegExp;
    templateStart: string;
    templateEnd: string;
}
declare class SingularityModule {
    name: string;
    objectClass: any | any[];
    objectPrototype: any;
    summaryShort: string;
    summaryLong: string;
    features: string[];
    resources: Hash<string>;
    parentModule: SingularityModule;
    subModules: SingularityModule[];
    methods: SingularityMethod[];
    properties: SingularityParameter[];
    trackObjects: any[];
    ignoreUnknownMembers: string[];
    addModule: (mod: SingularityModule) => SingularityModule;
    totalMethods: () => number;
    implementedMethodCount: () => number;
    implementedMethodTests: () => number;
    implementedDocumentation: () => number;
    implementedProperties: () => number;
    totalProperties: () => number;
    totalDocumentation: () => number;
    passedMethodTests: () => number;
    implementedMethodTestsTotal: () => number;
    implementedJSFiddle: () => number;
    totalJSFiddle: () => number;
    implementedItems: () => any;
    totalItems: () => any;
    uninitializedMethods: {
        extName: string;
        method?: Function;
        details?: SingularityMethodDetails;
        extendPrototype: any;
        prefix: string;
    }[];
    getMethods: (extName?: string) => SingularityMethod[];
    getUnknownMethods: () => string[];
    getUnknownProperties: () => string[];
    requiredJSFiddle: boolean;
    requiredDocumentation: boolean;
    requiredUnitTests: boolean;
    method: (extName: string, method?: Function, details?: SingularityMethodDetails, extendPrototype?: any, prefix?: string) => void;
    property: (name: string, param?: SingularityParameter) => void;
    ignore: (...items: string[]) => void;
    ignoreUnknown: (...items: string[]) => void;
    init: () => void;
    fullName: () => any;
    totalCodeLines: () => number;
    constructor(name: string, objectClass: any | any[], objectPrototype?: any);
}
declare class SingularityMethod {
    details: SingularityMethodDetails;
    isAlias: boolean;
    shortName: string;
    name: string;
    moduleName: string;
    target: string;
    targetType: INamed;
    methodCall: string;
    codeLines: number;
    prefix: string;
    method: Function;
    methodOriginal: Function;
    data: Hash<any>;
    methodModule: SingularityModule;
    auto: SingularityAutoDefinition;
    toString: () => any;
    documentationPresent: () => number;
    documentationTotal: () => number;
    constructor(methodModule: SingularityModule, details?: SingularityMethodDetails, target?: any, moduleName?: string, name?: string, method?: Function, prefix?: string);
    private loadAutoIgnoreErrors;
    private loadAutoLogErrors;
    private loadAutoLogExecution;
    private loadAutoTimeExecution;
    private loadAutoDefaultResult;
    private loadAutoOverrideResult;
    private loadAutoCacheResults;
    private loadAutoResultAsArray;
    private loadAutoMakeAsync;
    private loadAutoRetry;
    private loadInputValidation;
    private loadMethodCall;
    addTest: (caller: any, args: any[], result?: any, requirement?: string) => void;
    addCustomTest: (testFunc: () => any, requirement?: string) => void;
    addFailsTest: (caller: any, args: any[], expectedError?: string, requirement?: string) => void;
}
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
    jsFiddleLinks?: Hash<String>;
}
interface SingularityParameter {
    name?: string;
    defaultValue?: any;
    required?: boolean;
    isMulti?: boolean;
    types?: INamed[];
    description?: string;
}
interface SingularityType {
    name: string;
    typeClass: any;
    protoType: any;
    typeOfName?: string;
    templateName?: string;
    autoDefault: SingularityAutoDefinition;
}
declare class SingularityAutoDefinition {
    validateInput: boolean;
    injectDefaultInputValue: boolean;
    ignoreErrors: boolean;
    logErrors: boolean;
    logExecution: boolean;
    timeExecution: boolean;
    makeAsync: boolean;
    cacheResults: boolean;
    retryTimes: number;
    resultAsArray: boolean;
    defaultResult: any;
    overrideResult: any;
    constructor(source?: SingularityAutoDefinition);
}
declare var sing: Singularity;
declare var singRoot: SingularityModule;
declare function SingularityTotalCodeLines(): number;
declare function SingularityLoadContext(context: Hash<any>): Object;
declare function SingularityResolveKey(key: string, data?: any, context?: Hash<any>, rootKey?: string): any;
declare var singCore: SingularityModule;
declare var singModule: SingularityModule;
declare function ModuleTotalCodeLines(): number;
declare function ModuleGetMethods(extName?: string): SingularityMethod[];
declare function ModuleGetUnknownProperties(): string[];
declare function ModuleGetUnknownMethods(): string[];
declare var singMethod: SingularityModule;
declare var singExt: SingularityModule;
interface HashObject {
    [index: string]: any;
}
interface Hash<T> {
    [index: string]: T;
}
interface IndexHash<U> {
    [index: number]: U;
}
interface INamed {
    name: string;
}
interface IKeyValue<TKey, TValue> {
    key: TKey;
    value: TValue;
}
interface Object extends INamed {
}
declare class Direction {
    static left: string;
    static right: string;
    static center: string;
    static l: string;
    static r: string;
    static c: string;
}
