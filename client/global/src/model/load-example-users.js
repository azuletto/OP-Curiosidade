import { getUsersList } from "../javascripts/tableHandler.js";
export async function loadExampleUsers() {
  const exampleUsers = await getUsersList();
  return exampleUsers;
}
