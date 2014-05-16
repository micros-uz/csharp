using Inspector.DAL.Interfaces;

namespace Inspector.DAL.AdoNet
{
    internal class GenericRepository<T> : IRepository<T> where T : new()
    {
        private readonly IUnitOfWork _uow;
        public GenericRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public void Add(T entity)
        {
            using(var cmd = _uow.GetCommand())
            {
                cmd.CommandText = "";
                cmd.ExecuteNonQuery();
            }
        }

        public System.Collections.Generic.IEnumerable<T> GetAll()
        {
            return null;
        }

        public void Update(T entity)
        {
        }

        public void Delete(T entity)
        {
        }
    }
}
