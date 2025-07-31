window.verifyEdit = verifyEdit;
import { verfifyUser } from "./create-user.js";
import { getUserByIdHandler } from "./crudHandler.js";
import {
  clearTable,
  //loadTable,
  init,
} from "../../javascripts/Table/table.js";
import { getUsersList } from "../tableHandler.js";
let user_edit;
const submitButton = document.getElementById("submit-button");
export function verifyEdit(userId, edit) {
  editUser(userId, edit);
}
async function editUser(userId, edit) {
  localStorage.setItem("edit_mode", JSON.stringify(edit));
  user_edit = await getUserByIdHandler(userId);
  console.log(user_edit);
  if (user_edit) {
    document.getElementById("user_name").value = user_edit.data.name;
    document.getElementById("user_email").value = user_edit.data.email;
    document.getElementById("user_age").value = user_edit.data.birthDate;
    document.getElementById("user_adress").value = user_edit.data.address;
    document.getElementById("user_info").value = user_edit.data.otherInfos.info;
    document.getElementById("user_interess").value = user_edit.data.otherInfos.interess;
    document.getElementById("user_feelings").value = user_edit.data.otherInfos.feelings;
    document.getElementById("user_valors").value = user_edit.data.otherInfos.valors;
switch (user_edit.data.status) {
  case true:
  case "Ativo": // Se vier como string "Ativo"
    document.getElementById("user_status").checked = true;
    break;
  case false:
  case "Inativo": // Se vier como string "Inativo"
    document.getElementById("user_status").checked = false;
    break;
  default:
    document.getElementById("user_status").checked = false; // Valor inválido = desmarca
    break;
}
    // document.getElementById("user_status").checked = user_edit.data.status === true;
    modal.showModal();
  }
}
if (window.location.pathname.includes("register")) {
  submitButton.addEventListener("click", function (e) {
    e.preventDefault();
    user_edit.data.name = document.getElementById("user_name").value;
    user_edit.data.email = document.getElementById("user_email").value;
    user_edit.data.birthDate = document.getElementById("user_age").value;
    user_edit.data.address = document.getElementById("user_adress").value;
    user_edit.data.otherInfos.info = document.getElementById("user_info").value;
    user_edit.data.otherInfos.interess = document.getElementById("user_interess").value;
    user_edit.data.otherInfos.feelings = document.getElementById("user_feelings").value;
    user_edit.data.otherInfos.valors = document.getElementById("user_valors").value;
    user_edit.data.status = document.getElementById("user_status").checked
      ? "Ativo"
      : "Inativo";
    if (verfifyUser(user_edit)) {
      localStorage.setItem("edit_mode", JSON.stringify(false));
      clearTable();
      //loadTable();
      init();
      modal.close();
    }
  });
}
