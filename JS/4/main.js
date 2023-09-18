function generateForm(size) {
    const field = document.getElementById("field");

    for (let i = 1; i <= size; i++) {
        field.innerHTML += `<button onclick="test${i}()"> ${i} </button>`;
    }
}

function start() {
    generateForm(4);
}
start()

// -----------------------------------------------------------


function test1(){
    let productSet = new Set(["1", "2", "3", "5", "9"])

    const addNewProduct = ((product) => {
        productSet.add(product);
    })

    const removeProduct = ((product) => {
        productSet.delete(product);
    })

    const hasProduct = ((product) => {
        return productSet.has(product);
    })


    console.log(productSet);

    addNewProduct("8");
    removeProduct("3");
    
    console.log(hasProduct("1"));
    console.log(hasProduct("4"));
    console.log(productSet.length);

    console.log(productSet);
}


function test2(){
    let studentList = new Set();

    const student1 = {
        ID: 12,
        group: 6,
        fullName: "Pavel Bykov Alexeevich"
    }

    const addStudent = ((student) => {
        studentList.add(student);
    })

    const removeStudentByNumber = ((number) => {
        for(student of studentList){
            if(student.ID == number){
                studentList.delete(student);
            }
        }
    })


    const filterByGroup = ((group) => {
        for(student of studentList){
            if(student.group !== group){
                studentList.delete(student);
            }
        }
    })


    const sortByID = ((id) => {
        const studentArr = new Array(studentList);

        studentArr.sort((a, b) => {
            return a.ID < b.ID;
        })

        studentList = new Set();
        studentArr.forEach((element) => {
            studentList.add(element);
        })
    })

}



function test3(){
    let products = new Map();

    const laptop = {
        name: 'Laptop',
        count: 1,
        price: 10
    }


    const addNewProduct = ((product) => {
        products.add(product);
    })


    const deleteProductByID = ((id) => {
        products.delete(id);
    })


    const deleteProductByName = ((name) => {
        for(let i = 0; i < name.length; i++){
            let product = products.get(i);
            if(product.name === name){
                products.delete();
            }
        }
    })


    const changeCountPropertyByID = ((id, newCount) => {
        products.get(id).count = newCount;
    })


    const changePricePropertByID = ((id, newPrice) => {
        products.get(id).price = newPrice;
    })

    const show = function(){
        console.log(products);
    }

    addNewProduct(laptop);
    show;

    deleteProductByID(0);
    show;

    addNewProduct(laptop);
    deleteProductByName('Laptop')
    show;

    changeCountPropertyByID(0, 123);
    changePricePropertByID(0, 120)
    show;

    
}


function test4(){
    const wMap = new WeakMap();

    const testFunction = (input => {

        if(!wMap.has(input)){
            console.log('NO CACHE')
            wMap.set(input, input.a * input.b)
        }

        return wMap.get(input);
    })

    const testObj = {a: 12,
                     b: 3,}
    const testObj2 = {a: 1,
                     b: 3,}

    console.log(testFunction(testObj));
    console.log(testFunction( {a:12, b:3}));
    console.log(testFunction(testObj));
    
}
