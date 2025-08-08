import { API_URL } from "../../../../config.js";
const token = localStorage.getItem("token") || "";
export async function saveUserHandler(user) {
  try {
    const response = await fetch(`${API_URL}/person`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(user.data),
    });

    if (!response.ok) {
      const errorData = await response.json();
    }
  } catch (error) {
    console.error("Error during registration:", error);
    loginErrorMessage.textContent =
      "An unexpected error occurred. Please try again.";
  }
}
export async function getUserByIdHandler(userId) {
  try {
    const response = await fetch(`${API_URL}/person/${userId}`, {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${token}`,
      },
      credentials: "include",
    });

    if (!response.ok) {
      throw new Error("User not found");
    }

    return await response.json();
  } catch (error) {
    console.error("Error fetching user:", error);
    return null;
  }
}
