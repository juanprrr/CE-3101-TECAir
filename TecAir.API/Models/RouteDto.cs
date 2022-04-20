using System.ComponentModel.DataAnnotations;

namespace TecAir.API.Models
{
    public class RouteDto
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
