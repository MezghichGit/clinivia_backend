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
    public class DocteursController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly IWebHostEnvironment _environment;
        public DocteursController(ApplicationContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Docteur>>> GetDocteurs()
        {
            var docteurs = await _context.Docteurs
                .Select(d => new Docteur
                {
                    UserId = d.UserId,
                    FirstName = d.FirstName,
                    LastName = d.LastName,
                    Email = d.Email,
                    Gender = d.Gender,
                    Mobile = d.Mobile,
                    DateBirth = d.DateBirth,
                    Password = d.Password,
                    Education = d.Education,
                    DepartementId = d.DepartementId,
                    PhotoPath = d.PhotoPath,
                    Departement = d.Departement
                }).ToListAsync();

            return docteurs;
        }

        // GET: api/Docteurs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Docteur>> GetDocteur(int id)
        {
            var docteur = await _context.Docteurs.FindAsync(id);

            if (docteur == null)
            {
                return NotFound();
            }

            return docteur;
        }

        // PUT: api/Docteurs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocteur(int id, Docteur docteur)
        {
            if (id != docteur.UserId)
            {
                return BadRequest();
            }

            _context.Entry(docteur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocteurExists(id))
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

        // POST: api/Docteurs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /* [HttpPost]
        public async Task<ActionResult<Docteur>> PostDocteur(Docteur docteur)
        {
            _context.Docteurs.Add(docteur);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDocteur", new { id = docteur.UserId }, docteur);
        }*/
        [HttpPost]
        public async Task<ActionResult<DocteurDto>> PostDocteur([FromForm] DocteurDto docteurDto)
        {
            var docteur = new Docteur
            {
                FirstName = docteurDto.FirstName,
                LastName = docteurDto.LastName,
                Email = docteurDto.Email,
                Password = docteurDto.Password, 
                Gender = docteurDto.Gender,
                Mobile = docteurDto.Mobile,
                DateBirth = docteurDto.DateBirth,
                Education = docteurDto.Education,
                DepartementId = docteurDto.DepartementId
            };
            
            if (docteurDto.Photo != null)
            {
                var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var photoPath = Path.Combine(uploadsFolder, docteurDto.Photo.FileName);
                using (var stream = new FileStream(photoPath, FileMode.Create))
                {
                    await docteurDto.Photo.CopyToAsync(stream);
                }
                docteur.PhotoPath = Path.Combine("uploads", docteurDto.Photo.FileName);
            }
            
            _context.Docteurs.Add(docteur);
            await _context.SaveChangesAsync();

            var createdDocteurDto = new DocteurDto
            {
                //UserId = docteur.UserId,
                FirstName = docteur.FirstName,
                LastName = docteur.LastName,
                Email = docteur.Email,
                Education = docteur.Education,
                Mobile = docteur.Mobile,
                Gender  = docteur.Gender,
                Photo = docteurDto.Photo,
                DateBirth = docteur.DateBirth,
                Password = docteur.Password,
                DepartementId = docteur.DepartementId
            };

            return CreatedAtAction(nameof(GetDocteurs), new { id = docteur.UserId }, createdDocteurDto);
        }
    

        // DELETE: api/Docteurs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocteur(int id)
        {
            var docteur = await _context.Docteurs.FindAsync(id);
            if (docteur == null)
            {
                return NotFound();
            }

            _context.Docteurs.Remove(docteur);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DocteurExists(int id)
        {
            return _context.Docteurs.Any(e => e.UserId == id);
        }
    }
}
