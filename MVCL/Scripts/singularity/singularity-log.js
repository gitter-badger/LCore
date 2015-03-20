/// <reference path="singularity-core.ts"/>
var LOGGING_INFO_ENABLED = false;
var LOGGING_ERROR_ENABLED = true;
var LOGGING_WARNING_ENABLED = true;
var singLog = sing.addModule(new sing.Module('Singularity.Logging', sing, sing));
singLog.requiredDocumentation = false;
function log() {
    var message = [];
    for (var _i = 0; _i < arguments.length; _i++) {
        message[_i - 0] = arguments[_i];
    }
    if (LOGGING_INFO_ENABLED)
        console.log('%c' + $.toStr($.resolve(message), true), 'background: #eee; color: #555');
}
singLog.addExt('log', ArrayLog, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    },
}, Array.prototype, "Array");
function ArrayLog() {
    log(this);
}
singLog.addExt('log', NumberLog, {
    summary: 'Common funciton - Logs the calling Number to the console.',
    parameters: [],
    returns: 'Nothing.',
    returnType: null,
    examples: ['\
            (1).log()   //  logs 1  \r\n\
            (5).log()   //  logs 5  \r\n'],
    tests: function (ext) {
        ext.addTest(true, []);
        ext.addTest(false, []);
    }
}, Number.prototype, "Number");
function NumberLog() {
    log(this);
}
singLog.addExt('log', StringLog, {
    summary: 'Common funciton - Logs the calling Boolean to the console.',
    parameters: [],
    returns: 'Nothing.',
    returnType: null,
    examples: ['\
            (\'a\').log()   //  logs a  \r\n\
            (\'hello\').log()   //  logs hello  \r\n'],
    tests: function (ext) {
        ext.addTest('', []);
        ext.addTest('a', []);
        ext.addTest('hello', []);
    }
}, String.prototype, "String");
function StringLog() {
    log(this);
}
singLog.addExt('log', BooleanLog, {
    summary: 'Common funciton - Logs the calling Boolean to the console.',
    parameters: [],
    returns: 'Nothing.',
    returnType: null,
    examples: ['\
            (true).log()   //  logs true  \r\n\
            (false).log()   //  logs false  \r\n'],
    tests: function (ext) {
        ext.addTest(true, []);
        ext.addTest(false, []);
    }
}, Boolean.prototype, "Boolean");
function BooleanLog() {
    log(this);
}
function warn() {
    var message = [];
    for (var _i = 0; _i < arguments.length; _i++) {
        message[_i - 0] = arguments[_i];
    }
    if (LOGGING_ERROR_ENABLED)
        console.log('%c Warning: ' + $.toStr($.resolve(message), true), 'background: #aaa; color: #F7DAA3');
}
singLog.addExt('warn', ArrayWarn, {}, Array.prototype, "Array");
function ArrayWarn() {
    warn(this);
}
singLog.addExt('warn', NumberWarn, {}, Number.prototype, "Number");
function NumberWarn() {
    warn(this);
}
singLog.addExt('warn', StringWarn, {}, String.prototype, "String");
function StringWarn() {
    warn(this);
}
singLog.addExt('warn', BooleanWarn, {}, Boolean.prototype, "Boolean");
function BooleanWarn() {
    warn(this);
}
function error() {
    var message = [];
    for (var _i = 0; _i < arguments.length; _i++) {
        message[_i - 0] = arguments[_i];
    }
    if (LOGGING_ERROR_ENABLED)
        console.log('%c Error: ' + $.toStr($.resolve(message), true), 'background: #eee; color: #FF0000');
}
singLog.addExt('error', ArrayError, {}, Array.prototype, "Array");
function ArrayError() {
    error(this);
}
singLog.addExt('error', NumberError, {}, Number.prototype, "Number");
function NumberError() {
    error(this);
}
singLog.addExt('error', StringError, {}, String.prototype, "String");
function StringError() {
    error(this);
}
singLog.addExt('error', BooleanError, {}, Boolean.prototype, "Boolean");
function BooleanError() {
    error(this);
}
//# sourceMappingURL=singularity-log.js.map