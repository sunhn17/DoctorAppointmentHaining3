using DoctorAppointmentHaining.Application.Dtos;
using DoctorAppointmentHaining.Domain.Contracts;
using DoctorAppointmentHaining.Domain.Entities;
using DoctorAppointmentHaining.Domain.Exceptions;
using Microsoft.Extensions.Hosting;

namespace DoctorAppointmentHaining.Application.UseCases
{
    public class CreatDoctorSlot
    {
        private readonly IDoctorRepository _doctorRepository;

        public CreatDoctorSlot(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task Execute(CreateDoctorSlotsRequest request)
        {
            if (request.Cost == 0)
            {
                throw new DoctorSlotCostException();
            }

            var slot = new DoctorTimeSlot { Id = request.Id, Time = request.Time, DoctorId = request.DoctorId, DoctorName = request.DoctorName, IsReserved = request.IsReserved, Cost = request.Cost };

            await _doctorRepository.Add(slot);
        }
    }
}
