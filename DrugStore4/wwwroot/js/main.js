//Home
//close details
var All_Details = document.querySelectorAll('details');
All_Details.forEach(function (deet) {
    deet.addEventListener('toggle', toggleOpenOneOnly);
});
function toggleOpenOneOnly(e) {
    var _this = this;
    if (this.open) {
        All_Details.forEach(function (deet) {
            if (deet != _this && deet.open)
                deet.open = false;
        });
    }
}
function goToHomePage() {
    window.location.replace('/Home/Index');
}
function goToCatalog() {
    window.location.replace('/Catalog/Index');
}
function goToAdCreate() {
    window.location.replace('/Ad/Create');
}
function goToProfile() {
    window.location.replace('/Profile/Index');
}
function goToLogin() {
    window.location.replace('/Account/Login');
}
//Registration
function goToRegistrationPage() {
    window.location.replace('/Account/Index');
}
function registrateUser() {
    var nickname = document.querySelector(".registration-field__div input[name = 'Nickname']").value;
    var email = document.querySelector(".registration-field__div input[name = 'Email']").value;
    var telephone = document.querySelector(".registration-field__div input[name = 'Telephone']").value;
    var city = document.querySelector(".registration-field__div input[name = 'City']").value;
    var district = document.querySelector(".registration-field__div input[name = 'District']").value;
    var password = document.querySelector(".registration-field__div input[name = 'Password']").value;
    var doublePassword = document.querySelector(".registration-field__div input[name = 'DoublePassword']").value;
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
function clearErrorLogin() {
    var error = document.querySelector(".login-error");
    error.textContent = "";
}
//create Ad
function goToCreateAd() {
    window.location.replace('/Ad/Create');
}
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
        .then(function (response) { return response.json(); })
        .then(function (answer) {
        if (answer.code == 1) {
            var error = document.querySelector(".ad-error");
            error.textContent = answer.message;
        }
        else {
            window.location.replace('/Profile/Index');
        }
    });
}
//DrugInfoPage Show.cshtml
function goToDrugInfo(id) {
    window.location.replace('/Ad/Show/' + id);
}
//CatalogPage
function changePage(event) {
    var page = event.target.textContent;
    fetch('/Catalog/Index?page=' + page)
        .then(function (response) { return response.json(); });
    window.location.replace('/Catalog/Index?page=' + page);
}
function filterData(event) {
    var indexOption = event.target.options.selectedIndex;
    var idOption = event.target.options[indexOption].dataset.value;
    var searchDrug = event.target.options[indexOption].dataset.search;
    var typeSelect = document.querySelector(".catalog-filter__item__selected");
    var IdType = typeSelect != null ? typeSelect.dataset.id : "";
    fetch('/Catalog/Index?type=' + IdType + '&filter=' + idOption + '&search=' + searchDrug)
        .then(function (response) { return response.json; });
    window.location.replace('/Catalog/Index?type=' + IdType + '&filter=' + idOption + '&search=' + searchDrug);
}
function searchDrug() {
    var input = document.querySelector('.header-search__input');
    var drug = input.value;
    fetch('/Catalog/Index?search=' + drug)
        .then(function (response) { return response.json; });
    window.location.replace('/Catalog/Index?search=' + drug);
}
//Profile
function deleteAd(event) {
    var idAd = event.target.dataset.id;
    var answer = confirm('Подтвердите удаление');
    if (answer) {
        fetch('/Profile/DeleteAd/' + idAd)
            .then(function (response) { return response.json(); })
            .then(function (answer) {
            if (answer.Code == 1) {
                alert("Возникла ошибка при удалении.");
            }
            else {
                var elementTr = event.target.parentElement.parentElement;
                var elementParent = elementTr.parentElement;
                elementParent.removeChild(elementTr);
            }
        });
    }
}
function goToLogout() {
    window.location.replace('/Account/Logout');
}
//# sourceMappingURL=main.js.map