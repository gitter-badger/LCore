/// <reference path="singularity-core.ts"/>

// ReSharper disable once InconsistentNaming
interface JQueryStatic {
    isString?: (obj: any) => boolean;

    defer?: (deferFunc: Function) => void;
}

// ReSharper disable once InconsistentNaming
interface JQuery {
    // Missing from definition
    selectmenu(): JQuery;

    init?: (initFunc: () => void) => void;
    findIDNameSelector?: (name: string) => JQuery;
    checked?: () => boolean;
    allVisible?: () => boolean;
    actionIf?: (name: string) => boolean;

    outerHtml?: () => string;
    innerHtml?: () => string;

    hasAttr?: (name: string) => boolean;

    swapClass?: (class1: string, class2: string) => JQuery;

    getAttributes?: () => IKeyValue<string, string>[]| IKeyValue<string, string>[][];

    isOnScreen?: (x?: number, y?: number) => boolean;

    superFadeIn?: (speed?: string|number) => JQuery;
    superFadeOut?: (speed?: string|number) => JQuery;
}


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

singJQuery.method('checked', checked,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: '',
        examples: null,
        glyphIcon: '&#xe013;',
        tests(ext) {
        }
    }, $.fn);

function checked() {
    var anyChecked = false;


    this.each(function () {
        const thisJQuery = $(this);
        if (thisJQuery && thisJQuery[0] && (thisJQuery[0] as any).checked['checked'])
            anyChecked = true;
    });

    return anyChecked;
}

singJQuery.method('allVisible', allVisible,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: '',
        examples: null,
        glyphIcon: '&#xe105;',
        tests(ext) {
        }
    }, $.fn);

function allVisible() {

    var allVisible = true;

    this.each(function () {
        const opacity = $(this).attr('opacity');

        if (opacity == '0') {
            allVisible = false;
        }

        if ($(this).css('display') == 'none') {
            allVisible = false;
        }
    });

    return allVisible;
}

singJQuery.method('findIDNameSelector', findIDNameSelector,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: '',
        examples: null,
        glyphIcon: '&#xe003;',
        tests(ext) {
        }
    }, $.fn);

function findIDNameSelector(name: string) {

    let target = $();

    try {
        target = $(this).find(`#${name}`);
    } catch (ex) { }

    if (target.length == 0)
        try {
            target = $(this).find(`[name=${name}]`);
        } catch (ex) { }

    if (target.length == 0)
        try {
            target = $(this).find(name);
        } catch (ex) { }

    return target || $();
}

singJQuery.method('actionIf', actionIf,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: '',
        examples: null,
        glyphIcon: '&#xe162;',
        tests(ext) {
        }
    }, $.fn);

function actionIf(name: string) {

    var target = $(this);

    var ifTargetName = target.attr(`${name}-if`);

    // If there's no target, there's no condition to match. Always true.
    if (!ifTargetName)
        return true;

    var ifTarget = $('body').findIDNameSelector(ifTargetName);

    var targetValue = (target.attr(`${name}-if-value`) || '') as any;

    var operation = (a: any, b: any) => (a == b);

    if (targetValue.indexOf('!=') == 0) {
        operation = (a, b) => (a != b);
        targetValue = targetValue.substr(2);
    }
    else if (targetValue.indexOf('>=') == 0) {
        operation = (a, b) => (parseFloat(a) >= parseFloat(b));
        targetValue = parseFloat(targetValue.substr(2));
    }
    else if (targetValue.indexOf('<=') == 0) {
        operation = (a, b) => (parseFloat(a) <= parseFloat(b));
        targetValue = parseFloat(targetValue.substr(2));
    }
    else if (targetValue.indexOf('><') == 0) {
        operation = (a, b) => (parseFloat(a) >= parseFloat(b[0]) && parseFloat(a) <= parseFloat(b[1]));
        targetValue = targetValue.substr(2);
        targetValue = [
            targetValue.split(',')[0],
            targetValue.split(',')[1]
        ];
    }
    else if (targetValue.indexOf('<>') == 0) {
        operation = (a, b) => (parseFloat(a) <= parseFloat(b[0]) || parseFloat(a) >= parseFloat(b[1]));
        targetValue = targetValue.substr(2);
        targetValue = [
            targetValue.split(',')[0],
            targetValue.split(',')[1]
        ];
    }
    else if (targetValue.indexOf(',') > 0) {
        operation = (a, b) => (b.indexOf(a) >= 0);
        targetValue = targetValue.split(',');
    }
    else if (targetValue.indexOf('!') == 0) {
        operation = (a, b) => (parseFloat(a) != parseFloat(b));
        targetValue = targetValue.substr(1);
    }
    else if (targetValue.indexOf('<') == 0) {
        operation = (a, b) => (parseFloat(a) < parseFloat(b));
        targetValue = parseFloat(targetValue.substr(1));
    }
    else if (targetValue.indexOf('>') == 0) {
        operation = (a, b) => (parseFloat(a) > parseFloat(b));
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
};

singJQuery.method('defer', defer,
    {
        summary: null,
        parameters: null,
        validateInput: false,
        returns: '',
        returnType: '',
        aliases: ['wait'],
        examples: null,
        glyphIcon: '&#xe095;',
        tests(ext) {
        }
    });

function defer(deferFunc: Function): void {
    if (deferFunc)
        setTimeout(deferFunc, 0);
}

singJQuery.method('hasAttr', jQueryHasAttr,
    {
        summary: null,
        parameters: null,
        validateInput: false,
        returns: '',
        returnType: '',
        examples: null,
        glyphIcon: '&#xe042;',
        tests(ext) {
        }
    }, $.fn);

function jQueryHasAttr(name: string): boolean {

    return $(this).attr(name) !== undefined;
}

singJQuery.method('outerHtml', jQueryOuterHtml,
    {
        summary: null,
        parameters: null,
        validateInput: false,
        returns: '',
        returnType: '',
        examples: null,
        glyphIcon: '&#xe140;',
        tests(ext) {
        }
    }, $.fn);

function jQueryOuterHtml(): string {

    if (this.length == 0) {
        return '';
    }
    else {
        return this[0].outerHTML;
    }
}

singJQuery.method('innerHtml', jQueryInnerHtml,
    {
        summary: null,
        parameters: null,
        validateInput: false,
        returns: '',
        returnType: '',
        examples: null,
        glyphIcon: '&#xe087;',
        tests(ext) {
        }
    }, $.fn);

function jQueryInnerHtml(): string {

    if (this.length == 0) {
        return '';
    }
    else {
        return this[0].innerHTML;
    }
}

// https://github.com/moagrius/isOnScreen

singJQuery.method('isOnScreen', jQueryIsOnScreen,
    {
        summary: null,
        parameters: null,
        validateInput: false,
        returns: '',
        returnType: '',
        examples: null,
        glyphIcon: '&#xe106;',
        tests(ext) {
        }
    }, $.fn);

function jQueryIsOnScreen(x: number = 1, y: number = 1): boolean {

    const win = $(window);

    const viewport = {
        top: win.scrollTop(),
        left: win.scrollLeft(),
        right: 0,
        bottom: 0
    };

    viewport.right = viewport.left + win.width();
    viewport.bottom = viewport.top + win.height();

    const height = this.outerHeight();
    const width = this.outerWidth();

    if (!width || !height) {
        return false;
    }

    const bounds = this.offset();
    bounds.right = bounds.left + width;
    bounds.bottom = bounds.top + height;

    const visible = (!(viewport.right < bounds.left ||
        viewport.left > bounds.right ||
        viewport.bottom < bounds.top ||
        viewport.top > bounds.bottom));

    if (!visible) {
        return false;
    }

    const deltas = {
        top: Math.min(1,(bounds.bottom - viewport.top) / height),
        bottom: Math.min(1,(viewport.bottom - bounds.top) / height),
        left: Math.min(1,(bounds.right - viewport.left) / width),
        right: Math.min(1,(viewport.right - bounds.left) / width)
    };

    return (deltas.left * deltas.right) >= x && (deltas.top * deltas.bottom) >= y;
};

singJQuery.method('swapClasses', jQuerySwapClass,
    {
        summary: null,
        parameters: null,
        validateInput: false,
        returns: '',
        returnType: '',
        examples: null,
        glyphIcon: '&#xe110;',
        tests(ext) {
        }
    }, $.fn);

function jQuerySwapClass(class1: string, class2: string): JQuery {

    const thisJQuery = this as JQuery;

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
};

singJQuery.method('fadeClasses', jQueryFadeClass,
    {
        summary: null,
        parameters: null,
        validateInput: false,
        returns: '',
        returnType: '',
        examples: null,
        glyphIcon: '',
        tests(ext) {
        }
    }, $.fn);

function jQueryFadeClass(class1: string, class2: string, speed: string|number = 'fast', callback?: Function): JQuery {

    var thisJQuery = this as JQuery;

    if (true) {
        if (thisJQuery.hasClass(class1)) {

            thisJQuery.fadeOut(speed, () => {
                thisJQuery.removeClass(class1);
                thisJQuery.addClass(class2);

                thisJQuery.fadeIn(speed, () => {
                    if (callback)
                        callback();
                });
            });
        }
        else if (thisJQuery.hasClass(class2)) {
            thisJQuery.fadeOut(speed, () => {
                thisJQuery.removeClass(class2);
                thisJQuery.addClass(class1);

                thisJQuery.fadeIn(speed, () => {
                    if (callback)
                        callback();
                });
            });
        }
        else {
            thisJQuery.fadeOut(speed, () => {
                thisJQuery.addClass(class1);

                thisJQuery.fadeIn(speed, () => {
                    if (callback)
                        callback();
                });
            });
        }
    }

    return thisJQuery;
};

singJQuery.method('superFadeOut', jQuerySuperFadeOut,
    {
        summary: null,
        parameters: null,
        validateInput: false,
        returns: '',
        returnType: '',
        examples: null,
        glyphIcon: '',
        tests(ext) {
        }
    }, $.fn);

function jQuerySuperFadeOut(speed: string|number = 'fast'): JQuery {

    const thisJQuery = this as JQuery;

    thisJQuery.each(function () {

        const jElement = $(this);

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

        jElement.animate(
            {
                opacity: 0,
                height: 0,
                padding: 0,
                margin: 0
            }, speed);
    });

    return thisJQuery;
};

singJQuery.method('superFadeIn', jQuerySuperFadeIn,
    {
        summary: null,
        parameters: null,
        validateInput: false,
        returns: '',
        returnType: '',
        examples: null,
        glyphIcon: '',
        tests(ext) {
        }
    }, $.fn);

function jQuerySuperFadeIn(speed: string|number = 'fast'): JQuery {

    const thisJQuery = this as JQuery;

    thisJQuery.each(function () {

        var jElement = $(this);

        var opacity: any = jElement.data('old-opacity');
        opacity = (opacity == '') ? jElement.css('opacity') : opacity;

        var height: any = jElement.data('old-height');
        height = (height == '') ? 'auto' : height;

        var marginTop: any = jElement.data('old-margin-top');
        marginTop = (marginTop == '') ? jElement.css('margin-top') : marginTop;

        var marginBottom: any = jElement.data('old-margin-bottom');
        marginBottom = (marginBottom == '') ? jElement.css('margin-bottom') : marginBottom;

        var marginLeft: any = jElement.data('old-margin-left');
        marginLeft = (marginLeft == '') ? jElement.css('margin-left') : marginLeft;

        var marginRight: any = jElement.data('old-margin-right');
        marginRight = (marginRight == '') ? jElement.css('margin-right') : marginRight;

        var paddingTop: any = jElement.data('old-padding-top');
        paddingTop = (paddingTop == '') ? jElement.css('padding-top') : paddingTop;

        var paddingBottom: any = jElement.data('old-padding-bottom');
        paddingBottom = (paddingBottom == '') ? jElement.css('padding-bottom') : paddingBottom;

        var paddingLeft: any = jElement.data('old-padding-left');
        paddingLeft = (paddingLeft == '') ? jElement.css('padding-left') : paddingLeft;

        var paddingRight: any = jElement.data('old-padding-right');
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

        jElement.animate(
            {
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
            }, speed, () => {
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
};
