using System.ComponentModel.DataAnnotations;

namespace TecAir.API.Models
{
    /// <summary>
    /// This class is assigned for the gates data.
    /// </summary>
    public class GateDto
    {
        [Key]
        public string Number { get; set; }
        public int Id_airport { get; set; }
    }
}
