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
        public IActionResult GetById(string id)
        {
            var result = _service.GetById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet("office/{officeId}")]
        public IActionResult GetByOffice(string officeId)
        {
            return Ok(_service.GetByOffice(officeId));
        }

        [HttpPut("{id}/cancel")]
        public IActionResult Cancel(string id)
        {
            var ok = _service.Cancel(id);
            if (!ok) return NotFound();
            return Ok(new { message = "Appointment cancelled" });
        }
    }
}
