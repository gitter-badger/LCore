/// <reference path="singularity-core.ts"/>


interface String {

    templateInject?: (obj: Object, _context?: Object) => string;
    templateExtract?: (template: string) => Object;

}

interface JQueryStatic {

    getTemplate?: (name: string, data?: Object) => JQuery;

}

interface JQuery {

    singIf?: (data?: any, _context?: Object, deferred?: boolean) => void;
    singFill?: (data?: any, _context?: Object, deferred?: boolean) => void;
    singLoop?: (data?: any, _context?: Object, deferred?: boolean) => void;

    fillTemplate?: (data: Object, _context?: Object, deferred?: boolean) => void;
}

interface ITemplateContext {

    name?: string;
    data: any;

}

var singTemplates = singCore.addModule(new sing.Module('Templates', String));

sing.templatePatternGlobal = /^.*{\{\{(.+)\}\}}+.*/g;
sing.templatePattern = /.*\{\{(.+)\}\}.*/;
sing.templateStart = '{{';
sing.templateEnd = '}}';

function StringExtract(template: string, obj: any): any {

    var matches = this.match(/\[()\]/);
    /*
    $.objEach(function (key: string, item: any, index: number):any {

        if (template.contains('{' + key + '}')) {
        }
        return null;
    });
    */
}

singTemplates.method('templateInject', StringTemplateInject,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

function StringTemplateInject(obj: Object, _context?: Hash<any>): string {

    var out = this.toString();

    var matches = out.match(sing.templatePattern) || [];

    while (matches.length > 0) {

        var key = matches[1];

        if (key.contains(' with ')) {
            // sing-fill template. ignore.

            out = out.replace(sing.templateStart + key + sing.templateEnd, '<<' + key + '>>');
            matches = out.match(sing.templatePattern) || [];
            continue;
        }

        var value: any = null;

        value = sing.resolveKey(key, obj, _context);

        if (value == null)
            throw 'could not find key ' + key;

        var valueTemplate = sing.getTemplateName(value);

        if (valueTemplate != null) {
            var valueTemplateHtml = $.getTemplate(valueTemplate);

            if (valueTemplateHtml) {

                var valueTemplateStr = valueTemplateHtml.outerHtml().templateInject(value, _context);

                return valueTemplateStr;
            }
        }
        if (value != null && value != undefined) {

            out = out.replace(sing.templateStart + key + sing.templateEnd, value.toString());

        }
        // Remove template if no data is found
        else {
            out = out.replace(sing.templateStart + key + sing.templateEnd, '');
        }
        matches = out.match(sing.templatePattern) || [];
    }

    return out;
}

singTemplates.method('templateExtract', StringTemplateExtract,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

function StringTemplateExtract(template: string): any {
    var src = <string>this;

    var templateValues = <string[]>[];

    var templateKeys = <string[]>[];

    while (src.length > 0) {

        if (template.length > 1 && template[0] == '{' && template[1] == '{') {
            var templateValue = '';
            var templateKey = '';

            while (template.length > 0) {

                if (template[0] == '}' && template.length > 1 && template[1] != '}') {
                    template = template.substr(1);
                    break;
                }
                else if (template[0] != '{' && template[0] != '}') {
                    templateKey += template[0];
                }

                template = template.substr(1);
            }

            while (src.length > 1 && src[0] != template[0] && src[1] != template[1]) {
                templateValue += src[0];
                src = src.substr(1);
            }


            templateValues.push(templateValue);
            templateKeys.push(templateKey);
        }

        src = src.substr(1);
        template = template.substr(1);
    }

    if (templateKeys.length != templateValues.length) {
        throw 'Template did not match.';
    }

    var out = {};

    for (var i = 0; i < templateKeys.length; i++) {
        var key = templateKeys[i];

        if (key.contains('.')) {
            var keyParts = key.split('.');

            var cursor: any = out;

            for (var j = 0; j < keyParts.length; j++) {
                if (cursor[keyParts[j]] === undefined) {
                    cursor[keyParts[j]] = j == keyParts.length - 1 ? templateValues[i].tryToNumber() : {};
                }
                cursor = cursor[keyParts[j]];
            }
        }
    }

    return out;
}

////////////////////////////////////////////////////////////////////////////////////////////////

singTemplates.method('getTemplate', ObjectGetTemplate,
    {
        summary: null,
        parameters: null,
        validateInput: false,
        returns: '',
        returnType: '',
        examples: null,
        tests: function (ext) {
        },
    }, $);

function ObjectGetTemplate(name: string, data?: Object): JQuery {

    var template = <any>sing.templates[name];

    if (!template || template.length == 0)
        return null;

    template = $(template);

    if ($.isDefined(data)) {
        try {
            return template.attr('sing-template-data', 'true').fillTemplate(data);


        } catch (ex) {
            return $('<error>' + ex + ' ' + ex.stack + '</error>');
        }
    }
    return template;
}

singTemplates.method('getTemplateFor', ObjectGetTemplateFor, {}, sing);

function ObjectGetTemplateFor(obj?: Object) {



}

singTemplates.method('fillTemplate', JQueryFillTemplate,
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

var deferred = 0;
var deferredDone = 0;

function JQueryFillTemplate(data: any, _context?: Hash<any>, forceFill: boolean = false): void {

    _context = sing.loadContext(_context);

    var template = <JQuery>(this);

    var visible = template.isOnScreen(0.01, 0.01);

    if (!forceFill && !visible && template.attr('sing-deferred') != 'true') {

        // Mark element as deferred to avoid inifinite loop.
        template.attr('sing-deferred', 'true');

        var tempHtml = template.outerHtml();

        var thisDeferredID = deferred;

        template.attr('defer-id', thisDeferredID);
        template.html('DEFERRED');

        deferred++;

        _context = $.extend(true, {}, _context);

        (function () {
            try {
                var deferTemplate = $('*[defer-id=' + thisDeferredID + ']');
                var newTemplate = $(tempHtml);

                deferTemplate.before(newTemplate);
                deferTemplate.remove();

                newTemplate.fillTemplate(data, _context, true);

                deferredDone++;

            }
            catch (ex) {
                error(ex);
            }

        }).fn_defer()();
        return;
    }

    var ifs = template.find('*[sing-if]');

    ifs.each(function () {
        $(this).singIf(data, _context, true);
    });

    var loops = template.find('*[sing-loop]');
    loops.each(function () {
        $(this).singLoop(data, _context, true);
    });

    var fills = template.find('*[sing-fill]');

    fills.each(function () {
        $(this).singFill(data, _context, forceFill);
    });
    if (template.attr('sing-fill') && template.attr('sing-fill').length > 0)
        template.singFill(data, _context, forceFill);

    var html = template[0].outerHTML;
    var templateReplace = html.templateInject(data, _context);
    template.replaceWith($(templateReplace));

    if (sing.templateShownFunctions && sing.templateShownFunctions.length > 0) {
        sing.templateShownFunctions.each(function (fn) {
            fn(template);
        });
    }
}

singTemplates.method('singIf', JQueryPerformSingIf,
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

function JQueryPerformSingIf(data?: any, _context?: Hash<any>, forceFill: boolean = false) {

    _context = sing.loadContext(_context);

    var srcThis = <JQuery>this;
    

    // Don't perform if for elements within templates
    var parent = srcThis.parent('*[sing-template]');

    if (parent.length != 0 && parent.attr('sing-template-data') != 'true')
        return;

    var mode = 'sing-if';
    var condition = '';

    if ($(this).hasAttr('sing-else-if')) {
        mode = 'sing-else-if';
        condition = $(this).attr('sing-else-if');
    }
    else if ($(this).hasAttr('sing-else')) {
        mode = 'sing-else';
        condition = '';
    }
    else {
        condition = $(this).attr('sing-if');
    }

    condition = condition || '';

    if (condition.startsWith(sing.templateStart))
        condition = condition.substr(sing.templateStart.length);
    if (condition.endsWith(sing.templateEnd))
        condition = condition.substr(0, condition.length - sing.templateEnd.length);

    if (mode == 'sing-else') {
        sourceData = true;
    }
    else {
        var sourceData = sing.resolveKey(condition, data, _context);

        if (!$.isDefined(sourceData))
            sourceData = false;
    }

    srcThis.removeAttr(mode);

    var next = srcThis.next();

    if (srcThis.siblings().length > 0) {

        next = next;
    }

    if ($.isEmpty(sourceData) ||
        sourceData === false ||
        sourceData === 0 ||
        sourceData == [] ||
        ($.isString(sourceData) && sourceData && sourceData.startsWith('<error>could not resolve'))) {
        srcThis.remove();
        
        // Evaluate all subsequent else-if and else tags if the result is false.
        if (next && next.length == 1 && (next.hasAttr('sing-else-if') || next.hasAttr('sing-else'))) {
            next.singIf(data, _context);
        }

        return $();
    }
    else {
        // Remove all subsequent else-if and else tags if the result is true.
        while (next && next.length > 0 && (next.hasAttr('sing-else-if') || next.hasAttr('sing-else'))) {
            var last = next;
            next = last.next();
            last.remove();

        }

        return srcThis;
    }

}

singTemplates.method('singFill', JQueryPerformSingFill,
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

function JQueryPerformSingFill(data?: any, _context?: Hash<any>, forceFill: boolean = false) {

    _context = sing.loadContext(_context);

    var srcThis = <JQuery>this;
    
    // Don't perform fill for elements within templates
    var parent = srcThis.parent('*[sing-template]');

    if (parent.length != 0 && parent.attr('sing-template-data') != 'true')
        return;

    var fillWith = $(this).attr('sing-fill');

    if (fillWith.startsWith(sing.templateStart) || fillWith.startsWith('<<'))
        fillWith = fillWith.substr(sing.templateStart.length);
    if (fillWith.endsWith(sing.templateEnd) || fillWith.endsWith('>>'))
        fillWith = fillWith.substr(0, fillWith.length - sing.templateEnd.length);

    // No template - target self.

    var template = <JQuery>null;
    var source = '';

    if (!fillWith.contains(' with ')) {
        template = srcThis;
        source = fillWith;
    }
    else {

        var fill = fillWith.split(' with ')[0].trim();

        source = fillWith.split(' with ')[1].trim();

        //        console.log('SING-FILL ' + fill + ' WITH ' + source);

        template = $.getTemplate(fill);

        srcThis.html('');
        srcThis.prepend(template);
    }


    if (!template || template.length == 0)
        throw 'could not find template ' + fill;

    var sourceData: any;

    if (source.contains(' as ')) {
        var after = source.after(' as ');
        var sourceData = sing.resolveKey(source.before(' as '), data, _context);

        // Copy context because a key is duplicated
        if (_context['after'] !== undefined) {
            _context = $.extend(true, {}, _context);
        }

        _context[after] = sourceData;
    }
    else {
        sourceData = sing.resolveKey(source, data, _context);
    }


    if (!$.isDefined(sourceData))
        throw 'could not find data ' + source;

    template.removeAttr('sing-template');
    srcThis.removeAttr('sing-fill');
    srcThis.attr('sing-data-type', $.typeName(sourceData));
    if (fill)
        srcThis.attr('sing-template-name', fill.toSlug());

    try {
        // Clear data so that sub-templates will have access to their own data sets.
        _context['$data'] = undefined;
        srcThis.fillTemplate(sourceData, _context, forceFill);

    } catch (ex) {

        console.trace();
        srcThis.html('<error>' + ex + ' ' + ex.stack + '</error>');

    }

    return srcThis;
}

singTemplates.method('singLoop', JQueryPerformSingLoop,
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

function JQueryPerformSingLoop(data: any, _context?: Hash<any>, forceFill: boolean = false): void {

    _context = sing.loadContext(_context);

    var loop = <JQuery>this;

    var loopKey = loop.attr('sing-loop');

    if (loopKey.startsWith(sing.templateStart))
        loopKey = loopKey.substr(sing.templateStart.length);

    if (loopKey.endsWith(sing.templateEnd))
        loopKey = loopKey.substr(0, loopKey.length - sing.templateEnd.length);

    var loopDataKey = itemKey;
    var itemKey = '$item';
    if (loopKey.contains(' in ')) {
        itemKey = loopKey.split(' in ')[0].trim();
        loopKey = loopKey.split(' in ')[1].trim();
    }
    else {
        var tempNumber = 0;
        while (_context[itemKey + (tempNumber == 0 ? '' : tempNumber)] !== undefined) {
            tempNumber++;
        }
        //itemKey.push(itemKey.trim());
    }

    var itemDataIndex = itemKey.length - 1;
    var loopData = sing.resolveKey(loopKey, data, _context);

    //console.log('SING-LOOP ' + itemKey + ' IN ' + loopKey);

    var out = '';

    if (loopData == null || loopData.length == 0) {
    }
    else {
        var loopKeys: string[] = [];

        if ($.isHash(loopData)) {
            loopData = $.objValues(loopData);
            loopKeys = $.objKeys(loopData);
        }
        if ($.isArray(loopData)) {

            for (var i = 0; i < loopData.length; i++) {

                //console.log('SING-LOOP ' + (i) + ' ' + itemKey + ' IN ' + loopKey);

                var loopClone: JQuery;

                if (loop.attr('sing-loop-inner') == 'true') {
                    loopClone = $(loop[0].innerHTML).removeAttr('sing-loop');
                }
                else {
                    loopClone = $(loop[0].outerHTML).removeAttr('sing-loop');
                }

                loop.before(loopClone);

                // Copy context because a key is duplicated
                if (_context[itemKey] !== undefined) {
                    _context = $.extend(true, {}, _context);
                }

                _context[itemKey] = loopData[i];

                _context[itemKey + '$i'] = i;
                _context[itemKey + '$index'] = i;
                _context[itemKey + '$isFirst'] = i == 0;
                _context[itemKey + '$isLast'] = i == loopData.length - 1;
                _context[itemKey + '$isEven'] = i % 2 == 0;
                _context[itemKey + '$isOdd'] = i % 2 == 1;

                if (loopKeys && loopKeys.length > 0)
                    _context[itemKey + '$key'] = loopKeys[i];

                try {
                    loopClone.fillTemplate(data, _context, forceFill);

                } catch (ex) {
                    loopClone = $('<error>' + ex + ' ' + ex.stack + '</error>');
                    console.trace();
                }

            }
        }
    }
    loop.remove();
}

singTemplates.property('templatePatternGlobal');
singTemplates.property('templatePattern');
singTemplates.property('templateStart');
singTemplates.property('templateEnd');

sing.loadTemplate = function (url: string, callback: Function) {

    var data = $.ajax(url, {
        complete: function (data) {

            //console.log(data);

            var templates = $('<div>' + data.responseText + '</div>');

            templates.find('*[sing-template]').each(function () {
                if ($(this).attr('sing-template-data') == 'true')
                    return;

                var name = $(this).attr('sing-template');

                var html = $(this)[0].outerHTML;

                sing.templates[name] = html;
            });

            if (callback)
                callback();
        }
    });
}

$().init(function () {

    $('*[sing-template]').each(function () {
        if ($(this).attr('sing-template-data') == 'true')
            return;
        var name = $(this).attr('sing-template');
        var html = $(this)[0].outerHTML;

        sing.templates[name] = html;

        $(this).remove();
    });
});

sing.initTemplates = function () {

    $('*[sing-if]').each(function () {

        try {
            $(this).hide();
            $(this).singIf();
            if ($(this).enhanceWithin)
                $(this).enhanceWithin();
            $(this).fadeIn('fast');
        }
        catch (ex) {
            console.log(ex);
        }
    });

    $('*[sing-loop]').each(function () {

        try {
            $(this).hide();
            $(this).singLoop();
            if ($(this).enhanceWithin)
                $(this).enhanceWithin();
            $(this).fadeIn('fast');
        }
        catch (ex) {
            console.log(ex);
        }
    });

    $('*[sing-fill]').each(function () {

        try {
            $(this).singFill();
            if ($(this).enhanceWithin)
                $(this).enhanceWithin();
            $(this).hide().fadeIn('fast');
        }
        catch (ex) {
            console.log(ex);
        }
    });
};


// #region Examples 
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

// IF Conditions
<div sing-if="{{item}}">
    <a>{{item.name}}</a>
    <a>{{item.age}}</a>
</div>

// ELSE-IF Conditions
<div sing-if="{{item}}">
    <a>{{item.name}}</a>
    <a>{{item.age}}</a>
</div>
<div sing-else-if="{{item2}}">
    <a>{{item2.name}}</a>
    <a>{{item2.age}}</a>
</div>

// ELSE Conditions
<div sing-if="{{item}}">
    <a>{{item.name}}</a>
    <a>{{item.age}}</a>
</div>
<div sing-else>
    Item Not Found
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


// These should work 


// IF Operators
<div sing-if="{{item.age}}">
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
// #endregion Examples


