using System.ComponentModel.DataAnnotations;

namespace DoctorAppointmentHaining.Application.Dtos
{
    public class CreateDoctorSlotsRequest
    {
        [Required] public Guid Id { get; set; }
        [Required] public DateTime Time { get; set; }
        [Required] public Guid DoctorId { get; set; }
        [Required] public string? DoctorName { get; set; }
        [Required] public bool IsReserved { get; set; }
        [Required] public decimal Cost { get; set; }
        public Guid PatientId { get; set; }
        public string? PatientName { get; set; }
    }
}
