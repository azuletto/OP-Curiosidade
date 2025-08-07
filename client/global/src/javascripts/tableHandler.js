import { API_URL } from "../../../../client/config.js";

export async function getUsersList(payloadObject) {
  const token = localStorage.getItem("token");
  if (payloadObject.skipTable === undefined) {
    payloadObject.skipTable = 0; // Default value if skipTable is not provided
  }
  if (!token) {
    console.error("Token não encontrado no localStorage");
    return null;
  }

  const queryParams = [
    `skipTable=${payloadObject.skipTable}`,
    `filterStatus=${payloadObject.filterStatus}`,
    `filterType.filterByName=${payloadObject.FilterType.filterByName}`,
    `filterType.filterByTimeStamp=${payloadObject.FilterType.filterByTimeStamp}`,
    `filterType.filterByStatus=${payloadObject.FilterType.filterByStatus}`,
    `filterType.filterByEmail=${payloadObject.FilterType.filterByEmail}`,
  ].join("&");

  try {
    const response = await fetch(`${API_URL}/table/preview?${queryParams}`, {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${token}`,
      },
      credentials: "include",
    });

    if (response.status === 401) {
      return null;
    }

    if (!response.ok) {
      throw new Error(`Erro HTTP: ${response.status}`);
    }

    const { data } = await response.json();
    return data.persons;
  } catch (err) {
    console.error("Falha na requisição:", err);
    return null;
  }
}
