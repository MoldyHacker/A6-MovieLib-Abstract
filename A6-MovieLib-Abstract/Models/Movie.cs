using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A6_MovieLib_Abstract.Models
{
    internal class Movie : Media
    {
        private int id { get; set; }
        public override string Display()
        {
            throw new NotImplementedException();
        }
    }
}
