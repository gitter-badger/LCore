/// <reference path="singularity-core.ts"/>
var SingularityTest = (function () {
    function SingularityTest(name, testFunc, requirement) {
        this.name = name;
        this.testFunc = testFunc;
        this.requirement = requirement;
        this.testFunc = function () {
            this.testResult = testFunc();
            if (this.testResult == null)
                this.testResult = true;
            return this.testResult;
        };
    }
    return SingularityTest;
})();
var singTests = singCore.addModule(new sing.Module('Tests', sing, sing));
singTests.requiredDocumentation = false;
singTests.requiredUnitTests = false;
singTests.method('addTest', SingularityAddTest, {}, sing);
function SingularityAddTest(name, testFunc, requirement) {
    if (!sing.methods[name])
        throw name + ' not found';
    if (!sing.methods[name].details.tests)
        throw name + ' tests not found';
    if ($.isFunction(sing.methods[name].details.tests))
        sing.methods[name].details.unitTests = sing.methods[name].details.unitTests || [];
    sing.methods[name].details.unitTests = sing.methods[name].details.unitTests.concat(new SingularityTest(name, testFunc, requirement));
}
;
singTests.method('addCustomTest', SingularityAddCustomTest, {}, sing);
function SingularityAddCustomTest(name, testFunc, requirement) {
    if (!$.isString(name))
        throw name + ' was not a string';
    if (!sing.methods[name])
        throw name + ' not found';
    if (!sing.methods[name].details.tests)
        throw name + ' tests not found';
    requirement = requirement || '';
    requirement += '\r\n' + testFunc.toString() + '\r\n';
    sing.methods[name].details.unitTests = sing.methods[name].details.unitTests || [];
    sing.methods[name].details.unitTests = sing.methods[name].details.unitTests.concat(new SingularityTest(name, testFunc, requirement));
}
;
singTests.method('addMethodTest', SingularityAddMethodTest, {}, sing);
function SingularityAddMethodTest(ext, target, args, compare, requirement) {
    if (!ext.method)
        throw ext.name + ' method not found';
    requirement = (requirement ? (requirement + '\r\n') : '') + (!!target ? '(' + $.toStr(target, true) + ').' : '') + ext.shortName;
    requirement += '(';
    for (var i = 0; i < args.length; i++) {
        requirement += $.toStr(args[i], true);
        if (i < args.length - 1)
            requirement += ', ';
    }
    requirement += ')';
    requirement = requirement.pad(50);
    requirement += ' == (' + $.toStr(compare, true) + ')';
    this.addTest(ext.name, function () {
        var result = ext.method.apply(target, args);
        if (compare == result)
            return true;
        else if ($.toStr(compare) == $.toStr(result))
            return true;
        else
            return requirement + '\r\n' + $.toStr(compare, true) + ' expected, result: ' + $.toStr(result, true);
    }, requirement);
}
;
singTests.method('addAssertTest', SingularityAddAssertTest, {}, sing);
function SingularityAddAssertTest(name, result, compare, requirement) {
    requirement = requirement || $.toStr(compare, true) + ' is expected to match result: ' + $.toStr(result, true);
    this.addTest(name, function () {
        if (compare == result)
            return true;
        else if ($.toStr(compare) == $.toStr(result))
            return true;
        else
            return requirement + '\r\n' + ' TEST FAILED \r\n';
    }, requirement);
}
;
singTests.method('addFailsTest', SingularityAddFailsTest, {}, sing);
function SingularityAddFailsTest(ext, target, args, expectedError, requirement) {
    if (target == null || target == undefined)
        throw 'no target';
    requirement = (requirement ? (requirement + '\r\n') : '') + '(' + $.toStr(target, true) + ').' + ext.shortName;
    requirement += '(';
    for (var i = 0; i < args.length; i++) {
        requirement += $.toStr(args[i], true);
        if (i < args.length - 1)
            requirement += ', ';
    }
    requirement += ')';
    requirement = requirement.pad(50);
    requirement += ' THROWS ' + (expectedError ? '\'' + expectedError + '\'' : 'AN ERROR ');
    this.addTest(ext.name, function () {
        try {
            var result = ext.method.apply(target, args);
            return name + ' was expected to fail but it did not. \r\n\r\n' + requirement;
        }
        catch (ex) {
            if (expectedError && ex != expectedError && ex != 'Uncaught ' + expectedError && 'Uncaught ' + ex != expectedError) {
                return name + ' was expected to fail with a message of \'' + expectedError + '\' \r\n' + 'but instead failed with error \'' + ex + '\'' + '\r\n\r\n' + requirement;
            }
            return true;
        }
    }, requirement);
}
;
singTests.method('runTests', SingularityRunTests, {}, sing);
function SingularityRunTests(display) {
    if (display === void 0) { display = false; }
    this.resolveTests();
    var result;
    var testCount = 0;
    var displayStr = '';
    for (var i = 0; i < Object.keys(sing.methods).length; i++) {
        var name = Object.keys(sing.methods)[i];
        var ext = sing.methods[name];
        var tests = ext.details.unitTests;
        if (tests) {
            for (var j = 0; j < tests.length; j++) {
                var test = tests[j];
                // log('running test ' + name + ' ' + (j + 1));
                if (display)
                    displayStr += test.requirement + '\r\n';
                var testFunc = test.testFunc;
                var testResult = testFunc();
                if (testResult != true && testResult !== undefined && testResult !== null) {
                    testResult = testResult || '';
                    result = 'Error testing \'' + name + '\' Test ' + (j + 1) + '\r\n' + testResult;
                    break;
                }
                testCount++;
            }
        }
        ;
    }
    return sing.listTests() + '\r\n' + displayStr + '\r\n' + (result || '\r\n\r\nAll ' + testCount + ' tests succeeded.');
}
;
singTests.method('listTests', SingularityListTests, {}, sing);
function SingularityListTests() {
    this.resolveTests();
    var out = '\r\n';
    for (var i = 0; i < Object.keys(sing.methods).length; i++) {
        var name = Object.keys(sing.methods)[i];
        var item = sing.methods[name];
        var tests = item.details.unitTests;
        if (tests && tests.length > 0)
            out += ('Extension: ' + name).pad(50) + '      Tests: ' + tests.length + '\r\n';
        else
            ; // out += 'Function: ' + name + '      Tests: 0\r\n';
    }
    return out;
}
;
singTests.method('listMissingTests', SingularityListMissingTests, {}, sing);
function SingularityListMissingTests() {
    this.resolveTests();
    var out = '';
    for (var i = 0; i < Object.keys(sing.methods).length; i++) {
        var name = Object.keys(sing.methods)[i];
        var item = sing.methods[name];
        var tests = item.details.unitTests;
        if (!tests || tests.length == 0) {
            out += 'Extension: ' + name + '      Tests: 0\r\n';
        }
    }
    return out;
}
;
singTests.method('resolveTests', SingularityResolveTests, {}, sing);
function SingularityResolveTests() {
    $.objEach(sing.methods, function (key, ext, i) {
        if (ext && ext.details.tests && $.isFunction(ext.details.tests)) {
            ext.details.tests(ext);
            // Clear it if it's still a function (no tests)
            if ($.isFunction(ext.details.tests))
                ext.details.tests = [];
        }
    });
}
;
//# sourceMappingURL=singularity-tests.js.map