using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepperSearch
{
    public interface IScrapper
    {
        Task<List<Discount>> ScrapDataAsync(int startPage, int endPage, PepperGroup group);
    }
}
