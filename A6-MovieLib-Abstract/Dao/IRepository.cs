using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A6_MovieLib_Abstract.Models;

namespace A6_MovieLib_Abstract.Dao
{
    public interface IRepository<T> where T : Media
    {
        void Add(T media);
        IEnumerable<T> Get();
        T Search(string searchText);
    }
}
