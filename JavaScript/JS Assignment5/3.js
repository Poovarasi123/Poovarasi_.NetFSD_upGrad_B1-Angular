class Student {
  constructor(name) {
    this.name = name;
    this.marks = [];
  }

  addMark(mark) {
    this.marks.push(mark);
  }

  getAverage() {
    let sum = this.marks.reduce((a, b) => a + b, 0);
    return sum / this.marks.length;
  }

  getGrade() {
    let avg = this.getAverage();
    if (avg >= 90) return "A";
    if (avg >= 75) return "B";
    if (avg >= 50) return "C";
    return "Fail";
  }
  getDetails() {
    console.log(`Student Name: ${this.name}`);
    console.log(`Marks: ${this.marks.join(", ")}`);
    console.log(`Average: ${this.getAverage().toFixed(2)}`);
    console.log(`Grade: ${this.getGrade()}`);
    console.log("---------------------------");
  }

}
let s1 = new Student("Rahul");
s1.addMark(95);
s1.addMark(88);
s1.addMark(92);
s1.getDetails();