using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecAir.API.Models
{
    /// <summary>
    /// This class is assigned for the travels data.
    /// </summary>
    public class TravelDto
    {
        [Key, Column(Order = 1)]
        public int Number { get; set; }
        public string Name { get; set; }
        [Key, Column(Order = 2)]
        public int Id_route { get; set; }
        public DateTime Departure_time { get; set; }
        public DateTime Arrival_time { get; set; }
        public int Id_origin { get; set; }
        public int Id_destination { get; set; }
    }
}
