namespace DoctorAppointmentHaining.Domain.Entities
{
    public class DoctorTimeSlot
    {
        public Guid Id { get; set; }
        public DateTime Time { get; set; }
        public Guid DoctorId { get; set; }
        public string DoctorName { get; set; }
        public bool IsReserved { get; set; }
        public decimal Cost { get; set; }
        public Guid PatientId { get; set; }
        public string? PatientName { get; set; }
    }
}
