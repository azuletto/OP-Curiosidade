window.verifyEdit = verifyEdit;
import { verfifyUser } from "./create-user.js";
import { clearTable, loadTable, init_table } from "./table.js";
let user_edit;
const submitButton = document.getElementById("submit-button");
export function verifyEdit(userId, edit) {
  editUser(userId, edit);
}
function editUser(userId, edit) {
  localStorage.setItem("edit_mode", JSON.stringify(edit));
  let users = JSON.parse(localStorage.getItem("users_list")) || [];
  user_edit = users.find((user) => String(user.id) === String(userId));
  if (user_edit) {
    document.getElementById("user_name").value = user_edit.name;
    document.getElementById("user_age").value = user_edit.age;
    document.getElementById("user_email").value = user_edit.email;
    document.getElementById("user_adress").value = user_edit.adress;
    document.getElementById("user_info").value = user_edit.info;
    document.getElementById("user_interess").value = user_edit.interess;
    document.getElementById("user_feelings").value = user_edit.feelings;
    document.getElementById("user_valors").value = user_edit.valors;
    document.getElementById("user_status").checked =
      user_edit.status === "Ativo";
    modal.showModal();
  }
}
if (window.location.pathname.includes("register")) {
  submitButton.addEventListener("click", function (e) {
    e.preventDefault();
    user_edit.name = document.getElementById("user_name").value;
    user_edit.age = document.getElementById("user_age").value;
    user_edit.email = document.getElementById("user_email").value;
    user_edit.adress = document.getElementById("user_adress").value;
    user_edit.info = document.getElementById("user_info").value;
    user_edit.interess = document.getElementById("user_interess").value;
    user_edit.feelings = document.getElementById("user_feelings").value;
    user_edit.valors = document.getElementById("user_valors").value;
    user_edit.status = document.getElementById("user_status").checked
      ? "Ativo"
      : "Inativo";
    let users_list = JSON.parse(localStorage.getItem("users_list"));
    if (verfifyUser(user_edit)) {
      users_list.find((user) => String(user.id) === String(user_edit.id)).name =
        user_edit.name;
      users_list.find((user) => String(user.id) === String(user_edit.id)).age =
        user_edit.age;
      users_list.find(
        (user) => String(user.id) === String(user_edit.id)
      ).email = user_edit.email;
      users_list.find(
        (user) => String(user.id) === String(user_edit.id)
      ).adress = user_edit.adress;
      users_list.find((user) => String(user.id) === String(user_edit.id)).info =
        user_edit.info;
      users_list.find(
        (user) => String(user.id) === String(user_edit.id)
      ).interess = user_edit.interess;
      users_list.find(
        (user) => String(user.id) === String(user_edit.id)
      ).feelings = user_edit.feelings;
      users_list.find(
        (user) => String(user.id) === String(user_edit.id)
      ).valors = user_edit.valors;
      users_list.find(
        (user) => String(user.id) === String(user_edit.id)
      ).status = user_edit.status;
      localStorage.setItem("users_list", JSON.stringify(users_list));
      localStorage.setItem("edit_mode", JSON.stringify(false));
      clearTable();
      loadTable();
      init_table();
      modal.close();
    }
  });
}
