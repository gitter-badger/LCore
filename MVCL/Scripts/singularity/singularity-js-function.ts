/// <reference path="singularity-core.ts"/>

interface Function {
    fn_try?: <T>(logFailure?: boolean) => (...items: any[]) => T;
    fn_catch?: <T>(catchFunction?: Function, logFailure?: boolean) => (...items: any[]) => T;

    fn_log?: <T>(logAttempt?: boolean, logSuccess?: boolean, logFailure?: boolean) => (...items: any[]) => T;
    fn_time?: <T>() => (...items: any[]) => T;
    fn_count?: <T>(logFailure?: boolean) => (...items: any[]) => T;
    fn_trace?: <T>() => (...items: any[]) => T;

    fn_cache?: <T>(uniqueCacheID: string, expiresAfter?: Date) => (...items: any[]) => T;

    fn_if?: <T>(ifFunc: (...items: any[]) => boolean) => (...items: any[]) => T;
    //fn_ifElse
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

    fn_supply?: <T, U>(parameter: U) => (param: U, ...items: any[]) => T;

    fn_or?: (orFunc: (...items: any[]) => boolean) => (...items: any[]) => boolean;
    fn_and?: (orFunc: (...items: any[]) => boolean) => (...items: any[]) => boolean;
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

//
//////////////////////////////////////////////////////
//

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
            result = source.apply(this.prototype, arguments);
        }
        catch (ex) {
            if (logFailure) {
                log(['FAILED', source.name, ex]);
                log([arguments]);
            }

            if (catchFunction)
                return catchFunction.apply(this.prototype, [ex].concat(arguments));
        }

        return result;
    };
}


//
//////////////////////////////////////////////////////
//

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

            var result = source.apply(this.prototype, arguments);

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

//
//////////////////////////////////////////////////////
//

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
            var result = source.apply(this.prototype, arguments);

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
//
//////////////////////////////////////////////////////
//

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

        var result = thisCache[argStr].value = source.apply(this.prototype, arguments);

        if (expiresAfter > 0) {
            thisCache[argStr].expires = (new Date()).valueOf() + expiresAfter;
        }

        return result;
    }
}

//
//////////////////////////////////////////////////////
//


singFunction.addExt('fn_trace', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        tests: function (ext) {
        },
    });

function FunctionTrace() {
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
singFunction.addExt('fn_if', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        tests: function (ext) {
        },
    });

singFunction.addExt('fn_unless', null,
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

singFunction.addExt('fn_then', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        tests: function (ext) {
        },
    });

singFunction.addExt('fn_repeat', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        tests: function (ext) {
        },
    });

singFunction.addExt('fn_while', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        tests: function (ext) {
        },
    });

singFunction.addExt('fn_repeatEvery', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        tests: function (ext) {
        },
    });

singFunction.addExt('fn_retry', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        tests: function (ext) {
        },
    });

singFunction.addExt('fn_time', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        tests: function (ext) {
        },
    });
singFunction.addExt('fn_defer', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        tests: function (ext) {
        },
    });
singFunction.addExt('fn_delay', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        tests: function (ext) {
        },
    });
singFunction.addExt('fn_async', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        tests: function (ext) {
        },
    });

singFunction.addExt('fn_wrap', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        tests: function (ext) {
        },
    });

singFunction.addExt('fn_onExecute', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        tests: function (ext) {
        },
    });
singFunction.addExt('fn_onExecuted', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        tests: function (ext) {
        },
    });

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
