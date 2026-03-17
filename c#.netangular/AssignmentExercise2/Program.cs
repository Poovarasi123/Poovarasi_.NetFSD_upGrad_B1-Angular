using System;

class Program
{
    static void Main()
    {
        Assignment1();
        Assignment2();
        Assignment3();
        Assignment4();
        Assignment5();
        Assignment6();
        Assignment7();
        Assignment8();
    }

    static void Assignment1()
    {
        Patient p = new Patient();
        p.PatientId = 101;
        p.PatientName = "Ravi Kumar";
        p.Age = 45;
        p.Disease = "Diabetes";

        Console.WriteLine("Patient Id: " + p.PatientId);
        Console.WriteLine("Patient Name: " + p.PatientName);
        Console.WriteLine("Age: " + p.Age);
        Console.WriteLine("Disease: " + p.Disease);
        Console.WriteLine();
    }

    static void Assignment2()
    {
        Doctor d1 = new Doctor();
        Doctor d2 = new Doctor();

        d1.DoctorId = 1;
        d1.DoctorName = "Dr Kumar";
        d1.Specialization = "Cardiology";
        d1.ConsultationFee = 500;

        d2.DoctorId = 2;
        d2.DoctorName = "Dr Meena";
        d2.Specialization = "Dermatology";
        d2.ConsultationFee = 400;

        Console.WriteLine(d1.DoctorName);
        Console.WriteLine(d2.DoctorName);
        Console.WriteLine();
    }

    static void Assignment3()
    {
        Hospital.HospitalName = "Apollo Hospital";
        Hospital.HospitalAddress = "Chennai";

        Hospital p1 = new Hospital();
        Hospital p2 = new Hospital();
        Hospital p3 = new Hospital();

        p1.PatientName = "Ravi";
        p2.PatientName = "Sita";
        p3.PatientName = "Arun";

        Console.WriteLine(Hospital.HospitalName);
        Console.WriteLine(p1.PatientName);
        Console.WriteLine(p2.PatientName);
        Console.WriteLine(p3.PatientName);
        Console.WriteLine();
    }

    static void Assignment4()
    {
        Appointment a = new Appointment();
        a.AppointmentId = 1;
        a.PatientName = "Ravi";

        Console.WriteLine(a.DoctorName);
        Console.WriteLine(a.AppointmentDate);
        Console.WriteLine();
    }

    static void Assignment5()
    {
        MedicalTest t1 = new MedicalTest(1, "Blood Test", 500);
        MedicalTest t2 = new MedicalTest(2, "X-Ray", 1000);

        Console.WriteLine(t1.TestName);
        Console.WriteLine(t2.TestName);
        Console.WriteLine();
    }

    static void Assignment6()
    {
        Billing b = new Billing();
        b.PatientName = "Ramesh";
        b.ConsultationFee = 1000;
        b.TestCharges = 500;

        Console.WriteLine("Total Bill: " + b.CalculateTotalBill());
        Console.WriteLine();
    }

    static void Assignment7()
    {
        Nurse n = new Nurse
        {
            NurseId = 1,
            NurseName = "Anita",
            Department = "Emergency"
        };

        Console.WriteLine(n.NurseName);
        Console.WriteLine();
    }

    static void Assignment8()
    {
        PatientRecord.HospitalName = "Apollo Hospital";

        PatientRecord p1 = new PatientRecord(101, "Ravi", 40, "Fever");
        PatientRecord p2 = new PatientRecord(102, "Sita", 35, "Cold");
        PatientRecord p3 = new PatientRecord(103, "Arun", 50, "Diabetes");

        p1.DisplayPatientRecord();
        p2.DisplayPatientRecord();
        p3.DisplayPatientRecord();
    }
}
