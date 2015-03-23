var singObject = singModule.addModule(new sing.Module("Object", $, $));
singObject.method('objEach', ObjectEach, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: '',
    examples: null,
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
    tests: function (ext) {
        ext.addTest(undefined, [null], []);
        ext.addTest(undefined, [undefined], []);
        ext.addTest(undefined, ['a'], [{ 0: { key: '0', value: 'a' } }]);
        ext.addTest(undefined, [5], []);
        ext.addTest(undefined, [[]], []);
        ext.addTest(undefined, [{}], []);
        ext.addTest(undefined, [{ a: 1, b: 2 }], [{ key: 'a', value: 1 }, { key: 'b', value: 2 }]);
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
    tests: function (ext) {
        ext.addTest(undefined, [null], []);
        ext.addTest(undefined, [undefined], []);
        ext.addTest(undefined, ['a'], []);
        ext.addTest(undefined, ['a', 'b'], []);
        ext.addTest(undefined, [5], []);
        ext.addTest(undefined, [[]], []);
        ext.addTest(undefined, [{}], []);
        ext.addTest(undefined, [{ a: 1, b: 2 }], [1, 2]);
        ext.addTest(undefined, [{ a: 'b', c: 'd' }, ['a']], 'b');
        ext.addTest(undefined, [{ a: 'b', c: 'd' }, ['b']], null);
        ext.addTest(undefined, [{ a: 'b', c: 'd' }, ['c']], 'd');
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
    if (!names || names.length == 0 || names[0] == null)
        return;
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
    tests: function (ext) {
        ext.addTest(undefined, [null], []);
        ext.addTest(undefined, [undefined], []);
        ext.addTest(undefined, ['a'], []);
        ext.addTest(undefined, ['a', 'b'], []);
        ext.addTest(undefined, [5], []);
        ext.addTest(undefined, [[]], []);
        ext.addTest(undefined, [{}], []);
        ext.addTest(undefined, [{ a: 1, b: 2 }], ['a', 'b']);
    },
});
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
    tests: function (ext) {
        ext.addTest(null, [], false);
        ext.addTest(null, [null, 'a'], false);
        ext.addTest(null, [{ b: 'a' }, 'a'], false);
        ext.addTest(null, [{ a: 'b' }, 'a'], true);
    },
});
function ObjectHasKey(obj, key) {
    if (obj == null || !(typeof obj == 'object'))
        return false;
    var keys = Object.keys(obj);
    return keys.contains(key);
}
singObject.method('resolve', ObjectResolve, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    tests: function (ext) {
        ext.addTest(undefined, [5], 5);
        ext.addTest(undefined, ['aa'], 'aa');
        ext.addTest(undefined, [['aa', 'bb']], ['aa', 'bb']);
        ext.addTest(undefined, [function () {
            return 5;
        }], 5);
        ext.addTest(undefined, [function () {
            return 'aa';
        }], 'aa');
        ext.addTest(undefined, [function () {
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
function ArrayClone() {
    return this.collect();
}
singObject.method('clone', NumberClone, {}, Number.prototype, "Number");
function NumberClone() {
    return this.valueOf();
}
singObject.method('clone', NumberClone, {}, Boolean.prototype, "Boolean");
function BooleanClone() {
    return this.valueOf();
}
singObject.method('clone', StringClone, {}, String.prototype, "String");
function StringClone() {
    return this.valueOf();
}
singObject.method('clone', DateClone, {}, Date.prototype, "Date");
function DateClone() {
    return this.valueOf();
}
singObject.method('clone', ObjectClone, {}, $, "jQuery");
function ObjectClone() {
    if (this.clone !== ObjectClone && $.isFunction(this.clone))
        return this.clone();
    // can't clone
    return this;
}
singObject.method('isEmpty', ObjectIsEmpty, {}, $);
function ObjectIsEmpty(obj) {
    return (obj === undefined || obj === null || obj === 0 || obj === '' || ($.isArray(obj) && obj.length == 0) || ($.isString(obj) && obj.trim().length == 0));
}
//# sourceMappingURL=singularity-object.js.map