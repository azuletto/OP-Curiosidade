if (localStorage.getItem('logged_in') === false || localStorage.getItem('logged_in') === null) {
    window.location.href = '../login-page/index.html';
}