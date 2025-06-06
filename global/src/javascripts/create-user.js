

let user = {
    name:"",
    age:"",
    email:"",
    adress:"",
    info:"",
    interess:"",
    feelings:"",
    valors:"",
    id:"0",
    time_stamp:"",
    status:""
};

let users_list = [];
users_list = JSON.parse(localStorage.getItem("users_list")) || [];

const submitButton = document.getElementById("submit-button");
const exitButton = document.getElementById("exit-register-modal");

exitButton.addEventListener("click", function(e)  {
    clearModal();
    e.preventDefault();
});
modal.addEventListener("close", function(e) {
    clearModal();
});




submitButton.addEventListener("click", function(e) {
    let editMode = JSON.parse(localStorage.getItem("edit_mode"));
    
    if(editMode === true) {
    console.log("Usuário não cadastrado, modo de edição ativado");
    e.preventDefault();
    return;
}   

    if(editMode === false) {
    user.name = document.getElementById("user_name").value;
    user.age = document.getElementById("user_age").value;
    user.email = document.getElementById("user_email").value;
    user.adress = document.getElementById("user_adress").value;
    user.info = document.getElementById("user_info").value;
    user.interess = document.getElementById("user_interess").value;
    user.feelings = document.getElementById("user_feelings").value;
    user.valors = document.getElementById("user_valors").value;
    user.status = document.getElementById("user_status").checked ? "active":"inactive";
    user.time_stamp = new Date().toISOString();
    verfifyUser(user);
    verifyStorage();    
    saveUser(user);
    window.location.reload();
    }
});

function clearModal() {
    document.getElementById("user_name").value = ""
    document.getElementById("user_age").value = ""
    document.getElementById("user_email").value = ""
    document.getElementById("user_adress").value = ""
    document.getElementById("user_info").value = ""
    document.getElementById("user_interess").value = ""
    document.getElementById("user_feelings").value = ""
    document.getElementById("user_valors").value = ""
    document.getElementById("user_status").checked = false;
    
}

function verfifyUser(user) {
    if(user.email === users_list.find(u => u.email === user.email)?.email) {
        console.error("Email already exists.");
        return error("Email already exists.");
    }
    for (let key in user) {
        if (user[key] === "" || user[key] === null || user[key] === undefined) {
            console.error(`The ${key} field is empty.`);
            return error(`The ${key} field is empty.`);
        }
    }
}

function saveUser(user) {
    if (users_list.length === 0) {
        user.id = 1;
    }
    else {
        (user.id) = Number(users_list[users_list.length - 1].id) + 1;
    }
    users_list.push(user);
    localStorage.setItem("users_list", JSON.stringify(users_list));

    users_list = JSON.parse(localStorage.getItem("users_list"));

}

function verifyStorage() {
    if(!localStorage.getItem("users_list")) {
        localStorage.setItem("users_list", JSON.stringify([]));
    } else {
        users_list = JSON.parse(localStorage.getItem("users_list"));
    }
}