import { regexEmail } from "../Validations/email-regex.js";
import { init, clearTable /*, loadTable */} from "../Table/table.js";
import { getUsersList } from "../tableHandler.js";
import { getUserByIdHandler, saveUserHandler } from "../CRUD/crudHandler.js";
let user =
{
  name: "",
  email: "",
  dateOfBirth: "",
  status: "",
  address: "",
  otherInfos: {
    valors: "",
    feelings: "",
    info: "",
    interess: ""
  }
};

let users_list = [];
users_list = getUsersList() || [];
const submitButton = document.getElementById("submit-button");
const exitButton = document.getElementById("exit-register-modal");
let user_age = document.getElementById("user_age");
let email_error = document.getElementById("email-error");
let name_error = document.getElementById("name-error");
let age_error = document.getElementById("age-error");
let address_error = document.getElementById("error-input");
let user_info_error = document.getElementById("error-input-1");
let user_interess_error = document.getElementById("error-input-2");
let user_feelings_error = document.getElementById("error-input-3");
let user_valors_error = document.getElementById("error-input-4");
if (window.location.pathname.includes("register")) {
  exitButton.addEventListener("click", function (e) {
    clearModal();
    e.preventDefault();
  });
  modal.addEventListener("close", function (e) {
    clearModal();
  });
  user_age.addEventListener("keyup", () => {
    let user_age_input = user_age.value;
    const date = new Date().toISOString().split("T")[0];
    if (user_age_input > date) {
      user_age.value = date;
    }
  });
  let allInputs = document.querySelectorAll(".input-modal");
  allInputs[0].addEventListener("keyup", () => {
    let nameVer = verifyName(document.getElementById("user_name").value);
    if (nameVer) {
      document.getElementById("user_name").classList.remove("invalid-input");
      name_error.innerHTML = "";
    }
  });
  allInputs[1].addEventListener("keyup", () => {
    let ageVer = verifyAge(document.getElementById("user_age").value);
    if (ageVer) {
      document.getElementById("user_age").classList.remove("invalid-input");
      age_error.innerHTML = "";
    }
  });
  allInputs[2].addEventListener("keyup", () => {
    let blankUser = { email: document.getElementById("user_email").value };
    let isEvent = true;
    let emailVer = verifyEmail(blankUser, isEvent);
    if (emailVer) {
      document.getElementById("user_email").classList.remove("invalid-input");
      email_error.innerHTML = "";
    }
  });
  allInputs[3].addEventListener("keyup", () => {
    let addressVer = verifyAddress(document.getElementById("user_adress").value);
  });
  submitButton.addEventListener("click", function (e) {
    let editMode = JSON.parse(localStorage.getItem("edit_mode"));
    if (!editMode) {
      user.name = document.getElementById("user_name").value;
      user.dateOfBirth = document.getElementById("user_age").value;
      user.email = document.getElementById("user_email").value;
      user.address = document.getElementById("user_adress").value;
      user.status = document.getElementById("user_status").checked
      user.otherInfos.info = document.getElementById("user_info").value;
      user.otherInfos.interess = document.getElementById("user_interess").value;
      user.otherInfos.feelings = document.getElementById("user_feelings").value;
      user.otherInfos.valors = document.getElementById("user_valors").value;
      user.status = document.getElementById("user_status").checked
      if (!verfifyUser(user)) {
        e.preventDefault();
        return Error;
      } else {
      }
      //verifyStorage();
      saveUser(user);
      clearUser();
    }
  });
}
function clearUser() {
  user.name = "";
  user.age = "";
  user.email = "";
  user.adress = "";
  user.info = "";
  user.interess = "";
  user.feelings = "";
  user.valors = "";
  user.id = "";
  user.time_stamp = "";
  user.status = "";
}
function clearModal() {
  document.getElementById("user_name").value = "";
  document.getElementById("user_age").value = "";
  document.getElementById("user_email").value = "";
  document.getElementById("user_adress").value = "";
  document.getElementById("user_info").value = "";
  document.getElementById("user_interess").value = "";
  document.getElementById("user_feelings").value = "";
  document.getElementById("user_valors").value = "";
  document.getElementById("user_status").checked = false;
  document.getElementById("email-error").innerHTML = "";
  document.getElementById("name-error").innerHTML = "";
  document.getElementById("age-error").innerHTML = "";
  document.getElementById("error-input").innerHTML = "";
  document.getElementById("user_name").classList.remove("invalid-input");
  document.getElementById("user_age").classList.remove("invalid-input");
  document.getElementById("user_email").classList.remove("invalid-input");
  document.getElementById("user_adress").classList.remove("invalid-input");
}
export async function verfifyUser(user) {
  email_error.innerHTML = "";
  name_error.innerHTML = "";
  age_error.innerHTML = "";
  address_error.innerHTML = "";
  user_info_error.innerHTML = "";
  user_interess_error.innerHTML = "";
  user_feelings_error.innerHTML = "";
  user_valors_error.innerHTML = "";
  document.getElementById("user_name").classList.remove("invalid-input");
  document.getElementById("user_age").classList.remove("invalid-input");
  document.getElementById("user_email").classList.remove("invalid-input");
  document.getElementById("user_adress").classList.remove("invalid-input");
  const isNameValid = verifyName(user.data.name);
  const isEmailValid = verifyEmail(user);
  const isAgeValid = verifyAge(user.data.birthDate);
  const isAddressValid = verifyAdress(user.data.address);
  if (!isNameValid || !isEmailValid || !isAgeValid || !isAddressValid) {
    document
      .getElementById("modal-header")
      .scrollIntoView({ behavior: "smooth", block: "center" });
    return false;
  } else {
    return true;
  }
}
function verifyAdress(adress) {
  if (String(adress).trim() === "") {
    document.getElementById("user_adress").classList.add("invalid-input");
    address_error.innerHTML = "O campo de endereço não pode estar vazio.";
    return false;
  } else return true;
}
function verifyAge(birthDate) {
  if (
    birthDate < new Date("1920-01-01").toISOString().split("T")[0] ||
    birthDate > new Date().toISOString().split("T")[0] ||
    !birthDate
  ) {
    document.getElementById("user_age").classList.add("invalid-input");
    age_error.innerHTML = "Data de nascimento inválida.";
    return false;
  } else return true;
}
async function verifyEmail(user, isevent = false) {
  let user_edit = await getUserByIdHandler(user.data.id);
  let editMode = JSON.parse(localStorage.getItem("edit_mode"));
  if (editMode && isevent) {
    if (!regexEmail(user.data.email)) {
      document.getElementById("user_email").classList.add("invalid-input");
      email_error.innerHTML = "E-mail inválido, tente novamente.";
      return false;
    }
    return true;
  } else if (editMode) {
    if (
      !regexEmail(user.data.email) || (user_edit.data.email !== user.data.email)
    ) {
      document.getElementById("user_email").classList.add("invalid-input");
      email_error.innerHTML = "E-mail inválido ou já cadastrado.";
      return false;
    } else return true;
  } else if (!editMode) {
    if (
      !regexEmail(user.data.email)
    ) {
      document.getElementById("user_email").classList.add("invalid-input");
      email_error.innerHTML = "E-mail inválido ou já cadastrado.";
      return false;
    } else return true;
  }
}
function verifyAddress(address) {
  if (String(address).trim() === "") {
    document.getElementById("user_adress").classList.add("invalid-input");
    address_error.innerHTML = "O campo de endereço não pode estar vazio.";
    return false;
  } else {
    document.getElementById("user_adress").classList.remove("invalid-input");
    address_error.innerHTML = "";
    return true;
  }
}
function verifyName(name) {
  if (String(name).trim() === "") {
    document.getElementById("user_name").classList.add("invalid-input");
    name_error.innerHTML = "O campo de nome não pode estar vazio.";
    return false;
  } else return true;
}
function saveUser(user) {
  saveUserHandler(user)
    .then(() => {
      clearTable();
      init();
      clearModal();
      modal.close();
    })
    .catch((error) => {
      console.error("Error saving user:", error);
    });
}
