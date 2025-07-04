if (!localStorage.getItem("set_sort")) {
  let set_sort = [];
  set_sort[0] = false;
  set_sort[1] = false;
  set_sort[2] = false;
  set_sort[3] = false;
  localStorage.setItem("set_sort", JSON.stringify(set_sort));
}
export function sort_by_name() {
  let users_list;
  users_list = JSON.parse(localStorage.getItem("users_list"));
  users_list.sort((a, b) => a.name.localeCompare(b.name));
  let set_sort = JSON.parse(localStorage.getItem("set_sort"));
  if (set_sort[0] === true) {
    users_list = sort_by_name_d();
  }
  return users_list;
}
export function sort_by_email() {
  let users_list = [];
  users_list = JSON.parse(localStorage.getItem("users_list"));
  users_list.sort((a, b) => a.email.localeCompare(b.email));
  let set_sort = JSON.parse(localStorage.getItem("set_sort"));
  if (set_sort[1] === true) {
    users_list = sort_by_email_d();
  }
  return users_list;
}
export function sort_by_status() {
  let users_list = [];
  users_list = JSON.parse(localStorage.getItem("users_list"));
  users_list.sort((a, b) => a.status.localeCompare(b.status));
  let set_sort = JSON.parse(localStorage.getItem("set_sort"));
  if (set_sort[2] === true) {
    users_list = sort_by_status_d();
  }
  return users_list;
}
export function sort_by_time_stamp() {
  let users_list = [];
  users_list = JSON.parse(localStorage.getItem("users_list"));
  users_list.sort((a, b) => new Date(b.time_stamp) - new Date(a.time_stamp));
  let set_sort = JSON.parse(localStorage.getItem("set_sort"));
  if (set_sort[3] === true) {
    users_list = sort_by_time_stamp_d();
  }
  return users_list;
}
export function sort_by_name_d() {
  let users_list = [];
  users_list = JSON.parse(localStorage.getItem("users_list"));
  users_list.sort((a, b) => b.name.localeCompare(a.name));
  return users_list;
}
export function sort_by_email_d() {
  let users_list = [];
  users_list = JSON.parse(localStorage.getItem("users_list"));
  users_list.sort((a, b) => b.email.localeCompare(a.email));
  return users_list;
}
export function sort_by_status_d() {
  let users_list = [];
  users_list = JSON.parse(localStorage.getItem("users_list"));
  users_list.sort((a, b) => b.status.localeCompare(a.status));
  return users_list;
}
export function sort_by_time_stamp_d() {
  let users_list = [];
  users_list = JSON.parse(localStorage.getItem("users_list"));
  users_list.sort((a, b) => new Date(a.time_stamp) - new Date(b.time_stamp));
  return users_list;
}
