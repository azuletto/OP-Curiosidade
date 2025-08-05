import { API_URL } from "../../../../config.js";
let token = localStorage.getItem("token") || "";
export async function updateUser(payload) {
  try {
    const response = await fetch(`${API_URL}/person`, {
      method: 'PUT',
      headers: {
        "Content-Type": "application/json",
        "Authorization": `Bearer ${token}`,
      },
      credentials: "include",
      body: JSON.stringify(payload),
    });

    if (!response.ok) {
      throw new Error('Failed to update user');
    }

    const updatedUser = await response.json();
    return updatedUser;
  } catch (error) {
    throw error;
  }
}