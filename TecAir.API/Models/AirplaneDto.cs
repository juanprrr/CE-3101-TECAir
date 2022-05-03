using System.ComponentModel.DataAnnotations;

namespace TecAir.API.Models
{
    /// <summary>
    /// This class is assigned for the airplanes data.
    /// </summary>
    public class AirplaneDto
    {
        [Key]
        public string Registration { get; set; }
        public int Capacity { get; set; }
        public string Model { get; set; }
    }
}
