using DoctorAppointmentHaining.Application.Dtos;
using DoctorAppointmentHaining.Application.UseCases;
using DoctorAppointmentHaining.Domain.Entities;
using DoctorAppointmentHaining.Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace DoctorAppointmentHaining.API.Controllers
{
    [Controller]
    [Route("/Doctor")]
    public class TimeAppointController : ControllerBase
    {
        private readonly CreatDoctorSlot _creatDoctorSlot;
        private TimeAppointDb _SlotDB;

        public TimeAppointController(TimeAppointDb SlotDB, CreatDoctorSlot creatDoctorSlot)
        {
            _SlotDB = SlotDB;
            _creatDoctorSlot = creatDoctorSlot;

        }

        [HttpGet("getslots")]
        public async Task<IActionResult> Get([FromHeader] string? name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return Ok(_SlotDB.TimeSlot_SHN.ToList());
            }

            var product = await _SlotDB.TimeSlot_SHN.Where(item => item.DoctorName == name).ToListAsync();

            if (product == null)
            {
                return BadRequest("Slot not found!");
            }

            return Ok(product);
        }

        [HttpPost("postslots")]
        public async Task<IActionResult> PostAsync([FromBody] CreateDoctorSlotsRequest Doctorslot)
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

            await _creatDoctorSlot.Execute(Doctorslot);
            return Ok("Slot Created!");
        }
    }
}
