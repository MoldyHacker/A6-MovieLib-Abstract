using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A6_MovieLib_Abstract.Models
{
    public class Show : Media
    {
        private int id { get; set; }
        private string title { get; set; }
        int season { get; set; }
        int episode { get; set; }
        string[] writers { get; set; }

        public override string Display()
        {
            throw new NotImplementedException();
        }
    }
}
