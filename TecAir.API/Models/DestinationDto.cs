using System.ComponentModel.DataAnnotations;

namespace TecAir.API.Models
{
    public class DestinationDto
    {
        [Key]
        public int Id_airport { get; set; }
        public int Num_travel { get; set; }
        public DateTime Arrival_time { get; set; }
    }
}
