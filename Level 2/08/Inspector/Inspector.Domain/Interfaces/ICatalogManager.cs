using Inspector.Domain.Models;
using System.Collections.Generic;

namespace Inspector.Domain.Interfaces
{
    public interface ICatalogManager
    {
        IEnumerable<T> GetEntities<T>() where T : new();

        IEnumerable<Area> GetAreas();
        IEnumerable<Organization> GetOrgatizations(string soato);
    }
}
