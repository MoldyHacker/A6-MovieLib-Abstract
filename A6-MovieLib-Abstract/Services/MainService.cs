using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A6_MovieLib_Abstract.Models;

namespace A6_MovieLib_Abstract.Services
{
    public class MainService : IMainService
    {
        public void Invoke()
        {
            string input;
            do
            {
                Console.WriteLine("Which media type should be displayed?");
                input = Console.ReadLine();
                Media media = null;
                switch (input)
                {
                case "1":
                    media = new Movie();
                    break;
                case "2":
                    media = new Show();
                    break;
                case "3":
                    media = new Video();
                    break;
                default:
                    Console.WriteLine("not a valid option.");
                    media = null;
                    break;
                }

                // if (input == "1")
                //     media = new Movie();
                // else if (input == "2")
                //     media = new Show();

                media?.Display();
            } while (input != "4");
            
        }
    }
}
