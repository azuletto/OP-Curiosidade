import { API_URL } from "../../../../client/config.js";

export async function getUsersList() {
  const token = localStorage.getItem("token");
  
  if (!token) {
    console.error("Token não encontrado no localStorage");
    return null;
  }

  try {
    const response = await fetch(`${API_URL}/Admin/table`, {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
        "Authorization": `Bearer ${token}`,
      },
      credentials: "include",
    });

    if (response.status === 401) {
      console.error("Token inválido/expirado ou falta de permissão");
      return null;
    }

    if (!response.ok) {
      throw new Error(`Erro HTTP: ${response.status}`);
    }

    const { data } = await response.json();
    return data;
  } catch (err) {
    console.error("Falha na requisição:", err);
    return null;
  }
}