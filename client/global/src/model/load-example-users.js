import { getUsersList } from "../javascripts/tableHandler.js";
export async function loadExampleUsers(payload) {
  const exampleUsers = await getUsersList(payload);
  return exampleUsers;
}
