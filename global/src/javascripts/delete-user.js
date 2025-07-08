import { init_table, clearTable, loadTable } from "./table.js";
window.deleteUser = deleteUser;
let users_list = [];
let desableUsers = [];
let userIdtoDelete = "";
const confirmModal = document.getElementById("delete-confirm");
users_list = JSON.parse(localStorage.getItem("users_list")) || [];
desableUsers = JSON.parse(localStorage.getItem("desable_users")) || [];

if (localStorage.getItem("desable_users") === null) {
  localStorage.setItem("desable_users", JSON.stringify([]));
}
const confirmButton = document.getElementById("confirm-delete");
const cancelButton = document.getElementById("cancel-delete");
if (window.location.pathname.includes("cadastro-page")) {
  confirmButton.addEventListener("click", () => {
    backupDelete(userIdtoDelete);
    confirmModal.close();
  });
  cancelButton.addEventListener("click", () => {
    confirmModal.close();
  });
}
export function deleteUser(userId) {
  userIdtoDelete = userId;
  confirmModal.showModal();
}
function backupDelete(userId) {
  let user = users_list.find((user) => String(user.id) === String(userId));
  if (user) {
    users_list.splice(users_list.indexOf(user), 1);
    localStorage.setItem("users_list", JSON.stringify(users_list));
    desableUsers.push(user);
    localStorage.setItem("desable_users", JSON.stringify(desableUsers));
    clearTable();
    loadTable();
    init_table();
  }
}
