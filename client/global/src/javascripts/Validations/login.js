const logOutButton = document.getElementById("logout-area");
const userNameElement = document.getElementById("username");
const user_name = JSON.parse(localStorage.getItem("logged_in_user"));
userNameElement.textContent = user_name;
logOutButton.addEventListener("click", function () {
  localStorage.removeItem("token");
  window.location.href = "../login/index.html";
});
