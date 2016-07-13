/// <reference path="definitions/jquery.d.ts" />
/// <reference path="definitions/jqueryui.d.ts" />
/// <reference path="definitions/jquery.cookie.d.ts" />
/// <reference path="definitions/jquery.timepicker.d.ts" />
/// <reference path="definitions/chance.d.ts" />
interface Document {
    selection: any;
}
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
    modules: IHash<SingularityModule>;
    addModule(mod: SingularityModule): SingularityModule;
    methods: IHash<SingularityMethod>;
    templates: IHash<string>;
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
                Content: string;
                Loop: string;
                Fill: string;
                If: string;
                ElseIf: string;
                Else: string;
                Data: string;
                ShortIf: string;
                ShortElseIf: string;
                ShortElse: string;
                ShortFill: string;
                ShortLoop: string;
                ShortTemplate: string;
                ShortContent: string;
                ShortData: string;
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
        empty(): void;
        identity(obj: any): any;
        equals(obj: any, obj2: any): boolean;
        increment(i: number): number;
        booleanNot(obj: any): boolean;
        toString(obj: any): any;
    };
    autoDefaults: SingularityAutoDefinition;
    types: IHash<ISingularityType>;
    addType(name: string, addType: ISingularityType): void;
    defaultSettings: {
        requiredDocumentation: boolean;
        requiredGlyphIcons: boolean;
        requiredUnitTests: boolean;
        requiredJSFiddle: boolean;
    };
    init(): void;
    ready(): void;
    getType: (protoType: any) => ISingularityType;
    getTypeName(protoType: any | any[]): any;
    getTemplateName(protoType: any): string;
    globalResolve: IHash<any>;
    resolve: (key: string, data?: any, context?: Object, rootKey?: string) => any;
    loadContext: (context: IHash<any>) => IHash<any>;
    loadTemplate: (url: string, callback: (ms: number) => void) => void;
    initTemplates: () => void;
    totalCodeLines: () => number;
    templateShownFunctions: ((item: JQuery) => void)[];
    templateShown(fn: (item: JQuery) => void): void;
    tests: SingularityTests;
    getDocs: (funcName?: string, includeCode?: boolean, includeDocumentation?: boolean) => string;
    getSummary: (funcName?: string, includeFunctions?: boolean) => string;
    getMissing: (funcName?: string) => string;
    bbCodes: IBBCode[];
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
    features: ISingularityFeature[];
    resources: IHash<string>;
    parentModule: SingularityModule;
    subModules: SingularityModule[];
    methods: SingularityMethod[];
    properties: ISingularityParameter[];
    trackObjects: any[];
    ignoreUnknownMembers: string[];
    jsFiddleLinks: IHash<String>;
    addModule(mod: SingularityModule): SingularityModule;
    rootModule: () => SingularityModule;
    totalMethods(): number;
    implementedMethodCount(): number;
    implementedMethodTests(): number;
    implementedDocumentation(): number;
    implementedProperties(): number;
    totalProperties(): number;
    totalDocumentation(): number;
    passedMethodTests(): number;
    implementedMethodTestsTotal(): number;
    implementedJSFiddle(): number;
    totalJSFiddle(): number;
    implementedItems(): number;
    totalItems(): number;
    uninitializedMethods: {
        extName: string;
        method?: Function;
        details?: ISingularityMethodDetails;
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
    method(extName: string, method?: Function, details?: ISingularityMethodDetails, extendPrototype?: any, prefix?: string): void;
    property(name: string, param?: ISingularityParameter): void;
    ignore: (...items: string[]) => void;
    ignoreUnknown(...items: string[]): void;
    init(): void;
    fullName(): string;
    totalCodeLines: () => number;
    constructor(name: string, objectClass: any | any[], objectPrototype?: any);
}
declare class SingularityMethod {
    details: ISingularityMethodDetails;
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
    data: IHash<any>;
    methodModule: SingularityModule;
    auto: SingularityAutoDefinition;
    toString(): string;
    passedTests(): number;
    passesAllTests(): boolean;
    documentationComplete(): boolean;
    documentationPresent(): number;
    documentationTotal(): number;
    constructor(methodModule: SingularityModule, details?: ISingularityMethodDetails, target?: any, moduleName?: string, name?: string, method?: Function, prefix?: string);
    private loadAutoIgnoreErrors(ext, methods);
    private loadAutoLogErrors(ext, methods);
    private loadAutoLogExecution(ext, methods);
    private loadAutoTimeExecution(ext, methods);
    private loadAutoDefaultResult(ext, methods);
    private loadAutoOverrideResult(ext, methods);
    private loadAutoCacheResults(ext, methods);
    private loadAutoResultAsArray(ext, methods);
    private loadAutoMakeAsync(ext, methods);
    private loadAutoRetry(ext, methods);
    private loadInputValidation(ext, methods);
    private loadMethodCall(ext);
    isTested(): boolean;
    addTest: (caller: any, args: any[], result?: any, requirement?: string) => void;
    addCustomTest: (testFunc: () => any, requirement?: string) => void;
    addFailsTest: (caller: any, args: any[], expectedError?: string, requirement?: string) => void;
}
interface ISingularityMethodDetails {
    summary?: string;
    glyphIcon?: string;
    returns?: string;
    returnType?: INamed;
    returnTypeName?: string;
    examples?: string[];
    aliases?: string[];
    override?: boolean;
    auto?: SingularityAutoDefinition;
    validateInput?: boolean;
    parameters?: ISingularityParameter[];
    features?: ISingularityFeature[];
    manuallyTested?: boolean;
    manuallyTestedVersion?: number;
    tests?: (ext: SingularityMethod) => void;
    unitTests?: SingularityTest[];
    jsFiddleLinks?: IHash<String>;
}
interface ISingularityParameter {
    name?: string;
    defaultValue?: any;
    required?: boolean;
    isMulti?: boolean;
    types?: INamed[];
    glyphIcon?: string;
    description?: string;
}
interface ISingularityType {
    name: string;
    typeClass: any;
    protoType: any;
    glyphIcon: string;
    typeOfName?: string;
    templateName?: string;
    autoDefault: SingularityAutoDefinition;
}
interface ISingularityFeature {
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
declare function singularityTotalCodeLines(): number;
declare function singularityLoadContext(context: IHash<any>): Object;
declare function singularityResolve(key: string, data?: any, context?: IHash<any>, rootKey?: string): any;
declare var singCore: SingularityModule;
declare var singModule: SingularityModule;
declare function moduleTotalCodeLines(): number;
declare function moduleGetMethods(extName?: string): SingularityMethod[];
declare function moduleGetUnknownProperties(): string[];
declare function moduleGetUnknownMethods(): string[];
declare var singMethod: SingularityModule;
declare var singExt: SingularityModule;
interface IHashObject {
    [index: string]: any;
}
interface IHash<T> {
    [index: string]: T;
}
interface IIndexHash<U> {
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
declare function findMate(key: string, index: number): number;
declare function insertAtCaret(areaId: string, text: string): void;
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
    first(count: number): T[];
    first(item: T): T;
    first(condition: Function): T;
    first(condition: ((item: T, index: number) => boolean)): T;
    first(itemOrCountOrAction: number | T | ((item: T, index: number) => boolean)): T | T[];
    last(count: number): T[];
    last(item: T): T;
    last(condition: ((item: T, index: number) => boolean)): T;
    last(itemOrCountOrAction: number | T | ((item: T, index: number) => boolean)): T | T[];
}
interface Number {
    timesDo?: (executeFunc: () => void, args?: any[], caller?: any) => any[];
}
declare var singEnumerable: SingularityModule;
declare function enumerableEach<T>(action: (item: T, i: number) => void): void;
declare function enumerableWhile<T>(action: (item: T, index: number) => any): boolean;
declare function enumerableUntil<T>(action: (item: T, index: number) => any): boolean;
declare function enumerableCount<T>(itemOrAction: T | ((item: T, index: number) => any)): number;
declare function enumerableHas<T>(...items: T[]): any;
declare function enumerableSelect<T>(filter: (item: T, index: number) => boolean): T[];
declare function enumerableCollect<T>(collector: (item: T, index: number) => any): T[];
declare function enumerableFirst<T>(countOrCondition: number | ((item: T, index: number) => boolean)): T | T[];
declare function enumerableLast<T>(countOrCondition: number | ((item: T, index: number) => boolean)): T | T[];
declare function enumerableRange<T>(start?: number, end?: number): T[];
declare function enumerableFlatten(): any[];
declare function enumerableIndices<T>(...items: any[]): number[];
declare function enumerableRemove<T>(itemOrItemsOrFunction: T | T[] | ((item: T, index: number) => boolean)): T[];
declare function enumerableSortBy<T>(arg?: string | string[] | ((item: T) => any)): T[];
declare function enumerableQuickSort(sortWith?: any[][], left?: number, right?: number): any[] | IQuickSortResult;
interface IQuickSortResult {
    items: any[];
    sortWith: any[][];
}
declare function enumerableQuickSortPartition(items: any[], left?: number, right?: number, sortWith?: any[][]): {
    items: any[];
    sortWith: any[][];
    index: number;
};
declare function enumerableQuickSortSwap(items: any[], firstIndex: number, secondIndex: number, sortWith?: any[][]): {
    items: any[];
    sortWith: any[][];
};
declare function enumerableTimesDo(executeFunc: (...args: any[]) => any, args: any[], caller: any): any[];
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
declare var loggingInfoEnabled: boolean;
declare var loggingErrorEnabled: boolean;
declare var loggingWarningEnabled: boolean;
declare var singLog: SingularityModule;
declare function log(...message: any[]): void;
declare function arrayLog(): void;
declare function numberLog(): void;
declare function stringLog(): void;
declare function booleanLog(): void;
declare function warn(...message: any[]): void;
declare function arrayWarn(): void;
declare function numberWarn(): void;
declare function stringWarn(): void;
declare function booleanWarn(): void;
declare function error(...message: any[]): void;
declare function arrayError(): void;
declare function numberError(): void;
declare function stringError(): void;
declare function booleanError(): void;
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
declare function stringContains(str?: string): boolean;
declare var stringReplaceAllErrorReplacementContinsSearch: string;
declare function stringReplaceAll(searchOrSearches: string | string[], replaceOrReplacements: string | string[]): any;
declare function stringRemoveAll(stringOrStrings: string | string[]): any;
declare function stringUpper(): any;
declare function stringLower(): any;
declare function stringCollapseSpaces(): any;
declare function stringStartsWith(stringOrStrings: string | string[]): boolean;
declare function stringEndsWith(stringOrStrings: string | string[]): boolean;
declare function stringReverse(): string;
declare function stringRepeat(times?: number, separator?: string): string;
declare function stringWords(): any;
declare function stringLines(): any;
declare function stringSurround(str: string): any;
declare function stringTruncate(length: number): string;
declare function stringIsValidEmail(): boolean;
declare function stringIsHex(): boolean;
declare function stringIsValidUrl(): boolean;
declare function stringIsIpAddress(): boolean;
declare function stringIsGuid(): boolean;
declare function stringTryToNumber(defaultValue?: any): any;
declare function stringJoinLines(asHTML?: boolean): any;
declare function stringPad(length: number, align?: Direction, whitespace?: string): any;
declare function booleanToStr(includeMarkup?: boolean): string;
declare function objectToStr(obj: any, includeMarkup?: boolean, stack?: any[]): any;
declare function arrayToStr(includeMarkup?: boolean): string;
declare function stringToStr(includeMarkup?: boolean): any;
declare function isString(str?: any): boolean;
declare function stringFirst(count: number): any;
declare function stringLast(count: number): any;
declare function stringContainsAny(...items: string[]): boolean;
declare function stringBefore(search: string): any;
declare function stringAfter(search: string): any;
declare function stringBeforeLast(search: string): any;
declare function stringAfterFirst(search: string): any;
declare function stringToSlug(): string;
declare function stringContainsAll(...items: string[]): boolean;
declare function stringPluralize(count: number): string;
declare function stringIsJson(): boolean;
declare function stringParseJson(): Object;
declare function stringFill(fillWith: string): any;
declare function test(): string;
interface ITimePickerOptions {
    step?: number;
}
interface String {
    textToHTML?: () => string;
}
declare var singHTML: SingularityModule;
declare function stringTextToHTML(): string;
declare function stringStripHTML(): string;
declare function getAttributes(): IKeyValue<string, string>[] | IKeyValue<string, string>[][];
declare function initHTMLExtensions(): void;
declare var Identicon: any;
declare var jsSha: any;
declare function initIdent(): void;
declare function initHoverSrc(): void;
declare function propertyIf(propertyName: string, changeTrue?: (propertyTarget: JQuery) => void, changeFalse?: (propertyTarget: JQuery) => void): void;
declare function initPropertyIf(): void;
declare function initClickActions(): void;
declare function initRememberPage(): void;
declare var keyCodeToChar: IIndexHash<string>;
declare var keyCharToCode: IHash<number>;
declare var wysihtml5Editor: any;
declare function initKeyBindClick(): void;
declare function initFields(): void;
declare function randomFields(): void;
declare function objectToHtml(obj: any, parentKey?: string, context?: any): string;
declare function htmlToObject(html: string): string;
declare var testStructure: {
    html: {
        head: {
            title: string;
        };
        body: {
            '_example-attr': string;
            '_example-attr2'(): string;
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
                3(): string;
            };
            'div#example5': string;
            'div#example6'(): string;
            'div#example7'(): {
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
                'li.example': ({
                    _class: string;
                    _content: string;
                } | {
                    _content: string;
                })[];
            };
            'div#example14': {
                _content(c: any): any;
            };
            'div#example15'(c: any): any;
        };
    };
};
interface JQueryStatic {
    isString?: (obj: any) => boolean;
    defer?: (deferFunc: Function) => void;
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
declare function checked(): boolean;
declare function allVisible(): boolean;
declare function findIDNameSelector(name: string): JQuery;
declare function actionIf(name: string): boolean;
declare function defer(deferFunc: Function): void;
declare function jQueryHasAttr(name: string): boolean;
declare function jQueryOuterHtml(): string;
declare function jQueryInnerHtml(): string;
declare function jQueryIsOnScreen(x?: number, y?: number): boolean;
declare function jQuerySwapClass(class1: string, class2: string): JQuery;
declare function jQueryFadeClass(class1: string, class2: string, speed?: string | number, callback?: Function): JQuery;
declare function jQuerySuperFadeOut(speed?: string | number): JQuery;
declare function jQuerySuperFadeIn(speed?: string | number): JQuery;
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
declare function stringTemplateInject(obj: Object, _context?: IHash<any>): string;
declare function stringTemplateExtract(template: string): any;
declare function objectGetTemplate(name: string, data?: Object): JQuery;
declare function objectGetTemplateFor(): void;
declare var deferred: number;
declare var deferredDone: number;
declare function jQueryFillTemplate(data: any, _context?: IHash<any>, forceFill?: boolean): void;
declare function jQueryPerformSingIf(data?: any, _context?: IHash<any>): boolean;
declare function jQueryPerformSingFill(data?: any, _context?: IHash<any>, forceFill?: boolean, fillInside?: boolean): JQuery;
declare function jQueryPerformSingLoop(data: any, _context?: IHash<any>, forceFill?: boolean, fillInside?: boolean): void;
declare function jQueryTemplateError(ex: any, target: JQuery, data: any, _context: any): void;
declare function htmlTraverse(target: HTMLElement, action: (target: HTMLElement, root: HTMLElement) => void, root?: HTMLElement): void;
declare function jQueryTraverse(target: JQuery, action: (target: any, root: JQuery) => void, root?: JQuery): void;
declare function jQueryTraverseReplace(target: JQuery, action: (target: any, root: JQuery) => string, root?: JQuery): void;
declare function fillTemplateTraverse(target: JQuery, root: JQuery, data?: any, _context?: IHash<any>): void;
interface String {
    replaceRegExp?: (pattern: RegExp, replace?: RegExp) => string;
    hasMatch?: (pattern: RegExp) => boolean;
    matchCount?: (pattern: RegExp) => number;
    escapeRegExp?: () => string;
}
declare var singRegExp: SingularityModule;
declare function stringMatchCount(pattern: string): any;
declare function stringHasMatch(pattern: string): boolean;
declare function stringReplaceRegExp(pattern: RegExp, replace?: RegExp): string;
declare function stringEscapeRegExp(): string;
interface String {
    bbCodesToHTML?: () => string;
    bbCodesToText?: () => string;
}
interface IBBCode {
    name: string;
    tag: string;
    matchStr: RegExp;
    htmlStr: string;
    textStr: string;
    test: string;
}
declare var singBBCode: SingularityModule;
declare function stringBBCodesToHTML(): string;
declare function stringBBCodesToText(): string;
interface ISingularityDocs {
    getDocs?: (funcName?: string, includeCode?: boolean, includeDocumentation?: boolean) => string;
    getSummary?: (funcName?: string, includeFunctions?: boolean) => string;
    getMissing?: (funcName?: string) => string;
}
declare var singDocs: SingularityModule;
declare function singularityGetDocs(funcName?: string, includeCode?: boolean, includeDocumentation?: boolean): string;
declare function singularityGetMissing(funcName?: string): string;
declare function singularityGetSummary(funcName?: string, includeFunctions?: boolean): string;
interface JQueryStatic {
    objEach<T>(objHash: IHash<T>, eachFunc: (key: string, item: T, i: number) => any): any[];
    objEach(obj: any, eachFunc: (key: string, item: any, i: number) => any): any[];
    objProperties<T>(objHash?: IHash<T>): [{
        key: string;
        value: T;
    }];
    objProperties(obj?: any): [{
        key: string;
        value: any;
    }];
    objValues<T>(objHash?: IHash<T>): T[];
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
declare function objectEach(obj: IHash<any>, eachFunc: (key: string, item: any, index: number) => void): void;
declare function objectProperties(obj?: IHash<any>): {
    key: string;
    value: any;
}[];
declare function objectValues(obj?: IHash<any> | any[], findKeys?: string[]): any[];
declare function arrayFindValues<T>(...names: string[]): any[];
declare function objectKeys(obj?: Object): string[];
declare function objectHasKey(obj: any, key: string): boolean;
declare function objectResolve(obj: any, args: any[]): any;
declare function objectDefined(obj?: any): boolean;
declare function objectIsHash(obj?: any): boolean;
declare function arrayClone<T>(deepClone?: boolean): any[];
declare function numberClone(): any;
declare function booleanClone(): any;
declare function stringClone(): any;
declare function dateClone(): Date;
declare function objectClone(obj: any, deepClone?: boolean): any;
declare function objectIsEmpty(obj?: any): boolean;
declare function objectTypeName(obj?: any): any;
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
    resolveTests(): void;
}
declare class SingularityTest {
    name: string;
    tempFunc: Function;
    index: number;
    requirement: string;
    testFunc: Function;
    testResult: any;
    constructor(name: string, tempFunc: Function, index: number, requirement?: string);
}
declare var singTests: SingularityModule;
declare function singularityAddTest(name: string, testFunc: () => any, requirement?: string): void;
declare function singularityAddCustomTest(name: string, testFunc: Function, requirement?: string): void;
declare function singularityAddMethodTest(ext: SingularityMethod, target?: any, args?: any[], compare?: any, requirement?: string): void;
declare function singularityAddAssertTest(name: string, result: any, compare: any, requirement?: string): void;
declare function singularityAddFailsTest(ext: SingularityMethod, target: any, args: any[], expectedError?: string, requirement?: string): void;
declare function singularityRunTests(display?: boolean): string;
declare function singularityListTests(): string;
declare function singularityListMissingTests(): string;
declare function methodAddFailsTest(caller: any, args: any[], expectedError?: string, requirement?: string): void;
declare function methodAddCustomTest(testFunc: () => any, requirement?: string): void;
declare function methodAddSimpleTest(caller: any, args: any[], result?: any, requirement?: string): void;
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
declare function booleanXor(b: boolean): boolean;
declare function booleanXNOR(b: boolean): boolean;
declare function booleanOR(...b: boolean[]): boolean;
declare function booleanNOR(...b: boolean[]): boolean;
declare function booleanAND(...b: boolean[]): boolean;
declare function booleanNAND(...b: boolean[]): boolean;
declare function booleanToYesNo(): string;
declare function booleanTernary(obj?: any, obj2?: any): any;
declare function stringIsBoolean(): boolean;
declare function stringToBoolean(): boolean;
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
declare function numberMax(...numbers: number[]): number;
declare function numberMin(...numbers: number[]): number;
declare function numberRound(decimalPlaces: number): number;
declare function numberCeiling(decimalPlaces: number): number;
declare function numberFloor(decimalPlaces: number): number;
declare function numberPower(power: number): number;
declare function numberAbsoluteValue(): number;
declare function numberPercentOf(of: number, decimalPlaces?: number, asString?: boolean): number | string;
declare function numberFormatFileSize(decimalPlaces: number, useLongUnit?: boolean): string;
declare function numberToStr(includeMarkup?: boolean): any;
declare function numberNumericValueOf(): number;
declare function stringNumericValueOf(): number;
declare function booleanToNumericValue(): number;
declare function numberIsInt(obj: any): boolean;
declare function numberIsFloat(obj: any): boolean;
declare function objectIsNumber(obj: any): boolean;
declare function numberRandom(minimum: number, maximum: number, count?: number): number | number[] | void;
declare function stringIsNumeric(): boolean;
declare function stringIsInteger(): boolean;
declare function numberIsEven(): boolean;
declare function numberIsOdd(): boolean;
declare function stringToNumber(): number;
declare function stringToInteger(): number;
declare function arrayTotal(): number;
declare function arrayAverage(): number;
interface Date {
}
interface Function {
    fnTry?: <T>(logFailure?: boolean) => (...items: any[]) => T;
    fnCatch(catchFunction?: (ex: any) => void, logFailure?: boolean): Function;
    fnCatch<T>(catchFunction?: (ex: any) => void, logFailure?: boolean): (...items: any[]) => T;
    fnLog?: <T>(logAttempt?: boolean, logSuccess?: boolean, logFailure?: boolean) => (...items: any[]) => T;
    fnTime?: <T>() => (...items: any[]) => T;
    fnCount?: <T>(logFailure?: boolean) => (...items: any[]) => T;
    fnTrace?: <T>() => (...items: any[]) => T;
    fnCache<T>(uniqueCacheID: string, expiresAfter?: Date): (var1: T) => void;
    fnCache<T, U>(uniqueCacheID: string, expiresAfter?: Date): (var1: T) => U;
    fnCache<T, T2, U>(uniqueCacheID: string, expiresAfter?: Date): (var1: T, var2?: T2) => U;
    fnCache<T>(uniqueCacheID: string, expiresAfter?: Date): (...items: any[]) => T;
    fnIf?: (ifFunc: (...items: any[]) => boolean) => (...items: any[]) => any;
    fnUnless?: <T>(unlessFunc: (...items: any[]) => boolean) => (...items: any[]) => T;
    fnThen?: <T>(thenFunc: (...items: any[]) => any) => (...items: any[]) => T;
    fnRepeat<T>(times: number): (...items: any[]) => T;
    fnRepeat<T>(list: any[]): (...items: any[]) => T;
    fnRepeat<T>(repeatFn: (...items: any[]) => T): (...items: any[]) => T;
    fnWhile?: <T>(whileFunc: (...items: any[]) => boolean) => (...items: any[]) => T;
    fnUntil?: <T>(untilFunc: (...items: any[]) => boolean) => (...items: any[]) => T;
    fnRepeatEvery?: <T>(periodMS: number) => (...items: any[]) => T;
    fnRetry?: <T>(times: number) => (...items: any[]) => T;
    fnRecurring?: (intervalMs: number, breakCondition?: number | ((...items: any[]) => boolean)) => ((...items: any[]) => void);
    fnDefer?: <T>(callback?: (...items: any[]) => void) => () => T;
    fnDelay?: <T>(delayMs: number) => (...items: any[]) => T;
    fnAsync?: <T>(callback?: (...items: any[]) => void) => (...items: any[]) => T;
    fnWrap?: <T>(wrapper: (fn: (...items: any[]) => T, ...items: any[]) => T) => (...items: any[]) => T;
    fnOnExecute?: <T>(eventHandler: (...items: any[]) => void) => (...items: any[]) => T;
    fnOnExecuted?: <T>(eventHandler: (...items: any[]) => void) => (...items: any[]) => T;
    fnOR?: (orFunc: (...items: any[]) => boolean) => (...items: any[]) => boolean;
    fnAND?: (orFunc: (...items: any[]) => boolean) => (...items: any[]) => boolean;
    fnNot(): () => boolean;
    fnNot(): Function;
}
declare var singFunction: SingularityModule;
declare function functionTry(): Function;
declare function functionCatch(catchFunction: Function, logFailure?: boolean): Function;
declare function functionLog(logAttempt?: boolean, logSuccess?: boolean, logFailure?: boolean): () => any;
declare function functionCount(logFailure?: boolean): () => any;
declare function functionCache(uniqueCacheID: string, expiresAfter?: number): (...items: any[]) => any;
declare function functionOR(orFunc: (...items: any[]) => boolean): (...items: any[]) => boolean;
declare function functionIf<T>(ifFunc: (...items: any[]) => boolean): (...items: any[]) => any;
declare function functionUnless(ifFunc: (...items: any[]) => boolean): (...items: any[]) => any;
declare function functionThen(thenFunc: Function): Function;
declare function functionRepeat(repeatOver: number | any[] | ((...items: any[]) => boolean)): (...items: any[]) => any;
declare function functionWhile(condition: ((...items: any[]) => boolean)): (...items: any[]) => any;
declare function functionRetry(times?: number): (...items: any[]) => any;
declare function functionTime(): (...items: any[]) => number;
declare function functionDefer(callback?: Function): (...items: any[]) => void;
declare function functionDelay(delayMS: number, callback?: Function): (...items: any[]) => void;
declare function functionBefore(triggerFunc?: Function): (...items: any[]) => any;
declare function functionAfter(triggerFunc?: Function): (...items: any[]) => any;
declare function functionWrap(triggerFunc?: Function): (...items: any[]) => any;
declare function functionTrace(traceStr?: string): (...items: any[]) => any;
declare function functionRecurring(intervalMS: number, breakCondition?: number | ((...items: any[]) => boolean)): (...items: any[]) => void;
declare function arrayExecuteAll(...items: Function[]): any[];
declare function functionNot(): Function;
interface Array<T> {
    arrayValues?: (findKeys?: string | string[]) => any[];
    splitAt?: (...indexes: number[]) => T[];
    sortBy?: (arg?: string | string[] | ((item: T) => number)) => T[];
    orderBy?: (arg?: string | string[] | ((item: T) => number)) => T[];
    quickSort?: (sortWith?: any[][], left?: number, right?: number) => any[] | IQuickSortResult;
    removeAt?: (...indexes: number[]) => T[];
    unique?: (...indexes: number[]) => T[];
    random?: (count?: number) => T | T[];
    group?: (keyFunc: (item: any, index: number) => string) => IHash<T>;
}
interface JQueryStatic {
    toArray?: (obj: any) => any[];
}
declare var singArray: SingularityModule;
declare function splitAt<T>(...indexes: number[]): T[][];
declare function arrayRemoveAt<T>(...indexes: number[]): T[];
declare function arrayUnique<T>(): T[];
declare function arrayRandom<T>(count?: number): T[];
declare function arrayShuffle<T>(): T[];
declare function arrayGroup<T>(indexFunc: (item: T, index: number) => string): IHash<T[]>;
declare function objToArray(obj: any): any;
