let books = [
  { id: 1, title: "JavaScript Basics", price: 450, stock: 10 },
  { id: 2, title: "React Guide", price: 650, stock: 5 },
  { id: 3, title: "Node.js Mastery", price: 550, stock: 8 },
  { id: 4, title: "CSS Complete", price: 300, stock: 12 }
];

console.log("Book Titles:");
console.log(books.map(b => b.title));

const totalValue = books.reduce((sum, b) => sum + b.price * b.stock, 0);
console.log("Total Inventory Value:", totalValue);

const costlyBooks = books.filter(b => b.price > 500);
console.log("Books above ₹500:");
console.log(costlyBooks);

const updatedBooks = books.map(b => ({
  ...b,
  price: +(b.price * 1.05).toFixed(2)
}));
console.log("Price Increased by 5%:");
console.log(updatedBooks);

const sortedBooks = [...books].sort((a, b) => a.price - b.price);
console.log("Sorted by Price (Low to High):");
console.log(sortedBooks);

const remainingBooks = books.filter(b => b.id !== 2);
console.log("After Removing Book with ID 2:");
console.log(remainingBooks);

const isOutOfStock = books.some(b => b.stock === 0);
console.log("Any Book Out of Stock?");
console.log(isOutOfStock);

const grouped = books.reduce((acc, b) => {
  if (b.price < 400) acc.low.push(b);
  else if (b.price <= 600) acc.medium.push(b);
  else acc.high.push(b);
  return acc;
}, { low: [], medium: [], high: [] });

console.log("Grouped by Price Range:");
console.log(grouped);

const discounted = books.map(b =>
  b.price > 600
    ? { ...b, price: +(b.price * 0.9).toFixed(2) }
    : b
);

console.log("After 10% Discount (Above ₹600):");
console.log(discounted);

const invoice = books
  .map(b => `${b.title} - ₹${b.price}`)
  .join("\n");

console.log("Invoice:");
console.log(invoice);