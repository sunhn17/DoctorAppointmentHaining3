namespace DoctorAppointmentHaining.Domain.Entities
{
    public class PatientAppointSlot
    {
        public Guid Id { get; set; }
        public Guid SlotId { get; set; }
        public Guid PatientId { get; set; }
        public string? PatientName { get; set; }
        public DateTime ReservedAt { get; set; }

        public string? DoctorName { get; set; }
        public bool IsReserved { get; set; }
        public decimal Cost { get; set; }

    }
}
