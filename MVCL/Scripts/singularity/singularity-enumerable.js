/// <reference path="singularity-core.ts"/>
var singEnumerable = sing.addModule(new sing.Module("Singularity.Enumerable", Array));
singEnumerable.requiredDocumentation = false;
//////////////////////////////////////////////////////
//
// Iteration Functions
//
singEnumerable.addExt('each', EnumerableEach, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    },
});
function EnumerableEach(action) {
    if (!this)
        return;
    this.while(function (item, i) {
        action(item, i);
        // each always continues until the end
        return true;
    });
}
singEnumerable.addExt('while', EnumerableWhile, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    },
});
function EnumerableWhile(action) {
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
singEnumerable.addExt('until', EnumerableUntil, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    },
});
function EnumerableUntil(action) {
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
singEnumerable.addExt('count', EnumerableCount, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    },
});
function EnumerableCount(action) {
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
singEnumerable.addExt('contains', EnumerableContains, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    aliases: ['has'],
    tests: function (ext) {
    },
});
function EnumerableContains(itemOrItemsOrFunction) {
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
singEnumerable.addExt('select', EnumerableSelect, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    aliases: ['where'],
    tests: function (ext) {
    },
});
function EnumerableSelect(action) {
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
singEnumerable.addExt('every', EnumerableEvery, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    },
});
function EnumerableEvery(itemOrFunction) {
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
singEnumerable.addExt('collect', EnumerableCollect, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    },
});
function EnumerableCollect(action) {
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
singEnumerable.addExt('first', EnumerableFirst, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    },
});
function EnumerableFirst(itemOrAction) {
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
singEnumerable.addExt('last', EnumerableLast, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    },
});
function EnumerableLast(action) {
    if (!this)
        return;
    if (!action && this.length > 0)
        return this[this.length - 1];
    if (!action)
        return;
    return this.reverse.first(action);
}
singEnumerable.addExt('range', EnumerableRange, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    },
});
function EnumerableRange(start, end) {
    if (!this || start > end)
        return [];
    var out = [];
    for (var i = start; i < end; i++) {
        out = out.concat(this[i]);
    }
    return out;
}
singEnumerable.addExt('flatten', EnumerableFlatten, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    },
});
function EnumerableFlatten() {
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
singEnumerable.addExt('indices', EnumerableIndices, {
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
function EnumerableIndices(itemOrItemsOrFunction) {
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
singEnumerable.addExt('remove', EnumerableRemove, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    },
});
function EnumerableRemove(itemOrItemsOrFunction) {
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
singEnumerable.addExt('splitAt', null, {
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
singEnumerable.addExt('sortBy', EnumerableSortBy, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    aliases: ['order'],
    tests: function (ext) {
    },
});
function EnumerableSortBy(arg) {
    var defaultValueFunc = function (item) {
        if (item && item.numericValueOf)
            return item.numericValueOf();
        else
            return $.toStr(item).numericValueOf();
    };
    if (arg == null) {
        arg = defaultValueFunc;
    }
    var indexes = this;
    if ($.isString(arg) && arg.contains('.')) {
        arg = arg.split('.');
    }
    if ($.isString(arg)) {
        indexes = indexes.collect(function (item) {
            return $.objHasKey(item, arg) && item != null ? defaultValueFunc(item[arg]) : -1;
        });
    }
    else if ($.isArray(arg)) {
        for (var i = 0; i < arg.length; i++) {
            indexes = indexes.collect(function (item) {
                if (!$.objHasKey(item, arg[i])) {
                    return -1;
                }
                return item[arg[i]] == null ? -1 : item[arg[i]];
            });
        }
    }
    else {
        indexes = indexes.collect(arg);
    }
    if (!indexes.every($.isNumeric.fn_or($.isString))) {
        indexes = indexes.collect($.toStr).collect(sing.extensions['String.numericValueOf'].method);
    }
    var items = this;
    var out = indexes.quickSort(undefined, undefined, [items]);
    return out[1];
}
singEnumerable.addExt('quickSort', EnumerableQuickSort, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    },
});
function EnumerableQuickSort(left, right, sortWith) {
    if (left === void 0) { left = 0; }
    if (right === void 0) { right = (this.length - 1); }
    var items = this;
    if (sortWith && left == 0 && right == this.length - 1) {
        for (var i = 0; i < sortWith.length; i++) {
            if (sortWith[i] && sortWith[i].length != items.length) {
                console.log(this, sortWith);
                throw 'Lengths did not match ' + items.length + ', ' + sortWith[i].length;
            }
        }
    }
    var index;
    if (items.length > 1) {
        var partitionResult = EnumerableQuickSortPartition(items, left, right, sortWith);
        var index = partitionResult.index;
        items = partitionResult.items;
        sortWith = partitionResult.sortWith;
        if (left < index - 1) {
            if (sortWith != null) {
                var sorted = items.quickSort(left, index - 1, sortWith);
                items = sorted[0];
                for (var i = 1; i < sorted.length; i++) {
                    sortWith[i - 1] = sorted[i];
                }
            }
            else {
                items = items.quickSort(left, index - 1);
            }
        }
        if (index < right) {
            if (sortWith != null) {
                var sorted = items.quickSort(index, right, sortWith);
                items = sorted[0];
                for (var i = 1; i < sorted.length; i++) {
                    sortWith[i - 1] = sorted[i];
                }
            }
            else {
                items = items.quickSort(index, right);
            }
        }
    }
    if (sortWith != null) {
        var out = [];
        out.push(items);
        out = out.concat(sortWith);
        return out;
    }
    else {
        return items;
    }
}
function EnumerableQuickSortPartition(items, left, right, sortWith) {
    var pivot = items[Math.floor((right + left) / 2)], i = left, j = right;
    while (i <= j) {
        while (items[i] < pivot) {
            i++;
        }
        while (items[j] > pivot) {
            j--;
        }
        if (i <= j) {
            var swapResult = EnumerableQuickSortSwap(items, i, j, sortWith);
            items = swapResult.items;
            sortWith = swapResult.sortWith;
            i++;
            j--;
        }
    }
    return {
        items: items,
        sortWith: sortWith,
        index: i,
    };
}
function EnumerableQuickSortSwap(items, firstIndex, secondIndex, sortWith) {
    var temp = items[firstIndex];
    items[firstIndex] = items[secondIndex];
    items[secondIndex] = temp;
    if (sortWith != null) {
        for (var i = 0; i < sortWith.length; i++) {
            temp = sortWith[i][firstIndex];
            sortWith[i][firstIndex] = sortWith[i][secondIndex];
            sortWith[i][secondIndex] = temp;
        }
    }
    return {
        items: items,
        sortWith: sortWith,
    };
}
singEnumerable.addExt('timesDo', EnumerableTimesDo, {
    summary: "Repeats a function a number of times",
    parameters: [
        {
            name: 'executeFunc',
            types: [Function],
            desription: 'The function to execute',
            required: true,
        },
        {
            name: 'args',
            types: [Array],
            defaultValue: [],
            desription: '',
        },
        {
            name: 'caller',
            types: [Object],
            desription: '',
        },
    ],
    returns: 'An array of objects collected from the return values of executeFunc\'s executions.',
    returnType: Object,
    examples: ['\
            (5).timesDo(function() { alert(\'hi\'); });'],
    tests: function (ext) {
        /* TODO: FIX timesDo is causing a stack overflow

        ext.addCustomTest(function () {
            var test = 0;
            (5).timesDo(function () { test++; });

            if (test != 5)
                return false;
        }, 'Must execute the function the correct number of times.');
        
        ext.addTest(1, [null], undefined, 'Passing a null function does nothing.');
        ext.addTest(1, [undefined], undefined, 'Passing an undefined function does nothing.');

        */
        ext.addTest(5, [sing.func.increment, [5]], [6, 6, 6, 6, 6]);
    },
}, Number.prototype);
function EnumerableTimesDo(executeFunc, args, caller) {
    if (!this || this <= 0 || !executeFunc)
        return;
    caller = caller || this;
    var out = [];
    for (var i = 0; i < this; i++) {
        if (!this)
            return;
        var result = executeFunc.apply(caller, args);
        if (result != null && result != undefined)
            out.push(result);
    }
    return out;
}
singEnumerable.addExt('removeAt', null, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    },
});
singEnumerable.addExt('unique', null, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    },
});
singEnumerable.addExt('random', null, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    },
});
singEnumerable.addExt('shuffle', null, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    },
});
singEnumerable.addExt('fill', null, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    },
});
singEnumerable.addExt('index', null, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    },
});
singEnumerable.addExt('group', null, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    },
});
//# sourceMappingURL=singularity-enumerable.js.map