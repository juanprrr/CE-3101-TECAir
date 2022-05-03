using System.ComponentModel.DataAnnotations;

namespace TecAir.API.Models
{
    /// <summary>
    /// This class is assigned for the promotions data.
    /// </summary>
    public class PromotionDto
    {
        [Key]
        public int Code { get; set; }
        public int Discount { get; set; }
        public DateTime Date_of_issue { get; set; }
    }
}
