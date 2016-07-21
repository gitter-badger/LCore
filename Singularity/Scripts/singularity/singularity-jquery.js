/// <reference path="singularity-core.ts"/>
var singJQuery = singExt.addModule(new sing.Module('jQuery', [$, $.fn], $));
singJQuery.glyphIcon = '&#xe148;';
singJQuery.ignoreUnknown('ALL');
/*
//////////////////////////////////////////////////////
//
// jQuery Extensions
//
//
*/
singJQuery.method('checked', checked, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: '',
    examples: null,
    glyphIcon: '&#xe013;',
    tests: function (ext) {
    }
}, $.fn);
function checked() {
    var anyChecked = false;
    this.each(function () {
        var thisJQuery = $(this);
        if (thisJQuery && thisJQuery[0] && thisJQuery[0].checked['checked'])
            anyChecked = true;
    });
    return anyChecked;
}
singJQuery.method('allVisible', allVisible, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: '',
    examples: null,
    glyphIcon: '&#xe105;',
    tests: function (ext) {
    }
}, $.fn);
function allVisible() {
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
singJQuery.method('findIDNameSelector', findIDNameSelector, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: '',
    examples: null,
    glyphIcon: '&#xe003;',
    tests: function (ext) {
    }
}, $.fn);
function findIDNameSelector(name) {
    var target = $();
    try {
        target = $(this).find("#" + name);
    }
    catch (ex) { }
    if (target.length == 0)
        try {
            target = $(this).find("[name=" + name + "]");
        }
        catch (ex) { }
    if (target.length == 0)
        try {
            target = $(this).find(name);
        }
        catch (ex) { }
    return target || $();
}
singJQuery.method('actionIf', actionIf, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: '',
    examples: null,
    glyphIcon: '&#xe162;',
    tests: function (ext) {
    }
}, $.fn);
function actionIf(name) {
    var target = $(this);
    var ifTargetName = target.attr(name + "-if");
    // If there's no target, there's no condition to match. Always true.
    if (!ifTargetName)
        return true;
    var ifTarget = $('body').findIDNameSelector(ifTargetName);
    var targetValue = (target.attr(name + "-if-value") || '');
    var operation = function (a, b) { return (a == b); };
    if (targetValue.indexOf('!=') == 0) {
        operation = function (a, b) { return (a != b); };
        targetValue = targetValue.substr(2);
    }
    else if (targetValue.indexOf('>=') == 0) {
        operation = function (a, b) { return (parseFloat(a) >= parseFloat(b)); };
        targetValue = parseFloat(targetValue.substr(2));
    }
    else if (targetValue.indexOf('<=') == 0) {
        operation = function (a, b) { return (parseFloat(a) <= parseFloat(b)); };
        targetValue = parseFloat(targetValue.substr(2));
    }
    else if (targetValue.indexOf('><') == 0) {
        operation = function (a, b) { return (parseFloat(a) >= parseFloat(b[0]) && parseFloat(a) <= parseFloat(b[1])); };
        targetValue = targetValue.substr(2);
        targetValue = [
            targetValue.split(',')[0],
            targetValue.split(',')[1]
        ];
    }
    else if (targetValue.indexOf('<>') == 0) {
        operation = function (a, b) { return (parseFloat(a) <= parseFloat(b[0]) || parseFloat(a) >= parseFloat(b[1])); };
        targetValue = targetValue.substr(2);
        targetValue = [
            targetValue.split(',')[0],
            targetValue.split(',')[1]
        ];
    }
    else if (targetValue.indexOf(',') > 0) {
        operation = function (a, b) { return (b.indexOf(a) >= 0); };
        targetValue = targetValue.split(',');
    }
    else if (targetValue.indexOf('!') == 0) {
        operation = function (a, b) { return (parseFloat(a) != parseFloat(b)); };
        targetValue = targetValue.substr(1);
    }
    else if (targetValue.indexOf('<') == 0) {
        operation = function (a, b) { return (parseFloat(a) < parseFloat(b)); };
        targetValue = parseFloat(targetValue.substr(1));
    }
    else if (targetValue.indexOf('>') == 0) {
        operation = function (a, b) { return (parseFloat(a) > parseFloat(b)); };
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
singJQuery.method('defer', defer, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    aliases: ['wait'],
    examples: null,
    glyphIcon: '&#xe095;',
    tests: function (ext) {
    }
});
function defer(deferFunc) {
    if (deferFunc)
        setTimeout(deferFunc, 0);
}
singJQuery.method('hasAttr', jQueryHasAttr, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    glyphIcon: '&#xe042;',
    tests: function (ext) {
    }
}, $.fn);
function jQueryHasAttr(name) {
    return $(this).attr(name) !== undefined;
}
singJQuery.method('outerHtml', jQueryOuterHtml, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    glyphIcon: '&#xe140;',
    tests: function (ext) {
    }
}, $.fn);
function jQueryOuterHtml() {
    if (this.length == 0) {
        return '';
    }
    else {
        return this[0].outerHTML;
    }
}
singJQuery.method('innerHtml', jQueryInnerHtml, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    glyphIcon: '&#xe087;',
    tests: function (ext) {
    }
}, $.fn);
function jQueryInnerHtml() {
    if (this.length == 0) {
        return '';
    }
    else {
        return this[0].innerHTML;
    }
}
// https://github.com/moagrius/isOnScreen
singJQuery.method('isOnScreen', jQueryIsOnScreen, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    glyphIcon: '&#xe106;',
    tests: function (ext) {
    }
}, $.fn);
function jQueryIsOnScreen(x, y) {
    if (x === void 0) { x = 1; }
    if (y === void 0) { y = 1; }
    var win = $(window);
    var viewport = {
        top: win.scrollTop(),
        left: win.scrollLeft(),
        right: 0,
        bottom: 0
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
    var visible = (!(viewport.right < bounds.left ||
        viewport.left > bounds.right ||
        viewport.bottom < bounds.top ||
        viewport.top > bounds.bottom));
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
singJQuery.method('swapClasses', jQuerySwapClass, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    glyphIcon: '&#xe110;',
    tests: function (ext) {
    }
}, $.fn);
function jQuerySwapClass(class1, class2) {
    var thisJQuery = this;
    if (true) {
        if (thisJQuery.hasClass(class1)) {
            thisJQuery.removeClass(class1);
            thisJQuery.addClass(class2);
        }
        else if (thisJQuery.hasClass(class2)) {
            thisJQuery.removeClass(class2);
            thisJQuery.addClass(class1);
        }
        else {
            thisJQuery.addClass(class1);
        }
    }
    return thisJQuery;
}
;
singJQuery.method('fadeClasses', jQueryFadeClass, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    glyphIcon: '',
    tests: function (ext) {
    }
}, $.fn);
function jQueryFadeClass(class1, class2, speed, callback) {
    if (speed === void 0) { speed = 'fast'; }
    var thisJQuery = this;
    if (true) {
        if (thisJQuery.hasClass(class1)) {
            thisJQuery.fadeOut(speed, function () {
                thisJQuery.removeClass(class1);
                thisJQuery.addClass(class2);
                thisJQuery.fadeIn(speed, function () {
                    if (callback)
                        callback();
                });
            });
        }
        else if (thisJQuery.hasClass(class2)) {
            thisJQuery.fadeOut(speed, function () {
                thisJQuery.removeClass(class2);
                thisJQuery.addClass(class1);
                thisJQuery.fadeIn(speed, function () {
                    if (callback)
                        callback();
                });
            });
        }
        else {
            thisJQuery.fadeOut(speed, function () {
                thisJQuery.addClass(class1);
                thisJQuery.fadeIn(speed, function () {
                    if (callback)
                        callback();
                });
            });
        }
    }
    return thisJQuery;
}
;
singJQuery.method('superFadeOut', jQuerySuperFadeOut, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    glyphIcon: '',
    tests: function (ext) {
    }
}, $.fn);
function jQuerySuperFadeOut(speed) {
    if (speed === void 0) { speed = 'fast'; }
    var thisJQuery = this;
    thisJQuery.each(function () {
        var jElement = $(this);
        jElement.data('old-opacity', jElement.css('opacity'));
        jElement.data('old-height', jElement.css('height'));
        jElement.data('old-margin-top', jElement.css('margin-top'));
        jElement.data('old-margin-bottom', jElement.css('margin-bottom'));
        jElement.data('old-margin-left', jElement.css('margin-left'));
        jElement.data('old-margin-right', jElement.css('margin-right'));
        jElement.data('old-padding-top', jElement.css('padding-top'));
        jElement.data('old-padding-bottom', jElement.css('padding-bottom'));
        jElement.data('old-padding-left', jElement.css('padding-left'));
        jElement.data('old-padding-right', jElement.css('padding-right'));
        jElement.animate({
            opacity: 0,
            height: 0,
            padding: 0,
            margin: 0
        }, speed);
    });
    return thisJQuery;
}
;
singJQuery.method('superFadeIn', jQuerySuperFadeIn, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    glyphIcon: '',
    tests: function (ext) {
    }
}, $.fn);
function jQuerySuperFadeIn(speed) {
    if (speed === void 0) { speed = 'fast'; }
    var thisJQuery = this;
    thisJQuery.each(function () {
        var jElement = $(this);
        var opacity = jElement.data('old-opacity');
        opacity = (opacity == '') ? jElement.css('opacity') : opacity;
        var height = jElement.data('old-height');
        height = (height == '') ? 'auto' : height;
        var marginTop = jElement.data('old-margin-top');
        marginTop = (marginTop == '') ? jElement.css('margin-top') : marginTop;
        var marginBottom = jElement.data('old-margin-bottom');
        marginBottom = (marginBottom == '') ? jElement.css('margin-bottom') : marginBottom;
        var marginLeft = jElement.data('old-margin-left');
        marginLeft = (marginLeft == '') ? jElement.css('margin-left') : marginLeft;
        var marginRight = jElement.data('old-margin-right');
        marginRight = (marginRight == '') ? jElement.css('margin-right') : marginRight;
        var paddingTop = jElement.data('old-padding-top');
        paddingTop = (paddingTop == '') ? jElement.css('padding-top') : paddingTop;
        var paddingBottom = jElement.data('old-padding-bottom');
        paddingBottom = (paddingBottom == '') ? jElement.css('padding-bottom') : paddingBottom;
        var paddingLeft = jElement.data('old-padding-left');
        paddingLeft = (paddingLeft == '') ? jElement.css('padding-left') : paddingLeft;
        var paddingRight = jElement.data('old-padding-right');
        paddingRight = (paddingRight == '') ? jElement.css('padding-right') : paddingRight;
        jElement.data('old-opacity', '');
        jElement.data('old-height', '');
        jElement.data('old-margin-top', '');
        jElement.data('old-margin-bottom', '');
        jElement.data('old-margin-left', '');
        jElement.data('old-margin-right', '');
        jElement.data('old-padding-top', '');
        jElement.data('old-padding-bottom', '');
        jElement.data('old-padding-left', '');
        jElement.data('old-padding-right', '');
        jElement.animate({
            opacity: opacity,
            height: height,
            'padding-top': paddingTop,
            'padding-bottom': paddingBottom,
            'padding-left': paddingLeft,
            'padding-right': paddingRight,
            'margin-top': marginTop,
            'margin-bottom': marginBottom,
            'margin-left': marginLeft,
            'margin-right': marginRight
        }, speed, function () {
            jElement.css('height', '');
            jElement.css('padding-top', '');
            jElement.css('padding-bottom', '');
            jElement.css('padding-left', '');
            jElement.css('padding-right', '');
            jElement.css('margin-top', '');
            jElement.css('margin-bottom', '');
            jElement.css('margin-left', '');
            jElement.css('margin-right', '');
        });
    });
    return thisJQuery;
}
;
//# sourceMappingURL=singularity-jquery.js.map