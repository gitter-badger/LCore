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
declare function StringToSlug(): any;
declare function StringContainsAll(...items: string[]): boolean;
declare function StringPluralize(count: number): string;
declare function StringIsJSON(): boolean;
declare function StringParseJSON(): Object;
declare function StringFill(fillWith: string): any;
