using System.ComponentModel.DataAnnotations;

namespace TecAir.API.Models
{
    public class UniversityDto
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
