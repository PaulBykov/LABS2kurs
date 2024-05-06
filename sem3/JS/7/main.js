
function getAllShoes(shoesObj) {
    let allShoes = [];

    for (const shoeType in shoesObj) {
        const shoesOfType = shoesObj[shoeType];
        for (const shoeKey in shoesOfType) {
            allShoes.push(shoesOfType[shoeKey]);
        }
    }

    return allShoes;
}

function Shoe(id, size, color, worth, discount = 0){
    this.id = id;
    this.size = size;
    this.color = color;
    this.discount = discount;
    this.worth = worth;

    Object.defineProperty(this, 'price', {
        enumerable: true,
        configurable: false,

        get: function() {
            return this.worth - (this.worth * (this.discount / 100));
        },

        set: function (value){
            this.price = value;
        }
    });

    Object.defineProperty(this, "id",
        {
            writable:false,
            enumerable: true,
            configurable: false
        })

}


function task1(){

    const products = {
        shoes: {
            sneakers: {
                shoe1: new Shoe(1, 36, "black", 100),
                shoe2: new Shoe(2, 42, "white", 140, 25),
                shoe3: new Shoe(3, 44, "white", 80),
                shoe4: new Shoe(4, 41, "white", 140)
            },
            boots: {
                shoe5: new  Shoe(6, 43, "red", 90),
                shoe6: new  Shoe(7, 38, "white", 130),
            },
            sandals: {
                shoe7: new Shoe(8, 45, "white", 100),
                shoe8: new Shoe(9, 43, "brown", 80),
            }
        },
        jackets: {
            jacket: {
                id: 13,
                size: 9,
                price: 30,
            },
        },
        accessories: {
            glasses: {
                id: 15,
                size: 3,
                price: 300,
            }
        }
    }

    const Shoes = getAllShoes(products.shoes);

    const filterByPriceDist = (lowerPrice, higherPrice) => {
        const result = Shoes.filter(
            (product) =>
                product.price >= lowerPrice
                && product.price <= higherPrice
        )

        console.log(result);
    }
    const filterByColor = (color) => {
        const result = Shoes.filter(
            (product) =>
                product.color === color
        )

        console.log(result);
    }
    const filterBySize = (size) => {
        const result = Shoes.filter(
            (product) =>
                product.size === size
        )

        console.log(result);
    }


    const newProducts = JSON.parse(JSON.stringify(products));

    filterByColor("white")

    console.log("worth: " + products.shoes.sneakers.shoe2.worth);
    console.log("discount: " + products.shoes.sneakers.shoe2.discount + "%");
    console.log("price: " + products.shoes.sneakers.shoe2.price);

}

task1()