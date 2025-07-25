import { loadExampleUsers } from "../../global/src/model/load-example-users.js";
import { getTotalUsersCount, getMonthUsersCount, getPendingUsersCount } from "./get-users-handler.js";

// let users_list = await loadExampleUsers();
let title_total = document.getElementById("title-total");
let pending_users = document.getElementById("title-pending");
let title_month_users = document.getElementById("title-month");

let total_users_count = await getTotalUsersCount();
let month_users_count = await getMonthUsersCount();
let pending_users_count = await getPendingUsersCount();

title_total.innerHTML = total_users_count;
title_month_users.innerHTML = month_users_count;
pending_users.innerHTML = pending_users_count;
