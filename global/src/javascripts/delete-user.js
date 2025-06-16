window.deleteUser = deleteUser;

let users_list = [];
users_list = JSON.parse(localStorage.getItem("users_list")) || [];
let desableUsers = [];
desableUsers = JSON.parse(localStorage.getItem("desable_users")) || [];

if (localStorage.getItem("desable_users") === null) {
    localStorage.setItem("desable_users", JSON.stringify([]));
}

export function deleteUser(userId) {
    backupDelete(userId);
}

function backupDelete(userId) {
    let user = users_list.find(user => Number(user.id) === Number(userId));

    if (user) {
        users_list.splice(users_list.indexOf(user), 1);
        localStorage.setItem("users_list", JSON.stringify(users_list));
        desableUsers.push(user);
        localStorage.setItem("desable_users", JSON.stringify(desableUsers));
        alert(`User ${user.name} has been deleted successfully.`);
        window.location.reload();
    }
}




