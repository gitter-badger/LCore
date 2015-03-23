/// <reference path="singularity-core.ts"/>
var singBBCode = singString.addModule(new sing.Module('BBCode', String));
singBBCode.requiredDocumentation = false;
singBBCode.requiredUnitTests = false;
singBBCode.method('bbCodesToHTML', StringBBCodesToHTML, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    },
});
function StringBBCodesToHTML() {
    var out = this;
    sing.BBCodes.each(function (item, index) {
        out = out.replaceRegExp(item.matchStr, item.htmlStr);
    });
    return out;
}
singBBCode.method('bbCodesToText', StringBBCodesToText, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    },
});
function StringBBCodesToText() {
    var out = this;
    sing.BBCodes.each(function (item, index) {
        out = out.replaceRegExp(item.matchStr, item.textStr);
    });
    return out;
}
// Tests from http://en.wikipedia.org/wiki/BBCode
sing.BBCodes = [
    {
        name: 'Bold',
        tag: '[b][/b]',
        matchStr: /\[b\](.+)\[\/b\]/,
        htmlStr: '\<b\>$1\</b\>',
        textStr: '$1',
        test: '[b]bolded text[/b]',
    },
    {
        name: 'Italics',
        tag: '[i][/i]',
        matchStr: /\[i\](.+)\[\/i\]/,
        htmlStr: '<i>$1</i>',
        textStr: '$1',
        test: '[i]italicized text[/i]',
    },
    {
        name: 'Underline',
        tag: '[u][/u]',
        matchStr: /\[u\](.+)\[\/u\]/,
        htmlStr: '<u>$1</u>',
        textStr: '$1',
        test: '[u]underlined text[/u]',
    },
    {
        name: 'Strikethrough',
        tag: '[s][/s]',
        matchStr: /\[s\](.+)\[\/s\]/,
        htmlStr: '<s>$1</s>',
        textStr: '$1',
        test: '[s]strikethrough text[/s]',
    },
    {
        name: 'Center',
        tag: '[center][/center]',
        matchStr: /\[center\](.+)\[\/center\]/,
        htmlStr: '<center>$1</center>',
        textStr: '$1',
        test: '[center]centered text[/center]',
    },
    {
        name: 'Font Style Size',
        tag: '[style size={size}][/style]',
        matchStr: /\[style size\=["]*(\d{1,3}).*\](.+)\[\/style\]/,
        htmlStr: '<font size="$1">$2</font>',
        textStr: '$2',
        test: '[style size="20px"]Large Text[/style]',
    },
    {
        name: 'Font Size',
        tag: '[size={size}][/style]',
        matchStr: /\[size\=["]*(\d{1,3}).*\](.+)\[\/size\]/,
        htmlStr: '<font size="$1">$2</font>',
        textStr: '$2',
        test: '[size="28px"]Larger Text[/size]',
    },
    {
        name: 'Font Color',
        tag: '[color={color}][/color]',
        matchStr: /\[color\=["]*([.,\#]+).*\](.+)\[\/color\]/,
        htmlStr: '<font style="color:$1;">$2</font>',
        textStr: '$2',
        test: '[color="red"]Red Text[/style]\r\n[color=#FF0000]Red Text[/color]',
    },
    {
        name: 'Style Color',
        tag: '[style color={color}][/color]',
        matchStr: /\[style color\=["]*([.,#]+).*\](.+)\[\/style\]/,
        htmlStr: '<font style="color:$1;">$2</font>',
        textStr: '$2',
        test: '[style color="red"]Red Text[/style]\r\n[style color=#FF0000]Red Text[/style]',
    },
    {
        name: 'URL',
        tag: '[url]{url}[/url]',
        matchStr: /\[url\](.+)\[\/url\]/,
        htmlStr: '<a href="$1">$1</a>',
        textStr: '$1',
        test: '[url]http://example.org[/url]',
    },
    {
        name: 'Named URL',
        tag: '[url={url}][/url]',
        matchStr: /\[url\=\"?(.+)\"?\](.+)\[\/url\]/,
        htmlStr: '<a href=$1>$2</a>',
        textStr: '$2',
        test: '[url="http://example.com"]Example[/url]',
    },
];
//# sourceMappingURL=singularity-text-bbcode.js.map