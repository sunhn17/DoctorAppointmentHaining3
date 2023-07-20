using System.ComponentModel.DataAnnotations;

namespace DoctorAppointmentHaining.Application.Dtos
{
    public class CreatePatientAppRequest
    {
        [Required] public Guid Id { get; set; }
        [Required] public Guid SlotId { get; set; }
        [Required] public Guid PatientId { get; set; }
        [Required] public string? PatientName { get; set; }
        [Required] public DateTime ReservedAt { get; set; }
        public string? DoctorName { get; set; }
        public bool IsReserved { get; set; }
        public decimal Cost { get; set; }
    }
}
