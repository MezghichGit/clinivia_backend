using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace clinivia_backend.Models
{
    
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName{ get; set; }
        public string Gender { get; set; }
        public int Mobile { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime DateBirth { get; set; }
        public string PhotoPath { get; set; }
    }
    public class Docteur : User
    {
        
        public string Education { get; set; }
        [ForeignKey("Departement")]
        public int DepartementId { get; set; }
        public Departement Departement { get; set; }
    }
    public class Patient : User
    {
        public string BloodGroup { get; set; }
        public string BloodPressure { get; set; }
        public string Sugger { get; set; }
        public string Injury { get; set; }
        public string MartialStatus { get; set; }
        public int Age { get; set; }

    }
}
