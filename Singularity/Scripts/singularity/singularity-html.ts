/// <reference path="../definitions/jquery.d.ts" />
/// <reference path="../definitions/jqueryui.d.ts" />
/// <reference path="../definitions/jquery.cookie.d.ts" />
/// <reference path="../definitions/jquery.timepicker.d.ts" />
/// <reference path="../definitions/chance.d.ts" />
/// <reference path="singularity-core.ts"/>
/// <reference path="singularity-string.ts"/>

// #region Comments
//////////////////////////////////////////////////////
//
// HTML Extensions
//
//
// Action Conditions
// All actions are able to be made conditional using attributes.
//
// *[<action>-if]
// The ID or Name or Selector of the value to look for. If you only want to check for the presence of a value or a checkbox being checked
// use <action>-if without <action>-if-value
// *[<action>-if-value]
// Requires a specific string or value to be present
// 
// ex. by ID        <action>-if="checkfield5"
// ex. by Name      <action>-if="valuename"
// ex. by Selector  <action>-if="form.class .class2 input"
//
// Numeric operations: 
// Prefix a number with an operation to compare it 
//
// >=                           ex. <action>-if-value=">=5"
// >                            ex. <action>-if-value=">5"
// <                            ex. <action>-if-value="<5"
// <=                           ex. <action>-if-value="<=5"
// !=                           ex. <action>-if-value="!=5"
// !                            ex. <action>-if-value="!5"
// (leave blank for == )        ex. <action>-if-value="5"
//
//
// Range operations:
// >< Inclusion                 ex. <action>-if-value="><5,10"
// <> Exclusion                 ex. <action>-if-value="<>2,100"
//
// List operations
// ,                            ex. <action>-if-value="2,4,6,8"
//                              ex. <action>-if-value="eggs,bacon,ham"
//
//////////////////////////////////////////////////////
//
// img[error-src]
// If an image loads with an error its error-src url will be used
//
// *[focus-first]
// When the page loads the first control with this tag will be focesed
//
//////////////////////////////////////////////////////
//
// *[go-to-remember-page]
// Triggers navigation to remembered page (if enabled)
//
// *[enable-remember-page]
// Enables navigation to remembered page (log in screen)
//
// *[remember-page]
// Triggers saving of current page
//
//////////////////////////////////////////////////////
// Click Actions
//
// *[click-show]
// *[click-show-if]                 (optional)
// *[click-show-if-value]           (optional)
// When clicked, the target(s) with the passed ID, Name or Selector will be shown
//
// *[click-hide]
// *[click-hide-if]                 (optional)
// *[click-hide-if-value]           (optional)
// When clicked, the target(s) with the passed ID, Name or Selector will be hidden
//
// *[click-toggle]
// *[click-toggle-if]               (optional)
// *[click-toggle-if-value]         (optional)
// When clicked, the target(s) with the passed ID, Name or Selector visibility will be toggled
//
// *[click-fade-in]
// *[click-fade-in-if]              (optional)
// *[click-fade-in-if-value]        (optional)
// When clicked, the target(s) with the passed ID, Name or Selector will be faded in
//
// *[click-fade-out]
// *[click-fade-out-if]             (optional)
// *[click-fade-out-if-value]       (optional)
// When clicked, the target(s) with the passed ID, Name or Selector will be faded out
//
// *[click-fade-toggle]
// *[click-fade-toggle-if]          (optional)
// *[click-fade-toggle-if-value]    (optional)
// When clicked, the target(s) with the passed ID, Name or Selector visibility will be toggled
//
// *[click-add-class]
// *[click-add-class-target]        (optional, default is self)
// *[click-add-class-if]            (optional)
// *[click-add-class-if-value]      (optional)
// Adds a css class or classes provided in the attribute 'click-add-class'
// The default target is the element itself, optionally 'click-add-class-target' will direct the 
// change to the ID, Name or Selector target.
//
// *[click-remove-class]
// *[click-remove-class-target]     (optional, default is self)
// *[click-remove-class-if]         (optional)
// *[click-remove-class-if-value]   (optional)
// Removes a css class or classes provided in the attribute 'click-remove-class'
// The default target is the element itself, optionally 'click-remove-class-target' will direct the 
// change to the ID, Name or Selector target.
//
// *[click-toggle-class]
// *[click-toggle-class-target]     (optional, default is self)
// *[click-toggle-class-if]         (optional)
// *[click-toggle-class-if-value]   (optional)
// Toggles a css class or classes provided in the attribute 'click-toggle-class'
// The default target is the element itself, optionally 'click-toggle-class-target' will direct the 
// change to the ID, Name or Selector target.
// 
//
// TODO: TS: Write
// *[click-animate]
// *[click-animate-target]          (optional, default is self)
// *[click-animate-duration]        (optional)
// *[click-animate-easing]          (optional)
// *[click-animate-if]              (optional)
// *[click-animate-if-value]        (optional)
//
// TODO: TS: Write
// *[click-scroll-to]
// *[click-scroll-to-if]              (optional)
// *[click-scroll-to-if-value]        (optional)
//
// TODO: TS: Write
// *[click-text]
// *[click-text-target]             (optional, default is self)
// *[click-text-if]                 (optional)
// *[click-text-if-value]           (optional)
// 
// TODO: TS: Write
// *[click-html]
// *[click-html-target]             (optional, default is self)
// *[click-html-if]                 (optional)
// *[click-html-if-value]           (optional)
//
//////////////////////////////////////////////////////
//
// CSS Class Settings
//
// TODO: TS: Write
// *[class-if]
// *[class-if-value]
//
// Attribute setting
//
// TODO: TS: Write
// *[attr]
// *[attr-target]
// *[attr-if]
// *[attr-if-value]
//
//////////////////////////////////////////////////////
//
// Boolean Property Change Actions
//
// *[show-if]
// *[show-if-value]
//
// *[hide-if]
// *[hide-if-value]
//
// *[enabled-if]
// *[enabled-if-value]
//
// *[disabled-if]
// *[disabled-if-value]
// TODO: TS: Test
//
// *[readonly-if]
// *[readonly-if-value]
// TODO: TS: Test
//
// *[selected-if]
// *[selected-if-value]
// TODO: TS: Test
//
// *[checked-if]
// *[checked-if-value]
//
// *[ctrl-href]
// *[shift-href]
// *[alt-href]
// *[double-href]
// TODO: TS: Test
// *[key-bind-click]
// #key-bind-page-tip
//////////////////////////////////////////////////////
//
// Field Extensions
// TODO: TS: Test
//
// .tab-container *[href]
// .datepicker
// .timepicker
// .spinner-int
// .select-list
// .tab-container
// .spinner-money
// .int-range
// .spinner-decimal
//
//////////////////////////////////////////////////////
// #endregion Comments

interface TimePickerOptions {
    step?: number;
}
interface String {

    textToHTML?: () => string;

    // stripHTML
    // getAttributes
}

var singHTML = singString.addModule(new sing.Module('HTML', String));

singHTML.glyphIcon = '&#xe022;';

singHTML.method('textToHTML', StringTextToHTML,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests(ext) {
        }
    });

function StringTextToHTML(): string {

    return this.replaceAll('\r\n', '\n')
        .replaceAll('\n', '<br/>')
        .replaceAll('  ', '&nbsp;&nbsp;');
}


singHTML.method('stripHTML', StringStripHTML,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests(ext) {
        }
    });

function StringStripHTML() {

    const out = this as string;

    const pattern = /.*\<(.+)\>.*/;

    out.replaceRegExp(pattern, / /);

    return out;
}


singHTML.method('getAttributes', GetAttributes,
    {
        summary: null,
        parameters: null,
        validateInput: false,
        returns: '',
        returnType: '',
        examples: null,
        tests(ext) {
        }
    }, $.fn);

function GetAttributes(): IKeyValue<string, string>[] | IKeyValue<string, string>[][] {

    const thisJQuery = this as JQuery;

    var attrs: IKeyValue<string, Attr>[][] = [];

    thisJQuery.each(function () {

        const thisHtml = this as HTMLElement;

        const attrOut: IKeyValue<string, Attr>[] = [];

        const props = $.objProperties(thisHtml.attributes);

        for (let i = 0; i < props.length; i++) {
            if (props[i].key != 'length')
                attrOut.push({ key: props[i].key, value: (props[i].value) as Attr });
        }

        if (attrOut.length > 0)
            attrs.push(attrOut);
    });

    if (attrs.length > 1)
        return attrs.collect(item => item.collect(item2 => ({
            name: item2.value.nodeName,
            value: item2.value.nodeValue
        } as IKeyValue<string, string>)));

    if (attrs.length == 1)
        return attrs[0].collect(item => ({
            name: item.value.nodeName,
            value: item.value.nodeValue
        } as IKeyValue<string, string>));

    if (attrs.length == 0)
        return [];
}





////////////////////////////////////////////////////////////////////////////////////////////////////

function InitHTMLExtensions() {
    InitKeyBindClick();

    InitRememberPage();

    InitClickActions();

    InitPropertyIf();

    InitIdent();

    InitHoverSrc();

    $('ul#menu a').each(function () {
        if (document.URL.indexOf($(this).attr('href')) > 0) {
            $('.active-page').removeClass('active-page');
            $(this).addClass('active-page');
        }
    });

    $(`*[${sing.constants.htmlAttr.FocusFirst}]`).each(function () {
        const target = $(this).attr(sing.constants.htmlAttr.FocusFirst);

        const targets = $(this).find(target);

        // Prefer fields with no values
        const emptyTargets = targets.select(t => ($(t).val() == ''));

        if (emptyTargets && emptyTargets.length > 0)
            emptyTargets[0].focus();

        if (targets && targets.length > 0)
            targets[0].focus();
    });

    $(`*[${sing.constants.htmlAttr.Click.Animate}]`).each(function () {
        var element = $(this);

        var animation = element.attr(sing.constants.htmlAttr.Click.Animate);

        var duration = (element.attr(sing.constants.htmlAttr.Click.AnimateDuration) as any) || null;

        if (duration)
            duration = parseFloat(duration);

        var easing = element.attr(sing.constants.htmlAttr.Click.AnimateEasing) || null;

        const targetName = element.attr(sing.constants.htmlAttr.Click.AnimateTarget);

        var target = $('body').findIDNameSelector(targetName);

        if (!target || target.length == 0 || !target.animate)
            target = element;

        element.click(() => {

            var actionIf = element.actionIf(sing.constants.htmlAttr.Click.Animate);

            if (!actionIf)
                return;

            try {
                // parseJSON can't handle double quotes
                animation = animation.replaceAll('\'', '"');

                const animationObject = $.parseJSON(animation);

                target.animate(animationObject, duration, easing);
            }
            catch (ex) {

            }
        });

    });

    $('.close-dialog').each(function () {
        $(this).prepend($("<div class='close-button'><span class='glyphicon'>&#xe014;</span></div>"));
    });

    $('.close-dialog .close-button').click(function () {
        $(this).parent().superFadeOut();
    });

    if ($('#UpdateButton').length > 0) {
        $('.field-update-refresh-page').each(function () {

            $(this).find('input, select, textarea').each(function () {
                $(this).change(function () {
                    // Show shade
                    $(this).parents('.wide-form').find('.view-updating-shade').fadeIn();

                    // Click update
                    $('#UpdateButton').click();
                });
            });
        });
    }

    $('.field-list-add-drag').each(function () {
        var ListParent = $(this);

        $(this).find('.field-list-row').mousedown(function (e) {
            e.stopPropagation();

            ListParent.find('.field-name').show();
            ListParent.find('.field-token').hide();

            $(this).data('toggled', 'true');

            $(this).find('.field-name').hide();
            $(this).find('.field-token').show();

            ($(this).find('.field-token input')[0] as any).select();
        });
    });

    $('.field-list-add').each(function () {
        var targetAttr = $(this).attr('target');

        // end, beginning, or cursor
        var position = $(this).attr('position') || 'cursor';

        // ReSharper disable once DoubleNegationOfBoolean
        var tokenBraces = !!($(this).attr('token-braces') == 'true');


        $(this).find('.field-list-row').mousedown(function (e) {
            e.stopPropagation();

            var fieldName: any = $(this).data('field-name');

            if (tokenBraces)
                fieldName = `[${fieldName as string}]`;

            // ReSharper disable once AssignedValueIsNeverUsed
            var target: JQuery = null;

            if (targetAttr == 'focused') {
                target = $(document.activeElement);
            }
            else {
                target = $(targetAttr);
            }

            if (target.length > 0) {

                if ((target[0] as any).type == 'textarea') {
                    if (position == 'end') {
                        target.val(`${target.val()}\r\n${fieldName}`);
                    }
                    else if (position == 'beginning') {
                        target.val(`${fieldName}\r\n${target.val()}`);
                    }
                    else if (position == 'cursor') {

                        insertAtCaret(target.attr('id'), fieldName);
                    }
                }
                else if ((target[0] as any).type == 'input') {
                    if (position == 'end') {
                        target.val(target.val() + fieldName);

                    }
                    else if (position == 'beginning') {
                        target.val(fieldName + target.val());

                    }
                    else if (position == 'cursor') {
                        insertAtCaret(target.attr('id'), fieldName);
                    }
                }
                else if ((target[0] as any).type == 'iframe') {
                    const value = wysihtml5Editor.getValue();
                    wysihtml5Editor.setValue(value + fieldName, true);
                }
            }
        });
    });

    $('.manage-view-show-similar').click(function () {
        const fieldName = $(this).data('field-name');
        const fieldValue = $(this).data('field-value');

        $('#GlobalSearchTerm').val(`${fieldName}:${fieldValue}`);

        $('.manage-global-search input[type=submit]').click();
    });

    try {
        $('select').sortable();
    }
    catch (ex) {
    }
}

var Identicon: any;
var jsSHA: any;

function InitIdent() {

    if (Identicon && jsSHA) {
        const ident = $('ident');

        ident.each(function () {
            const thisJQuery = $(this);

            const hash = thisJQuery.html();

            const size = (thisJQuery.attr('size') || '').tryToNumber() || 36;

            const classes = (thisJQuery.attr('class') || '');
            const styles = (thisJQuery.attr('style') || '');

            // ReSharper disable once UnusedLocals
            const icon = new Identicon(hash, size);

            const salt = 'SingularitySalt';
            const shaObj = new jsSHA(hash + salt, 'TEXT');

            const hash2 = shaObj.getHash('SHA-256', 'HEX', 1);

            const data = new Identicon(hash2, size);

            // $("#show_identicon")[0].src = `data:image/png;base64,${data}`;

            $(this).html(`<img width="${size}" height="${size}" src="data:image/png;base64,${data}" class="${classes}" style="${styles}">`);

        });
    }
}

function InitHoverSrc() {
    const animated = $(`img[${sing.constants.htmlAttr.HoverSrc}]`);

    animated.each(function () {
        var thisElement = $(this);
        thisElement.on('mouseover', () => {
            thisElement.attr(thisElement.attr(sing.constants.htmlAttr.StaticSrc, thisElement.attr('src')));
            thisElement.attr('src', thisElement.attr(sing.constants.htmlAttr.HoverSrc));
        });
        thisElement.on('mouseout', () => {
            if (thisElement.hasAttr(thisElement.attr(sing.constants.htmlAttr.StaticSrc))) {
                thisElement.attr('src', thisElement.attr(thisElement.attr(sing.constants.htmlAttr.StaticSrc)));
                thisElement.removeAttr('static-src');
            }
        });
    });
}

function PropertyIf(propertyName: string, changeTrue?: (propertyTarget: JQuery) => void, changeFalse?: (propertyTarget: JQuery) => void) {

    $(`*[${propertyName}-if]`).each(function () {
        var propertyTarget = $(this);

        const ifTargetName = propertyTarget.attr(`${propertyName}-if`);

        const ifTarget = $('body').findIDNameSelector(ifTargetName);

        if (!ifTarget || ifTarget.length == 0) {
        }
        else {
            ifTarget.each(function () {

                const valueTarget = $(this);

                const changeFunction = () => {
                    var visible = propertyTarget.actionIf(propertyName);

                    if (visible && changeTrue)
                        changeTrue(propertyTarget);
                    else if (!visible && changeFalse)
                        changeFalse(propertyTarget);
                };

                var events = 'change paste keyup';

                if (valueTarget.attr('type') == 'radio')
                    events = 'change';

                valueTarget.on(events, changeFunction);

                // Sets the value initially
                changeFunction();
            });

        }
    });
}

function InitPropertyIf() {
    PropertyIf('show',
        target => {
            target.show('fast');
        },
        target => {
            target.hide('fast');
        });

    PropertyIf('hide',
        target => {
            target.hide('fast');
        },
        target => {
            target.show('fast');
        });

    PropertyIf('enabled',
        target => {
            target.removeAttr('disabled');
        },
        target => {
            target.attr('disabled', 'disabled');
        });

    PropertyIf('disabled',
        target => {
            target.attr('disabled', 'disabled');
        },
        target => {
            target.removeAttr('disabled');
        });

    PropertyIf('readonly',
        target => {
            target.attr('readonly', 'readonly');
        },
        target => {
            target.removeAttr('readonly');
        });

    PropertyIf('selected',
        target => {
            target.attr('selected', 'selected');
        },
        target => {
            target.removeAttr('selected');
        });

    PropertyIf('checked',
        target => {
            target.attr('checked', 'checked');
        },
        target => {
            target.removeAttr('checked');
        });

}

function InitClickActions() {

    $(`*[${sing.constants.htmlAttr.Click.Show}]`).each(function () {

        var target = $(this).attr(sing.constants.htmlAttr.Click.Show);

        $(this).click(function () {

            const actionIf = $(this).actionIf(sing.constants.htmlAttr.Click.Show);

            if (!actionIf)
                return;

            $('body').findIDNameSelector(target).show('fast');
        });
    });

    $(`*[${sing.constants.htmlAttr.Click.Hide}]`).each(function () {

        var target = $(this).attr(sing.constants.htmlAttr.Click.Hide);

        $(this).click(function () {
            const actionIf = $(this).actionIf(sing.constants.htmlAttr.Click.Hide);

            if (!actionIf)
                return;

            $('body').findIDNameSelector(target).hide('fast');
        });
    });

    $(`*[${sing.constants.htmlAttr.Click.Toggle}]`).each(function () {

        var target = $(this).attr(sing.constants.htmlAttr.Click.Toggle);

        $(this).click(function () {
            const actionIf = $(this).actionIf(sing.constants.htmlAttr.Click.Toggle);

            if (!actionIf)
                return;

            $('body').findIDNameSelector(target).toggle('fast');
        });
    });

    $(`*[${sing.constants.htmlAttr.Click.FadeIn}]`).each(function () {

        var target = $(this).attr(sing.constants.htmlAttr.Click.FadeIn);

        $(this).click(function () {

            const actionIf = $(this).actionIf(sing.constants.htmlAttr.Click.FadeIn);

            if (!actionIf)
                return;

            $('body').findIDNameSelector(target).fadeIn('fast');
        });
    });

    $(`*[${sing.constants.htmlAttr.Click.FadeOut}]`).each(function () {

        var target = $(this).attr(sing.constants.htmlAttr.Click.FadeOut);

        $(this).click(function () {

            const actionIf = $(this).actionIf(sing.constants.htmlAttr.Click.FadeOut);

            if (!actionIf)
                return;

            $('body').findIDNameSelector(target).fadeOut('fast');
        });
    });

    $(`*[${sing.constants.htmlAttr.Click.FadeToggle}]`).each(function () {

        var target = $(this).attr(sing.constants.htmlAttr.Click.FadeToggle) as any;

        target = $('body').findIDNameSelector(target);

        $(this).click(function () {

            const actionIf = $(this).actionIf(sing.constants.htmlAttr.Click.FadeToggle);

            if (!actionIf)
                return;

            target.each(function () {

                if ($(this).allVisible())
                    $(this).fadeOut('fast');
                else
                    $(this).fadeIn('fast');
            });
        });
    });

    $(`*[${sing.constants.htmlAttr.Click.ToggleClass}]`).each(function () {

        var element = $(this);

        var className = element.attr(sing.constants.htmlAttr.Click.ToggleClass);

        const targetName = element.attr(sing.constants.htmlAttr.Click.ToggleClassTarget);

        var target = $('body').findIDNameSelector(targetName);

        if (target && target.length == 0)
            target = element;

        element.click(() => {

            var actionIf = element.actionIf(sing.constants.htmlAttr.Click.ToggleClass);

            if (!actionIf)
                return;

            target.toggleClass(className);
        });
    });

    $(`*[${sing.constants.htmlAttr.Click.AddClass}]`).each(function () {

        var element = $(this);

        var className = element.attr(sing.constants.htmlAttr.Click.AddClass);

        const targetName = element.attr(sing.constants.htmlAttr.Click.AddClassTarget);

        var target = $('body').findIDNameSelector(targetName);

        if (!target || target.length == 0)
            target = element;

        element.click(() => {

            var actionIf = element.actionIf(sing.constants.htmlAttr.Click.AddClass);

            if (!actionIf)
                return;

            target.addClass(className);
        });
    });

    $(`*[${sing.constants.htmlAttr.Click.RemoveClass}]`).each(function () {

        var element = $(this);

        var className = element.attr(sing.constants.htmlAttr.Click.RemoveClass);

        const targetName = element.attr(sing.constants.htmlAttr.Click.RemoveClassTarget);

        var target = $('body').findIDNameSelector(targetName);

        if (!target || target.length == 0)
            target = element;

        element.click(() => {

            var actionIf = element.actionIf(sing.constants.htmlAttr.Click.RemoveClassTarget);

            if (!actionIf)
                return;

            target.removeClass(className);
        });
    });
}

function InitRememberPage() {
    $(`*[${sing.constants.htmlAttr.GoToRememberPage}]`).each(() => {
        if (!$.cookie)
            return;

        var lastPage = $.cookie('remember-page');
        var go = $.cookie('enable-remember-page') == 'true';

        if (go && lastPage) {
            $.removeCookie('remember-page');
            $.cookie('enable-remember-page', false, { expires: 7, path: '/' });
            document.location.href = lastPage;
        }
    });

    $(`*[${sing.constants.htmlAttr.EnableRememberPage}]`).each(() => {
        $.cookie('enable-remember-page', true, { expires: 7, path: '/' });
    });

    $(`*[${sing.constants.htmlAttr.RememberPage}]`).each(() => {
        $.cookie('enable-remember-page', false, { expires: 7, path: '/' });
        $.cookie('remember-page', document.URL, { expires: 7, path: '/' });
    });
}

var keyCodeToChar: IndexHash<string> = {
    8: 'Backspace', 9: 'Tab', 13: 'Enter', 16: 'Shift', 17: 'Ctrl', 18: 'Alt', 19: 'Pause/Break',
    20: 'Caps Lock', 27: 'Esc', 32: 'Space', 33: 'Page Up', 34: 'Page Down', 35: 'End', 36: 'Home',
    37: 'Left', 38: 'Up', 39: 'Right', 40: 'Down', 45: 'Insert', 46: 'Delete', 48: '0', 49: '1',
    50: '2', 51: '3', 52: '4', 53: '5', 54: '6', 55: '7', 56: '8', 57: '9', 65: 'A', 66: 'B', 67: 'C',
    68: 'D', 69: 'E', 70: 'F', 71: 'G', 72: 'H', 73: 'I', 74: 'J', 75: 'K', 76: 'L', 77: 'M', 78: 'N',
    79: 'O', 80: 'P', 81: 'Q', 82: 'R', 83: 'S', 84: 'T', 85: 'U', 86: 'V', 87: 'W', 88: 'X', 89: 'Y',
    90: 'Z', 91: 'Windows', 93: 'Right Click', 96: 'Numpad 0', 97: 'Numpad 1', 98: 'Numpad 2', 99: 'Numpad 3',
    100: 'Numpad 4', 101: 'Numpad 5', 102: 'Numpad 6', 103: 'Numpad 7', 104: 'Numpad 8', 105: 'Numpad 9',
    106: 'Numpad *', 107: 'Numpad +', 109: 'Numpad -', 110: 'Numpad .', 111: 'Numpad /', 112: 'F1', 113: 'F2',
    114: 'F3', 115: 'F4', 116: 'F5', 117: 'F6', 118: 'F7', 119: 'F8', 120: 'F9', 121: 'F10', 122: 'F11',
    123: 'F12', 144: 'Num Lock', 145: 'Scroll Lock', 182: 'My Computer', 183: 'My Calculator', 186: ';',
    187: '=', 188: ',', 189: '-', 190: '.', 191: '/', 192: '`', 219: '[', 220: '\\', 221: ']', 222: "'"
};
var keyCharToCode: Hash<number> = {
    "Backspace": 8, "Tab": 9, "Enter": 13, "Shift": 16, "Ctrl": 17, "Alt": 18, "Pause/Break": 19, "Caps Lock": 20,
    "Esc": 27, "Space": 32, "Page Up": 33, "Page Down": 34, "End": 35, "Home": 36, "Left": 37, "Up": 38,
    "Right": 39, "Down": 40, "Insert": 45, "Delete": 46, "0": 48, "1": 49, "2": 50, "3": 51, "4": 52, "5": 53,
    "6": 54, "7": 55, "8": 56, "9": 57, "A": 65, "B": 66, "C": 67, "D": 68, "E": 69, "F": 70, "G": 71, "H": 72,
    "I": 73, "J": 74, "K": 75, "L": 76, "M": 77, "N": 78, "O": 79, "P": 80, "Q": 81, "R": 82, "S": 83, "T": 84,
    "U": 85, "V": 86, "W": 87, "X": 88, "Y": 89, "Z": 90, "Windows": 91, "Right Click": 93, "Numpad 0": 96,
    "Numpad 1": 97, "Numpad 2": 98, "Numpad 3": 99, "Numpad 4": 100, "Numpad 5": 101, "Numpad 6": 102, "Numpad 7": 103,
    "Numpad 8": 104, "Numpad 9": 105, "Numpad *": 106, "Numpad +": 107, "Numpad -": 109, "Numpad .": 110, "Numpad /": 111,
    "F1": 112, "F2": 113, "F3": 114, "F4": 115, "F5": 116, "F6": 117, "F7": 118, "F8": 119, "F9": 120, "F10": 121,
    "F11": 122, "F12": 123, "Num Lock": 144, "Scroll Lock": 145, "My Computer": 182, "My Calculator": 183, ";": 186,
    "=": 187, ",": 188, "-": 189, ".": 190, "/": 191, "`": 192, "[": 219, "\\": 220, "]": 221, "'": 222
};

var wysihtml5Editor: any;

function InitKeyBindClick() {

    var down: boolean[] = [];

    $(`*[${sing.constants.htmlAttr.Click.CtrlHref}]`).click(function (e) {

        if (down[keyCharToCode['Ctrl']]) {
            location.href = $(this).attr(sing.constants.htmlAttr.Click.CtrlHref);

            e.preventDefault();
        }
    });

    $(`*[${sing.constants.htmlAttr.Click.ShiftHref}]`).click(function (e) {

        if (down[keyCharToCode['Shift']]) {
            location.href = $(this).attr(sing.constants.htmlAttr.Click.ShiftHref);

            e.preventDefault();
        }
    });

    $(`*[${sing.constants.htmlAttr.Click.AltHref}]`).click(function (e) {

        if (down[keyCharToCode['Alt']]) {
            location.href = $(this).attr(sing.constants.htmlAttr.Click.AltHref);

            e.preventDefault();
        }
    });

    $(`*[${sing.constants.htmlAttr.Click.DoubleHref}]`).on('dblclick', function (e) {

        if (down[keyCharToCode['Alt']]) {
            location.href = $(this).attr(sing.constants.htmlAttr.Click.DoubleHref);

            e.preventDefault();
        }
    });

    $(document).keydown(e => {

        down[e.keyCode] = true;


        $(`*[${sing.constants.htmlAttr.Click.KeyBindClick}]`).each(function () {

            const keyCode = $(this).attr(sing.constants.htmlAttr.Click.KeyBindClick);

            var key1: number;
            var key2: number;

            if (keyCode.indexOf('+') > 0 && keyCode.indexOf('+') < keyCode.length - 1) {

                key1 = parseInt(keyCode.substr(0, keyCode.indexOf('+')));
                key2 = parseInt(keyCode.substr(keyCode.indexOf('+') + 1));

                if (!key1)
                    key1 = keyCharToCode[keyCode.substr(0, keyCode.indexOf('+'))];
                if (!key2)
                    key2 = keyCharToCode[keyCode.substr(keyCode.indexOf('+') + 1)];

                if (down[key1] && e.keyCode == key2) {
                    if ($(this).attr('href'))
                        location.href = $(this).attr('href');
                    else
                        $(this).click();
                    e.preventDefault();
                }
            }
            else {

                key1 = (keyCode.tryToNumber(null) as number);

                if (!key1)
                    key1 = keyCharToCode[keyCode];

                if (e.keyCode == key1) {
                    if ($(this).attr('href'))
                        location.href = $(this).attr('href');
                    else
                        $(this).click();
                    e.preventDefault();
                }
            }
        });

    }).keyup(e => {

        down[e.keyCode] = false;

    });

    var KeyBindTip = '';

    $(`*[${sing.constants.htmlAttr.Click.KeyBindClick}]`).each(function () {
        const keyCode = $(this).attr(sing.constants.htmlAttr.Click.KeyBindClick);
        var commandName = $(this).attr(sing.constants.htmlAttr.Click.KeyBindClickName);
        const href = $(this).attr('href');
        const id = $(this).attr('id');

        if (!commandName)
            return;
        var key1: number;
        if (keyCode.indexOf('+') > 0 && keyCode.indexOf('+') < keyCode.length - 1) {
            console.log(keyCode);
            key1 = (StringTryToNumber(keyCode.substr(0, keyCode.indexOf('+'))) as number);
            let key2 = StringTryToNumber(keyCode.substr(keyCode.indexOf('+') + 1)) as number;

            if (!key1)
                // ReSharper disable once AssignedValueIsNeverUsed
                key1 = keyCharToCode[keyCode.substr(0, keyCode.indexOf('+'))];
            if (!key2)
                // ReSharper disable once AssignedValueIsNeverUsed
                key2 = keyCharToCode[keyCode.substr(keyCode.indexOf('+') + 1)];

            if (href)
                commandName = `<a style='cursor: pointer;' onclick='location.href = "${href}";'>${commandName}</a>`;
            else if (id)
                commandName = `<a style='cursor: pointer;' onclick='$("#${id}").click();'>${commandName}</a>`;

            KeyBindTip += `<b>${keyCode.substr(0, keyCode.indexOf('+'))}+${keyCode.substr(keyCode.indexOf('+') + 1)}</b> - ${commandName}`;
            KeyBindTip += '<br>';
        }
        else {
            key1 = (StringTryToNumber(keyCode) as number);

            if (!key1)
                // ReSharper disable once AssignedValueIsNeverUsed
                key1 = keyCharToCode[keyCode];

            if (href)
                commandName = `<a style='cursor: pointer;' onclick='location.href = "${href}";'>${commandName}</a>`;
            else if (id)
                commandName = `<a style='cursor: pointer;' onclick='$("#${id}").click();'>${commandName}</a>`;


            KeyBindTip += `<b>${keyCode}</b> - ${commandName}`;
            KeyBindTip += '<br>';
        }
    });

    if (KeyBindTip)
        $('#key-bind-page-tip').html(KeyBindTip);
    else
        $('#key-bind-page-tip').parent().hide();

}

function InitFields() {

    // Adds the tab id to all href in the tab container
    $('.tab-container *[href]').each(function () {

        const href = $(this).attr('href');

        if (href.indexOf('#') < 0) {
            $(this).attr('href', `${href}#${$(this).parent('.ui-tabs-panel').attr('id')}`);
        }
    });

    $('#randomize-fields').click(() => {
        RandomFields();
    });

    try {
        $('.datepicker').datepicker();
    } catch (ex) {
    }

    try {
        $('.timepicker').timepicker({ step: 15 });
    } catch (ex) {
    }

    // broken
    // $('.spinner-int').spinner();

    try {
        $('.select-list').selectmenu();
    } catch (ex) {
    }

    try {
        $('.tab-container').tabs();
    } catch (ex) {
    }

    try {
        $('.spinner-money').spinner({
            min: 0,
            max: 1000000,
            step: 1,
            numberFormat: 'C'
        });
    }
    catch (ex) {
    }

    $('img[error-src]').error(function () {
        $(this).attr('src', $(this).attr(sing.constants.htmlAttr.ErrorSrc));
    });

    try {
        $('.int-range').each(function () {
            var val = parseInt($(this).attr('value'));
            const minimum = parseInt($(this).attr('minimum'));
            const maximum = parseInt($(this).attr('maximum'));

            if (val <= minimum || isNaN(val))
                val = minimum;
            if (val >= maximum)
                val = maximum;

            if (val && !isNaN(val)) {
                $(`#${$(this).attr('target')}`).val(val.toString());
                $(`#${$(this).attr('text-target')}`).html(val.toString());
                /*
                $(this).slider({
                //    range: "min",
                    min: minimum,
                    max: maximum,
                    value: val,
                    slide: function (event: any, ui: any) {
                        $(`#${$(this).attr('target')}`).val(ui.value);
                        $(`#${$(this).attr('text-target')}`).html(ui.value);
                    },
                    change: function (event: any, ui: any) {
                        $(`#${$(this).attr('target')}`).val(ui.value);
                        $(`#${$(this).attr('text-target')}`).html(ui.value);
                    }
                })
                    */
                ;
            }
            //                $(`#${$(this).attr('target')}`).val($(this).slider("value"));
            //                $(`#${$(this).attr('text-target')}`).val($(this).slider("value"));
        });
    }
    catch (ex) {
    }

    try {
        $('.spinner-decimal').spinner({
            step: 0.01,
            numberFormat: 'n'
        });
    }
    catch (ex) {
    }
}

function RandomFields() {

    $('.field[data-type-name]').each(function () {
        var ObjectType = $(this).attr('data-object-type');
        var DataTypeName = $(this).attr('data-type-name');

        var Maximum = parseFloat($(this).attr('maximum'));
        var Minimum = parseFloat($(this).attr('minimum'));

        var Object: any = null;

        var chance = new Chance(Math.random);

        if (DataTypeName == 'MultilineText') {
            Object = chance.paragraph({ sentences: 6 });
            $(this).find('textarea').val(Object);
            return;
        }
        else if (ObjectType == 'System.String') {
            Object = chance.string();
        }

        if (ObjectType == 'System.Nullable`1[System.Int32]' ||
            ObjectType == 'System.Int32') {

            if (Maximum && Minimum) {
                Object = chance.integer({ min: Minimum, max: Maximum });

                $(this).find('.int-range').slider('value', Object);
                return;
            }
            else
                Object = chance.integer();
        }

        if (ObjectType == 'System.Nullable`1[System.Guid]' ||
            ObjectType == 'System.Guid') {
            Object = chance.guid();
        }

        if (ObjectType == 'System.Nullable`1[System.DateTime]' ||
            ObjectType == 'System.DateTime') {
            if (DataTypeName == 'Date') {
                Object = chance.date({ string: true });
            }
            else if (DataTypeName == 'Time') {
                Object = `${chance.hour({ twentyfour: true })}:${chance.minute()}:${chance.second()}`;
            }
            else if (DataTypeName == 'DateTime') {
                Object = `${chance.date({ string: true })} ${chance.hour({ twentyfour: true })}:${chance.minute()}:${chance.second()}`;
            }
        }

        if (DataTypeName == 'PhoneNumber') {
            Object = chance.phone();
        }
        if (DataTypeName == 'EmailAddress') {
            Object = chance.email();
        }
        if (DataTypeName == 'CreditCard') {
            Object = chance.cc();
        }
        if (DataTypeName == 'PostalCode') {
            Object = chance.postal();
        }
        if (DataTypeName == 'ImageUrl') {
            Object = `https://placekitten.com/g/${chance.integer({ min: 200, max: 500 })}/${chance.integer({ min: 200, max: 500 })}`;
        }
        if (DataTypeName == 'Url') {
            Object = chance.domain();
        }


        if (ObjectType == 'System.Nullable`1[System.TimeSpan]' ||
            ObjectType == 'System.TimeSpan') {
            //    Object = `${chance.hour({ twentyfour: true })}:${chance.minute()}:${chance.second()}:${chance.millisecond()}`;
        }

        if (ObjectType == 'System.Nullable`1[System.Boolean]' ||
            ObjectType == 'System.Boolean') {

            $(this).find('input[type=radio]').each(function () {
                if (chance.bool()) {
                    $(this).click();
                }
            });
        }

        if (ObjectType == 'System.Nullable`1[System.Single]' ||
            ObjectType == 'System.Single') {

        }

        var max: number;
        var selection: number;

        if ($(this).find('select option').length > 0) {
            max = $(this).find('select option').length;
            selection = chance.integer({ min: 0, max: max - 1 });

            $(this).find('option')[selection].click();
        }

        if ($(this).find('ui-menu ui-menu-item').length > 0) {
            max = $(this).find('ui-menu ui-menu-item').length;
            selection = chance.integer({ min: 0, max: max - 1 });

            $(this).find('ui-menu ui-menu-item')[selection].click();
        }

        if (Object) {
            $(this).find('input').val(Object).change();
        }

    });
}


function ObjectToHtml(obj: any, parentKey: string = null, context: any = null) {
    if (!obj)
        return '';

    let out = '';
    if (parentKey) {
        // ReSharper disable once AssignedValueIsNeverUsed
        // ReSharper disable once UnusedLocals
        const parentElement = parentKey.before('.').before('#');
        // ReSharper disable once UnusedLocals
        const parentClasses = parentKey.afterFirst('.');
        // ReSharper disable once UnusedLocals
        const parentID = parentKey.after('#');
    }

    if ($.isFunction(obj)) {
        out += (obj as Function)(context);
    }
    else if ($.isString(obj)) {

    }
    else if ($.isArray(obj)) {

    }
    else if ($.isHash(obj)) {
        const objKeys = $.objKeys(obj);
        for (let key in objKeys) {
            if (objKeys.hasOwnProperty(key)) {

                // ReSharper disable once UnusedLocals
                const objValue = obj[key];

                if ($.isNumber(key)) {
                } else if ($.isString(key)) {
                    if (key.startsWith('_')) {

                    }
                }
            }
        }

    }

    if (parentKey) {
    }

    return out;
}
function HtmlToObject(html: string) {
    if (!html || html.trim().length == 0)
        return '';


}

var testStructure = {
    html: {
        head: {
            title: ''
        },
        body: {
            ///////////////////////////////////

            // Attributes 
            '_example-attr': 'value',

            // Attributes, function evaluation
            '_example-attr2'() { return 'evaluate'; },

            ///////////////////////////////////

            // Element with class longhand (string)
            'span': {
                _class: 'example1'
            },
            // <span class="example1"></span>

            // Element with class shorthand
            'span.example1': {
            },
            // <span class="example1"></span>

            // Multiple classes longhand
            'div': {
                _classes: ['class1', 'class2']
            },
            // <div class="class1 class2"></div>

            // Multiple classes shorthand
            'div.class1.class2': {
            },
            // <div class="class1 class2"></div>

            ///////////////////////////////////

            // Element with id longhand
            'div.example2': {
                _id: 'example2'
            },
            // <div class="example2" id="example2"></div>

            // Element with id shorthand
            'div.example2#example2': {
            },
            // <div class="example2" id="example2"></div>

            ///////////////////////////////////

            // Element with content longhand
            'div#example3': {
                _content: {
                    // ...
                }
            },
            // <div id="example3">
            // ...
            // </div>

            // Element with indexed content
            'div#example4': {
                0: {
                    // ...
                },
                1: [
                    // ...
                ] as any[],
                2: '',
                3() { return '' }
                // ...
            },
            // <div id="example4">
            // ...
            // </div>

            // Element with content as a string
            'div#example5': 'content',
            // <div id="example5">content</div>

            // Element with content as a function (string)
            'div#example6'() {
                return 'content';
            },
            // <div id="example6">content</div>

            // Element with content as a function (object)
            'div#example7'() {
                return { 'ul': { 'li': ['1', '2', '3'] } };
            },
            // <div id="example7">
            //   <ul>
            //     <li>1</li>
            //     <li>2</li>
            //     <li>3</li>
            //   </ul>
            // </div>

            // Multiple elements (multiple divs)
            'div#example9': [
                'content1',
                'content2'
            ],
            // <div id="example9">
            //   <div>content1</div>
            //   <div>content2</div>
            // </div>

            // Multiple elements with classes (multiple divs)
            'div.all-class#example10': [
                'content1',
                'content2'
            ],
            // <div id="example10">
            //   <div class="all-class">content1</div>
            //   <div class="all-class">content2</div>
            // </div>

            // Multiple elements with classes (mixed types)
            'div.all-class#example11': [
                // String
                'content1',

                // Function
                () => 'content2',

                // Object
                {
                    _class: 'special',
                    _content: 'content3'
                }
            ],
            // <div id="example11">
            //   <div class="all-class">content1</div>
            //   <div class="all-class">content2</div>
            //   <div class="all-class special">content3</div>
            // </div>

            ///////////////////////////////////

            // List example, longhand
            'ul#example12': {
                'li': [
                    {
                        _class: 'example',
                        _content: '1'
                    },
                    {
                        _class: 'example',
                        _content: '2'
                    }
                    // ...
                ]
            },

            // List example, shorthand
            'ul.example13': {
                'li.example': [
                    {
                        _class: 'active',
                        _content: '1'
                    },
                    {
                        _content: '2'
                    }
                    // ...
                ]
            },

            ///////////////////////////////////


            // Basic context passing
            'div#example14': {
                _content(c: any) {
                    return (c && c.name) ? c.name : '';
                }
            },

            // Context Looping longhand
            'div#example15'(c: any) {
                if (c.items) {
                    return c.items.collect((item: any) => ({
                        span: {
                            _value: item.value
                        }
                    }));
                }
            }
        }
    }
};