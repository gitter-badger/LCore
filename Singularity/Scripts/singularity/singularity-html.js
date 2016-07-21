/// <reference path="../definitions/jquery.d.ts" />
/// <reference path="../definitions/jqueryui.d.ts" />
/// <reference path="../definitions/jquery.cookie.d.ts" />
/// <reference path="../definitions/jquery.timepicker.d.ts" />
/// <reference path="../definitions/chance.d.ts" />
/// <reference path="singularity-core.ts"/>
/// <reference path="singularity-string.ts"/>
var singHTML = singString.addModule(new sing.Module('HTML', String));
singHTML.glyphIcon = '&#xe022;';
singHTML.method('textToHTML', stringTextToHTML, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    }
});
function stringTextToHTML() {
    return this.replaceAll('\r\n', '\n')
        .replaceAll('\n', '<br/>')
        .replaceAll('  ', '&nbsp;&nbsp;');
}
singHTML.method('stripHTML', stringStripHTML, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    }
});
function stringStripHTML() {
    var out = this;
    var pattern = /.*\<(.+)\>.*/;
    out.replaceRegExp(pattern, / /);
    return out;
}
singHTML.method('getAttributes', getAttributes, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    tests: function (ext) {
    }
}, $.fn);
function getAttributes() {
    var thisJQuery = this;
    var attrs = [];
    thisJQuery.each(function () {
        var thisHtml = this;
        var attrOut = [];
        var props = $.objProperties(thisHtml.attributes);
        for (var i = 0; i < props.length; i++) {
            if (props[i].key != 'length')
                attrOut.push({ key: props[i].key, value: (props[i].value) });
        }
        if (attrOut.length > 0)
            attrs.push(attrOut);
    });
    if (attrs.length > 1)
        return attrs.collect(function (item) { return item.collect(function (item2) { return ({
            name: item2.value.nodeName,
            value: item2.value.nodeValue
        }); }); });
    if (attrs.length == 1)
        return attrs[0].collect(function (item) { return ({
            name: item.value.nodeName,
            value: item.value.nodeValue
        }); });
    if (attrs.length == 0)
        return [];
}
////////////////////////////////////////////////////////////////////////////////////////////////////
function initHTMLExtensions() {
    initKeyBindClick();
    initRememberPage();
    initClickActions();
    initPropertyIf();
    initIdent();
    initHoverSrc();
    $('ul#menu a').each(function () {
        if (document.URL.indexOf($(this).attr('href')) > 0) {
            $('.active-page').removeClass('active-page');
            $(this).addClass('active-page');
        }
    });
    $("*[" + sing.constants.htmlAttr.FocusFirst + "]").each(function () {
        var target = $(this).attr(sing.constants.htmlAttr.FocusFirst);
        var targets = $(this).find(target);
        // Prefer fields with no values
        var emptyTargets = targets.select(function (t) { return ($(t).val() == ''); });
        if (emptyTargets && emptyTargets.length > 0)
            emptyTargets[0].focus();
        if (targets && targets.length > 0)
            targets[0].focus();
    });
    $("*[" + sing.constants.htmlAttr.Click.Animate + "]").each(function () {
        var element = $(this);
        var animation = element.attr(sing.constants.htmlAttr.Click.Animate);
        var duration = element.attr(sing.constants.htmlAttr.Click.AnimateDuration) || null;
        if (duration)
            duration = parseFloat(duration);
        var easing = element.attr(sing.constants.htmlAttr.Click.AnimateEasing) || null;
        var targetName = element.attr(sing.constants.htmlAttr.Click.AnimateTarget);
        var target = $('body').findIDNameSelector(targetName);
        if (!target || target.length == 0 || !target.animate)
            target = element;
        element.click(function () {
            var actionIf = element.actionIf(sing.constants.htmlAttr.Click.Animate);
            if (!actionIf)
                return;
            try {
                // parseJSON can't handle double quotes
                animation = animation.replaceAll('\'', '"');
                var animationObject = $.parseJSON(animation);
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
        var listParent = $(this);
        $(this).find('.field-list-row').mousedown(function (e) {
            e.stopPropagation();
            listParent.find('.field-name').show();
            listParent.find('.field-token').hide();
            $(this).data('toggled', 'true');
            $(this).find('.field-name').hide();
            $(this).find('.field-token').show();
            $(this).find('.field-token input')[0].select();
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
            var fieldName = $(this).data('field-name');
            if (tokenBraces)
                fieldName = "[" + fieldName + "]";
            // ReSharper disable once AssignedValueIsNeverUsed
            var target = null;
            if (targetAttr == 'focused') {
                target = $(document.activeElement);
            }
            else {
                target = $(targetAttr);
            }
            if (target.length > 0) {
                if (target[0].type == 'textarea') {
                    if (position == 'end') {
                        target.val(target.val() + "\r\n" + fieldName);
                    }
                    else if (position == 'beginning') {
                        target.val(fieldName + "\r\n" + target.val());
                    }
                    else if (position == 'cursor') {
                        insertAtCaret(target.attr('id'), fieldName);
                    }
                }
                else if (target[0].type == 'input') {
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
                else if (target[0].type == 'iframe') {
                    var value = wysihtml5Editor.getValue();
                    wysihtml5Editor.setValue(value + fieldName, true);
                }
            }
        });
    });
    $('.manage-view-show-similar').click(function () {
        var fieldName = $(this).data('field-name');
        var fieldValue = $(this).data('field-value');
        $('#GlobalSearchTerm').val(fieldName + ":" + fieldValue);
        $('.manage-global-search input[type=submit]').click();
    });
    try {
        $('select').sortable();
    }
    catch (ex) {
    }
}
// ReSharper disable once InconsistentNaming
var Identicon;
var jsSha;
function initIdent() {
    if (Identicon && jsSha) {
        var ident = $('ident');
        ident.each(function () {
            var thisJQuery = $(this);
            var hash = thisJQuery.html();
            var size = (thisJQuery.attr('size') || '').tryToNumber() || 36;
            var classes = (thisJQuery.attr('class') || '');
            var styles = (thisJQuery.attr('style') || '');
            // ReSharper disable once UnusedLocals
            var icon = new Identicon(hash, size);
            var salt = 'SingularitySalt';
            // ReSharper disable once InconsistentNaming
            var shaObj = new jsSha(hash + salt, 'TEXT');
            var hash2 = shaObj.getHash('SHA-256', 'HEX', 1);
            var data = new Identicon(hash2, size);
            // $("#show_identicon")[0].src = `data:image/png;base64,${data}`;
            $(this).html("<img width=\"" + size + "\" height=\"" + size + "\" src=\"data:image/png;base64," + data + "\" class=\"" + classes + "\" style=\"" + styles + "\">");
        });
    }
}
function initHoverSrc() {
    var animated = $("img[" + sing.constants.htmlAttr.HoverSrc + "]");
    animated.each(function () {
        var thisElement = $(this);
        thisElement.on('mouseover', function () {
            thisElement.attr(thisElement.attr(sing.constants.htmlAttr.StaticSrc, thisElement.attr('src')));
            thisElement.attr('src', thisElement.attr(sing.constants.htmlAttr.HoverSrc));
        });
        thisElement.on('mouseout', function () {
            if (thisElement.hasAttr(thisElement.attr(sing.constants.htmlAttr.StaticSrc))) {
                thisElement.attr('src', thisElement.attr(thisElement.attr(sing.constants.htmlAttr.StaticSrc)));
                thisElement.removeAttr('static-src');
            }
        });
    });
}
function propertyIf(propertyName, changeTrue, changeFalse) {
    $("*[" + propertyName + "-if]").each(function () {
        var propertyTarget = $(this);
        var ifTargetName = propertyTarget.attr(propertyName + "-if");
        var ifTarget = $('body').findIDNameSelector(ifTargetName);
        if (!ifTarget || ifTarget.length == 0) {
        }
        else {
            ifTarget.each(function () {
                var valueTarget = $(this);
                var changeFunction = function () {
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
function initPropertyIf() {
    propertyIf('show', function (target) {
        target.show('fast');
    }, function (target) {
        target.hide('fast');
    });
    propertyIf('hide', function (target) {
        target.hide('fast');
    }, function (target) {
        target.show('fast');
    });
    propertyIf('enabled', function (target) {
        target.removeAttr('disabled');
    }, function (target) {
        target.attr('disabled', 'disabled');
    });
    propertyIf('disabled', function (target) {
        target.attr('disabled', 'disabled');
    }, function (target) {
        target.removeAttr('disabled');
    });
    propertyIf('readonly', function (target) {
        target.attr('readonly', 'readonly');
    }, function (target) {
        target.removeAttr('readonly');
    });
    propertyIf('selected', function (target) {
        target.attr('selected', 'selected');
    }, function (target) {
        target.removeAttr('selected');
    });
    propertyIf('checked', function (target) {
        target.attr('checked', 'checked');
    }, function (target) {
        target.removeAttr('checked');
    });
}
function initClickActions() {
    $("*[" + sing.constants.htmlAttr.Click.Show + "]").each(function () {
        var target = $(this).attr(sing.constants.htmlAttr.Click.Show);
        $(this).click(function () {
            var actionIf = $(this).actionIf(sing.constants.htmlAttr.Click.Show);
            if (!actionIf)
                return;
            $('body').findIDNameSelector(target).show('fast');
        });
    });
    $("*[" + sing.constants.htmlAttr.Click.Hide + "]").each(function () {
        var target = $(this).attr(sing.constants.htmlAttr.Click.Hide);
        $(this).click(function () {
            var actionIf = $(this).actionIf(sing.constants.htmlAttr.Click.Hide);
            if (!actionIf)
                return;
            $('body').findIDNameSelector(target).hide('fast');
        });
    });
    $("*[" + sing.constants.htmlAttr.Click.Toggle + "]").each(function () {
        var target = $(this).attr(sing.constants.htmlAttr.Click.Toggle);
        $(this).click(function () {
            var actionIf = $(this).actionIf(sing.constants.htmlAttr.Click.Toggle);
            if (!actionIf)
                return;
            $('body').findIDNameSelector(target).toggle('fast');
        });
    });
    $("*[" + sing.constants.htmlAttr.Click.FadeIn + "]").each(function () {
        var target = $(this).attr(sing.constants.htmlAttr.Click.FadeIn);
        $(this).click(function () {
            var actionIf = $(this).actionIf(sing.constants.htmlAttr.Click.FadeIn);
            if (!actionIf)
                return;
            $('body').findIDNameSelector(target).fadeIn('fast');
        });
    });
    $("*[" + sing.constants.htmlAttr.Click.FadeOut + "]").each(function () {
        var target = $(this).attr(sing.constants.htmlAttr.Click.FadeOut);
        $(this).click(function () {
            var actionIf = $(this).actionIf(sing.constants.htmlAttr.Click.FadeOut);
            if (!actionIf)
                return;
            $('body').findIDNameSelector(target).fadeOut('fast');
        });
    });
    $("*[" + sing.constants.htmlAttr.Click.FadeToggle + "]").each(function () {
        var target = $(this).attr(sing.constants.htmlAttr.Click.FadeToggle);
        target = $('body').findIDNameSelector(target);
        $(this).click(function () {
            var actionIf = $(this).actionIf(sing.constants.htmlAttr.Click.FadeToggle);
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
    $("*[" + sing.constants.htmlAttr.Click.ToggleClass + "]").each(function () {
        var element = $(this);
        var className = element.attr(sing.constants.htmlAttr.Click.ToggleClass);
        var targetName = element.attr(sing.constants.htmlAttr.Click.ToggleClassTarget);
        var target = $('body').findIDNameSelector(targetName);
        if (target && target.length == 0)
            target = element;
        element.click(function () {
            var actionIf = element.actionIf(sing.constants.htmlAttr.Click.ToggleClass);
            if (!actionIf)
                return;
            target.toggleClass(className);
        });
    });
    $("*[" + sing.constants.htmlAttr.Click.AddClass + "]").each(function () {
        var element = $(this);
        var className = element.attr(sing.constants.htmlAttr.Click.AddClass);
        var targetName = element.attr(sing.constants.htmlAttr.Click.AddClassTarget);
        var target = $('body').findIDNameSelector(targetName);
        if (!target || target.length == 0)
            target = element;
        element.click(function () {
            var actionIf = element.actionIf(sing.constants.htmlAttr.Click.AddClass);
            if (!actionIf)
                return;
            target.addClass(className);
        });
    });
    $("*[" + sing.constants.htmlAttr.Click.RemoveClass + "]").each(function () {
        var element = $(this);
        var className = element.attr(sing.constants.htmlAttr.Click.RemoveClass);
        var targetName = element.attr(sing.constants.htmlAttr.Click.RemoveClassTarget);
        var target = $('body').findIDNameSelector(targetName);
        if (!target || target.length == 0)
            target = element;
        element.click(function () {
            var actionIf = element.actionIf(sing.constants.htmlAttr.Click.RemoveClassTarget);
            if (!actionIf)
                return;
            target.removeClass(className);
        });
    });
}
function initRememberPage() {
    $("*[" + sing.constants.htmlAttr.GoToRememberPage + "]").each(function () {
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
    $("*[" + sing.constants.htmlAttr.EnableRememberPage + "]").each(function () {
        $.cookie('enable-remember-page', true, { expires: 7, path: '/' });
    });
    $("*[" + sing.constants.htmlAttr.RememberPage + "]").each(function () {
        $.cookie('enable-remember-page', false, { expires: 7, path: '/' });
        $.cookie('remember-page', document.URL, { expires: 7, path: '/' });
    });
}
var keyCodeToChar = {
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
var keyCharToCode = {
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
var wysihtml5Editor;
function initKeyBindClick() {
    var down = [];
    $("*[" + sing.constants.htmlAttr.Click.CtrlHref + "]").click(function (e) {
        if (down[keyCharToCode['Ctrl']]) {
            location.href = $(this).attr(sing.constants.htmlAttr.Click.CtrlHref);
            e.preventDefault();
        }
    });
    $("*[" + sing.constants.htmlAttr.Click.ShiftHref + "]").click(function (e) {
        if (down[keyCharToCode['Shift']]) {
            location.href = $(this).attr(sing.constants.htmlAttr.Click.ShiftHref);
            e.preventDefault();
        }
    });
    $("*[" + sing.constants.htmlAttr.Click.AltHref + "]").click(function (e) {
        if (down[keyCharToCode['Alt']]) {
            location.href = $(this).attr(sing.constants.htmlAttr.Click.AltHref);
            e.preventDefault();
        }
    });
    $("*[" + sing.constants.htmlAttr.Click.DoubleHref + "]").on('dblclick', function (e) {
        if (down[keyCharToCode['Alt']]) {
            location.href = $(this).attr(sing.constants.htmlAttr.Click.DoubleHref);
            e.preventDefault();
        }
    });
    $(document).keydown(function (e) {
        down[e.keyCode] = true;
        $("*[" + sing.constants.htmlAttr.Click.KeyBindClick + "]").each(function () {
            var keyCode = $(this).attr(sing.constants.htmlAttr.Click.KeyBindClick);
            var key1;
            var key2;
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
                key1 = keyCode.tryToNumber(null);
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
    }).keyup(function (e) {
        down[e.keyCode] = false;
    });
    var keyBindTip = '';
    $("*[" + sing.constants.htmlAttr.Click.KeyBindClick + "]").each(function () {
        var keyCode = $(this).attr(sing.constants.htmlAttr.Click.KeyBindClick);
        var commandName = $(this).attr(sing.constants.htmlAttr.Click.KeyBindClickName);
        var href = $(this).attr('href');
        var id = $(this).attr('id');
        if (!commandName)
            return;
        var key1;
        if (keyCode.indexOf('+') > 0 && keyCode.indexOf('+') < keyCode.length - 1) {
            console.log(keyCode);
            key1 = stringTryToNumber(keyCode.substr(0, keyCode.indexOf('+')));
            var key2 = stringTryToNumber(keyCode.substr(keyCode.indexOf('+') + 1));
            if (!key1)
                // ReSharper disable once AssignedValueIsNeverUsed
                key1 = keyCharToCode[keyCode.substr(0, keyCode.indexOf('+'))];
            if (!key2)
                // ReSharper disable once AssignedValueIsNeverUsed
                key2 = keyCharToCode[keyCode.substr(keyCode.indexOf('+') + 1)];
            if (href)
                commandName = "<a style='cursor: pointer;' onclick='location.href = \"" + href + "\";'>" + commandName + "</a>";
            else if (id)
                commandName = "<a style='cursor: pointer;' onclick='$(\"#" + id + "\").click();'>" + commandName + "</a>";
            keyBindTip += "<b>" + keyCode.substr(0, keyCode.indexOf('+')) + "+" + keyCode.substr(keyCode.indexOf('+') + 1) + "</b> - " + commandName;
            keyBindTip += '<br>';
        }
        else {
            key1 = stringTryToNumber(keyCode);
            if (!key1)
                // ReSharper disable once AssignedValueIsNeverUsed
                key1 = keyCharToCode[keyCode];
            if (href)
                commandName = "<a style='cursor: pointer;' onclick='location.href = \"" + href + "\";'>" + commandName + "</a>";
            else if (id)
                commandName = "<a style='cursor: pointer;' onclick='$(\"#" + id + "\").click();'>" + commandName + "</a>";
            keyBindTip += "<b>" + keyCode + "</b> - " + commandName;
            keyBindTip += '<br>';
        }
    });
    if (keyBindTip)
        $('#key-bind-page-tip').html(keyBindTip);
    else
        $('#key-bind-page-tip').parent().hide();
}
function initFields() {
    // Adds the tab id to all href in the tab container
    $('.tab-container *[href]').each(function () {
        var href = $(this).attr('href');
        if (href.indexOf('#') < 0) {
            $(this).attr('href', href + "#" + $(this).parent('.ui-tabs-panel').attr('id'));
        }
    });
    $('#randomize-fields').click(function () {
        randomFields();
    });
    try {
        $('.datepicker').datepicker();
    }
    catch (ex) {
    }
    /*    try {
            $('.timepicker').timepicker({ step: 15 });
        } catch (ex) {
        }*/
    // broken
    // $('.spinner-int').spinner();
    try {
        $('.select-list').selectmenu();
    }
    catch (ex) {
    }
    try {
        $('.tab-container').tabs();
    }
    catch (ex) {
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
            var minimum = parseInt($(this).attr('minimum'));
            var maximum = parseInt($(this).attr('maximum'));
            if (val <= minimum || isNaN(val))
                val = minimum;
            if (val >= maximum)
                val = maximum;
            if (val && !isNaN(val)) {
                $("#" + $(this).attr('target')).val(val.toString());
                $("#" + $(this).attr('text-target')).html(val.toString());
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
function randomFields() {
    $('.field[data-type-name]').each(function () {
        var objectType = $(this).attr('data-object-type');
        var dataTypeName = $(this).attr('data-type-name');
        var maximum = parseFloat($(this).attr('maximum'));
        var minimum = parseFloat($(this).attr('minimum'));
        var object = null;
        var chance = new Chance(Math.random);
        if (dataTypeName == 'MultilineText') {
            object = chance.paragraph({ sentences: 6 });
            $(this).find('textarea').val(object);
            return;
        }
        else if (objectType == 'System.String') {
            object = chance.string();
        }
        if (objectType == 'System.Nullable`1[System.Int32]' ||
            objectType == 'System.Int32') {
            if (maximum && minimum) {
                object = chance.integer({ min: minimum, max: maximum });
                $(this).find('.int-range').slider('value', object);
                return;
            }
            else
                object = chance.integer();
        }
        if (objectType == 'System.Nullable`1[System.Guid]' ||
            objectType == 'System.Guid') {
            object = chance.guid();
        }
        if (objectType == 'System.Nullable`1[System.DateTime]' ||
            objectType == 'System.DateTime') {
            if (dataTypeName == 'Date') {
                object = chance.date({ string: true });
            }
            else if (dataTypeName == 'Time') {
                object = chance.hour({ twentyfour: true }) + ":" + chance.minute() + ":" + chance.second();
            }
            else if (dataTypeName == 'DateTime') {
                object = chance.date({ string: true }) + " " + chance.hour({ twentyfour: true }) + ":" + chance.minute() + ":" + chance.second();
            }
        }
        if (dataTypeName == 'PhoneNumber') {
            object = chance.phone();
        }
        if (dataTypeName == 'EmailAddress') {
            object = chance.email();
        }
        if (dataTypeName == 'CreditCard') {
            object = chance.cc();
        }
        if (dataTypeName == 'PostalCode') {
            object = chance.postal();
        }
        if (dataTypeName == 'ImageUrl') {
            object = "https://placekitten.com/g/" + chance.integer({ min: 200, max: 500 }) + "/" + chance.integer({ min: 200, max: 500 });
        }
        if (dataTypeName == 'Url') {
            object = chance.domain();
        }
        if (objectType == 'System.Nullable`1[System.TimeSpan]' ||
            objectType == 'System.TimeSpan') {
        }
        if (objectType == 'System.Nullable`1[System.Boolean]' ||
            objectType == 'System.Boolean') {
            $(this).find('input[type=radio]').each(function () {
                if (chance.bool()) {
                    $(this).click();
                }
            });
        }
        if (objectType == 'System.Nullable`1[System.Single]' ||
            objectType == 'System.Single') {
        }
        var max;
        var selection;
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
        if (object) {
            $(this).find('input').val(object).change();
        }
    });
}
function objectToHtml(obj, parentKey, context) {
    if (parentKey === void 0) { parentKey = null; }
    if (context === void 0) { context = null; }
    if (!obj)
        return '';
    var out = '';
    if (parentKey) {
        // ReSharper disable once AssignedValueIsNeverUsed
        // ReSharper disable once UnusedLocals
        var parentElement = parentKey.before('.').before('#');
        // ReSharper disable once UnusedLocals
        var parentClasses = parentKey.afterFirst('.');
        // ReSharper disable once UnusedLocals
        var parentID = parentKey.after('#');
    }
    if ($.isFunction(obj)) {
        out += obj(context);
    }
    else if ($.isString(obj)) {
    }
    else if ($.isArray(obj)) {
    }
    else if ($.isHash(obj)) {
        var objKeys = $.objKeys(obj);
        for (var key in objKeys) {
            if (objKeys.hasOwnProperty(key)) {
                // ReSharper disable once UnusedLocals
                var objValue = obj[key];
                if ($.isNumber(key)) {
                }
                else if ($.isString(key)) {
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
function htmlToObject(html) {
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
            '_example-attr2': function () { return 'evaluate'; },
            ///////////////////////////////////
            // Element with class longhand (string)
            'span': {
                _class: 'example1'
            },
            // <span class="example1"></span>
            // Element with class shorthand
            'span.example1': {},
            // <span class="example1"></span>
            // Multiple classes longhand
            'div': {
                _classes: ['class1', 'class2']
            },
            // <div class="class1 class2"></div>
            // Multiple classes shorthand
            'div.class1.class2': {},
            // <div class="class1 class2"></div>
            ///////////////////////////////////
            // Element with id longhand
            'div.example2': {
                _id: 'example2'
            },
            // <div class="example2" id="example2"></div>
            // Element with id shorthand
            'div.example2#example2': {},
            // <div class="example2" id="example2"></div>
            ///////////////////////////////////
            // Element with content longhand
            'div#example3': {
                _content: {}
            },
            // <div id="example3">
            // ...
            // </div>
            // Element with indexed content
            'div#example4': {
                0: {},
                1: [],
                2: '',
                3: function () { return ''; }
            },
            // <div id="example4">
            // ...
            // </div>
            // Element with content as a string
            'div#example5': 'content',
            // <div id="example5">content</div>
            // Element with content as a function (string)
            'div#example6': function () {
                return 'content';
            },
            // <div id="example6">content</div>
            // Element with content as a function (object)
            'div#example7': function () {
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
                function () { return 'content2'; },
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
                ]
            },
            ///////////////////////////////////
            // Basic context passing
            'div#example14': {
                _content: function (c) {
                    return (c && c.name) ? c.name : '';
                }
            },
            // Context Looping longhand
            'div#example15': function (c) {
                if (c.items) {
                    return c.items.collect(function (item) { return ({
                        span: {
                            _value: item.value
                        }
                    }); });
                }
            }
        }
    }
};
//# sourceMappingURL=singularity-html.js.map