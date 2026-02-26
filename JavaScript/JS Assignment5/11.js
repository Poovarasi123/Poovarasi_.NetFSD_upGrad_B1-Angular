class User {
  constructor() {
    this._password = "";
  }

  set password(value) {
    if (value.length >= 6) {
      this._password = value;
    } else {
      console.log("Password must be at least 6 characters");
    }
  }

  get password() {
    return this._password;
  }
}

let user1 = new User();

user1.password = "abc";       
user1.password = "secure123"; 

console.log(user1.password);