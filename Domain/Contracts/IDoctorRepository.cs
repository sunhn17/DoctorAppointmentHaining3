using DoctorAppointmentHaining.Domain.Entities;

namespace DoctorAppointmentHaining.Domain.Contracts
{
    public interface IDoctorRepository
    {
        public Task Add(DoctorTimeSlot doctorTimeSlot);
    }
}
