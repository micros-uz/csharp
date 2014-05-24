using Inspector.DAL;
using Inspector.DAL.Interfaces;
using Inspector.Domain.Interfaces;
using Inspector.Domain.Models;
using System;
using System.Collections.Generic;

namespace Inspector.BLL.Managers
{
    internal class CatalogManager : GenericManager, ICatalogManager
    {
        private readonly IDbContext _ctx;

        public CatalogManager(IDbContext ctx)
            : base(ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Area> GetAreas()
        {
            var uow = _ctx.GetUnitOfWork();
            var rpstr = uow.GetRepository<Area>();

            return rpstr.GetAll(x => x.Name != "Test");

            //return new List<Area>
            //{
            //    new Area{Name = "Toshkent", SOATO = "1726"},
            //    new Area{Name = "Toshkent viloyati", SOATO = "1727"},
            //    new Area{Name = "Fargona viloyati", SOATO = "1730"}
            //};
        }

        public IEnumerable<Organization> GetOrgatizations(string soato)
        {
            var uow = _ctx.GetUnitOfWork();
            var rpstr = uow.GetRepository<Organization>();

            return rpstr.GetAll(x => x.SOATO == soato);
        }

        public IEnumerable<T> GetEntities<T>() where T: IEntity, new()
        {
            var uow = _ctx.GetUnitOfWork();
            var rpstr = uow.GetRepository<T>();

            return rpstr.GetAll(null);
        }

        public void AddArea(Area area)
        {
            AddEntity(area);
        }
    }
}
