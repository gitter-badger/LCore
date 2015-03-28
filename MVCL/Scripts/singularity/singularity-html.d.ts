/// <reference path="../definitions/jquery.d.ts" />
/// <reference path="../definitions/jqueryui.d.ts" />
/// <reference path="../definitions/jquery.cookie.d.ts" />
/// <reference path="../definitions/jquery.timepicker.d.ts" />
/// <reference path="../definitions/chance.d.ts" />
declare var singHTML: SingularityModule;
declare function StringTextToHTML(): string;
declare function StringStripHTML(): string;
declare function GetAttributes(): IKeyValue<string, string>[] | IKeyValue<string, string>[][];
declare function InitHTMLExtensions(): void;
declare function PropertyIf(propertyName: string, changeTrue?: (propertyTarget: JQuery) => void, changeFalse?: (propertyTarget: JQuery) => void): void;
declare function InitPropertyIf(): void;
declare function InitClickActions(): void;
declare function InitRememberPage(): void;
declare var keyCodeToChar: IndexHash<string>;
declare var keyCharToCode: Hash<number>;
declare function InitKeyBindClick(): void;
declare function InitFields(): void;
declare function RandomFields(): void;
