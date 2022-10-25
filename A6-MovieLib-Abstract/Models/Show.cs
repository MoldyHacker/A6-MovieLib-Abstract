using BetterConsoleTables;
using CsvHelper;
using CsvHelper.Configuration;

namespace A6_MovieLib_Abstract.Models
{
    public class Show : Media
    {
        // private int id { get; set; }
        // private string title { get; set; }
        private int season { get; set; }
        private int episode { get; set; }
        private string writers { get; set; }

        private const string filePath = "Data/shows.csv";

        public List<Show> show { get; set; }

        public Show(int id, string title, int season, int episode, string writers)
        {
            this.id = id;
            this.title = title;
            this.season = season;
            this.episode = episode;
            this.writers = writers;
        }

        public Show()
        {
            Read();
        }

        public override void Read()
        {
            show = new List<Show>();

            // List<int> _ids, _season, _episode;
            // _ids = new List<int>();
            // _season = new List<int>();
            // _episode = new List<int>();
            // List<string> _titles = new List<string>();
            // List<string> _writers = new List<string>();

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
                    // _season.Add(Int32.Parse(details[2]));
                    // _episode.Add(Int32.Parse(details[3]));
                    // _writers.Add(details[4].Replace("|", ", "));
                    
                    show.Add(new Show(int.Parse(details[0]), details[1], int.Parse(details[2]), int.Parse(details[3]), details[4].Replace("|", ", ")));
                }
                // close file when done
                sr.Close();
            }
            catch (Exception ex)
            {
                throw new IOException();
            }
        }

        public override string Display()
        {
           
            Table table = new Table("ID", "Show Title", "Season", "Episode", "Writer(s)");
            // loop thru Movie Lists
            // for (int i = 0; i < _ids.Count; i++)
            //     table.AddRow(_ids[i], _titles[i], _season[i], _episode[i], _writers[i]);

            foreach (var show in show)
                table.AddRow(show.id, show.title, show.season, show.episode, show.writers);
            

            return table.ToString();
        }
    }
}
