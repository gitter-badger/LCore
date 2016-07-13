/// <reference path="singularity-core.ts"/>
var singObject = singExt.addModule(new sing.Module("Object", $, $));
singObject.glyphIcon = '&#xe165;';
singObject.srcLink = '/Scripts/singularity/singularity-object.ts';
singObject.ignoreUnknown('ALL');
singObject.method('objEach', ObjectEach, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: '',
    examples: null,
    glyphIcon: '&#xe153;',
    tests: function (ext) {
        ext.addCustomTest(function () {
            var test = { a: 1, b: 2 };
            var test2 = [];
            $.objEach(test, function (key, item, index) {
                test2.push({ key: key, item: item, index: index });
            });
            if ($.toStr(test2) != $.toStr([{ key: 'a', item: 1, index: 0 }, { key: 'b', item: 2, index: 1 }]))
                return $.toStr(test2) + '\r\n' + $.toStr([{ key: 'a', item: 1, index: 0 }, { key: 'b', item: 2, index: 1 }]);
        }, 'Executes for every element');
    },
});
function ObjectEach(obj, eachFunc) {
    var keys = Object.keys(obj);
    keys.each(function (key, i) {
        eachFunc(key, obj[key], i);
    });
}
singObject.method('objProperties', ObjectProperties, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: '',
    examples: null,
    glyphIcon: '&#xe056;',
    tests: function (ext) {
        ext.addTest($, [null], []);
        ext.addTest($, [undefined], []);
        ext.addTest($, [['a']], [{ key: '0', value: 'a' }]);
        ext.addTest($, [5], []);
        ext.addTest($, [[]], []);
        ext.addTest($, [{}], []);
        ext.addTest($, [{ a: 1, b: 2 }], [{ key: 'a', value: 1 }, { key: 'b', value: 2 }]);
    },
});
function ObjectProperties(obj) {
    if (obj == null || !(typeof obj == 'object'))
        return [];
    var keys = Object.keys(obj);
    var values = keys.collect(function (item, i) {
        return { key: item, value: obj[item] };
    });
    return values;
}
singObject.method('objValues', ObjectValues, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    glyphIcon: '&#xe055;',
    tests: function (ext) {
        ext.addTest($, [null], []);
        ext.addTest($, [undefined], []);
        ext.addTest($, ['a'], []);
        ext.addTest($, ['a', 'b'], []);
        ext.addTest($, [5], []);
        ext.addTest($, [[]], []);
        ext.addTest($, [{}], []);
        ext.addTest($, [{ a: 1, b: 2 }], [1, 2]);
        ext.addTest($, [{ a: 'b', c: 'd' }, ['a']], 'b');
        ext.addTest($, [{ a: 'b', c: 'd' }, ['b']], null);
        ext.addTest($, [{ a: 'b', c: 'd' }, ['c']], 'd');
    },
});
function ObjectValues(obj, findKeys) {
    if (obj == null || !(typeof obj == 'object'))
        return null;
    if (findKeys != null && findKeys.length > 0) {
        if ($.isArray(obj)) {
            return obj.arrayValues.apply(obj, findKeys);
        }
        else {
            return [obj].arrayValues.apply([obj], findKeys);
        }
    }
    else {
        var keys = Object.keys(obj);
        var values = keys.collect(function (item, i) {
            return obj[item];
        });
        return values;
    }
}
singObject.method('arrayValues', ArrayFindValues, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    glyphIcon: '&#xe055;',
    tests: function (ext) {
        ext.addTest([], [null], []);
        ext.addTest([], [undefined], []);
        ext.addTest([1], [null], []);
        ext.addTest([1], [undefined], []);
        ext.addTest([{ a: 'b', c: 'd' }, { a: 'b2', c: 'd2' }], ['a'], ['b', 'b2']);
        ext.addTest([{ a: 'b', c: 'd' }, { a: 'b2', c: 'd2' }], ['b'], []);
        ext.addTest([{ a: 'b', c: 'd' }, { a: 'b2', c: 'd2' }], ['c'], ['d', 'd2']);
        ext.addTest([{ a: { name: 'a' }, b: { name: 'b' }, c: { name: 'c' } }, { a: { name: 'a2' }, b: { name: 'b2' }, c: { name: 'c2' } }], ['a.name'], ['a', 'a2']);
        ext.addTest([{ a: { name: 'a' }, b: { name: 'b' }, c: { name: 'c' } }, { a: { name: 'a2' }, b: { name: 'b2' }, c: { name: 'c2' } }], ['b.name'], ['b', 'b2']);
        ext.addTest([{ a: { name: 'a' }, b: { name: 'b' }, c: { name: 'c' } }, { a: { name: 'a2' }, b: { name: 'b2' }, c: { name: 'c2' } }], ['c.name'], ['c', 'c2']);
        ext.addTest([{ a: { name: 'a' }, b: { name: 'b' }, c: { name: 'c' } }, { a: { name: 'a2' }, b: { name: 'b2' }, c: { name: 'c2' } }], ['a', 'name'], ['a', 'a2']);
        ext.addTest([{ a: { name: 'a' }, b: { name: 'b' }, c: { name: 'c' } }, { a: { name: 'a2' }, b: { name: 'b2' }, c: { name: 'c2' } }], ['b', 'name'], ['b', 'b2']);
        ext.addTest([{ a: { name: 'a' }, b: { name: 'b' }, c: { name: 'c' } }, { a: { name: 'a2' }, b: { name: 'b2' }, c: { name: 'c2' } }], ['c', 'name'], ['c', 'c2']);
    },
}, Array.prototype);
function ArrayFindValues() {
    var names = [];
    for (var _i = 0; _i < arguments.length; _i++) {
        names[_i - 0] = arguments[_i];
    }
    var thisArray = this;
    if (!names || names.length == 0 || names[0] == null)
        return;
    if (names.length == 1 && names[0].contains('.')) {
        names = names[0].split('.');
    }
    if (names.length > 0) {
        var name = names.shift();
        var out = thisArray.collect(function (item) {
            if (!item || !item[name])
                return null;
            else
                return item[name];
        });
        if (names.length > 0) {
            return out.arrayValues.apply(out, names);
        }
        else {
            return out;
        }
    }
    return [];
}
singObject.method('objKeys', ObjectKeys, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    glyphIcon: 'icon-keys',
    tests: function (ext) {
        ext.addTest($, [null], []);
        ext.addTest($, [undefined], []);
        ext.addTest($, ['a'], []);
        ext.addTest($, ['a', 'b'], []);
        ext.addTest($, [5], []);
        ext.addTest($, [[]], []);
        ext.addTest($, [{}], []);
        ext.addTest($, [{ a: 1, b: 2 }], ['a', 'b']);
    },
}, $);
function ObjectKeys(obj) {
    if (obj == null || !(typeof obj == 'object'))
        return [];
    var keys = Object.keys(obj);
    return keys;
}
singObject.method('objHasKey', ObjectHasKey, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    glyphIcon: '&#xe003;',
    tests: function (ext) {
        ext.addTest(null, [], false);
        ext.addTest(null, [null, 'a'], false);
        ext.addTest(null, [{ b: 'a' }, 'a'], false);
        ext.addTest(null, [{ a: 'b' }, 'a'], true);
    },
});
function ObjectHasKey(obj, key) {
    if (!$.isDefined(obj))
        return false;
    return $.isDefined(obj[key]) || Object.keys(obj).has(key);
}
singObject.method('resolve', ObjectResolve, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    glyphIcon: '&#xe162;',
    tests: function (ext) {
        ext.addTest($, [5], 5);
        ext.addTest($, ['aa'], 'aa');
        ext.addTest($, [['aa', 'bb']], ['aa', 'bb']);
        ext.addTest($, [function () {
            return 5;
        }], 5);
        ext.addTest($, [function () {
            return 'aa';
        }], 'aa');
        ext.addTest($, [function () {
            return ['aa', 'bb'];
        }], ['aa', 'bb']);
    },
});
function ObjectResolve(obj, args) {
    if ($.isFunction(obj))
        return obj.apply(null, args);
    if ($.isArray(obj) && obj.length == 1)
        return obj[0];
    return obj;
}
singObject.method('isDefined', ObjectDefined, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    glyphIcon: '&#xe003;',
    tests: function (ext) {
        ext.addTest(null, [undefined], false);
        ext.addTest(null, [null], false);
        ext.addTest(null, [0], true);
        ext.addTest(null, ['a'], true);
        ext.addTest(null, [['a']], true);
        ext.addTest(null, [{}], true);
        ext.addTest(null, [{ name: 'a' }], true);
    },
});
function ObjectDefined(obj) {
    if (obj !== undefined && obj !== null)
        return true;
    return false;
}
singObject.method('isHash', ObjectIsHash, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    glyphIcon: 'icon-show-thumbnails',
    tests: function (ext) {
        ext.addTest(null, [undefined], false);
        ext.addTest(null, [null], false);
        ext.addTest(null, [0], false);
        ext.addTest(null, ['a'], false);
        ext.addTest(null, [['a']], false);
        ext.addTest(null, [{}], true);
        ext.addTest(null, [{ a: 'a' }], true);
    },
});
function ObjectIsHash(obj) {
    if (!$.isDefined(obj))
        return false;
    if ($.isArray(obj))
        return false;
    if (typeof obj == 'object')
        return true;
    return false;
}
singObject.method('clone', ArrayClone, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    glyphIcon: '&#xe224;',
    tests: function (ext) {
        ext.addTest([], [], []);
        ext.addTest([undefined], [], []);
        ext.addTest([[]], [], []);
        ext.addTest(['a'], [], ['a']);
        ext.addCustomTest(function () {
            var ary = [1, 2, 3];
            var ary2 = ary.clone();
            ary.push(4);
            if (ary2.length == 4)
                return 'Same array was returned';
        }, 'Arrays must be clones, not the source array');
    },
}, Array.prototype, "Array");
function ArrayClone(deepClone) {
    if (deepClone === void 0) { deepClone = false; }
    var thisArray = this;
    if (deepClone) {
        return thisArray.collect(function (item) {
            return $.clone(item, true);
        });
    }
    else {
        return thisArray.collect();
    }
}
singObject.method('clone', NumberClone, {
    glyphIcon: '&#xe224;',
    tests: function (ext) {
        ext.addTest(0, [], 0);
        ext.addTest(1, [], 1);
        ext.addTest(NaN, [], NaN);
        ext.addTest(Infinity, [], Infinity);
        ext.addTest(-Infinity, [], -Infinity);
        ext.addCustomTest(function () {
            var src = 1;
            var src2 = src.clone();
            src2 = 2;
            if (src == 2)
                return 'Same number was returned';
        }, 'Numbers must be clones, not the source number');
    },
}, Number.prototype, "Number");
function NumberClone() {
    return this.valueOf();
}
singObject.method('clone', BooleanClone, {
    glyphIcon: '&#xe224;',
    tests: function (ext) {
        ext.addTest(false, [], false);
        ext.addTest(true, [], true);
        ext.addCustomTest(function () {
            var src = false;
            var src2 = src.clone();
            src2 = true;
            if (src == true)
                return 'Same boolean was returned';
        }, 'Booleans must be clones, not the source boolean');
    },
}, Boolean.prototype, "Boolean");
function BooleanClone() {
    return this.valueOf();
}
singObject.method('clone', StringClone, {
    glyphIcon: '&#xe224;',
    tests: function (ext) {
        ext.addTest('', [], '');
        ext.addTest('a', [], 'a');
        ext.addCustomTest(function () {
            var src = 'a';
            var src2 = src.clone();
            src2 = 'b';
            if (src == 'b')
                return 'Same string was returned';
        }, 'Strings must be clones, not the source string');
    },
}, String.prototype, "String");
function StringClone() {
    return this.valueOf();
}
singObject.method('clone', DateClone, {
    glyphIcon: '&#xe224;',
    tests: function (ext) {
        var testDate = new Date();
        ext.addTest(testDate, [], testDate);
        ext.addCustomTest(function () {
            var src = new Date();
            var src2 = src.clone();
            src2.setMinutes(0);
            src2.setSeconds(0);
            src2.setMilliseconds(777);
            // This has 1/360,000 probability of failing
            // if (src.getMinutes() == 0 && src.getSeconds() == 0 && src.getMilliseconds() == 777)
            //    return 'Same date was returned';
            // This has 1/60 probability of failing
            if (src.getSeconds() == 0)
                return 'Same date was returned';
        }, 'Dates must be clones, not the source date');
    },
}, Date.prototype, "Date");
function DateClone() {
    return new Date(this.valueOf());
}
singObject.method('clone', ObjectClone, {
    glyphIcon: '&#xe224;',
    tests: function (ext) {
        ext.addTest($, [0], 0);
        ext.addTest($, [1], 1);
        ext.addTest($, [NaN], NaN);
        ext.addTest($, [Infinity], Infinity);
        ext.addTest($, [-Infinity], -Infinity);
        ext.addTest($, [false], false);
        ext.addTest($, [true], true);
        ext.addTest($, [''], '');
        ext.addTest($, ['a'], 'a');
        var testDate = new Date();
        ext.addTest($, [testDate], testDate);
        ext.addTest($, [{}], {});
        ext.addTest($, [[]], []);
        ext.addTest($, [[[]]], [[]]);
        ext.addTest($, [['a']], ['a']);
        ext.addTest($, [[['a']]], [['a']]);
    },
}, $, "jQuery");
function ObjectClone(obj, deepClone) {
    if (deepClone === void 0) { deepClone = false; }
    if (obj.clone !== ObjectClone && $.isFunction(obj.clone))
        return obj.clone(deepClone);
    var out = {};
    var key;
    if (deepClone) {
        for (key in $.objKeys(obj)) {
            out[key] = obj[key];
        }
    }
    else {
        for (key in $.objKeys(obj)) {
            out[key] = $.clone(obj[key]);
        }
    }
    return out;
}
singObject.method('isEmpty', ObjectIsEmpty, {
    glyphIcon: '&#xe118;',
    tests: function (ext) {
        ext.addTest($, [0], false);
        ext.addTest($, [1], false);
        ext.addTest($, [NaN], true);
        ext.addTest($, [Infinity], false);
        ext.addTest($, [-Infinity], false);
        ext.addTest($, [''], true);
        ext.addTest($, ['  '], true);
        ext.addTest($, ['a'], false);
        ext.addTest($, [null], true);
        ext.addTest($, [undefined], true);
        ext.addTest($, [], true);
        ext.addTest($, [[]], true);
        ext.addTest($, [{}], true);
        ext.addTest($, [[{}]], true);
        ext.addTest($, [[1]], false);
        ext.addTest($, [[[1]]], false);
        ext.addTest($, [[[], [1]]], false);
    },
}, $);
function ObjectIsEmpty(obj) {
    return (obj === undefined || obj === null || obj === '' || (typeof obj == 'number' && isNaN(obj)) || ($.isString(obj) && obj.trim().length == 0) || ($.isHash(obj) && $.objKeys(obj).length == 0)) || ($.isArray(obj) && (obj.length == 0 || !obj.has(function (item) {
        return !$.isEmpty(item);
    }))) || ($.isHash(obj) && !$.objValues(obj).has(function (item) {
        return !$.isEmpty(item);
    }));
}
singObject.method('typeName', ObjectTypeName, {
    glyphIcon: '&#xe041;',
    tests: function (ext) {
        ext.addTest($, [0], 'Number');
        ext.addTest($, [1], 'Number');
        ext.addTest($, [NaN], 'Number');
        ext.addTest($, [Infinity], 'Number');
        ext.addTest($, [-Infinity], 'Number');
        ext.addTest($, [''], 'String');
        ext.addTest($, ['a'], 'String');
        ext.addTest($, [true], 'Boolean');
        ext.addTest($, [false], 'Boolean');
        ext.addTest($, [null], 'Null');
        ext.addTest($, [undefined], 'Undefined');
        ext.addTest($, [[]], 'Array');
        ext.addTest($, [{}], 'Object');
        ext.addTest($, [sing], 'Singularity');
    },
}, $);
function ObjectTypeName(obj) {
    if (typeof obj === "undefined")
        return "Undefined";
    if (obj === null)
        return "Null";
    if (obj.__proto__ && obj.__proto__.constructor && obj.__proto__.constructor.name)
        return obj.__proto__.constructor.name;
    return Object.prototype.toString.call(obj).match(/^\[object\s(.*)\]$/)[1];
}
//# sourceMappingURL=singularity-object.js.map