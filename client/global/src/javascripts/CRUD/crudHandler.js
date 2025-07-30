  export async function saveUserHandler(user) {
  try {
    const response = await fetch(`${host}/person`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(user),
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
