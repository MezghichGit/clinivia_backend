using System.ComponentModel.DataAnnotations;

namespace clinivia_backend.Models
{
    
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserNom { get; set; }
        public string UserPrenom { get; set; }
    }
}
