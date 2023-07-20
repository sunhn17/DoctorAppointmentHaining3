using DoctorAppointmentHaining.Domain.Entities;

namespace DoctorAppointmentHaining.Domain.Contracts
{
    public interface IPatientRepository
    {
        public Task Add(PatientAppointSlot patientAppointSlot);
    }
}
