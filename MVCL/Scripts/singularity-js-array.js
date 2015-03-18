/// <reference path="singularity-core.ts"/>
function InitSingularityJS_Array() {
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //
    // Array Extensions
    //
    //
    // Iteration Functions
    sing.addArrayExt('each', ArrayEach, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    function ArrayEach(action) {
        if (!this)
            return;
        this.while(function (item, i) {
            action(item, i);
            // each always continues until the end
            return true;
        });
    }
    //
    //////////////////////////////////////////////////////
    //
    sing.addArrayExt('while', ArrayWhile, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    function ArrayWhile(action) {
        if (!this || !action)
            return true;
        var exit = false;
        for (var i = 0; i < this.length; i++) {
            var result = action(this[i], i);
            if (result == false)
                exit = true;
            if (exit)
                break;
        }
        return !exit;
    }
    //
    //////////////////////////////////////////////////////
    //
    sing.addArrayExt('until', ArrayUntil, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    function ArrayUntil(action) {
        if (!this || !action)
            return true;
        return this.while(function (item, i) {
            var result = action(item, i);
            return (result !== null && result !== undefined && result !== false);
        });
    }
    //
    //////////////////////////////////////////////////////
    //
    // Lookup Functions
    sing.addArrayExt('count', ArrayCount, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    function ArrayCount(action) {
        if (!this || !action)
            return 0;
        var out = 0;
        this.each(function (item, i) {
            var result = action(item, i);
            if (result != null && result != undefined && result != false) {
                out++;
            }
        });
        return out;
    }
    //
    //////////////////////////////////////////////////////
    //
    sing.addArrayExt('contains', ArrayContains, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        aliases: ['has'],
        tests: function (ext) {
        },
    });
    function ArrayContains(itemOrItemsOrFunction) {
        if (!this || itemOrItemsOrFunction == null || itemOrItemsOrFunction == undefined)
            return false;
        if ($.isArray(itemOrItemsOrFunction)) {
            return itemOrItemsOrFunction.contains(function (it, i) {
                if (this.contains(it))
                    return true;
            });
        }
        if ($.isFunction(itemOrItemsOrFunction)) {
            return !!this.first(itemOrItemsOrFunction);
        }
        return this.indexOf(itemOrItemsOrFunction) >= 0;
    }
    //
    //////////////////////////////////////////////////////
    //
    sing.addArrayExt('select', ArraySelect, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        aliases: ['where'],
        tests: function (ext) {
        },
    });
    function ArraySelect(action) {
        if (!this || !action)
            return [];
        var out = [];
        this.each(function (item, i) {
            var result = action(item, i);
            if (result != null && result != undefined)
                out = out.concat(item);
        });
        return out;
    }
    //
    //////////////////////////////////////////////////////
    //
    sing.addArrayExt('every', ArrayEvery, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    function ArrayEvery(itemOrFunction) {
        if (!this || !itemOrFunction)
            return false;
        if ($.isFunction(itemOrFunction)) {
            return this.while(function (item, i) {
                var result = itemOrFunction(item, i);
                return (result != null && result != undefined && result != false);
            });
        }
        else {
            return this.length > 0 && this.count(itemOrFunction) == this.length;
        }
    }
    //
    //////////////////////////////////////////////////////
    //
    // Mapping Functions
    sing.addArrayExt('collect', ArrayCollect, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    function ArrayCollect(action) {
        if (!this)
            return [];
        if (action == null || action == undefined)
            action = sing.func.identity;
        var out = [];
        this.each(function (item, i) {
            var result = action(item, i);
            if (result !== null && result !== undefined)
                out = out.concat(result);
        });
        return out;
    }
    //
    //////////////////////////////////////////////////////
    //
    sing.addArrayExt('first', ArrayFirst, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    function ArrayFirst(itemOrAction) {
        if (!this)
            return;
        if (!itemOrAction && this.length > 0)
            return this[0];
        if (!itemOrAction)
            return;
        if (!$.isFunction(itemOrAction))
            itemOrAction = function (item, i) {
                return item == itemOrAction;
            };
        var out = undefined;
        this.while(function (item, i) {
            var result = itemOrAction(item, i);
            if (result == true) {
                out = result;
                return false;
            }
        });
        return out;
    }
    //
    //////////////////////////////////////////////////////
    //
    sing.addArrayExt('last', ArrayLast, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    function ArrayLast(action) {
        if (!this)
            return;
        if (!action && this.length > 0)
            return this[this.length - 1];
        if (!action)
            return;
        return this.reverse.first(action);
    }
    //
    //////////////////////////////////////////////////////
    //
    sing.addArrayExt('range', ArrayRange, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    function ArrayRange(start, end) {
        if (!this || start > end)
            return [];
        var out = [];
        for (var i = start; i < end; i++) {
            out = out.concat(this[i]);
        }
        return out;
    }
    //
    //////////////////////////////////////////////////////
    //
    sing.addArrayExt('flatten', ArrayFlatten, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    function ArrayFlatten() {
        if (!this)
            return [];
        var out = [];
        this.each(function (item, i) {
            if ($.isArray(item))
                out.concat(item.flatten());
            else
                out.concat(item);
        });
        return out;
    }
    //
    //////////////////////////////////////////////////////
    //
    sing.addArrayExt('indices', ArrayIndices, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        aliases: ['indexes'],
        tests: function (ext) {
            sing.addAssertTest(ext.name, ['a'].indices('a'), [0]);
            sing.addAssertTest(ext.name, ['a'].indices(['b']), []);
            sing.addAssertTest(ext.name, ['a'].indices(['']), []);
            sing.addAssertTest(ext.name, ['a'].indices([undefined]), []);
            sing.addAssertTest(ext.name, ['a'].indices([null]), []);
            sing.addAssertTest(ext.name, ['a'].indices(null), []);
            sing.addAssertTest(ext.name, ['a', 'b'].indices(['a', 'b']), [0, 1]);
            sing.addAssertTest(ext.name, ['a', 'a', 'a', 'b', 'b', 'b'].indices(['a', 'b']), [0, 1, 2, 3, 4, 5]);
        },
    });
    function ArrayIndices(itemOrItemsOrFunction) {
        if (!this || itemOrItemsOrFunction == null || itemOrItemsOrFunction == undefined)
            return [];
        var src = this;
        if ($.isArray(itemOrItemsOrFunction)) {
            return src.collect(function (item, i) {
                if (itemOrItemsOrFunction.contains(item))
                    return i;
            });
        }
        if ($.isFunction(itemOrItemsOrFunction)) {
            return src.collect(function (item, i) {
                if (!!itemOrItemsOrFunction(item, i))
                    return i;
            });
        }
        var index = src.indexOf(itemOrItemsOrFunction);
        if (index >= 0)
            return [index];
        else
            return [];
    }
    //
    //////////////////////////////////////////////////////
    //
    sing.addArrayExt('log', ArrayLog, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    function ArrayLog(itemOrItemsOrFunction) {
        log(this);
    }
    //
    //////////////////////////////////////////////////////
    //
    sing.addArrayExt('toStr', ArrayToStr, {
        summary: null,
        parameters: null,
        returns: null,
        returnType: String,
        examples: null,
        tests: function (ext) {
        },
    });
    function ArrayToStr(includeMarkup) {
        if (includeMarkup === void 0) { includeMarkup = false; }
        var out = includeMarkup ? '[' : '';
        var src = this;
        this.each(function (item, i) {
            if (item === null)
                out += 'null';
            else if (item === undefined)
                out += 'undefined';
            else if (item.toStr)
                out += item.toStr(includeMarkup); // includeMarkup is passed to child elements
            if (i < src.length - 1)
                out += includeMarkup ? ', ' : '\r\n';
        });
        out += includeMarkup ? ']' : '';
        return out;
    }
    //
    //////////////////////////////////////////////////////
    //
    sing.addArrayExt('remove', ArrayRemove, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    function ArrayRemove(itemOrItemsOrFunction) {
        var src = this;
        if (!itemOrItemsOrFunction)
            return src;
        if ($.isArray(itemOrItemsOrFunction)) {
            return src.select(function (item, i) {
                return !itemOrItemsOrFunction.contains(item);
            });
        }
        if ($.isFunction(itemOrItemsOrFunction)) {
            return src.select(itemOrItemsOrFunction.not());
        }
        return src.select(function (item, i) {
            return item == itemOrItemsOrFunction;
        });
    }
    //
    //////////////////////////////////////////////////////
    //
    sing.addArrayExt('splitAt', null, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    function SplitAt() {
        var indexes = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            indexes[_i - 0] = arguments[_i];
        }
        indexes.sort();
        var out = [];
        var section = [];
        var indexI = 0;
        for (var i = 0; i < this.length; i++) {
            if (indexes.length > indexI) {
                if (i < indexes[indexI])
                    section.push(this[i]);
                if (i == indexes[indexI]) {
                    out.push(section);
                    section = [];
                    indexI++;
                }
            }
        }
        return out;
    }
    sing.addArrayExt('sortBy', null, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        aliases: ['order'],
        tests: function (ext) {
        },
    });
    function ArraySortBy(arg) {
        if (arg == null) {
            arg = function (item) {
                if (item.numericValueOf)
                    return item.numericValueOf();
                else
                    return $.toStr(item).numericValueOf();
            };
        }
        var indexes = this.collect(arg);
        return [];
    }
    sing.addArrayExt('exfiltrate', null, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    sing.addArrayExt('removeAt', null, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    sing.addArrayExt('unique', null, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    sing.addArrayExt('random', null, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    sing.addArrayExt('shuffle', null, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    sing.addArrayExt('fill', null, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    sing.addArrayExt('index', null, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    sing.addArrayExt('group', null, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    //
}
//# sourceMappingURL=singularity-js-array.js.map