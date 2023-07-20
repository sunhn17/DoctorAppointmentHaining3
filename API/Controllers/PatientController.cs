using DoctorAppointmentHaining.Application.Dtos;
using DoctorAppointmentHaining.Application.UseCases;
using DoctorAppointmentHaining.Domain.Entities;
using DoctorAppointmentHaining.Infrastructure.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace DoctorAppointmentHaining.API.Controllers
{
    [Controller]
    [Route("/Patient")]
    [Authorize]
    public class PatientController : ControllerBase
    {
        private readonly CreatPatientAppoint _creatPatientAppoint;
        private TimeAppointDb _SlotDB;
        private readonly ILogger<PatientController> _logger;

        public PatientController(TimeAppointDb SlotDB, CreatPatientAppoint creatPatientAppoint, ILogger<PatientController> logger)
        {
            _SlotDB = SlotDB;
            _creatPatientAppoint = creatPatientAppoint;
            _logger = logger;
        }

        [HttpGet("getslots")]
        public async Task<IActionResult> Get([FromHeader] string? name)
        {
            var timeslot = await _SlotDB.TimeSlot_SHN.Where(item => item.IsReserved == false).ToListAsync();

            if (timeslot.Count == 0)
            {
                return Ok("Appointment Slot Not Found!");
            }

            return Ok(timeslot);

        }
        [HttpPost("postslots")]
        public async Task<IActionResult> PostAsync([FromBody] CreatePatientAppRequest appointslot)
        {
            Console.WriteLine(JsonSerializer.Serialize(HttpContext.Request.Headers));
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(value => value.Errors)
                    .Select(error => error.ErrorMessage)
                    .ToList();
                return BadRequest(errors);
            }

            var appointmentSlot = await _SlotDB.TimeSlot_SHN.FindAsync(appointslot.SlotId);

            _logger.LogInformation("Appointment from Patient: ${PatientName}", appointslot.PatientName);
            _logger.LogInformation("Appointment time: ${ReservedAt}", appointslot.ReservedAt);
            _logger.LogInformation("Appointment to Doctor name: ${DoctorName}", appointmentSlot.DoctorName);

            await _creatPatientAppoint.Execute(appointslot);

            return Ok("Appointment Succeful!");
        }
    }
}
