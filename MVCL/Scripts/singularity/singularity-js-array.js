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
    },
});
function ArrayUnique() {
    var indexes = [];
    for (var _i = 0; _i < arguments.length; _i++) {
        indexes[_i - 0] = arguments[_i];
    }
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
singArray.method('group', ArrayGroup, {});
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