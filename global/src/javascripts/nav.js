const geralContent = document.getElementById("geral-container");
const nav = document.getElementById("nav");
const itensMenu = document.querySelectorAll(".nav-list");
const textsMenu = document.querySelectorAll(".nav-list p");
if (window.location.pathname.includes("dash-page")) {
  itensMenu[0].style.background = "var(--principal-color)";
  itensMenu[0].style.width = "85.9% ";
  textsMenu[0].style.fontWeight = "bold";
}
if (window.location.pathname.includes("cadastro-page")) {
  itensMenu[1].style.background = "var(--principal-color)";
  itensMenu[1].style.width = "85.9%";
  textsMenu[1].style.fontWeight = "bold";
}
if (window.location.pathname.includes("report-page")) {
  itensMenu[2].style.background = "var(--principal-color)";
  itensMenu[2].style.width = "85.9%";
  textsMenu[2].style.fontWeight = "bold";
}
const itemRelatorios = [...itensMenu].find((item) =>
  item.textContent.includes("Relatórios")
);
