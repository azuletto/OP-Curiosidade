import { init, clearTable } from "../Table/table.js";
import { getUserByIdHandler } from "./crudHandler.js";
import { deleteUserHandler } from "./deleteUserHandler.js";
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
async function backupDelete(userId) {
  let user = await getUserByIdHandler(userId);
  if (user) {
    await deleteUserHandler(userId);
    clearTable();
    init();
  }
}
