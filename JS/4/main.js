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
    const laptop = {name: "laptop"};
    const someProducts = [
        laptop,
        {
            name: "tablet",
        },
        {
            name: "piano",
        },
        {
            name: "phone",
        }
    ]

    let productSet = new Set(someProducts)


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

    addNewProduct({name: "mouse"});
    removeProduct(laptop);
    
    console.log(hasProduct({name: "mouse"}));
    console.log(productSet.length);

    console.log(productSet);
}


function test2(){
    const someStudents = [
        {
            ID: 1,
            group: 6,
            fullName: "Pavel Bykov Alexeevich"
        },
        {
            ID: 2,
            group: 4,
            fullName: "Stas Rozel Olegovich"
        },
        {
            ID: 7,
            group: 4,
            fullName: "Alexander Ivashkevich Olegovich"
        },
        {
            ID: 4,
            group: 4,
            fullName: "Nikolay Beloded Ivanovich"
        },
    ]

    let studentList = new Set(someStudents);

    const addStudent = ((student) => {
        studentList.add(student);
    })

    const removeStudentByNumber = ((number) => {
        for(const student of studentList){
            if(student.ID === number){
                studentList.delete(student);
            }
        }
    })

    const filterByGroup = ((group) => {
        for(const student of studentList){
            if(student.group !== group){
                studentList.delete(student);
            }
        }
    })

    const sortByID = (() => {
        let sortedArray = Array.from(studentList).sort((a, b) => a.ID - b.ID);
        studentList = new Set(sortedArray);

    })

    const print = () => {
        console.log("-----------------------------------------------");
        for(const student of studentList){
            console.log(student.ID + " " + student.group + " " + student.fullName);
        }
    }

    const useTestValues = (() => {
       addStudent({
           ID: 5,
           group: 2,
           fullName: "Idk any others"
       });
       print();

       removeStudentByNumber(2);
       print();

       sortByID();
       print();

       filterByGroup(4);
       print();
    });

    useTestValues();
    return studentList;
}



function test3(){
    const someProducts = [
        {
            name: 'Laptop',
            count: 1,
            price: 100,
        },
        {
            name: 'Tablet',
            count: 6,
            price: 20,
        }
    ];

    let products = new Map();
    let lastID = 1;

    const addNewProduct = ((product) => {
        products.set(lastID++, product);
    })


    const deleteProductByID = ((id) => {
        products.delete(id);
    })


    const deleteProductByName = ((name) => {
        for(let productID of products.keys()){
            if(products.get(productID).name === name){
                products.delete(productID);
            }
        }
    })


    const changeCountPropertyByID = ((id, newCount) => {
        products.get(id).count = newCount;
    })


    const changePricePropertyByID = ((id, newPrice) => {
        products.get(id).price = newPrice;
    })

    const show = function(){
        console.log("--------------------------------------------");
        products.forEach((product) => {
            console.log(product.name + " " + product.count + " " + product.price);
        })
    }

    someProducts.forEach((product) => {
        addNewProduct(product);
    });
    show();

    changeCountPropertyByID(2, 123)
    changePricePropertyByID(2, 120)
    show();

    deleteProductByID(1);
    show();

    addNewProduct(
        {
            name: 'Piano',
            count: 30,
            price: 160,
        }
    );
    show();

    deleteProductByName('Piano')
    show();

}


function test4(){
    const wMap = new WeakMap();

    const power = (input => {

        if(!wMap.has(input)){
            console.log('NO CACHE')
            wMap.set(input, input.a ** input.b)
        }

        return wMap.get(input);
    })

    const testObj = {a: 12,
                     b: 3,}

    console.log(power(testObj));
    console.log(power( {a:12, b:3}));
    console.log(power(testObj));
    
}


