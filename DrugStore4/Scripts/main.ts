//Registration
function createUser() {
    let email = document.querySelector<HTMLInputElement>(".registration-field__div input[name = 'Email']").value;
    console.log(email);
    let password = document.querySelector<HTMLInputElement>(".registration-field__div input[name = 'Password']").value;
    let doublePassword = document.querySelector<HTMLInputElement>(".registration-field__div input[name = 'DoublePassword']").value;

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
            .then(response => response.json())
            .then(answer => {
                if (answer.code === 1) {
                    let error = document.querySelector(".registration-error");
                    error.textContent = answer.message;
                } else {
                    window.location.replace('/login');

                }
            })
            .catch((e) => {
                console.log(e)
            })
    }
}

function clearError() {
    let error = document.querySelector(".registration-error");
    error.textContent = "";
}