const resultField = document.querySelector("#time-status");


document.querySelector("#update-time").addEventListener("click", ()=>{
    const reqInfo = document.querySelector(".request-info");

    fetch("http://localhost:8080/demo2-1.0-SNAPSHOT/Main")
        .then((response) => response.text())
        .then((data) => reqInfo.innerHTML = data)
        .then(() => updateDateFromCookie())
        .catch((reason) => alert("error during get: " + reason))
})



function getCookie(name) {
    const cookies = document.cookie.split(';'); // Разбиваем строку кук на массив кук

    for (let i = 0; i < cookies.length; i++) {
        const cookie = cookies[i].trim(); // Удаляем пробелы с обоих концов строки куки
        const cookieParts = cookie.split('=');

        if (cookieParts.length === 2 && cookieParts[0] === name) {
            return cookieParts[1]; // Возвращаем значение куки
        }
    }

    return undefined;
}



function updateDateFromCookie() {
    const dateCookie = getCookie('date');
    if (dateCookie) {
        document.getElementById('time-status').textContent = dateCookie;
    }
}