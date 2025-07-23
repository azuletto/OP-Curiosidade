if (localStorage.getItem("token") === null) {
  window.location.href = "../login/index.html?error=not_logged";
}
