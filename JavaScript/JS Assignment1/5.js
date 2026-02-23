let number = 7;
let sign = (number >= 0) ? "Positive" : "Negative";
let type;
if (number % 2 === 0) {
    type = "Even";
} else {
    type = "Odd";
}

console.log("Number: " + number);
console.log("Sign: " + sign);
console.log("Type: " + type);

for (let i = 1; i <= number; i++) {
    console.log(i);
}