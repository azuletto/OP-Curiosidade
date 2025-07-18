const inputs = document.querySelectorAll("input");
const errorMessages = document.querySelectorAll(".error-message");

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
