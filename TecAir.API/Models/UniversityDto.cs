using System.ComponentModel.DataAnnotations;

namespace TecAir.API.Models
{
    /// <summary>
    /// This class is assigned for the universities data.
    /// </summary>
    public class UniversityDto
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
