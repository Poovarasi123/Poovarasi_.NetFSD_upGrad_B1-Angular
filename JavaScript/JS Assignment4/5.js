let numbers = [10, 20, 30, 10, 40, 20, 50, 60, 60];

const uniqueNumbers = [...new Set(numbers)];
console.log("Remove Duplicates:", uniqueNumbers);

const secondLargest = [...new Set(numbers)]
  .sort((a, b) => b - a)[1];
console.log("Second Largest:", secondLargest);

const frequency = numbers.reduce((acc, num) => {
  acc[num] = (acc[num] || 0) + 1;
  return acc;
}, {});
console.log("Frequency:", frequency);

const firstNonRepeating = numbers.find(num => frequency[num] === 1);
console.log("First Non-Repeating:", firstNonRepeating);

const rotateBy2 = [
  ...numbers.slice(2),
  ...numbers.slice(0, 2)
];
console.log("Rotated by 2:", rotateBy2);

let nested = [1, 2, [3, 4, [5]]];
const flattened = nested.flat(Infinity);
console.log("Flattened Array:", flattened);

let arr = [1, 2, 3, 5, 6];
const missingNumber = (() => {
  const n = arr.length + 1;
  const expectedSum = (n * (n + 1)) / 2;
  const actualSum = arr.reduce((sum, num) => sum + num, 0);
  return expectedSum - actualSum;
})();
console.log("Missing Number:", missingNumber);