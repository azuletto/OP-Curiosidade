import { API_URL } from "../../../../config.js";
let token = localStorage.getItem("token") || "";
export async function deleteUserHandler(userId) {
  try {
    const response = await fetch(`${API_URL}/person/${userId}`, {
      method: "DELETE",
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${token}`,
      },
      credentials: "include",
      body: JSON.stringify({ id: userId }),
    });

    if (!response.ok) {
      throw new Error("Failed to delete user");
    }

    const deletedUser = await response.json();
    return deletedUser;
  } catch (error) {
    throw error;
  }
}
