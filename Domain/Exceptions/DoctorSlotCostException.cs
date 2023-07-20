namespace DoctorAppointmentHaining.Domain.Exceptions
{
    public class DoctorSlotCostException : Exception
    {
        public DoctorSlotCostException() : base("Cost is not sent correctly")
        {
        }
    }
}
