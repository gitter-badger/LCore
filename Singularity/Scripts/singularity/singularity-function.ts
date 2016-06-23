/// <reference path="singularity-core.ts"/>

interface Function {
    fn_try?: <T>(logFailure?: boolean) => (...items: any[]) => T;

    fn_catch(catchFunction?: (ex: any) => void, logFailure?: boolean): Function;
    fn_catch<T>(catchFunction?: (ex: any) => void, logFailure?: boolean): (...items: any[]) => T;

    fn_log?: <T>(logAttempt?: boolean, logSuccess?: boolean, logFailure?: boolean) => (...items: any[]) => T;
    fn_time?: <T>() => (...items: any[]) => T;
    fn_count?: <T>(logFailure?: boolean) => (...items: any[]) => T;
    fn_trace?: <T>() => (...items: any[]) => T;

    fn_cache<T>(uniqueCacheID: string, expiresAfter?: Date): (var1: T) => void;
    fn_cache<T, U>(uniqueCacheID: string, expiresAfter?: Date): (var1: T) => U;
    fn_cache<T, T2, U>(uniqueCacheID: string, expiresAfter?: Date): (var1: T, var2?: T2) => U;
    fn_cache<T>(uniqueCacheID: string, expiresAfter?: Date): (...items: any[]) => T;

    fn_if?: (ifFunc: (...items: any[]) => boolean) => (...items: any[]) => any;
    fn_unless?: <T>(unlessFunc: (...items: any[]) => boolean) => (...items: any[]) => T;
    fn_then?: <T>(thenFunc: (...items: any[]) => any) => (...items: any[]) => T;

    fn_repeat<T>(times: number): (...items: any[]) => T;
    fn_repeat<T>(list: any[]): (...items: any[]) => T;
    fn_repeat<T>(repeat_fn: (...items: any[]) => T): (...items: any[]) => T;

    fn_while?: <T>(whileFunc: (...items: any[]) => boolean) => (...items: any[]) => T;
    fn_until?: <T>(untilFunc: (...items: any[]) => boolean) => (...items: any[]) => T;
    fn_repeatEvery?: <T>(periodMS: number) => (...items: any[]) => T;
    fn_retry?: <T>(times: number) => (...items: any[]) => T;

    fn_recurring?: (intervalMS: number, breakCondition?: number | ((...items: any[]) => boolean)) => ((...items: any[]) => void);

    fn_defer?: <T>(callback?: (...items: any[]) => void) => () => T;
    fn_delay?: <T>(delayMS: number) => (...items: any[]) => T;
    fn_async?: <T>(callback?: (...items: any[]) => void) => (...items: any[]) => T;
    fn_wrap?: <T>(wrapper: (fn: (...items: any[]) => T, ...items: any[]) => T) => (...items: any[]) => T;
    fn_onExecute?: <T>(eventHandler: (...items: any[]) => void) => (...items: any[]) => T;
    fn_onExecuted?: <T>(eventHandler: (...items: any[]) => void) => (...items: any[]) => T;


    fn_or?: (orFunc: (...items: any[]) => boolean) => (...items: any[]) => boolean;
    fn_and?: (orFunc: (...items: any[]) => boolean) => (...items: any[]) => boolean;

    fn_not(): () => boolean;
    fn_not(): Function;

    // fn_ifElse
    // fn_supply?: <T, U>(parameter: U) => (param: U, ...items: any[]) => T;
}

var singFunction = singExt.addModule(new sing.Module('Function', Function));

singFunction.glyphIcon = '&#xe019;';


/////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Function Extensions
//

singFunction.method('fn_try', FunctionTry,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        glyphIcon: '&#xe029;',
        tests(ext) {

            ext.addCustomTest(() => {
                (() => {
                    throw 'fail';
                }).fn_try()();
            });
        }
    });

function FunctionTry() {
    const source = this as Function;
    // Redirects to catch with no catchFunction
    return source.fn_catch();
}

singFunction.method('fn_catch', FunctionCatch,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        glyphIcon: '&#xe029;',
        tests(ext) {
            ext.addCustomTest(() => {

                var test = '';

                (() => {
                    throw 'fail';
                }).fn_catch(ex => {
                    test = ex;
                })();

                if (test != 'fail')
                    return 'failed';
            });
        }
    });

function FunctionCatch(catchFunction: Function, logFailure: boolean = false): Function {
    var source = this;

    return function () {
        var result: any;

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

singFunction.method('fn_log', FunctionLog,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        manuallyTested: true,
        glyphIcon: '&#xe105;'
    });

function FunctionLog(logAttempt: boolean = true, logSuccess: boolean = true, logFailure: boolean = true) {

    var thisFunction = this as Function;

    return function () {

        try {
            if (logAttempt) {
                log(['Attempting: ', thisFunction.name, arguments]);
            }

            const result = thisFunction.apply(this, arguments);

            if (logSuccess) {
                log([`Completed: ${thisFunction.name}`, arguments, result]);
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

singFunction.method('fn_count', FunctionCount,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        glyphIcon: '&#xe141;',
        examples: null
    });

function FunctionCount(logFailure: boolean = false) {
    var source = this;
    var functionCallCount = 0;

    return function () {
        try {
            const result = source.apply(this, arguments);

            log([source.name, `count:${functionCallCount}`]);
            log([arguments, result]);

            return result;
        }
        catch (ex) {
            if (logFailure) {
                log(['FAILED', source.name, ex, `count:${functionCallCount}`]);
                log([arguments]);
            }

            throw ex;
        }
    };
}

singFunction.method('fn_cache', FunctionCache,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        glyphIcon: '&#xe121;',
        manuallyTested: true
    });

function FunctionCache(uniqueCacheID: string, expiresAfter: number = 0) {
    var source = this;

    var cacheKeyLimit = 300;


    uniqueCacheID = uniqueCacheID || this.name;

    if (!uniqueCacheID)
        throw 'Unique ID not found';

    var ext = sing.methods['Singularity.Extensions.Function.fn_cache'];
    if (!ext.data)
        ext.data = {
        };

    if (!ext.data['cache'])
        ext.data['cache'] = {
        };

    return function (...items: any[]) {

        const thisCaller = this;

        const cache = ext.data['cache'];

        if (!cache[uniqueCacheID])
            cache[uniqueCacheID] = {};

        const thisCache = cache[uniqueCacheID];

        const argStr = `${ObjectToStr(thisCaller)}|||||||${ObjectToStr(items)}`;

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

            const result = thisCache[argStr].value = source.apply(thisCaller, items);

            if (expiresAfter > 0) {
                thisCache[argStr].expires = (new Date()).valueOf() + expiresAfter;
            }

            return result;
        }
    };
}

singFunction.method('fn_or', FunctionOR,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        glyphIcon: '&#xe110;',
        tests(ext) {
            ext.addCustomTest(() => {

                var fn_test = ((a: number) => (a > 5)).fn_or(((a: number) => (a < 0)));

                if (!fn_test(-50) || !fn_test(50) || fn_test(2))
                    return 'failed';
            });
        }
    });

function FunctionOR(orFunc: (...items: any[]) => boolean): (...items: any[]) => boolean {

    var source = this;

    return function () {

        const result1 = source.apply(this, arguments);
        const result2 = orFunc.apply(this, arguments);

        return result1 || result2;
    };

}

singFunction.method('fn_if', FunctionIf,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        glyphIcon: '&#xe063;',
        tests(ext) {
            ext.addCustomTest(() => {

                var a = 0;

                var fn_test = (() => {
                    a++;
                }).fn_if(((a: any) => (a == 'GO')));

                fn_test('NO');

                if (a != 0)
                    return 'failed';

                fn_test('GO');
                fn_test('GO');
                fn_test('GO');

                if (a != 3)
                    return 'failed';
            });
        }
    });

function FunctionIf<T>(ifFunc: (...items: any[]) => boolean): (...items: any[]) => any {

    var srcThis = this;

    return function (...items: any[]): any {

        if (ifFunc.apply(this, items) == true) {
            return srcThis.apply(this, items);
        }
    };
}

singFunction.method('fn_unless', FunctionUnless,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        glyphIcon: '&#xe063;',
        tests(ext) {
            ext.addCustomTest(() => {

                var a = 0;

                var fn_test = (() => {
                    a++;
                }).fn_unless(((a: any) => (a == 'NO')));

                fn_test('NO');

                if (a != 0)
                    return 'failed';

                fn_test('GO');
                fn_test('GO');
                fn_test('GO');

                if (a != 3)
                    return 'failed';
            });
        }
    });

function FunctionUnless(ifFunc: (...items: any[]) => boolean): (...items: any[]) => any {

    var srcThis = this;

    return function (...items: any[]): any {

        if (ifFunc.apply(this, items) != true) {
            return srcThis.apply(this, items);
        }
    };
}

singFunction.method('fn_then', FunctionThen,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        glyphIcon: '&#xe095;',
        tests(ext) {

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

function FunctionThen(thenFunc: Function): Function {

    var srcThis = this;

    return function (...items: any[]): any {

        const out = srcThis.apply(this, items);

        if ($.isDefined(out))
            items.push(out);

        const out2 = thenFunc.apply(this, items);

        if ($.isDefined(out2))
            return out2;

        return out;
    };
}

singFunction.method('fn_repeat', FunctionRepeat,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        glyphIcon: '&#xe115;',
        tests(ext) {
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

function FunctionRepeat(repeatOver: number | any[] | ((...items: any[]) => boolean)): (...items: any[]) => any {

    var srcThis = this;

    if ($.isFunction(repeatOver)) {
        return function (...items: any[]) {

            const out: any[] = [];

            var result = (repeatOver as (...items: any[]) => boolean).apply(this, items);

            while (result != null) {
                out.push(result);
                result = (repeatOver as (...items: any[]) => boolean).apply(this, items);
            }

            return out;
        };
    }

    if ($.isNumber(repeatOver)) {
        return () => (repeatOver as number).timesDo(this);
    }

    repeatOver = $.toArray(repeatOver);

    return function (...items: any[]) {

        const out: any[] = [];
        const array = repeatOver as any[];
        for (let repeat in array) {
            if ((array).hasOwnProperty(repeat)) {

                const args = items;
                args.push(repeat);

                const result = srcThis.apply(this, items);

                if (result != null)
                    out.push(result);

            }
        }

        return out;
    };

}

singFunction.method('fn_while', FunctionWhile,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        glyphIcon: '&#xe030;',
        tests(ext) {
        }
    });

function FunctionWhile(condition: ((...items: any[]) => boolean)): (...items: any[]) => any {
    return function (...items: any[]) {
        return this.fn_repeat(condition).apply(this, items);
    };
}

singFunction.method('fn_retry', FunctionRetry,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        glyphIcon: '&#xe031;',
        tests(ext) {
        }
    });

function FunctionRetry(times: number = 1): (...items: any[]) => any {

    var srcThis = this;

    return function (...items: any[]) {

        var exception: any = null;
        var attempts = 0;

        while (attempts < times) {
            try {
                const result = srcThis.apply(this, items);
                return result;
            } catch (ex) {
                exception = ex;
                attempts++;
            }
        }
        throw `Failed ${times} times with ${exception}`;
    };
}

singFunction.method('fn_time', FunctionTime,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        glyphIcon: '&#x231b;',
        tests(ext) {
        }
    });

function FunctionTime() {

    var srcThis = this;

    return function (...items: any[]) {

        const start = new Date().valueOf();

        srcThis.apply(this, items);

        const end = new Date().valueOf();

        const length = (end - start).max(0);

        log(`Completed: ${srcThis.name} in ${length} milliseconds`);

        return length;
    };
}

singFunction.method('fn_defer', FunctionDefer,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        glyphIcon: '&#xe234;',
        aliases: ['async'],
        tests(ext) {
        }
    });

function FunctionDefer(callback?: Function) {
    var srcThis = this;
    return (...items: any[]) => {
        setTimeout(() => {
            const result = srcThis.apply(srcThis, items);
            if (callback)
                callback(result);
        }, 1);
    };
}

singFunction.method('fn_delay', FunctionDelay,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        glyphIcon: '&#xe234;',
        tests(ext) {
        }
    });

function FunctionDelay(delayMS: number, callback?: Function) {
    delayMS = delayMS.max(1);

    return (...items: any[]) => {
        setTimeout(function () {
            const result = this.apply(this, items);
            if (callback)
                callback(result);
        }, delayMS);
    };
}

singFunction.method('fn_before', FunctionBefore,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        glyphIcon: '&#xe070;',
        tests(ext) {
        }
    });

function FunctionBefore(triggerFunc?: Function) {

    var srcThis = this;

    return function (...items: any[]) {

        triggerFunc.apply(this, items);

        const result = srcThis.apply(this, items);

        return result;

    };
}

singFunction.method('fn_after', FunctionAfter,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        glyphIcon: '&#xe076;',
        tests(ext) {
        }
    });

function FunctionAfter(triggerFunc?: Function) {

    var srcThis = this;

    return function (...items: any[]) {

        const result = srcThis.apply(this, items);

        items.push(result);

        triggerFunc.apply(this, items);

        return result;

    };
}

singFunction.method('fn_wrap', FunctionWrap,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        glyphIcon: '&#xe102;',
        tests(ext) {
        }
    });

function FunctionWrap(triggerFunc?: Function) {

    var srcThis = this;

    return function (...items: any[]) {

        triggerFunc.apply(this, items);

        const result = srcThis.apply(this, items);

        items.push(result);

        triggerFunc.apply(this, items);

        return result;

    };
}

singFunction.method('fn_trace', FunctionTrace,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        glyphIcon: '&#xe105;',
        tests(ext) {
        }
    });

function FunctionTrace(traceStr?: string) {

    var srcThis = this;

    return function (...items: any[]) {

        if (traceStr != null && traceStr.length > 0)
            console.log(traceStr);

        console.trace();

        const result = srcThis.apply(this, items);

        return result;
    };
}

singFunction.method('fn_recurring', FunctionRecurring,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        glyphIcon: '&#xe031;',
        tests(ext) {
        }
    });

function FunctionRecurring(intervalMS: number, breakCondition?: number | ((...items: any[]) => boolean)) {

    var srcThis = this as Function;

    const minimum = 10;

    var runs = 0;

    intervalMS = intervalMS.max(minimum);

    var setTimer = (src: Function, items: any[]) => {
        if ($.isNumber(breakCondition) && breakCondition > 0 && runs >= breakCondition)
            return;
        else if ($.isFunction(breakCondition) && (breakCondition as ((...items: any[]) => boolean))(items))
            return;

        setTimeout(() => {
            setTimer(src, items);
        }, intervalMS);

        srcThis.apply(src, items);

        runs++;
    };

    return function (...items: any[]) {

        const src = this;

        setTimer(src, items);
    };
}

singFunction.method('executeAll', ArrayExecuteAll,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        glyphIcon: '&#xe162;',
        tests(ext) {
        }
    }, Array.prototype);

function ArrayExecuteAll(...items: Function[]): any[] {
    if (!items.every($.isFunction))
        throw 'Not all items were functions';
    const out = items.collect(item => item.apply(this, items));

    return out;
}

singFunction.method('fn_not', FunctionNot,
    {
        glyphIcon: '&#xe126;'
    });

function FunctionNot(): Function {

    var srcThis = this;

    return function (...items: any[]) {

        const result = srcThis.apply(this, items);

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

