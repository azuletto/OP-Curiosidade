import { loadExampleUsers } from "../model/load-example-users.js";
import { deleteUser } from "./delete-user.js";
import { verifyEdit } from "./edit-user.js"

if (!localStorage.getItem("users_list")) {
    localStorage.setItem("users_list", JSON.stringify([]));
}

localStorage.setItem("edit_mode", JSON.stringify(false));

let table_data = JSON.parse(localStorage.getItem("users_list")) || [];

if (table_data.length === 0 && localStorage.getItem("users_list") === "[]") {
    table_data = loadExampleUsers();
    localStorage.setItem("users_list", JSON.stringify(table_data));
}

let table = document.querySelector("table");
let search_input = document.querySelector(".search-bar");

if (search_input) {
    search_input.addEventListener("keyup", function () {
        let filter = search_input.value.toLowerCase();
        let rows = table.querySelectorAll("tbody tr");

        rows.forEach(row => {
            let nameCell = row.querySelector("td:nth-child(1)");
            let emailCell = row.querySelector("td:nth-child(2)");
            let statusCell = row.querySelector("td:nth-child(3)");

            if (nameCell && emailCell && statusCell) {
                let nameText = nameCell.textContent.toLowerCase();
                let emailText = emailCell.textContent.toLowerCase();
                let statusText = statusCell.textContent.toLowerCase();

                if (nameText.includes(filter) || emailText.includes(filter) || statusText.includes(filter)) {
                    row.style.display = "";
                } else {
                    row.style.display = "none";
                }
            }
        });
    });
} else {
    console.warn("Elemento 'search-bar' não encontrado");
}

table_data = JSON.parse(localStorage.getItem("users_list"));


init_table()

function init_table() {

    let table_max;
    let body = document.createElement("tbody")

    if (window.location.pathname.includes("dash-page")) {
        table_max = 10;
        sort_by_time_stamp();
    } else {
        table_max = table_data.length;
    }

    for (let i = 0; i < table_max; i++) {

        let tr = document.createElement("tr")
        let t_name = document.createElement("td")
        let t_email = document.createElement("td")
        let t_status = document.createElement("td")

        t_name.innerHTML = `${table_data[i].name}`
        t_email.innerHTML = `${table_data[i].email}`
        t_status.innerHTML = `${table_data[i].status}`

        if (window.location.pathname.includes("cadastro-page")) {

            let t_edit = document.createElement("td")
            let t_delete = document.createElement("td")
            const edit = true;

            t_edit.innerHTML = `<button id="edit-button" onclick="verifyEdit(${table_data[i].id},${edit})"> 
            <img src="../../../pages/cadastro-page/assets/image/edit-icon.svg" alt="Edit User" width="10px" height="10px">
            </button>`
            t_delete.innerHTML = `<button id="delete-button" onclick="deleteUser(${table_data[i].id})">
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

function sort_by_time_stamp() {
    table_data.sort((a, b) => new Date(b.time_stamp) - new Date(a.time_stamp));
    localStorage.setItem("users_list", JSON.stringify(table_data));
}