const form = document.querySelector("#login-form");
const responseField = document.querySelector("#login-status");

form.addEventListener("submit", (e) => {
    e.preventDefault();
    const login = form.querySelector("#login-input").value;
    const password = form.querySelector("#pass-input").value;

    sendData(login, password);
})


function sendData(login, pass){
    var xhr = new XMLHttpRequest();
    xhr.open("POST", "http://localhost:8080/demo2-1.0-SNAPSHOT/Auth", true);
    xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
    xhr.onreadystatechange = function() {
        if(xhr.readyState === XMLHttpRequest.DONE ) {
            if (xhr.status === 200) {
                responseField.innerText = "Success";
                responseField.style.color = "green";

                setTimeout(() => {
                    window.location.href = ("http://localhost:8080/demo2-1.0-SNAPSHOT/main/main.jsp")
                }, 1000)
            }
            else{
                responseField.innerText = "Error";
                responseField.style.color = "red";
            }
        }

    };
    xhr.send("login=" + login + "&pass=" + pass + "&register=true");

}