import { loadExampleUsers } from "../../model/load-example-users.js";

const table = document.querySelector("table");

init();

async function init() {
  const users = await loadExampleUsers();
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
    tbody.appendChild(tr);
  });

  table.appendChild(tbody);
}

function clearTable() {
  const oldBody = table.querySelector("tbody");
  if (oldBody) oldBody.remove();
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
