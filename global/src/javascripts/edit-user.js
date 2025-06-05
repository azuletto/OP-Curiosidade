function editUser(userId) {

    const modalClose = document.getElementById('exit-register-modal');
    const modal = document.querySelector('dialog');

 

    modalClose.onclick = function () {
        modal.close()
    }

    const users = JSON.parse(localStorage.getItem("users_list")) || [];
    const user = users.find(user => Number(user.id) === Number(userId));

    if (user) {

    document.getElementById("user_name").value = user.name;
    document.getElementById("user_age").value = user.age;
    console.log(user.age); 
    document.getElementById("user_email").value = user.email;
    document.getElementById("user_adress").value = user.adress;
    document.getElementById("user_info").value = user.info;
    document.getElementById("user_interess").value = user.interess;
    document.getElementById("user_feelings").value = user.feelings;
    document.getElementById("user_valors").value = user.valors;
    document.getElementById("user_status").checked = user.status === "active";

    modal.showModal();

    console.log(`Usuário com ID ${userId} encontrado e carregado para edição.`);

    } else {
        console.warn(`Nenhum usuário encontrado com ID: ${userId}`);
        return null; // Retorno explícito para indicar que não encontrou
    }
}
