﻿/// <reference path="singularity-core.ts"/>

class SingularityTests {

    testErrors: string[] = [];

    addTest: (name: string, testFunc: () => any, requirement?: string) => void;
    addCustomTest: (name: string, testFunc: () => any, requirement?: string) => void;
    addMethodTest: (ext: SingularityMethod, target?: any, args?: any[], compare?: any, requirement?: string) => void;
    addAssertTest: (name: string, result: any, compare: any, requirement?: string) => void;
    addFailsTest: (ext: SingularityMethod, target: any, args: any[], expectedError?: string, requirement?: string) => void;
    runTests: (display: boolean) => string;
    listTests: () => string;
    listMissingTests: () => string;

    resolveTests = function () {
        
        // Resolve module feature tests
        $.objEach(sing.modules, function (key, mod, i) {
            if (!$.isEmpty(mod.features)) {

                mod.features.each(function (item) {
                    if ($.isFunction(item.tests))
                        item.tests(null);

                    if ($.isFunction(item.tests))
                        item.tests = null;
                });
            }
        });

        $.objEach(sing.methods, function (key, ext, i) {

            if (ext.isAlias)
                return;

            // Resolve method feature tests
            if (ext && ext.details.features) {
                ext.details.features.each(function (item) {
                    if ($.isFunction(item.tests))
                        item.tests(ext);

                    if ($.isFunction(item.tests))
                        item.tests = null;
                });
            }
            
            // Resolve method details tests
            if (ext && ext.details.tests && $.isFunction(ext.details.tests)) {

                ext.details.tests(ext);

                // Clear it if it's still a function (no tests)
                if ($.isFunction(ext.details.tests))
                    ext.details.tests = null;
            }
        });
    };

    constructor() {
    }
}

class SingularityTest {

    testResult: any;

    constructor(public name: string,
        public testFunc: Function,
        public index: number,
        public requirement?: string) {

        this.testFunc = function () {

            this.testResult = testFunc();

            if (this.testResult == null)
                this.testResult = true;

            if (this.testResult !== true &&
                this.testResult !== undefined &&
                this.testResult !== null) {

                this.testResult = '#' + index + ': ' + name + ' ' + this.testResult + (this.requirement ? ' ' + this.requirement : '');

                if (!sing.tests.testErrors.has(this.testResult))
                    sing.tests.testErrors.push(this.testResult);
                else {
                    sing.tests = sing.tests;
                }
            }
            return this.testResult;
        }
    }
}

sing.addType('SingularityTests', {
    typeClass: SingularityTests,
    protoType: SingularityTests.prototype,
    name: 'SingularityTests',
    autoDefault: this.autoDefaults,
});

sing.tests = new SingularityTests();

var singTests = singCore.addModule(new sing.Module('Tests', SingularityTests));


singTests.method('resolveTests', sing.tests.resolveTests, {});

singTests.method('addTest', SingularityAddTest, {});

function SingularityAddTest(name: string, testFunc: () => any, requirement?: string) {

    if (!sing.methods[name])
        throw name + ' not found';

    if (!sing.methods[name].details.tests)
        throw name + ' tests not found';

    if ($.isFunction(sing.methods[name].details.tests))
        sing.methods[name].details.unitTests = sing.methods[name].details.unitTests || [];

    sing.methods[name].details.unitTests = sing.methods[name].details.unitTests.concat(new SingularityTest(name, testFunc, sing.methods[name].details.unitTests.length + 1, requirement));
};

singTests.method('addCustomTest', SingularityAddCustomTest, {});

function SingularityAddCustomTest(name: string, testFunc: Function, requirement?: string) {
    if (!$.isString(name))
        throw name + ' was not a string';

    if (!sing.methods[name])
        throw name + ' not found';

    if (!sing.methods[name].details.tests)
        throw name + ' tests not found';

    requirement = requirement || '';

    requirement += '\r\n' + testFunc.toString() + '\r\n';

    sing.methods[name].details.unitTests = sing.methods[name].details.unitTests || [];

    sing.methods[name].details.unitTests = sing.methods[name].details.unitTests.concat(new SingularityTest(name, testFunc, sing.methods[name].details.unitTests.length + 1, requirement));
};

singTests.method('addMethodTest', SingularityAddMethodTest, {});

function SingularityAddMethodTest(ext: SingularityMethod, target?: any, args?: any[], compare?: any, requirement?: string) {

    if (!ext.method)
        throw ext.name + ' method not found';

    requirement = (requirement ? (requirement + '\r\n') : '') +
    (!!target ? '(' + $.toStr(target, true) + ').' : '') + ext.shortName;

    requirement += '(';
    for (var i = 0; i < args.length; i++) {
        requirement += $.toStr(args[i], true);
        if (i < args.length - 1)
            requirement += ', ';
    }
    requirement += ')';

    requirement = requirement.pad(50);

    requirement += '// == (' + $.toStr(compare, true) + ')';

    // ext.details = ext.details || {};
    // ext.details.examples = ext.details.examples || [];

    // ext.details.examples.push(requirement);

    this.addTest(ext.name, function (): any {
        var result = ext.method.apply(target, args);

        if (compare == result)
            return true;
        else if ($.toStr(compare) == $.toStr(result))
            return true;
        else
            return requirement + '\r\n \r\n' +
                $.toStr(compare, true) + ' expected, result: ' + $.toStr(result, true);
    }, requirement);

};

singTests.method('addAssertTest', SingularityAddAssertTest, {});

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

singTests.method('addFailsTest', SingularityAddFailsTest, {});

function SingularityAddFailsTest(ext: SingularityMethod, target: any, args: any[], expectedError?: string, requirement?: string) {

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

singTests.method('runTests', SingularityRunTests, {});

function SingularityRunTests(display: boolean = false) {

    sing.tests.resolveTests();

    var result: string = '';
    var testCount = 0;

    var displayStr = '';

    var testGroups: Hash<SingularityTest[]> = {};

    $.objValues(sing.modules).each(function (mod) {
        if (mod.features)
            mod.features.each(function (feature) {
                if (feature.unitTests) {
                    if (testGroups[mod.fullName()])
                        testGroups[mod.fullName()] = testGroups[mod.fullName()].concat(feature.unitTests);
                    else
                        testGroups[mod.fullName()] = feature.unitTests;
                }
            });
    });

    $.objValues(sing.methods).each(function (method) {

        if (method.details.features)
            method.details.features.each(function (feature) {
                if (feature.unitTests) {
                    if (testGroups[method + ' ' + feature.name])
                        testGroups[method + ' ' + feature.name] = testGroups[method + ' ' + feature.name].concat(feature.unitTests);
                    else
                        testGroups[method + ' ' + feature.name] = feature.unitTests;
                }
            });

        if (method.details) {
            testGroups[method.name] = method.details.unitTests;
            if (testGroups[method.name])
                testGroups[method.name] = testGroups[method.name].concat(method.details.unitTests);
            else
                testGroups[method.name] = method.details.unitTests;
        }
    });

    $.objProperties(testGroups).each(function (testGroup) {

        var name = testGroup.key;
        var tests = testGroup.value;
        if (tests) {
            tests.each(function (test, i) {

                if (display)
                    displayStr += test.requirement + '\r\n';

                var testFunc = test.testFunc;

                var testResult = testFunc();

                if (testResult != true && testResult !== undefined && testResult !== null) {
                    testResult = testResult || '';
                    result += 'Error testing \'' + name + '\' Test ' + (i + 1) + '\r\n' + testResult;
                }

                testCount++;
            });
        }
    });

    return sing.tests.listTests() + '\r\n' +
        displayStr + '\r\n' +
        (result || '\r\n\r\nAll ' + testCount + ' tests succeeded.');
};

singTests.method('listTests', SingularityListTests, {});

function SingularityListTests() {

    sing.tests.resolveTests();

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
};

singTests.method('listMissingTests', SingularityListMissingTests, {});

function SingularityListMissingTests() {

    sing.tests.resolveTests();

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
};

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

SingularityMethod.prototype.addFailsTest = MethodAddFailsTest;

singTests.method('addFailsTest', MethodAddFailsTest, {}, SingularityMethod);

function MethodAddFailsTest(caller: any, args: any[], expectedError?: string, requirement?: string): void {

    sing.tests.addFailsTest(this, caller, args, expectedError, requirement);
}

SingularityMethod.prototype.addCustomTest = MethodAddCustomTest;

singTests.method('addCustomTest', MethodAddCustomTest, {}, SingularityMethod);

function MethodAddCustomTest(testFunc: () => any, requirement?: string): void {
    sing.tests.addCustomTest(this.name, testFunc, requirement);
}

SingularityMethod.prototype.addTest = MethodAddSimpleTest;

singTests.method('addTest', MethodAddSimpleTest, {}, SingularityMethod);

function MethodAddSimpleTest(caller: any, args: any[], result?: any, requirement?: string): void {

    var thisSingularityMethod = <SingularityMethod>this;

    sing.tests.addMethodTest(this, caller, args, result, requirement);
}
