using System.Collections.Generic;
using System.Data;

namespace Inspector.Domain.Models
{
    public interface IEntity
    {
        void Load(IDataRecord record);
        string TableName { get; }
        void Save(Dictionary<string, object> dic);
    }
}
