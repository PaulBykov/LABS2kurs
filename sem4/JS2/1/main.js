const form = document.querySelector("#about-me-form");

function removeAllErrorMessages(){
    const errorMessages = document.querySelectorAll(".error-message");
    errorMessages.forEach((msg) => {
        msg.remove();
    })
}


form.addEventListener('submit', function (event)
{
    event.preventDefault();
    removeAllErrorMessages();

    const inputs = form.querySelectorAll("input, textarea");
    inputs.forEach((input) => {
        if(input.value.length < 1){
            displayError("Поле не должно быть пустым", input.id);
        }
    });


    const names = document.querySelectorAll("#surname, #first-name");
    const NAMES_REGEXP = /^[a-zA-Zа-яА-Я]*$/
    names.forEach((name) => {
        if(name.value.length > 20){
            displayError("Длина этого поля не должна превышать 20", name.id)
        }

        if(!NAMES_REGEXP.test(name.value)){
            displayError("Недопустимые символы", name.id);
        }
    })




    const email = form.querySelector("#email");
    const EMAIL_REGEXP = /^\S+@[a-zA-Z]{2,5}\.[a-zA-Z]{2,3}$/;
    if(!EMAIL_REGEXP.test(email.value)){
        displayError("Неверный формат почты!", email.id);
    }


    const phoneNumber = document.querySelector("#number");
    const NUMBER_REGEXP = /^\(0\d{2}\)\d{3}-\d{2}-\d{2}$/;
    if(!NUMBER_REGEXP.test(phoneNumber.value)){
        displayError("Неверный формат номера телефона", phoneNumber.id)
    }


    const aboutSelf = document.querySelector("#free-textarea");
    if(aboutSelf.value.length > 250){
        displayError("Максимальная длина этого поля 250 символов", aboutSelf.id);
    }


    const city = document.querySelector("#city");
    const yearRadioButtons = document.querySelectorAll("#year")
    const learnBSTU = document.querySelector("#learn-bstu");

    const activeRadioButton = (() => {
        let ind = -1;
        yearRadioButtons.forEach((btn, index) => {
            if(btn.checked){
                ind = index;
            }
        });

        return ind;
    })();

    if(city.value === 'Минск' && activeRadioButton === 2 && learnBSTU.checked){
        this.submit()
    }
    else{
        const ans = confirm("Вы уверены в своём ответе?");

        ans && this.submit();
    }
});

function displayError(message, inputId) {
    const errorLabel = document.querySelector('[for="' + inputId + '"]');
    // Создаем элемент для вывода сообщения об ошибке
    const errorMessage = document.createElement('span');
    errorMessage.className = 'error-message';
    errorMessage.textContent = message;

    // Проверяем, есть ли уже сообщение об ошибке
    const existingErrorMessage = errorLabel.querySelector('.error-message');
    if (existingErrorMessage) {
        // Если есть, заменяем его новым сообщением
        existingErrorMessage.textContent = "\n" + message;
    } else {
        // Иначе добавляем новое сообщение об ошибке
        errorLabel.appendChild(errorMessage);
    }
}

