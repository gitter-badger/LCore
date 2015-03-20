/// <reference path="singularity-core.ts"/>

interface Function {
    fn_try?: <T>(logFailure?: boolean) => (...items: any[]) => T;
    fn_catch?: <T>(catchFunction?: Function, logFailure?: boolean) => (...items: any[]) => T;

    fn_log?: <T>(logAttempt?: boolean, logSuccess?: boolean, logFailure?: boolean) => (...items: any[]) => T;
    fn_time?: <T>() => (...items: any[]) => T;
    fn_count?: <T>(logFailure?: boolean) => (...items: any[]) => T;
    fn_trace?: <T>() => (...items: any[]) => T;

    fn_cache?: <T>(uniqueCacheID: string, expiresAfter?: Date) => (...items: any[]) => T;

    fn_if?: (ifFunc: (...items: any[]) => boolean) => (...items: any[]) => any;
    fn_unless?: <T>(unlessFunc: (...items: any[]) => boolean) => (...items: any[]) => T;
    fn_then?: <T>(thenFunc: (...items: any[]) => any) => (...items: any[]) => T;
    fn_repeat?: <T>(times: number) => (...items: any[]) => T;
    fn_while?: <T>(whileFunc: (...items: any[]) => boolean) => (...items: any[]) => T;
    fn_until?: <T>(untilFunc: (...items: any[]) => boolean) => (...items: any[]) => T;
    fn_repeatEvery?: <T>(periodMS: number) => (...items: any[]) => T;
    fn_retry?: <T>(times: number) => (...items: any[]) => T;

    fn_defer?: <T>() => () => T;
    fn_delay?: <T>(delayMS: number) => (...items: any[]) => T;
    fn_async?: <T>(callback: (...items: any[]) => void) => (...items: any[]) => T;
    fn_wrap?: <T>(wrapper: (fn: (...items: any[]) => T, ...items: any[]) => T) => (...items: any[]) => T;
    fn_onExecute?: <T>(eventHandler: (...items: any[]) => void) => (...items: any[]) => T;
    fn_onExecuted?: <T>(eventHandler: (...items: any[]) => void) => (...items: any[]) => T;


    fn_or?: (orFunc: (...items: any[]) => boolean) => (...items: any[]) => boolean;
    fn_and?: (orFunc: (...items: any[]) => boolean) => (...items: any[]) => boolean;

    // fn_ifElse
    // fn_supply?: <T, U>(parameter: U) => (param: U, ...items: any[]) => T;
}

var singFunction = sing.addModule(new sing.Module("Function", Function));

singFunction.requiredDocumentation = false;

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Function Extensions
//

singFunction.addExt('fn_try', FunctionTry,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        tests: function (ext) {
        },
    });

function FunctionTry(logFailure) {
    var source = this;
    // Redirects to catch with no catchFunction
    return source.fn_catch();
}

singFunction.addExt('fn_catch', FunctionCatch,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        tests: function (ext) {
        },
    });

function FunctionCatch(catchFunction, logFailure) {
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

singFunction.addExt('fn_log', FunctionLog,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        tests: function (ext) {
        },
    });

function FunctionLog(logAttempt, logSuccess, logFailure) {
    logAttempt = logAttempt != false ? true : false;
    logSuccess = logSuccess != false ? true : false;
    logFailure = logFailure != false ? true : false;

    var source = this;

    return function () {

        try {
            if (logAttempt) {
                log(['Attempting: ', source.name, arguments, result]);
            }

            var result = source.apply(this, arguments);

            if (logSuccess) {
                log(['Completed: ' + source.name, arguments, result]);
            }

            return result;
        }
        catch (ex) {
            if (logFailure) {
                log(['FAILED', source.name, ex]);
                log([arguments]);
            }

            throw ex;

        }
    };
}

singFunction.addExt('fn_count', FunctionCount,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        tests: function (ext) {
        },
    });

function FunctionCount(logFailure) {
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
    }
}

singFunction.addExt('fn_cache', FunctionCache,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        tests: function (ext) {
        },
    });

function FunctionCache(uniqueCacheID, expiresAfter) {
    var source = this;

    uniqueCacheID = uniqueCacheID || this.name;

    if (!uniqueCacheID)
        throw 'Unique ID not found'

    var ext = sing.extensions['Function.fn_cache'];
    if (!ext.data)
        ext.data = {
        };

    if (!ext.data['cache'])
        ext.data['cache'] = {
        };

    return function () {

        var cache = sing.extensions['Function.fn_cache'].data['cache'];

        if (!cache[uniqueCacheID])
            cache[uniqueCacheID] = {};

        var thisCache = cache[uniqueCacheID];

        var argStr = $.toStr($.objValues(arguments));

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

        var result = thisCache[argStr].value = source.apply(this, arguments);

        if (expiresAfter > 0) {
            thisCache[argStr].expires = (new Date()).valueOf() + expiresAfter;
        }

        return result;
    }
}

singFunction.addExt('fn_or', FunctionOR,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        tests: function (ext) {
        },
    });

function FunctionOR(orFunc: (...items: any[]) => boolean): (...items: any[]) => boolean {

    var source = this;

    return function () {

        var result1 = source.apply(this, arguments);
        var result2 = orFunc.apply(this, arguments);

        return result1 || result2;
    }

}

singFunction.addExt('fn_if', FunctionIf,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        tests: function (ext) {
        },
    });

function FunctionIf<T>(ifFunc: (...items: any[]) => boolean): (...items: any[]) => any {

    var srcThis = this;

    return function (...items: any[]): any {

        if (ifFunc.apply(this, items) == true) {
            return srcThis.apply(this, items);
        }
    };
}

singFunction.addExt('fn_unless', FunctionUnless,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        tests: function (ext) {
        },
    });

function FunctionUnless(ifFunc: (...items: any[]) => boolean): (...items: any[]) => any {

    var srcThis = this;

    return function (...items: any[]): any {

        if (ifFunc.apply(this, items) != true) {
            return srcThis.apply(this, items);
        }
    };
}

singFunction.addExt('fn_then', FunctionThen,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        tests: function (ext) {
        },
    });

function FunctionThen(ifFunc: (...items: any[]) => boolean): (...items: any[]) => any {

    var srcThis = this;

    return function (...items: any[]): any {

        if (ifFunc.apply(this, items) != true) {
            return srcThis.apply(this, items);
        }
    };
}

singFunction.addExt('fn_repeat', FunctionRepeat,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        tests: function (ext) {
        },
    });

function FunctionRepeat(repeatOver: number | any[]| ((...items: any[]) => boolean)): (...items: any[]) => any {

    var srcThis = this;

    if ($.isFunction(repeatOver)) {
        return function (...items: any[]) {

            var out = [];

            var result = (<(...items: any[]) => boolean>repeatOver).apply(this, items);

            while (result != null && result != undefined) {
                out.push(result);
                result = (<(...items: any[]) => boolean>repeatOver).apply(this, items);
            }

            return out;
        };
    }

    if ($.isNumber(repeatOver)) {
        return function (...items: any[]) {
            return (<number>repeatOver).timesDo(srcThis);
        };
    }

    repeatOver = $.toArray(repeatOver);

    return function (...items: any[]) {

        var out = [];

        for (var repeat in <any[]>repeatOver) {

            var args = items;
            args.push(repeat);

            var result = srcThis.apply(this, items);

            if (result != null &&
                result != undefined)
                out.push(result);

        }

        return out;
    };

}

singFunction.addExt('fn_while', FunctionWhile,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        tests: function (ext) {
        },
    });

function FunctionWhile(condition: ((...items: any[]) => boolean)): (...items: any[]) => any {
    return function (...items: any[]) {
        return this.fn_repeat(condition).apply(this, items);
    }
}

singFunction.addExt('fn_retry', FunctionRetry,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        tests: function (ext) {
        },
    });

function FunctionRetry(times: number = 1): (...items: any[]) => any {

    var srcThis = this;

    return function (...items: any[]) {

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
    }
}

singFunction.addExt('fn_time', FunctionTime,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        tests: function (ext) {
        },
    });

function FunctionTime() {

    var srcThis = this;

    return function (...items: any[]) {

        var start = new Date().valueOf();

        var result = srcThis.apply(this, items);

        var end = new Date().valueOf();

        var length = (end - start).max(0);

        log('Completed: ' + srcThis.name + ' in ' + length + ' milliseconds');

        return result;
    };
}

singFunction.addExt('fn_defer', FunctionDefer,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        aliases: ['async'],
        tests: function (ext) {
        },
    });

function FunctionDefer(callback?: Function) {

    var srcThis = this;

    return function (...items: any[]) {
        setTimeout(function () {
            var result = srcThis.apply(this, items);
            if (callback)
                callback(result)
        }, 1);
    };
}

singFunction.addExt('fn_delay', FunctionDelay,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        tests: function (ext) {
        },
    });

function FunctionDelay(delayMS, number, callback?: Function) {

    var srcThis = this;

    delayMS = delayMS.max(1);

    return function (...items: any[]) {
        setTimeout(function () {
            var result = srcThis.apply(this, items);
            if (callback)
                callback(result)
        }, delayMS);
    };
}

singFunction.addExt('fn_before', FunctionBefore,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        tests: function (ext) {
        },
    });

function FunctionBefore(triggerFunc?: Function) {

    var srcThis = this;

    return function (...items: any[]) {

        triggerFunc.apply(this, items);

        var result = srcThis.apply(this, items);

        return result;

    }
}

singFunction.addExt('fn_after', FunctionAfter,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        tests: function (ext) {
        },
    });

function FunctionAfter(triggerFunc?: Function) {

    var srcThis = this;

    return function (...items: any[]) {

        var result = srcThis.apply(this, items);

        items.push(result);

        triggerFunc.apply(this, items);

        return result;

    }
}

singFunction.addExt('fn_wrap', FunctionWrap,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        tests: function (ext) {
        },
    });

function FunctionWrap(triggerFunc?: Function) {

    var srcThis = this;

    return function (...items: any[]) {

        triggerFunc.apply(this, items);

        var result = srcThis.apply(this, items);

        items.push(result);

        triggerFunc.apply(this, items);

        return result;

    }
}

singFunction.addExt('fn_trace', FunctionTrace,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        tests: function (ext) {
        },
    });

function FunctionTrace(traceStr?: string) {

    var srcThis = this;

    return function (...items: any[]) {

        if (traceStr != null && traceStr.length > 0)
            console.log(traceStr);

        console.trace();

        var result = srcThis.apply(this, items);

        return result;
    }
}

singFunction.addExt('fn_recurring', FunctionRecurring,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        tests: function (ext) {
        },
    });

function FunctionRecurring(intervalMS: number) {

    var srcThis = this;

    var minimum = 100;

    intervalMS = intervalMS.max(minimum);

    var setTimer = function (src, items) {
        setTimeout(function () {
            setTimer(src, items);
        }, intervalMS);
        srcThis.apply(src, items);
    }

    return function (...items: any[]) {

        var src = this;

        setTimer(src, items);
    };
}

singFunction.addExt('executeAll', ArrayExecuteAll,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        tests: function (ext) {
        },
    }, Array.prototype);

function ArrayExecuteAll(...items: Function[]): any[] {
    if (!items.every($.isFunction))
        throw 'Not all items were functions';

    var srcThis = this;

    var out = [];

    out = items.collect(function (item) {
        return item.apply(srcThis, items);
    });

    return out;
}

/*
singFunction.addExt('fn_supply', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        tests: function (ext) {
        },
    });

singFunction.addExt('fn_ifElse', null,
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

