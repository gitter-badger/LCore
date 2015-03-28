/// <reference path="singularity-core.d.ts" />
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
declare function NumberRound(decimalPlaces: number): number;
declare function NumberPower(power: number): number;
declare function NumberCeiling(decimalPlaces: number): number;
declare function NumberFloor(decimalPlaces: number): number;
declare function NumberFormatFileSize(decimalPlaces: number, useLongUnit?: boolean): string;
declare function NumberAbsoluteValue(): number;
declare function NumberPercentOf(of: number, decimalPlaces?: number, asString?: boolean): number | string;
declare function NumberToStr(includeMarkup?: boolean): any;
declare function NumberIsInt(num: any): boolean;
declare function NumberIsFloat(num: any): boolean;
declare function ObjectIsNumber(num: any): boolean;
declare function NumberNumericValueOf(): number;
declare function StringNumericValueOf(): number;
declare function BooleanToNumericValue(): number;
declare function NumberRandom(minimum: number, maximum: number, count?: number): number | number[];
declare function StringIsNumeric(): boolean;
declare function StringIsInteger(): boolean;
declare function StringToNumber(): number;
declare function StringToInteger(): number;
declare function ArrayTotal(): number;
declare function ArrayAverage(): void;
