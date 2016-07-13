var singFunction = singExt.addModule(new sing.Module("Function", Function));
singFunction.glyphIcon = '&#xe019;';
singFunction.method('fn_try', FunctionTry, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    glyphIcon: '&#xe029;',
    tests: function (ext) {
        ext.addCustomTest(function () {
            (function () {
                throw 'fail';
            }).fn_try()();
        });
    },
});
function FunctionTry() {
    var source = this;
    return source.fn_catch();
}
singFunction.method('fn_catch', FunctionCatch, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    glyphIcon: '&#xe029;',
    tests: function (ext) {
        ext.addCustomTest(function () {
            var test = '';
            (function () {
                throw 'fail';
            }).fn_catch(function (ex) {
                test = ex;
            })();
            if (test != 'fail')
                return 'failed';
        });
    },
});
function FunctionCatch(catchFunction, logFailure) {
    if (logFailure === void 0) { logFailure = false; }
    var source = this;
    return function () {
        var result;
        try {
            result = source.apply(this, arguments);
        }
        catch (ex) {
            if (logFailure) {
                log(['FAILED', source.name, ex]);
                log([arguments]);
            }
            if (catchFunction)
                return catchFunction.apply(this, [ex].concat(arguments));
        }
        return result;
    };
}
singFunction.method('fn_log', FunctionLog, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    manuallyTested: true,
    glyphIcon: '&#xe105;',
});
function FunctionLog(logAttempt, logSuccess, logFailure) {
    if (logAttempt === void 0) { logAttempt = true; }
    if (logSuccess === void 0) { logSuccess = true; }
    if (logFailure === void 0) { logFailure = true; }
    var thisFunction = this;
    return function () {
        try {
            if (logAttempt) {
                log(['Attempting: ', thisFunction.name, arguments, result]);
            }
            var result = thisFunction.apply(this, arguments);
            if (logSuccess) {
                log(['Completed: ' + thisFunction.name, arguments, result]);
            }
            return result;
        }
        catch (ex) {
            if (logFailure) {
                log(['FAILED', thisFunction.name, ex]);
                log([arguments]);
            }
            throw ex;
        }
    };
}
singFunction.method('fn_count', FunctionCount, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    glyphIcon: '&#xe141;',
    examples: null,
});
function FunctionCount(logFailure) {
    if (logFailure === void 0) { logFailure = false; }
    var source = this;
    var functionCallCount = 0;
    return function () {
        try {
            var result = source.apply(this, arguments);
            log([source.name, 'count:' + functionCallCount]);
            log([arguments, result]);
            return result;
        }
        catch (ex) {
            if (logFailure) {
                log(['FAILED', source.name, ex, 'count:' + functionCallCount]);
                log([arguments]);
            }
            throw ex;
        }
    };
}
singFunction.method('fn_cache', FunctionCache, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    glyphIcon: '&#xe121;',
    manuallyTested: true,
});
function FunctionCache(uniqueCacheID, expiresAfter) {
    if (expiresAfter === void 0) { expiresAfter = 0; }
    var source = this;
    var cacheKeyLimit = 300;
    uniqueCacheID = uniqueCacheID || this.name;
    if (!uniqueCacheID)
        throw 'Unique ID not found';
    var ext = sing.methods['Singularity.Extensions.Function.fn_cache'];
    if (!ext.data)
        ext.data = {};
    if (!ext.data['cache'])
        ext.data['cache'] = {};
    return function () {
        var items = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            items[_i - 0] = arguments[_i];
        }
        var thisCaller = this;
        var cache = ext.data['cache'];
        if (!cache[uniqueCacheID])
            cache[uniqueCacheID] = {};
        var thisCache = cache[uniqueCacheID];
        var argStr = $.toStr(thisCaller) + '|||||||' + $.toStr(items);
        if (argStr.length > cacheKeyLimit) {
            return source.apply(thisCaller, items);
        }
        else {
            if (thisCache[argStr] != undefined && thisCache[argStr] != null) {
                if (thisCache[argStr].expires < (new Date()).valueOf()) {
                    thisCache[argStr] = {};
                }
                else {
                    return thisCache[argStr].value;
                }
            }
            else {
                thisCache[argStr] = {};
            }
            var result = thisCache[argStr].value = source.apply(thisCaller, items);
            if (expiresAfter > 0) {
                thisCache[argStr].expires = (new Date()).valueOf() + expiresAfter;
            }
            return result;
        }
    };
}
singFunction.method('fn_or', FunctionOR, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    glyphIcon: '&#xe110;',
    tests: function (ext) {
        ext.addCustomTest(function () {
            var fn_test = (function (a) {
                return a > 5;
            }).fn_or((function (a) {
                return a < 0;
            }));
            if (!fn_test(-50) || !fn_test(50) || fn_test(2))
                return 'failed';
        });
    },
});
function FunctionOR(orFunc) {
    var source = this;
    return function () {
        var result1 = source.apply(this, arguments);
        var result2 = orFunc.apply(this, arguments);
        return result1 || result2;
    };
}
singFunction.method('fn_if', FunctionIf, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    glyphIcon: '&#xe063;',
    tests: function (ext) {
        ext.addCustomTest(function () {
            var a = 0;
            var fn_test = (function () {
                a++;
            }).fn_if((function (a) {
                return a == 'GO';
            }));
            fn_test('NO');
            if (a != 0)
                return 'failed';
            fn_test('GO');
            fn_test('GO');
            fn_test('GO');
            if (a != 3)
                return 'failed';
        });
    },
});
function FunctionIf(ifFunc) {
    var srcThis = this;
    return function () {
        var items = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            items[_i - 0] = arguments[_i];
        }
        if (ifFunc.apply(this, items) == true) {
            return srcThis.apply(this, items);
        }
    };
}
singFunction.method('fn_unless', FunctionUnless, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    glyphIcon: '&#xe063;',
    tests: function (ext) {
        ext.addCustomTest(function () {
            var a = 0;
            var fn_test = (function () {
                a++;
            }).fn_unless((function (a) {
                return a == 'NO';
            }));
            fn_test('NO');
            if (a != 0)
                return 'failed';
            fn_test('GO');
            fn_test('GO');
            fn_test('GO');
            if (a != 3)
                return 'failed';
        });
    },
});
function FunctionUnless(ifFunc) {
    var srcThis = this;
    return function () {
        var items = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            items[_i - 0] = arguments[_i];
        }
        if (ifFunc.apply(this, items) != true) {
            return srcThis.apply(this, items);
        }
    };
}
singFunction.method('fn_then', FunctionThen, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    glyphIcon: '&#xe095;',
    tests: function (ext) {
    },
});
function FunctionThen(thenFunc) {
    var srcThis = this;
    return function () {
        var items = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            items[_i - 0] = arguments[_i];
        }
        var out = srcThis.apply(this, items);
        if ($.isDefined(out))
            items.push(out);
        var out2 = thenFunc.apply(this, items);
        if ($.isDefined(out2))
            return out2;
        return out;
    };
}
singFunction.method('fn_repeat', FunctionRepeat, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    glyphIcon: '&#xe115;',
    tests: function (ext) {
    },
});
function FunctionRepeat(repeatOver) {
    var srcThis = this;
    if ($.isFunction(repeatOver)) {
        return function () {
            var items = [];
            for (var _i = 0; _i < arguments.length; _i++) {
                items[_i - 0] = arguments[_i];
            }
            var out = [];
            var result = repeatOver.apply(this, items);
            while (result != null && result != undefined) {
                out.push(result);
                result = repeatOver.apply(this, items);
            }
            return out;
        };
    }
    if ($.isNumber(repeatOver)) {
        return function () {
            var items = [];
            for (var _i = 0; _i < arguments.length; _i++) {
                items[_i - 0] = arguments[_i];
            }
            return repeatOver.timesDo(srcThis);
        };
    }
    repeatOver = $.toArray(repeatOver);
    return function () {
        var items = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            items[_i - 0] = arguments[_i];
        }
        var out = [];
        for (var repeat in repeatOver) {
            var args = items;
            args.push(repeat);
            var result = srcThis.apply(this, items);
            if (result != null && result != undefined)
                out.push(result);
        }
        return out;
    };
}
singFunction.method('fn_while', FunctionWhile, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    glyphIcon: '&#xe030;',
    tests: function (ext) {
    },
});
function FunctionWhile(condition) {
    return function () {
        var items = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            items[_i - 0] = arguments[_i];
        }
        return this.fn_repeat(condition).apply(this, items);
    };
}
singFunction.method('fn_retry', FunctionRetry, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    glyphIcon: '&#xe031;',
    tests: function (ext) {
    },
});
function FunctionRetry(times) {
    if (times === void 0) { times = 1; }
    var srcThis = this;
    return function () {
        var items = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            items[_i - 0] = arguments[_i];
        }
        var exception = null;
        var attempts = 0;
        while (attempts < times) {
            try {
                var result = srcThis.apply(this, items);
                return result;
            }
            catch (ex) {
                exception = ex;
                attempts++;
            }
        }
        throw 'Failed ' + times + ' times with ' + exception;
    };
}
singFunction.method('fn_time', FunctionTime, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    glyphIcon: '&#x231b;',
    tests: function (ext) {
    },
});
function FunctionTime() {
    var srcThis = this;
    return function () {
        var items = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            items[_i - 0] = arguments[_i];
        }
        var start = new Date().valueOf();
        var result = srcThis.apply(this, items);
        var end = new Date().valueOf();
        var length = (end - start).max(0);
        log('Completed: ' + srcThis.name + ' in ' + length + ' milliseconds');
        return result;
    };
}
singFunction.method('fn_defer', FunctionDefer, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    glyphIcon: '&#xe234;',
    aliases: ['async'],
    tests: function (ext) {
    },
});
function FunctionDefer(callback) {
    var srcThis = this;
    return function () {
        var items = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            items[_i - 0] = arguments[_i];
        }
        setTimeout(function () {
            var result = srcThis.apply(this, items);
            if (callback)
                callback(result);
        }, 1);
    };
}
singFunction.method('fn_delay', FunctionDelay, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    glyphIcon: '&#xe234;',
    tests: function (ext) {
    },
});
function FunctionDelay(delayMS, callback) {
    var srcThis = this;
    delayMS = delayMS.max(1);
    return function () {
        var items = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            items[_i - 0] = arguments[_i];
        }
        setTimeout(function () {
            var result = srcThis.apply(this, items);
            if (callback)
                callback(result);
        }, delayMS);
    };
}
singFunction.method('fn_before', FunctionBefore, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    glyphIcon: '&#xe070;',
    tests: function (ext) {
    },
});
function FunctionBefore(triggerFunc) {
    var srcThis = this;
    return function () {
        var items = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            items[_i - 0] = arguments[_i];
        }
        triggerFunc.apply(this, items);
        var result = srcThis.apply(this, items);
        return result;
    };
}
singFunction.method('fn_after', FunctionAfter, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    glyphIcon: '&#xe076;',
    tests: function (ext) {
    },
});
function FunctionAfter(triggerFunc) {
    var srcThis = this;
    return function () {
        var items = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            items[_i - 0] = arguments[_i];
        }
        var result = srcThis.apply(this, items);
        items.push(result);
        triggerFunc.apply(this, items);
        return result;
    };
}
singFunction.method('fn_wrap', FunctionWrap, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    glyphIcon: '&#xe102;',
    tests: function (ext) {
    },
});
function FunctionWrap(triggerFunc) {
    var srcThis = this;
    return function () {
        var items = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            items[_i - 0] = arguments[_i];
        }
        triggerFunc.apply(this, items);
        var result = srcThis.apply(this, items);
        items.push(result);
        triggerFunc.apply(this, items);
        return result;
    };
}
singFunction.method('fn_trace', FunctionTrace, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    glyphIcon: '&#xe105;',
    tests: function (ext) {
    },
});
function FunctionTrace(traceStr) {
    var srcThis = this;
    return function () {
        var items = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            items[_i - 0] = arguments[_i];
        }
        if (traceStr != null && traceStr.length > 0)
            console.log(traceStr);
        console.trace();
        var result = srcThis.apply(this, items);
        return result;
    };
}
singFunction.method('fn_recurring', FunctionRecurring, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    glyphIcon: '&#xe031;',
    tests: function (ext) {
    },
});
function FunctionRecurring(intervalMS, breakCondition) {
    var srcThis = this;
    var minimum = 10;
    var runs = 0;
    intervalMS = intervalMS.max(minimum);
    var setTimer = function (src, items) {
        if ($.isNumber(breakCondition) && breakCondition > 0 && runs >= breakCondition)
            return;
        else if ($.isFunction(breakCondition) && breakCondition(items) == true)
            return;
        setTimeout(function () {
            setTimer(src, items);
        }, intervalMS);
        srcThis.apply(src, items);
        runs++;
    };
    return function () {
        var items = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            items[_i - 0] = arguments[_i];
        }
        var src = this;
        setTimer(src, items);
    };
}
singFunction.method('executeAll', ArrayExecuteAll, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    glyphIcon: '&#xe162;',
    tests: function (ext) {
    },
}, Array.prototype);
function ArrayExecuteAll() {
    var items = [];
    for (var _i = 0; _i < arguments.length; _i++) {
        items[_i - 0] = arguments[_i];
    }
    if (!items.every($.isFunction))
        throw 'Not all items were functions';
    var srcThis = this;
    var out = [];
    out = items.collect(function (item) {
        return item.apply(srcThis, items);
    });
    return out;
}
singFunction.method('fn_not', FunctionNot, {
    glyphIcon: '&#xe126;',
});
function FunctionNot() {
    var srcThis = this;
    return function () {
        var items = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            items[_i - 0] = arguments[_i];
        }
        var result = srcThis.apply(this, items);
        return !result;
    };
}
//# sourceMappingURL=singularity-js-function.js.map