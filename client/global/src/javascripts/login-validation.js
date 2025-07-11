if (localStorage.getItem("logged_in") === null) {
  window.location.href = "../login/index.html?error=not_logged";
}
