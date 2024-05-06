using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace _9
{
    public class Computer
    {
        public int ComputerId { get; set; }

        public bool IsFree { get; set; }

        [ForeignKey("Rate")]
        public int RateId { get; set; }

        public virtual Rate Rate { get; set; }
    }
}
