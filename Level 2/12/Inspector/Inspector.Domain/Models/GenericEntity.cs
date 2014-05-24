using System.Collections.Generic;
namespace Inspector.Domain.Models
{
    public abstract class GenericEntity : IEntity
    {
        public abstract void Load(System.Data.IDataRecord record);

        public string TableName
        {
            get { throw new System.NotImplementedException(); }
        }

        public abstract void Save(Dictionary<string, object> dic);
    }
}
