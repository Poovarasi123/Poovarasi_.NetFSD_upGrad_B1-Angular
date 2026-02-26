class BankAccount {
  constructor(accountHolder, balance = 0) {
    this.accountHolder = accountHolder;
    this.balance = balance;
  }

  deposit(amount) {
    if (amount <= 0) {
      console.log("Deposit amount must be positive");
      return;
    }
    this.balance += amount;
    console.log(`Deposited ₹${amount}`);
  }

  withdraw(amount) {
    if (amount <= 0) {
      console.log("Withdrawal amount must be positive");
      return;
    }

    if (amount > this.balance) {
      console.log("Insufficient balance");
    } else {
      this.balance -= amount;
      console.log(`Withdrawn ₹${amount}`);
    }
  }

  checkBalance() {
    console.log(`Account Holder: ${this.accountHolder}`);
    console.log(`Balance: ₹${this.balance}`);
    console.log("---------------------------");
  }
}

let acc1 = new BankAccount("Rahul", 1000);

acc1.checkBalance();  
acc1.deposit(500);     
acc1.withdraw(200);    
acc1.withdraw(2000);   
acc1.checkBalance();  