const modalButton = document.getElementById('register-button');
const modalClose = document.getElementById('exit-register-modal');
const modal = document.querySelector('dialog');

modalButton.onclick = function () {
    modal.showModal()
}

modalClose.onclick = function () {
    modal.close()
}

