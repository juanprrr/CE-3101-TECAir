using System.ComponentModel.DataAnnotations;

namespace TecAir.API.Models
{
    public class TravelDto
    {
        [Key]
        public int Number { get; set; }
        public string Name { get; set; }
        public int Id_route { get; set; }
        public DateTime Departure_time { get; set; }
        public DateTime Arrival_time { get; set; }
        public int Id_airport { get; set; }
    }
}
