let loginPage = document.getElementById("login");
let loginBtn = document.getElementById("loginBtn");
let loginSpan = document.getElementsByClassName("login-close")[0];

loginBtn.onclick = function (event) {
  event.preventDefault();
  loginPage.style.display = "block";
};

loginSpan.onclick = function () {
  loginPage.style.display = "none";
};

window.onclick = function (event) {
  if (event.target == loginPage) {
    loginPage.style.display = "none";
  }
  if (event.target == registerPage) {
    registerPage.style.display = "none";
  }
};

let registerPage = document.getElementById("register");
let registerBtn = document.getElementById("registerBtn");
let registerSpan = document.getElementsByClassName("register-close")[0];

registerBtn.onclick = function (event) {
  event.preventDefault();
  registerPage.style.display = "block";
};

registerSpan.onclick = function () {
  registerPage.style.display = "none";
};
