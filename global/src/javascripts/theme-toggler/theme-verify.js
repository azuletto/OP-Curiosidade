verifyTheme();
if (!window.location.pathname.includes("login-page")) {
  toggleSetter();
}
function verifyTheme() {
  try {
    const theme = localStorage.getItem("theme") || "light-theme";
    document.documentElement.classList.add(theme);
    if (theme === "dark-theme") {
      document.getElementById("theme-toggle").checked = false;
    }
  } catch (e) {
    console.error();
  }
}
function toggleSetter() {
  document.addEventListener("DOMContentLoaded", () => {
    const theme = localStorage.getItem("theme") || "light-theme";
    let toggle = document.getElementById("theme-toggle");
    let toggle_label = document.getElementById("theme-toggle-label");
    if (theme === "dark-theme") {
      toggle_label.classList.add("no-transition");
      setTimeout(() => {
        toggle_label.classList.remove("no-transition");
      }, 300);
      toggle.checked = true;
    } else {
      toggle_label.classList.add("no-transition");
      setTimeout(() => {
        toggle_label.classList.remove("no-transition");
      }, 300);
      toggle.checked = false;
    }
  });
}
