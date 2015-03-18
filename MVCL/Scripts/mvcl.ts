

function MNCL_Init() {

    tooltip.init();

}

function preg_quote(str) {

    return (str + '').replace(/([\\\.\+\*\?\[\^\]\$\(\)\{\}\=\!\<\>\|\:])/g, "\\$1");
}

interface Tooltip {
    init: () => void;
}

var tooltip: Tooltip;