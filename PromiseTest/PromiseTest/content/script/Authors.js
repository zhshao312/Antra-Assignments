function getAuthors() {
    let p1 = fetch("https://jsonplaceholder.typicode.com/users")
        .then(function (response) {
            return response.json();
        })
    p1.then(function (data){
        let length = data.length;
        let tbody = document.querySelector("tbody");
        tbody.innerHTML = "";
        for (let i = 0; i < length; i++) {
            let tr = `<tr><td>${data[i].id}</td><td>${data[i].name}</td><td>${data[i].email}</td><td>${data[i].phone}</td></tr>`;
            tbody.innerHTML = tbody.innerHTML + tr;
        }
    })
}