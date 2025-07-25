import { getUsersList } from "../javascripts/tableHandler.js";
export async function loadExampleUsers() {
  const exampleUsers = await getUsersList();
  if (!exampleUsers) {
    loadExampleUsers();
    window.location.reload();
  }
  return exampleUsers;
}
