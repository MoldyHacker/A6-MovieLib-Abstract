using BetterConsoleTables;
using CsvHelper;
using CsvHelper.Configuration;

namespace A6_MovieLib_Abstract.Models
{
    public class Show : Media
    {
        private int id { get; set; }
        private string title { get; set; }
        private int season { get; set; }
        private int episode { get; set; }
        private List<string> writers { get; set; }

        private const string filePath = "Data/shows.csv";

        public override string Display()
        {
            List<int> _ids, _season, _episode;
            _ids = new List<int>();
            _season = new List<int>();
            _episode = new List<int>();
            List<string> _titles = new List<string>();
            List<string> _writers = new List<string>();

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
                    _season.Add(Int32.Parse(details[2]));
                    _episode.Add(Int32.Parse(details[3]));
                    _writers.Add(details[4].Replace("|", ", "));
                }
                // close file when done
                sr.Close();
            }
            catch (Exception ex)
            {
                throw new IOException();
            }
            Table table = new Table("ID", "Show Title", "Season", "Episode", "Writer(s)");
            // loop thru Movie Lists
            for (int i = 0; i < _ids.Count; i++)
                table.AddRow(_ids[i], _titles[i], _season[i], _episode[i], _writers[i]);

            return table.ToString();
        }
    }
}
