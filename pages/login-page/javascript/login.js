import { regexEmail } from "/global/src/javascripts/email-regex.js";

const login_button = document.getElementById("login-button");
const error_message = document.getElementById("error-message");

const user = {
    username: "admin",
    password: "opcuriosidade",
    email: "admin@admin"
}

login_button.addEventListener("click", function () {



    const password = document.getElementById("password").value;
    const email = document.getElementById("email").value;

    if (regexEmail(email) === true) {
        error_message.innerHTML = ""
        if (email === user.email && password === user.password) {
            localStorage.setItem("logged_in", "true");
            localStorage.setItem("logged_in_user", JSON.stringify(user));
            window.location.href = "../dash-page/index.html";
        } else {
            error_message.innerHTML = "E-mail ou senha não encontrados."
        }
    } else {
        error_message.innerHTML = "Você inseriu um e-mail inválido. Tente novamente."
    }
})

