class Employee {
  constructor(name, salary) {
    this.name = name;
    this.salary = salary;
  }

  getDetails() {
    console.log(`Name: ${this.name}`);
    console.log(`Base Salary: ₹${this.salary}`);
  }
}

class Manager extends Employee {
  constructor(name, salary, bonus) {
    super(name, salary);  
    this.bonus = bonus;
  }

  getTotalSalary() {
    return this.salary + this.bonus;
  }
}

class Director extends Manager {
  constructor(name, salary, bonus, stockOptions) {
    super(name, salary, bonus);  
    this.stockOptions = stockOptions;
  }

  getFullCompensation() {
    return this.getTotalSalary() + this.stockOptions;
  }
}

let director1 = new Director("Rahul", 80000, 20000, 50000);

director1.getDetails();  
console.log(`Bonus: ₹${director1.bonus}`);
console.log(`Total Salary (with bonus): ₹${director1.getTotalSalary()}`);
console.log(`Full Compensation (with stock): ₹${director1.getFullCompensation()}`);