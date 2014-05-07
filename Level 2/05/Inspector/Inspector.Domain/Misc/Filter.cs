using Inspector.Domain.Models;
using System;

namespace Inspector.Domain.Misc
{
    public class Filter
    {
        public string Soato {get;set;}
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public OrgType? OrgType { get; set; }
    }
}
