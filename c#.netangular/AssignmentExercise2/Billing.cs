class Billing
{
    public string PatientName;
    public int ConsultationFee;
    public int TestCharges;

    public int CalculateTotalBill()
    {
        return ConsultationFee + TestCharges;
    }
}