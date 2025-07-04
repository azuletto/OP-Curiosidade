import { regexEmail } from "/global/src/javascripts/email-regex.js";
const login_button = document.getElementById("login-button");
const error_message = document.getElementById("error-message");
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
  const password = document.getElementById("password").value;
  const email = document.getElementById("email").value;
  if (regexEmail(email) === true) {
    error_message.innerHTML = "";
    if (email === user.email && password === user.password) {
      localStorage.setItem("logged_in", "true");
      localStorage.setItem("logged_in_user", JSON.stringify(user));
      window.location.href = "../dash-page/index.html";
    } else {
      error_message.innerHTML = "E-mail ou senha não encontrados.";
    }
  } else {
    error_message.innerHTML =
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
