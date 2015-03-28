/// <reference path="singularity-core.d.ts" />
interface String {
    templateInject?: (obj: Object, _context?: Object) => string;
    templateExtract?: (template: string) => Object;
}
interface JQueryStatic {
    getTemplate?: (name: string, data?: Object) => JQuery;
}
interface JQuery {
    singIf?: (data?: any, _context?: Object, deferred?: boolean) => void;
    singFill?: (data?: any, _context?: Object, deferred?: boolean) => void;
    singLoop?: (data?: any, _context?: Object, deferred?: boolean) => void;
    fillTemplate?: (data: Object, _context?: Object, deferred?: boolean) => void;
}
interface ITemplateContext {
    name?: string;
    data: any;
}
declare var singTemplates: SingularityModule;
declare function StringExtract(template: string, obj: any): any;
declare function StringTemplateInject(obj: Object, _context?: Hash<any>): string;
declare function StringTemplateExtract(template: string): any;
declare function ObjectGetTemplate(name: string, data?: Object): JQuery;
declare function ObjectGetTemplateFor(obj?: Object): void;
declare var deferred: number;
declare var deferredDone: number;
declare function JQueryFillTemplate(data: any, _context?: Hash<any>, forceFill?: boolean): void;
declare function JQueryPerformSingIf(data?: any, _context?: Hash<any>, forceFill?: boolean): JQuery;
declare function JQueryPerformSingFill(data?: any, _context?: Hash<any>, forceFill?: boolean): JQuery;
declare function JQueryPerformSingLoop(data: any, _context?: Hash<any>, forceFill?: boolean): void;
