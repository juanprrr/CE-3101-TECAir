using System.ComponentModel.DataAnnotations;

namespace TecAir.API.Models
{
    public class GateDto
    {
        [Key]
        public string Number { get; set; }
        public int Id_airport { get; set; }
    }
}
