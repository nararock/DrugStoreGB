//Registration
function registrateUser(): void {
    let nickname = document.querySelector<HTMLInputElement>(".registration-field__div input[name = 'Nickname']").value;
    let email = document.querySelector<HTMLInputElement>(".registration-field__div input[name = 'Email']").value;
    let telephone = document.querySelector<HTMLInputElement>(".registration-field__div input[name = 'Telephone']").value;
    let city = document.querySelector<HTMLInputElement>(".registration-field__div input[name = 'City']").value;
    let district = document.querySelector<HTMLInputElement>(".registration-field__div input[name = 'District']").value;
    let password = document.querySelector<HTMLInputElement>(".registration-field__div input[name = 'Password']").value;
    let doublePassword = document.querySelector<HTMLInputElement>(".registration-field__div input[name = 'DoublePassword']").value;

        fetch('/Account/Registrate', {
        method: 'POST',
        body: JSON.stringify({
            Email: email,
            Nickname: nickname,
            Telephone: telephone,
            City: city,
            District: district,
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

//create Ad
function createAd() {
    let title = document.querySelector<HTMLInputElement>(".ad-input input[name = 'Title']").value;
    let type = document.querySelector<HTMLInputElement>(".ad-select select[name = 'Type']").value;
    let category = document.querySelector<HTMLInputElement>(".ad-select select[name = 'Category']").value;
    let dose = document.querySelector<HTMLInputElement>(".ad-input input[name = 'Dose']").value;
    let amount = document.querySelector<HTMLInputElement>(".ad-input input[name = 'Amount']").value;
    let month = document.querySelector<HTMLInputElement>(".ad-select select[name = 'Month']").value;
    let year = document.querySelector<HTMLInputElement>(".ad-select select[name = 'Year']").value;
    let manufacturer = document.querySelector<HTMLInputElement>(".ad-input input[name = 'Manufacturer']").value;
    let description = document.querySelector<HTMLInputElement>(".ad-textarea textarea[name = 'Description']").value;

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
        .then((response) => response.json())
        .then(answer => {
            if (answer.code == 1) {
                let error = document.querySelector(".ad-error");
                error.textContent = answer.message;
            }
            else {
                window.location.replace('/Profile/Index');
            }
        })
}

//DrugInfoPage Show.cshtml
function goToDrugInfo(event) {
    let id = event.target.parentElement.dataset.id;
    window.location.replace('/Ad/Show/' + id);
}

//CatalogPage
function changePage(event) {
    let page = event.target.textContent;
    fetch('/Catalog/Index?page=' + page)
        .then((response) => response.json())
    window.location.replace('/Catalog/Index?page=' + page);
}

//Profile
function deleteAd(event) {
    let idAd = event.target.dataset.id;    

    fetch('/Profile/DeleteAd/' + idAd)
        .then((response) => response.json())
        .then(answer => {
            if (answer.Code == 1) {
                alert("Возникла ошибка при удалении.")
            }
            else {
                let elementTr = event.target.parentElement.parentElement;
                let elementParent = elementTr.parentElement;
                elementParent.removeChild(elementTr);
            }
        })
}
