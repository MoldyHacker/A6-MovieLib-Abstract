using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A6_MovieLib_Abstract.Models
{
    public class Video : Media
    {
        private int id { get; set; }
        private string title { get; set; }
        string format { get; set; }
        int length { get; set; }
        int[] regions { get; set; }

        public override string Display()
        {
            throw new NotImplementedException();
        }
    }
}
