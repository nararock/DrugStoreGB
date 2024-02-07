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
//create Ad
function createAd() {
    var title = document.querySelector(".ad-input input[name = 'Title']").value;
    var type = document.querySelector(".ad-select select[name = 'Type']").value;
    var category = document.querySelector(".ad-select select[name = 'Category']").value;
    var dose = document.querySelector(".ad-input input[name = 'Dose']").value;
    var amount = document.querySelector(".ad-input input[name = 'Amount']").value;
    var month = document.querySelector(".ad-select select[name = 'Month']").value;
    var year = document.querySelector(".ad-select select[name = 'Year']").value;
    var manufacturer = document.querySelector(".ad-input input[name = 'Manufacturer']").value;
    var description = document.querySelector(".ad-textarea textarea[name = 'Description']").value;
    fetch('/Ad/Create', {
        method: 'POST',
        body: JSON.stringify({
            Title: title,
            Type: type,
            Category: category,
            Dose: dose,
            Amount: amount,
            Month: month,
            Year: year,
            Manufacturer: manufacturer,
            Description: description
        }),
        headers: {
            'Content-type': 'application/json; charset=UTF-8',
        },
        credentials: 'include'
    })
        .then(function (response) { return response.json(); });
}
//# sourceMappingURL=main.js.map