import { regexEmail } from "../Validations/regex.js";
import { init_table, clearTable, loadTable } from "../Table/table.js";
let user = {
  name: "",
  age: "",
  email: "",
  address: "",
  info: "",
  interess: "",
  feelings: "",
  valors: "",
  id: "",
  time_stamp: "",
  status: "",
};
if (!localStorage.getItem("users_list")) {
  localStorage.setItem("users_list", JSON.stringify([]));
}
let users_list = [];
users_list = JSON.parse(localStorage.getItem("users_list")) || [];
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
    let addressVer = verifyAdress(document.getElementById("user_adress").value);
    if (adressVer) {
      document.getElementById("user_adress").classList.remove("invalid-input");
      address_error.innerHTML = "";
    }
  });
  submitButton.addEventListener("click", function (e) {
    let editMode = JSON.parse(localStorage.getItem("edit_mode"));
    if (!editMode) {
      user.name = document.getElementById("user_name").value;
      user.age = document.getElementById("user_age").value;
      user.email = document.getElementById("user_email").value;
      user.adress = document.getElementById("user_adress").value;
      user.info = document.getElementById("user_info").value;
      user.interess = document.getElementById("user_interess").value;
      user.feelings = document.getElementById("user_feelings").value;
      user.valors = document.getElementById("user_valors").value;
      user.status = document.getElementById("user_status").checked
        ? "Ativo"
        : "Inativo";
      user.time_stamp = new Date().toISOString();
      if (!verfifyUser(user)) {
        e.preventDefault();
        return Error;
      } else {
      }
      verifyStorage();
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
export function verfifyUser(user) {
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
  const isNameValid = verifyName(user.name);
  const isEmailValid = verifyEmail(user);
  const isAgeValid = verifyAge(user.age);
  const isAddressValid = verifyAdress(user.adress);
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
function verifyAge(age) {
  if (
    age < new Date("1920-01-01").toISOString().split("T")[0] ||
    age > new Date().toISOString().split("T")[0] ||
    !age
  ) {
    document.getElementById("user_age").classList.add("invalid-input");
    age_error.innerHTML = "Data de nascimento inválida.";
    return false;
  } else return true;
}
function verifyEmail(user, isevent = false) {
  let users_list = JSON.parse(localStorage.getItem("users_list")) || [];
  let editMode = JSON.parse(localStorage.getItem("edit_mode"));
  if (editMode && isevent) {
    if (!regexEmail(user.email)) {
      document.getElementById("user_email").classList.add("invalid-input");
      email_error.innerHTML = "E-mail inválido, tente novamente.";
      return false;
    }
    return true;
  } else if (editMode) {
    if (
      !regexEmail(user.email) ||
      users_list.find((u) => u.email === user.email && u.id !== user.id)
    ) {
      document.getElementById("user_email").classList.add("invalid-input");
      email_error.innerHTML = "E-mail inválido ou já cadastrado.";
      return false;
    } else return true;
  } else if (!editMode) {
    if (
      !regexEmail(user.email) ||
      users_list.find((u) => u.email === user.email)
    ) {
      document.getElementById("user_email").classList.add("invalid-input");
      email_error.innerHTML = "E-mail inválido ou já cadastrado.";
      return false;
    } else return true;
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
  let userUUID = crypto.randomUUID();
  user.id = userUUID;
  users_list.push(user);
  localStorage.setItem("users_list", JSON.stringify(users_list));
  clearTable();
  loadTable();
  init_table();
  clearModal();
  modal.close();
}
function verifyStorage() {
  if (!localStorage.getItem("users_list")) {
    localStorage.setItem("users_list", JSON.stringify([]));
  } else {
    users_list = JSON.parse(localStorage.getItem("users_list"));
  }
}
