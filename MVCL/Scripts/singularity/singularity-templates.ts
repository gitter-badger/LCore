/// <reference path="singularity-core.ts"/>


interface String {


}

var singTemplates = sing.addModule(new sing.Module('Singularity.Templates', String));

singTemplates.requiredDocumentation = false;


sing.templatePattern = /.*\{\{(.+)\}\}.*/;
sing.templateStart = '{{';
sing.templateEnd = '}}';

singTemplates.addExt('extract', StringExtract,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

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

singTemplates.addExt('templateInject', StringTemplateInject,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

function StringTemplateInject(obj: Object, itemKey?: string, itemObj?: Object): string {

    var out = this.toString();

    var match = out.match(sing.templatePattern);

    log(out.toString(), match, sing.templatePattern);

    while (match != null && match.length > 0) {

        var key = match[1];

        var values = [obj].arrayValues(key);


        if (itemKey != null && itemKey.length > 0 && key.startsWith(itemKey + '.')) {
            values = [itemObj].arrayValues(key.substr(itemKey.length + 1));

            if (!$.isArray(values))
                values = [values];
        }

        log(key, values, itemKey, itemObj,(itemKey != null && itemKey.length > 0 && key.startsWith(itemKey + '.')), key.substr(itemKey.length + 1),(values != null && values != undefined));

        if ($.isArray(values) && values.length > 0)
            values = values[0];

        if (values != null && values != undefined) {
            out = out.replace(sing.templateStart + key + sing.templateEnd, values.toString());
        }
        // Remove template if no data is found
        else {
            out = out.replace(sing.templateStart + key + sing.templateEnd, '');
        }

        match = out.match(sing.templatePattern);
    }

    log(out);
    return out;
}

singTemplates.addExt('templateExtract', StringTemplateExtract,
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

