using Microsoft.AspNetCore.Mvc;
using AppointmentApi.Models;
using AppointmentApi.Services;

namespace AppointmentApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly AppointmentService _service;

        public AppointmentController(AppointmentService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Appointment appointment)
        {
            var created = await _service.CreateAsync(appointment);
            return Ok(created);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet("office/{officeName}")]
        public async Task<IActionResult> GetByOfficeName(string officeName)
        {
            var result = await _service.GetByOfficeNameAsync(officeName);
            return Ok(result);
        }

        [HttpGet("city/{cityCode}")]
        public async Task<IActionResult> GetByCityCode(int cityCode)
        {
            var result = await _service.GetByCityCodeAsync(cityCode);
            return Ok(result);
        }

        [HttpGet("citizen/{citizenId}")]
        public async Task<IActionResult> GetByCitizenId(int citizenId)
        {
            var result = await _service.GetByCitizenIdAsync(citizenId);
            return Ok(result);
        }

        [HttpPut("{id}/cancel")]
        public async Task<IActionResult> Cancel(string id)
        {
            var success = await _service.CancelAsync(id);
            if (!success) return NotFound();
            return Ok(new { message = "Appointment cancelled" });
        }
    }
}
