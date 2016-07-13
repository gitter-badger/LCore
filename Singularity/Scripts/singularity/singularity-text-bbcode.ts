/// <reference path="singularity-core.ts"/>
/// <reference path="singularity-string.ts"/>

interface String {

    bbCodesToHTML?: () => string;
    bbCodesToText?: () => string;
}

interface IBBCode {
    name: string;
    tag: string;

    matchStr: RegExp;

    htmlStr: string;
    textStr: string;

    test: string;
}


var singBBCode = singString.addModule(new sing.Module('BBCode', String));

singBBCode.glyphIcon = '&#xe242;';

singBBCode.method('bbCodesToHTML', stringBBCodesToHTML,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests(ext) {
        }
    });

function stringBBCodesToHTML(): string {
    var out = this;

    sing.bbCodes.each((item) => {
        out = out.replaceRegExp(item.matchStr, item.htmlStr);
    });

    return (out as string);
}

singBBCode.method('bbCodesToText', stringBBCodesToText,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests(ext) {
        }
    });

function stringBBCodesToText(): string {
    var out = this;

    sing.bbCodes.each((item) => {
        out = out.replaceRegExp(item.matchStr, item.textStr);
    });
    return out;
}


// Tests from http://en.wikipedia.org/wiki/BBCode
sing.bbCodes = ([
    {
        name: 'Bold',
        tag: '[b][/b]',
        matchStr: /\[b\](.+)\[\/b\]/,
        htmlStr: '\<b\>$1\</b\>',
        textStr: '$1',

        test: '[b]bolded text[/b]'
    },
    {
        name: 'Italics',
        tag: '[i][/i]',
        matchStr: /\[i\](.+)\[\/i\]/,
        htmlStr: '<i>$1</i>',
        textStr: '$1',

        test: '[i]italicized text[/i]'
    },
    {
        name: 'Underline',
        tag: '[u][/u]',
        matchStr: /\[u\](.+)\[\/u\]/,
        htmlStr: '<u>$1</u>',
        textStr: '$1',

        test: '[u]underlined text[/u]'
    },
    {
        name: 'Strikethrough',
        tag: '[s][/s]',
        matchStr: /\[s\](.+)\[\/s\]/,
        htmlStr: '<s>$1</s>',
        textStr: '$1',

        test: '[s]strikethrough text[/s]'
    },
    {
        name: 'Center',
        tag: '[center][/center]',
        matchStr: /\[center\](.+)\[\/center\]/,
        htmlStr: '<center>$1</center>',
        textStr: '$1',

        test: '[center]centered text[/center]'
    },
    {
        name: 'Font Style Size',
        tag: '[style size={size}][/style]',
        matchStr: /\[style size\=["]*(\d{1,3}).*\](.+)\[\/style\]/,
        htmlStr: '<font size="$1">$2</font>',
        textStr: '$2',

        test: '[style size="20px"]Large Text[/style]'
    },
    {
        name: 'Font Size',
        tag: '[size={size}][/style]',
        matchStr: /\[size\=["]*(\d{1,3}).*\](.+)\[\/size\]/,
        htmlStr: '<font size="$1">$2</font>',
        textStr: '$2',

        test: '[size="28px"]Larger Text[/size]'
    },
    {
        name: 'Font Color',
        tag: '[color={color}][/color]',
        matchStr: /\[color\=["]*([.,\#]+).*\](.+)\[\/color\]/,
        htmlStr: '<font style="color:$1;">$2</font>',
        textStr: '$2',

        test: '[color="red"]Red Text[/style]\r\n[color=#FF0000]Red Text[/color]'
    },
    {
        name: 'Style Color',
        tag: '[style color={color}][/color]',
        matchStr: /\[style color\=["]*([.,#]+).*\](.+)\[\/style\]/,
        htmlStr: '<font style="color:$1;">$2</font>',
        textStr: '$2',

        test: '[style color="red"]Red Text[/style]\r\n[style color=#FF0000]Red Text[/style]'
    },
    {
        name: 'URL',
        tag: '[url]{url}[/url]',
        matchStr: /\[url\](.+)\[\/url\]/,
        htmlStr: '<a href="$1">$1</a>',
        textStr: '$1',

        test: '[url]http://example.org[/url]'
    },
    {
        name: 'Named URL',
        tag: '[url={url}][/url]',
        matchStr: /\[url\=\"?(.+)\"?\](.+)\[\/url\]/,
        htmlStr: '<a href=$1>$2</a>',
        textStr: '$2',

        test: '[url="http://example.com"]Example[/url]'
    }
    /*
        {
            name: 'Image',
            tag: '[img][/img]',
            matchStr: /[img](\w+)[\/img]/,
            htmlStr: '<img src="$1" />',
            textStr: '$1',
 
            test: '[img]http://upload.wikimedia.org/wikipedia/commons/thumb/7/7c/Go-home.svg/100px-Go-home.svg.png[/img]',
        },
        {
            name: 'Image Width',
            tag: '[img width=][/img]',
            matchStr: /[img width\=(\d{1,5})](\w+)[\/img]/,
            htmlStr: '<img width=$1 src="$2" />',
            textStr: 'Image: $2',
 
            test: '[img width=50]http://upload.wikimedia.org/wikipedia/commons/thumb/7/7c/Go-home.svg/100px-Go-home.svg.png[/img]',
        },
        {
            name: 'Image Height',
            tag: '[img height=][/img]',
            matchStr: /[img height\=(\d{1,5})](\w+)[\/img]/,
            htmlStr: '<img height="$1" src="$2" />',
            textStr: 'Image: $2',
 
            test: '[img height=50]http://upload.wikimedia.org/wikipedia/commons/thumb/7/7c/Go-home.svg/100px-Go-home.svg.png[/img]',
        },
        {
            name: 'Image Width + Height',
            tag: '[img width= height=][/img]',
            matchStr: /[img width\=(\d{1,5}) height\=(\d{1,5})](\w+)[\/img]/,
            htmlStr: '<img width="$1" height="$2" src="$3" />',
            textStr: 'Image: $3',
 
            test: '[img width=50 height=50]http://upload.wikimedia.org/wikipedia/commons/thumb/7/7c/Go-home.svg/100px-Go-home.svg.png[/img]',
        },
        {
            name: 'Image Width x Height',
            tag: '[img={width}x{height}][/img]',
            matchStr: /[img\=(\d{1,5})x(\d{1,5})](\w+)[\/img]/,
            htmlStr: '<img width="$1" height="$2" src="$3" />',
            textStr: 'Image: $3',
 
            test: '[img=50x50]http://upload.wikimedia.org/wikipedia/commons/thumb/7/7c/Go-home.svg/100px-Go-home.svg.png[/img]',
        },
        {
            name: 'Quotation',
            tag: '[quote][/quote]',
            matchStr: /[quote](\w+)[\/quote]/,
            htmlStr: '<div class="quote">$1</div>',
            textStr: '$1',
 
            test: '[quote]quoted text[/quote]',
        },
        {
            name: 'Quotation with Source',
            tag: '[quote][/quote]',
            matchStr: /[quote\=(\w+)](\w+)[\/quote]/,
            htmlStr: '<div class="quote"><strong>$1 wrote:</strong> $2</div>',
            textStr: '$1: $2',
 
            test: '[quote="author"]quoted text[/quote]',
        },
        {
            name: 'Unordered List',
            tag: '[ul][/ul]',
            matchStr: /[ul](\w+)[\/ul]/,
            htmlStr: '<ul>$1</ul>',
            textStr: '$1',
 
            test: '[ul] [li]Entry 1 [li]Entry 2[/li] [/list]\r\n [list]\r\n[li]Entry 1[/li]\r\n[li]Entry 2[/li][/ul]',
        },
        {
            name: 'Ordered List',
            tag: '[ol][/ol]',
            matchStr: /[ol](\w+)[\/ol]/,
            htmlStr: '<ol>$1</ol>',
            textStr: '$1',
 
            test: '[ol] [li]Entry 1 [li]Entry 2[/li] [/list]\r\n [list]\r\n[li]Entry 1[/li]\r\n[li]Entry 2[/li][/ol]',
        },
        {
            name: 'List Item',
            tag: '[li][/li]',
            matchStr: /[li](\w+)[\/li]/,
            htmlStr: '<li>$1</li>',
            textStr: '$1',
 
            test: '[list] [li]Entry 1 [li]Entry 2[/li] [/list]\r\n [list]\r\n[li]Entry 1[/li]\r\n[li]Entry 2[/li][/list]',
        },
        /*
        {
            name: 'List Item Shorthand',
            tag: '* Text',
            matchStr: / / ;///^* (\w+)$/,
            htmlStr: '<li>$1</li>',
            textStr: '- $1',
 
            test: '[list] [*]Entry 1 [*]Entry 2 [/list]\r\n [list]\r\n*Entry 1\r\n*Entry 2 [/list]',
        },
        *//*
{
name: 'List',
tag: '[list][/list]',
matchStr: /[list](\w+)[\/list]/,
htmlStr: '<list>$1</list>',
textStr: '$1',

test: '[list] [*]Entry 1 [*]Entry 2 [/list]\r\n [list]\r\n*Entry 1\r\n*Entry 2 [/list]',
},
{
name: 'Code',
tag: '[code][/code]',
matchStr: /[code](\w+)[\/code]/,
htmlStr: '<code>$1</code>',
textStr: '$1',

test: '[code]monospaced text[/code]',
},
{
name: 'Table',
tag: '[table][/table]',
matchStr: /[table](\w+)[\/table]/,
htmlStr: '<table>$1</table>',
textStr: '$1',

test: '[table][tr][th]table header[/th][th][/th][/tr][tr][td]1[/td][td]2[/td][/tr][/table]',
},
{
name: 'Table Row',
tag: '[tr][/tr]',
matchStr: /[tr](\w+)[\/tr]/,
htmlStr: '<tr>$1</tr>',
textStr: '$1',

test: '[table][tr][th]table header[/th][th][/th][/tr][tr][td]1[/td][td]2[/td][/tr][/table]',
},
{
name: 'Table Cell',
tag: '[td][/td]',
matchStr: /[td](\w+)[\/td]/,
htmlStr: '<td>$1</td>',
textStr: '$1',

test: '[table][tr][th]table header[/th][th][/th][/tr][tr][td]1[/td][td]2[/td][/tr][/table]',
},
{
name: 'Table Header',
tag: '[th][/th]',
matchStr: /[th](\w+)[\/th]/,
htmlStr: '<th>$1</th>',
textStr: '$1',

test: '[table][tr][th]table header[/th][th][/th][/tr][tr][td]1[/td][td]2[/td][/tr][/table]',
},

{
name: 'YouTube',
tag: '[youtube][/youtube]',
matchStr: /[youtube](\w+)[\/youtube]/,
htmlStr:
'<object><param name="movie" value="http://www.youtube.com"><embed src="$1" type="application/x-shockwave-flash" width="400" height="325" title="Adobe Flash Player"></object>',
textStr: '$1',

test: '',
},
{
name: 'YouTube Width',
tag: '[youtube width=][/youtube]',
matchStr: /[youtube width\=(\d{1,5})](\w+)[\/youtube]/,
htmlStr:
'<object><param name="movie" value="http://www.youtube.com"><embed src="$2" type="application/x-shockwave-flash" width="$1" height="325" title="Adobe Flash Player"></object>',
textStr: '$2',

test: '',
},
{
name: 'YouTube Height',
tag: '[youtube height=][/youtube]',
matchStr: /[youtube height\=(\d{1,5})](\w+)[\/youtube]/,
htmlStr:
'<object><param name="movie" value="http://www.youtube.com"><embed src="$2" type="application/x-shockwave-flash" width="400" height="$1" title="Adobe Flash Player"></object>',
textStr: '$2',

test: '',
},
{
name: 'YouTube Width + Height',
tag: '[youtube width= height=][/youtube]',
matchStr: /[youtube width\=(\d{1,5}) height\=(\d{1,5})](\w+)[\/youtube]/,
htmlStr:
'<object><param name="movie" value="http://www.youtube.com"><embed src="$3" type="application/x-shockwave-flash" width="$1" height="$2" title="Adobe Flash Player"></object>',
textStr: '$3',

test: '',
},
{
name: 'YouTube Width x Height',
tag: '[youtube={width}x{height}][/youtube]',
matchStr: /[youtube\=(\d{1,5})x(\d{1,5})](\w+)[\/youtube]/,
htmlStr:
'<object><param name="movie" value="http://www.youtube.com"><embed src="$3" type="application/x-shockwave-flash" width="$1" height="$2" title="Adobe Flash Player"></object>',
textStr: '$3',

test: '',
},

{
name: 'Google Video',
tag: '[gvideo][/gvideo]',
matchStr: /[gvideo](\w+)[\/gvideo]/,
htmlStr:
'<embed style="width:400px; height:325px;" type="application/x-shockwave-flash" src="$1" title="Adobe Flash Player">',
textStr: '$1',

test: '',
},
{
name: 'Google Video Width',
tag: '[gvideo width=][/gvideo]',
matchStr: /[gvideo width\=(\d{1,5})](\w+)[\/gvideo]/,
htmlStr:
'<embed style="width:$1px; height:325px;" type="application/x-shockwave-flash" src="$2" title="Adobe Flash Player">',
textStr: '$2',

test: '',
},
{
name: 'Google Video Height',
tag: '[gvideo height=][/gvideo]',
matchStr: /[gvideo height\=(\d{1,5})](\w+)[\/gvideo]/,
htmlStr:
'<embed style="width:400px; height:$1px;" type="application/x-shockwave-flash" src="$2" title="Adobe Flash Player">',
textStr: '$2',

test: '',
},
{
name: 'Google Video Width + Height',
tag: '[gvideo width= height=][/gvideo]',
matchStr: /[gvideo width\=(\d{1,5}) height\=(\d{1,5})](\w+)[\/gvideo]/,
htmlStr:
'<embed style="width:$1px; height:$2px;" type="application/x-shockwave-flash" src="$3" title="Adobe Flash Player">',
textStr: '$3',

test: '',
},
{
name: 'Google Video Width x Height',
tag: '[gvideo={width}x{height}][/gvideo]',
matchStr: /[gvideo\=(\d{1,5})x(\d{1,5})](\w+)[\/gvideo]/,
htmlStr:
'<embed style="width:$1px; height:$2px;" type="application/x-shockwave-flash" src="$3" title="Adobe Flash Player">',
textStr: '$3',

test: '',
},

{
name: 'Smiley Face',
tag: '[:-)]',
matchStr: /[\:\-\)]/,
htmlStr: '<img src="Face-smile.svg" alt=":-)">',
textStr: '$3',

test: '[:-)]',
},
*/
] as IBBCode[]);

