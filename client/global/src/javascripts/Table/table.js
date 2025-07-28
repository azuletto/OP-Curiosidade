import { loadExampleUsers } from "../../model/load-example-users.js";

const table = document.querySelector("table");

if (window.location.pathname.includes("dash")) { init_table(); }
if (window.location.pathname.includes("register")) { init_register_table(); }

export async function init_table() {
  const users = await loadExampleUsers();
  renderTable(users);
}
export async function init_register_table() {
  // Configura ordenação inicial
  if (!localStorage.getItem("set_sort")) {
    localStorage.setItem("set_sort", JSON.stringify([false, false, false, false]));
  }
  
  // Configura paginação inicial
  if (!localStorage.getItem("page_number")) {
    localStorage.setItem("page_number", "0");
  }
  
  current_page = parseInt(localStorage.getItem("page_number"));
  renderRegisterTable(users);
    setupPagination(users);
    setupSorting();
    setupSearch();
}
function renderRegisterTable(users) {
  clearTable();
  loadTableData(users);
  renderTablePage(current_page);
}
function renderTable(users) {
  clearTable();

  const tbody = document.createElement("tbody");

  users.forEach((user) => {
    const tr = document.createElement("tr");

    const tdName = createCell(user.name);
    const tdEmail = createCell(user.email);
    const tdStatus = createStatusCell(user.status);
    const tdDate = createCell(formatDate(user.timeStamp));

    tr.append(tdName, tdEmail, tdStatus, tdDate);
    tbody.appendChild(tr);
  });

  table.appendChild(tbody);
}

export function clearTable() {
  const oldBody = table.querySelector("tbody");
  if (oldBody) oldBody.remove();
}
function loadTableData(users) {
  table_data = [];
  for (let i = 0; i < Math.ceil(users.length / 10); i++) {
    table_data.push(users.slice(i * 10, i * 10 + 10));
  }
}
function renderTablePage(page) {
  clearTable();
  const tbody = document.createElement("tbody");

  table_data[page]?.forEach((user) => {
    const tr = document.createElement("tr");
    tr.append(
      createCell(user.name),
      createCell(user.email),
      createStatusCell(user.status),
      createCell(formatDate(user.timeStamp)),
      createActionsCell(user.id, true)
    );
    tbody.appendChild(tr);
  });

  table.appendChild(tbody);
  updatePageInfo();
} 
function createActionsCell(userId, canEdit = true) {
  const td = document.createElement("td");
  td.className = "actions-cell";
  
  if (canEdit) {
    const editButton = document.createElement("button");
    editButton.className = "action-button";
    editButton.innerHTML = '<span class="material-symbols-outlined">edit</span>';
    editButton.onclick = () => verifyEdit(userId, canEdit);
    td.appendChild(editButton);
  }
  
  const deleteButton = document.createElement("button");
  deleteButton.className = "action-button";
  deleteButton.innerHTML = '<span class="material-symbols-outlined">delete</span>';
  deleteButton.onclick = () => deleteUser(userId);
  td.appendChild(deleteButton);
  
  return td;
}
function setupPagination(users) {
  nextButton.addEventListener("click", () => {
    if (current_page < table_data.length - 1) {
      current_page++;
      localStorage.setItem("page_number", current_page.toString());
      renderTablePage(current_page);
    }
  });

  prevButton.addEventListener("click", () => {
    if (current_page > 0) {
      current_page--;
      localStorage.setItem("page_number", current_page.toString());
      renderTablePage(current_page);
    }
  });

  firstButton.addEventListener("click", () => {
    current_page = 0;
    localStorage.setItem("page_number", "0");
    renderTablePage(0);
  });

  lastButton.addEventListener("click", () => {
    current_page = table_data.length - 1;
    localStorage.setItem("page_number", current_page.toString());
    renderTablePage(current_page);
  });
}
function updatePageInfo() {
  if (number_page) {
    number_page.textContent = `${current_page + 1} / ${table_data.length}`;
  }
}
function setupSorting() {
  const sortHeaders = document.querySelectorAll("th.sort-tr");
  
  sortHeaders.forEach(header => {
    header.addEventListener("click", () => {
      const id = header.id;
      let set_sort = JSON.parse(localStorage.getItem("set_sort"));
      let newState;
      
      // Reset all sort states
      set_sort = set_sort.map(() => false);
      
      switch(id) {
        case "sort-name":
          newState = !set_sort[0];
          set_sort[0] = newState;
          f_users_list = table_sort.sort_by_name();
          break;
        case "sort-email":
          newState = !set_sort[1];
          set_sort[1] = newState;
          f_users_list = table_sort.sort_by_email();
          break;
        case "sort-status":
          newState = !set_sort[2];
          set_sort[2] = newState;
          f_users_list = table_sort.sort_by_status();
          break;
        case "sort-timestamp":
          newState = !set_sort[3];
          set_sort[3] = newState;
          f_users_list = table_sort.sort_by_time_stamp();
          break;
      }
      
      // Update UI
      updateSortIcons(set_sort);
      
      // Save state and reload table
      localStorage.setItem("set_sort", JSON.stringify(set_sort));
      localStorage.setItem("users_list", JSON.stringify(f_users_list));
      
      // Reset to first page
      current_page = 0;
      localStorage.setItem("page_number", "0");
      loadTableData(f_users_list);
      renderTablePage(0);
    });
  });
}
function updateSortIcons(set_sort) {
  const icons = {
    "sort-name": set_sort[0],
    "sort-email": set_sort[1],
    "sort-status": set_sort[2],
    "sort-timestamp": set_sort[3]
  };
  
  for (const [id, isActive] of Object.entries(icons)) {
    const element = document.getElementById(id);
    if (element) {
      element.innerHTML = isActive 
        ? `${id.replace('sort-', '').toUpperCase()} <span class="material-symbols-outlined">keyboard_arrow_up</span>`
        : id.replace('sort-', '').toUpperCase();
    }
  }
}
function createCell(text) {
  const td = document.createElement("td");
  td.textContent = text;
  return td;
}

function createStatusCell(status) {
  const td = document.createElement("td");
  const p = document.createElement("p");
  p.className = "status-bk";
  p.textContent = status ? "Ativo" : "Inativo";

  if (status) {
    p.style.color = "var(--status-color-a)";
    p.style.backgroundColor = "var(--status-bk-color-a)";
    p.style.border = "1px solid var(--status-color-a)";
    p.id = "status-a";
  } else {
    p.style.color = "var(--status-color-i)";
    p.style.backgroundColor = "var(--status-bk-color-i)";
    p.style.border = "1px solid var(--status-color-i)";
    p.id = "status-i";
  }

  td.appendChild(p);
  return td;
}

function formatDate(timestamp) {
  return new Date(timestamp)
    .toLocaleString("pt-BR", {
      day: "2-digit",
      month: "2-digit",
      year: "numeric",
      hour: "2-digit",
      minute: "2-digit",
      hour12: false,
    })
    .replace(",", " -");
}
