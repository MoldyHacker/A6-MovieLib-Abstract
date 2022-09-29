using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetterConsoleTables;

namespace A6_MovieLib_Abstract.Models
{
    internal class Movie : Media
    {
        private int id { get; set; }
        private string title { get; set; }
        private List<string> genres { get; set; }

        private const string filePath = "Data/moviesTrunc.csv";

        public override string Display()
        {
            List<int> _ids = new List<int>();
            List<string> _titles = new List<string>();
            List<string> _genres = new List<string>();

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

                    _ids.Add(int.Parse(details[0]));
                    _titles.Add(details[1]);
                    _genres.Add(details[2].Replace("|", ", "));
                }
                // close file when done
                sr.Close();
            }
            catch (Exception ex)
            {
                throw new IOException();
            }
            Table table = new Table("ID", "Movie Title", "Genre(s)");
            // loop thru Movie Lists
            for (int i = 0; i < _ids.Count; i++)
                table.AddRow(_ids[i], _titles[i], _genres[i]);

            return table.ToString();
        }
    }
}
