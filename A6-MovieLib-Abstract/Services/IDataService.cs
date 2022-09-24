using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A6_MovieLib_Abstract.Services
{
    public interface IDataService
    {
        void Read();
        void Write();
        void Display();
    }
}
