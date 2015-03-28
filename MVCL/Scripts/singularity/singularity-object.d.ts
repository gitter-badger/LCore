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
}
interface JQuery {
}
interface Array<T> {
    clone?: () => T[];
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
declare function ObjectHasKey(obj: Object, key: string): boolean;
declare function ObjectResolve(obj: any, args: any[]): any;
declare function ObjectDefined(obj?: any): boolean;
declare function ObjectIsHash(obj?: any): boolean;
declare function ArrayClone(): any;
declare function NumberClone(): any;
declare function BooleanClone(): any;
declare function StringClone(): any;
declare function DateClone(): any;
declare function ObjectClone(): any;
declare function ObjectIsEmpty(obj?: any): boolean;
declare function ObjectTypeName(obj?: any): any;
