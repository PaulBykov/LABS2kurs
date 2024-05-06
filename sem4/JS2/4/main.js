var iter;
(function (iter) {
    var ProductIterator = /** @class */ (function () {
        function ProductIterator(products) {
            this.currentCategory = 0;
            this.currentSubCategory = 0;
            this.currentObject = 0;
            this.products = products;
        }
        ProductIterator.prototype.next = function () {
            while (this.currentCategory < Object.keys(this.products).length) {
                var category = this.products[Object.keys(this.products)[this.currentCategory]];
                var subcategory = category[Object.keys(category)[this.currentSubCategory]];
                if (this.currentObject >= Object.keys(subcategory).length) {
                    this.currentObject = 0;
                    this.currentSubCategory++;
                }
                if (this.currentSubCategory >= Object.keys(category).length) {
                    this.currentSubCategory = 0;
                    this.currentCategory++;
                }
                return { done: false, value: subcategory[Object.keys(subcategory)[this.currentObject++]] };
            }
            return { done: true, value: undefined };
        };
        return ProductIterator;
    }());
    iter.ProductIterator = ProductIterator;
})(iter || (iter = {}));
var shoe;
(function (shoe) {
    var Shoe = /** @class */ (function () {
        function Shoe(id, size, color, price, discount) {
            if (discount === void 0) { discount = 0; }
            this.id = id;
            this.size = size;
            this.color = color;
            this.price = price;
            this.discount = discount;
        }
        Object.defineProperty(Shoe.prototype, "FinalPrice", {
            get: function () {
                return this.price - this.price * this.discount;
            },
            enumerable: false,
            configurable: true
        });
        Object.defineProperty(Shoe.prototype, "Discount", {
            get: function () {
                return this.discount;
            },
            set: function (newDiscount) {
                this.discount = newDiscount;
            },
            enumerable: false,
            configurable: true
        });
        return Shoe;
    }());
    shoe.Shoe = Shoe;
    shoe.getFilter = function (filterParam) {
        switch (filterParam) {
            case "color": {
                return function (obj, targetColor) {
                    return (obj.color === targetColor);
                };
            }
            case "price": {
                return function (obj, param) {
                    return (obj.price >= param.min && obj.price <= param.max);
                };
            }
            case "size": {
                return function (obj, targetSize) {
                    return (obj.size == targetSize);
                };
            }
        }
    };
    shoe.filter = function (iter, callback, searchRequest) {
        var res = iter.next();
        var ans = [];
        while (!res.done) {
            if (callback(res.value, searchRequest)) {
                ans.push(res.value);
            }
            res = iter.next();
        }
        return ans;
    };
})(shoe || (shoe = {}));
function main() {
    var products = {
        shoes: {
            sneakers: {
                shoe1: new shoe.Shoe(1, 36, "black", 100),
                shoe2: new shoe.Shoe(2, 42, "white", 140, 25),
                shoe3: new shoe.Shoe(3, 44, "white", 80),
                shoe4: new shoe.Shoe(4, 41, "red", 140)
            },
            boots: {
                shoe5: new shoe.Shoe(6, 43, "red", 90),
                shoe6: new shoe.Shoe(7, 38, "white", 130),
            },
            sandals: {
                shoe7: new shoe.Shoe(8, 45, "white", 100),
                shoe8: new shoe.Shoe(9, 43, "brown", 80),
            }
        },
        outwear: {
            jackets: {
                jacket1: {
                    id: 13,
                    size: 9,
                    price: 30,
                }
            },
        },
        accessories: {
            glasses: {
                glass1: {
                    id: 15,
                    size: 3,
                    price: 300,
                }
            }
        }
    };
    var shoe123 = new shoe.Shoe(10, 25, "black", 100, 0.5);
    console.log(shoe123.FinalPrice);
    var it = new iter.ProductIterator(products);
    var res = { done: false, value: undefined };
    // print all products
    //while(!res.done){res = it.next();console.log(res);}
    //let's filter
    var filterCallback = shoe.getFilter("price");
    console.log(shoe.filter(it, filterCallback, { min: 80, max: 135 }));
}
main();
