import { loadExampleUsers } from "../model/load-example-users.js";

let table_data = JSON.parse(localStorage.getItem("users_list")) || [];

if (localStorage.getItem("users_list") === null) {
    table_data = loadExampleUsers();
    localStorage.setItem("users_list", JSON.stringify(table_data));
}

let table = document.querySelector("table");

init_table()

function init_table () {

    let body = document.createElement("tbody")
    
    for (let i = 0; i < table_data.length; i++) {

        let tr = document.createElement("tr")
        let t_name = document.createElement("td")
        let t_email = document.createElement("td")
        let t_status = document.createElement("td")
        
        t_name.innerHTML = `${table_data[i].name}`
        console.log(table_data[i].name);
        t_email.innerHTML = `${table_data[i].email}`
        t_status.innerHTML = `${table_data[i].status}`

        if (window.location.pathname.includes("cadastro-page")) {
        let t_edit = document.createElement("td")
        let t_delete = document.createElement("td")

        t_edit.innerHTML = `<button id="edit-button" onclick="editUser(${table_data[i].id})"> 
        <img src="../../../pages/cadastro-page/assets/image/edit-icon.svg" alt="Edit User" width="10px" height="10px">
        </button>`
        t_delete.innerHTML = `<button id="delete-button">
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