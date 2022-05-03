using System.ComponentModel.DataAnnotations;

namespace TecAir.API.Models
{
    /// <summary>
    /// This class is assigned for the flights data.
    /// </summary>
    public class FlightDto
    {
        [Key]
        public int Id { get; set; }
        public int Cost { get; set; }
        public int Number_of_passengers { get; set; }
        public string Status { get; set; }
        public string Id_airplane { get; set; }
        public int Id_ruta { get; set; }
        public int Id_promotion { get; set; }
    }
}
