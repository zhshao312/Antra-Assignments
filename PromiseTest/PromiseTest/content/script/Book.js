 function getBooks() {
    let x = fetch("https://jsonplaceholder.typicode.com/users/1/albums")
        .then(function (response) {
            return response.json();
        })
    x.then(function (data){
        let length = data.length;
        let tbody = document.querySelector("tbody");
        tbody.innerHTML = "";    
        for (let i = 0; i < length; i++) {
            let tr = `<tr><td>${data[i].userId}</td><td>${data[i].id}</td><td>${data[i].title}</td></td>`;
            tbody.innerHTML = tbody.innerHTML + tr
        }

    })
}