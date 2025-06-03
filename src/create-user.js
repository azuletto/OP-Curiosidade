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

const submitButton = document.getElementById("submit-button");
if (!submitButton) {
    console.error("Submit button not found");
}

submitButton.addEventListener("click", function(e) {

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
    saveUser(user);
    console.log(user);
    
});

function verfifyUser(user) {
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
        user.id = users_list[users_list.length - 1].id + 1;
    }
    users_list.push(user);
    localStorage.setItem("users_list", JSON.stringify(users_list));
    console.log(`User with id ${user.id} created successfully.`);

    users_list = JSON.parse(localStorage.getItem("users_list"));

    console.log("A lista de usuários atualizadas é: "+ JSON.stringify(users_list));
}
