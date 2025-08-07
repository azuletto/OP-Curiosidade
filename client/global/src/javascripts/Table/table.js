import { loadExampleUsers } from "../../model/load-example-users.js";
import { getTotalUsersCount } from "../../../../pages/dash/get-users-handler.js";
import { verifyEdit } from "../CRUD/edit-user.js";
import { deleteUser } from "../CRUD/delete-user.js";
import { API_URL } from "../../../../config.js";
import { clearSortButtons } from "./table-sort.js";

const input = document.getElementsByClassName("search-bar")[0];
const paginationButtons = document.getElementById("pagination-buttons");
let query_data = [];
let timeout;

input.addEventListener("input", () => {
  clearTimeout(timeout);

  timeout = setTimeout(() => {
    const query = input.value.trim();
    clearSortButtons();
    if (query) {
      paginationButtons.style.display = "none";
      console.log("Buscando por:", query);
      fetch(`${API_URL}/search?searchTerm=${query}`)
        .then((res) => res.json())
        .then((data) => {
          query_data = data;
          renderTable(query_data.data);
        });
    } else {
      paginationButtons.style.display = "flex";
      console.log("Input vazio. Reiniciando...");
      init(); // <- sua função para restaurar o estado original
    }
  }, 1000);
});

let filterStatus = 0;
let filterType = {
  filterByName: false,
  filterByTimeStamp: true,
  filterByStatus: false,
  filterByEmail: false,
};

function inDash() {
  if (window.location.pathname.includes("dash")) {
    return true;
  }
  return false;
}

const table = document.querySelector("table");
if (localStorage.getItem("page") === null) {
  localStorage.setItem("page", "1");
}

export function getCurrentPage() {
  if (inDash()) {
    return 1;
  }
  let current_page = parseInt(localStorage.getItem("page"));
  if (!current_page || isNaN(current_page)) {
    current_page = 1;
  }
  return current_page;
}

const totalUsers = await getTotalUsersCount();
export const rowsPerPage = 10;
const totalPages = Math.ceil(totalUsers / rowsPerPage);

const nextButton = document.getElementById("next");
const prevButton = document.getElementById("previous");
const lastPageButton = document.getElementById("last");
const firstPageButton = document.getElementById("first");

const numberDisplay = document.getElementById("number");
if (!inDash()) {
  numberDisplay.textContent = `${getCurrentPage()} / ${totalPages}`;
}

init();

export async function init(payload) {
  const currentPage = getCurrentPage();
  if (inDash()) {
    payload = {
      skipTable: (currentPage - 1) * rowsPerPage,
      filterStatus: 0,
      FilterType: {
        filterByName: false,
        filterByTimeStamp: true,
        filterByStatus: false,
        filterByEmail: false,
      },
    };
  } else {
    if (!payload) {
      payload = {
        skipTable: (currentPage - 1) * rowsPerPage,
        filterStatus: 0,
        FilterType: {
          filterByName: false,
          filterByTimeStamp: true,
          filterByStatus: false,
          filterByEmail: false,
        },
      };
    }
  }
  const users = await loadExampleUsers(payload);
  renderTable(users);
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
    if (window.location.pathname.includes("register")) {
      const tdActions = createActionCell(user.id);
      tr.append(tdActions);
    }
    tbody.appendChild(tr);
  });

  table.appendChild(tbody);
}

export function clearTable() {
  const oldBody = table.querySelector("tbody");
  if (oldBody) oldBody.remove();
}

function createCell(text) {
  const td = document.createElement("td");
  td.textContent = text;
  return td;
}

function createActionCell(userId) {
  const tdActions = document.createElement("td");

  const deleteButton = document.createElement("button");
  deleteButton.id = "delete-button";
  const editButton = document.createElement("button");
  editButton.id = "edit-button";

  editButton.innerHTML = `<span class="material-symbols-outlined">edit</span>`;
  editButton.onclick = () => {
    localStorage.setItem("edit_mode", JSON.stringify(true));
    verifyEdit(userId, true);
  };

  deleteButton.innerHTML = `<span class="material-symbols-outlined">delete</span>`;
  deleteButton.onclick = () => deleteUser(userId);

  tdActions.appendChild(editButton);
  tdActions.appendChild(deleteButton);

  return tdActions;
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

if (!inDash()) {
  nextButton.addEventListener("click", async () => {
    let currentPage = getCurrentPage();
    if (currentPage < totalPages) {
      currentPage++;
      localStorage.setItem("page", currentPage.toString());
      numberDisplay.textContent = `${currentPage} / ${totalPages}`;
      await loadAndRenderUsers(currentPage, rowsPerPage);
    }
  });

  prevButton.addEventListener("click", async () => {
    let currentPage = getCurrentPage();
    if (currentPage > 1) {
      currentPage--;
      localStorage.setItem("page", currentPage.toString());
      numberDisplay.textContent = `${currentPage} / ${totalPages}`;
      await loadAndRenderUsers(currentPage, rowsPerPage);
    }
  });

  lastPageButton.addEventListener("click", async () => {
    localStorage.setItem("page", totalPages.toString());
    numberDisplay.textContent = `${totalPages} / ${totalPages}`;
    await loadAndRenderUsers(totalPages, rowsPerPage);
  });

  firstPageButton.addEventListener("click", async () => {
    localStorage.setItem("page", "1");
    numberDisplay.textContent = `1 / ${totalPages}`;
    await loadAndRenderUsers(1, rowsPerPage);
  });
}
async function loadAndRenderUsers(currentPage, rowsPerPage) {
  let payload = {
    skipTable: (currentPage - 1) * rowsPerPage,
    filterStatus: getFilterStatus(),
    FilterType: {
      filterByName: false,
      filterByTimeStamp: true,
      filterByStatus: false,
      filterByEmail: false,
    },
  };

  function getFilterStatus() {
    let status = localStorage.getItem("sort-status");
    if (status === null) {
      return 0;
    }
    return parseInt(status);
  }

  const filterType = localStorage.getItem("sort");
  switch (filterType) {
    case "name":
      payload.FilterType.filterByName = true;
      payload.FilterType.filterByTimeStamp = false;
      payload.FilterType.filterByStatus = false;
      payload.FilterType.filterByEmail = false;
      break;

    case "email":
      payload.FilterType.filterByEmail = true;
      payload.FilterType.filterByTimeStamp = false;
      payload.FilterType.filterByName = false;
      payload.FilterType.filterByStatus = false;
      break;

    case "status":
      payload.FilterType.filterByStatus = true;
      payload.FilterType.filterByTimeStamp = false;
      payload.FilterType.filterByName = false;
      payload.FilterType.filterByEmail = false;
      break;

    case "timestamp":
      payload.FilterType.filterByTimeStamp = true;
      payload.FilterType.filterByName = false;
      payload.FilterType.filterByStatus = false;
      payload.FilterType.filterByEmail = false;
      break;
  }
  const users = await loadExampleUsers(payload);
  renderTable(users);
}
