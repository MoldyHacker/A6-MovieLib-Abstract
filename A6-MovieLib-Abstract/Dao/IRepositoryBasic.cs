using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A6_MovieLib_Abstract.Models;

namespace A6_MovieLib_Abstract.Dao
{
    public interface IRepositoryBasic
    {
        void Add(Media media);
        List<Media> Get();
        // T Search(string searchText);
        IEnumerable<Media> Search(string searchText);
    }
}
