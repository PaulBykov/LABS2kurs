var __spreadArray = (this && this.__spreadArray) || function (to, from, pack) {
    if (pack || arguments.length === 2) for (var i = 0, l = from.length, ar; i < l; i++) {
        if (ar || !(i in from)) {
            if (!ar) ar = Array.prototype.slice.call(from, 0, i);
            ar[i] = from[i];
        }
    }
    return to.concat(ar || Array.prototype.slice.call(from));
};
function createPhoneNumber(numbers) {
    return "(" + numbers[0] + numbers[1] + numbers[2] + ") " +
        numbers[3] + numbers[4] + numbers[5] + "-" +
        numbers[6] + numbers[7] + numbers[8] + numbers[9];
}
var Challenge = /** @class */ (function () {
    function Challenge() {
    }
    Challenge.solution = function (number) {
        var sum = 0;
        for (var i = 0; i < number; i++) {
            if (i % 3 == 0 || i % 5 == 0) {
                sum += i;
            }
        }
        return sum;
    };
    return Challenge;
}());
function moveRight(arr, k) {
    var arr1 = __spreadArray([], arr, true);
    for (var i = 0; i < arr1.length; i++) {
        arr1[i] = arr[(arr.length - k + i) % arr.length];
    }
    return arr1;
}
function middleArr(arr1, arr2) {
    var arr3 = __spreadArray(__spreadArray([], arr1, true), arr2, true);
    var mid = arr3.length / 2;
    if (Math.floor(mid) == Math.ceil(mid)) {
        return (arr3[mid] + arr3[mid - 1]) / 2;
    }
    else {
        return arr3[Math.floor(mid)];
    }
}
