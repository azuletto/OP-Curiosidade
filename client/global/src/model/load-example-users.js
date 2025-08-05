import { getUsersList } from "../javascripts/tableHandler.js";
export async function loadExampleUsers(skipTable) {
  const exampleUsers = await getUsersList(skipTable);
  return exampleUsers;
}
