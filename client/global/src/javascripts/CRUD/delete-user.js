import { init_table, clearTable, loadTable } from "../Table/table.js";
import { getUsersList } from "../tableHandler.js";
window.deleteUser = deleteUser;
let users_list = [];
let desableUsers = [];
let userIdtoDelete = "";
const confirmModal = document.getElementById("delete-confirm");
users_list = getUsersList() || [];
desableUsers = JSON.parse(localStorage.getItem("desable_users")) || [];

if (localStorage.getItem("desable_users") === null) {
  localStorage.setItem("desable_users", JSON.stringify([]));
}
const confirmButton = document.getElementById("confirm-delete");
const cancelButton = document.getElementById("cancel-delete");
if (window.location.pathname.includes("register")) {
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
    clearTable();
    loadTable();
    init_table();
  }
}
