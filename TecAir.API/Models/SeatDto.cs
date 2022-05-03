using System.ComponentModel.DataAnnotations;

namespace TecAir.API.Models
{
    /// <summary>
    /// This class is assigned for the seats data.
    /// </summary>
    public class SeatDto
    {
        [Key]
        public int Number { get; set; }
        public string Class { get; set; }
        public string Id_airplane { get; set; }
    }
}
