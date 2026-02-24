let employees = [
 { id:1, name:"Ravi", dept:"IT", salary:70000 },
 { id:2, name:"Anita", dept:"HR", salary:50000 },
 { id:3, name:"Karan", dept:"IT", salary:80000 },
 { id:4, name:"Meena", dept:"Finance", salary:60000 }
];

const totalSalary = employees.reduce((sum, e) => sum + e.salary, 0);
console.log("Total Salary Expense:", totalSalary);

const highestPaid = employees.reduce((max, e) => e.salary > max.salary ? e : max);
const lowestPaid = employees.reduce((min, e) => e.salary < min.salary ? e : min);
console.log("Highest Paid:", highestPaid);
console.log("Lowest Paid:", lowestPaid);

const updatedIT = employees.map(e =>
  e.dept === "IT"
    ? { ...e, salary: +(e.salary * 1.15).toFixed(2) }
    : e
);
console.log("After 15% IT Salary Increase:");
console.log(updatedIT);

const groupedByDept = employees.reduce((acc, e) => {
  acc[e.dept] = acc[e.dept] || [];
  acc[e.dept].push(e);
  return acc;
}, {});
console.log("Grouped by Department:");
console.log(groupedByDept);

const deptAvgSalary = Object.keys(groupedByDept).reduce((acc, dept) => {
  const avg = groupedByDept[dept].reduce((sum, e) => sum + e.salary, 0) / groupedByDept[dept].length;
  acc[dept] = avg;
  return acc;
}, {});
console.log("Department-wise Average Salary:");
console.log(deptAvgSalary);

const sortedEmployees = [...employees].sort((a, b) => b.salary - a.salary);
console.log("Sorted by Salary Descending:");
console.log(sortedEmployees);

const afterTax = employees.map(e => ({
  ...e,
  salaryAfterTax: +(e.salary * 0.9).toFixed(2)
}));
console.log("After 10% Tax Deduction:");
console.log(afterTax);

const overallAverage = totalSalary / employees.length;
const aboveAverage = employees.filter(e => e.salary > overallAverage);
console.log("Employees Above Average Salary:");
console.log(aboveAverage);

const htmlTable =
  "<table border='1'>" +
  "<tr><th>ID</th><th>Name</th><th>Dept</th><th>Salary</th></tr>" +
  employees.map(e =>
    `<tr><td>${e.id}</td><td>${e.name}</td><td>${e.dept}</td><td>${e.salary}</td></tr>`
  ).join("") +
  "</table>";

console.log("HTML Table:");
console.log(htmlTable);