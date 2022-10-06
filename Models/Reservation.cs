using System.ComponentModel.DataAnnotations;

namespace CaseStudy.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
        public string IdProof { get; set; }
        public string RoomType { get; set; }
        public int NoOfMembers { get; set; }
        public string CheckIn { get; set; }
        public string CheckOut { get; set; }
    }
}
