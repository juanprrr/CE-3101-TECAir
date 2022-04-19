using System.ComponentModel.DataAnnotations;

namespace TecAir.API.Models
{
    public class EmployeeDto
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string First_lastname { get; set; }
        public string Second_lastname { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Id_aeroport { get; set; }
        public int Id_role { get; set; }
    }
}
