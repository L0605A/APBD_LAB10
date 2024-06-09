using CodeFirst.Models;
using CodeFirst.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CodeFirst.Endpoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionsController : ControllerBase
    {
        private readonly IServices _services;

        public PrescriptionsController(IServices services)
        {
            _services = services;
        }

        [HttpPost]
        public async Task<IActionResult> AddPrescription(PrescriptionRequestDto request)
        {
            if (request.DueDate < request.Date)
            {
                return BadRequest("DueDate must be greater than or equal to Date");
            }
            
            if (request.Medicaments.Count > 10)
            {
                return BadRequest("A prescription can include a maximum of 10 medicaments");
            }

            var doctorExistance = await _services.DoctorExists(request.IdDoctor);
            
            if (!doctorExistance)
            {
                return NotFound("Doctor not found");
            }
            
            var MedicamentCorrect = await _services.CorrectMedicaments(request);
            
            if (!MedicamentCorrect)
            {
                return BadRequest("One or more incorrect medicaments");
            }


            var result = await _services.AddPrescriptionAsync(request);

            Console.WriteLine(await _services.PatientExists(request.Patient.IdPatient));
            
            return Ok(result);
            
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatient(int id)
        {
            var patientExists = await _services.PatientExists(id);

            if (!patientExists)
            {
                return NotFound("Patient not found");
            }
            
            
            var result = await _services.GetPatientAsync(id);


            return Ok(result);
            

        }
    }
}