using DoctorAppointmentHaining.Application.Dtos;
using DoctorAppointmentHaining.Domain.Contracts;
using DoctorAppointmentHaining.Domain.Entities;
using DoctorAppointmentHaining.Domain.Exceptions;
using Microsoft.IdentityModel.Tokens;

namespace DoctorAppointmentHaining.Application.UseCases
{
    public class CreatPatientAppoint
    {
        private readonly IPatientRepository _patientRepository;
        public CreatPatientAppoint(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public async Task Execute(CreatePatientAppRequest request)
        {
            if (string.IsNullOrEmpty(request.PatientName))
            {
                throw new PatientNameEmptyExistsException();
            }

            var slot = new PatientAppointSlot { Id = request.Id, SlotId = request.SlotId, PatientId = request.PatientId, PatientName = request.PatientName, ReservedAt = request.ReservedAt };

            await _patientRepository.Add(slot);
        }
    }
}
