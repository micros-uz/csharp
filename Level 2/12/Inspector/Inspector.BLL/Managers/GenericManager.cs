using Inspector.DAL.Interfaces;
using Inspector.Domain.Models;

namespace Inspector.BLL.Managers
{
    internal class GenericManager
    {
        private readonly IDbContext _ctx;

        public GenericManager(IDbContext ctx)
        {
            _ctx = ctx;
        }

        protected void AddEntity<T>(T entity) where T : IEntity, new()
        {
            using (var uow = _ctx.GetUnitOfWork())
            {
                var rpstr = uow.GetRepository<T>();
                rpstr.Add(entity);

                uow.SaveChanges();
            }
        }
    }
}
