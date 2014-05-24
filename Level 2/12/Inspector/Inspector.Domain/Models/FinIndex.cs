using Inspector.Domain.Misc;
using System;
using System.Collections.Generic;

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

        public override void Save(Dictionary<string, object> dic)
        {
            dic.Add("OrgId", OrgId);
            dic.Add("ProductVolume", ProductVolume);
            dic.Add("Revenue", Revenue);
            dic.Add("Profit", Profit);
            dic.Add("StartDate", StartDate.ToString("yyyy-MM-dd"));
            dic.Add("EndDate", EndDate.ToString("yyyy-MM-dd"));
        }
    }
}
