/// <reference path="definitions/jquery.d.ts" />
/// <reference path="definitions/jqueryui.d.ts" />
/// <reference path="definitions/jquery.cookie.d.ts" />
/// <reference path="definitions/jquery.timepicker.d.ts" />
/// <reference path="definitions/chance.d.ts" />
declare class Singularity {
    summary: string;
    Module: typeof SingularityModule;
    Extension: typeof SingularityMethod;
    AutoDefinition: typeof SingularityAutoDefinition;
    enableTests: boolean;
    defaultPolyfill: boolean;
    totalExecutions: number;
    totalExecutionTime: number;
    topLevelMethod: boolean;
    modules: Hash<SingularityModule>;
    addModule: (mod: SingularityModule) => SingularityModule;
    methods: Hash<SingularityMethod>;
    templates: Hash<string>;
    constants: {
        IncludeURLs: {
            Style: string;
            StyleMin: string;
            Script: string;
            ScriptMin: string;
            templateCommon: string;
            jsFiddleRoot: string;
        };
        TemplatePatternStart: string;
        TemplatePatternEnd: string;
        TemplatePatternRegExpGlobal: RegExp;
        TemplatePatternRegExp: RegExp;
        specialTokens: {
            Context: string;
            Data: string;
            Global: string;
            Key: string;
            I: string;
            It: string;
            Item: string;
            Index: string;
            IsLast: string;
            IsFirst: string;
            Length: string;
        };
        htmlElement: {
            Error: string;
            Templates: {
                Element: string;
                Try: string;
                Catch: string;
            };
        };
        htmlAttr: {
            GoToRememberPage: string;
            EnableRememberPage: string;
            RememberPage: string;
            ErrorSrc: string;
            HoverSrc: string;
            FocusFirst: string;
            StaticSrc: string;
            Templates: {
                Template: string;
                Loop: string;
                Fill: string;
                If: string;
                ElseIf: string;
                Else: string;
                ShortIf: string;
                ShortElseIf: string;
                ShortElse: string;
                ShortFill: string;
                ShortLoop: string;
                ShortTemplate: string;
                Filled: string;
                Deferred: string;
                TemplateName: string;
                TemplateData: string;
                LoopInner: string;
                DataType: string;
                DeferID: string;
            };
            Click: {
                Animate: string;
                AnimateDuration: string;
                AnimateEasing: string;
                AnimateTarget: string;
                Show: string;
                Hide: string;
                Toggle: string;
                FadeIn: string;
                FadeOut: string;
                FadeToggle: string;
                AddClass: string;
                AddClassTarget: string;
                RemoveClass: string;
                RemoveClassTarget: string;
                ToggleClass: string;
                ToggleClassTarget: string;
                CtrlHref: string;
                ShiftHref: string;
                AltHref: string;
                DoubleHref: string;
                KeyBindClick: string;
                KeyBindClickName: string;
            };
        };
    };
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
    addType: (name: string, addType: SingularityType) => void;
    defaultSettings: {
        requiredDocumentation: boolean;
        requiredGlyphIcons: boolean;
        requiredUnitTests: boolean;
        requiredJSFiddle: boolean;
    };
    init: () => void;
    ready: () => void;
    getType: (protoType: any) => SingularityType;
    getTypeName: (protoType: any) => any;
    getTemplateName: (protoType: any) => string;
    globalResolve: Hash<any>;
    resolve: (key: string, data?: any, context?: Object, rootKey?: string) => any;
    loadContext: (context: Hash<any>) => Hash<any>;
    loadTemplate: (url: string, callback: (ms: number) => void) => void;
    initTemplates: () => void;
    totalCodeLines: () => number;
    templateShownFunctions: ((item: JQuery) => void)[];
    templateShown: (fn: (item: JQuery) => void) => void;
    tests: SingularityTests;
    getDocs: (funcName?: string, includeCode?: boolean, includeDocumentation?: boolean) => string;
    getSummary: (funcName?: string, includeFunctions?: boolean) => string;
    getMissing: (funcName?: string) => string;
    BBCodes: BBCode[];
}
declare class SingularityModule {
    name: string;
    objectClass: any | any[];
    objectPrototype: any;
    summaryShort: string;
    summaryLong: string;
    glyphIcon: string;
    srcLink: string;
    version: number;
    features: SingularityFeature[];
    resources: Hash<string>;
    parentModule: SingularityModule;
    subModules: SingularityModule[];
    methods: SingularityMethod[];
    properties: SingularityParameter[];
    trackObjects: any[];
    ignoreUnknownMembers: string[];
    jsFiddleLinks: Hash<String>;
    addModule: (mod: SingularityModule) => SingularityModule;
    rootModule: () => SingularityModule;
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
    requiredGlyphIcons: boolean;
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
    passedTests: () => number;
    passesAllTests: () => boolean;
    documentationComplete: () => boolean;
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
    isTested: () => boolean;
    addTest: (caller: any, args: any[], result?: any, requirement?: string) => void;
    addCustomTest: (testFunc: () => any, requirement?: string) => void;
    addFailsTest: (caller: any, args: any[], expectedError?: string, requirement?: string) => void;
}
interface SingularityMethodDetails {
    summary?: string;
    glyphIcon?: string;
    returns?: string;
    returnType?: INamed;
    returnTypeName?: string;
    examples?: string[];
    aliases?: string[];
    override?: boolean;
    auto?: SingularityAutoDefinition;
    parameters?: SingularityParameter[];
    features?: SingularityFeature[];
    manuallyTested?: boolean;
    manuallyTestedVersion?: number;
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
    glyphIcon?: string;
    description?: string;
}
interface SingularityType {
    name: string;
    typeClass: any;
    protoType: any;
    glyphIcon: string;
    typeOfName?: string;
    templateName?: string;
    autoDefault: SingularityAutoDefinition;
}
interface SingularityFeature {
    name: string;
    description?: string;
    tests?: (ext?: SingularityMethod) => void;
    unitTests?: SingularityTest[];
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
declare function SingularityResolve(key: string, data?: any, context?: Hash<any>, rootKey?: string): any;
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
declare class SingularityTests {
    testErrors: string[];
    addTest: (name: string, testFunc: () => any, requirement?: string) => void;
    addCustomTest: (name: string, testFunc: () => any, requirement?: string) => void;
    addMethodTest: (ext: SingularityMethod, target?: any, args?: any[], compare?: any, requirement?: string) => void;
    addAssertTest: (name: string, result: any, compare: any, requirement?: string) => void;
    addFailsTest: (ext: SingularityMethod, target: any, args: any[], expectedError?: string, requirement?: string) => void;
    runTests: (display: boolean) => string;
    listTests: () => string;
    listMissingTests: () => string;
    resolveTests: () => void;
    constructor();
}
declare class SingularityTest {
    name: string;
    testFunc: Function;
    index: number;
    requirement: string;
    testResult: any;
    constructor(name: string, testFunc: Function, index: number, requirement?: string);
}
declare var singTests: SingularityModule;
declare function SingularityAddTest(name: string, testFunc: () => any, requirement?: string): void;
declare function SingularityAddCustomTest(name: string, testFunc: Function, requirement?: string): void;
declare function SingularityAddMethodTest(ext: SingularityMethod, target?: any, args?: any[], compare?: any, requirement?: string): void;
declare function SingularityAddAssertTest(name: string, result: any, compare: any, requirement?: string): void;
declare function SingularityAddFailsTest(ext: SingularityMethod, target: any, args: any[], expectedError?: string, requirement?: string): void;
declare function SingularityRunTests(display?: boolean): string;
declare function SingularityListTests(): string;
declare function SingularityListMissingTests(): string;
declare function MethodAddFailsTest(caller: any, args: any[], expectedError?: string, requirement?: string): void;
declare function MethodAddCustomTest(testFunc: () => any, requirement?: string): void;
declare function MethodAddSimpleTest(caller: any, args: any[], result?: any, requirement?: string): void;
interface Array<T> {
    arrayValues?: (findKeys?: string | string[]) => any[];
    splitAt?: (...indexes: number[]) => T[];
    sortBy?: (arg?: string | string[] | ((item: T) => number)) => T[];
    orderBy?: (arg?: string | string[] | ((item: T) => number)) => T[];
    quickSort?: (sortWith?: any[][], left?: number, right?: number) => any[] | QuickSortResult;
    removeAt?: (...indexes: number[]) => T[];
    unique?: (...indexes: number[]) => T[];
    random?: (count?: number) => T | T[];
    group?: (keyFunc: (item: any, index: number) => string) => Hash<T>;
}
interface JQueryStatic {
    toArray?: (obj: any) => any[];
}
declare var singArray: SingularityModule;
declare function SplitAt<T>(...indexes: number[]): T[][];
declare function ArrayRemoveAt<T>(...indexes: number[]): T[];
declare function ArrayUnique<T>(): T[];
declare function ArrayRandom<T>(count?: number): T[];
declare function ArrayShuffle<T>(): T[];
declare function ArrayGroup<T>(indexFunc: (item: T, index: number) => string): Hash<T[]>;
declare function ObjToArray(obj: any): any;
interface Boolean {
    toYesNo?: () => string;
    XOR?: (b: boolean) => boolean;
    XNOR?: (b: boolean) => boolean;
    OR?: (...b: boolean[]) => boolean;
    AND?: (...b: boolean[]) => boolean;
    NAND?: (...b: boolean[]) => boolean;
    NOR?: (...b: boolean[]) => boolean;
    ternary?: (obj?: any, obj2?: any) => any;
}
interface String {
    isBoolean?: () => boolean;
    toBoolean?: () => boolean;
}
declare var singBoolean: SingularityModule;
declare function BooleanXOR(b: boolean): boolean;
declare function BooleanXNOR(b: boolean): boolean;
declare function BooleanOR(...b: boolean[]): boolean;
declare function BooleanNOR(...b: boolean[]): boolean;
declare function BooleanAND(...b: boolean[]): boolean;
declare function BooleanNAND(...b: boolean[]): boolean;
declare function BooleanToYesNo(): string;
declare function BooleanTernary(obj?: any, obj2?: any): any;
declare function StringIsBoolean(): boolean;
declare function StringToBoolean(): boolean;
interface Date {
}
interface ISingularityDocs {
    getDocs?: (funcName?: string, includeCode?: boolean, includeDocumentation?: boolean) => string;
    getSummary?: (funcName?: string, includeFunctions?: boolean) => string;
    getMissing?: (funcName?: string) => string;
}
declare var singDocs: SingularityModule;
declare function SingularityGetDocs(funcName?: string, includeCode?: boolean, includeDocumentation?: boolean): string;
declare function SingularityGetMissing(funcName?: string): string;
declare function SingularityGetSummary(funcName?: string, includeFunctions?: boolean): string;
interface Array<T> {
    each?: (action: (item?: T, index?: number) => void) => void;
    'while'?: (action: (item?: T, index?: number) => boolean) => void;
    indices?: (item: T | T[]) => T[];
    collect(): T[];
    collect<U>(convertFunc?: (item?: T, index?: number) => U): U[];
    collect(collectFunc?: (item?: T, index?: number) => any): any[];
    select(condition: (...items: any[]) => boolean): T[];
    select(condition: (item?: T) => boolean): T[];
    select(condition: (item?: T, index?: number) => boolean): T[];
    where?: (condition: (item?: T, index?: number) => boolean) => T[];
    range?: (start: number, finish: number) => T[];
    flatten?: () => T[];
    remove?: (item: T | T[] | ((a: T, b: number) => boolean)) => T[];
    count?: (item: T | T[] | ((arg: T, index: number) => boolean | number)) => number;
    has?: (item: T | T[] | ((arg: T, index: number) => boolean)) => boolean;
    shuffle?: () => T[];
    first<T>(count: number): T[];
    first<T>(item: T): T;
    first<T>(condition: Function): T;
    first<T>(condition: ((item: T, index: number) => boolean)): T;
    first<T>(itemOrCountOrAction: number | T | ((item: T, index: number) => boolean)): T | T[];
    last<T>(count: number): T[];
    last<T>(item: T): T;
    last<T>(condition: ((item: T, index: number) => boolean)): T;
    last<T>(itemOrCountOrAction: number | T | ((item: T, index: number) => boolean)): T | T[];
}
interface Number {
    timesDo?: (executeFunc: () => void, args?: any[], caller?: any) => any[];
}
declare var singEnumerable: SingularityModule;
declare function EnumerableEach<T>(action: (item: T, i: number) => void): void;
declare function EnumerableWhile<T>(action: (item: T, index: number) => any): boolean;
declare function EnumerableUntil<T>(action: (item: T, index: number) => any): boolean;
declare function EnumerableCount<T>(itemOrAction: T | ((item: T, index: number) => any)): number;
declare function EnumerableHas<T>(...items: T[]): any;
declare function EnumerableSelect<T>(filter: (item: T, index: number) => boolean): T[];
declare function EnumerableCollect<T>(collector: (item: T, index: number) => any): T[];
declare function EnumerableFirst<T>(countOrCondition: number | ((item: T, index: number) => boolean)): T | T[];
declare function EnumerableLast<T>(countOrCondition: number | ((item: T, index: number) => boolean)): T | T[];
declare function EnumerableRange<T>(start?: number, end?: number): T[];
declare function EnumerableFlatten(): any[];
declare function EnumerableIndices<T>(...items: any[]): number[];
declare function EnumerableRemove<T>(itemOrItemsOrFunction: T | T[] | ((item: T, index: number) => boolean)): T[];
declare function EnumerableSortBy<T>(arg?: string | string[] | ((item: T) => any)): T[];
declare function EnumerableQuickSort(sortWith?: any[][], left?: number, right?: number): any[] | QuickSortResult;
interface QuickSortResult {
    items: any[];
    sortWith: any[][];
}
declare function EnumerableQuickSortPartition(items: any[], left?: number, right?: number, sortWith?: any[][]): {
    items: any[];
    sortWith: any[][];
    index: number;
};
declare function EnumerableQuickSortSwap(items: any[], firstIndex: number, secondIndex: number, sortWith?: any[][]): {
    items: any[];
    sortWith: any[][];
};
declare function EnumerableTimesDo(executeFunc: (...args: any[]) => any, args: any[], caller: any): any[];
interface Function {
    fn_try?: <T>(logFailure?: boolean) => (...items: any[]) => T;
    fn_catch(catchFunction?: (ex: any) => void, logFailure?: boolean): Function;
    fn_catch<T>(catchFunction?: (ex: any) => void, logFailure?: boolean): (...items: any[]) => T;
    fn_log?: <T>(logAttempt?: boolean, logSuccess?: boolean, logFailure?: boolean) => (...items: any[]) => T;
    fn_time?: <T>() => (...items: any[]) => T;
    fn_count?: <T>(logFailure?: boolean) => (...items: any[]) => T;
    fn_trace?: <T>() => (...items: any[]) => T;
    fn_cache<T>(uniqueCacheID: string, expiresAfter?: Date): (var1: T) => void;
    fn_cache<T, U>(uniqueCacheID: string, expiresAfter?: Date): (var1: T) => U;
    fn_cache<T, T2, U>(uniqueCacheID: string, expiresAfter?: Date): (var1: T, var2?: T2) => U;
    fn_cache<T>(uniqueCacheID: string, expiresAfter?: Date): (...items: any[]) => T;
    fn_if?: (ifFunc: (...items: any[]) => boolean) => (...items: any[]) => any;
    fn_unless?: <T>(unlessFunc: (...items: any[]) => boolean) => (...items: any[]) => T;
    fn_then?: <T>(thenFunc: (...items: any[]) => any) => (...items: any[]) => T;
    fn_repeat<T>(times: number): (...items: any[]) => T;
    fn_repeat<T>(list: any[]): (...items: any[]) => T;
    fn_repeat<T>(repeat_fn: (...items: any[]) => T): (...items: any[]) => T;
    fn_while?: <T>(whileFunc: (...items: any[]) => boolean) => (...items: any[]) => T;
    fn_until?: <T>(untilFunc: (...items: any[]) => boolean) => (...items: any[]) => T;
    fn_repeatEvery?: <T>(periodMS: number) => (...items: any[]) => T;
    fn_retry?: <T>(times: number) => (...items: any[]) => T;
    fn_recurring?: (intervalMS: number, breakCondition?: number | ((...items: any[]) => boolean)) => ((...items: any[]) => void);
    fn_defer?: <T>(callback?: (...items: any[]) => void) => () => T;
    fn_delay?: <T>(delayMS: number) => (...items: any[]) => T;
    fn_async?: <T>(callback?: (...items: any[]) => void) => (...items: any[]) => T;
    fn_wrap?: <T>(wrapper: (fn: (...items: any[]) => T, ...items: any[]) => T) => (...items: any[]) => T;
    fn_onExecute?: <T>(eventHandler: (...items: any[]) => void) => (...items: any[]) => T;
    fn_onExecuted?: <T>(eventHandler: (...items: any[]) => void) => (...items: any[]) => T;
    fn_or?: (orFunc: (...items: any[]) => boolean) => (...items: any[]) => boolean;
    fn_and?: (orFunc: (...items: any[]) => boolean) => (...items: any[]) => boolean;
    fn_not(): () => boolean;
    fn_not(): Function;
}
declare var singFunction: SingularityModule;
declare function FunctionTry(): Function;
declare function FunctionCatch(catchFunction: Function, logFailure?: boolean): Function;
declare function FunctionLog(logAttempt?: boolean, logSuccess?: boolean, logFailure?: boolean): () => any;
declare function FunctionCount(logFailure?: boolean): () => any;
declare function FunctionCache(uniqueCacheID: string, expiresAfter?: number): (...items: any[]) => any;
declare function FunctionOR(orFunc: (...items: any[]) => boolean): (...items: any[]) => boolean;
declare function FunctionIf<T>(ifFunc: (...items: any[]) => boolean): (...items: any[]) => any;
declare function FunctionUnless(ifFunc: (...items: any[]) => boolean): (...items: any[]) => any;
declare function FunctionThen(thenFunc: Function): Function;
declare function FunctionRepeat(repeatOver: number | any[] | ((...items: any[]) => boolean)): (...items: any[]) => any;
declare function FunctionWhile(condition: ((...items: any[]) => boolean)): (...items: any[]) => any;
declare function FunctionRetry(times?: number): (...items: any[]) => any;
declare function FunctionTime(): (...items: any[]) => number;
declare function FunctionDefer(callback?: Function): (...items: any[]) => void;
declare function FunctionDelay(delayMS: number, callback?: Function): (...items: any[]) => void;
declare function FunctionBefore(triggerFunc?: Function): (...items: any[]) => any;
declare function FunctionAfter(triggerFunc?: Function): (...items: any[]) => any;
declare function FunctionWrap(triggerFunc?: Function): (...items: any[]) => any;
declare function FunctionTrace(traceStr?: string): (...items: any[]) => any;
declare function FunctionRecurring(intervalMS: number, breakCondition?: number | ((...items: any[]) => boolean)): (...items: any[]) => void;
declare function ArrayExecuteAll(...items: Function[]): any[];
declare function FunctionNot(): Function;
interface String {
    pad?: (length: number, align?: Direction) => string;
    lower?: () => string;
    upper?: () => string;
    replaceAll?: (find: string, replace?: string) => string;
    removeAll?: (find: string) => string;
    contains?: (search: string) => boolean;
    collapseSpaces?(): string;
    startsWith?: (search: string) => boolean;
    endsWith?: (search: string) => boolean;
    reverse?: () => string;
    repeat?: (times: number, separator?: string) => string;
    words?: () => string[];
    lines?: () => string[];
    surround?: (str: string) => string;
    truncate?: (length: number) => string;
    toStr?: (includeMarkup?: boolean) => string;
    tryToNumber?: (defaultValue?: any) => string | number;
    before?: (search: string) => string;
    after?: (search: string) => string;
    afterFirst?: (search: string) => string;
    beforeLast?: (search: string) => string;
    toSlug?: () => string;
    containsAny?: (...items: string[]) => boolean;
    containsAll?: (...items: string[]) => boolean;
    pluralize?: (count?: number) => string;
}
interface Boolean {
    toStr?: (includeMarkup?: boolean) => string;
}
interface Array<T> {
    joinLines?: () => string;
    toStr?: (includeMarkup?: boolean) => string;
}
interface JQueryStatic {
    toStr?: (obj: any, includeMarkup?: boolean, stack?: any[]) => string;
}
declare var singString: SingularityModule;
declare function StringContains(str?: string): boolean;
declare var StringReplaceAll_ErrorReplacementContinsSearch: string;
declare function StringReplaceAll(searchOrSearches: string | string[], replaceOrReplacements: string | string[]): any;
declare function StringRemoveAll(stringOrStrings: string | string[]): any;
declare function StringUpper(): any;
declare function StringLower(): any;
declare function StringCollapseSpaces(): any;
declare function StringStartsWith(stringOrStrings: string | string[]): boolean;
declare function StringEndsWith(stringOrStrings: string | string[]): boolean;
declare function StringReverse(): string;
declare function StringRepeat(times?: number, separator?: string): string;
declare function StringWords(): any;
declare function StringLines(): any;
declare function StringSurround(str: string): any;
declare function StringTruncate(length: number): string;
declare function StringIsValidEmail(): boolean;
declare function StringIsHex(): boolean;
declare function StringIsValidURL(): boolean;
declare function StringIsIPAddress(): boolean;
declare function StringIsGuid(): boolean;
declare function StringTryToNumber(defaultValue?: any): any;
declare function StringJoinLines(asHTML?: boolean): any;
declare function StringPad(length: number, align?: Direction, whitespace?: string): any;
declare function BooleanToStr(includeMarkup?: boolean): string;
declare function ObjectToStr(obj: any, includeMarkup?: boolean, stack?: any[]): any;
declare function ArrayToStr(includeMarkup?: boolean): string;
declare function StringToStr(includeMarkup?: boolean): any;
declare function IsString(str?: any): boolean;
declare function StringFirst(count: number): any;
declare function StringLast(count: number): any;
declare function StringContainsAny(...items: string[]): boolean;
declare function StringBefore(search: string): any;
declare function StringAfter(search: string): any;
declare function StringBeforeLast(search: string): any;
declare function StringAfterFirst(search: string): any;
declare function StringToSlug(): any;
declare function StringContainsAll(...items: string[]): boolean;
declare function StringPluralize(count: number): string;
declare function StringIsJSON(): boolean;
declare function StringParseJSON(): Object;
declare function StringFill(fillWith: string): any;
declare function Test(): string;
interface String {
    textToHTML?: () => string;
}
declare var singHTML: SingularityModule;
declare function StringTextToHTML(): string;
declare function StringStripHTML(): string;
declare function GetAttributes(): IKeyValue<string, string>[] | IKeyValue<string, string>[][];
declare function InitHTMLExtensions(): void;
declare var Identicon: any;
declare var jsSHA: any;
declare function InitIdent(): void;
declare function InitHoverSrc(): void;
declare function PropertyIf(propertyName: string, changeTrue?: (propertyTarget: JQuery) => void, changeFalse?: (propertyTarget: JQuery) => void): void;
declare function InitPropertyIf(): void;
declare function InitClickActions(): void;
declare function InitRememberPage(): void;
declare var keyCodeToChar: IndexHash<string>;
declare var keyCharToCode: Hash<number>;
declare var wysihtml5Editor: any;
declare function InitKeyBindClick(): void;
declare function InitFields(): void;
declare function RandomFields(): void;
declare function insertAtCaret(areaId: string, text: string): void;
declare function ObjectToHtml(obj: any, parentKey?: string, context?: any): string;
declare function HtmlToObject(html: string): string;
declare var testStructure: {
    html: {
        head: {
            title: string;
        };
        body: {
            '_example-attr': string;
            '_example-attr2': () => string;
            'span': {
                _class: string;
            };
            'span.example1': {};
            'div': {
                _classes: string[];
            };
            'div.class1.class2': {};
            'div.example2': {
                _id: string;
            };
            'div.example2#example2': {};
            'div#example3': {
                _content: {};
            };
            'div#example4': {
                0: {};
                1: any[];
                2: string;
                3: () => string;
            };
            'div#example5': string;
            'div#example6': () => string;
            'div#example7': () => {
                'ul': {
                    'li': string[];
                };
            };
            'div#example9': string[];
            'div.all-class#example10': string[];
            'div.all-class#example11': (string | (() => string) | {
                _class: string;
                _content: string;
            })[];
            'ul#example12': {
                'li': {
                    _class: string;
                    _content: string;
                }[];
            };
            'ul.example13': {
                'li.example': {
                    _content: string;
                }[];
            };
            'div#example14': {
                _content: (c: any) => any;
            };
            'div#example15': (c: any) => any;
        };
    };
};
interface JQueryStatic {
    isString?: (obj: any) => boolean;
    Defer?: (deferFunc: Function) => void;
}
interface JQuery {
    selectmenu(): JQuery;
    init?: (initFunc: () => void) => void;
    findIDNameSelector?: (name: string) => JQuery;
    checked?: () => boolean;
    allVisible?: () => boolean;
    actionIf?: (name: string) => boolean;
    outerHtml?: () => string;
    innerHtml?: () => string;
    hasAttr?: (name: string) => boolean;
    swapClass?: (class1: string, class2: string) => JQuery;
    getAttributes?: () => IKeyValue<string, string>[] | IKeyValue<string, string>[][];
    isOnScreen?: (x?: number, y?: number) => boolean;
    superFadeIn?: (speed?: string | number) => JQuery;
    superFadeOut?: (speed?: string | number) => JQuery;
}
declare var singJQuery: SingularityModule;
declare function Checked(): boolean;
declare function AllVisible(): boolean;
declare function FindIDNameSelector(name: string): JQuery;
declare function ActionIf(name: string): boolean;
declare function Defer(deferFunc: Function): void;
declare function JQueryHasAttr(name: string): boolean;
declare function JQueryOuterHtml(): string;
declare function JQueryInnerHtml(): string;
declare function JQueryIsOnScreen(x?: number, y?: number): boolean;
declare function JQuerySwapClass(class1: string, class2: string): JQuery;
declare function JQueryFadeClass(class1: string, class2: string, speed?: string | number, callback?: Function): JQuery;
declare function JQuerySuperFadeOut(speed?: string | number): JQuery;
declare function JQuerySuperFadeIn(speed?: string | number): JQuery;
interface Array<T> {
    log?: () => void;
}
interface Number {
    log?: () => void;
}
interface String {
    log?: () => void;
}
interface Boolean {
    log?: () => void;
}
declare var LOGGING_INFO_ENABLED: boolean;
declare var LOGGING_ERROR_ENABLED: boolean;
declare var LOGGING_WARNING_ENABLED: boolean;
declare var singLog: SingularityModule;
declare function log(...message: any[]): void;
declare function ArrayLog(): void;
declare function NumberLog(): void;
declare function StringLog(): void;
declare function BooleanLog(): void;
declare function warn(...message: any[]): void;
declare function ArrayWarn(): void;
declare function NumberWarn(): void;
declare function StringWarn(): void;
declare function BooleanWarn(): void;
declare function error(...message: any[]): void;
declare function ArrayError(): void;
declare function NumberError(): void;
declare function StringError(): void;
declare function BooleanError(): void;
interface Number {
    pow?: (power: number) => number;
    round?: (decimalPlaces?: number) => number;
    min?: (...items: number[]) => number;
    max?: (...items: number[]) => number;
    ceil?: (decimalPlaces?: number) => number;
    floor?: (decimalPlaces?: number) => number;
    formatFileSize?: (decimalPlaces: number, useLongUnit: boolean) => string;
    percentOf?: (value: number, decimalPlaces?: number, asPercent?: boolean) => number | string;
    abs?: () => number;
    toStr?: (includeMarkup?: boolean) => string;
    numericValueOf?: () => number;
}
interface JQueryStatic {
    isInt?: (num: any) => boolean;
    isFloat?: (num: any) => boolean;
    isNumber?: (num: any) => boolean;
    random(minimum: number, maximum: number, count?: number): number | number[];
}
interface String {
    toInteger?: () => number;
    toNumber?: () => number;
    isNumeric?: () => number;
    numericValueOf?: () => number;
}
interface Boolean {
    numericValueOf?: () => number;
}
interface Array<T> {
    total?: () => number;
    average?: () => number;
}
declare var singNumber: SingularityModule;
declare function NumberMax(...numbers: number[]): number;
declare function NumberMin(...numbers: number[]): number;
declare function NumberRound(decimalPlaces: number): number;
declare function NumberCeiling(decimalPlaces: number): number;
declare function NumberFloor(decimalPlaces: number): number;
declare function NumberPower(power: number): number;
declare function NumberAbsoluteValue(): number;
declare function NumberPercentOf(of: number, decimalPlaces?: number, asString?: boolean): number | string;
declare function NumberFormatFileSize(decimalPlaces: number, useLongUnit?: boolean): string;
declare function NumberToStr(includeMarkup?: boolean): any;
declare function NumberNumericValueOf(): number;
declare function StringNumericValueOf(): number;
declare function BooleanToNumericValue(): number;
declare function NumberIsInt(obj: any): boolean;
declare function NumberIsFloat(obj: any): boolean;
declare function ObjectIsNumber(obj: any): boolean;
declare function NumberRandom(minimum: number, maximum: number, count?: number): number | number[];
declare function StringIsNumeric(): boolean;
declare function StringIsInteger(): boolean;
declare function NumberIsEven(): boolean;
declare function NumberIsOdd(): boolean;
declare function StringToNumber(): number;
declare function StringToInteger(): number;
declare function ArrayTotal(): number;
declare function ArrayAverage(): number;
interface JQueryStatic {
    objEach<T>(objHash: Hash<T>, eachFunc: (key: string, item: T, i: number) => any): any[];
    objEach(obj: any, eachFunc: (key: string, item: any, i: number) => any): any[];
    objProperties<T>(objHash?: Hash<T>): [{
        key: string;
        value: T;
    }];
    objProperties(obj?: any): [{
        key: string;
        value: any;
    }];
    objValues<T>(objHash?: Hash<T>): T[];
    objValues(obj?: any): any[];
    objKeys?: (obj?: any) => string[];
    objHasKey?: (obj: Object, key: string) => boolean;
    resolve?: (obj?: Object | any[] | Function) => Object;
    isDefined?: (obj?: any) => boolean;
    isHash?: (obj?: any) => boolean;
    isEmpty?: (obj?: any) => boolean;
    typeName?: (obj?: any) => string;
    clone(obj: any, deepClone?: boolean): any;
    clone<T>(obj: T, deepClone?: boolean): T;
}
interface JQuery {
}
interface Array<T> {
    clone?: (deepClone?: boolean) => T[];
}
interface String {
    clone?: () => string;
}
interface Number {
    clone?: () => number;
}
interface Boolean {
    clone?: () => boolean;
}
interface Date {
    clone?: () => Date;
}
declare var singObject: SingularityModule;
declare function ObjectEach(obj: Hash<any>, eachFunc: (key: string, item: any, index: number) => void): void;
declare function ObjectProperties(obj?: Hash<any>): {
    key: string;
    value: any;
}[];
declare function ObjectValues(obj?: Hash<any> | any[], findKeys?: string[]): any[];
declare function ArrayFindValues<T>(...names: string[]): any[];
declare function ObjectKeys(obj?: Object): string[];
declare function ObjectHasKey(obj: any, key: string): boolean;
declare function ObjectResolve(obj: any, args: any[]): any;
declare function ObjectDefined(obj?: any): boolean;
declare function ObjectIsHash(obj?: any): boolean;
declare function ArrayClone<T>(deepClone?: boolean): any[];
declare function NumberClone(): any;
declare function BooleanClone(): any;
declare function StringClone(): any;
declare function DateClone(): Date;
declare function ObjectClone(obj: any, deepClone?: boolean): any;
declare function ObjectIsEmpty(obj?: any): boolean;
declare function ObjectTypeName(obj?: any): any;
interface String {
    replaceRegExp?: (pattern: RegExp, replace?: RegExp) => string;
    hasMatch?: (pattern: RegExp) => boolean;
    matchCount?: (pattern: RegExp) => number;
    escapeRegExp?: () => string;
}
declare var singRegExp: SingularityModule;
declare function StringMatchCount(pattern: string): any;
declare function StringHasMatch(pattern: string): boolean;
declare function StringReplaceRegExp(pattern: RegExp, replace?: RegExp): string;
declare function StringEscapeRegExp(): string;
interface String {
    templateInject?: (obj: Object, _context?: Object) => string;
    templateExtract?: (template: string) => Object;
}
interface JQueryStatic {
    getTemplate?: (name: string, data?: Object) => JQuery;
}
interface JQuery {
    singIf?: (data?: any, _context?: Object, forceFill?: boolean) => boolean;
    singFill?: (data?: any, _context?: Object, forceFill?: boolean, fillInside?: boolean) => void;
    singLoop?: (data?: any, _context?: Object, forceFill?: boolean, fillInside?: boolean) => void;
    fillTemplate?: (data: Object, _context?: Object, forceFill?: boolean) => void;
}
interface ITemplateContext {
    name?: string;
    data: any;
}
declare var singTemplates: SingularityModule;
declare function StringTemplateInject(obj: Object, _context?: Hash<any>): string;
declare function StringTemplateExtract(template: string): any;
declare function ObjectGetTemplate(name: string, data?: Object): JQuery;
declare function ObjectGetTemplateFor(obj?: Object): void;
declare var deferred: number;
declare var deferredDone: number;
declare function JQueryFillTemplate(data: any, _context?: Hash<any>, forceFill?: boolean): void;
declare function JQueryPerformSingIf(data?: any, _context?: Hash<any>, forceFill?: boolean): boolean;
declare function JQueryPerformSingFill(data?: any, _context?: Hash<any>, forceFill?: boolean, fillInside?: boolean): JQuery;
declare function JQueryPerformSingLoop(data: any, _context?: Hash<any>, forceFill?: boolean, fillInside?: boolean): void;
declare function JQueryTemplateError(ex: any, target: JQuery, data: any, _context: any): void;
declare function HtmlTraverse(target: HTMLElement, action: (target: HTMLElement, root: HTMLElement) => void, root?: HTMLElement): void;
declare function JQueryTraverse(target: JQuery, action: (target: any, root: JQuery) => void, root?: JQuery): void;
declare function JQueryTraverseReplace(target: JQuery, action: (target: any, root: JQuery) => string, root?: JQuery): void;
declare function FillTemplateTraverse(target: JQuery, root: JQuery, data?: any, _context?: Hash<any>): void;
interface String {
    bbCodesToHTML?: () => string;
    bbCodesToText?: () => string;
}
interface BBCode {
    name: string;
    tag: string;
    matchStr: RegExp;
    htmlStr: string;
    textStr: string;
    test: string;
}
declare var singBBCode: SingularityModule;
declare function StringBBCodesToHTML(): string;
declare function StringBBCodesToText(): string;
