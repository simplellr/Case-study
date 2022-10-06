using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CaseStudy.Models
{
    public class RoomManagement
    {
        [Key]
        public int RoomNo { get; set; }

        public string Facilities { get; set; }

        public int No_Of_Adults { get; set; }

        public string RoomType { get; set; }

    }
}