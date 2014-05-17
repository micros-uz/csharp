using Inspector.Domain.Misc;
using System;

namespace Inspector.Domain.Models
{
    [Table("FinIndexes")]
    public class FinIndex : GenericEntity
    {
        public int Id { get; set; }
        public int OrgId { get; set; }
        public decimal ProductVolume { get; set; }
        public decimal Revenue { get; set; }
        public decimal Profit { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public override void Load(System.Data.IDataRecord record)
        {
            throw new NotImplementedException();
        }

        public override void Save(System.Collections.Generic.Dictionary<string, object> dic)
        {
            throw new NotImplementedException();
        }
    }
}
