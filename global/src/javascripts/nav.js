const menuHamburguer = document.getElementById("hamburguer-button")
const hideNav = document.getElementById("hide-nav")
const geralContent = document.getElementById("geral-container")
const nav = document.getElementById("nav")

if(window.innerWidth <= 740) {nav.style.display = "none"
    geralContent.style.marginLeft = 0
}
menuHamburguer.style.display = "none"
menuHamburguer.addEventListener("click", () => { open_nav() })
hideNav.addEventListener("click", () => { close_nav() })


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
    if(screenWidth <= 740) {
        nav.style.width = "50%"
    } else {nav.style.width = "12%"}

    geralContent.style.marginLeft = "12%"
    nav.style.display = "flex"
    
    menuHamburguer.style.display = "none"

}

function close_nav() {

    geralContent.style.marginLeft = 0;
    nav.style.display = "none"
    menuHamburguer.style.display = "flex"

}