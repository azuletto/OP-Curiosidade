import { init, getCurrentPage, rowsPerPage } from "./table.js";

const sortByNameButton = document.getElementById("sort-name");
const sortByEmailButton = document.getElementById("sort-email");
const sortByStatusButton = document.getElementById("sort-status");
const sortByTimeStampButton = document.getElementById("sort-timestamp");
const sortName = document.getElementById("sort-name");
const sortEmail = document.getElementById("sort-email");
const sortStatus = document.getElementById("sort-status");
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
          filterByEmail: false
        }
      };
    init(payload);
    localStorage.setItem("sort", currentSort);
}

function loadIconSortBUttons(string) {
  
}

sortByNameButton.addEventListener("click", () => {
  let sortStatus = loadFilterStatus();
  currentSort = "name";
    init({
        skipTable: (getCurrentPage() - 1) * rowsPerPage,
        filterStatus: sortStatus,
        FilterType: {
            filterByName: true,
            filterByTimeStamp: false,
            filterByStatus: false,
            filterByEmail: false
        }
    });
  localStorage.setItem("sort", currentSort);
});

sortByEmailButton.addEventListener("click", () => {
  let sortStatus = loadFilterStatus();
    currentSort = "email";
    init({
        skipTable: (getCurrentPage() - 1) * rowsPerPage,
        filterStatus: sortStatus,
        FilterType: {
            filterByName: false,
            filterByTimeStamp: false,
            filterByStatus: false,
            filterByEmail: true
        }
    });
    localStorage.setItem("sort", currentSort);
});

sortByStatusButton.addEventListener("click", () => {
    let sortStatus = loadFilterStatus();
    currentSort = "status";
    init({
        skipTable: (getCurrentPage() - 1) * rowsPerPage,
        filterStatus: sortStatus,
        FilterType: {
            filterByName: false,
            filterByTimeStamp: false,
            filterByStatus: true,
            filterByEmail: false
        }
    });
    localStorage.setItem("sort", currentSort);
});

sortByTimeStampButton.addEventListener("click", () => {
  let sortStatus = loadFilterStatus();
    currentSort = "timestamp";
    init({
        skipTable: (getCurrentPage() - 1) * rowsPerPage,
        filterStatus: sortStatus,
        FilterType: {
            filterByName: false,
            filterByTimeStamp: true,
            filterByStatus: false,
            filterByEmail: false
        }
    });
    localStorage.setItem("sort", currentSort);
});