using HealthBuddyApp.DTO.ReqDto;
using HealthBuddyApp.DTO.ResDto;
using HealthBuddyApp.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HealthBuddyApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {

        private IAppointmentService _appointementService;

        public AppointmentController(IAppointmentService appointementService)
        {
            _appointementService = appointementService;
        }

        // GET: api/<AppointementController>
        [HttpGet]
        public List<AppointmentResDto> Get()
        {
            return _appointementService.getAllAppointments();
        }

        // GET api/<AppointementController>/5
        [HttpGet("{id}")]
        public AppointmentResDto Get(long id)
        {
            return  _appointementService.getAppointment(id);
        } 
        
        [HttpGet("patient/{patientId}")]
        public List<AppointmentResDto> GetByPatient(long patientId)
        {
            return  _appointementService.getAppointmentsBypatientId(patientId);
        }

        [HttpGet("doctor/{doctorId}")]
        public List<AppointmentResDto> GetByDoctor(long doctorId)
        {
            return _appointementService.getAppointmentsByDoctorId(doctorId);
        }

        [HttpGet("hosp/{hospId}")]
        public List<AppointmentResDto> GetByHospital(long hospId)
        {
            return _appointementService.getAppointmentsByHospitalId(hospId);
        }

        // POST api/<AppointementController>
        [HttpPost]
        public string Post([FromBody] AppointmentReqDto appointmentReqDto)
        {
            return _appointementService.bookAppointment(appointmentReqDto);
        }

        // PUT api/<AppointementController>/5
        [HttpPatch("cancle/{appointId}")]
        public string cancleAppointment( long appointId)
        {
            return _appointementService.cancleAppointment(appointId);
        }

        [HttpPatch("complete/{appointId}")]
        public string completeAppointment(long appointId)
        {
            return _appointementService.completeAppointment(appointId);
        }
    }
}
