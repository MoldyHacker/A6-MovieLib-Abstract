using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A6_MovieLib_Abstract.Models;

namespace A6_MovieLib_Abstract.Dao
{
    public class MovieRepository : IRepositoryBasic<Movie>
    {
        private Context _context;

        public MovieRepository()
        {
            _context = new Context();
        }

        public void Add(Media movie)
        {
            _context.Movies.Add(movie);
        }

        public List<Media> Get()
        {
            return _context.Movies;
        }

        public IEnumerable<Media> Search(string searchText)
        {
            return _context.Movies.Where(m => m.title.ToLower().Contains(searchText.ToLower(), StringComparison.CurrentCultureIgnoreCase)).ToList();
        }


        // public Media Search(string searchText)
        // {
        //     return _context.Movies.First(a => a.title == searchText);
        // }
    }
}
