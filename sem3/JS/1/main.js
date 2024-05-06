
function compare(a, b){
    let mark = " != ";

    if(a == b){
        mark = " == ";
    }

    if(a > b){
        mark = " > ";
    }

    if(a < b){
        mark = " < ";
    }

    console.log (a + mark + b);
}

function generateForm(size){
    const field = document.getElementById("field");

    for(let i = 1; i <= size; i++){
        field.innerHTML += `<button onclick="test${i}()"> ${i} </button>`;
    }
}

function start(){
    generateForm(12);


}
start()

//-----------------------------------------------------------------------

function test1(){
    let a = 5;     // number
    let name = "Name"; // string
    let i = 0; // number
    let double = 0.23; // number
    let result = 1/0; // number (value: infinity)
    let answer = true; // boolean
    let no = null; // object (null)

    console.log("Тест1 - смотри код");
}

function test2(squreSide = 5, AX = 45, AY = 21){
    console.log("Тест2: ")
    const squresPerSideX = Math.floor(AX / squreSide);
    const squresPerSideY = Math.floor(AY / squreSide);

    console.log (squresPerSideX * squresPerSideY);
}

function test3(){
    console.log("Тест3: ")
    let i = 2;
    let a = ++i;
    let b = i++;

    compare(a, b);
}


function test4(){
    console.log("Тест4: ")

    const compareValues = [ ["Котик", "котик"], ["Котик", "китик"], ["Кот", "Котик"],
                            ["Привет", "Пока"], [73, "53"], [false, 0], [54, true],
                            [123, false], [true, "3"], [3, "5мм"], [8, "-2"],
                            [34, "34"], [null, undefined]
                          ];
    
    compareValues.forEach(element => {
        console.log( element[0] + (element[0] > element[1] ? '>' : (element[1] < element[0] ? '<' : (element[0] == element[1] ? '==' : '!='))) + element[1])
    });
}

function test5(){
    console.log("Тест5: ")

    const teacherName = "Кудлацкая Марина Федоровна".toLowerCase();
    const inputedName = prompt("Введите имя преподователя");

    try{
        if(teacherName.indexOf(inputedName.toLowerCase()) >= 0){
            alert('Частично верно!')
        }
        else{
            alert('Неправильно!')
        }
    }
    catch(e){
        console.log("Assuming this error type, you might have clicked on 'cancel' button")
    }
}

function test6(){
    console.log("Тест6: ")

    let count = 0;
    for(let i = 0; i < 3; i++){
        if(prompt(`Вы сдали предмет номер ${i} (да / нет): `) == "да"){
            count++;
        }
    }

    let studentStatus;
    switch(count){
        case 0:
            studentStatus = 'Ты больше не ФИТ!';
            break;
        case 3:
            studentStatus = 'Теперь ты на 1 курс старше';
            break;
        default:
            studentStatus = 'Ну, пересдача так пересдача';
            break;
    }

    console.log(studentStatus);
}


function test7(){
    console.log("Тест7: ")

    const a = prompt('Введите a: ');
    const b = prompt('Введите b: ');
    const n = prompt('Введите n: ');

    console.log(a + b);
    console.log(a - b);
    console.log(a / b);
    console.log(a * b);
    console.log(Math.pow(a, n));
    console.log(Math.pow(b, n));
    console.log(a % b);
    console.log(Math.sqrt(a));
    console.log(Math.sqrt(b));
}

function testX(){
    console.log("Тест8 - смотри код")

    true + true // true
    0 + "5" // 05
    5 + "мм" // 5мм
    8/Infinity // 0
    9 * "\n9" // 81
    null - 1 // -1
    "5" - 2 // 3
    "5px" - 3 // NaN
    true - 3 // -2
    7 || 0 // 7
}

function test8(){
    console.log("Тест8: ")

    let simpleArr = new Array(10);

    let i = 1;
    simpleArr.fill(i++);

    for(let j = 0; j < simpleArr.length; j++){
        if(index % 2 == 0){
            element += 2;
            continue;
        }
        element = element + "мм";
    }

    console.log(simpleArr);
}


function test9(){
    console.log("Тест9: ")

    const daysaWeak = ["пн", "вт", "ср", "чт", "пт", "сб", "вс"];
    const weakObj = {...daysaWeak}

    const dayNumber = prompt('Введите номер дня недели: ');

    try{
        console.log(weakObj[dayNumber - 1]);
    }
    catch(error){
        console.log("A fatal error! Make sure you've wrote a legit number");
    }
}

function test10(a = 10, b, c){
    if(c === undefined){
        c = prompt('Введите c: ')
    }

    return a + String(b) + String(c)
}



function params(){
    return null;
}

function test11(){
    console.log("Тест11: ")

    const a = prompt('Введите a')
    const b = prompt('Введите b')

    function params1(){
        if(a == b){
            return (() => {
                console.log((Number(a) + Number(b)) * 2);
            })
        }
        else{
            return (function (){
                console.log(a * b);
            });
        }
    }

    let params = params1();

    params();
}
