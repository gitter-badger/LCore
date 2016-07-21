/// <reference path="singularity-core.ts"/>
/// <reference path="singularity-tests.ts"/>
var singArray = singExt.addModule(new sing.Module('Array', Array));
singArray.summaryShort = 'Extensions on the Array prototype';
singArray.summaryLong = 'Performs array manipulation functions on any type of Javascript Array.';
singArray.features = ['Shuffling arrays',
    'Random elements',
    'De-duplication',
    'Array indexing'];
singArray.glyphIcon = '&#xe236;';
//////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Array Extensions
//
//
//////////////////////////////////////////////////////
//
// Mapping Functions
//
singArray.method('splitAt', splitAt, {
    summary: 'Takes an array and splits it at the specified indexes.',
    parameters: [
        {
            name: 'indexes',
            description: 'The indexes to split the source Array.',
            isMulti: true,
            types: [Number],
            required: false
        }
    ],
    returns: 'A split group of arrays',
    returnType: Array,
    glyphIcon: '&#xe226;',
    tests: function (ext) {
        ext.addTest([], [], []);
        ext.addTest([], [null], []);
        ext.addTest([], [undefined], []);
        ext.addTest([], [0], []);
        ext.addTest([1], [0], [[1]]);
        ext.addTest([1, 2], [0], [[1, 2]]);
        ext.addTest([1, 2], [1], [[1], [2]]);
        ext.addTest([1, 2, 3, 4, 5, 6], [1, 3], [[1], [2, 3], [4, 5, 6]]);
    }
});
function splitAt() {
    var indexes = [];
    for (var _i = 0; _i < arguments.length; _i++) {
        indexes[_i - 0] = arguments[_i];
    }
    indexes = indexes.unique();
    indexes.sort();
    var thisArray = this;
    var out = [];
    var section = [];
    var indexI = 0;
    for (var i = 0; i < thisArray.length; i++) {
        if (indexes.length >= indexI) {
            if (i == indexes[indexI]) {
                if (section.length > 0)
                    out.push(section);
                section = [];
                indexI++;
            }
            section.push(thisArray[i]);
        }
    }
    if (!$.isEmpty(section))
        out.push(section);
    return out;
}
singArray.method('removeAt', arrayRemoveAt, {
    summary: 'Takes an array and returns a new array with the passed indexes removed.',
    parameters: [
        {
            name: 'indexes',
            description: 'The indexes to remove from the source Array.',
            isMulti: true,
            types: [Number],
            required: false
        }
    ],
    returns: 'An array with the passed indexes removed',
    returnType: Array,
    glyphIcon: '&#xe163;',
    tests: function (ext) {
        ext.addTest([], [], []);
        ext.addTest([], [null], []);
        ext.addTest([], [undefined], []);
        ext.addTest([], [0], []);
        ext.addTest([1], [0], []);
        ext.addTest([1, 2], [0], [2]);
        ext.addTest([1, 2], [1], [1]);
        ext.addTest([1, 2], [0, 1], []);
        ext.addTest([1, 2, 3, 4, 5, 6], [0, 1], [3, 4, 5, 6]);
        ext.addTest([1, 2, 3, 4, 5, 6], [0, 5], [2, 3, 4, 5]);
    }
});
function arrayRemoveAt() {
    var indexes = [];
    for (var _i = 0; _i < arguments.length; _i++) {
        indexes[_i - 0] = arguments[_i];
    }
    var thisArray = this;
    return thisArray.select(function (item, index) { return (!indexes.has(index)); });
}
singArray.method('unique', arrayUnique, {
    summary: 'Takes an array and returns only unique values, discarding duplicates.',
    parameters: [],
    returns: 'An array with unique values.',
    returnType: Array,
    glyphIcon: 'icon-snowflake',
    aliases: ['removeDuplicates'],
    tests: function (ext) {
        ext.addTest([], [], []);
        ext.addTest([null, undefined], [], []);
        ext.addTest([1, 2, 3], [], [1, 2, 3]);
        ext.addTest([1, 2, 3, 1, 2, 3], [], [1, 2, 3]);
        ext.addTest([1, 2, 3, 'a', 'b', 'c', 1, 2, 3, 'a', 'b', 'c'], [], [1, 2, 3, 'a', 'b', 'c']);
    }
});
function arrayUnique() {
    var thisArray = this;
    var out = [];
    thisArray.each(function (item) {
        if (!out.has(item) && $.isDefined(item))
            out.push(item);
    });
    return out;
}
singArray.method('random', arrayRandom, {
    summary: 'Takes an array and returns one or more random values from the source array.',
    parameters: [
        {
            name: 'count',
            defaultValue: 1,
            types: [Number]
        }
    ],
    returns: 'A single item if no count is supplied or count is 1. Otherwise an array of items is returned.',
    returnType: Object,
    glyphIcon: 'icon-playing-dices',
    tests: function (ext) {
        ext.addCustomTest(function () {
            var test = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20];
            var test2 = test.random();
            var test3 = test.random(5);
            if (!test.has(test2))
                return 'failed';
            if (test3.has(function (a) { return (!test.has(a)); }))
                return 'failed';
        });
    }
});
function arrayRandom(count) {
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
singArray.method('shuffle', arrayShuffle, {
    summary: 'Takes an array and returns a new array with the original array values, shuffled.',
    parameters: [],
    returns: 'A new array with the original array values, shuffled',
    returnType: Array,
    glyphIcon: '&#xe110;',
    tests: function (ext) {
        ext.addCustomTest(function () {
            var test = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20];
            var test2 = test.shuffle();
            if (test == test2 || test2.length != test.length)
                return 'failed';
            if (test2.has(function (a) { return (!test.has(a)); }))
                return 'failed';
        });
    }
});
function arrayShuffle() {
    var thisArray = this;
    var out = [];
    while (thisArray.length > 0) {
        var rand = $.random(0, thisArray.length).floor();
        out.push(thisArray[rand]);
        thisArray = thisArray.remove(thisArray[rand]);
    }
    return out;
}
singArray.method('group', arrayGroup, {
    summary: 'Takes an array and groups the items using the key returned from the indexing function',
    returns: 'A Javascript hash object grouped by the indexing function.',
    returnType: Object,
    parameters: [
        {
            name: 'indexFunc',
            types: [Function]
        }
    ],
    glyphIcon: '&#xe032;',
    tests: function (ext) {
        ext.addTest([], [], []);
        ext.addTest([], [null], []);
        ext.addTest([1, 2, 3], [function () { }], { '': [1, 2, 3] });
        ext.addTest([1, 2, 3], [function (a) { return ("group" + a); }], { group1: [1], group2: [2], group3: [3] });
        ext.addTest([1, 2, 2, 3], [function (a) { return ("group" + a); }], { group1: [1], group2: [2, 2], group3: [3] });
    }
});
function arrayGroup(indexFunc) {
    var thisArray = this;
    var out = {};
    thisArray.each(function (item, index) {
        var key = indexFunc(item, index);
        key = key || '';
        if ($.isArray(out[key]))
            out[key].push(item);
        else
            out[key] = [item];
    });
    return out;
}
singArray.method('toArray', objToArray, {
    summary: 'Takes an object of any kind and returns it as an array. If no object is passed an empty array will be returned. \
            If an array is passed, it will be returned.',
    parameters: [
        {
            name: 'obj',
            types: [Object]
        }
    ],
    validateInput: false,
    returns: 'An array',
    returnType: Array,
    glyphIcon: '&#xe055;',
    tests: function (ext) {
        ext.addTest(null, [], []);
        ext.addTest(null, [null], []);
        ext.addTest(null, [undefined], []);
        ext.addTest(null, [0], [0]);
        ext.addTest(null, [[0, 1, 2]], [0, 1, 2]);
    }
}, $);
function objToArray(obj) {
    if (!$.isDefined(obj))
        return [];
    if ($.isArray(obj))
        return obj;
    else
        return [obj];
}
//# sourceMappingURL=singularity-array.js.map