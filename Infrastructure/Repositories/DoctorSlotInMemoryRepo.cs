using DoctorAppointmentHaining.Domain.Contracts;
using DoctorAppointmentHaining.Domain.Entities;

namespace DoctorAppointmentHaining.Infrastructure.Repositories
{
    public class DoctorSlotInMemoryRepo : IDoctorRepository
    {
        private static readonly List<DoctorTimeSlot> DoctorTimeSlots = new();
        public async Task Add(DoctorTimeSlot doctorTimeSlot)
        {
            DoctorTimeSlots.Add(doctorTimeSlot);
        }
    }
}
