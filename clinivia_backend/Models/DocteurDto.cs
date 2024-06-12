using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace clinivia_backend.Models
{
    public class DocteurDto
    {
       // public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int Mobile { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime DateBirth { get; set; }
        public string Education { get; set; }
        public int DepartementId { get; set; }
        public IFormFile Photo { get; set; }
    }
}
