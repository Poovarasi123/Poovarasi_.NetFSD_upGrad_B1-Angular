using System;

class Appointment
{
    public int AppointmentId;
    public string PatientName;
    public string DoctorName;
    public DateTime AppointmentDate;

    public Appointment()
    {
        DoctorName = "General Physician";
        AppointmentDate = DateTime.Today;
    }
}