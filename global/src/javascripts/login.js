const logOutButton = document.getElementById('logout-area');
const userNameElement = document.getElementById('username');

const user_name = JSON.parse(localStorage.getItem('logged_in_user')).username

userNameElement.textContent = user_name;

logOutButton.addEventListener('click', function () {
    localStorage.removeItem('logged_in');
    window.location.href = '../login-page/index.html';
})