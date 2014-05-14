namespace Inspector.Domain.Models
{
    public class Organization
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
    }
}
