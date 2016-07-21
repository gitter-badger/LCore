/// <reference path="singularity-core.ts"/>
var loggingInfoEnabled = true;
var loggingErrorEnabled = true;
var loggingWarningEnabled = true;
var singLog = singCore.addModule(new sing.Module('Logging', sing, sing));
singLog.glyphIcon = '&#xe105;';
singLog.ignoreUnknown('ALL');
function log() {
    var message = [];
    for (var _i = 0; _i < arguments.length; _i++) {
        message[_i - 0] = arguments[_i];
    }
    if (loggingInfoEnabled) {
        console.log("%c" + message, 'background: #eee; color: #555');
    }
}
singLog.method('log', arrayLog, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    }
}, Array.prototype, 'Array');
function arrayLog() {
    log(this);
}
singLog.method('log', numberLog, {
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
}, Number.prototype, 'Number');
function numberLog() {
    log(this);
}
singLog.method('log', stringLog, {
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
}, String.prototype, 'String');
function stringLog() {
    log(this);
}
singLog.method('log', booleanLog, {
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
}, Boolean.prototype, 'Boolean');
function booleanLog() {
    log(this);
}
function warn() {
    var message = [];
    for (var _i = 0; _i < arguments.length; _i++) {
        message[_i - 0] = arguments[_i];
    }
    if (loggingWarningEnabled) {
        if ($.toStr && $.resolve)
            console.log("%c" + $.toStr($.resolve(message), true), 'background: #555; color: #F7DAA3');
        else
            console.log("%c" + message, 'background: #555; color: #F7DAA3');
    }
}
singLog.method('warn', arrayWarn, {}, Array.prototype, 'Array');
function arrayWarn() {
    warn(this);
}
singLog.method('warn', numberWarn, {}, Number.prototype, 'Number');
function numberWarn() {
    warn(this);
}
singLog.method('warn', stringWarn, {}, String.prototype, 'String');
function stringWarn() {
    warn(this);
}
singLog.method('warn', booleanWarn, {}, Boolean.prototype, 'Boolean');
function booleanWarn() {
    warn(this);
}
function error() {
    var message = [];
    for (var _i = 0; _i < arguments.length; _i++) {
        message[_i - 0] = arguments[_i];
    }
    if (loggingErrorEnabled) {
        console.log(message);
    }
}
singLog.method('error', arrayError, {}, Array.prototype, 'Array');
function arrayError() {
    error(this);
}
singLog.method('error', numberError, {}, Number.prototype, 'Number');
function numberError() {
    error(this);
}
singLog.method('error', stringError, {}, String.prototype, 'String');
function stringError() {
    error(this);
}
singLog.method('error', booleanError, {}, Boolean.prototype, 'Boolean');
function booleanError() {
    error(this);
}
//# sourceMappingURL=singularity-log.js.map