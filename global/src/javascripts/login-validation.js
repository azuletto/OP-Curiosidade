if (localStorage.getItem("logged_in") === null) {
  window.location.href = "../login-page/index.html?error=not_logged";
}
