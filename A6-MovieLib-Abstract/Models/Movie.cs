using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using BetterConsoleTables;

namespace A6_MovieLib_Abstract.Models
{
    public class Movie : Media
    {
        // private int id { get; set; }
        // private string title { get; set; }
        private string genres { get; set; }

        public List<Movie> movie { get; set; }

        private const string filePath = "Data/moviesTrunc.csv";
        
        // private List<int> _ids = new List<int>();
        // private List<string> _titles = new List<string>();
        // private List<string> _genres = new List<string>();

        public Movie(int id, string title, string genres)
        {
            this.id = id;
            this.title = title;
            this.genres = genres;
        }
        
        public Movie()
        {
            Read();
        }


        public override void Read()
        {
            movie = new List<Movie>();

            try
            {
                StreamReader sr = new StreamReader(filePath);
                // first line contains column headers
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    // no quote = no comma in movie title
                    // movie details are separated with comma(,)
                    string[] details = line.Split(',');

                    // _ids.Add(int.Parse(details[0]));
                    // _titles.Add(details[1]);
                    // _genres.Add(details[2].Replace("|", ", "));

                    movie.Add(new Movie(int.Parse(details[0]), details[1], details[2].Replace("|", ", ")));
                    // movie.Add(new Movie( int.Parse(details[0]), details[1]));
                }

                // close file when done
                sr.Close();

            }
            catch (Exception ex)
            {
                throw new IOException();
            }
        }

        public List<Media> ReadToList()
        {
            List<Media> list = new List<Media>();
            list.AddRange(movie);
            return list;
        }

        public override string Display()
        {
            Table table = new Table("ID", "Movie Title", "Genre(s)");
            // loop thru Movie Lists
            foreach (var movie in movie)
                table.AddRow(movie.id, movie.title, movie.genres);
            
            // for (int i = 0; i < _ids.Count; i++)
            //     table.AddRow(_ids[i], _titles[i], _genres[i]);

            return table.ToString();
        }
    }
}
