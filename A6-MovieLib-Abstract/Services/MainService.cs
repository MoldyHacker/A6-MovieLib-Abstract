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
            string? input;
            do
            {
                Console.Write("Which media type should be displayed?\n" +
                                  "1. Movies\n" +
                                  "2. Shows\n" +
                                  "3. Videos\n" +
                                  "4. Exit\n" +
                                  "> ");
                input = Console.ReadLine();
                Media? media = null;
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

                Console.WriteLine(media?.Display());
                

            } while (input != "4");
            
        }
    }
}
