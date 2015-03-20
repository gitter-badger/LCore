/// <reference path="singularity-core.ts"/>
/// <reference path="singularity-tests.ts"/>
var singArray = sing.addModule(new sing.Module("Array", Array));
singArray.requiredDocumentation = false;
singArray.requiredUnitTests = false;
function InitSingularityJS_Array() {
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //
    // Array Extensions
    //
    //
    // Iteration Functions
    //
    singArray.addExt('each', ArrayEach, {
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
    singArray.addExt('while', ArrayWhile, {
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
    singArray.addExt('until', ArrayUntil, {
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
    singArray.addExt('count', ArrayCount, {
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
    singArray.addExt('contains', ArrayContains, {
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
    singArray.addExt('select', ArraySelect, {
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
    singArray.addExt('every', ArrayEvery, {
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
    //
    singArray.addExt('collect', ArrayCollect, {
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
    singArray.addExt('first', ArrayFirst, {
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
    singArray.addExt('last', ArrayLast, {
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
    singArray.addExt('range', ArrayRange, {
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
    singArray.addExt('flatten', ArrayFlatten, {
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
    singArray.addExt('indices', ArrayIndices, {
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
    singArray.addExt('log', ArrayLog, {
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
    singArray.addExt('toStr', ArrayToStr, {
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
    singArray.addExt('remove', ArrayRemove, {
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
    singArray.addExt('splitAt', null, {
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
    singArray.addExt('sortBy', ArraySortBy, {
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
    singArray.addExt('quickSort', ArrayQuickSort, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    function ArrayQuickSort(left, right, sortWith) {
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
            var partitionResult = ArrayQuickSortPartition(items, left, right, sortWith);
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
    function ArrayQuickSortPartition(items, left, right, sortWith) {
        var pivot = items[Math.floor((right + left) / 2)], i = left, j = right;
        while (i <= j) {
            while (items[i] < pivot) {
                i++;
            }
            while (items[j] > pivot) {
                j--;
            }
            if (i <= j) {
                var swapResult = ArrayQuickSortSwap(items, i, j, sortWith);
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
    function ArrayQuickSortSwap(items, firstIndex, secondIndex, sortWith) {
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
    singArray.addExt('findValues', ArrayFindValues, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    function ArrayFindValues() {
        var names = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            names[_i - 0] = arguments[_i];
        }
        if (names.length == 1 && names[0].contains('.')) {
            names = names[0].split('.');
        }
        if (names.length > 0) {
            var name = names.shift();
            var out = this.collect(function (item) {
                if (!item || !item[name])
                    return null;
                else
                    return item[name];
            });
            if (names.length > 0) {
                return out.findValues.apply(out, names);
            }
            else {
                return out;
            }
        }
        return [];
    }
    singArray.addExt('removeAt', null, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    singArray.addExt('unique', null, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    singArray.addExt('random', null, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    singArray.addExt('shuffle', null, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    singArray.addExt('fill', null, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    singArray.addExt('index', null, {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });
    singArray.addExt('group', null, {
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