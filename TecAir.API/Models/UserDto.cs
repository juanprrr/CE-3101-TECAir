using System.ComponentModel.DataAnnotations;

namespace TecAir.API.Models
{
    public class UserDto
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string First_lastname { get; set; }
        public string Second_lastname { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public int Student_id { get; set; }
        public int Id_university { get; set; }
        public string Password { get; set; }
    }
}
