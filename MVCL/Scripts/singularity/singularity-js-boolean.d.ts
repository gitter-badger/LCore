/// <reference path="singularity-core.d.ts" />
interface Boolean {
    XOR?: (b: boolean) => boolean;
    toYesNo?: () => string;
    XNOR?: (b: boolean) => boolean;
    OR?: (...b: boolean[]) => boolean;
    AND?: (...b: boolean[]) => boolean;
    NAND?: (...b: boolean[]) => boolean;
    NOR?: (...b: boolean[]) => boolean;
    unary?: (obj?: any, obj2?: any) => any;
}
interface String {
    isBoolean?: () => boolean;
    toBoolean?: () => boolean;
}
declare var singBoolean: SingularityModule;
declare function BooleanXOR(b: boolean): boolean;
declare function BooleanXNOR(b: boolean): boolean;
declare function BooleanOR(...b: boolean[]): boolean;
declare function BooleanAND(...b: boolean[]): boolean;
declare function BooleanNAND(...b: boolean[]): boolean;
declare function BooleanNOR(...b: boolean[]): boolean;
declare function BooleanToYesNo(): string;
declare function BooleanUnary(obj?: any, obj2?: any): any;
declare function StringIsBoolean(): boolean;
declare function StringToBoolean(): boolean;
