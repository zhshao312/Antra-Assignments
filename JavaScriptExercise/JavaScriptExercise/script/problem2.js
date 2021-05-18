let menu = {
    width: 200,
    height: 300,
    title: "my menu"
};

function multiplyNumeric(input) {
    for (let key in input) {
        if (typeof (input[key]) == "number") {
            input[key] = input[key] * 2;
        }
    }
}

multiplyNumeric(menu);

console.log(menu);