/// <reference path="singularity-core.d.ts" />
interface ISingularityDocs {
    getDocs?: (funcName?: string, includeCode?: boolean, includeDocumentation?: boolean) => string;
    getSummary?: (funcName?: string, includeFunctions?: boolean) => string;
    getMissing?: (funcName?: string) => string;
}
declare var singDocs: SingularityModule;
declare function SingularityGetDocs(funcName?: string, includeCode?: boolean, includeDocumentation?: boolean): string;
declare function SingularityGetMissing(funcName?: string): string;
declare function SingularityGetSummary(funcName?: string, includeFunctions?: boolean): string;
