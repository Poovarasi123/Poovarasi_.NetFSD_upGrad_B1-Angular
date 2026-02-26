class Wallet {
  #balance = 0;

  addMoney(amount) {
    if (amount > 0) {
      this.#balance += amount;
    }
  }

  spendMoney(amount) {
    if (amount <= this.#balance) {
      this.#balance -= amount;
    } else {
      console.log("Insufficient balance");
    }
  }

  getBalance() {
    return this.#balance;
  }
}

let myWallet = new Wallet();

myWallet.addMoney(1000);
myWallet.spendMoney(300);

console.log(myWallet.getBalance());