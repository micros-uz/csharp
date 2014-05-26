using Inspector.DAL.Interfaces;
using Inspector.Domain.Models;
using Moq;
using System.Linq;
using System.Collections.Generic;

namespace Inspector.Test.Helpers
{
    internal class DbContextHelper
    {
        internal static IDbContext GetCtx()
        {
            var dbContextMock = new Mock<IDbContext>();
            var uowMock = new Mock<IUnitOfWork>();
            var rpstr = new Mock<IRepository<Area>>();

            rpstr.Setup(x => x.GetAll(null))
                .Returns(Enumerable.Repeat<Area>(new Area(), 14));

            uowMock.Setup(x => x.GetRepository<Area>())
                .Returns(rpstr.Object);

            dbContextMock.Setup(x => x.GetUnitOfWork())
                .Returns(uowMock.Object);


            return dbContextMock.Object;
        }
    }
}
