/// <reference path="singularity-core.d.ts" />
interface Array<T> {
    log?: () => void;
}
interface Number {
    log?: () => void;
}
interface String {
    log?: () => void;
}
interface Boolean {
    log?: () => void;
}
declare var LOGGING_INFO_ENABLED: boolean;
declare var LOGGING_ERROR_ENABLED: boolean;
declare var LOGGING_WARNING_ENABLED: boolean;
declare var singLog: SingularityModule;
declare function log(...message: any[]): void;
declare function ArrayLog(): void;
declare function NumberLog(): void;
declare function StringLog(): void;
declare function BooleanLog(): void;
declare function warn(...message: any[]): void;
declare function ArrayWarn(): void;
declare function NumberWarn(): void;
declare function StringWarn(): void;
declare function BooleanWarn(): void;
declare function error(...message: any[]): void;
declare function ArrayError(): void;
declare function NumberError(): void;
declare function StringError(): void;
declare function BooleanError(): void;
