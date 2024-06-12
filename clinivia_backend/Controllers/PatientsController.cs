using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using clinivia_backend.Models;
using Microsoft.Extensions.Hosting;

namespace clinivia_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly IWebHostEnvironment _environment;

        public PatientsController(ApplicationContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: api/Patients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatients()
        {
            return await _context.Patients.ToListAsync();
        }

        // GET: api/Patients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetPatient(int id)
        {
            var patient = await _context.Patients.FindAsync(id);

            if (patient == null)
            {
                return NotFound();
            }

            return patient;
        }

        // PUT: api/Patients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatient(int id, Patient patient)
        {
            if (id != patient.UserId)
            {
                return BadRequest();
            }

            _context.Entry(patient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Patients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /*[HttpPost]
        public async Task<ActionResult<Patient>> PostPatient(Patient patient)
        {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPatient", new { id = patient.UserId }, patient);
        }*/
        [HttpPost]
        public async Task<ActionResult<PatientDto>> PostPatient([FromForm] PatientDto patientDto)
        {
            var patient = new Patient
            {
                FirstName = patientDto.FirstName,
                LastName = patientDto.LastName,
                Email = patientDto.Email,
                Password = patientDto.Password,
                Gender = patientDto.Gender,
                Mobile = patientDto.Mobile,
                DateBirth = patientDto.DateBirth,
                BloodGroup = patientDto.BloodGroup,
                BloodPressure = patientDto.BloodPressure,
                Sugger = patientDto.Sugger,
                Injury = patientDto.Injury,
                MartialStatus = patientDto.MartialStatus,
                Age = patientDto.Age
    };

            if (patientDto.Photo != null)
            {
                var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads/patients");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }
                var currentDateTime = DateTime.Now;
                string customFormat = currentDateTime.ToString("yyyy_MM_dd_HH_mm_ss");

                var newFileName = customFormat + "_"+patientDto.FirstName + "_" + patientDto.Photo.FileName; // new DateTime();
                var photoPath = Path.Combine(uploadsFolder, newFileName);

                using (var stream = new FileStream(photoPath, FileMode.Create))
                {
                    await patientDto.Photo.CopyToAsync(stream);
                }
                patient.PhotoPath = Path.Combine("uploads/patients", newFileName);
            }

            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            var createdPatientDto = new PatientDto
            {
                FirstName = patientDto.FirstName,
                LastName = patientDto.LastName,
                Email = patientDto.Email,
                Password = patientDto.Password,
                Gender = patientDto.Gender,
                Mobile = patientDto.Mobile,
                DateBirth = patientDto.DateBirth,
                BloodGroup = patientDto.BloodGroup,
                BloodPressure = patientDto.BloodPressure,
                Sugger = patientDto.Sugger,
                Injury = patientDto.Injury,
                MartialStatus = patientDto.MartialStatus,
                Age = patientDto.Age
            };

            return CreatedAtAction(nameof(GetPatients), new { id = patient.UserId }, createdPatientDto);
        }

        // DELETE: api/Patients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PatientExists(int id)
        {
            return _context.Patients.Any(e => e.UserId == id);
        }
    }
}
