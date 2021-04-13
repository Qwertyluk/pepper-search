using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepperSearch
{
    public interface IScrapper
    {
        Task<List<Discount>> GetDataAsync(int startPage, int endPage, PepperGroup group);
        Task<List<Discount>> GetDataAsync(int startPage, int endPage, string pepperSearchPhrase);
    }
}
