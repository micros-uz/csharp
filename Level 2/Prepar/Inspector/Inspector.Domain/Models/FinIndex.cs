using System;

namespace Inspector.Domain.Models
{
    public class FinIndex
    {
        public int IndexId { get; set; }
        public int OrgId { get; set; }
        public decimal ProductVolume { get; set; }
        public decimal Revenue { get; set; }
        public decimal Profit { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
