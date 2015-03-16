/*
//////////////////////////////////////////////////////
//
// jQuery Extensions
//
//
*/

function InitSingularityJS_jQuery() {

    sing.addjQueryFnExt('checked', Checked,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: '',
        examples: null,
        tests: function (ext) {
        },
    });

    function Checked() {
        var anyChecked = false;

        this.each(function () {
            if ($(this)[0].checked)
                anyChecked = true;
        });

        return anyChecked;
    }

    sing.addjQueryFnExt('allVisible', AllVisible,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: '',
        examples: null,
        tests: function (ext) {
        },
    });

    function AllVisible() {

        var allVisible = true;

        this.each(function () {
            var opacity = $(this).attr('opacity');

            if (opacity == 0 || opacity == '0') {
                allVisible = false;
            }

            if ($(this).css('display') == 'none') {
                allVisible = false;
            }
        });

        return allVisible;
    }

    sing.addjQueryFnExt('findIDNameSelector', FindIDNameSelector,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: '',
        examples: null,
        tests: function (ext) {
        },
    });

    function FindIDNameSelector(name) {

        var target = $();

        try {
            target = $(this).find('#' + name);
        } catch (ex) { }

        if (target.length == 0)
            try {
                target = $(this).find('[name=' + name + ']');
            } catch (ex) { }

        if (target.length == 0)
            try {
                target = $(this).find(name);
            } catch (ex) { }

        return target || $();
    }

    sing.addjQueryFnExt('actionIf', ActionIf,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: '',
        examples: null,
        tests: function (ext) {
        },
    });

    function ActionIf(name) {

        var target = $(this);

        var ifTargetName = target.attr(name + '-if');

        // If there's no target, there's no condition to match. Always true.
        if (!ifTargetName)
            return true;

        var ifTarget = $('body').findIDNameSelector(ifTargetName);

        var targetValue = target.attr(name + '-if-value') || '';

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
    };

    //
    //////////////////////////////////////////////////////
    // MOVE to object extensions
    //

    sing.addjQueryExt('isFunction', IsFunction,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: '',
        examples: null,
        tests: function (ext) {
        },
    });

    function IsFunction(obj) {
        return !!(obj && obj.constructor && obj.call && obj.apply);
    }

    sing.addjQueryExt('toStr', ToStr,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: '',
        examples: null,
        tests: function (ext) {
        },
    });

    function ToStr(str, includeMarkup) {
        if (str === undefined)
            return 'undefined';
        if (str === null)
            return 'null';

        if (str.toStr)
            return str.toStr(includeMarkup);

        return str;
    }

    sing.addjQueryExt('isString', IsString,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: '',
        examples: null,
        tests: function (ext) {
        },
    });

    function IsString(str) {
        return typeof str == 'string';
    }

    sing.addjQueryExt('objectEach', ObjectEach,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: '',
        examples: null,
        tests: function (ext) {
        },
    });

    function ObjectEach(src, eachFunc) {

        var keys = Object.keys(src);

        keys.each(function (key, i) {
            eachFunc(key, src[key], i);
        });
    }

    sing.addjQueryExt('objProperties', ObjectProperties,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: '',
        examples: null,
        tests: function (ext) {
        },
    });

    function ObjectProperties(src) {

        var keys = Object.keys(src);

        var values = keys.collect(function (item, i) { return src[item]; });

        return {
            keys: keys,
            values: values
        };
    }

    sing.addjQueryExt('objValues', ObjectValues,
    {
        summary: null,
        parameters: null,
        validateInput: false,
        returns: '',
        returnType: '',
        examples: null,
        tests: function (ext) {
        },
    });

    function ObjectValues(src) {

        var keys = Object.keys(src);

        var values = keys.collect(function (item, i) { return src[item]; });

        return values;
    }


    sing.addjQueryExt('objKeys', ObjectKeys,
    {
        summary: null,
        parameters: null,
        validateInput: false,
        returns: '',
        returnType: '',
        examples: null,
        tests: function (ext) {
        },
    });

    function ObjectKeys(src) {

        var keys = Object.keys(src);

        return keys;
    }

    sing.addjQueryExt('resolve', ObjectResolve,
    {
        summary: null,
        parameters: null,
        validateInput: false,
        returns: '',
        returnType: '',
        examples: null,
        tests: function (ext) {
        },
    });

    function ObjectResolve(src, args) {

        if ($.isFunction(src))
            return src.apply(null, args);

        if ($.isArray(src) && src.length == 1)
            return src[0];

        return src;
    }


    // $.resolve()
    // $.isArray()
    // $.isHash()
    // $.isInt()
    // $.isFloat()
    // $.isNumber()
    // $.toArray()
    // $.wait();
    // $.sleep();
}