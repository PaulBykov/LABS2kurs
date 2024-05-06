document.getElementById("guessForm").addEventListener("submit", function(event) {
    event.preventDefault();
    var guess = document.getElementById("guessInput").value;
    makeGuess(guess);
});

document.getElementById("setForm").addEventListener("submit", function(event) {
    event.preventDefault();
    var number = document.getElementById("setInput").value;
    setNumber(number);
});



function makeGuess(guess) {
    var xhr = new XMLHttpRequest();
    xhr.open("POST", "http://localhost:8080/demo1-1.0-SNAPSHOT/GuessNumber", true);
    xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
    xhr.onreadystatechange = function() {
        if (xhr.readyState === XMLHttpRequest.DONE && xhr.status === 200) {
            document.getElementById("result").innerText = xhr.responseText;
        }
    };
    xhr.send("guess=" + guess);
}


function setNumber(number){
    var xhr = new XMLHttpRequest();
    xhr.open("POST", "http://localhost:8080/demo1-1.0-SNAPSHOT/SetNumber", true);
    xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
    xhr.send("number=" + number);
}