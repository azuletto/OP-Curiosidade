window.deleteUser = deleteUser;


const confirmModal = document.getElementById('delete-confirm')

let users_list = [];
users_list = JSON.parse(localStorage.getItem("users_list")) || [];
let desableUsers = [];
desableUsers = JSON.parse(localStorage.getItem("desable_users")) || [];

if (localStorage.getItem("desable_users") === null) {
    localStorage.setItem("desable_users", JSON.stringify([]));
}

export function deleteUser(userId) {
    confirmModal.showModal()
    const confirmButton = document.getElementById("confirm-delete")
    const cancelButton = document.getElementById("cancel-delete")
    confirmButton.addEventListener("click", () => {
    backupDelete(userId);
    })
    cancelButton.addEventListener("click", () => {
        confirmModal.close()
    })
    
}

function backupDelete(userId) {
    let user = users_list.find(user => Number(user.id) === Number(userId));

    if (user) {
        users_list.splice(users_list.indexOf(user), 1);
        localStorage.setItem("users_list", JSON.stringify(users_list));
        desableUsers.push(user);
        localStorage.setItem("desable_users", JSON.stringify(desableUsers));
        window.location.reload();
    }
}




