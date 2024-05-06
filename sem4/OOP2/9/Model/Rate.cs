using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace _9
{
    public class Rate
    {
        [Key]
        public int RateId { get; set; }

        [Required]
        public string RateName { get; set; }

        [Required]
        public float Multiplier { get; set; }

        public ICollection<Computer> Computers { get; set; }
    }
}
