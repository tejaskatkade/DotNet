using HealthBuddyApp.DTO.ReqDto;
using HealthBuddyApp.Repository;
using HealthBuddyApp.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Ocsp;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HealthBuddyApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        private readonly IHospitalService service;

        public HospitalController(IHospitalService service)
        {
            this.service = service;       
        }
        // GET: api/<HospitalController>
        [HttpGet]
        public IActionResult Get()
        {
            var hospitals = service.getAllHospitals();
            if (hospitals == null)
                return NotFound(new { Message = $"No hospitals found " });

            return Ok(hospitals);
        }
        [HttpGet("active")]
        public IActionResult GetActive()
        {
            var hospitals = service.getActiveHospitals();
            if (hospitals == null)
                return NotFound(new { Message = $"No Active hospitals found " });

            return Ok(hospitals);
        }

        // GET api/<HospitalController>/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var hospital = service.getActiveHospitals();
            if (hospital == null)
                return NotFound(new { Message = $"No doctor found " });

            return Ok(hospital);
        }

        // POST api/<HospitalController>
        [HttpPost]
        public string Post([FromBody] HospitalReqDto hospitalDto)
        {
            return service.addHospital(hospitalDto);
        }

        // PUT api/<HospitalController>/5
        [HttpPut("{id}")]
        public string Put(long id, [FromBody] HospitalReqDto hospitalDto)
        {
            return service.updateHospital(id, hospitalDto);
        }

        // DELETE api/<HospitalController>/5
        [HttpDelete("{hospId}/doctor/{doctorId}")]
        public string RemoveDoctor(long hospId, long doctorId)
        {
            return service.removeDoctor(hospId, doctorId);
        }

        [HttpPost("{hospid}/doctor/{doctorId}")]
        public string addDocInHosp(long hospid, long doctorId)
        {
            return service.addDoctor(hospid, doctorId);
        }

        [HttpPatch("activate/{hospId}")]
        public string activateHospital(long hospId)
        {
            return service.activateHospital(hospId);
        }
        [HttpPatch("inActivate/{hospId}")]
        public string inActivateHospital(long hospId)
        {
            return service.inActivateHospital(hospId);
        }
    }
}
