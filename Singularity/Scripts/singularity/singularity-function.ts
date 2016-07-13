/// <reference path="singularity-core.ts"/>

interface Function {
    fnTry?: <T>(logFailure?: boolean) => (...items: any[]) => T;

    fnCatch(catchFunction?: (ex: any) => void, logFailure?: boolean): Function;
    fnCatch<T>(catchFunction?: (ex: any) => void, logFailure?: boolean): (...items: any[]) => T;

    fnLog?: <T>(logAttempt?: boolean, logSuccess?: boolean, logFailure?: boolean) => (...items: any[]) => T;
    fnTime?: <T>() => (...items: any[]) => T;
    fnCount?: <T>(logFailure?: boolean) => (...items: any[]) => T;
    fnTrace?: <T>() => (...items: any[]) => T;

    fnCache<T>(uniqueCacheID: string, expiresAfter?: Date): (var1: T) => void;
    fnCache<T, U>(uniqueCacheID: string, expiresAfter?: Date): (var1: T) => U;
    fnCache<T, T2, U>(uniqueCacheID: string, expiresAfter?: Date): (var1: T, var2?: T2) => U;
    fnCache<T>(uniqueCacheID: string, expiresAfter?: Date): (...items: any[]) => T;

    fnIf?: (ifFunc: (...items: any[]) => boolean) => (...items: any[]) => any;
    fnUnless?: <T>(unlessFunc: (...items: any[]) => boolean) => (...items: any[]) => T;
    fnThen?: <T>(thenFunc: (...items: any[]) => any) => (...items: any[]) => T;

    fnRepeat<T>(times: number): (...items: any[]) => T;
    fnRepeat<T>(list: any[]): (...items: any[]) => T;
    fnRepeat<T>(repeatFn: (...items: any[]) => T): (...items: any[]) => T;

    fnWhile?: <T>(whileFunc: (...items: any[]) => boolean) => (...items: any[]) => T;
    fnUntil?: <T>(untilFunc: (...items: any[]) => boolean) => (...items: any[]) => T;
    fnRepeatEvery?: <T>(periodMS: number) => (...items: any[]) => T;
    fnRetry?: <T>(times: number) => (...items: any[]) => T;

    fnRecurring?: (intervalMs: number, breakCondition?: number | ((...items: any[]) => boolean)) => ((...items: any[]) => void);

    fnDefer?: <T>(callback?: (...items: any[]) => void) => () => T;
    fnDelay?: <T>(delayMs: number) => (...items: any[]) => T;
    fnAsync?: <T>(callback?: (...items: any[]) => void) => (...items: any[]) => T;
    fnWrap?: <T>(wrapper: (fn: (...items: any[]) => T, ...items: any[]) => T) => (...items: any[]) => T;
    fnOnExecute?: <T>(eventHandler: (...items: any[]) => void) => (...items: any[]) => T;
    fnOnExecuted?: <T>(eventHandler: (...items: any[]) => void) => (...items: any[]) => T;


    fnOR?: (orFunc: (...items: any[]) => boolean) => (...items: any[]) => boolean;
    fnAND?: (orFunc: (...items: any[]) => boolean) => (...items: any[]) => boolean;

    fnNot(): () => boolean;
    fnNot(): Function;

    // fn_ifElse
    // fn_supply?: <T, U>(parameter: U) => (param: U, ...items: any[]) => T;
}

var singFunction = singExt.addModule(new sing.Module('Function', Function));

singFunction.glyphIcon = '&#xe019;';


/////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Function Extensions
//

singFunction.method('fnTry', functionTry,
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
                }).fnTry()();
            });
        }
    });

function functionTry() {
    const source = this as Function;
    // Redirects to catch with no catchFunction
    return source.fnCatch();
}

singFunction.method('fnCatch', functionCatch,
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
                }).fnCatch(ex => {
                    test = ex;
                })();

                if (test != 'fail')
                    return 'failed';
            });
        }
    });

function functionCatch(catchFunction: Function, logFailure: boolean = false): Function {
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

singFunction.method('fnLog', functionLog,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        manuallyTested: true,
        glyphIcon: '&#xe105;'
    });

function functionLog(logAttempt: boolean = true, logSuccess: boolean = true, logFailure: boolean = true) {

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

singFunction.method('fnCount', functionCount,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        glyphIcon: '&#xe141;',
        examples: null
    });

function functionCount(logFailure: boolean = false) {
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

singFunction.method('fnCache', functionCache,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        glyphIcon: '&#xe121;',
        manuallyTested: true
    });

function functionCache(uniqueCacheID: string, expiresAfter: number = 0) {
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

        const argStr = `${objectToStr(thisCaller)}|||||||${objectToStr(items)}`;

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

singFunction.method('fnOr', functionOR,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: Function,
        examples: null,
        glyphIcon: '&#xe110;',
        tests(ext) {
            ext.addCustomTest(() => {

                var fnTest = ((a: number) => (a > 5)).fnOR(((a: number) => (a < 0)));

                if (!fnTest(-50) || !fnTest(50) || fnTest(2))
                    return 'failed';
            });
        }
    });

function functionOR(orFunc: (...items: any[]) => boolean): (...items: any[]) => boolean {

    var source = this;

    return function () {

        const result1 = source.apply(this, arguments);
        const result2 = orFunc.apply(this, arguments);

        return result1 || result2;
    };

}

singFunction.method('fnIf', functionIf,
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

                var fnTest = (() => {
                    a++;
                }).fnIf(((a: any) => (a == 'GO')));

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

function functionIf<T>(ifFunc: (...items: any[]) => boolean): (...items: any[]) => any {

    var srcThis = this;

    return function (...items: any[]): any {

        if (ifFunc.apply(this, items) == true) {
            return srcThis.apply(this, items);
        }
    };
}

singFunction.method('fnUnless', functionUnless,
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

                var fnTest = (() => {
                    a++;
                }).fnUnless(((a: any) => (a == 'NO')));

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

function functionUnless(ifFunc: (...items: any[]) => boolean): (...items: any[]) => any {

    var srcThis = this;

    return function (...items: any[]): any {

        if (ifFunc.apply(this, items) != true) {
            return srcThis.apply(this, items);
        }
    };
}

singFunction.method('fnThen', functionThen,
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

function functionThen(thenFunc: Function): Function {

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

singFunction.method('fnRepeat', functionRepeat,
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

function functionRepeat(repeatOver: number | any[] | ((...items: any[]) => boolean)): (...items: any[]) => any {

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

singFunction.method('fnWhile', functionWhile,
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

function functionWhile(condition: ((...items: any[]) => boolean)): (...items: any[]) => any {
    return function (...items: any[]) {
        return this.fn_repeat(condition).apply(this, items);
    };
}

singFunction.method('fnRetry', functionRetry,
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

function functionRetry(times: number = 1): (...items: any[]) => any {

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

singFunction.method('fnTime', functionTime,
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

function functionTime() {

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

singFunction.method('fnDefer', functionDefer,
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

function functionDefer(callback?: Function) {
    var srcThis = this;
    return (...items: any[]) => {
        setTimeout(() => {
            const result = srcThis.apply(srcThis, items);
            if (callback)
                callback(result);
        }, 1);
    };
}

singFunction.method('fnDelay', functionDelay,
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

function functionDelay(delayMS: number, callback?: Function) {
    delayMS = delayMS.max(1);

    return (...items: any[]) => {
        setTimeout(function () {
            const result = this.apply(this, items);
            if (callback)
                callback(result);
        }, delayMS);
    };
}

singFunction.method('fnBefore', functionBefore,
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

function functionBefore(triggerFunc?: Function) {

    var srcThis = this;

    return function (...items: any[]) {

        triggerFunc.apply(this, items);

        const result = srcThis.apply(this, items);

        return result;

    };
}

singFunction.method('fnAfter', functionAfter,
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

function functionAfter(triggerFunc?: Function) {

    var srcThis = this;

    return function (...items: any[]) {

        const result = srcThis.apply(this, items);

        items.push(result);

        triggerFunc.apply(this, items);

        return result;

    };
}

singFunction.method('fnWrap', functionWrap,
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

function functionWrap(triggerFunc?: Function) {

    var srcThis = this;

    return function (...items: any[]) {

        triggerFunc.apply(this, items);

        const result = srcThis.apply(this, items);

        items.push(result);

        triggerFunc.apply(this, items);

        return result;

    };
}

singFunction.method('fnTrace', functionTrace,
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

function functionTrace(traceStr?: string) {

    var srcThis = this;

    return function (...items: any[]) {

        if (traceStr != null && traceStr.length > 0)
            console.log(traceStr);

        console.trace();

        const result = srcThis.apply(this, items);

        return result;
    };
}

singFunction.method('fnRecurring', functionRecurring,
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

function functionRecurring(intervalMS: number, breakCondition?: number | ((...items: any[]) => boolean)) {

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

singFunction.method('executeAll', arrayExecuteAll,
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

function arrayExecuteAll(...items: Function[]): any[] {
    if (!items.every($.isFunction))
        throw 'Not all items were functions';
    const out = items.collect(item => item.apply(this, items));

    return out;
}

singFunction.method('fnNot', functionNot,
    {
        glyphIcon: '&#xe126;'
    });

function functionNot(): Function {

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

