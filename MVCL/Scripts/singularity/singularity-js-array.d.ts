/// <reference path="singularity-core.d.ts" />
/// <reference path="singularity-tests.d.ts" />
interface Array<T> {
    arrayValues?: (findKeys?: string | string[]) => any[];
    splitAt?: (...indexes: number[]) => T[];
    sortBy?: (arg?: string | string[] | ((item: T) => number)) => T[];
    orderBy?: (arg?: string | string[] | ((item: T) => number)) => T[];
    quickSort?: (sortWith?: any[][], left?: number, right?: number) => any[] | any[][];
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
declare function ArrayGroup<T>(keyFunc: (item: T, index: number) => string): Hash<T[]>;
declare function ObjToArray(obj: any): any;
