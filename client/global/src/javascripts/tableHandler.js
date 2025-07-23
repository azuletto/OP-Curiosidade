// Obter o token do localStorage
const token = localStorage.getItem("token");
import { API_URL } from "../../../../client/config.js";
// Fazer a chamada à API
async function getUsersList() {
  try {
    const response = await fetch(`${API_URL}/Admin/table`, {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${token}`,
      },
    });

    if (!response.ok) {
      throw new Error(`Erro na requisição: ${response.status}`);
    }
    const users_list = await response.json();
    if (users_list.length === 0) {
      getUsersList();
      const users_list = await response.json();
    }
    return users_list;
  } catch (error) {
    console.error("Erro ao buscar lista de usuários:", error);
    return null;
  }
}
