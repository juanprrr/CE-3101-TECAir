using System.ComponentModel.DataAnnotations;

namespace TecAir.API.Models
{
    /// <summary>
    /// This class is assigned for the employees data.
    /// </summary>
    public class ReservationDto
    {
        [Key]
        public int Id { get; set; }
        public DateTime Expiration_date { get; set; }
        public DateTime Date_of_issue { get; set; }
        public bool Check { get; set; }
        public int Id_flight { get; set; }
        public int Id_user { get; set; }
    }
}
