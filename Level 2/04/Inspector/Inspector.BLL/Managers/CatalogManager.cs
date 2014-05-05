using Inspector.Domain.Interfaces;
using Inspector.Domain.Models;
using System.Collections.Generic;

namespace Inspector.BLL.Managers
{
    internal class CatalogManager : ICatalogManager
    {
        public IEnumerable<Area> GetAreas()
        {
            return new List<Area>
            {
                new Area{Name = "Toshkent", SOATO = "1726"},
                new Area{Name = "Toshkent viloyati", SOATO = "1727"},
                new Area{Name = "Fargona viloyati", SOATO = "1730"}
            };
        }

        public IEnumerable<Organization> GetOrgatizations(string soato)
        {
            throw new System.NotImplementedException();
        }
    }
}
