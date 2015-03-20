/// <reference path="singularity-core.ts"/>

interface ISingularityTests {
    addTest?: (name: string, testFunc: () => any, requirement?: string) => void;
    addCustomTest?: (name: string, testFunc: () => any, requirement?: string) => void;
    addMethodTest?: (ext: SingularityExtension, target?: any, args?: any[], compare?: any, requirement?: string) => void;
    addAssertTest?: (name: string, result: any, compare: any, requirement?: string) => void;
    addFailsTest?: (ext: SingularityExtension, target: any, args: any[], expectedError?: string, requirement?: string) => void;
    runTests?: (display: boolean) => string;
    listTests?: () => string;
    listMissingTests?: () => string;
}

class SingularityTest {

    constructor(public name: string,
        public testFunc: Function,
        public requirement?: string) {
    }
}

var singTests = sing.addModule(new sing.Module('Singularity.Tests', sing, sing));
singTests.requiredDocumentation = false;
singTests.requiredUnitTests = false;

function InitSingularityTests() {

    singTests.addExt('addTest', SingularityAddTest, {}, sing);

    function SingularityAddTest(name: string, testFunc: () => any, requirement?: string) {

        if (!sing.extensions[name])
            throw name + ' not found';

        if (!sing.extensions[name].details.tests)
            throw name + ' tests not found';

        if ($.isFunction(sing.extensions[name].details.tests))
            sing.extensions[name].details.unitTests = sing.extensions[name].details.unitTests || [];

        sing.extensions[name].details.unitTests = sing.extensions[name].details.unitTests.concat(new SingularityTest(name, testFunc, requirement));
    };

    singTests.addExt('addCustomTest', SingularityAddCustomTest, {}, sing);

    function SingularityAddCustomTest(name: string, testFunc: Function, requirement?: string) {
        if (!$.isString(name))
            throw name + ' was not a string';

        if (!sing.extensions[name])
            throw name + ' not found';

        if (!sing.extensions[name].details.tests)
            throw name + ' tests not found';

        requirement = requirement || '';

        requirement += '\r\n' + testFunc.toString() + '\r\n';

        sing.extensions[name].details.unitTests = sing.extensions[name].details.unitTests || [];

        sing.extensions[name].details.unitTests = sing.extensions[name].details.unitTests.concat(new SingularityTest(name, testFunc, requirement));
    };

    singTests.addExt('addMethodTest', SingularityAddMethodTest, {}, sing);

    function SingularityAddMethodTest(ext: SingularityExtension, target?: any, args?: any[], compare?: any, requirement?: string) {

        if (!ext.method)
            throw ext.name + ' method not found';

        requirement = (requirement ? (requirement + '\r\n') : '') +
        '(' + $.toStr(target, true) + ').' + ext.shortName;

        requirement += '(';
        for (var i = 0; i < args.length; i++) {
            requirement += $.toStr(args[i], true);
            if (i < args.length - 1)
                requirement += ', ';
        }
        requirement += ')';

        requirement = requirement.pad(50);

        requirement += ' == (' + $.toStr(compare, true) + ')';

        this.addTest(ext.name, function (): any {
            var result = ext.method.apply(target, args);

            if (compare == result)
                return true;
            else if ($.toStr(compare) == $.toStr(result))
                return true;
            else
                return requirement + '\r\n' +
                    $.toStr(compare, true) + ' expected, result: ' + $.toStr(result, true);
        }, requirement);

    };

    singTests.addExt('addAssertTest', SingularityAddAssertTest, {}, sing);

    function SingularityAddAssertTest(name: string, result: any, compare: any, requirement?: string) {

        requirement = requirement || $.toStr(compare, true) + ' is expected to match result: ' + $.toStr(result, true)

        this.addTest(name, function (): any {
            if (compare == result)
                return true;
            else if ($.toStr(compare) == $.toStr(result))
                return true;
            else
                return requirement + '\r\n' +
                    ' TEST FAILED \r\n';
        }, requirement);
    };

    singTests.addExt('addFailsTest', SingularityAddFailsTest, {}, sing);

    function SingularityAddFailsTest(ext: SingularityExtension, target: any, args: any[], expectedError?: string, requirement?: string) {

        if (target == null || target == undefined)
            throw 'no target';

        requirement = (requirement ? (requirement + '\r\n') : '') +
        '(' + $.toStr(target, true) + ').' + ext.shortName;

        requirement += '(';
        for (var i = 0; i < args.length; i++) {
            requirement += $.toStr(args[i], true);
            if (i < args.length - 1)
                requirement += ', ';
        }
        requirement += ')';

        requirement = requirement.pad(50);

        requirement += ' THROWS ' + (expectedError ? '\'' + expectedError + '\'' : 'AN ERROR ');

        this.addTest(ext.name, function (): any {

            try {

                var result = ext.method.apply(target, args);

                return name + ' was expected to fail but it did not. \r\n\r\n' +
                    requirement;

            }
            catch (ex) {

                if (expectedError && ex != expectedError &&
                    ex != 'Uncaught ' + expectedError &&
                    'Uncaught ' + ex != expectedError) {

                    return name + ' was expected to fail with a message of \'' + expectedError + '\' \r\n' +
                        'but instead failed with error \'' + ex + '\'' + '\r\n\r\n' +
                        requirement;
                }

                return true;
            }
        }, requirement);
    };

    singTests.addExt('runTests', SingularityRunTests, {}, sing);

    function SingularityRunTests(display: boolean = false) {

        this.resolveTests();

        var result;
        var testCount = 0;

        var displayStr = '';

        for (var i = 0; i < Object.keys(sing.extensions).length; i++) {

            var name = Object.keys(sing.extensions)[i];

            var ext = sing.extensions[name];
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
            };
        }

        return (<ISingularityTests>sing).listTests() + '\r\n' +
            displayStr + '\r\n' +
            (result || '\r\n\r\nAll ' + testCount + ' tests succeeded.');
    };

    singTests.addExt('listTests', SingularityListTests, {}, sing);

    function SingularityListTests() {

        this.resolveTests();

        var out = '\r\n';

        for (var i = 0; i < Object.keys(sing.extensions).length; i++) {

            var name = Object.keys(sing.extensions)[i];

            var item = sing.extensions[name];
            var tests = item.details.unitTests;

            if (tests && tests.length > 0)
                out += ('Extension: ' + name).pad(30) + '      Tests: ' + tests.length + '\r\n';
            else
                ; // out += 'Function: ' + name + '      Tests: 0\r\n';
        }

        return out;
    };

    singTests.addExt('listMissingTests', SingularityListMissingTests, {}, sing);

    function SingularityListMissingTests() {

        this.resolveTests();

        var out = '';

        for (var i = 0; i < Object.keys(sing.extensions).length; i++) {

            var name = Object.keys(sing.extensions)[i];

            var item = sing.extensions[name];
            var tests = item.details.unitTests;

            if (!tests || tests.length == 0) {
                out += 'Extension: ' + name + '      Tests: 0\r\n';
            }
        }

        return out;
    };

    singTests.addExt('resolveTests', SingularityResolveTests, {}, sing);

    function SingularityResolveTests() {

        $.objEach(sing.extensions, function (key, ext, i) {

            if (ext && ext.details.tests && $.isFunction(ext.details.tests)) {

                ext.details.tests(ext);

                // Clear it if it's still a function (no tests)
                if ($.isFunction(ext.details.tests))
                    ext.details.tests = [];
            }
        });
    };
}

var LOGGING_ENABLED = true;

function log(...message: any[]) {
    if (LOGGING_ENABLED)
        console.log(message);
}