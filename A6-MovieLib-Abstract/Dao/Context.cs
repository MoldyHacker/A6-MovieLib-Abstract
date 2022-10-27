using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using A6_MovieLib_Abstract.Models;

namespace A6_MovieLib_Abstract.Dao
{
    public class Context
    {
        public List<Media> Movies { get; set; }
        public List<Media> Shows { get; set; }
        public List<Media> Videos { get; set; }

        private Movie _movie = new Movie();
        private Show _show = new Show();
        private Video _video = new Video();

        public Context()
        {
            // Movies = new List<Media>()
            // {
            //     new Movie { id = 1, title = "Toy Story" },
            //     new Movie { id = 2, title = "Toy Story 2" },
            //     new Movie { id = 3, title = "Toy Story 3" }
            // };

            Movies = new List<Media>();
            Movies.AddRange(_movie.movie);




            Shows = new List<Media>();
            Shows.AddRange(_show.show);

            // {
            //     new Show { id = 1, title = "Bobs Burgers" },
            //     new Show { id = 2, title = "Bobs Burgers 1" },
            //     new Show { id = 3, title = "Bobs Burgers 2" }
            // };

            Videos = new List<Media>();
            Videos.AddRange(_video.video);


        }

        public List<T> Set<T>()
        {
            var type = typeof(T);
            var contextTables = this.GetType().GetProperties();

            foreach (var property in contextTables)
            {
                if (property.Name.Contains(type.Name))
                {
                    var value = property.GetValue(this, null);
                    return ((List<T>)value);
                }
            }

            return null;
        }
    }
}
