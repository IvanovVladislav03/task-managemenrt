import axios from "axios";

const login = async (email, password) => {
  const loginData = { email, password };

  try {
    const response = await axios.post("https://localhost:7008/api/auth/login", loginData, {
      headers: {
        "Content-Type": "application/json",
      },
      withCredentials: true,
    });

    if (response.status === 200) {
      return { success: true, message: "Успешный вход!" };
    } else {
      return { success: false, message: response.data.message || "Ошибка на сервере." };
    }
  } catch (error) {
    return { success: false, message: error.response?.data?.message || "Ошибка при подключении к API." };
  }
};

const registry = async (userName, email, password) => {
  const registryData = {userName, email, password };

  try {
    const response = await axios.post("https://localhost:7008/api/auth/register", registryData, {
      headers: {
        "Content-Type": "application/json",
      },
    });

    if (response.status === 200) {
      return { success: true, message: "Успешно зарегестрирован!" };
    } else {
      return { success: false, message: response.data.message || "Ошибка на сервере." };
    }
  } catch (error) {
    return { success: false, message: error.response?.data?.message || "Ошибка при подключении к API." };
  }
};

export { login };
export { registry };
