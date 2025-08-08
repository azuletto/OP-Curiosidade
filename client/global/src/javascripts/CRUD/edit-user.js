window.verifyEdit = verifyEdit;
import { verfifyUser } from "./create-user.js";
import { getUserByIdHandler } from "./crudHandler.js";
import { clearTable, init } from "../../javascripts/Table/table.js";
import { updateUser } from "./updateUserHandler.js";
let user_edit;
const submitButton = document.getElementById("submit-button");
export function verifyEdit(userId, edit) {
  editUser(userId, edit);
}
async function editUser(userId, edit) {
  localStorage.setItem("edit_mode", JSON.stringify(edit));
  user_edit = await getUserByIdHandler(userId);
  if (user_edit) {
    document.getElementById("user_name").value = user_edit.data.name;
    document.getElementById("user_email").value = user_edit.data.email;
    document.getElementById("user_age").value = user_edit.data.birthDate;
    document.getElementById("user_adress").value = user_edit.data.address;
    document.getElementById("user_info").value = user_edit.data.otherInfos.info;
    document.getElementById("user_interess").value =
      user_edit.data.otherInfos.interess;
    document.getElementById("user_feelings").value =
      user_edit.data.otherInfos.feelings;
    document.getElementById("user_valors").value =
      user_edit.data.otherInfos.valors;
    switch (user_edit.data.status) {
      case true:
      case "Ativo":
        document.getElementById("user_status").checked = true;
        break;
      case false:
      case "Inativo":
        document.getElementById("user_status").checked = false;
        break;
      default:
        document.getElementById("user_status").checked = false;
        break;
    }
    modal.showModal();
  }
}
if (window.location.pathname.includes("register") && localStorage.getItem("edit_mode") === "true") {
  submitButton.addEventListener("click", async function (e) {
    e.preventDefault();

    user_edit.data.name = document.getElementById("user_name").value;
    user_edit.data.email = document.getElementById("user_email").value;
    user_edit.data.birthDate = document.getElementById("user_age").value;
    user_edit.data.status = document.getElementById("user_status").checked
      ? true
      : false;
    user_edit.data.address = document.getElementById("user_adress").value;
    user_edit.data.otherInfos.valors =
      document.getElementById("user_valors").value;
    user_edit.data.otherInfos.feelings =
      document.getElementById("user_feelings").value;
    user_edit.data.otherInfos.info = document.getElementById("user_info").value;
    user_edit.data.otherInfos.interess =
      document.getElementById("user_interess").value;

    const payload = {
      personViewDataDTO: user_edit.data,
    };
    const isValid = await verfifyUser(user_edit);

    if (isValid === true) {
      await updateUser(payload);
      localStorage.setItem("edit_mode", JSON.stringify(false));
      clearTable();
      init();
      modal.close();
    } else {
      e.preventDefault();
      return Error;
    }
  });
}
