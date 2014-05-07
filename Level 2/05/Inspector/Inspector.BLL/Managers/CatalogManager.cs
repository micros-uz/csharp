using Inspector.Domain.Interfaces;
using Inspector.Domain.Models;
using System;
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
            return new List<Organization>
            {
                new Organization{Name = soato + "_OVD", OKPO = "0" + int.Parse(soato) * 2},
                new Organization{Name = soato + "_Hokimiyat", OKPO = "0" + int.Parse(soato) * 2},
                new Organization{Name = soato + "_Bozor", OKPO = "0" + int.Parse(soato) * 2},
            };
        }
    }
}
