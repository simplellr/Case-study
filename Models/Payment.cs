using System.ComponentModel.DataAnnotations;

namespace CaseStudy.Models
{
    public class Payment
    {
        public string CardHolderName { get; set; }

        [Key]
        public long CardNumber { get; set; }
        public string ExpiryDate { get; set; }
        public int CVV { get; set; }

    }
}
