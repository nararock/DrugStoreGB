//Registration
function registrateUser() {
    var email = document.querySelector(".registration-field__div input[name = 'Email']").value;
    var password = document.querySelector(".registration-field__div input[name = 'Password']").value;
    var doublePassword = document.querySelector(".registration-field__div input[name = 'DoublePassword']").value;
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
        .then(function (response) { return response.json(); })
        .then(function (answer) {
        if (answer.code === 1) {
            var error = document.querySelector(".registration-error");
            error.textContent = answer.message;
        }
        else {
            window.location.replace('/Account/Login');
        }
    })
        .catch(function (e) {
        console.log(e);
    });
}
function clearError() {
    var error = document.querySelector(".registration-error");
    error.textContent = "";
}
//Login
function loginUser() {
    var email = document.querySelector(".login-field__div input[name = 'Email']").value;
    var password = document.querySelector(".login-field__div input[name = 'Password']").value;
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
        .then(function (response) { return response.json(); })
        .then(function (answer) {
        if (answer.code === 1) {
            var error = document.querySelector(".login-error");
            error.textContent = answer.message;
        }
        else {
            window.location.replace('/Profile/Index');
        }
    });
}
//# sourceMappingURL=main.js.map