import { regexEmail } from "/global/src/javascripts/email-regex.js";
const login_button = document.getElementById("login-button");
const error_message = document.querySelectorAll(".error-message");
const login_error_message = document.getElementById("login-error-message");
const show_pass_btn = document.getElementById("show-pass-button");
const pass_input = document.getElementById("password");
const urlParams = new URLSearchParams(window.location.search);
const errorParam = urlParams.get("error");
let showPass;
if (errorParam === "not_logged") {
  login_error_message.innerHTML =
    "Você <strong>não está logado</strong>, entre com um usuário para continuar.";
}
const user = {
  username: "Administrador",
  password: "opcuriosidade",
  email: "admin@curiosidade.com",
};
login_button.addEventListener("click", function () {
  if (login_error_message) {
    login_error_message.innerHTML = "";
  }
  console.log(error_message);
  const password = document.getElementById("password").value;
  const email = document.getElementById("email").value;
  if (regexEmail(email) === true) {
    error_message[0].innerHTML = "";
    if (email === user.email && password === user.password) {
      localStorage.setItem("logged_in", "true");
      localStorage.setItem("logged_in_user", JSON.stringify(user));
      window.location.href = "../dash/index.html";
    } else if (email === user.email && password !== user.password) {
      error_message[1].innerHTML = "";
      error_message[1].innerHTML = "Senha incorreta. Tente novamente.";
    }
  } else {
    error_message[0].innerHTML =
      "Você inseriu um e-mail inválido. Tente novamente.";
  }
});
show_pass_btn.addEventListener("click", () => {
  event.preventDefault();
  if (!showPass) {
    showPass = true;
    pass_input.type = "text";
    document.getElementById(
      "show-pass-icon"
    ).innerHTML = `<span class="material-symbols-outlined">visibility</span>`;
  } else if (showPass) {
    showPass = false;
    pass_input.type = "password";
    document.getElementById(
      "show-pass-icon"
    ).innerHTML = `<span class="material-symbols-outlined">visibility_off</span>`;
  }
});
