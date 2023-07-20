using Azure.Core;
using DoctorAppointmentHaining.Domain.Contracts;
using DoctorAppointmentHaining.Domain.Entities;
using DoctorAppointmentHaining.Infrastructure.Database;

namespace DoctorAppointmentHaining.Infrastructure.Repositories
{
    public class PatientAppointRepo : IPatientRepository
    {
        private readonly TimeAppointDb _db;
        public PatientAppointRepo(TimeAppointDb db)
        {
            _db = db;
        }

        public async Task Add(PatientAppointSlot patientAppointSlot)
        {
            var appointmentSlot = await _db.TimeSlot_SHN.FindAsync(patientAppointSlot.SlotId);

            appointmentSlot.PatientName = patientAppointSlot.PatientName;
            appointmentSlot.PatientId = patientAppointSlot.PatientId;
            appointmentSlot.IsReserved = true;

            _db.TimeSlot_SHN.Update(appointmentSlot);
            await _db.SaveChangesAsync();

        }
    }

}
