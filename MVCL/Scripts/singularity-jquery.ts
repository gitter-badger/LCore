/// <reference path="singularity-core.ts"/>

interface JQueryStatic {
    isString?: (obj: any) => boolean;

    toStr?: (obj: any, includeMarkup?: boolean) => string;
    objEach?: (obj: any, eachFunc: (key: string, item: any, i: number) => any) => any[];

    objProperties?: (obj?) => [{ key: string; value: any; }];
    objValues?: (obj?) => any[];
    objKeys?: (obj?) => string[];
    objHasKey?: (obj: Object, key: string) => boolean;
    resolve?: (obj?: Object | Function) => Object;
    
    // numericValueOf
    // $.isArray()
    // $.isDefined()
    // $.isHash()
    // $.isInt()
    // $.isFloat()
    // $.isNumber()
    // $.toArray()
    // $.wait();
    // $.sleep();
}

interface JQuery {
    // Missing from definition
    selectmenu(): JQuery;


    init?: (initFunc: () => void) => void;
    findIDNameSelector?: (name: string) => JQuery;
    checked?: () => boolean;
    allVisible?: () => boolean;
    actionIf?: (name: string) => boolean;

    fillTemplate?: (data: Object, itemKey?: string, itemData?: Object) => JQuery;

    getAttributes?: () => IKeyValue<string, string>[]| IKeyValue<string, string>[][];
}


var singJQuery = sing.addModule(new sing.Module("jQuery", $, $));

singJQuery.requiredDocumentation = false;

/*
//////////////////////////////////////////////////////
//
// jQuery Extensions
//
//
*/

function InitSingularityJS_jQuery() {
    
    singJQuery.addExt('checked', Checked,
        {
            summary: null,
            parameters: null,
            returns: '',
            returnType: '',
            examples: null,
            tests: function (ext) {
            },
        }, $.fn.prototype);

    function Checked() {
        var anyChecked = false;

        this.each(function () {
            if ($(this)[0]['checked'])
                anyChecked = true;
        });

        return anyChecked;
    }

    singJQuery.addExt('allVisible', AllVisible,
        {
            summary: null,
            parameters: null,
            returns: '',
            returnType: '',
            examples: null,
            tests: function (ext) {
            },
        }, $.fn.prototype);

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

    singJQuery.addExt('findIDNameSelector', FindIDNameSelector,
        {
            summary: null,
            parameters: null,
            returns: '',
            returnType: '',
            examples: null,
            tests: function (ext) {
            },
        }, $.fn.prototype);

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

    singJQuery.addExt('actionIf', ActionIf,
        {
            summary: null,
            parameters: null,
            returns: '',
            returnType: '',
            examples: null,
            tests: function (ext) {
            },
        }, $.fn.prototype);

    function ActionIf(name) {

        var target = $(this);

        var ifTargetName = target.attr(name + '-if');

        // If there's no target, there's no condition to match. Always true.
        if (!ifTargetName)
            return true;

        var ifTarget = $('body').findIDNameSelector(ifTargetName);

        var targetValue = <any>(target.attr(name + '-if-value') || '');

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

    singJQuery.addExt('toStr', ToStr,
        {
            summary: null,
            parameters: null,
            returns: '',
            returnType: '',
            examples: null,
            tests: function (ext) {

                ext.addTest(undefined, [null], '');
                ext.addTest(undefined, [null, false], '');
                ext.addTest(undefined, [null, true], 'null');
                ext.addTest(undefined, [undefined], '');
                ext.addTest(undefined, [undefined, false], '');
                ext.addTest(undefined, [undefined, true], 'undefined');

                ext.addTest(undefined, [[]], '');
                ext.addTest(undefined, [[], false], '');
                ext.addTest(undefined, [[], true], '[]');

                ext.addTest(undefined, [{}], '');
                ext.addTest(undefined, [{}, false], '');
                ext.addTest(undefined, [{}, true], '{}');

                ext.addTest(undefined, [NaN], '');
                ext.addTest(undefined, [NaN, false], '');
                ext.addTest(undefined, [NaN, true], 'NaN');


                ext.addTest(undefined, [{ a: 'b', b: 5, c: false, d: [], e: { f: {} } }], 'a: b\r\nb: 5\r\nc: No\r\nd: \r\ne: f: \r\n\r\n');
                ext.addTest(undefined, [{ a: 'b', b: 5, c: false, d: [], e: { f: {} } }, true], '{a: \'b\', b: 5, c: false, d: [], e: {f: {}}}');

                ext.addTest(undefined, [['a']], 'a');
                ext.addTest(undefined, [['a'], false], 'a');
                ext.addTest(undefined, [['a'], true], '[\'a\']');

                ext.addTest(undefined, [[true]], 'Yes');
                ext.addTest(undefined, [[true], false], 'Yes');
                ext.addTest(undefined, [[true], true], '[true]');
                ext.addTest(undefined, [[false]], 'No');
                ext.addTest(undefined, [[false], false], 'No');
                ext.addTest(undefined, [[false], true], '[false]');

                ext.addTest(undefined, [[5]], '5');
                ext.addTest(undefined, [[5], false], '5');
                ext.addTest(undefined, [[5], true], '[5]');

                ext.addTest(undefined, [[false, false, false, false]], 'No\r\nNo\r\nNo\r\nNo');
                ext.addTest(undefined, [[false, false, false, false], false], 'No\r\nNo\r\nNo\r\nNo');
                ext.addTest(undefined, [[false, false, false, false], true], '[false, false, false, false]');
            },
        }, $.fn.prototype);

    function ToStr(obj: any, includeMarkup: boolean = false) {

        if (obj === undefined)
            return includeMarkup ? 'undefined' : '';
        if (obj === null)
            return includeMarkup ? 'null' : '';

        if (obj.toStr)
            return obj.toStr(includeMarkup);

        if (typeof obj == 'object') {
            var out = includeMarkup ? '{' : '';

            var keyCount = Object.keys(obj).length;

            $.objEach(obj, function (key, item, index) {
                if (includeMarkup) {
                    out += key + ': ' + $.toStr(item, true);
                    if (index < keyCount - 1)
                        out += ', ';
                }
                else {
                    out += key + ': ' + $.toStr(item) + '\r\n';
                }
            });

            out += includeMarkup ? '}' : '';
            return out;
        }

        return obj;
    }

    singJQuery.addExt('isString', IsString,
        {
            summary: null,
            parameters: null,
            returns: '',
            returnType: '',
            examples: null,
            tests: function (ext) {
                ext.addTest(undefined, [], false);
                ext.addTest(undefined, [], false);
                ext.addTest(undefined, [], false);
                ext.addTest(undefined, [5], false);
                ext.addTest(undefined, [''], true);
                ext.addTest(undefined, ['a'], true);
            },
        });

    function IsString(str) {
        return typeof str == 'string';
    }

    singJQuery.addExt('objEach', ObjectEach,
        {
            summary: null,
            parameters: null,
            returns: '',
            returnType: '',
            examples: null,
            tests: function (ext) {

                ext.addCustomTest(undefined, function () {

                    var test = { a: 1, b: 2 };
                    var test2 = [];

                    $.objEach(test, function (key, item, index) {
                        test2.push({ key: key, item: item, index: index });
                    });

                    if ($.toStr(test2) != $.toStr([{ key: 'a', item: 1, index: 0 },
                        { key: 'b', item: 2, index: 1 }]))
                        return $.toStr(test2) + '\r\n' + $.toStr([{ key: 'a', item: 1, index: 0 },
                            { key: 'b', item: 2, index: 1 }]);

                }, 'Executes for every element');
            },
        });

    function ObjectEach(obj: Object, eachFunc: (key: string, item: any, index: number) => void): void {

        var keys = Object.keys(obj);

        keys.each(function (key, i) {
            eachFunc(key, obj[key], i);
        });
    }

    singJQuery.addExt('objProperties', ObjectProperties,
        {
            summary: null,
            parameters: null,
            returns: '',
            returnType: '',
            examples: null,
            tests: function (ext) {
                ext.addTest(undefined, [null], []);
                ext.addTest(undefined, [undefined], []);
                ext.addTest(undefined, ['a'], [{ 0: { key: '0', value: 'a' } }]);
                ext.addTest(undefined, [5], []);
                ext.addTest(undefined, [[]], []);
                ext.addTest(undefined, [{}], []);
                ext.addTest(undefined, [{ a: 1, b: 2 }], [{ key: 'a', value: 1 }, { key: 'b', value: 2 }]);
            },
        });

    function ObjectProperties(obj?: Object): { key: string; value: any }[] {
        if (obj == null || !(typeof obj == 'object'))
            return [];

        var keys = Object.keys(obj);

        var values = <[{ key: string; value: any }]>keys.collect(function (item, i) {
            return { key: item, value: obj[item] };
        });

        return values;
    }

    singJQuery.addExt('objValues', ObjectValues,
        {
            summary: null,
            parameters: null,
            validateInput: false,
            returns: '',
            returnType: '',
            examples: null,
            tests: function (ext) {
                ext.addTest(undefined, [null], []);
                ext.addTest(undefined, [undefined], []);
                ext.addTest(undefined, ['a'], []);
                ext.addTest(undefined, ['a', 'b'], []);
                ext.addTest(undefined, [5], []);
                ext.addTest(undefined, [[]], []);
                ext.addTest(undefined, [{}], []);
                ext.addTest(undefined, [{ a: 1, b: 2 }], [1, 2]);
            },
        });

    function ObjectValues(obj?: Object): any[] {
        if (obj == null || !(typeof obj == 'object'))
            return [];

        var keys = Object.keys(obj);

        var values = keys.collect(function (item, i) { return obj[item]; });

        return values;
    }

    singJQuery.addExt('objKeys', ObjectKeys,
        {
            summary: null,
            parameters: null,
            validateInput: false,
            returns: '',
            returnType: '',
            examples: null,
            tests: function (ext) {
                ext.addTest(undefined, [null], []);
                ext.addTest(undefined, [undefined], []);
                ext.addTest(undefined, ['a'], []);
                ext.addTest(undefined, ['a', 'b'], []);
                ext.addTest(undefined, [5], []);
                ext.addTest(undefined, [[]], []);
                ext.addTest(undefined, [{}], []);
                ext.addTest(undefined, [{ a: 1, b: 2 }], ['a', 'b']);
            },
        });

    function ObjectKeys(obj?: Object): string[] {
        if (obj == null || !(typeof obj == 'object'))
            return [];

        var keys = Object.keys(obj);

        return keys;
    }

    singJQuery.addExt('objHasKey', ObjectHasKey,
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

    function ObjectHasKey(obj: Object, key: string): boolean {
        if (obj == null || !(typeof obj == 'object'))
            return false;

        var keys = Object.keys(obj);

        return keys.contains(key);
    }

    singJQuery.addExt('resolve', ObjectResolve,
        {
            summary: null,
            parameters: null,
            validateInput: false,
            returns: '',
            returnType: '',
            examples: null,
            tests: function (ext) {
                ext.addTest(undefined, [5], 5);
                ext.addTest(undefined, ['aa'], 'aa');
                ext.addTest(undefined, [['aa', 'bb']], ['aa', 'bb']);
                ext.addTest(undefined, [function () { return 5; }], 5);
                ext.addTest(undefined, [function () { return 'aa'; }], 'aa');
                ext.addTest(undefined, [function () { return ['aa', 'bb']; }], ['aa', 'bb']);
            },
        });

    function ObjectResolve(obj: any, args: any[]): any {

        if ($.isFunction(obj))
            return obj.apply(null, args);

        if ($.isArray(obj) && obj.length == 1)
            return obj[0];

        return obj;
    }

    /*
    
    // These Work

    <div sing-template="ListTest">
        <ul>
            <li sing-loop="{{person in items}}">
                <a>{{person.name}}</a>
                <a>{{person.age}}</a>
            </li>
        </ul>
    </div>

    <div sing-template="ListTest">
        <ul>
            <li sing-loop="{{items}}">
                <a>{{item.name}}</a>
                <a>{{item.age}}</a>
            </li>
        </ul>
    </div>
    
    <div sing-template="Test">
        <a>{{name}}</a>
        <a>{{age}}</a>
    </div>
    
    // These should work 

    // IF
    <div sing-if="{{item.isAlive}}">
        <a>{{item.name}}</a>
        <a>{{item.age}}</a>
    </div>

    // IF Operators
    <div sing-if="{{item.age > 50}}">
        <a>{{item.name}}</a>
        <a>{{item.age}}</a>
    </div>

    // IF Operators OR
    <div sing-if="{{item.age > 50 || item.age < 5 }}">
        <a>{{item.name}}</a>
        <a>{{item.age}}</a>
    </div>

    // IF Operators AND
    <div sing-if="{{item.age > 50 && item.age != 67 }}">
        <a>{{item.name}}</a>
        <a>{{item.age}}</a>
    </div>
    
    // FILTERS
    <div sing-if="{{item.age : even}}">
        <a>{{item.name}}</a>
        <a>{{item.age}}</a>
    </div>
    
    // FILTERS With Variables
    <div sing-if="{{item.age : even}}">
        <a>{{item.name}}</a>
        <a>{{item.age}}</a>
    </div>
    
    
    // NESTED LOOPS
    <div sing-template="ListTest">
        <ul>
            <li sing-loop="{{person in items}}">
                <a>{{person.name}}</a>
                <a>{{person.age}}</a>

                <ul sing-if="{{person.friends}}">
                    <li sing-loop={{friend in person.friends}}">
                        <a>{{friend.name}}</a>
                        <a>{{friend.age}}</a>                
                    </li>
                </ul>
            </li>
        </ul>
    </div>

    // INDEX (others)
    <div sing-template="ListTest">
        <ul>
            <li sing-loop="{{person in items}}">
                {{index}}

                <a>{{person.name}}</a>
                <a>{{person.age}}</a>
            </li>
        </ul>
    </div>
    
    // Method Calls
    <div sing-template="ListTest">
        <ul>
            <li sing-loop="{{person in items.getPeople()}}">
                {{index}}

                <a>{{person.name}}</a>
                <a>{{person.age}}</a>
            </li>
        </ul>
    </div>

    // Method Calls with arguments

    <div sing-template="ListTest">
        <ul>
            <li sing-loop="{{person in items.getPeople('fred')}}">
                {{index}}

                <a>{{person.name}}</a>
                <a>{{person.age}}</a>
            </li>
        </ul>
    </div>


     */
    singJQuery.addExt('getTemplate', ObjectGetTemplate,
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

    function ObjectGetTemplate(name: string, data?: Object): JQuery {

        var template = $('*[sing-template=' + name + ']').clone();

        if (!template || template.length == 0)
            throw 'Template ' + name + ' not found.';


        if (data != null)
            return template.fillTemplate(data).attr('sing-template-data', 'true');

        return template;
    }

    singJQuery.addExt('fillTemplate', ObjectFillTemplate,
        {
            summary: null,
            parameters: null,
            validateInput: false,
            returns: '',
            returnType: '',
            examples: null,
            tests: function (ext) {
            },
        }, $.fn.prototype);

    function ObjectFillTemplate(data: Object, itemKey: string = '', itemData?: Object): JQuery {

        var template = <JQuery>(this.clone());

        var loops = template.find('*[sing-loop]');

        log('loops', loops);
        for (var i = 0; i < loops.length; i++) {

            var loop = $(loops[i]);

            var loopKey = loop.attr('sing-loop');

            if (loopKey.startsWith(sing.templateStart))
                loopKey = loopKey.substr(sing.templateStart.length);

            if (loopKey.endsWith(sing.templateEnd))
                loopKey = loopKey.substr(0, loopKey.length - sing.templateEnd.length);

            var itemKey = 'item';
            var loopDataKey = itemKey;

            if (loopKey.contains(' in ')) {
                itemKey = loopKey.split(' in ')[0];
                loopKey = loopKey.split(' in ')[1];
            }

            var loopData = [data].findValues(loopKey);


            log('loop', loop, loopKey, itemKey, loopData);

            if (loopData == null || loopData.length == 0) {
            }
            else {

                if ($.isArray(loopData)) {

                    for (var i = 0; i < loopData.length; i++) {

                        var loopClone = loop.clone().removeAttr('sing-loop');

                        loopClone = loopClone.fillTemplate(data, itemKey, <JQuery>loopData[i]);

                        loop.before(loopClone);
                    }
                }
            }
            loop.remove();
        }

        // template attrs
        /*
        var attrs = template.getAttributes() || [];
        for (var attr in attrs) {
            if (attr.value.contains(sing.templateStart) && attr.value.contains(sing.templateEnd)) {
                template.attr(attr.name, attr.value.templateInject(data, itemKey, itemData))
            }
        }
        */
        // template contents
        var html = template.html();
        var templateReplace = html.templateInject(data, itemKey, itemData);

        log(data, itemKey, itemData, html, templateReplace);
        template.html(templateReplace);
        // template children

        return template;
    }

    singJQuery.addExt('getAttributes', GetAttributes,
        {
            summary: null,
            parameters: null,
            validateInput: false,
            returns: '',
            returnType: '',
            examples: null,
            tests: function (ext) {
            },
        }, $.fn.prototype);

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


    singJQuery.addExt('isArray', null,
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
    singJQuery.addExt('isHash', null,
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
    singJQuery.addExt('isInt', null,
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
    singJQuery.addExt('isFloat', null,
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
    singJQuery.addExt('isNumber', null,
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
    singJQuery.addExt('toArray', null,
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
    singJQuery.addExt('sleep', null,
        {
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
    singJQuery.addExt('isDefined', null,
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
}