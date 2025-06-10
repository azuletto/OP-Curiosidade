
let users_list = JSON.parse(localStorage.getItem('users_list'));

let title_total = document.getElementById("title-total");

let pending_users = document.getElementById("title-pending");
let pending_users_count = users_list.filter(user => user.status === 'inactive').length;

let title_month_users = document.getElementById("title-month");

let month_users_count = users_list.filter(user => {
    let user_timestamp = new Date(user.time_stamp);
    let current_date = new Date();
    return user_timestamp.getMonth() === current_date.getMonth() &&
        user_timestamp.getFullYear() === current_date.getFullYear();
})
title_month_users.innerHTML = month_users_count.length;
title_total.innerHTML = users_list.length;
pending_users.innerHTML = pending_users_count;

