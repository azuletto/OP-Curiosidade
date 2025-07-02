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
const user_age = document.getElementById("user_age");
let email_error = document.getElementById("email-error");
let name_error = document.getElementById("name-error");
let age_error = document.getElementById("age-error");
let adress_error = document.getElementById("error-input");
let user_info_error = document.getElementById("error-input-1");
let user_interess_error = document.getElementById("error-input-2");
let user_feelings_error = document.getElementById("error-input-3");
let user_valors_error = document.getElementById("error-input-4");


if(window.location.pathname.includes("cadastro-page")) {
    exitButton.addEventListener("click", function (e) {
        clearModal();
        e.preventDefault();
    });
    modal.addEventListener("close", function (e) {
        clearModal();
    });
    user_age.addEventListener("keyup", () => {
        let user_age_input = user_age.value
        const date = new Date().toISOString().split('T')[0];
        if (user_age_input > date) {
            user_age.value = date
        }
    })
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
            user.status = document.getElementById("user_status").checked ? "Ativo" : "Inativo";
            user.time_stamp = new Date().toISOString();
    
    
            if (!verfifyUser(user)) {
                e.preventDefault();
                return Error
            }
            verifyStorage();
            saveUser(user);
    
        }
    });
}


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
    document.getElementById("email-error").innerHTML = "";
    document.getElementById("name-error").innerHTML = "";
    document.getElementById("age-error").innerHTML = "";
    document.getElementById("error-input").innerHTML = "";
    document.getElementById("error-input-1").innerHTML = "";
    document.getElementById("error-input-2").innerHTML = "";
    document.getElementById("error-input-3").innerHTML = "";
    document.getElementById("error-input-4").innerHTML = "";
}

export function verfifyUser(user) {

    email_error.innerHTML = "";
    name_error.innerHTML = "";
    age_error.innerHTML = "";
    adress_error.innerHTML = "";
    user_info_error.innerHTML = "";
    user_interess_error.innerHTML = "";
    user_feelings_error.innerHTML = "";
    user_valors_error.innerHTML = "";



    if (String(user.name).trim() === "") {
        name_error.innerHTML = "O campo de nome não pode estar vazio."
        document.getElementById("user_name").scrollIntoView({
            behavior: 'smooth',
            block: 'center'
        });
        return false;
    }
    if (String(user.email).trim() === "") {
        document.getElementById("user_email").scrollIntoView({
            behavior: 'smooth',
            block: 'center'
        });
        email_error.innerHTML = "O campo de e-mail não pode estar vazio.";
        return false;
    }
    if (regexEmail(user.email) !== true) {
        document.getElementById("user_email").scrollIntoView({
            behavior: 'smooth',
            block: 'center'
        });
        email_error.innerHTML = "Você inseriu um e-mail inválido. Tente novamente.";
        return false;
    }
    let edit_mode = JSON.parse(localStorage.getItem("edit_mode"))
    if (!edit_mode) {
        if (users_list.some(u => u.email === user.email)) {
            document.getElementById("user_email").scrollIntoView({
                behavior: 'smooth',
                block: 'center'
            });
            email_error.innerHTML = "E-mail já cadastrado.";
            return false;
        }
    }
    if(user_age.value < new Date("1920-01-01").toISOString().split('T')[0] ||
       user_age.value > new Date().toISOString().split('T')[0]) {
        document.getElementById("user_age").scrollIntoView({
            behavior: 'smooth',
            block: 'center'
        });
        age_error.innerHTML = "Data de nascimento inválida.";
        return false;
    }
    if(String(user.adress).trim() === "") {
        document.getElementById("user_adress").scrollIntoView({
            behavior: 'smooth',
            block: 'center'
        });
        adress_error.innerHTML = "O campo de endereço não pode estar vazio.";
        return false;
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