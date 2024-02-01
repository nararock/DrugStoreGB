//Registration
function registrateUser(): void {
    let email = document.querySelector<HTMLInputElement>(".registration-field__div input[name = 'Email']").value;
    let password = document.querySelector<HTMLInputElement>(".registration-field__div input[name = 'Password']").value;
    let doublePassword = document.querySelector<HTMLInputElement>(".registration-field__div input[name = 'DoublePassword']").value;

        fetch('/Account/Registrate', {
        method: 'POST',
        body: JSON.stringify({
            Email: email,
            Password: password,
            DoublePassword: doublePassword
        }),
        headers: {
            // Добавляем необходимые заголовки
            'Content-type': 'application/json; charset=UTF-8',
        },
        credentials: 'include'
    })
        .then(response => response.json())
        .then(answer => {
            if (answer.code === 1) {
                let error = document.querySelector(".registration-error");
                error.textContent = answer.message;
            } else {
                window.location.replace('/Account/Login');

            }
        })
        .catch((e) => {
            console.log(e)
        })
}


function clearError() {
    let error = document.querySelector(".registration-error");
    error.textContent = "";
}

//Login
function loginUser() {
    let email = document.querySelector<HTMLInputElement>(".login-field__div input[name = 'Email']").value;
    let password = document.querySelector<HTMLInputElement>(".login-field__div input[name = 'Password']").value;

    fetch('/Account/Login', {
        method: 'POST',
        body: JSON.stringify({
            Email: email,
            Password: password
        }),
        headers: {
            'Content-type': 'application/json; charset=UTF-8',
        },
        credentials: 'include'
    })
        .then((response) => response.json())
        .then(answer => {
            if (answer.code === 1) {
                let error = document.querySelector(".login-error");
                error.textContent = answer.message;
            } else {
                window.location.replace('/Profile/Index');
            }
        })
}