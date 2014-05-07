using Inspector.Domain.Models;
using System.Collections.Generic;

namespace Inspector.Domain.Interfaces
{
    public interface ICatalogManager
    {
        IEnumerable<Area> GetAreas();
        IEnumerable<Organization> GetOrgatizations(string soato);
    }
}
