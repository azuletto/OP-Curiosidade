let html = document.querySelector("html");

let toggle_button = document.querySelector("#theme-toggle");
let toggle_label = document.querySelector("#theme-toggle-label");
let dark_icon = document.getElementById("theme-toggle-icon-light");
let light_icon = document.getElementById("theme-toggle-icon-dark");
if (localStorage.getItem("theme") === "dark-theme") {
  html.classList.add("dark-theme");
} else if (
  localStorage.getItem("theme") === null ||
  localStorage.getItem("theme") === "" ||
  localStorage.getItem("theme") === "light-theme"
) {
  html.classList.remove("dark-theme");
}
try {
  const theme = localStorage.getItem("theme") || "light-theme";
  if (theme === "dark-theme") {
    document.getElementById("theme-toggle-icon-light").style.display = "none";
    document.getElementById("theme-toggle-icon-dark").style.display =
      "inline-block";
  } else {
    document.getElementById("theme-toggle-icon-dark").style.display = "none";
    document.getElementById("theme-toggle-icon-light").style.display =
      "inline-block";
  }
} catch (e) {}
if (
  !window.location.pathname.includes("login") &&
  !window.location.pathname.includes("register-admin")
) {
  toggle_button.addEventListener("click", function () {
    document.querySelectorAll("*").forEach((element) => {
      element.style.transition = "all 0.3s linear";
    });
    if (html.classList.contains("dark-theme")) {
      html.classList.remove("dark-theme");
      localStorage.setItem("theme", "light-theme");
      document.getElementById("theme-toggle-icon-light").style.display =
        "inline-block";
      document.getElementById("theme-toggle-icon-dark").style.display = "none";
      animateIcon(dark_icon);
    } else {
      html.classList.add("dark-theme");
      localStorage.setItem("theme", "dark-theme");
      document.getElementById("theme-toggle-icon-dark").style.display =
        "inline-block";
      document.getElementById("theme-toggle-icon-light").style.display = "none";
      animateIcon(light_icon);
    }
    setTimeout(() => {
      document.querySelectorAll("*").forEach((element) => {
        element.style.transition = "none";
      });
    }, 300);
  });
}
function animateIcon(icon) {
  if (!icon) return;
  icon.style.transition = "transform 0.3s ease-in-out";
  icon.style.transform = "rotate(0deg)";
  void icon.offsetWidth;
  icon.style.transform = "rotate(360deg)";
}
