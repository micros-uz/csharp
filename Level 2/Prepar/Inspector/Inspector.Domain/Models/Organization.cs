namespace Inspector.Domain.Models
{
    public class Organization : GenericEntity
    {
        public int Id { get; set; }
        public string OKPO { get; set; }
        public string SOATO { get; set; }
        public string INN { get; set; }
        public string Name { get; set; }
        public OrgType Type { get; set; }

        public override string ToString()
        {
            return string.Format("{0,16} | {1,8}", Name, OKPO);
        }

        public override void Load(System.Data.IDataRecord record)
        {
            Id = record.GetInt32(0);
            OKPO = record.GetString(1);
            SOATO = record.GetString(2);
            INN = record.GetString(3);
            Name = record.GetString(4);
            Type = (OrgType)record.GetByte(5);
        }

        public override void Save(System.Collections.Generic.Dictionary<string, object> dic)
        {
            throw new System.NotImplementedException();
        }
    }
}
