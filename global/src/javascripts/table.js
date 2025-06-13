import { loadExampleUsers } from "../model/load-example-users.js";
import { deleteUser } from "./delete-user.js";
import { verifyEdit } from "./edit-user.js"

const nextButton = document.getElementById("next-page");
const prevButton = document.getElementById("previous-page");

let number_page = document.getElementById("number-page")

let table = document.querySelector("table");
let search_input = document.querySelector(".search-bar");

searchBar();
let table_data = [];
table_data = loadTable();



init_table();
updateTable();

function init_table() {



    let page_number;

    if (!localStorage.getItem("page_number")) {
        let page_number = 0;
        localStorage.setItem("page_number", String(page_number));
    }

    page_number = Number(localStorage.getItem("page_number"))

    let users_list = JSON.parse(localStorage.getItem("users_list"))
    let max_number_page;
    max_number_page = Math.ceil(users_list.length / 10);

    if (page_number >= max_number_page) {
        page_number = max_number_page - 1;
        localStorage.setItem("page_number", String(page_number))
    }

    if (!window.location.pathname.includes("dash-page")) {
        number_page.innerHTML = (page_number + 1) + "/" + max_number_page;
    }


    let body = document.createElement("tbody")

    for (let i = 0; i < table_data[page_number].length; i++) {

        if (!table_data[page_number][i]) continue;



        let tr = document.createElement("tr")

        let t_name = document.createElement("td")
        let t_email = document.createElement("td")
        let t_status = document.createElement("td")

        t_name.innerHTML = `${table_data[page_number][i]?.name}`
        t_email.innerHTML = `${table_data[page_number][i]?.email}`
        t_status.innerHTML = `${table_data[page_number][i]?.status}`


        if (window.location.pathname.includes("cadastro-page")) {

            let t_edit = document.createElement("td")
            let t_delete = document.createElement("td")
            const edit = true;

            t_edit.innerHTML = `<button id="edit-button" onclick="verifyEdit(${table_data[page_number][i]?.id},${edit})"> 
            <img src="../../../pages/cadastro-page/assets/image/edit-icon.svg" alt="Edit User" width="10px" height="10px">
            </button>`
            t_delete.innerHTML = `<button id="delete-button" onclick="deleteUser(${table_data[page_number][i]?.id})">
            <img style="color:red;" src="../../../pages/cadastro-page/assets/image/delete-icon.svg" alt="Delete user" width="10px" height="10px">
            </button>`

            tr.appendChild(t_edit)
            tr.appendChild(t_delete)
        }

        tr.appendChild(t_name)
        tr.appendChild(t_email)
        tr.appendChild(t_status)

        body.appendChild(tr)
    }
    table.appendChild(body);
}

function updateTable() {
    if(window.location.pathname.includes("dash-page")) {
        return;
    }

    let users_list = JSON.parse(localStorage.getItem("users_list"));
    let page_number = JSON.parse(localStorage.getItem("page_number"));

    nextButton.addEventListener("click", function () {
        if (page_number < Math.ceil(users_list.length / 10) - 1) {
            page_number++;
            localStorage.setItem("page_number", String(page_number))
            let tbody = document.querySelector("tbody");
            table.removeChild(tbody)
            init_table()
        } else {
            return;
        }
    })
    prevButton.addEventListener("click", function () {
        if (page_number > 0) {
            page_number--;
            localStorage.setItem("page_number", String(page_number))
            let tbody = document.querySelector("tbody");
            table.removeChild(tbody)
            init_table()
        } else {
            return;
        }
    })
}
function sort_by_time_stamp() {
    table_data.sort((a, b) => new Date(b.time_stamp) - new Date(a.time_stamp));
    localStorage.setItem("users_list", JSON.stringify(table_data));
}

function loadTable() {

    ///verifica se o localStorage já tem a lista de usuários, se não tiver, cria uma lista vazia
    if (!localStorage.getItem("users_list")) {
        localStorage.setItem("users_list", JSON.stringify([]));
    }

    ///seta como default o modo de edição desativado
    localStorage.setItem("edit_mode", JSON.stringify(false));

    ///seta a variável local com o que tem no espaço de memória e se não tiver nada, carrega o model
    let users_list = JSON.parse(localStorage.getItem("users_list")) || [];

    if (users_list.length === 0 && localStorage.getItem("users_list") === "[]") {
        users_list = loadExampleUsers();
        localStorage.setItem("users_list", JSON.stringify(users_list));
    }

    ///aqui eu tenho que carregar uma lista de listas
    users_list = JSON.parse(localStorage.getItem("users_list"));

    let table_data = [];

    for (let i = 0; i < Math.ceil(users_list.length / 10); i++) {
        table_data.push(users_list.slice((i * 10), (i * 10 + 10)));
    }

    return table_data;
}

function searchBar() {

    // se tiver o searc h input ele cria um evento de escuta, criando um filter, com o valor atual do input
    if (search_input) {
        search_input.addEventListener("keyup", function () {

            if (event.key === "Enter") {
                event.preventDefault();
            }

            let filter = search_input.value.toLowerCase();
            let users_list = JSON.parse(localStorage.getItem("users_list"));

            // Se a busca estiver vazia, ele pega e tira o body que pode ter sido criado pela busca
            // limpando assim a tabela e pedindo para renderizar normalmente.
            if (filter === "") {
                let tbody = document.querySelector("tbody");
                if (tbody) table.removeChild(tbody);
                init_table();
                return;
            }

            // cria uma variável que vai conter todos os usuários com o filtro que o input está
            // ou seja, ele retorna só os usuários que em filter, user.arg.toLowerCase().includes(input)
            // para todo usuário que inclue algo do filtro, ele é retornado.
            let filtered_users = users_list.filter(user => {
                return user.name.toLowerCase().includes(filter) ||
                    user.email.toLowerCase().includes(filter) ||
                    user.status.toLowerCase().includes(filter);
            });

            // Remove o corpo da tabela atual para poder renderizar a tabela com os usuários filtrados
            let tbody = document.querySelector("tbody");
            if (tbody) table.removeChild(tbody);

            // Cria novo corpo da tabela com os resultados filtrados, seguindo a mesma lógica da criação da tabela anterior
            let new_body = document.createElement("tbody");

            filtered_users.forEach(user => {
                let tr = document.createElement("tr");

                let t_name = document.createElement("td");
                let t_email = document.createElement("td");
                let t_status = document.createElement("td");

                t_name.textContent = user.name;
                t_email.textContent = user.email;
                t_status.textContent = user.status;

                if (window.location.pathname.includes("cadastro-page")) {
                    let t_edit = document.createElement("td");
                    let t_delete = document.createElement("td");
                    const edit = true;

                    t_edit.innerHTML = `<button id="edit-button" onclick="verifyEdit(${user.id},${edit})"> 
                        <img src="../../../pages/cadastro-page/assets/image/edit-icon.svg" alt="Edit User" width="10px" height="10px">
                        </button>`;
                    t_delete.innerHTML = `<button id="delete-button" onclick="deleteUser(${user.id})">
                        <img style="color:red;" src="../../../pages/cadastro-page/assets/image/delete-icon.svg" alt="Delete user" width="10px" height="10px">
                        </button>`;

                    tr.appendChild(t_edit);
                    tr.appendChild(t_delete);
                }

                tr.appendChild(t_name);
                tr.appendChild(t_email);
                tr.appendChild(t_status);

                new_body.appendChild(tr);
            });

            table.appendChild(new_body);

            // Atualiza o número da página para mostrar "Filtrado" em vez da paginação normal
            if (!window.location.pathname.includes("dash-page")) {
                number_page.innerHTML = `Filtrado (${filtered_users.length} resultados)`;
            }
        });
    } else {
        console.warn("Elemento 'search-bar' não encontrado");
    }
}