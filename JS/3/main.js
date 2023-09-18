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

function test1(array){
    array = array.reduce((prev, curr) => prev.concat(curr), []);

    return array;
}


function test2(array){
    const flatArray = array.flat();

    return flatArray.reduce((sum, curr) => {
        return sum += curr;
    })
}


function test3(studentArray){
// test3([{name: "Pasha", age: 18, groupID: 6}, {name: "Stas", age: 19, groupID: 5}, {name: "Lesha", age: 11, groupID: 5}])
    let groupList = new Map();

    studentArray.forEach(student => {
        if(student.age > 17){
            if(groupList.has(student.groupID)){
                groupList.get(student.groupID).push(student);
            }
            else{
                groupList.set(student.groupID, [student]);
            }
        }
    });

    return result = Object.fromEntries(groupList.entries());
}


function test4(string){
    let target1 = '';

    for(symbol in string){
        target1 += symbol.charCodeAt(0);
    }

    let target2 = target1.replace('7', '1');

    return [target1, target2]
}


function test5(){
    // test5({name: "Pasha", age: 18, groupID: 6}, {gregor: "yes", type: 2})
    return Object.assign({}, Object.assign(...arguments));   
}


function test6(stages){
// test6(7)
    const size = 1 + 2 * stages;

    for(let i = 0; i < stages; i++){
        let result = ''

        result += ' '.repeat(stages - i);
        result += '*'.repeat(1 + 2 * i);
        result += ' '.repeat(stages - i);

        console.log(result, '\n');
    }

}


