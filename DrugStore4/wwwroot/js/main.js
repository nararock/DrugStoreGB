//Registration
function createUser() {
    var email = document.querySelector(".registration-field__div input[name = 'Email']").value;
    console.log(email);
    var password = document.querySelector(".registration-field__div input[name = 'Password']").value;
    var doublePassword = document.querySelector(".registration-field__div input[name = 'DoublePassword']").value;
    if (password == doublePassword) {
        fetch('/Registration/Create', {
            method: 'POST',
            body: JSON.stringify({
                Email: this.email,
                Password: this.password
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
                window.location.replace('/login');
            }
        })
            .catch(function (e) {
            console.log(e);
        });
    }
}
function clearError() {
    var error = document.querySelector(".registration-error");
    error.textContent = "";
}
//# sourceMappingURL=main.js.map