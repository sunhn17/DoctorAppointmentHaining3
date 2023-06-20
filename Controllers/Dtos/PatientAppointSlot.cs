namespace DoctorAppointmentHaining.Controllers.Dtos
{
    public class PatientAppointSlot
    {
        public Guid Id { get; set; }
        public Guid SlotId { get; set; }
        public Guid PatientId { get; set; }
        public string? PatientName { get; set; }
        public DateTime ReservedAt { get; set; }
    }
}
