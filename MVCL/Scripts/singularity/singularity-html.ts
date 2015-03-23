/// <reference path="../definitions/jquery.d.ts" />
/// <reference path="../definitions/jqueryui.d.ts" />
/// <reference path="../definitions/jquery.cookie.d.ts" />
/// <reference path="../definitions/jquery.timepicker.d.ts" />
/// <reference path="../definitions/chance.d.ts" />

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
// TODO: Write
// *[click-animate]
// *[click-animate-target]          (optional, default is self)
// *[click-animate-duration]        (optional)
// *[click-animate-easing]          (optional)
// *[click-animate-if]              (optional)
// *[click-animate-if-value]        (optional)
//
// TODO: Write
// *[click-scroll-to]
// *[click-scroll-to-if]              (optional)
// *[click-scroll-to-if-value]        (optional)
//
// TODO: Write
// *[click-text]
// *[click-text-target]             (optional, default is self)
// *[click-text-if]                 (optional)
// *[click-text-if-value]           (optional)
// 
// TODO: Write
// *[click-html]
// *[click-html-target]             (optional, default is self)
// *[click-html-if]                 (optional)
// *[click-html-if-value]           (optional)
//
//////////////////////////////////////////////////////
//
// CSS Class Settings
//
// TODO: Write
// *[class-if]
// *[class-if-value]
//
// Attribute setting
//
// TODO: Write
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
// TODO test
//
// *[readonly-if]
// *[readonly-if-value]
// TODO test
//
// *[selected-if]
// *[selected-if-value]
// TODO test
//
// *[checked-if]
// *[checked-if-value]
//
//*[ctrl-href]
//*[shift-href]
//*[alt-href]
//*[double-href]
// TODO: test
//*[key-bind-click]
//#key-bind-page-tip
//////////////////////////////////////////////////////
//
// Field Extensions
// TODO: Test
//.tab-container *[href]
//.datepicker
//.timepicker
//.spinner-int
//.select-list
//.tab-container
//.spinner-money
//.int-range
//.spinner-decimal
//
//////////////////////////////////////////////////////
// #endregion Comments


var singHTML = singString.addModule(new sing.Module('HTML', String));

singHTML.requiredDocumentation = false;

singHTML.method('textToHTML', StringTextToHTML,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

function StringTextToHTML(): string {

    return this.replaceAll('\r\n', '\n')
        .replaceAll('\r\n', '<br/>')
        .replaceAll(' ', '&nbsp;');
}


singHTML.method('stripHTML', StringStripHTML,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

function StringStripHTML() {

    var out = <string>this;

    var pattern = /.*\<(.+)\>.*/

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
        tests: function (ext) {
        },
    }, $.fn);

function GetAttributes(): IKeyValue<string, string>[]| IKeyValue<string, string>[][] {

    var out = [];
    this.each(function (item) {
        var attrOut = [];
        var props = $.objProperties(this.attributes);
        for (var i = 0; i < props.length; i++) {
            if (props[i].key != 'length')
                attrOut.push(props[i].value);
        }
        if (attrOut.length > 0)
            out.push(attrOut);
    });

    if (out.length == 1)
        return out.collect(function (item) {

            return item.collect(function (item) {
                return {
                    name: item.nodeName,
                    value: item.nodeValue,
                };
            });
        });

    return out.collect(function (item) {
        return {
            name: item.nodeName,
            value: item.nodeValue,
        }
    })
}


////////////////////////////////////////////////////////////////////////////////////////////////////

function InitHTMLExtensions() {

    InitKeyBindClick();

    InitRememberPage();

    InitClickActions();

    InitPropertyIf();


    $('ul#menu a').each(function () {
        if (document.URL.indexOf($(this).attr('href')) > 0) {
            $('.active-page').removeClass('active-page');
            $(this).addClass('active-page');
        }
    });

    $('*[focus-first]').each(function () {
        var target = $(this).attr('focus-first');

        var targets = $(this).find(target);

        if (targets && targets.length > 0)
            targets[0].focus();
    });

    $('*[click-animate]').each(function () {
        var element = $(this);

        var animation = element.attr('click-animate');

        var duration = <any>element.attr('click-animate-duration') || null;

        if (duration)
            duration = parseFloat(duration);

        var easing = element.attr('click-animate-easing') || null;

        var targetName = element.attr('click-animate-target');

        var target = $('body').findIDNameSelector(targetName);

        if (!target || target.length == 0 || !target.animate)
            target = element;

        element.click(function () {

            var actionIf = element.actionIf('click-animate');

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
    })

    $('.close-dialog .close-button').click(function () {
        $(this).parent().fadeOut(300);
    })
}

function PropertyIf(propertyName, changeTrue, changeFalse) {

    $('*[' + propertyName + '-if]').each(function () {
        var propertyTarget = $(this);

        var ifTargetName = propertyTarget.attr(propertyName + '-if');

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

                valueTarget.on(events, changeFunction)

                // Sets the value initially
                changeFunction();
            });

        }
    });
}

function InitPropertyIf() {
    PropertyIf('show',
        function (target) {
            target.show('fast');
        },
        function (target) {
            target.hide('fast');
        });

    PropertyIf('hide',
        function (target) {
            target.hide('fast');
        },
        function (target) {
            target.show('fast');
        });

    PropertyIf('enabled',
        function (target) {
            target.removeAttr('disabled');
        },
        function (target) {
            target.attr('disabled', 'disabled');
        });

    PropertyIf('disabled',
        function (target) {
            target.attr('disabled', 'disabled');
        },
        function (target) {
            target.removeAttr('disabled');
        });

    PropertyIf('readonly',
        function (target) {
            target.attr('readonly', 'readonly');
        },
        function (target) {
            target.removeAttr('readonly');
        });

    PropertyIf('selected',
        function (target) {
            target.attr('selected', 'selected');
        },
        function (target) {
            target.removeAttr('selected');
        });

    PropertyIf('checked',
        function (target) {
            target.attr('checked', 'checked');
        },
        function (target) {
            target.removeAttr('checked');
        });

}

function InitClickActions() {

    $('*[click-show]').each(function () {

        var target = $(this).attr('click-show');

        $(this).click(function () {

            var actionIf = $(this).actionIf('click-show');

            if (!actionIf)
                return;

            $('body').findIDNameSelector(target).show('fast');
        });
    });

    $('*[click-hide]').each(function () {

        var target = $(this).attr('click-hide');

        $(this).click(function () {
            var actionIf = $(this).actionIf('click-hide');

            if (!actionIf)
                return;

            $('body').findIDNameSelector(target).hide('fast');
        });
    });

    $('*[click-toggle]').each(function () {

        var target = $(this).attr('click-toggle');

        $(this).click(function () {
            var actionIf = $(this).actionIf('click-toggle');

            if (!actionIf)
                return;

            $('body').findIDNameSelector(target).toggle('fast');
        });
    });

    $('*[click-fade-in]').each(function () {

        var target = $(this).attr('click-fade-in');

        $(this).click(function () {

            var actionIf = $(this).actionIf('click-fade-in');

            if (!actionIf)
                return;

            $('body').findIDNameSelector(target).fadeIn('fast');
        });
    });

    $('*[click-fade-out]').each(function () {

        var target = $(this).attr('click-fade-out');

        $(this).click(function () {

            var actionIf = $(this).actionIf('click-fade-out');

            if (!actionIf)
                return;

            $('body').findIDNameSelector(target).fadeOut('fast');
        });
    });

    $('*[click-fade-toggle]').each(function () {

        var target = <any>$(this).attr('click-fade-toggle');

        target = $('body').findIDNameSelector(target);

        $(this).click(function () {

            var actionIf = $(this).actionIf('click-fade-toggle');

            if (!actionIf)
                return;

            if (target.allVisible())
                target.fadeOut('fast');
            else
                target.fadeIn('fast');
        });
    });

    $('*[click-toggle-class]').each(function () {

        var element = $(this);

        var className = element.attr('click-toggle-class');

        var targetName = element.attr('click-toggle-class-target');

        var target = $('body').findIDNameSelector(targetName);

        if (target && target.length == 0)
            target = element;

        element.click(function () {

            var actionIf = element.actionIf('click-toggle-class');

            if (!actionIf)
                return;

            target.toggleClass(className);
        });
    });

    $('*[click-add-class]').each(function () {

        var element = $(this);

        var className = element.attr('click-add-class');

        var targetName = element.attr('click-add-class-target');

        var target = $('body').findIDNameSelector(targetName);

        if (!target || target.length == 0)
            target = element;

        element.click(function () {

            var actionIf = element.actionIf('click-add-class');

            if (!actionIf)
                return;

            target.addClass(className);
        });
    });

    $('*[click-remove-class]').each(function () {

        var element = $(this);

        var className = element.attr('click-remove-class');

        var targetName = element.attr('click-remove-class-target');

        var target = $('body').findIDNameSelector(targetName);

        if (!target || target.length == 0)
            target = element;

        element.click(function () {

            var actionIf = element.actionIf('click-remove-class');

            if (!actionIf)
                return;

            target.removeClass(className);
        });
    });
}

function InitRememberPage() {
    $('*[go-to-remember-page]').each(function () {
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

    $('*[enable-remember-page]').each(function () {
        $.cookie('enable-remember-page', true, { expires: 7, path: '/' });
    });

    $('*[remember-page]').each(function () {
        $.cookie('enable-remember-page', false, { expires: 7, path: '/' });
        $.cookie('remember-page', document.URL, { expires: 7, path: '/' });
    });
}

var keyCodeToChar = { 8: "Backspace", 9: "Tab", 13: "Enter", 16: "Shift", 17: "Ctrl", 18: "Alt", 19: "Pause/Break", 20: "Caps Lock", 27: "Esc", 32: "Space", 33: "Page Up", 34: "Page Down", 35: "End", 36: "Home", 37: "Left", 38: "Up", 39: "Right", 40: "Down", 45: "Insert", 46: "Delete", 48: "0", 49: "1", 50: "2", 51: "3", 52: "4", 53: "5", 54: "6", 55: "7", 56: "8", 57: "9", 65: "A", 66: "B", 67: "C", 68: "D", 69: "E", 70: "F", 71: "G", 72: "H", 73: "I", 74: "J", 75: "K", 76: "L", 77: "M", 78: "N", 79: "O", 80: "P", 81: "Q", 82: "R", 83: "S", 84: "T", 85: "U", 86: "V", 87: "W", 88: "X", 89: "Y", 90: "Z", 91: "Windows", 93: "Right Click", 96: "Numpad 0", 97: "Numpad 1", 98: "Numpad 2", 99: "Numpad 3", 100: "Numpad 4", 101: "Numpad 5", 102: "Numpad 6", 103: "Numpad 7", 104: "Numpad 8", 105: "Numpad 9", 106: "Numpad *", 107: "Numpad +", 109: "Numpad -", 110: "Numpad .", 111: "Numpad /", 112: "F1", 113: "F2", 114: "F3", 115: "F4", 116: "F5", 117: "F6", 118: "F7", 119: "F8", 120: "F9", 121: "F10", 122: "F11", 123: "F12", 144: "Num Lock", 145: "Scroll Lock", 182: "My Computer", 183: "My Calculator", 186: ";", 187: "=", 188: ",", 189: "-", 190: ".", 191: "/", 192: "`", 219: "[", 220: "\\", 221: "]", 222: "'" };
var keyCharToCode = { "Backspace": 8, "Tab": 9, "Enter": 13, "Shift": 16, "Ctrl": 17, "Alt": 18, "Pause/Break": 19, "Caps Lock": 20, "Esc": 27, "Space": 32, "Page Up": 33, "Page Down": 34, "End": 35, "Home": 36, "Left": 37, "Up": 38, "Right": 39, "Down": 40, "Insert": 45, "Delete": 46, "0": 48, "1": 49, "2": 50, "3": 51, "4": 52, "5": 53, "6": 54, "7": 55, "8": 56, "9": 57, "A": 65, "B": 66, "C": 67, "D": 68, "E": 69, "F": 70, "G": 71, "H": 72, "I": 73, "J": 74, "K": 75, "L": 76, "M": 77, "N": 78, "O": 79, "P": 80, "Q": 81, "R": 82, "S": 83, "T": 84, "U": 85, "V": 86, "W": 87, "X": 88, "Y": 89, "Z": 90, "Windows": 91, "Right Click": 93, "Numpad 0": 96, "Numpad 1": 97, "Numpad 2": 98, "Numpad 3": 99, "Numpad 4": 100, "Numpad 5": 101, "Numpad 6": 102, "Numpad 7": 103, "Numpad 8": 104, "Numpad 9": 105, "Numpad *": 106, "Numpad +": 107, "Numpad -": 109, "Numpad .": 110, "Numpad /": 111, "F1": 112, "F2": 113, "F3": 114, "F4": 115, "F5": 116, "F6": 117, "F7": 118, "F8": 119, "F9": 120, "F10": 121, "F11": 122, "F12": 123, "Num Lock": 144, "Scroll Lock": 145, "My Computer": 182, "My Calculator": 183, ";": 186, "=": 187, ",": 188, "-": 189, ".": 190, "/": 191, "`": 192, "[": 219, "\\": 220, "]": 221, "'": 222 };


function InitKeyBindClick() {
    var down = [];

    $('*[ctrl-href]').click(function (e) {

        if (down[keyCharToCode['Ctrl']]) {
            location.href = $(this).attr('ctrl-href');

            e.preventDefault();
        }
    });

    $('*[shift-href]').click(function (e) {

        if (down[keyCharToCode['Shift']]) {
            location.href = $(this).attr('shift-href');

            e.preventDefault();
        }
    });

    $('*[alt-href]').click(function (e) {

        if (down[keyCharToCode['Alt']]) {
            location.href = $(this).attr('alt-href');

            e.preventDefault();
        }
    });

    $('*[double-href]').on('dblclick', function (e) {

        if (down[keyCharToCode['Alt']]) {
            location.href = $(this).attr('alt-href');

            e.preventDefault();
        }
    });

    $(document).keydown(function (e) {

        down[e.keyCode] = true;


        $('*[key-bind-click]').each(function () {

            var keyCode = $(this).attr('key-bind-click');

            if (keyCode.indexOf('+') > 0 && keyCode.indexOf('+') < keyCode.length - 1) {
                var key1 = parseInt(keyCode.substr(0, keyCode.indexOf('+')));
                var key2 = parseInt(keyCode.substr(keyCode.indexOf('+') + 1));

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

                var key1 = <number>keyCode.tryToNumber(null);

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

    var KeyBindTip = '';

    $('*[key-bind-click]').each(function () {
        var keyCode = $(this).attr('key-bind-click');
        var commandName = $(this).attr('key-bind-click-name');
        var href = $(this).attr('href');
        var id = $(this).attr('id');

        if (!commandName)
            return;

        if (keyCode.indexOf('+') > 0 && keyCode.indexOf('+') < keyCode.length - 1) {
            var key1 = <number>keyCode.substr(0, keyCode.indexOf('+')).tryToNumber(null);
            var key2 = <number>keyCode.substr(keyCode.indexOf('+') + 1).tryToNumber(null);

            if (!key1)
                key1 = keyCharToCode[keyCode.substr(0, keyCode.indexOf('+'))];
            if (!key2)
                key2 = keyCharToCode[keyCode.substr(keyCode.indexOf('+') + 1)];


            if (href)
                commandName = "<a style='cursor: pointer;' onclick='location.href = \"" + href + "\";'>" + commandName + "</a>";
            else if (id)
                commandName = "<a style='cursor: pointer;' onclick='$(\"#" + id + "\").click();'>" + commandName + "</a>";

            KeyBindTip += "<b>" + keyCodeToChar[key1] + "+" + keyCodeToChar[key2] + "</b> - " + commandName;
            KeyBindTip += "<br>";
        }
        else {
            var key1 = keyCode.tryToNumber(null);

            if (!key1)
                key1 = keyCharToCode[keyCode];

            if (href)
                commandName = "<a style='cursor: pointer;' onclick='location.href = \"" + href + "\";'>" + commandName + "</a>";
            else if (id)
                commandName = "<a style='cursor: pointer;' onclick='$(\"#" + id + "\").click();'>" + commandName + "</a>";


            KeyBindTip += "<b>" + keyCodeToChar[key1] + "</b> - " + commandName
            KeyBindTip += "<br>";
        }
    });

    if (KeyBindTip)
        $("#key-bind-page-tip").html(KeyBindTip);
    else
        $("#key-bind-page-tip").parent().hide();

}

function InitFields() {

    // Adds the tab id to all href in the tab container
    $('.tab-container *[href]').each(function () {

        var href = $(this).attr('href');

        if (href.indexOf('#') < 0) {
            $(this).attr('href', href + '#' + $(this).parent('.ui-tabs-panel').attr('id'));
        }
    });

    $('#randomize-fields').click(function () {
        RandomFields();
    });

    $('.datepicker').datepicker();

    $('.timepicker').timepicker({ 'step': 15 });

    $('.spinner-int').spinner();

    $('.select-list').selectmenu();

    $('.tab-container').tabs();

    $('.spinner-money').spinner({
        min: 0,
        max: 1000000,
        step: 1,
        start: 1000,
        numberFormat: "C"
    });

    $("img[error-src]").error(function () {
        $(this).attr('src', $(this).attr('error-src'));
    });

    $('.int-range').each(function () {
        var val = parseInt($(this).attr('value'));
        var minimum = parseInt($(this).attr('minimum'));
        var maximum = parseInt($(this).attr('maximum'));

        if (val <= minimum || isNaN(val))
            val = minimum;
        if (val >= maximum)
            val = maximum;

        if (val && !isNaN(val)) {
            $('#' + $(this).attr('target')).val(val.toString());
            $('#' + $(this).attr('text-target')).html(val.toString());

            $(this).slider({
                range: "min",
                min: minimum,
                max: maximum,
                value: val,
                slide: function (event, ui) {
                    $('#' + $(this).attr('target')).val(ui.value);
                    $('#' + $(this).attr('text-target')).html(ui.value);
                },
                change: function (event, ui) {
                    $('#' + $(this).attr('target')).val(ui.value);
                    $('#' + $(this).attr('text-target')).html(ui.value);
                }
            });
        }
        //                $('#' + $(this).attr('target')).val($(this).slider("value"));
        //                $('#' + $(this).attr('text-target')).val($(this).slider("value"));
    });

    $(".spinner-decimal").spinner({
        step: 0.01,
        numberFormat: "n"
    });
}

function RandomFields() {

    $('.field[data-type-name]').each(function () {
        var ObjectType = $(this).attr('data-object-type');
        var DataTypeName = $(this).attr('data-type-name');

        var Maximum = parseFloat($(this).attr('maximum'));
        var Minimum = parseFloat($(this).attr('minimum'));

        var Object = null;

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
                Object = chance.hour({ twentyfour: true }) + ':' +
                chance.minute() + ":" + chance.second();
            }
            else if (DataTypeName == 'DateTime') {
                Object = chance.date({ string: true }) + " " +
                chance.hour({ twentyfour: true }) + ':' +
                chance.minute() + ":" + chance.second();
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
            Object = "https://placekitten.com/g/" + chance.integer({ min: 200, max: 500 }) + '/' + chance.integer({ min: 200, max: 500 });
        }
        if (DataTypeName == 'Url') {
            Object = chance.domain();
        }


        if (ObjectType == 'System.Nullable`1[System.TimeSpan]' ||
            ObjectType == 'System.TimeSpan') {
            //    Object = chance.hour({ twentyfour: true }) + ':' +
            //            chance.minute() + ":" + chance.second() + ":" + chance.millisecond();
        }

        if (ObjectType == 'System.Nullable`1[System.Boolean]' ||
            ObjectType == 'System.Boolean') {

            $(this).find('input[type=radio]').each(function () {
                if (chance.bool()) {
                    $(this).click();
                }
            })
        }

        if (ObjectType == 'System.Nullable`1[System.Single]' ||
            ObjectType == 'System.Single') {

        }

        if ($(this).find('select option').length > 0) {
            var max = $(this).find('select option').length;
            var selection = chance.integer({ min: 0, max: max - 1 });

            $(this).find('option')[selection].click();
        }

        if ($(this).find('ui-menu ui-menu-item').length > 0) {
            var max = $(this).find('ui-menu ui-menu-item').length;
            var selection = chance.integer({ min: 0, max: max - 1 });

            $(this).find('ui-menu ui-menu-item')[selection].click();
        }

        if (Object) {
            $(this).find('input').val(Object).change();
        }

    });
}
