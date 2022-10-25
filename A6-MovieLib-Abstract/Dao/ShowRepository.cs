using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A6_MovieLib_Abstract.Models;

namespace A6_MovieLib_Abstract.Dao
{
    public class ShowRepository : IRepositoryBasic
    {
        private Context _context;

        public ShowRepository()
        {
            _context = new Context();
        }

        public void Add(Media show)
        {
            _context.Shows.Add(show);
        }

        public List<Media> Get()
        {
            return _context.Shows;
        }

        public IEnumerable<Media> Search(string searchText)
        {
            throw new NotImplementedException();
        }


        // public Media Search(string searchText)
        // {
        //     return _context.Movies.First(a => a.title == searchText);
        // }
    }
}
