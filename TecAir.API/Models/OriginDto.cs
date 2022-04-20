using System.ComponentModel.DataAnnotations;

namespace TecAir.API.Models
{
    public class OriginDto
    {
        [Key]
        public int Id_airport { get; set; }
        public int Num_travel { get; set; }
        public DateTime Departure_time { get; set; }
    }
}
