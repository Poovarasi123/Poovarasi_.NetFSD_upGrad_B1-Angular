let cart = [
  { id: 1, product: "Laptop", price: 60000, qty: 1 },
  { id: 2, product: "Headphones", price: 2000, qty: 2 },
  { id: 3, product: "Mouse", price: 800, qty: 1 }
];

const totalValue = cart.reduce((sum, item) => sum + item.price * item.qty, 0);
console.log("Total Cart Value:", totalValue);

const increasedQty = cart.map(item =>
  item.id === 2 ? { ...item, qty: item.qty + 1 } : item
);
console.log("After Increasing Quantity (ID 2):");
console.log(increasedQty);

const updatedCart = cart.filter(item => item.id !== 3);
console.log("After Removing Product (ID 3):");
console.log(updatedCart);

const discountedCart = cart.map(item =>
  item.price > 10000
    ? { ...item, price: +(item.price * 0.9).toFixed(2) }
    : item
);
console.log("After 10% Discount (Above ₹10000):");
console.log(discountedCart);

const sortedCart = [...cart].sort(
  (a, b) => (a.price * a.qty) - (b.price * b.qty)
);
console.log("Sorted by Total Item Price:");
console.log(sortedCart);

const expensiveCheck = cart.some(item => item.price > 50000);
console.log("Any Product Above ₹50000?");
console.log(expensiveCheck);

const stockCheck = cart.every(item => item.qty > 0);
console.log("All Items In Stock?");
console.log(stockCheck);

const invoice = cart
  .map(item => `${item.product} x${item.qty} = ₹${item.price * item.qty}`)
  .join("\n");
console.log("Invoice:");
console.log(invoice);

const mostExpensive = cart.reduce((max, item) =>
  item.price > max.price ? item : max
);
console.log("Most Expensive Product:");
console.log(mostExpensive);

const gst = +(totalValue * 0.18).toFixed(2);
console.log("GST (18%):", gst);
console.log("Total with GST:", totalValue + gst);