using System.ComponentModel.DataAnnotations;

namespace TecAir.API.Models
{
    public class AeroportDto
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}
