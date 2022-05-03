using System.ComponentModel.DataAnnotations;

namespace TecAir.API.Models
{
    /// <summary>
    /// This class is assigned for the routes data.
    /// </summary>
    public class RouteDto
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
