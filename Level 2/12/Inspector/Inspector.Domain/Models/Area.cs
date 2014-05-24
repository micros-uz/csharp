using Inspector.Domain.Misc;
using System.Collections.Generic;
using System.Data;

namespace Inspector.Domain.Models
{
    public class Area : GenericEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SOATO { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public override void Load(IDataRecord record)
        {
            Id = record.GetInt32(0);
            Name = record.GetString(1);
            SOATO = record.GetString(2);
        }

        public override void Save(Dictionary<string, object> dic)
        {
            //dic.Add("Id", Id);
            dic.Add("Name", Name);
            dic.Add("SOATO", SOATO);
        }
    }
}
