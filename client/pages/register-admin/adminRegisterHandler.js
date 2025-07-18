const nameInput = document.getElementById("name");
const emailInput = document.getElementById("email");
const passwordInput = document.getElementById("password");
const passwordConfirmInput = document.getElementById("password-confirm");
const loginErrorMessage = document.getElementById("login-error-message");
const loginButton = document.getElementById("login-button");
import { API_URL as host } from "../config.js";

loginButton.addEventListener("click", async (event) => {
  console.log("Register button clicked");
  event.preventDefault();

  const name = nameInput.value.trim();
  const email = emailInput.value.trim();
  const password = passwordInput.value.trim();
  const passwordConfirm = passwordConfirmInput.value.trim();

  if (password !== passwordConfirm) {
    loginErrorMessage.textContent = "Passwords do not match.";
    return;
  }

  try {
    const response = await fetch(`${host}/Admin`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({ name, email, password }),
    });

    if (!response.ok) {
      const errorData = await response.json();
      console.log("Error response:", errorData);
      loginErrorMessage.textContent =
        errorData.message || "Registration failed.";
      return;
    }
  } catch (error) {
    console.error("Error during registration:", error);
    loginErrorMessage.textContent =
      "An unexpected error occurred. Please try again.";
  }
});
