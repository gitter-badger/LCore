var singObject = sing.addModule(new sing.Module("Object", $, $));
singObject.requiredDocumentation = false;
singObject.addExt('objEach', ObjectEach, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: '',
    examples: null,
    tests: function (ext) {
        ext.addCustomTest(undefined, function () {
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
singObject.addExt('objProperties', ObjectProperties, {
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
singObject.addExt('objValues', ObjectValues, {
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
    },
});
function ObjectValues(obj, findKeys) {
    if (obj == null || !(typeof obj == 'object'))
        return [];
    if (findKeys != null && findKeys.length > 0) {
        if ($.isArray(obj)) {
            return obj.arrayValues.apply(obj, findKeys);
        }
        else {
            return [obj].arrayValues.apply(obj, findKeys);
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
singObject.addExt('arrayValues', ArrayFindValues, {
    summary: null,
    parameters: null,
    returns: '',
    returnType: null,
    examples: null,
    tests: function (ext) {
    },
}, Array.prototype);
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
singObject.addExt('objKeys', ObjectKeys, {
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
singObject.addExt('objHasKey', ObjectHasKey, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    tests: function (ext) {
    },
});
function ObjectHasKey(obj, key) {
    if (obj == null || !(typeof obj == 'object'))
        return false;
    var keys = Object.keys(obj);
    return keys.contains(key);
}
singObject.addExt('resolve', ObjectResolve, {
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
singObject.addExt('isDefined', ObjectDefined, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    tests: function (ext) {
    },
});
function ObjectDefined(obj) {
    if (obj === undefined)
        return true;
    return false;
}
singObject.addExt('isHash', ObjectIsHash, {
    summary: null,
    parameters: null,
    validateInput: false,
    returns: '',
    returnType: '',
    examples: null,
    tests: function (ext) {
    },
});
function ObjectIsHash(obj) {
    if (!$.isDefined(obj))
        return false;
    if (typeof obj == 'object')
        return true;
    return false;
}
//# sourceMappingURL=singularity-object.js.map