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
    let currentCount = 1;

    function makeCounter(){
        return function(){
            return currentCount++;
        }
    }

    let counter = makeCounter()
    let counter2 = makeCounter();

    alert(counter())
    alert(counter())

    alert(counter2())
    alert(counter2())
}
test1();

function test2(){

    const sum = (a) => {
        return (b) => {
          return (c) => {
            return a * b * c;
          };
        };
      };


    const sum1 = sum(10); // sum1 = b => c => 10 * b * c
    const sum2 = sum1(3); // sum2 = c => 10 * 3 * c
    const result = sum2(1); // result = 10 * 3 * 0

    console.log(result); // => 30

}
test2();


function test3(){
    const testMode = true; // вызывать функцию беспрерывно

    let x = 0
    let y = 0

    const step = 10;
    const makeMove = function(){
        const direction = prompt("Enter left, right, up or down: ")


        switch (direction){
            case "left":
                x -= step;
                break;
            case "right":
                x += step;
                break;
            case "up":
                y += step;
                break;
            case "down":
                y -= step;
                break;
        }

        console.log(`x: ${x} \t y: ${y}`);

    }

    if(testMode === true){
        while(true){
            makeMove();
        }
    }

}


function test4(){

    let testVariable = 0;

    for(item in window){
        console.log(item);
    }

    window.innerWidth = 1000;
    window.testVariable = 10;
}
