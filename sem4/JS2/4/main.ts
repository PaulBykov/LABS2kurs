
namespace iter{
    export interface IIterResult{
        done: boolean,
        value: shoe.IProduct | undefined
    }
    export class ProductIterator {
        private readonly products: object;
        private currentCategory: number = 0;
        private currentSubCategory: number = 0;
        private currentObject: number = 0;

        constructor(products: object) {
            this.products = products;
        }
        public next(): iter.IIterResult {
            while(this.currentCategory < Object.keys(this.products).length) {
                const category: object = this.products[Object.keys(this.products)[this.currentCategory]];
                const subcategory: object = category[Object.keys(category)[this.currentSubCategory]];

                if (this.currentObject >= Object.keys(subcategory).length) {
                    this.currentObject = 0;
                    this.currentSubCategory++;
                }

                if (this.currentSubCategory >= Object.keys(category).length) {
                    this.currentSubCategory = 0;
                    this.currentCategory++;
                }

                return {done: false, value: subcategory[Object.keys(subcategory)[this.currentObject++]]};
            }

            return { done: true, value: undefined };
        }
    }

}

namespace shoe{
    export interface IProduct{
        id: number,
        size: number,
        color: string,
        price: number,

        discount: number | undefined,
    }
    export class Shoe implements IProduct{
        id: number;
        size: number;
        color: string;
        price: number;

        discount: number;

        get FinalPrice(){
            return this.price - this.price * this.discount;
        }
        set Discount(newDiscount: number){
            this.discount = newDiscount;
        }
        get Discount(){
            return this.discount;
        }

        constructor(id:number, size:number, color: string, price: number, discount:number = 0){
            this.id = id;
            this.size = size;
            this.color = color;
            this.price = price;
            this.discount = discount;
        }
    }

    type filterParam = "color" | "price" | "size";

    namespace callback{
        export type param = string | {min: number, max: number} | number;

        export type FilterCallback = (obj: IProduct, param: param) => boolean;
    }
    export const getFilter = (filterParam: filterParam) :callback.FilterCallback => {
        switch (filterParam){
            case "color":{
                return (obj: IProduct, targetColor: string) :boolean => {
                    return (obj.color === targetColor);
                };
            }
            case "price":{
                return (obj: IProduct, param: {min: number, max: number}):boolean => {
                    return (obj.price >= param.min && obj.price <= param.max);
                };
            }
            case "size":{
                return (obj: IProduct, targetSize: number):boolean => {
                    return (obj.size == targetSize);
                };
            }
        }
    };
    export const filter = (iter: iter.ProductIterator, callback: callback.FilterCallback, searchRequest: callback.param) :object[] => {
        let res: iter.IIterResult = iter.next();
        let ans: IProduct[] = [];

        while(!res.done){
            if(callback(res.value, searchRequest)){
                ans.push(res.value);
            }

            res = iter.next();
        }

        return ans;
    };
}



function main(){
    const products = {
        shoes: {
            sneakers: {
                shoe1: new shoe.Shoe(1, 36, "black", 100),
                shoe2: new shoe.Shoe(2, 42, "white", 140, 25),
                shoe3: new shoe.Shoe(3, 44, "white", 80),
                shoe4: new shoe.Shoe(4, 41, "red", 140)
            },
            boots: {
                shoe5: new  shoe.Shoe(6, 43, "red", 90),
                shoe6: new  shoe.Shoe(7, 38, "white", 130),
            },
            sandals: {
                shoe7: new shoe.Shoe(8, 45, "white", 100),
                shoe8: new shoe.Shoe(9, 43, "brown", 80),
            }
        },
        outwear: {
            jackets: {
                jacket1:{
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
    }
    const shoe123 = new shoe.Shoe(10, 25, "black", 100, 0.5);
    console.log(shoe123.FinalPrice);

    const it = new iter.ProductIterator(products);
    let res = {done: false, value: undefined};
    // print all products
    //while(!res.done){res = it.next();console.log(res);}

    //let's filter
    const filterCallback = shoe.getFilter("price");
    console.log(shoe.filter(it, filterCallback, {min: 80, max: 135}))


}


main()