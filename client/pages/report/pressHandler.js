import { API_URL } from "../../config.js";
import { renderTable, init } from "../../global/src/javascripts/Table/table.js";
const token = localStorage.getItem("token") || "";
const pressButton = document.getElementById("press-button");

pressButton.onclick = async () => {
  const response = await fetch(`${API_URL}/table`, {
    method: "GET",
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${token}`,
    },
    credentials: "include",
  });

  if (response.ok) {
    const data = await response.json();
    await renderTable(data.data);
    await pressContent();
    init();
  } else {
    console.error("Failed to fetch press report data");
  }
};

async function pressContent() {
  window.print();
}
