/// <reference path="singularity-core.ts"/>
var singDocs = singCore.addModule(new sing.Module('Documentation', Singularity));
singDocs.glyphIcon = '&#xe086;';
singDocs.ignoreUnknown('ALL');
singDocs.method('getDocs', SingularityGetDocs);
function SingularityGetDocs(funcName, includeCode, includeDocumentation) {
    if (includeCode === void 0) { includeCode = false; }
    if (includeDocumentation === void 0) { includeDocumentation = true; }
    sing.tests.resolveTests();
    var featuresCount = 0;
    var featuresFound = 0;
    var featuresHaveTests = 0;
    var featuresNeedTests = 0;
    var documentaionCount = 0;
    var documentaionFound = 0;
    var testsFound = 0;
    var testsPassed = 0;
    var header = '';
    if (!funcName || funcName == '' || funcName == 'all')
        header = sing.summary + '\r\n\r\n';
    var out = '';
    $.objEach(sing.methods, function (key, ext, index) {
        var mod = sing.modules[ext.moduleName];
        if (funcName && funcName.lower() != '' && funcName.lower() != 'all' && !ext.name.lower().startsWith(funcName.lower()))
            return;
        if (ext.isAlias) {
            return;
        }
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
            if (ext.isAlias && includeDocumentation == true) {
                return;
            }
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
            out += [
                line,
                ext.methodCall.pad(40) + (!ext.method ? ' -- NOT IMPLEMENTED' : functionDef).pad(40, Direction.r),
                line,
                (ext.details.summary ? ('\r\n    Summary: \r\n' + ext.details.summary) : ''),
                (ext.details.parameters && ext.details.parameters.length == 0 ? '\r\n    Parameters: None\r\n' : ''),
                (ext.details.parameters && ext.details.parameters.length > 0 ? ('\r\n    Parameters:\r\n' + ext.details.parameters.collect(function (item, j) {
                    return (' #' + (j + 1)).pad(10) + 'Name:    ' + item.name + '\r\n' + (item.required != true ? '              :    OPTIONAL \r\n' : '') + (item.isMulti == true ? '              :    Multi-parameter \r\n' : '') + (item.defaultValue != undefined ? ' Default Value:    ' + $.toStr(item.defaultValue, true) + '\r\n' : '') + '         Types:    [' + item.types.collect(function (a) {
                        return a.name;
                    }).join(', ') + '] \r\n' + '   Description:    ' + item.description + '\r\n\r\n';
                }).joinLines() + '\r\n') : ''),
                ext.details.returnTypeName ? ('\r\n    Return Type: ' + ext.details.returnTypeName + '\r\n') : '',
                (ext.details.aliases && ext.details.aliases.length > 0 ? ('\r\n    Aliases: \r\n' + ext.details.aliases.collect(function (alias, i) {
                    return ''.pad(13) + ext.methodCall + '.' + alias;
                }).join(', ') + '\r\n\r\n') : ''),
                ext.details.returns ? ('\r\n    Returns: \r\n' + ext.details.returns + '\r\n\r\n') : '',
                (ext.details.examples ? ('\r\n    Examples: \r\n' + ext.details.examples.joinLines()) : ''),
                (ext.method && includeCode ? ('\r\n    Method Code: \r\n\r\n' + ext.method.toString()) : '')
            ].joinLines().replaceAll('\r\n\r\n\r\n', '\r\n\r\n');
            out += '\r\n';
            if (ext.details.unitTests && ext.details.unitTests.length > 0) {
                out += '    Test Requirements: \r\n';
                var methodTestsFound = 0;
                var methodTestsPassed = 0;
                for (var i = 0; i < sing.methods[ext.name].details.unitTests.length; i++) {
                    methodTestsFound++;
                    testsFound++;
                    var test = sing.methods[ext.name].details.unitTests[i];
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
                            out += '        ' + (testPasses ? "" : "").pad(50) + ' TEST CASE FAILS \r\n\r\n';
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
                        out += '----' + methodTestsPassed + ' / ' + methodTestsFound + ' (' + methodTestsPassed.percentOf(methodTestsFound, 0, true) + ') Test Cases Passed\r\n\r\n';
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
}
;
singDocs.method('getMissing', SingularityGetMissing);
function SingularityGetMissing(funcName) {
    sing.tests.resolveTests();
    var featuresCount = 0;
    var featuresFound = 0;
    var documentaionCount = 0;
    var documentaionFound = 0;
    var header = 'Singularity.TS TypeScript, JavaScript, jQuery, HTML, Extension Method Engine & Library\r\n';
    var out = '';
    $.objEach(sing.methods, function (key, ext, i) {
        if (funcName && funcName.lower() != '' && funcName.lower() != 'all' && !ext.name.lower().contains(funcName.lower()))
            return;
        featuresCount += 1; // method
        documentaionCount += 5 + 1; // test cases
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
    header += '\r\n' + 'Methods Implemented:      ' + featuresFound + ' / ' + featuresCount + ' (' + Math.round((featuresFound / featuresCount) * 100) + '%) \r\n' + 'Documentation:            ' + documentaionFound + ' / ' + documentaionCount + ' (' + Math.round((documentaionFound / documentaionCount) * 100) + '%) \r\n';
    return header + out;
}
;
singDocs.method('getSummary', SingularityGetSummary);
function SingularityGetSummary(funcName, includeFunctions) {
    if (funcName === void 0) { funcName = 'all'; }
    if (includeFunctions === void 0) { includeFunctions = true; }
    var out = sing.getDocs(funcName, false, false);
    out += '\r\n';
    if (includeFunctions) {
        $.objEach(sing.methods, function (key, ext, i) {
            if (funcName && funcName.lower() != '' && funcName.lower() != 'all' && !ext.name.lower().contains(funcName.lower()))
                return;
            out += '\r\n' + (ext.name + ' ').pad(30);
            out += ((ext.details.returnTypeName || '') + ' function(').pad(20, Direction.r);
            out += ((ext.details && ext.details.parameters) ? ext.details.parameters.collect(function (item, i) {
                var TypeNames = item.types.collect(function (a) {
                    return a.name;
                }).join(', ');
                return (i > 0 ? ''.pad(50) : '') + '[' + TypeNames + '] ' + item.name;
            }).join(', \r\n') : '') + ') ' + (ext.details && ext.details.parameters && ext.details.parameters.length > 1 ? '\r\n' + ''.pad(50) : '') + '{ ... } ';
        });
    }
    return out;
}
;
//# sourceMappingURL=singularity-doc.js.map