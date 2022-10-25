using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetterConsoleTables;

namespace A6_MovieLib_Abstract.Models
{
    public class Video : Media
    {
        // private int id { get; set; }
        // private string title { get; set; }
        private string format { get; set; }
        private int length { get; set; }
        private string regions { get; set; }

        public List<Video> video { get; set; } 
        
        private const string filePath = "Data/videos.csv";

        

        public Video(int id, string title, string format, int length, string regions)
        {
            this.id = id;
            this.title = title;
            this.format = format;
            this.length = length;
            this.regions = regions;
        }

        public Video()
        {
            Read();
        }



        public override void Read()
        {
            video = new List<Video>();
            // List<int> _ids, _length;
            // _ids = new List<int>();
            // _length = new List<int>();
            // List<string> _titles = new List<string>();
            // List<string> _format = new List<string>();
            // List<string> _regions = new List<string>();

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
                    // _format.Add(details[2].Replace("|", ","));
                    // _length.Add(Int32.Parse(details[3]));
                    // _regions.Add(details[4].Replace("|", ", "));

                    video.Add(new Video(int.Parse(details[0]), details[1], details[2].Replace("|", ","), int.Parse(details[3]), details[4].Replace("|", ", ")));


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
            
            Table table = new Table("ID", "Video Title", "Format(s)", "Length", "Region(s)");
            // loop thru Movie Lists
            // for (int i = 0; i < _ids.Count; i++)
            //     table.AddRow(_ids[i], _titles[i], _format[i], _length[i], _regions[i]);

            foreach (var video in video)
                table.AddRow(video.id, video.title, video.format, video.length, video.regions);

            return table.ToString();
        }

        
    }
}
