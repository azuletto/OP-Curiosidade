const modalButton = document.getElementById("register-button");
const modalClose = document.getElementById("exit-register-modal");
const modal = document.getElementById("register-modal");
const cancelButton = document.getElementById("cancel-span");
modalButton.onclick = function () {
  modal.showModal();
};
modalClose.onclick = function () {
  modal.close();
};
cancelButton.onclick = function () {
  modal.close();
};
document
  .getElementById("register-button")
  .addEventListener("click", function () {
    localStorage.setItem("edit_mode", JSON.stringify(false));
  });
