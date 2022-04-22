using System.ComponentModel.DataAnnotations;

namespace TecAir.API.Models
{
    public class AirplaneDto
    {
        [Key]
        public string Registration { get; set; }
        public int Capacity { get; set; }
        public string Model { get; set; }
    }
}
