function validateCard(cardNumber,cardPrefixes) {
    let luhnCheck = num => {
        let array = (num + '')
            .split(' ')
            .reverse()
            .map(x => parseInt(x));
    }
    let lastDigit = arr.splice(0, 1)[0];
    let sum = arr.reduce((acc, val, i) => (i % 2 !== 0 ? acc + val : acc + ((val * 2) % 9 || 9), 0);
    sum += lastDigit;
    return sum % 10 === 0;
};

var cardNumber = "6724112312432478";
var cardPrefixes = "asdasddqw";
console.log(validateCard(cardNumber, cardPrefixes));
