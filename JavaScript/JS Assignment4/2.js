let students = [
  { name: "Akhil", marks: 85 },
  { name: "Priya", marks: 72 },
  { name: "Ravi", marks: 90 },
  { name: "Meena", marks: 45 },
  { name: "Karan", marks: 30 }
];

console.log("Passed Students:");
console.log(students.filter(s => s.marks >= 40));

console.log("Distinction Students:");
console.log(students.filter(s => s.marks >= 85));

const average = students.reduce((sum, s) => sum + s.marks, 0) / students.length;
console.log("Class Average:", average);

const topper = students.reduce((max, s) => s.marks > max.marks ? s : max);
console.log("Topper:");
console.log(topper);

const failedCount = students.filter(s => s.marks < 40).length;
console.log("Failed Students Count:", failedCount);

const gradedStudents = students.map(s => ({
  ...s,
  grade:
    s.marks >= 85 ? "A" :
    s.marks >= 60 ? "B" :
    s.marks >= 40 ? "C" : "Fail"
}));
console.log("Students with Grades:");
console.log(gradedStudents);

const rankedStudents = [...students]
  .sort((a, b) => b.marks - a.marks)
  .map((s, index) => ({ ...s, rank: index + 1 }));
console.log("Ranked Students:");
console.log(rankedStudents);

const lowestMarks = Math.min(...students.map(s => s.marks));
const withoutLowest = students.filter(s => s.marks !== lowestMarks);
console.log("After Removing Lowest Scorer:");
console.log(withoutLowest);

const leaderboard = [...students].sort((a, b) => b.marks - a.marks);
console.log("Leaderboard:");
console.log(leaderboard);