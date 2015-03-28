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
    repeat?: (times: number) => string;
    words?: () => string[];
    lines?: () => string[];
    surround?: (str: string) => string;
    truncate?: (length: number) => string;
    toStr?: (includeMarkup?: boolean) => string;
    textToHTML?: () => string;
    tryToNumber?: (defaultValue?: any) => string | number;
    before?: (search: string) => string;
    after?: (search: string) => string;
    toSlug?: () => string;
}
interface Boolean {
    toStr?: (includeMarkup?: boolean) => string;
}
interface Array<T> {
    joinLines?: () => string;
    toStr?: (includeMarkup?: boolean) => string;
}
interface JQueryStatic {
    toStr?: (obj: any, includeMarkup?: boolean) => string;
}
declare var singString: SingularityModule;
declare function StringContains(str?: string): boolean;
declare var StringReplaceAll_ErrorReplacementContinsSearch: string;
declare function StringReplaceAll(searchOrSearches: string | string[], replaceOrReplacements: string | string[]): any;
declare function StringUpper(): any;
declare function StringLower(): any;
declare function StringCollapseSpaces(): any;
declare function StringStartsWith(stringOrStrings: string | string[]): boolean;
declare function StringEndsWith(stringOrStrings: string | string[]): boolean;
declare function StringRemoveAll(stringOrStrings: string | string[]): any;
declare function StringReverse(): string;
declare function StringRepeat(times?: number): string;
declare function StringWords(): any;
declare function StringLines(): any;
declare function StringSurround(str: string): any;
declare function StringTruncate(length: number): any;
declare function StringIsValidEmail(): boolean;
declare function StringIsHex(): boolean;
declare function StringIsValidURL(): boolean;
declare function StringIsIPAddress(): boolean;
declare function StringIsGuid(): boolean;
declare function StringTryToNumber(defaultValue?: any): any;
declare function StringJoinLines(asHTML?: boolean): any;
declare function StringPad(length: number, align?: Direction, whitespace?: string): any;
declare function BooleanToStr(includeMarkup?: boolean): string;
declare function ToStr(obj: any, includeMarkup?: boolean): any;
declare function ArrayToStr<T>(includeMarkup?: boolean): string;
declare function StringToStr(includeMarkup?: boolean): any;
declare function IsString(str?: any): boolean;
declare function StringFirst(count: number): any;
declare function StringLast(count: number): any;
declare function StringContainsAny(...items: string[]): boolean;
declare function StringBefore(search: string): any;
declare function StringAfter(search: string): any;
declare function StringToSlug(): any;
