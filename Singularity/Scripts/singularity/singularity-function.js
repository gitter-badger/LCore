/// <reference path="singularity-core.ts"/>
var singFunction = singExt.addModule(new sing.Module('Function', Function));
singFunction.glyphIcon = '&#xe019;';
/////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Function Extensions
//
singFunction.method('fnTry', functionTry, {
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
            }).fnTry()();
        });
    }
});
function functionTry() {
    var source = this;
    // Redirects to catch with no catchFunction
    return source.fnCatch();
}
singFunction.method('fnCatch', functionCatch, {
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
            }).fnCatch(function (ex) {
                test = ex;
            })();
            if (test != 'fail')
                return 'failed';
        });
    }
});
function functionCatch(catchFunction, logFailure) {
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
        // ReSharper disable once UsageOfPossiblyUnassignedValue
        return result;
    };
}
singFunction.method('fnLog', functionLog, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    manuallyTested: true,
    glyphIcon: '&#xe105;'
});
function functionLog(logAttempt, logSuccess, logFailure) {
    if (logAttempt === void 0) { logAttempt = true; }
    if (logSuccess === void 0) { logSuccess = true; }
    if (logFailure === void 0) { logFailure = true; }
    var thisFunction = this;
    return function () {
        try {
            if (logAttempt) {
                log(['Attempting: ', thisFunction.name, arguments]);
            }
            var result = thisFunction.apply(this, arguments);
            if (logSuccess) {
                log([("Completed: " + thisFunction.name), arguments, result]);
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
singFunction.method('fnCount', functionCount, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    glyphIcon: '&#xe141;',
    examples: null
});
function functionCount(logFailure) {
    if (logFailure === void 0) { logFailure = false; }
    var source = this;
    var functionCallCount = 0;
    return function () {
        try {
            var result = source.apply(this, arguments);
            log([source.name, ("count:" + functionCallCount)]);
            log([arguments, result]);
            return result;
        }
        catch (ex) {
            if (logFailure) {
                log(['FAILED', source.name, ex, ("count:" + functionCallCount)]);
                log([arguments]);
            }
            throw ex;
        }
    };
}
singFunction.method('fnCache', functionCache, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    glyphIcon: '&#xe121;',
    manuallyTested: true
});
function functionCache(uniqueCacheID, expiresAfter) {
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
        var argStr = objectToStr(thisCaller) + "|||||||" + objectToStr(items);
        if (argStr.length > cacheKeyLimit) {
            return source.apply(thisCaller, items);
        }
        else {
            if (thisCache[argStr] != undefined &&
                thisCache[argStr] != null) {
                if (thisCache[argStr].expires < (new Date()).valueOf()) {
                    // Expired
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
singFunction.method('fnOr', functionOR, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    glyphIcon: '&#xe110;',
    tests: function (ext) {
        ext.addCustomTest(function () {
            var fnTest = (function (a) { return (a > 5); }).fnOR((function (a) { return (a < 0); }));
            if (!fnTest(-50) || !fnTest(50) || fnTest(2))
                return 'failed';
        });
    }
});
function functionOR(orFunc) {
    var source = this;
    return function () {
        var result1 = source.apply(this, arguments);
        var result2 = orFunc.apply(this, arguments);
        return result1 || result2;
    };
}
singFunction.method('fnIf', functionIf, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    glyphIcon: '&#xe063;',
    tests: function (ext) {
        ext.addCustomTest(function () {
            var a = 0;
            var fnTest = (function () {
                a++;
            }).fnIf((function (a) { return (a == 'GO'); }));
            fnTest('NO');
            if (a != 0)
                return 'failed';
            fnTest('GO');
            fnTest('GO');
            fnTest('GO');
            if (a != 3)
                return 'failed';
        });
    }
});
function functionIf(ifFunc) {
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
singFunction.method('fnUnless', functionUnless, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    glyphIcon: '&#xe063;',
    tests: function (ext) {
        ext.addCustomTest(function () {
            var a = 0;
            var fnTest = (function () {
                a++;
            }).fnUnless((function (a) { return (a == 'NO'); }));
            fnTest('NO');
            if (a != 0)
                return 'failed';
            fnTest('GO');
            fnTest('GO');
            fnTest('GO');
            if (a != 3)
                return 'failed';
        });
    }
});
function functionUnless(ifFunc) {
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
singFunction.method('fnThen', functionThen, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    glyphIcon: '&#xe095;',
    tests: function (ext) {
        /*
        ext.addCustomTest(function () {

            var test: any = 0;

            var fn_test = (function () {
                test++;
            }).fn_then((function () {
                test += 'test';
            }));

            fn_test();

            if (test != '1test')
                return 'failed';
        });

        ext.addCustomTest(function () {

            var test: any = 0;

            var fn_test = (function (test: any) {
                return ++test;
            }).fn_then((function (test: any) {
                test += 'test';
            }));

            fn_test(test);

            if (test != '1test')
                return 'failed';
        });
        */
    }
});
function functionThen(thenFunc) {
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
singFunction.method('fnRepeat', functionRepeat, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    glyphIcon: '&#xe115;',
    tests: function (ext) {
        /*
        ext.addCustomTest(function () {

            var test = 0;

            var test_fn = function () {
                test++;
            };
            test_fn = test_fn.fn_repeat(5);

            test_fn();

            if (test != 5)
                return 'failed';
        });
        ext.addCustomTest(function () {

            var test = [1, 2, 3, 4, 5];
            var test2 = '';

            var test_fn = function (a?: any) {
                test2 += a;
            };
            test_fn = test_fn.fn_repeat(test);

            test_fn();

            if (test2 != '12345')
                return 'failed';
        });
        */
    }
});
function functionRepeat(repeatOver) {
    var _this = this;
    var srcThis = this;
    if ($.isFunction(repeatOver)) {
        return function () {
            var items = [];
            for (var _i = 0; _i < arguments.length; _i++) {
                items[_i - 0] = arguments[_i];
            }
            var out = [];
            var result = repeatOver.apply(this, items);
            while (result != null) {
                out.push(result);
                result = repeatOver.apply(this, items);
            }
            return out;
        };
    }
    if ($.isNumber(repeatOver)) {
        return function () { return repeatOver.timesDo(_this); };
    }
    repeatOver = $.toArray(repeatOver);
    return function () {
        var items = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            items[_i - 0] = arguments[_i];
        }
        var out = [];
        var array = repeatOver;
        for (var repeat in array) {
            if ((array).hasOwnProperty(repeat)) {
                var args = items;
                args.push(repeat);
                var result = srcThis.apply(this, items);
                if (result != null)
                    out.push(result);
            }
        }
        return out;
    };
}
singFunction.method('fnWhile', functionWhile, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    glyphIcon: '&#xe030;',
    tests: function (ext) {
    }
});
function functionWhile(condition) {
    return function () {
        var items = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            items[_i - 0] = arguments[_i];
        }
        return this.fn_repeat(condition).apply(this, items);
    };
}
singFunction.method('fnRetry', functionRetry, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    glyphIcon: '&#xe031;',
    tests: function (ext) {
    }
});
function functionRetry(times) {
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
        throw "Failed " + times + " times with " + exception;
    };
}
singFunction.method('fnTime', functionTime, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    glyphIcon: '&#x231b;',
    tests: function (ext) {
    }
});
function functionTime() {
    var srcThis = this;
    return function () {
        var items = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            items[_i - 0] = arguments[_i];
        }
        var start = new Date().valueOf();
        srcThis.apply(this, items);
        var end = new Date().valueOf();
        var length = (end - start).max(0);
        log("Completed: " + srcThis.name + " in " + length + " milliseconds");
        return length;
    };
}
singFunction.method('fnDefer', functionDefer, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    glyphIcon: '&#xe234;',
    aliases: ['async'],
    tests: function (ext) {
    }
});
function functionDefer(callback) {
    var srcThis = this;
    return function () {
        var items = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            items[_i - 0] = arguments[_i];
        }
        setTimeout(function () {
            var result = srcThis.apply(srcThis, items);
            if (callback)
                callback(result);
        }, 1);
    };
}
singFunction.method('fnDelay', functionDelay, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    glyphIcon: '&#xe234;',
    tests: function (ext) {
    }
});
function functionDelay(delayMS, callback) {
    delayMS = delayMS.max(1);
    return function () {
        var items = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            items[_i - 0] = arguments[_i];
        }
        setTimeout(function () {
            var result = this.apply(this, items);
            if (callback)
                callback(result);
        }, delayMS);
    };
}
singFunction.method('fnBefore', functionBefore, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    glyphIcon: '&#xe070;',
    tests: function (ext) {
    }
});
function functionBefore(triggerFunc) {
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
singFunction.method('fnAfter', functionAfter, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    glyphIcon: '&#xe076;',
    tests: function (ext) {
    }
});
function functionAfter(triggerFunc) {
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
singFunction.method('fnWrap', functionWrap, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    glyphIcon: '&#xe102;',
    tests: function (ext) {
    }
});
function functionWrap(triggerFunc) {
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
singFunction.method('fnTrace', functionTrace, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    glyphIcon: '&#xe105;',
    tests: function (ext) {
    }
});
function functionTrace(traceStr) {
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
singFunction.method('fnRecurring', functionRecurring, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    glyphIcon: '&#xe031;',
    tests: function (ext) {
    }
});
function functionRecurring(intervalMS, breakCondition) {
    var srcThis = this;
    var minimum = 10;
    var runs = 0;
    intervalMS = intervalMS.max(minimum);
    var setTimer = function (src, items) {
        if ($.isNumber(breakCondition) && breakCondition > 0 && runs >= breakCondition)
            return;
        else if ($.isFunction(breakCondition) && breakCondition(items))
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
singFunction.method('executeAll', arrayExecuteAll, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: Function,
    examples: null,
    glyphIcon: '&#xe162;',
    tests: function (ext) {
    }
}, Array.prototype);
function arrayExecuteAll() {
    var _this = this;
    var items = [];
    for (var _i = 0; _i < arguments.length; _i++) {
        items[_i - 0] = arguments[_i];
    }
    if (!items.every($.isFunction))
        throw 'Not all items were functions';
    var out = items.collect(function (item) { return item.apply(_this, items); });
    return out;
}
singFunction.method('fnNot', functionNot, {
    glyphIcon: '&#xe126;'
});
function functionNot() {
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
/*
singFunction.method('fn_supply', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        tests: function (ext) {
        },
    });

singFunction.method('fn_ifElse', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        tests: function (ext) {
        },
    });
*/
//# sourceMappingURL=singularity-function.js.map