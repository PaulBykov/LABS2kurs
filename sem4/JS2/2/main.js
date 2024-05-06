const settings = {
    conHeight: "350",
    conWidth: "250",
    ballDim: "100",
}
function getRandomInt(min, max) {
    return Math.floor(Math.random() * max) + min;
}
class Game{
    started = false;
    choise;   //    1-3
    rightans; //    1-3

    constructor() {

    }
}
const session = new Game();


document.querySelector("#refresh-button").addEventListener('click', refresh);
document.querySelector("#settings-form").addEventListener("submit",updateStyles);
const RESULT_FIELD = document.querySelector(".result");
const COUNTER = document.querySelector("#fourth");


function refresh(){
    COUNTER.value = 0;
}

function updateStyles(event){
    event.preventDefault();
    const form = document.querySelector("#settings-form");

    settings.conHeight = form.querySelector("#first").value || settings.conHeight;
    settings.conWidth = form.querySelector("#second").value || settings.conWidth;
    settings.ballDim = form.querySelector("#third").value   || settings.ballDim;

    applyStyles();
}

function applyStyles(){
    const cones = document.querySelectorAll(".cone");

    cones.forEach((cone) => {
        cone.style.height = settings.conHeight + "px";
        cone.style.width = settings.conWidth + "px";
    })

    document.querySelectorAll(".ball").forEach((ball)=>{
        ball.style.width = settings.ballDim + "px"
    });
}



function move(){
    session.rightans = getRandomInt(1, 3);
    console.log("---TEST--- ans = " + session.rightans)

    const balls = document.querySelectorAll(".ball-container");
    const ball = balls[session.rightans-1];

    ball.style.display = "flex";
    setTimeout(() => ball.style.display="none", 2000)

    let msg;
    if(session.choise === session.rightans){
        msg = "Успех!";
        COUNTER.value++;
    } else{
        msg = "Не успех!";
        COUNTER.value--;
    }
    RESULT_FIELD.innerText = msg;


}

async function pickUp1(){
    session.choise = 1;
    await pickUp(document.querySelector("#first-fig").querySelector(".cone"));
}

async function pickUp2(){
    session.choise = 2;
    await pickUp(document.querySelector("#second-fig").querySelector(".cone"));
}

async function pickUp3(){
    session.choise = 3;
    await pickUp(document.querySelector("#third-fig").querySelector(".cone"));
}

async function pickUp(_target){
    if(session.started){
        return;
    }

    _target.style.bottom = settings.ballDim + "px";
    session.started = true;

    setTimeout(()=> {
        _target.style.bottom = "0px";
        session.started = false;
    }, 2000);

    move();
}