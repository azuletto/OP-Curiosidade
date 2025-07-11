import { loadExampleUsers } from "../model/load-example-users.js";
import * as table_sort from "../javascripts/table-sort.js";
import { deleteUser } from "./delete-user.js";
import { verifyEdit } from "./edit-user.js";
const nextButton = document.getElementById("next");
const lastButton = document.getElementById("last");
const prevButton = document.getElementById("previous");
const firstButton = document.getElementById("first");
const sort_name_tr = document.getElementById("sort-name");
const sort_email_tr = document.getElementById("sort-email");
const sort_status_tr = document.getElementById("sort-status");
const sort_timestamp = document.getElementById("sort-timestamp");
let number_page = document.getElementById("number");
let f_users_list;
let table = document.querySelector("table");
let search_input = document.querySelector(".search-bar");
let table_data = [];

if (!window.location.pathname.includes("dash")) {
  let get_set_sort = JSON.parse(localStorage.getItem("set_sort"));
  if (get_set_sort[0]) {
    document.getElementById(
      "sort-name"
    ).innerHTML = `NOME <span class="material-symbols-outlined">keyboard_arrow_up</span>`;
  } else {
    document.getElementById("sort-name").innerHTML = "NOME";
  }
  if (get_set_sort[1]) {
    document.getElementById(
      "sort-email"
    ).innerHTML = `EMAIL <span class="material-symbols-outlined">keyboard_arrow_up</span>`;
  } else {
    document.getElementById("sort-email").innerHTML = "EMAIL";
  }
  if (get_set_sort[2]) {
    document.getElementById(
      "sort-status"
    ).innerHTML = `STATUS <span class="material-symbols-outlined">keyboard_arrow_up</span>`;
  } else {
    document.getElementById("sort-status").innerHTML = "STATUS";
  }
  if (get_set_sort[3]) {
    document.getElementById(
      "sort-timestamp"
    ).innerHTML = `CRIAÇÃO <span class="material-symbols-outlined">keyboard_arrow_up</span>`;
  } else {
    document.getElementById("sort-timestamp").innerHTML = "CRIAÇÃO";
  }
}
if (window.location.pathname.includes("dash")) {
  f_users_list = table_sort.sort_by_time_stamp();
  localStorage.setItem("users_list", JSON.stringify(f_users_list));
  let set_sort = [];
  set_sort[0] = false;
  set_sort[1] = false;
  set_sort[2] = false;
  set_sort[3] = false;
  localStorage.setItem("set_sort", JSON.stringify(set_sort));
}
searchBar();
loadTable();
init_table();
updateTable();
export function clearTable() {
  let tbody = document.querySelector("tbody");
  let table = document.querySelector("table");
  if (tbody) {
    table.removeChild(tbody);
  }
}
export function init_table() {
  let page_number;
  if (
    !localStorage.getItem("page_number") ||
    window.location.pathname.includes("dash")
  ) {
    let page_number = 0;
    localStorage.setItem("page_number", JSON.stringify(page_number));
  }
  page_number = Number(localStorage.getItem("page_number"));
  let users_list = JSON.parse(localStorage.getItem("users_list"));
  let max_number_page;
  max_number_page = Math.ceil(users_list.length / 10);
  if (page_number >= max_number_page) {
    page_number = max_number_page - 1;
    localStorage.setItem("page_number", JSON.stringify(page_number));
  }
  if (!window.location.pathname.includes("dash")) {
    number_page.innerHTML = page_number + 1 + " / " + max_number_page;
  }
  let body = document.createElement("tbody");
  for (let i = 0; i < table_data[page_number].length; i++) {
    if (!table_data[page_number][i]) continue;
    let tr = document.createElement("tr");
    let t_name = document.createElement("td");
    let t_email = document.createElement("td");
    let t_status = document.createElement("td");
    let t_status_bk = document.createElement("p");
    t_status_bk.className = "status-bk";
    let t_data_create = document.createElement("td");
    t_name.innerHTML = `${table_data[page_number][i]?.name}`;
    t_email.innerHTML = `${table_data[page_number][i]?.email}`;
    t_status_bk.innerHTML = `${table_data[page_number][i]?.status}`;
    if (table_data[page_number][i].status === "Ativo") {
      t_status_bk.style.color = "var(--status-color-a)";
      t_status_bk.style.backgroundColor = "var(--status-bk-color-a)";
      t_status_bk.style.border = "1px solid var(--status-color-a)";
      t_status_bk.id = "status-a";
    } else if (table_data[page_number][i].status === "Inativo") {
      t_status_bk.style.color = "var(--status-color-i)";
      t_status_bk.style.backgroundColor = "var(--status-bk-color-i)";
      t_status_bk.style.border = "1px solid var(--status-color-i)";
      t_status_bk.id = "status-i";
    }
    t_data_create.innerHTML = new Date(table_data[page_number][i]?.time_stamp)
      .toLocaleString("pt-BR", {
        day: "2-digit",
        month: "2-digit",
        year: "numeric",
        hour: "2-digit",
        minute: "2-digit",
        hour12: false,
      })
      .replace(",", " -");
    t_status.appendChild(t_status_bk);
    tr.appendChild(t_name);
    tr.appendChild(t_email);
    tr.appendChild(t_status);
    tr.appendChild(t_data_create);
    if (window.location.pathname.includes("register")) {
      let t_edit = document.createElement("td");
      t_edit.id = "td-edit";
      let t_delete = document.createElement("td");
      const edit = true;
      t_edit.innerHTML = `
      <button id="edit-button" onclick="verifyEdit('${table_data[page_number][i]?.id}',${edit})">
          <span class="material-symbols-outlined">edit</span>
      </button>
      <button id="delete-button" onclick="deleteUser('${table_data[page_number][i]?.id}')">
          <span class="material-symbols-outlined">delete</span>
      </button>`;
      tr.appendChild(t_edit);
    }
    body.appendChild(tr);
  }
  table.appendChild(body);
}
function updateTable() {
  if (window.location.pathname.includes("dash")) {
    let page_number = 0;
    localStorage.setItem("page_number", JSON.stringify(page_number));
    return;
  }
  let users_list = JSON.parse(localStorage.getItem("users_list"));
  let page_number = JSON.parse(localStorage.getItem("page_number"));

  lastButton.addEventListener("click", function () {
    if (page_number < Math.ceil(users_list.length / 10) - 1) {
      page_number = Math.ceil(users_list.length / 10) - 1;
      localStorage.setItem("page_number", JSON.stringify(page_number));
      let tbody = document.querySelector("tbody");
      table.removeChild(tbody);
      init_table();
    } else {
      return;
    }
  });
  nextButton.addEventListener("click", function () {
    if (page_number < Math.ceil(users_list.length / 10) - 1) {
      page_number++;
      localStorage.setItem("page_number", JSON.stringify(page_number));
      let tbody = document.querySelector("tbody");
      table.removeChild(tbody);
      init_table();
    } else {
      return;
    }
  });
  prevButton.addEventListener("click", function () {
    if (page_number > 0) {
      page_number--;
      localStorage.setItem("page_number", JSON.stringify(page_number));
      let tbody = document.querySelector("tbody");
      table.removeChild(tbody);
      init_table();
    } else {
      return;
    }
  });
  firstButton.addEventListener("click", function () {
    if (page_number > 0) {
      page_number = 0;
      localStorage.setItem("page_number", JSON.stringify(page_number));
      let tbody = document.querySelector("tbody");
      table.removeChild(tbody);
      init_table();
    } else {
      return;
    }
  });
}
export function loadTable() {
  if (!localStorage.getItem("users_list")) {
    localStorage.setItem("users_list", JSON.stringify([]));
  }
  localStorage.setItem("edit_mode", JSON.stringify(false));
  let users_list = JSON.parse(localStorage.getItem("users_list")) || [];
  if (users_list.length === 0 && localStorage.getItem("users_list") === "[]") {
    users_list = loadExampleUsers();
    localStorage.setItem("users_list", JSON.stringify(users_list));
  }
  users_list = JSON.parse(localStorage.getItem("users_list"));
  let l_table_data = [];
  for (let i = 0; i < Math.ceil(users_list.length / 10); i++) {
    l_table_data.push(users_list.slice(i * 10, i * 10 + 10));
  }
  table_data = l_table_data;
  return;
}
window.pressLoad = pressLoad;
export function pressLoad() {
  let tbody = document.querySelector("tbody");
  if (tbody) table.removeChild(tbody);
  let new_body = document.createElement("tbody");
  let table_data = JSON.parse(localStorage.getItem("users_list"));
  for (let i = 0; i < table_data.length; i++) {
    let tr = document.createElement("tr");
    let t_name = document.createElement("td");
    let t_email = document.createElement("td");
    let t_status = document.createElement("td");
    let t_time_stamp = document.createElement("td");
    t_name.textContent = table_data[i].name;
    t_email.textContent = table_data[i].email;
    t_status.textContent = table_data[i].status;
    t_time_stamp.textContent = new Date(table_data[i].time_stamp)
      .toLocaleString("pt-BR", {
        day: "2-digit",
        month: "2-digit",
        year: "numeric",
        hour: "2-digit",
        minute: "2-digit",
        hour12: false,
      })
      .replace(",", " -");
    tr.appendChild(t_name);
    tr.appendChild(t_email);
    tr.appendChild(t_status);
    tr.appendChild(t_time_stamp);
    new_body.appendChild(tr);
  }
  table.appendChild(new_body);
  window.print();
  if (new_body) table.removeChild(new_body);
  init_table();
  return;
}
function searchBar() {
  if (search_input) {
    search_input.addEventListener("keyup", function () {
      if (event.key === "Enter") {
        event.preventDefault();
      }
      let filter = search_input.value.toLowerCase();
      let users_list = JSON.parse(localStorage.getItem("users_list"));
      if (window.location.pathname.includes("dash")) {
        let table_data = [];
        for (let i = 0; i < Math.ceil(users_list.length / 10); i++) {
          table_data.push(users_list.slice(i * 10, i * 10 + 10));
        }
        users_list = table_data[0];
      }
      if (filter === "") {
        let tbody = document.querySelector("tbody");
        if (tbody) table.removeChild(tbody);
        init_table();
        return;
      }
      let filtered_users = users_list.filter((user) => {
        return (
          user.name.toLowerCase().includes(filter) ||
          user.email.toLowerCase().includes(filter)
        );
      });
      let tbody = document.querySelector("tbody");
      if (tbody) table.removeChild(tbody);
      let new_body = document.createElement("tbody");
      filtered_users.forEach((user) => {
        let tr = document.createElement("tr");
        let t_name = document.createElement("td");
        let t_email = document.createElement("td");
        let t_status = document.createElement("td");
        let t_status_bk = document.createElement("p");
        t_status_bk.className = "status-bk";
        if (user.status === "Ativo") {
          t_status_bk.style.color = "var(--status-color-a)";
          t_status_bk.style.backgroundColor = "var(--status-bk-color-a)";
          t_status_bk.style.border = "1px solid var(--status-color-a)";
          t_status_bk.id = "status-a";
        } else if (user.status === "Inativo") {
          t_status_bk.style.color = "var(--status-color-i)";
          t_status_bk.style.backgroundColor = "var(--status-bk-color-i)";
          t_status_bk.style.border = "1px solid var(--status-color-i)";
          t_status_bk.id = "status-i";
        }
        let t_time_stamp = document.createElement("td");
        t_name.textContent = user.name;
        t_email.textContent = user.email;
        t_status_bk.textContent = user.status;
        t_time_stamp.textContent = new Date(user.time_stamp)
          .toLocaleString("pt-BR", {
            day: "2-digit",
            month: "2-digit",
            year: "numeric",
            hour: "2-digit",
            minute: "2-digit",
            hour12: false,
          })
          .replace(",", " -");
        t_status.appendChild(t_status_bk);
        tr.appendChild(t_name);
        tr.appendChild(t_email);
        tr.appendChild(t_status);
        tr.appendChild(t_time_stamp);
        if (window.location.pathname.includes("register")) {
          let t_edit = document.createElement("td");
          t_edit.id = "td-edit";
          let t_delete = document.createElement("td");
          t_delete.id = "td-delete";
          const edit = true;
          t_edit.innerHTML = `
          <button id="edit-button" onclick="verifyEdit('${user.id}',${edit})">
              <span class="material-symbols-outlined">edit</span>
          </button>
          
          <button id="delete-button" onclick="deleteUser('${user.id}')">
              <span class="material-symbols-outlined">delete</span>
          </button>`;
          tr.appendChild(t_edit);
        }
        new_body.appendChild(tr);
      });
      table.appendChild(new_body);
      if (!window.location.pathname.includes("dash")) {
        number_page.innerHTML = `Filtrado (${filtered_users.length} resultados)`;
      }
    });
  }
}

table.addEventListener("click", (e) => {
  const target = e.target.closest("th.sort-tr");

  if (!target) return;

  const id = target.id;
  let set_sort = JSON.parse(localStorage.getItem("set_sort")) || [
    false,
    false,
    false,
    false,
  ];
  let newState;

  switch (id) {
    case "sort-name":
      newState = !set_sort[0];
      set_sort = [newState, false, false, false];
      f_users_list = table_sort.sort_by_name();
      break;

    case "sort-email":
      newState = !set_sort[1];
      set_sort = [false, newState, false, false];
      f_users_list = table_sort.sort_by_email();
      break;

    case "sort-status":
      newState = !set_sort[2];
      set_sort = [false, false, newState, false];
      f_users_list = table_sort.sort_by_status();
      break;

    case "sort-timestamp":
      newState = !set_sort[3];
      set_sort = [false, false, false, newState];
      f_users_list = table_sort.sort_by_time_stamp();
      break;

    default:
      return;
  }

  document.getElementById("sort-name").innerHTML = set_sort[0]
    ? `NOME <span class="material-symbols-outlined">keyboard_arrow_up</span>`
    : "NOME";

  document.getElementById("sort-email").innerHTML = set_sort[1]
    ? `EMAIL <span class="material-symbols-outlined">keyboard_arrow_up</span>`
    : "EMAIL";

  document.getElementById("sort-status").innerHTML = set_sort[2]
    ? `STATUS <span class="material-symbols-outlined">keyboard_arrow_up</span>`
    : "STATUS";

  document.getElementById("sort-timestamp").innerHTML = set_sort[3]
    ? `CRIAÇÃO <span class="material-symbols-outlined">keyboard_arrow_up</span>`
    : "CRIAÇÃO";

  localStorage.setItem("set_sort", JSON.stringify(set_sort));
  localStorage.setItem("users_list", JSON.stringify(f_users_list));
  clearTable();
  loadTable();
  init_table();
});
