/// <reference path="singularity-core.d.ts" />
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
declare function EnumerableContains<T>(...items: T[]): any;
declare function EnumerableSelect<T>(action: (item: T, index: number) => boolean): T[];
declare function EnumerableCollect<T>(action: (item: T, index: number) => any): T[];
declare function EnumerableFirst<T>(itemOrAction: number | T | ((item: T, index: number) => boolean)): T | T[];
declare function EnumerableLast<T>(itemOrAction: number | T | ((item: T, index: number) => boolean)): T | T[];
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
