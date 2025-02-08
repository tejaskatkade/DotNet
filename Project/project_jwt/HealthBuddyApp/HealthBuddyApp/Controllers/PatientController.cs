using HealthBuddyApp.DTO.ReqDto;
using HealthBuddyApp.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HealthBuddyApp.Controllers
{
    

    [Route("[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private IPatientService  patientService;

        public PatientController(IPatientService patientService)
        {
               this.patientService = patientService;
        }

        // GET: api/<PatientController>
        [HttpGet]
        public IActionResult Get()
        {
            var patients = patientService.getAllPatients();
            if (patients == null)
                return NotFound(new { Message = $"No patient found " });

            return Ok(patients);
        }

        // GET api/<PatientController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var patient = patientService.getPatientById(id);
            if (patient == null)
                return NotFound(new { Message = $"No patient found " });

            return Ok(patient);
        }

        // POST api/<PatientController>
        [HttpPost]
        public string Post([FromBody] PatientReqDto patientDto)
        {
            return patientService.addPatient(patientDto);
        }

        // PUT api/<PatientController>/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] PatientReqDto patientDto)
        {
            return patientService.updatePatient(id, patientDto);
        }

        // DELETE api/<PatientController>/5
        [HttpPatch("activate/{id}")]
        public string activatePatient(int id)
        {
            return patientService.activatePatient(id);
        } 
        
        [HttpPatch("inActivate/{id}")]
        public string inActivatePatient(int id)
        {
            return patientService.inActivatePatient(id);
        }
    }
}
