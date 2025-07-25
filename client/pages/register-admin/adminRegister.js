const inputs = document.querySelectorAll("input");
const errorMessages = document.querySelectorAll(".error-message");
const show_pass_btn = document.getElementById("show-pass-button");
const pass_input = document.getElementById("password");

let showPass = false;

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

inputs[2].addEventListener("input", () => {
  if (inputs[2].value.trim() !== "") {
    errorMessages[2].textContent = "";
  }
});

inputs[3].addEventListener("input", () => {
  if (inputs[3].value.trim() !== "") {
    errorMessages[3].textContent = "";
  }
});
  