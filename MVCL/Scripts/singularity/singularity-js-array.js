/// <reference path="singularity-core.ts"/>
/// <reference path="singularity-tests.ts"/>
var singArray = singExt.addModule(new sing.Module("Array", Array));
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Array Extensions
//
//
//////////////////////////////////////////////////////
//
// Mapping Functions
//
singArray.method('splitAt', SplitAt, {
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
    var thisArray = this;
    var out = [];
    var section = [];
    var indexI = 0;
    for (var i = 0; i < thisArray.length; i++) {
        if (indexes.length > indexI) {
            if (i < indexes[indexI])
                section.push(thisArray[i]);
            if (i == indexes[indexI]) {
                out.push(section);
                section = [];
                indexI++;
            }
        }
    }
    return out;
}
singArray.method('removeAt', ArrayRemoveAt, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    },
});
function ArrayRemoveAt() {
    var indexes = [];
    for (var _i = 0; _i < arguments.length; _i++) {
        indexes[_i - 0] = arguments[_i];
    }
    var thisArray = this;
    return thisArray.select(function (item, index) {
        return !indexes.has(index);
    });
}
singArray.method('unique', ArrayUnique, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    aliases: ['removeDuplicates'],
    tests: function (ext) {
        ext.addTest([], [], []);
        ext.addTest([null, undefined], [], []);
        ext.addTest([1, 2, 3], [], [1, 2, 3]);
        ext.addTest([1, 2, 3, 1, 2, 3], [], [1, 2, 3]);
        ext.addTest([1, 2, 3, 'a', 'b', 'c', 1, 2, 3, 'a', 'b', 'c'], [], [1, 2, 3, 'a', 'b', 'c']);
    },
});
function ArrayUnique() {
    var thisArray = this;
    var out = [];
    thisArray.each(function (item, index) {
        if (!out.has(item))
            out.push(item);
    });
    return out;
}
singArray.method('random', ArrayRandom, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
        ext.addCustomTest(function () {
            var test = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20];
            var test2 = test.random();
            var test3 = test.random(5);
            if (!test.has(test2))
                return 'failed';
            if (test3.has(function (a) {
                return !test.has(a);
            }))
                return 'failed';
        });
    },
});
function ArrayRandom(count) {
    if (count === void 0) { count = 1; }
    var thisArray = this;
    var out = [];
    // Don't return more random items than we have;
    count = count.min(thisArray.length);
    if (count == thisArray.length)
        return thisArray.shuffle();
    thisArray = thisArray.shuffle();
    while (out.length < count) {
        out.push((thisArray).shift());
    }
    return out;
}
singArray.method('shuffle', ArrayShuffle, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
        ext.addCustomTest(function () {
            var test = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20];
            var test2 = test.shuffle();
            if (test == test2 || test2.length != test.length)
                return 'failed';
            if (test2.has(function (a) {
                return !test.has(a);
            }))
                return 'failed';
        });
    },
});
function ArrayShuffle() {
    var thisArray = this;
    var out = [];
    while (thisArray.length > 0) {
        var rand = $.random(0, thisArray.length).floor();
        out.push(thisArray[rand]);
        thisArray = thisArray.remove(thisArray[rand]);
    }
    return out;
}
singArray.method('group', ArrayGroup, {
    tests: function (ext) {
        ext.addTest([], [], []);
        ext.addTest([], [null], []);
        ext.addTest([1, 2, 3], [function (a) {
        }], { '': [1, 2, 3] });
        ext.addTest([1, 2, 3], [function (a) {
            return 'group' + a;
        }], { group1: [1], group2: [2], group3: [3] });
        ext.addTest([1, 2, 2, 3], [function (a) {
            return 'group' + a;
        }], { group1: [1], group2: [2, 2], group3: [3] });
    },
});
function ArrayGroup(keyFunc) {
    var thisArray = this;
    var out = {};
    thisArray.each(function (item, index) {
        var key = keyFunc(item, index);
        if (key && key.length > 0) {
            if ($.isArray(out[key]))
                out[key].push(item);
            else
                out[key] = [item];
        }
    });
    return out;
}
singArray.method('toArray', ObjToArray, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    tests: function (ext) {
        ext.addTest(null, [], []);
        ext.addTest(null, [null], []);
        ext.addTest(null, [undefined], []);
        ext.addTest(null, [0], [0]);
        ext.addTest(null, [[0, 1, 2]], [0, 1, 2]);
    },
}, $);
function ObjToArray(obj) {
    if (!$.isDefined(obj))
        return [];
    if ($.isArray(obj))
        return obj;
    else
        return [obj];
}
/*
singEnumerable.method('fill', null,
    {
        summary: null,
        parameters: null,
        returns: '',
        returnType: null,
        examples: null,
        tests: function (ext) {
        },
    });

*/
//# sourceMappingURL=singularity-js-array.js.map