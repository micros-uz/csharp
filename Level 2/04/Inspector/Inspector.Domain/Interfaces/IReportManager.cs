using Inspector.Domain.Misc;
using System;

namespace Inspector.Domain.Interfaces
{
    public interface IReportManager
    {
        void GetTotalProductVolume(Filter filter);
        void GetTotalRevenue(Filter filter);
        void GetTotalProfit(Filter filter);
    }
}
