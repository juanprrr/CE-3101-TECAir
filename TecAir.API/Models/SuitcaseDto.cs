using System.ComponentModel.DataAnnotations;

namespace TecAir.API.Models
{
    /// <summary>
    /// This class is assigned for the suitcases data.
    /// </summary>
    public class SuitcaseDto
    {
        [Key]
        public int Id { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }
        public int Id_user { get; set; }
    }
}
