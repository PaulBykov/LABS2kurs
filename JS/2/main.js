function generateForm(size) {
    const field = document.getElementById("field");

    for (let i = 1; i <= size; i++) {
        field.innerHTML += `<button onclick="test${i}()"> ${i} </button>`;
    }
}

function start() {
    generateForm(6);
}
start()

// -----------------------------------------------------------


function basicOperation(operation, value1, value2){

    const result = eval(value1 + operation + value2)

    return result;
}


function sumCubesTillN(n){
    let res = 0;

    for(let i = 1; i < n; i++){
        res += Math.pow(i, 3);
    }

    return res;
}


function avgArrValue(array){
    let sum = 0;

    array.forEach(element => {
        sum += element;
    });

    return element / array.length;
}


function engReversedString(str){
    const clearedString = str.replace(/[^A-Za-z]/g, '');

    return clearedString.split('').reverse().join('');
}


function stringMultiply(n , str){
    return str.repeat(n);
}


function getUniqueElemenets(str1, str2){
    let newStr = []

    str1.forEach((str) => {
        if(!str2.includes(str)){
            newStr.push(str);
        }
    });

    return newStr;
}


