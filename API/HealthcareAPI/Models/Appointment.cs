public class Appointment
{
    public int Id { get; set; }
    public string? DoctorName { get; set; }
    public DateTime Date { get; set; }
    public int PatientId { get; set; }
}