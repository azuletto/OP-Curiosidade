let table_data = JSON.parse(localStorage.getItem("users_list"));
 
let table = document.querySelector("table");


console.log(table_data)

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

        tr.appendChild(t_name)
        tr.appendChild(t_email)
        tr.appendChild(t_status)
        body.appendChild(tr)
    }

    table.appendChild(body);
}