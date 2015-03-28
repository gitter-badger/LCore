/// <reference path="singularity-core.ts"/>
var singJQuery = singExt.addModule(new sing.Module("jQuery", [$, $.fn], $));
singJQuery.ignoreUnknown('ALL');
/*
//////////////////////////////////////////////////////
//
// jQuery Extensions
//
//
*/
singJQuery.method('checked', Checked, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: '',
    examples: null,
    tests: function (ext) {
    },
}, $.fn);
function Checked() {
    var anyChecked = false;
    this.each(function () {
        var thisJQuery = $(this);
        if (thisJQuery && thisJQuery[0] && thisJQuery[0].checked['checked'])
            anyChecked = true;
    });
    return anyChecked;
}
singJQuery.method('allVisible', AllVisible, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: '',
    examples: null,
    tests: function (ext) {
    },
}, $.fn);
function AllVisible() {
    var allVisible = true;
    this.each(function () {
        var opacity = $(this).attr('opacity');
        if (opacity == '0') {
            allVisible = false;
        }
        if ($(this).css('display') == 'none') {
            allVisible = false;
        }
    });
    return allVisible;
}
singJQuery.method('findIDNameSelector', FindIDNameSelector, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: '',
    examples: null,
    tests: function (ext) {
    },
}, $.fn);
function FindIDNameSelector(name) {
    var target = $();
    try {
        target = $(this).find('#' + name);
    }
    catch (ex) {
    }
    if (target.length == 0)
        try {
            target = $(this).find('[name=' + name + ']');
        }
        catch (ex) {
        }
    if (target.length == 0)
        try {
            target = $(this).find(name);
        }
        catch (ex) {
        }
    return target || $();
}
singJQuery.method('actionIf', ActionIf, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: '',
    examples: null,
    tests: function (ext) {
    },
}, $.fn);
function ActionIf(name) {
    var target = $(this);
    var ifTargetName = target.attr(name + '-if');
    // If there's no target, there's no condition to match. Always true.
    if (!ifTargetName)
        return true;
    var ifTarget = $('body').findIDNameSelector(ifTargetName);
    var targetValue = (target.attr(name + '-if-value') || '');
    var operation = function (a, b) {
        return a == b;
    };
    if (targetValue.indexOf('!=') == 0) {
        operation = function (a, b) {
            return a != b;
        };
        targetValue = targetValue.substr(2);
    }
    else if (targetValue.indexOf('>=') == 0) {
        operation = function (a, b) {
            return parseFloat(a) >= parseFloat(b);
        };
        targetValue = parseFloat(targetValue.substr(2));
    }
    else if (targetValue.indexOf('<=') == 0) {
        operation = function (a, b) {
            return parseFloat(a) <= parseFloat(b);
        };
        targetValue = parseFloat(targetValue.substr(2));
    }
    else if (targetValue.indexOf('><') == 0) {
        operation = function (a, b) {
            return parseFloat(a) >= parseFloat(b[0]) && parseFloat(a) <= parseFloat(b[1]);
        };
        targetValue = targetValue.substr(2);
        targetValue = [
            targetValue.split(',')[0],
            targetValue.split(',')[1],
        ];
    }
    else if (targetValue.indexOf('<>') == 0) {
        operation = function (a, b) {
            return parseFloat(a) <= parseFloat(b[0]) || parseFloat(a) >= parseFloat(b[1]);
        };
        targetValue = targetValue.substr(2);
        targetValue = [
            targetValue.split(',')[0],
            targetValue.split(',')[1],
        ];
    }
    else if (targetValue.indexOf(',') > 0) {
        operation = function (a, b) {
            return b.indexOf(a) >= 0;
        };
        targetValue = targetValue.split(',');
    }
    else if (targetValue.indexOf('!') == 0) {
        operation = function (a, b) {
            return parseFloat(a) != parseFloat(b);
        };
        targetValue = targetValue.substr(1);
    }
    else if (targetValue.indexOf('<') == 0) {
        operation = function (a, b) {
            return parseFloat(a) < parseFloat(b);
        };
        targetValue = parseFloat(targetValue.substr(1));
    }
    else if (targetValue.indexOf('>') == 0) {
        operation = function (a, b) {
            return parseFloat(a) > parseFloat(b);
        };
        targetValue = parseFloat(targetValue.substr(1));
    }
    if (ifTarget.length == 0) {
        return false;
    }
    else {
        var val = ifTarget.val();
        if (!targetValue) {
            if (ifTarget.attr('type') == 'checkbox')
                return ifTarget.checked();
            if (ifTarget.attr('type') == 'radio')
                return ifTarget.filter(':checked').length > 0;
            return val != null && val != '';
        }
        else {
            // Radio values can be combined with the use of custom numeric operators
            if (ifTarget.attr('type') == 'radio')
                return operation(ifTarget.filter(':checked').val(), targetValue);
            return operation(val, targetValue);
        }
    }
}
;
singJQuery.method('defer', Defer, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    aliases: ['wait'],
    examples: null,
    tests: function (ext) {
    },
});
function Defer(deferFunc) {
    if (deferFunc)
        setTimeout(deferFunc, 0);
}
singJQuery.method('hasAttr', JQueryHasAttr, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    tests: function (ext) {
    },
}, $.fn);
function JQueryHasAttr(name) {
    return $(this).attr(name) !== undefined;
}
singJQuery.method('outerHtml', JQueryOuterHtml, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    tests: function (ext) {
    },
}, $.fn);
function JQueryOuterHtml() {
    if (!this || this.length == 0) {
        return '';
    }
    else {
        return this[0].outerHTML;
    }
}
singJQuery.method('innerHtml', JQueryInnerHtml, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    tests: function (ext) {
    },
}, $.fn);
function JQueryInnerHtml() {
    if (!this || this.length == 0) {
        return '';
    }
    else {
        return this[0].innerHTML;
    }
}
// https://github.com/moagrius/isOnScreen
singJQuery.method('isOnScreen', JQueryIsOnScreen, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    tests: function (ext) {
    },
}, $.fn);
function JQueryIsOnScreen(x, y) {
    if (x === void 0) { x = 1; }
    if (y === void 0) { y = 1; }
    var win = $(window);
    var viewport = {
        top: win.scrollTop(),
        left: win.scrollLeft(),
        right: 0,
        bottom: 0,
    };
    viewport.right = viewport.left + win.width();
    viewport.bottom = viewport.top + win.height();
    var height = this.outerHeight();
    var width = this.outerWidth();
    if (!width || !height) {
        return false;
    }
    var bounds = this.offset();
    bounds.right = bounds.left + width;
    bounds.bottom = bounds.top + height;
    var visible = (!(viewport.right < bounds.left || viewport.left > bounds.right || viewport.bottom < bounds.top || viewport.top > bounds.bottom));
    if (!visible) {
        return false;
    }
    var deltas = {
        top: Math.min(1, (bounds.bottom - viewport.top) / height),
        bottom: Math.min(1, (viewport.bottom - bounds.top) / height),
        left: Math.min(1, (bounds.right - viewport.left) / width),
        right: Math.min(1, (viewport.right - bounds.left) / width)
    };
    return (deltas.left * deltas.right) >= x && (deltas.top * deltas.bottom) >= y;
}
;
//# sourceMappingURL=singularity-jquery.js.map