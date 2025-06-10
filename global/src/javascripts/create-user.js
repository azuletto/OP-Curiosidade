import { regexEmail } from "/global/src/javascripts/email-regex.js";

let user = {
    name: "",
    age: "",
    email: "",
    adress: "",
    info: "",
    interess: "",
    feelings: "",
    valors: "",
    id: "0",
    time_stamp: "",
    status: ""
};

if (!localStorage.getItem("users_list")) {
    localStorage.setItem("users_list", JSON.stringify([]));
}

let users_list = [];
users_list = JSON.parse(localStorage.getItem("users_list")) || [];

const submitButton = document.getElementById("submit-button");
const exitButton = document.getElementById("exit-register-modal");
let error_message = document.getElementById("error-message");

exitButton.addEventListener("click", function (e) {
    clearModal();
    e.preventDefault();
});
modal.addEventListener("close", function (e) {
    clearModal();
});




submitButton.addEventListener("click", function (e) {



    let editMode = JSON.parse(localStorage.getItem("edit_mode"));

    if (editMode === false) {
        user.name = document.getElementById("user_name").value;
        user.age = document.getElementById("user_age").value;
        user.email = document.getElementById("user_email").value;
        user.adress = document.getElementById("user_adress").value;
        user.info = document.getElementById("user_info").value;
        user.interess = document.getElementById("user_interess").value;
        user.feelings = document.getElementById("user_feelings").value;
        user.valors = document.getElementById("user_valors").value;
        user.status = document.getElementById("user_status").checked ? "active" : "inactive";
        user.time_stamp = new Date().toISOString();


        if (!verfifyUser(user)) {
            e.preventDefault();
            return error_message;
        }
        verifyStorage();
        saveUser(user);

    }
});

function clearModal() {

    document.getElementById("user_name").value = ""
    document.getElementById("user_age").value = ""
    document.getElementById("user_email").value = ""
    document.getElementById("user_adress").value = ""
    document.getElementById("user_info").value = ""
    document.getElementById("user_interess").value = ""
    document.getElementById("user_feelings").value = ""
    document.getElementById("user_valors").value = ""
    document.getElementById("user_status").checked = false;
    document.getElementById("error-message").innerHTML = "";

}

function verfifyUser(user) {

    error_message.innerHTML = "";


    if (String(user.email).trim() === "") {
        error_message.innerHTML = "O campo de e-mail não pode estar vazio.";
        return false;
    }


    if (regexEmail(user.email) !== true) {
        error_message.innerHTML = "Você inseriu um e-mail inválido. Tente novamente.";
        return false;
    }


    if (users_list.some(u => u.email === user.email)) {
        error_message.innerHTML = "E-mail já cadastrado.";
        return false;
    }


    const requiredFields = ['name', 'age', 'adress', 'info', 'interess', 'feelings', 'valors'];
    for (let key of requiredFields) {
        if (!user[key] || String(user[key]).trim() === "") {
            error_message.innerHTML = `O campo ${key} não pode estar vazio.`;
            return false;
        }
    }


    return true;
}

function saveUser(user) {
    if (users_list.length === 0) {
        user.id = 1;
    }
    else {
        (user.id) = Number(users_list[users_list.length - 1].id) + 1;
    }
    users_list.push(user);
    localStorage.setItem("users_list", JSON.stringify(users_list));
    window.location.reload();
}

function verifyStorage() {
    if (!localStorage.getItem("users_list")) {
        localStorage.setItem("users_list", JSON.stringify([]));
    } else {
        users_list = JSON.parse(localStorage.getItem("users_list"));
    }
}