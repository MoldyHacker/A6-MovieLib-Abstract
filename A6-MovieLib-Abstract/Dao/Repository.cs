using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A6_MovieLib_Abstract.Models;

namespace A6_MovieLib_Abstract.Dao
{
    internal class Repository<T> : IRepository<T> where T : Media
    {
        private Context _context;
        private List<T> medias;

        public Repository()
        {
            _context = new Context();
            medias = _context.Set<T>();
        }
        public void Add(T media)
        {
            medias.Add(media);
        }

        public IEnumerable<T> Get()
        {
            return medias;
        }

        public T Search(string searchText)
        {
            return medias.FirstOrDefault(a => a.title.Contains(searchText, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
