using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A6_MovieLib_Abstract.Models
{
    public abstract class Media
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public abstract string Display();
    }
}
