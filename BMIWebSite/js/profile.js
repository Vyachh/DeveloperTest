const token = localStorage.getItem('token');


fetch('https://localhost:7213/api/User/GetUserInfo', {
  method: 'GET',
  headers: {
    'Authorization': `Bearer ${token}`,
    'Content-Type': 'application/json'
  }
})
  .then(response => response.json())
  .then(data => {
    console.log(data.Age);
    document.getElementById('user_name').textContent = `Name: ${data["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"]}`;
    document.getElementById('user_surname').textContent = `Surname: ${data["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname"]}`;
    document.getElementById('user_firstname').textContent = `Firstname: ${data["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname"]}`;
    document.getElementById('user_patronymic').textContent = `Patronymic: ${data.Patronymic} `;
    document.getElementById('user_age').textContent = `Age: ${data.Age}`;
    document.getElementById('user_height').textContent = `Height: ${data.Height}`;
    document.getElementById('user_weight').textContent = `Weight: ${data.Weight}`;
  })
  .catch(error => console.log(error));