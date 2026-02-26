class Product {
  constructor({ name, price, category = "General", ...rest }) {
    this.name = name;
    this.price = price;
    this.category = category;
    this.extraDetails = { ...rest };
  }

  getDetails = () =>
    `${this.name} costs ₹${this.price} and belongs to ${this.category} category`;

  updatePrice = (newPrice = this.price) => {
    this.price = newPrice;
  };
}

let product1 = new Product({
  name: "Laptop",
  price: 50000,
  brand: "Dell",
  warranty: "1 Year"
});

console.log(product1.getDetails());

product1.updatePrice(55000);
console.log(product1.getDetails());

console.log(product1.extraDetails);