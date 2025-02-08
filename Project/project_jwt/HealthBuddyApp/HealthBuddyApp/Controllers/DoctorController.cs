using System.Collections.Generic;
using HealthBuddyApp.DTO.ReqDto;
using HealthBuddyApp.DTO.ResDto;
using HealthBuddyApp.Entity;
using HealthBuddyApp.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HealthBuddyApp.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService service;
        public DoctorController(IDoctorService service)
        {
            this.service = service;
        }
        // GET: api/<DoctorController>
        [HttpGet]
        public IActionResult Get()
        {
            var doctors = service.getAllDoctors();
            if (doctors == null)
                return NotFound(new { Message = $"No doctor found " });

            return Ok(doctors);
        } 
        
        [HttpGet("active")]
        public IActionResult GetActive()
        {
            var doctors = service.getAllActiveDoctors();
            if (doctors == null)
                return NotFound(new { Message = $"No doctor found " });

            return Ok(doctors);
        }
        
        [HttpGet("hosp/{hospId}")]
        public IActionResult GetDoctorsByHosp(long hospId)
        {
            var doctors = service.getDoctorsByHospital(hospId);
            if (doctors == null)
                return NotFound(new { Message = $"No doctor found " });

            return Ok(doctors);
        }

        // GET api/<DoctorController>/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {   
                var doctor = service.getDoctorById(id);

                if (doctor == null)
                    return NotFound(new { Message = $"No doctor found with ID {id}" });

                return Ok(doctor);
        }

        // POST api/<DoctorController>
        [HttpPost]
        public ApiResponse Post([FromBody] DoctorReqDto doctorDto)
        {
            return service.addDoctor(doctorDto);

        }

        // PUT api/<DoctorController>/5
        [HttpPut("{id}")]
        public ApiResponse Put(int id, [FromBody] DoctorReqDto doctorDto)
        {
            return service.updateDoctor(id, doctorDto);
        }

        // DELETE api/<DoctorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpPatch("inactivate/{doctorId}")]
        public ApiResponse InActivateDoctor(int doctorId)
        {
            return service.inActivateDoctor(doctorId);
        }
        [HttpPatch("activate/{doctorId}")]
        public ApiResponse ActivateDoctor(int doctorId)
        {
            return service.activateDoctor(doctorId);
        }
    }
}
