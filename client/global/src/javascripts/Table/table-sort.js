import { init, getCurrentPage, rowsPerPage } from "./table.js";

const sortByNameButton = document.getElementById("sort-name");
const sortByEmailButton = document.getElementById("sort-email");
const sortByStatusButton = document.getElementById("sort-status");
const sortByTimeStampButton = document.getElementById("sort-timestamp");
const sortName = document.getElementById("sort-name");
const sortEmail = document.getElementById("sort-email");
const sortStatusElement = document.getElementById("sort-status");
const sortTimeStamp = document.getElementById("sort-timestamp");

let currentSort = localStorage.getItem("sort");

function loadFilterStatus() {
  let sortStatus = localStorage.getItem("sort-status");
  if (!sortStatus) {
    sortStatus = "0";
  }
  switch (sortStatus) {
    case "0":
      sortStatus = "1";
      break;
    case "1":
      sortStatus = "2";
      break;
    default:
      sortStatus = "0";
  }
  localStorage.setItem("sort-status", sortStatus);
  return sortStatus;
}

if (!currentSort) {
  currentSort = "timestamp";
  let payload = {
    skipTable: (currentPage - 1) * rowsPerPage,
    filterStatus: 0,
    FilterType: {
      filterByName: false,
      filterByTimeStamp: true,
      filterByStatus: false,
      filterByEmail: false,
    },
  };
  init(payload);
  localStorage.setItem("sort", currentSort);
}
function clearSortButtons() {
  sortName.innerHTML = "NOME";
  sortEmail.innerHTML = "EMAIL";
  sortStatusElement.innerHTML = "STATUS";
  sortTimeStamp.innerHTML = "CRIAÇÃO";
}
function loadIconSortButtons(string) {
  const sortStatus = localStorage.getItem("sort-status");
  switch (string) {
    case "name":
      clearSortButtons();
      sortName.innerHTML =
        sortStatus === "0" ? "NOME ▼" : sortStatus === "1" ? "NOME ▲" : "NOME";
      break;

    case "email":
      clearSortButtons();
      sortEmail.innerHTML =
        sortStatus === "0"
          ? "EMAIL ▼"
          : sortStatus === "1"
          ? "EMAIL ▲"
          : "EMAIL";
      break;

    case "status":
      console.log("Status sort clicked");
      clearSortButtons();
      sortStatusElement.innerHTML =
        sortStatus === "0"
          ? "STATUS ▼"
          : sortStatus === "1"
          ? "STATUS ▲"
          : "STATUS";
      break;

    case "timestamp":
      clearSortButtons();
      sortTimeStamp.innerHTML =
        sortStatus === "0"
          ? "CRIAÇÃO ▼"
          : sortStatus === "1"
          ? "CRIAÇÃO ▲"
          : "CRIAÇÃO";
      break;
  }
}
async function verifySort(currentSort) {
  if (localStorage.getItem("sort") !== currentSort) {
    localStorage.setItem("sort-status", "0");
  }
}
sortByNameButton.addEventListener("click", async () => {
  let sortStatus = loadFilterStatus();
  currentSort = "name";
  await verifySort(currentSort);
  loadIconSortButtons(currentSort);
  init({
    skipTable: (getCurrentPage() - 1) * rowsPerPage,
    filterStatus: sortStatus,
    FilterType: {
      filterByName: true,
      filterByTimeStamp: false,
      filterByStatus: false,
      filterByEmail: false,
    },
  });
  localStorage.setItem("sort", currentSort);
});

sortByEmailButton.addEventListener("click", async () => {
  let sortStatus = loadFilterStatus();
  currentSort = "email";
  await verifySort(currentSort);
  loadIconSortButtons(currentSort);
  init({
    skipTable: (getCurrentPage() - 1) * rowsPerPage,
    filterStatus: sortStatus,
    FilterType: {
      filterByName: false,
      filterByTimeStamp: false,
      filterByStatus: false,
      filterByEmail: true,
    },
  });
  localStorage.setItem("sort", currentSort);
});

sortByStatusButton.addEventListener("click", async () => {
  let sortStatus = loadFilterStatus();
  currentSort = "status";
  await verifySort(currentSort);
  loadIconSortButtons(currentSort);
  init({
    skipTable: (getCurrentPage() - 1) * rowsPerPage,
    filterStatus: sortStatus,
    FilterType: {
      filterByName: false,
      filterByTimeStamp: false,
      filterByStatus: true,
      filterByEmail: false,
    },
  });
  localStorage.setItem("sort", currentSort);
});

sortByTimeStampButton.addEventListener("click", async () => {
  let sortStatus = loadFilterStatus();
  currentSort = "timestamp";
  await verifySort(currentSort);
  loadIconSortButtons(currentSort);
  init({
    skipTable: (getCurrentPage() - 1) * rowsPerPage,
    filterStatus: sortStatus,
    FilterType: {
      filterByName: false,
      filterByTimeStamp: true,
      filterByStatus: false,
      filterByEmail: false,
    },
  });
  localStorage.setItem("sort", currentSort);
});
