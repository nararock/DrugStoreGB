//Home

//close details
const All_Details = document.querySelectorAll('details');

All_Details.forEach(deet => {
    deet.addEventListener('toggle', toggleOpenOneOnly)
})

function toggleOpenOneOnly(e) {
    if (this.open) {
        All_Details.forEach(deet => {
            if (deet != this && deet.open) deet.open = false
        });
    }
}

function goToHomePage() {
    window.location.href = '/Home/Index';
}

function goToCatalog() {
    window.location.href='/Catalog/Index';
}

function goToAdCreate() {
    window.location.href = '/Ad/Create';
}

function goToProfile() {
    window.location.href = '/Profile/Index';
}

function goToLogin() {
    window.location.href = '/Account/Login';
}
//Registration

function goToRegistrationPage() {
    window.location.href = '/Account/Index';
}
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

function clearErrorLogin() {
    let error = document.querySelector(".login-error");
    error.textContent = "";
}

//create Ad

function goToCreateAd() {
    window.location.href = '/Ad/Create';
}
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
function goToDrugInfo(id) {
    window.location.href ='/Ad/Show/' + id;
}

//CatalogPage
function changePage(event) {
    let page = event.target.textContent;
    fetch('/Catalog/Index?page=' + page)
        .then((response) => response.json())
    window.location.href = '/Catalog/Index?page=' + page;
}

function filterData(event) {
    let indexOption = event.target.options.selectedIndex;
    let idOption = event.target.options[indexOption].dataset.value;
    let searchDrug = event.target.options[indexOption].dataset.search;
    let typeSelect = document.querySelector(".catalog-filter__item__selected") as HTMLElement;
    let IdType = typeSelect != null ? typeSelect.dataset.id : "";
    fetch('/Catalog/Index?type=' + IdType + '&filter=' + idOption + '&search=' + searchDrug)
        .then(response => response.json)
    window.location.replace('/Catalog/Index?type=' + IdType + '&filter=' + idOption + '&search=' + searchDrug);    
}

function searchDrug() {
    let input = document.querySelector('.header-search__input') as HTMLInputElement;
    let drug = input.value;
    fetch('/Catalog/Index?search=' + drug)
        .then(response => response.json)
    window.location.href = '/Catalog/Index?search=' + drug;
}

//Profile
function deleteAd(event) {
    let idAd = event.target.dataset.id;
    let answer = confirm('Подтвердите удаление');

    if (answer) {
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
}

function goToLogout() {
    window.location.href = '/Account/Logout';
}