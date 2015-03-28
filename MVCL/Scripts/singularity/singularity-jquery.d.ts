/// <reference path="singularity-core.d.ts" />
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
    getAttributes?: () => IKeyValue<string, string>[] | IKeyValue<string, string>[][];
    isOnScreen?: (x?: number, y?: number) => boolean;
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
