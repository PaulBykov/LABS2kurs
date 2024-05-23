const tableContainer = document.querySelector(".items-container");
const addItemForm = document.querySelector("#addItemForm");
const deleteItemForm = document.querySelector("#deleteItemForm");


addItemForm.addEventListener("submit", (e) => {
    const itemName = addItemForm.querySelector("#itemName").value;
    postData("http://localhost:8080/demo2-1.0-SNAPSHOT/controller?command=addItem", {itemName: itemName})
})

deleteItemForm.addEventListener("submit", (e) => {
    const itemId = deleteItemForm.querySelector("#itemID").value;
    postData("http://localhost:8080/demo2-1.0-SNAPSHOT/controller?command=deleteItem", {itemId: itemId})
})


const postData = async (url = '', data = {}) => {
    await fetch(url, {
        method: 'POST',
        headers: {'Content-Type': 'application/json'},
        body: JSON.stringify(data)})
}

function getData(){
    fetch("http://localhost:8080/demo2-1.0-SNAPSHOT/controller?command=getAllItems")
        .then((response) => response.text())
        .then((text) => tableContainer.innerHTML = text)
        .catch((reason) => prompt("Error fetching data:" + reason))
}

getData();
