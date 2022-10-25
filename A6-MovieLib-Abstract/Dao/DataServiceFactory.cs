using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A6_MovieLib_Abstract.Dao
{
    public class DataServiceFactory
    {
        public static TRepository GetRepositoryInstance<T, TRepository>() where TRepository : class, new()
        {
            return new TRepository();
        }
    }
}
