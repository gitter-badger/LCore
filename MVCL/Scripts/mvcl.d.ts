declare function MVCL_Init(): void;
declare function preg_quote(str: string): string;
interface Tooltip {
    init: () => void;
}
declare var tooltip: Tooltip;
