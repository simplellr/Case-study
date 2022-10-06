using System.ComponentModel.DataAnnotations;

namespace CaseStudy.Models
{
    public class SetRoomRates
    {
        [Key]
        public int RoomTypeId { get; set; }

        public string RoomType { get; set; }

        public decimal BasePrice { get; set; }
    }
}
