﻿/// <reference path="singularity-core.ts"/>
/// <reference path="singularity-string.ts"/>
/// <reference path="singularity-html.ts"/>
/// <reference path="singularity-jquery.ts"/>

interface String {

    templateInject?: (obj: Object, _context?: Object) => string;
    templateExtract?: (template: string) => Object;

}

interface JQueryStatic {

    getTemplate?: (name: string, data?: Object) => JQuery;

}


interface JQuery {

    singIf?: (data?: any, _context?: Object, forceFill?: boolean) => boolean;
    singFill?: (data?: any, _context?: Object, forceFill?: boolean, fillInside?: boolean) => void;
    singLoop?: (data?: any, _context?: Object, forceFill?: boolean, fillInside?: boolean) => void;

    fillTemplate?: (data: Object, _context?: Object, forceFill?: boolean) => void;
}

interface ITemplateContext {

    name?: string;
    data: any;

}

var singTemplates = singCore.addModule(new sing.Module('Templates', String));

singTemplates.glyphIcon = '&#xe224;';

singTemplates.method('templateInject', StringTemplateInject,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests(ext) {
        }
    });

function StringTemplateInject(obj: Object, _context?: Hash<any>): string {

    let out = this.toString();

    // Causes injection of data into all EMPTY <sing> tags.
    /*
    var tagIndex = out.indexOf('<' + sing.constants.htmlElement.Templates.Element + '>');
    while (tagIndex >= 0) {
        var tagIndexClose = out.indexOf('</' + sing.constants.htmlElement.Templates.Element + '>');
        var len = ('<' + sing.constants.htmlElement.Templates.Element + '>').length;
        var len2 = ('</' + sing.constants.htmlElement.Templates.Element + '>').length;

        if (tagIndex > 0) {
            out = out.substr(0, tagIndex) + sing.constants.TemplatePatternStart +
            out.substr(tagIndex + len, tagIndexClose - tagIndex - len) +
            sing.constants.TemplatePatternEnd +
            + out.substr(tagIndexClose + len2);
        }
        else {
            out = sing.constants.TemplatePatternStart +
            out.substr(len, tagIndexClose - len) +
            sing.constants.TemplatePatternEnd +
            + out.substr(tagIndexClose + len2);
        }
        tagIndex = out.indexOf('<' + sing.constants.htmlElement.Templates.Element + '>');
    }
    */

    let matches = out.match(sing.constants.TemplatePatternRegExp) || [];

    while (matches.length > 0) {

        const key = matches[1];

        // WARNING this can cause problems if a string ' with ' is used.
        if (key.contains(' with ')) {
            // sing-fill template. ignore.

            out = out.replace(sing.constants.TemplatePatternStart + key + sing.constants.TemplatePatternEnd, `<<${key}>>`);
            matches = out.match(sing.constants.TemplatePatternRegExp) || [];
            continue;
        }

        let value: any;
        value = null;
        value = sing.resolve(key, obj, _context);

        if (!$.isDefined(value))
            value = '';

        const valueTemplate = sing.getTemplateName(value);

        if (valueTemplate != null) {
            const valueTemplateHtml = $.getTemplate(valueTemplate);

            if (valueTemplateHtml) {

                const valueTemplateStr = valueTemplateHtml.outerHtml().templateInject(value, _context);

                return valueTemplateStr;
            }
        }
        if (value != null) {

            out = out.replace(sing.constants.TemplatePatternStart + key + sing.constants.TemplatePatternEnd, value.toString());

        }
        // Remove template if no data is found
        else {
            out = out.replace(sing.constants.TemplatePatternStart + key + sing.constants.TemplatePatternEnd, '');
        }
        matches = out.match(sing.constants.TemplatePatternRegExp) || [];
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
        tests(ext) {
        }
    });

function StringTemplateExtract(template: string): any {
    let src = this as string;

    const templateValues = [] as string[];

    const templateKeys = [] as string[];

    while (src.length > 0) {

        if (template.length > 1 && template[0] == '{' && template[1] == '{') {
            let templateValue = '';
            let templateKey = '';

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

    const out = {};

    for (let i = 0; i < templateKeys.length; i++) {
        const key = templateKeys[i];

        if (key.contains('.')) {
            const keyParts = key.split('.');

            let cursor: any = out;

            for (let j = 0; j < keyParts.length; j++) {
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
        tests(ext) {
        }
    }, $);

function ObjectGetTemplate(name: string, data?: Object): JQuery {

    let template = sing.templates[name] as any;

    if (!template || template.length == 0)
        return null;

    template = $(template);

    if ($.isDefined(data)) {
        try {
            return template.attr(sing.constants.htmlAttr.Templates.TemplateData, 'true').fillTemplate(data);


        } catch (ex) {
            return $(`<error>${ex}</error>`);
        }
    }
    return template;
}

singTemplates.method('getTemplateFor', ObjectGetTemplateFor, {}, sing);

function ObjectGetTemplateFor() {

}

singTemplates.method('fillTemplate', JQueryFillTemplate,
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

var deferred = 0;
var deferredDone = 0;

function JQueryFillTemplate(data: any, _context?: Hash<any>, forceFill: boolean = false): void {

    _context = sing.loadContext(_context);

    var template = (this) as JQuery;

    const visible = template.isOnScreen(0.01, 0.01);

    if (!forceFill && !visible && template.attr(sing.constants.htmlAttr.Templates.Deferred) != 'true') {

        // Mark element as deferred to avoid inifinite loop.
        template.attr(sing.constants.htmlAttr.Templates.Deferred, 'true');

        var tempHtml = template.outerHtml();

        var thisDeferredID = deferred;

        template.attr(sing.constants.htmlAttr.Templates.DeferID, thisDeferredID);
        template.html('DEFERRED');

        deferred++;

        _context = $.extend(true, {}, _context);

        (() => {
            try {
                const deferTemplate = $(`*[${sing.constants.htmlAttr.Templates.DeferID}=${thisDeferredID}]`);
                const newTemplate = $(tempHtml);

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

    const loops = template.find(`*[${sing.constants.htmlAttr.Templates.Loop}]`);

    loops.each(function () {
        $(this).singLoop(data, _context, true);
    });

    const ifs = template.find(`*[${sing.constants.htmlAttr.Templates.If}]`);

    ifs.each(function () {
        $(this).singIf(data, _context, true);
    });


    const fills = template.find(`*[${sing.constants.htmlAttr.Templates.Fill}]`);

    fills.each(function () {
        $(this).singFill(data, _context, forceFill);
    });

    if (template.attr(sing.constants.htmlAttr.Templates.Fill) &&
        template.attr(sing.constants.htmlAttr.Templates.Fill).length > 0)
        template.singFill(data, _context, forceFill);

    try {
        const html = template[0].outerHTML;
        const templateReplace = html.templateInject(data, _context);
        template.replaceWith($(templateReplace));
    }
    catch (ex) {
        JQueryTemplateError(ex, template, data, _context);
    }

    // Removes all left over <sing> elements
    $(sing.constants.htmlElement.Templates.Element).each(() => {
        // innerHtml causes RangeError: Maximum call stack size exceeded
        // var innerHtml = this.innerHtml;
        // $(this).html(innerHtml);
    });

    if (sing.templateShownFunctions && sing.templateShownFunctions.length > 0) {
        sing.templateShownFunctions.each(fn => {
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
        tests(ext) {
        }
    }, $.fn);

function JQueryPerformSingIf(data?: any, _context?: Hash<any>) {

    _context = sing.loadContext(_context);

    var srcThis = this as JQuery;


    // Don't perform if for elements within templates
    var parent = srcThis.parent(`*[${sing.constants.htmlAttr.Templates.Template}]`);

    if (parent.length != 0 && parent.attr(sing.constants.htmlAttr.Templates.TemplateData) != 'true')
        return null;

    var mode = sing.constants.htmlAttr.Templates.If;
    var condition = '';

    if ($(this).hasAttr(sing.constants.htmlAttr.Templates.ElseIf)) {
        mode = sing.constants.htmlAttr.Templates.ElseIf;
        condition = $(this).attr(sing.constants.htmlAttr.Templates.ElseIf);
    }
    else if ($(this).hasAttr(sing.constants.htmlAttr.Templates.Else)) {
        mode = sing.constants.htmlAttr.Templates.Else;
        condition = '';
    }
    else {
        condition = $(this).attr(sing.constants.htmlAttr.Templates.If);
    }

    condition = condition || '';

    if (condition.startsWith(sing.constants.TemplatePatternStart))
        condition = condition.substr(sing.constants.TemplatePatternStart.length);
    if (condition.endsWith(sing.constants.TemplatePatternEnd))
        condition = condition.substr(0, condition.length - sing.constants.TemplatePatternEnd.length);

    var sourceData: any = null;

    if (mode == sing.constants.htmlAttr.Templates.Else) {
        sourceData = true;
    }
    else {
        try {
            sourceData = sing.resolve(condition, data, _context);
        }
        catch (ex) {
            // sing-if token errors are IGNORED and seen as false values.
            sourceData = false;
        }


        if (!$.isDefined(sourceData))
            sourceData = false;
    }

    srcThis.removeAttr(mode);

    var next = srcThis.next();

    if (srcThis.siblings().length > 0) {
    }

    if ($.isEmpty(sourceData) ||
        sourceData === false ||
        sourceData === 0 ||
        sourceData == []) {
        srcThis.remove();

        // Evaluate all subsequent else-if and else tags if the result is false.
        if (next && next.length == 1 && (next.hasAttr(sing.constants.htmlAttr.Templates.ElseIf) ||
            next.hasAttr(sing.constants.htmlAttr.Templates.Else))) {
            next.singIf(data, _context);
        }

        return false;
    }
    else {
        // Remove all subsequent else-if and else tags if the result is true.
        while (next && next.length > 0 && (next.hasAttr(sing.constants.htmlAttr.Templates.ElseIf) ||
            next.hasAttr(sing.constants.htmlAttr.Templates.Else))) {
            var last = next;
            next = last.next();
            last.remove();

        }

        return true;
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
        tests(ext) {
        }
    }, $.fn);

function JQueryPerformSingFill(data?: any, _context?: Hash<any>, forceFill: boolean = false, fillInside: boolean = true) {

    _context = sing.loadContext(_context);

    var srcThis = this as JQuery;

    // Don't perform fill for elements within inline templates
    var parent = srcThis.parent(`*[${sing.constants.htmlAttr.Templates.Template}]`);

    if (parent.length != 0 && parent.attr(sing.constants.htmlAttr.Templates.TemplateData) != 'true')
        return null;

    var fillWith = srcThis.attr(sing.constants.htmlAttr.Templates.Fill);

    // srcThis.removeAttr(sing.constants.htmlAttr.Templates.Fill);
    // srcThis.attr(sing.constants.htmlAttr.Templates.Filled, fillWith)

    if (fillWith.startsWith(sing.constants.TemplatePatternStart) || fillWith.startsWith('<<'))
        fillWith = fillWith.substr(sing.constants.TemplatePatternStart.length);
    if (fillWith.endsWith(sing.constants.TemplatePatternEnd) || fillWith.endsWith('>>'))
        fillWith = fillWith.substr(0, fillWith.length - sing.constants.TemplatePatternEnd.length);

    // No template - target self.

    var template = null as JQuery;
    var source = '';
    var fill: string;
    if (!fillWith.contains(' with ')) {
        template = srcThis;
        source = fillWith;
    }
    else {
        fill = fillWith.split(' with ')[0].trim();
        source = fillWith.split(' with ')[1].trim();

        //        console.log('SING-FILL ' + fill + ' WITH ' + source);

        template = $.getTemplate(fill);

        srcThis.html('');
        srcThis.prepend(template);
    }


    if (!template || template.length == 0)
        throw `could not find template ${fill}`;

    var sourceData: any;

    if (source.contains(' as ')) {
        var after = source.after(' as ').trim();
        sourceData = sing.resolve(source.before(' as '), data, _context);

        // Copy context because a key is duplicated
        if (_context[after] !== undefined) {
            _context = $.extend(true, {}, _context);
        }

        _context[after] = sourceData;
    }
    else {
        sourceData = sing.resolve(source, data, _context);
    }


    if (!$.isDefined(sourceData))
        throw `could not find data ${source}`;

    template.removeAttr(sing.constants.htmlAttr.Templates.Template);
    srcThis.removeAttr(sing.constants.htmlAttr.Templates.Fill);

    srcThis.attr(sing.constants.htmlAttr.Templates.DataType, $.typeName(sourceData));

    if (fill)
        srcThis.attr(sing.constants.htmlAttr.Templates.TemplateName, fill.toSlug());

    var content = srcThis.children(`.${sing.constants.htmlAttr.Templates.Content}, ${sing.constants.htmlElement.Templates.Element}[${sing.constants.htmlAttr.Templates.ShortContent}]`);

    if (content.length > 0) {

        content.each(c => {
            // Load the content name from the attribute
            var contentName = $(c).attr(sing.constants.htmlAttr.Templates.Content) || $(c).attr(sing.constants.htmlAttr.Templates.ShortContent);

            var contentCode = $(c).outerHtml();

            var contentNamed = !$.isEmpty(contentName);

            // Set the content to the html
            _context['content'] = sourceData['content'] || {};

            if (contentNamed) {
                // Add unnamed content to the content.unnamed object
                _context['content']['unnamed'] = sourceData['content']['unnamed'] || [];
                _context['content']['unnamed'].push(contentCode);
            } else {
                if (_context['content'][contentName] == null) {
                    // Add named content to the content object
                    _context['content'][contentName] = contentCode;

                }
                else if ($.isArray(sourceData['content'][contentName])) {
                    // Add named content to the existing content object array
                    _context['content'][contentName].push(contentCode);
                }
                else {
                    // Add named content to a new content object array
                    const temp = sourceData['content'][contentName];
                    _context['content'][contentName] = [temp, contentCode];
                }
            }

            $(c).remove();
        });
    }

    var dataElements = srcThis.children(`[${sing.constants.htmlAttr.Templates.Data}], ${sing.constants.htmlElement.Templates.Element}[${sing.constants.htmlAttr.Templates.ShortData}]`);


    if (dataElements.length > 0) {
        dataElements.each(d => {

            var dataName = $(d).attr(sing.constants.htmlAttr.Templates.Content) || $(d).attr(sing.constants.htmlAttr.Templates.ShortContent);

            var contentValue = $(d).innerHtml();

            _context[dataName] = contentValue;

            $(d).remove();
        });
    }

    var inner = srcThis.innerHtml().trim();

    // If no content is supplied and there is still inner code, use it as the content.
    if (!$.isEmpty((inner))) {
        _context['content'] = inner;
    }

    if (fillInside) {
        try {
            // Clear data so that sub-templates will have access to their own data sets.
            _context[sing.constants.specialTokens.Data] = undefined;
            // srcThis.fillTemplate(sourceData, _context, forceFill);
            FillTemplateTraverse(srcThis, srcThis, sourceData, _context);
        }
        catch (ex) {
            JQueryTemplateError(ex, srcThis, data, _context);
        }
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
        tests(ext) {
        }
    }, $.fn);

function JQueryPerformSingLoop(data: any, _context?: Hash<any>, forceFill: boolean = false, fillInside: boolean = true): void {

    _context = sing.loadContext(_context);

    var loop = this as JQuery;

    var loopKey = loop.attr(sing.constants.htmlAttr.Templates.Loop);

    if (loopKey.startsWith(sing.constants.TemplatePatternStart))
        loopKey = loopKey.substr(sing.constants.TemplatePatternStart.length);

    if (loopKey.endsWith(sing.constants.TemplatePatternEnd))
        loopKey = loopKey.substr(0, loopKey.length - sing.constants.TemplatePatternEnd.length);

    var itemKey = sing.constants.specialTokens.Item;

    if (loopKey.contains(' in ')) {
        itemKey = loopKey.split(' in ')[0].trim();
        loopKey = loopKey.split(' in ')[1].trim();
    }
    else {
        var tempNumber = 0;
        while (_context[itemKey + (tempNumber == 0 ? '' : tempNumber)] !== undefined) {
            tempNumber++;
        }
        // itemKey.push(itemKey.trim());
    }

    var loopData: any;
    var ex: any;
    try {
        loopData = sing.resolve(loopKey, data, _context);
    }
    catch (ex) {
        loopData = [];
    }

    // console.log('SING-LOOP ' + itemKey + ' IN ' + loopKey);

    if (loopData == null || loopData.length == 0) {
    }
    else {
        var loopKeys: string[] = [];

        if ($.isHash(loopData)) {
            loopKeys = $.objKeys(loopData);
            loopData = $.objValues(loopData);
        }
        if ($.isArray(loopData)) {

            _context[itemKey + sing.constants.specialTokens.Length] = loopData.length;

            for (var i = 0; i < loopData.length; i++) {

                // console.log('SING-LOOP ' + (i) + ' ' + itemKey + ' IN ' + loopKey);

                var loopClone: JQuery;

                if (loop.attr(sing.constants.htmlAttr.Templates.LoopInner) == 'true') {
                    loopClone = $(loop[0].innerHTML);
                }
                else {
                    loopClone = $(loop[0].outerHTML);
                }

                loopClone.removeAttr(sing.constants.htmlAttr.Templates.Loop);

                loop.before(loopClone);

                // Copy context because a key is duplicated
                if (_context[itemKey] !== undefined) {
                    _context = $.extend(true, {}, _context);
                }

                _context[itemKey] = loopData[i];

                _context[itemKey + sing.constants.specialTokens.I] = i;
                _context[itemKey + sing.constants.specialTokens.Index] = i;
                _context[itemKey + sing.constants.specialTokens.IsFirst] = i == 0;
                _context[itemKey + sing.constants.specialTokens.IsLast] = i == loopData.length - 1;

                if (loopKeys && loopKeys.length > 0)
                    _context[itemKey + sing.constants.specialTokens.Key] = loopKeys[i];

                if (fillInside) {
                    try {
                        // loopClone.fillTemplate(data, _context, forceFill);
                        FillTemplateTraverse(loopClone, loop, data, _context);

                    } catch (ex) {
                        JQueryTemplateError(ex, loopClone, data, _context);
                    }
                }

            }
        }
    }
    loop.remove();
}

sing.loadTemplate = (url: string | string[], callback?: (ms: number) => void) => {

    if ($.isArray(url)) {
        for (let i = 0; i < url.length; i++) {
            const last = i == url.length - 1;

            sing.loadTemplate(url[i], last ? callback : () => { });
        }
    }
    else {
        var start = new Date().valueOf();

        $.ajax(url as string, {
            complete(data: any) {

                const templates = $(`<div>${data.responseText}</div>`);

                templates.find(`*[${sing.constants.htmlAttr.Templates.Template}]`).each(function () {
                    if ($(this).attr(sing.constants.htmlAttr.Templates.TemplateData) == 'true')
                        return;

                    const name = $(this).attr(sing.constants.htmlAttr.Templates.Template);

                    const html = $(this)[0].outerHTML;

                    sing.templates[name] = html;
                });

                const end = new Date().valueOf();

                const length = (end - start).max(0);

                if (callback)
                    callback(length);
            }
        });
    }
};

$().init(() => {
    // Load all inline templates on jQuery init
    $(`*[${sing.constants.htmlAttr.Templates.Template}]`).each(function () {

        const thisElement = $(this);

        if (thisElement.attr(sing.constants.htmlAttr.Templates.TemplateData) == 'true')
            return;
        const name = thisElement.attr(sing.constants.htmlAttr.Templates.Template);
        const html = thisElement[0].outerHTML;

        sing.templates[name] = html;

        thisElement.remove();
    });
});

sing.initTemplates = () => {

    $(sing.constants.htmlElement.Templates.Element).each(function () {

        const thisElement = this as JQuery;
        // ReSharper disable once ConditionIsAlwaysConst
        if (thisElement != null) {
            // Initialize inline elements (shorthand)
            if (thisElement.hasAttr(sing.constants.htmlAttr.Templates.ShortIf)) {
                thisElement.attr(sing.constants.htmlAttr.Templates.If, thisElement.attr(sing.constants.htmlAttr.Templates.ShortIf));
                thisElement.removeAttr(sing.constants.htmlAttr.Templates.ShortIf);
            }
            if (thisElement.hasAttr(sing.constants.htmlAttr.Templates.ShortElseIf)) {
                thisElement.attr(sing.constants.htmlAttr.Templates.ElseIf, thisElement.attr(sing.constants.htmlAttr.Templates.ShortElseIf));
                thisElement.removeAttr(sing.constants.htmlAttr.Templates.ShortElseIf);
            }
            if (thisElement.hasAttr(sing.constants.htmlAttr.Templates.ShortElse)) {
                thisElement.attr(sing.constants.htmlAttr.Templates.Else, thisElement.attr(sing.constants.htmlAttr.Templates.ShortElse));
                thisElement.removeAttr(sing.constants.htmlAttr.Templates.ShortElse);
            }
            if (thisElement.hasAttr(sing.constants.htmlAttr.Templates.ShortLoop)) {
                thisElement.attr(sing.constants.htmlAttr.Templates.Loop, thisElement.attr(sing.constants.htmlAttr.Templates.ShortLoop));
                thisElement.removeAttr(sing.constants.htmlAttr.Templates.ShortLoop);
            }
            if (thisElement.hasAttr(sing.constants.htmlAttr.Templates.ShortFill)) {
                thisElement.attr(sing.constants.htmlAttr.Templates.Fill, thisElement.attr(sing.constants.htmlAttr.Templates.ShortFill));
                thisElement.removeAttr(sing.constants.htmlAttr.Templates.ShortFill);
            }
        }
    });

    FillTemplateTraverse($('body'), $('body'), null, {});

    /*
    $('*[' + sing.constants.htmlAttr.Templates.If + ']').each(function () {

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

    $('*[' + sing.constants.htmlAttr.Templates.Loop + ']').each(function () {

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

    $('*[' + sing.constants.htmlAttr.Templates.Fill + ']').each(function () {

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
    */

};

function JQueryTemplateError(ex: any, target: JQuery, data: any, _context: any) {

    const SingTry = target.parents(sing.constants.htmlElement.Templates.Try);

    if (SingTry == null || SingTry.length == 0) {
        target.html(`<${sing.constants.htmlElement.Error}>${ex}</${sing.constants.htmlElement.Error}>`);
        console.log(ex);
    }
    else {
        target.hide();

        const SingCatch = SingTry.next();

        if (SingCatch != null &&
            SingCatch.length > 0 &&
            SingCatch[0].localName == sing.constants.htmlElement.Templates.Catch) {

            _context['$ex'] = ex;

            // Removes the <sing-catch> element so the contents are shown.
            SingCatch.replaceWith(SingCatch[0].innerHTML);

            SingCatch.fillTemplate(data, _context, true);
            SingCatch.show();
        }
    }
}


function HtmlTraverse(target: HTMLElement, action: (target: HTMLElement, root: HTMLElement) => void, root: HTMLElement = target) {

    if (target != null &&
        target.children != null &&
        target.children.length > 0) {

        for (let i = 0; i < target.children.length; i++) {

            log(target.children[i].nodeType);

            action(target.children[i] as HTMLElement, root);

            HtmlTraverse(target.children[i] as HTMLElement, action, root);
        }
    }
}

function JQueryTraverse(target: JQuery, action: (target: any, root: JQuery) => void, root: JQuery = target) {

    const contents = target.contents();

    for (let i = 0; i < contents.length; i++) {

        action($(contents[i]), root);

        if (contents[i] != null &&
            !$.isString(contents[i])) {
            JQueryTraverse($(contents[i]), action, root);
        }
    }
}

function JQueryTraverseReplace(target: JQuery, action: (target: any, root: JQuery) => string, root: JQuery = target) {

    const contents = target.contents();

    for (let i = 0; i < contents.length; i++) {

        action($(contents[i]), root);

        if (contents[i] != null &&
            !$.isString(contents[i])) {
            JQueryTraverse($(contents[i]), action, root);
        }
    }
}

function FillTemplateTraverse(target: JQuery, root: JQuery, data: any = {}, _context: Hash<any> = {}) {

    _context = sing.loadContext(_context);

    if (!ObjectDefined(target))
        return;

    try {

        target.attr('test-filled', 'yup');

        if (target &&
            target.length > 0 &&
            target[0].attributes) {
            const attributes = target[0].attributes;

            for (let i = 0; i < attributes.length; i++) {
                const value = attributes[i];

                if (value.name == sing.constants.htmlAttr.Templates.Fill ||
                    value.name == sing.constants.htmlAttr.Templates.If ||
                    value.name == sing.constants.htmlAttr.Templates.Loop) { }
                else if (value.specified) {
                    const newValue = value.value.templateInject(data, _context);

                    if (value.value != newValue) {
                        target.attr(value.name, newValue);
                    }
                }
            }
        }


        if (target.hasAttr(sing.constants.htmlAttr.Templates.Fill)) {
            target.singFill(data, _context, true, true);

            // Fill loads context and reprocesses this element
            return;
        }

        if (target.hasAttr(sing.constants.htmlAttr.Templates.If)) {
            const ifResult = target.singIf(data, _context, true);

            // Don't process inside the If statement if the result is false
            if (ifResult == false)
                return;
        }

        if (target.hasAttr(sing.constants.htmlAttr.Templates.Loop)) {
            target.singLoop(data, _context, true, true);

            // Loop processes inner elements.
            return;
        }

        target.contents().each(function () {
            if ((this as Element).nodeType == 3) {
                $(this).before((this.textContent || '').templateInject(data, _context));
                this.textContent = '';
            }
            else {
                const thisElement = $(this);

                FillTemplateTraverse(thisElement, root, data, _context);
            }
        });
    }
    catch (ex) {
        JQueryTemplateError(ex, target, data, _context);
    }
}

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


<!-- named content -->

<div sing-fill="{{ TestInnerSection with data }}">
    <div sing-content="Content">
        ...
    </div>
    <div sing-content="Content2">
        ...
    </div>
</div>

<div sing-template="TestInnerSection">

    <H1>Stuff</H1>

    {{ content.Content }}

    {{ content.Content2 }}

</div>

<!-- unnamed content -->

<div sing-fill="{{ TestInnerSection2 with data }}">
    <div sing-content>
        <p>1</p>
    </div>
    <div sing-content>
        <p>2</p>
    </div>
</div>

<div sing-template="TestInnerSection2">

    <H1>Stuff</H1>

    <div sing-loop="{{ block in content.unnamed }}">
        {{ block }}
    </div>
</div>

<!-- named and unnamed content -->

<div sing-fill="{{ TestInnerSection3 with data }}">
    <div sing-content="header">
        <p>hello</p>
    </div>
    <div sing-content>
        <p>1</p>
    </div>
    <div sing-content>
        <p>2</p>
    </div>
    <div sing-content>
        <p>3</p>
    </div>
</div>

<div sing-template="TestInnerSection3">

    <h1>{{content.header}}</h1>

    <div sing-loop="{{ block in content.unnamed }}">
        <span>
            {{ block }}
        </span>
    </div>
</div>

<!-- multiple named content -->

<div sing-fill="{{ TestInnerSection4 with data }}">
    <div sing-content="header">
        <p>hello</p>
    </div>

    <div sing-content="People">
        <p>1</p>
    </div>
    <div sing-content="People">
        <p>2</p>
    </div>

    <div sing-content="Places">
        <p>3</p>
    </div>
    <div sing-content="Places">
        <p>3</p>
    </div>
</div>

<div sing-template="TestInnerSection4">

    <h1>{{content.header}}</h1>

    <div sing-loop="{{ person in content.People }}">
        <span>
            {{ person }}
        </span>
    </div>
    <div sing-loop="{{ place in content.Places }}">
        <span>
            {{ place }}
        </span>
    </div>
</div>

<!-- anonymous content wrapper -->

<div sing-fill="{{ TestInnerSection5 with data }}">
    <p>...</p>
    <p>...</p>
</div>

<div sing-template="TestInnerSection5">
    <div>
        <h1></h1>

        <div>
            {{content}}
        </div>
    </div>
</div>

// Inline logic (shorthand)
//
// <sing if="{{}}">
// <sing else-if="{{}}">
// <sing else>
// <sing fill="{{}}">
// <sing loop="{{}}">
// <sing template="">
// <sing content="">
// <sing data="varName">Value</sing>

*/

// #endregion Examples


