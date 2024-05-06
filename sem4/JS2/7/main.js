function task1(delay = 3000){
    return new Promise((resolve, reject) => {
        return setTimeout(() => reject(Math.random()), delay);
    })
}
task1().then((result) => {console.log(result)},
             (err) => { console.log("fatal error");}
);


function task2(){
    Promise.all([task1(1000), task1(2000), task1(3000)])
                .then(
                    (result) => {
                        console.log("task2: ");
                        result.forEach((elem) => console.log(elem))
                })
}
//task2();


function task3(){
    console.log("task3: ");
    let pr = new Promise((res,rej) => {
        rej('ku')
    })

    pr
        .then(() => console.log(1), () => console.log(6))
        .catch(() => console.log(2))
        .catch(() => console.log(3))
        .then(() => console.log(4))
        .then(() => console.log(5))
}
//task3();


function task4(){
    console.log("task4: ");
    const prom = new Promise((res, rej) => res(21));
    prom.then((value) => {
        console.log(value);
        return new Promise((resolve, reject) => resolve(value));
    })
        .then((value) => console.log(value * 2))
}
//task4();


async function task5() {
    console.log("task5: ");
    let value = await new Promise((res, rej) => res(21));
    console.log(value);
    value = await new Promise((res, reject) => res(value*2));
    console.log(value);
}
//task5();


