


document
  .getElementById("register_form")
  .addEventListener("submit", function (event) {
    event.preventDefault();
    let nickName = document.getElementById("reg_login").value;
    let password = document.getElementById("reg_password").value;
    // let age = document.getElementById("reg_age").value;
    // let height = document.getElementById("reg_height").value;
    // let weight = document.getElementById("reg_weight").value;

    if (!nickName || !password) {
      console.log("Пожалуйста, заполните все поля");
      return;
    }
    const url = "https://localhost:7213/api/User/register";

    let data = {
      nickName: nickName,
      password: password
    }
    fetch(url, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(data),
    })
      .then((response) => response.json())
      .then((result) => {
        console.log(result);
      })
      .catch((error) => {
        console.log(error);
      });
  });

document
  .getElementById("login_form")
  .addEventListener("submit", function (event) {
    event.preventDefault();
    let nickName = document.getElementById("log_nickName").value;
    let password = document.getElementById("log_password").value;

    const url = "https://localhost:7213/api/User/Login";


    let data = {
      nickName: nickName,
      password: password
    }

    fetch(url, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(data),
    })
      .then((response) => response.text())
      .then((result) => {
        localStorage.setItem("token", result);
      })
      .catch((error) => {
        console.log(error);
      });
  });

document.addEventListener("DOMContentLoaded", function () {
  const loginBtn = document.getElementById("loginBtn");
  const registerBtn = document.getElementById("registerBtn");
  const nicknameLink = document.createElement("a");
  nicknameLink.classList.add("bordered_href");
  nicknameLink.textContent = "User Profile"; // Замените на нужный текст ссылки
  nicknameLink.href = "/profile.html"

  // Проверка состояния аутентификации пользователя
  if (isLoggedIn()) {
    // Пользователь вошел на сайт
    loginBtn.remove(); // Удаление кнопки "Login"
    registerBtn.remove(); // Удаление кнопки "Register"
    // Добавление ссылки с ником пользователя
    document.querySelector(".header_nav").appendChild(nicknameLink);
  } else {
    // Пользователь не вошел на сайт
    nicknameLink.remove(); // Удаление ссылки с ником пользователя
  }

  // Функция для проверки состояния аутентификации пользователя
  function isLoggedIn() {

    const token = localStorage.getItem('token');
    return token !== null
  }
});

document
  .getElementById("calc_bmi")
  .addEventListener("submit", async function (event) {
    event.preventDefault();

    const MinHeightValue = 50;
    const MaxHeightValue = 250;
    const MinWeightValue = 5;
    const MaxWeightValue = 500;

    let height = document.getElementById("height").value;
    let weight = document.getElementById("weight").value;
    let validWeight = ValidateMeasurement(
      weight,
      MinWeightValue,
      MaxWeightValue,
      `Вес должен быть от ${MinWeightValue} до ${MaxWeightValue}`
    );
    let validHeight = ValidateMeasurement(
      height,
      MinHeightValue,
      MaxHeightValue,
      `Рост должен быть от ${MinHeightValue} до ${MaxHeightValue}`
    );


    let index = document.getElementById("index");
    let description = document.getElementById("description");

    if (validWeight !== undefined) {
      index.textContent = "Ошибка";
      description.textContent = validWeight;
    } else if (validHeight !== undefined) {
      index.textContent = "Ошибка";
      description.textContent = validHeight;
    } else {
      let result = await getInfo(height, weight);

      index.textContent = result.index;
      description.textContent = result.description;
    }
  });

async function getInfo(height, weight) {
  const response = await fetch(
    `https://localhost:7213/api/Pacient?height=${height}&weight=${weight}`
  );
  return (result = await response.json());
}

function ValidateMeasurement(value, minValue, maxValue, message) {
  if (value < minValue || value > maxValue) {
    return message;
  }
}
