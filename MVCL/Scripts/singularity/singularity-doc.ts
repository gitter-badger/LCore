/// <reference path="singularity-core.ts"/>

interface ISingularityDocs {

    getDocs?: (funcName?: string, includeCode?: boolean, includeDocumentation?: boolean) => string;
    getSummary?: (funcName?: string, includeFunctions?: boolean) => string;
    getMissing?: (funcName?: string) => string;
}

var singDocs = sing.addModule(new sing.Module('Singularity.Documentation', sing, sing));

singDocs.requiredDocumentation = false;
singDocs.requiredUnitTests = false;

singDocs.addExt('getDocs', SingularityGetDocs);

function SingularityGetDocs(funcName?: string, includeCode: boolean = false, includeDocumentation: boolean = true) {

    this.resolveTests();

    var featuresCount = 0;
    var featuresFound = 0;
    var featuresHaveTests = 0;
    var featuresNeedTests = 0;

    var documentaionCount = 0;
    var documentaionFound = 0;

    var testsFound = 0;
    var testsPassed = 0;

    var header = '';

    if (!funcName ||
        funcName == '' ||
        funcName == 'all')
        header = 'Singularity TypeScript, JavaScript, and jQuery language Extensions\r\n\r\n';

    var out = '';

    $.objEach(sing.extensions, function (key, ext: SingularityExtension, index) {

        var mod = sing.modules[ext.moduleName];

        if (funcName &&
            funcName.lower() != '' &&
            funcName.lower() != 'all' &&
            !ext.name.lower().contains(funcName.lower()))
            return;

        featuresCount += 1; // method

        if (mod.requiredUnitTests)
            featuresNeedTests++;

        if (mod.requiredDocumentation)
            documentaionCount += 5; // documentation

        if (ext.method)
            featuresFound++;

        if (ext.details) {
            if (ext.details.summary && mod.requiredDocumentation)
                documentaionFound++;
            if (ext.details.parameters && mod.requiredDocumentation)
                documentaionFound++;
            if (ext.details.returns && mod.requiredDocumentation)
                documentaionFound++;
            if (ext.details.returnTypeName && mod.requiredDocumentation)
                documentaionFound++;
            if (ext.details.examples && ext.details.examples.length > 0 && mod.requiredDocumentation)
                documentaionFound++;
            if (ext.details.unitTests && ext.details.unitTests.length > 0 && mod.requiredUnitTests) {
                featuresHaveTests++;
            }
        }

        var line = '------------------------------------------------------------------------------------';


        if (ext.details) {

            // Don't display details for alias functions, aliases are listed under the main function
            if (ext.isAlias && includeDocumentation == true)
                return;

            out += '\r\n';


            var functionDef = '';
            /*
            ((ext.details.returnTypeName || '') + ' function(').pad(20, 'r') +
         ((ext.details && ext.details.parameters) ? ext.details.parameters.collect(function (item, i) {
             var TypeNames = item.types.collect(function (t) { return t.name; }).join(', ');
             return '[' + TypeNames + '] ' + item.name;
         }).join(', ') : '') + ')' +
            ' { ... } ';
            */

            out +=
            [
                line,
                ext.methodCall.pad(40) + (!ext.method ? ' -- NOT IMPLEMENTED' : functionDef).pad(40, Direction.r),
                line,

                (ext.details.summary ? ('\r\n    Summary: \r\n' + ext.details.summary) : ''),

                (ext.details.parameters && ext.details.parameters.length == 0 ? '\r\n    Parameters: None\r\n' : ''),

                (ext.details.parameters && ext.details.parameters.length > 0 ? ('\r\n    Parameters:\r\n' + ext.details.parameters.collect(function (item, j) {
                    return (' #' + (j + 1)).pad(10) + 'Name:    ' + item.name + '\r\n' +
                        (item.required != true ? '              :    OPTIONAL \r\n' : '') +
                        (item.isMulti == true ? '              :    Multi-parameter \r\n' : '') +
                        (item.defaultValue != undefined ? ' Default Value:    ' + $.toStr(item.defaultValue, true) + '\r\n' : '') +
                        '         Types:    [' + item.types.collect(function (a) { return a.name; }).join(', ') + '] \r\n' +
                        '   Description:    ' + item.description + '\r\n\r\n';
                }).joinLines() + '\r\n') : ''),

                ext.details.returnTypeName ? ('\r\n    Return Type: ' + ext.details.returnTypeName + '\r\n') : '',
                (ext.details.aliases && ext.details.aliases.length > 0 ? ('\r\n    Aliases: \r\n' +
                    ext.details.aliases.collect(function (alias, i) {
                        return ''.pad(13) + ext.methodCall + '.' + alias;
                    }).join(', ') + '\r\n\r\n') : ''),

                ext.details.returns ? ('\r\n    Returns: \r\n' + ext.details.returns + '\r\n\r\n') : '',

                (ext.details.examples ? ('\r\n    Examples: \r\n' + ext.details.examples.joinLines()) : ''),

                (ext.method && includeCode ? ('\r\n    Method Code: \r\n\r\n' + ext.method.toString()) : '')]
                .joinLines()
                .replaceAll('\r\n\r\n\r\n', '\r\n\r\n');

            out += '\r\n';

            if (ext.details.unitTests && ext.details.unitTests.length > 0) {
                out += '    Test Requirements: \r\n';

                var methodTestsFound = 0;
                var methodTestsPassed = 0;

                for (var i = 0; i < sing.extensions[ext.name].details.unitTests.length; i++) {

                    methodTestsFound++;
                    testsFound++;

                    var test = sing.extensions[ext.name].details.unitTests[i];

                    if (!test) {
                        continue;
                    }

                    out += '        ' + (test.requirement || '') + '\r\n';

                    try {
                        var testPasses = test.testFunc();

                        if (testPasses == true || testPasses === undefined || testPasses === null) {
                            testsPassed++;
                            methodTestsPassed++;
                        }
                        else {
                            out += '        ' + (testPasses ? "" : "").pad(50) +
                            ' TEST CASE FAILS \r\n\r\n';
                        }

                    }
                    catch (ex) {
                        out += '        ' + ext.name.pad(50) + 'TEST CASE FAILS \r\n\r\n';
                    }
                }
                if (methodTestsFound > 0) {
                    if (methodTestsFound == methodTestsPassed) {
                        out += '----' + '\r\nAll Test Cases Passed\r\n\r\n';
                    }
                    else {
                        out += '----' + methodTestsPassed + ' / ' + methodTestsFound +
                        ' (' + methodTestsPassed.percentOf(methodTestsFound, 0, true) + ') Test Cases Passed\r\n\r\n';
                    }
                }
            }
        }
        else {
            out += '\r\n';
            out += line + '\r\n';
            out += ext.name + '\r\n';
            out += line + '\r\n';
            out += '\r\n';
        }

    });

    if (!includeDocumentation) {
        out = '';
    }

    var totalFound = featuresFound + documentaionFound + testsPassed + featuresHaveTests;
    var totalCount = featuresCount + documentaionCount + testsFound + featuresNeedTests;

    var leftSpace = 40;

    header += '\r\n';

    if (featuresFound != 0 || featuresCount != 0)
        header += 'Methods Implemented:      ' + (featuresFound + ' / ' + featuresCount).pad(leftSpace, Direction.r) + ' (' + featuresFound.percentOf(featuresCount, 0, true) + ')' + '\r\n';

    if (featuresHaveTests != 0 || featuresNeedTests != 0)
        header += 'Unit Tests Implemented:   ' + (featuresHaveTests + ' / ' + featuresNeedTests).pad(leftSpace, Direction.r) + ' (' + featuresHaveTests.percentOf(featuresNeedTests, 0, true) + ')' + '\r\n';

    if (testsPassed != 0 || testsFound != 0)
        header += 'Unit Tests Passed:        ' + (testsPassed + ' / ' + testsFound).pad(leftSpace, Direction.r) + ' (' + testsPassed.percentOf(testsFound, 0, true) + ')' + '\r\n';

    if (documentaionFound != 0 || documentaionCount != 0)
        header += 'Documentation:            ' + (documentaionFound + ' / ' + documentaionCount).pad(leftSpace, Direction.r) + ' (' + documentaionFound.percentOf(documentaionCount, 0, true) + ')' + '\r\n';

    header += '\r\n';

    if (totalFound != 0 || totalCount != 0)
        header += 'Total:                    ' + (totalFound + ' / ' + totalCount).pad(leftSpace, Direction.r) + ' (' + totalFound.percentOf(totalCount, 0, true) + ')' + '\r\n';

    return header + out;
};

singDocs.addExt('getMissing', SingularityGetMissing);

function SingularityGetMissing(funcName?: string) {

    this.resolveTests();

    var featuresCount = 0;
    var featuresFound = 0;

    var documentaionCount = 0;
    var documentaionFound = 0;

    var header = 'Singularity.TS TypeScript, JavaScript, jQuery, HTML, Extension Method Engine & Library\r\n';
    var out = '';

    $.objEach(sing.extensions, function (key: string, ext: SingularityExtension, i: number) {

        if (funcName &&
            funcName.lower() != '' &&
            funcName.lower() != 'all' &&
            !ext.name.lower().contains(funcName.lower()))
            return;

        featuresCount += 1; // method
        documentaionCount += 5 + // documentation
        1;  // test cases

        if (ext.method)
            featuresFound++;
        else
            out += ext.name + ' Method Implementation \r\n';

        if (ext.details) {
            if (ext.details.summary)
                documentaionFound++;
            else
                out += ext.name + ' Summary \r\n';

            if (ext.details.parameters)
                documentaionFound++;
            else
                out += ext.name + ' Parameters \r\n';

            if (ext.details.returnTypeName)
                documentaionFound++;
            else
                out += ext.name + ' Return Type \r\n';

            if (ext.details.returns)
                documentaionFound++;
            else
                out += ext.name + ' Returns \r\n';

            if (ext.details.examples)
                documentaionFound++;
            else
                out += ext.name + ' Examples \r\n';

            if (ext.details.unitTests && ext.details.unitTests.length > 0)
                documentaionFound++;
            else
                out += ext.name + ' Tests \r\n';
        }
    });

    header += '\r\n' +
    'Methods Implemented:      ' + featuresFound + ' / ' + featuresCount + ' (' + Math.round((featuresFound / featuresCount) * 100) + '%) \r\n' +
    'Documentation:            ' + documentaionFound + ' / ' + documentaionCount + ' (' + Math.round((documentaionFound / documentaionCount) * 100) + '%) \r\n';

    return header + out;

};

singDocs.addExt('getSummary', SingularityGetSummary);

function SingularityGetSummary(funcName: string = 'all', includeFunctions: boolean = true) {

    var out = sing.getDocs(funcName, false, false);

    out += '\r\n';

    if (includeFunctions) {
        $.objEach(sing.extensions, function (key, ext, i) {

            if (funcName &&
                funcName.lower() != '' &&
                funcName.lower() != 'all' &&
                !ext.name.lower().contains(funcName.lower()))
                return;

            out += '\r\n' + (ext.name + ' ').pad(30);

            out += ((ext.details.returnTypeName || '') + ' function(').pad(20, Direction.r);

            out += ((ext.details && ext.details.parameters) ? ext.details.parameters.collect(function (item, i) {
                var TypeNames = item.types.collect(function (a) { return a.name }).join(', ');
                return (i > 0 ? ''.pad(50) : '') +
                    '[' + TypeNames + '] ' + item.name;
            }).join(', \r\n') : '') +
            ') ' +
            (ext.details && ext.details.parameters && ext.details.parameters.length > 1 ? '\r\n' + ''.pad(50) : '') +
            '{ ... } ';
        });
    }
    return out;
};


// Tests from http://en.wikipedia.org/wiki/BBCode
sing.BBCodes = <BBCode[]>[
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
        matchStr: /\[url\=\"*(.+)\](.+)\[\/url\]/,
        htmlStr: '<a href=$1>$2</a>',
        textStr: '$2',

        test: '[url="http://example.com"]Example[/url]',
    },
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
'<object><param name="movie" value="http://www.youtube.com">' +
'<embed src="$1" type="application/x-shockwave-flash" width="400" height="325" title="Adobe Flash Player">' +
'</object>',
textStr: '$1',

test: '',
},
{
name: 'YouTube Width',
tag: '[youtube width=][/youtube]',
matchStr: /[youtube width\=(\d{1,5})](\w+)[\/youtube]/,
htmlStr:
'<object><param name="movie" value="http://www.youtube.com">' +
'<embed src="$2" type="application/x-shockwave-flash" width="$1" height="325" title="Adobe Flash Player">' +
'</object>',
textStr: '$2',

test: '',
},
{
name: 'YouTube Height',
tag: '[youtube height=][/youtube]',
matchStr: /[youtube height\=(\d{1,5})](\w+)[\/youtube]/,
htmlStr:
'<object><param name="movie" value="http://www.youtube.com">' +
'<embed src="$2" type="application/x-shockwave-flash" width="400" height="$1" title="Adobe Flash Player">' +
'</object>',
textStr: '$2',

test: '',
},
{
name: 'YouTube Width + Height',
tag: '[youtube width= height=][/youtube]',
matchStr: /[youtube width\=(\d{1,5}) height\=(\d{1,5})](\w+)[\/youtube]/,
htmlStr:
'<object><param name="movie" value="http://www.youtube.com">' +
'<embed src="$3" type="application/x-shockwave-flash" width="$1" height="$2" title="Adobe Flash Player">' +
'</object>',
textStr: '$3',

test: '',
},
{
name: 'YouTube Width x Height',
tag: '[youtube={width}x{height}][/youtube]',
matchStr: /[youtube\=(\d{1,5})x(\d{1,5})](\w+)[\/youtube]/,
htmlStr:
'<object><param name="movie" value="http://www.youtube.com">' +
'<embed src="$3" type="application/x-shockwave-flash" width="$1" height="$2" title="Adobe Flash Player">' +
'</object>',
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
];
