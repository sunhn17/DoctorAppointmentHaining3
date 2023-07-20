using DoctorAppointmentHaining.Domain.Contracts;
using DoctorAppointmentHaining.Domain.Entities;

namespace DoctorAppointmentHaining.Infrastructure.Repositories
{
    public class PatientAppointInMemoryRepo : IPatientRepository
    {
        private static readonly List<PatientAppointSlot> PatientAppointSlots = new();
        public async Task Add(PatientAppointSlot patientTimeSlot)
        {
            PatientAppointSlots.Add(patientTimeSlot);
        }
    }
}
