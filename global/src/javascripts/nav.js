const menuHamburguer = document.getElementById("hamburguer-button")
const hideNav = document.getElementById("hide-nav")
const geralContent = document.getElementById("geral-container")
const nav = document.getElementById("nav")

const itensMenu = document.querySelectorAll('.nav-list');


if (window.location.pathname.includes("dash-page")) {
    itensMenu[0].style.background = "var(--principal-color)";
    itensMenu[0].style.width = '90%';
}
if (window.location.pathname.includes("cadastro-page")) {
    itensMenu[1].style.background = "var(--principal-color)";
    itensMenu[1].style.width = '90%';
}
if (window.location.pathname.includes("report-page")) {
    itensMenu[2].style.background = "var(--principal-color)";
    itensMenu[2].style.width = '90%';
}


const itemRelatorios = [...itensMenu].find(item => 
  item.textContent.includes('Relatórios')
);


if(window.innerWidth <= 740) {nav.style.display = "none"
    menuHamburguer.style.display = "flex"
    geralContent.style.marginLeft = 0
} else {
    menuHamburguer.style.display = "none"
}

menuHamburguer.addEventListener("click", () => { open_nav() })
//hideNav.addEventListener("click", () => { close_nav() })


function open_nav() {
let screenWidth = window.innerWidth;

    nav.animate(
        [
            {opacity: 0},
            {opacity: 1}
        ],
        {
            duration: 300,
            easing: 'ease-in-out',
            fill: "forwards"
        }
    )


    geralContent.style.marginLeft = "12%"
    nav.style.display = "flex"
    
    menuHamburguer.style.display = "none"

}

function close_nav() {

    geralContent.style.marginLeft = 0;
    nav.style.display = "none"
    menuHamburguer.style.display = "flex"

}