const login_button = document.getElementById("login-button");

const user = {
username:"admin",
password:"opcuriosidade",
email:"admin@admin"
}

login_button.addEventListener("click", function() {

    const email = document.getElementById("email").value;
    const password = document.getElementById("password").value;

    if (email === user.email && password === user.password) {
        localStorage.setItem("logged_in", "true");
        localStorage.setItem("logged_in_user", JSON.stringify(user));
        window.location.href = "../dash-page/index.html";
    } else {
        alert("Invalid email or password. Please try again.");
    }
})