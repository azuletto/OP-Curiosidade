import { regexEmail } from "../../global/src/javascripts/email-regex.js";
import { API_URL } from "../config.js";
const inputs = document.querySelectorAll("input");
const errorMessages = document.querySelectorAll(".error-message");
const login_button = document.getElementById("login-button");
const error_message = document.querySelectorAll(".error-message");
const login_error_message = document.getElementById("login-error-message");
const show_pass_btn = document.getElementById("show-pass-button");
const pass_input = document.getElementById("password");
const urlParams = new URLSearchParams(window.location.search);
const errorParam = urlParams.get("error");
const registeredParam = urlParams.get("success");

let showPass = false;
let host = API_URL;

if (errorParam === "not_logged") {
  login_error_message.innerHTML =
    "Você <strong>não está logado</strong>, entre com um usuário para continuar.";
}
if (registeredParam === "registered") {
  login_error_message.style.color = "var(--success-color)";
  login_error_message.innerHTML =
    "Você se registrou com sucesso, agora faça o login.";
}

login_button.addEventListener("click", async function () {
  login_error_message.innerHTML = "";

  const password = pass_input.value;
  const email = document.getElementById("email").value;

  if (!regexEmail(email)) {
    error_message[0].innerHTML = "Digite um e-mail válido.";
    return;
  }

  try {
    const response = await fetch(`${host}/Admin/login`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({ email, password }),
    });

    const data = await response.json();
    console.log("Login response:", data);

    if (!response.ok) {
      login_error_message.innerHTML = data.message || "Erro ao fazer login.";
      return;
    } else {
      localStorage.setItem("token", data.data.token);
    }
  } catch (error) {
    console.error("Erro na requisição:", error);
    login_error_message.innerHTML = "Erro ao se conectar com o servidor.";
  }
});

show_pass_btn.addEventListener("click", (event) => {
  event.preventDefault();
  showPass = !showPass;
  pass_input.type = showPass ? "text" : "password";
  document.getElementById(
    "show-pass-icon"
  ).innerHTML = `<span class="material-symbols-outlined">
    ${showPass ? "visibility" : "visibility_off"}
  </span>`;
});
inputs[0].addEventListener("input", () => {
  if (inputs[0].value.trim() !== "") {
    errorMessages[0].textContent = "";
  }
});
inputs[1].addEventListener("input", () => {
  if (inputs[1].value.trim() !== "") {
    errorMessages[1].textContent = "";
  }
});
