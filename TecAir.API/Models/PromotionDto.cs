using System.ComponentModel.DataAnnotations;

namespace TecAir.API.Models
{
    public class PromotionDto
    {
        [Key]
        public int Code { get; set; }
        public int Discount { get; set; }
        public DateTime Date_of_issue { get; set; }
    }
}
