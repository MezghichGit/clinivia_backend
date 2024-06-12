namespace clinivia_backend.Models
{
    public class PatientDto
    {
     
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Gender { get; set; }
            public int Mobile { get; set; }
            public string Password { get; set; }
            public string Email { get; set; }
            public DateTime DateBirth { get; set; }
            public IFormFile Photo { get; set; }
            public string BloodGroup { get; set; }
            public string BloodPressure { get; set; }
            public string Sugger { get; set; }
            public string Injury { get; set; }
            public string MartialStatus { get; set; }
            public int Age { get; set; }

    }
}
