var singTemplates = singCore.addModule(new sing.Module('Templates', String));
sing.templatePatternGlobal = /^.*{\{\{(.+)\}\}}+.*/g;
sing.templatePattern = /.*\{\{(.+)\}\}.*/;
sing.templateStart = '{{';
sing.templateEnd = '}}';
function StringExtract(template, obj) {
    var matches = this.match(/\[()\]/);
}
singTemplates.method('templateInject', StringTemplateInject, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    },
});
function StringTemplateInject(obj, _context) {
    var out = this.toString();
    var matches = out.match(sing.templatePattern) || [];
    while (matches.length > 0) {
        var key = matches[1];
        if (key.contains(' with ')) {
            out = out.replace(sing.templateStart + key + sing.templateEnd, '<<' + key + '>>');
            matches = out.match(sing.templatePattern) || [];
            continue;
        }
        var value = null;
        value = sing.resolve(key, obj, _context);
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
        else {
            out = out.replace(sing.templateStart + key + sing.templateEnd, '');
        }
        matches = out.match(sing.templatePattern) || [];
    }
    return out;
}
singTemplates.method('templateExtract', StringTemplateExtract, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    },
});
function StringTemplateExtract(template) {
    var src = this;
    var templateValues = [];
    var templateKeys = [];
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
            var cursor = out;
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
singTemplates.method('getTemplate', ObjectGetTemplate, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    tests: function (ext) {
    },
}, $);
function ObjectGetTemplate(name, data) {
    var template = sing.templates[name];
    if (!template || template.length == 0)
        return null;
    template = $(template);
    if ($.isDefined(data)) {
        try {
            return template.attr('sing-template-data', 'true').fillTemplate(data);
        }
        catch (ex) {
            return $('<error>' + ex + '</error>');
        }
    }
    return template;
}
singTemplates.method('getTemplateFor', ObjectGetTemplateFor, {}, sing);
function ObjectGetTemplateFor(obj) {
}
singTemplates.method('fillTemplate', JQueryFillTemplate, {
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
function JQueryFillTemplate(data, _context, forceFill) {
    if (forceFill === void 0) { forceFill = false; }
    _context = sing.loadContext(_context);
    var template = (this);
    var visible = template.isOnScreen(0.01, 0.01);
    if (!forceFill && !visible && template.attr('sing-deferred') != 'true') {
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
singTemplates.method('singIf', JQueryPerformSingIf, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    tests: function (ext) {
    },
}, $.fn);
function JQueryPerformSingIf(data, _context, forceFill) {
    if (forceFill === void 0) { forceFill = false; }
    _context = sing.loadContext(_context);
    var srcThis = this;
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
        var sourceData = sing.resolve(condition, data, _context);
        if (!$.isDefined(sourceData))
            sourceData = false;
    }
    srcThis.removeAttr(mode);
    var next = srcThis.next();
    if (srcThis.siblings().length > 0) {
        next = next;
    }
    if ($.isEmpty(sourceData) || sourceData === false || sourceData === 0 || sourceData == [] || ($.isString(sourceData) && sourceData && sourceData.startsWith('<error>could not resolve'))) {
        srcThis.remove();
        if (next && next.length == 1 && (next.hasAttr('sing-else-if') || next.hasAttr('sing-else'))) {
            next.singIf(data, _context);
        }
        return $();
    }
    else {
        while (next && next.length > 0 && (next.hasAttr('sing-else-if') || next.hasAttr('sing-else'))) {
            var last = next;
            next = last.next();
            last.remove();
        }
        return srcThis;
    }
}
singTemplates.method('singFill', JQueryPerformSingFill, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    tests: function (ext) {
    },
}, $.fn);
function JQueryPerformSingFill(data, _context, forceFill) {
    if (forceFill === void 0) { forceFill = false; }
    _context = sing.loadContext(_context);
    var srcThis = this;
    var parent = srcThis.parent('*[sing-template]');
    if (parent.length != 0 && parent.attr('sing-template-data') != 'true')
        return;
    var fillWith = $(this).attr('sing-fill');
    if (fillWith.startsWith(sing.templateStart) || fillWith.startsWith('<<'))
        fillWith = fillWith.substr(sing.templateStart.length);
    if (fillWith.endsWith(sing.templateEnd) || fillWith.endsWith('>>'))
        fillWith = fillWith.substr(0, fillWith.length - sing.templateEnd.length);
    var template = null;
    var source = '';
    if (!fillWith.contains(' with ')) {
        template = srcThis;
        source = fillWith;
    }
    else {
        var fill = fillWith.split(' with ')[0].trim();
        source = fillWith.split(' with ')[1].trim();
        template = $.getTemplate(fill);
        srcThis.html('');
        srcThis.prepend(template);
    }
    if (!template || template.length == 0)
        throw 'could not find template ' + fill;
    var sourceData;
    if (source.contains(' as ')) {
        var after = source.after(' as ');
        var sourceData = sing.resolve(source.before(' as '), data, _context);
        if (_context['after'] !== undefined) {
            _context = $.extend(true, {}, _context);
        }
        _context[after] = sourceData;
    }
    else {
        sourceData = sing.resolve(source, data, _context);
    }
    if (!$.isDefined(sourceData))
        throw 'could not find data ' + source;
    template.removeAttr('sing-template');
    srcThis.removeAttr('sing-fill');
    srcThis.attr('sing-data-type', $.typeName(sourceData));
    if (fill)
        srcThis.attr('sing-template-name', fill.toSlug());
    try {
        _context['$data'] = undefined;
        srcThis.fillTemplate(sourceData, _context, forceFill);
    }
    catch (ex) {
        console.trace();
        srcThis.html('<error>' + ex + '</error>');
    }
    return srcThis;
}
singTemplates.method('singLoop', JQueryPerformSingLoop, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    tests: function (ext) {
    },
}, $.fn);
function JQueryPerformSingLoop(data, _context, forceFill) {
    if (forceFill === void 0) { forceFill = false; }
    _context = sing.loadContext(_context);
    var loop = this;
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
    }
    var itemDataIndex = itemKey.length - 1;
    var loopData = sing.resolve(loopKey, data, _context);
    var out = '';
    if (loopData == null || loopData.length == 0) {
    }
    else {
        var loopKeys = [];
        if ($.isHash(loopData)) {
            loopData = $.objValues(loopData);
            loopKeys = $.objKeys(loopData);
        }
        if ($.isArray(loopData)) {
            for (var i = 0; i < loopData.length; i++) {
                var loopClone;
                if (loop.attr('sing-loop-inner') == 'true') {
                    loopClone = $(loop[0].innerHTML).removeAttr('sing-loop');
                }
                else {
                    loopClone = $(loop[0].outerHTML).removeAttr('sing-loop');
                }
                loop.before(loopClone);
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
                }
                catch (ex) {
                    loopClone = $('<error>' + ex + '</error>');
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
sing.loadTemplate = function (url, callback) {
    var data = $.ajax(url, {
        complete: function (data) {
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
};
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
//# sourceMappingURL=singularity-templates.js.map