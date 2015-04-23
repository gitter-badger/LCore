

function MVCL_Init() {

    tooltip.init();

}

function preg_quote(str) {

    return (str + '').replace(/([\\\.\+\*\?\[\^\]\$\(\)\{\}\=\!\<\>\|\:])/g, "\\$1");
}

var Tooltip;