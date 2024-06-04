using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace clinivia_backend.Models
{
    public class Departement
    {
        [Key]
        public int D_id { get; set; }
        public int D_no { get; set; }
        public string D_name { get; set; }
        public string D_description { get; set; }
        public string D_head { get; set; }
        public DateTime D_date { get; set; }
        public string D_status { get; set; }
    }
}
