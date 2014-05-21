using Inspector.DAL.Interfaces;
using Inspector.Domain.Interfaces;
using Inspector.Domain.Models;

namespace Inspector.BLL.Managers
{
    internal class FinancialManager : GenericManager, IFinancialManager
    {
        public FinancialManager(IDbContext ctx)
            : base(ctx)
        {
        }
        
        public void AddFinIndex(FinIndex finIndex)
        {
            AddEntity(finIndex);
        }
    }
}
