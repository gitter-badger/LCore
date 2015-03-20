/// <reference path="singularity-core.ts"/>


interface String {

    templateInject?: (obj: Object, itemKey?: string, itemObj?: Object) => string;
    templateExtract?: (template: string) => Object;

}

var singTemplates = sing.addModule(new sing.Module('Singularity.Templates', String));

singTemplates.requiredDocumentation = false;


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

////////////////////////////////////////////////////////////////////////////////////////////////

singTemplates.addExt('getTemplate', ObjectGetTemplate,
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

    var template = $('*[sing-template=' + name + ']').clone();

    if (!template || template.length == 0)
        throw 'Template ' + name + ' not found.';


    if (data != null)
        return template.fillTemplate(data).attr('sing-template-data', 'true');

    return template;
}

singTemplates.addExt('fillTemplate', ObjectFillTemplate,
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

        var loopData = [data].arrayValues(loopKey);


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
// #endregion Examples