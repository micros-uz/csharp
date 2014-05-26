namespace Inspector.DAL.Interfaces
{
    public interface IDbContext
    {
        IUnitOfWork GetUnitOfWork();
    }
}
