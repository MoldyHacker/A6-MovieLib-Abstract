using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A6_MovieLib_Abstract.Dao;
using A6_MovieLib_Abstract.Models;
using Spectre.Console;

namespace A6_MovieLib_Abstract.Services
{
    public class MainService : IMainService
    {
        private readonly IRepositoryBasic _repo;

        private readonly IRepository<Movie> _movieRepo;

        public MainService(IRepository<Movie> movieRepo)
        {
            _movieRepo = movieRepo;
        }



        // public MainService(IRepositoryBasic repo)
        // {
        //     _repo = repo;
        // }



        public void Invoke()
        {
            // var medias = _repo.Get();
            var medias = _movieRepo.Get();

            // var searchedMedia = _repo.Search("Toy");
            // Console.WriteLine(searchedMedia);



            var filteredMedia = medias.Where(m => m.title.ToLower().Contains("toy"));
            foreach (var m in filteredMedia)
            {
                Console.WriteLine(m?.title);
            }
            Console.WriteLine(filteredMedia?.Count());




            string? input;
            do
            {
                Console.Write("Which media type should be displayed?\n" +
                                  "1. Movies\n" +
                                  "2. Shows\n" +
                                  "3. Videos\n" +
                                  "4. Search\n" +
                                  "5. Exit\n" +
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
                case "4":
                    string searchText = AnsiConsole.Ask<string>("Media search title: ");
                    
                    break;
                case "5":
                    break;
                default:
                    Console.WriteLine("not a valid option.");
                    media = null;
                    break;
                }
            
                Console.WriteLine(media?.Display());
            
            } while (input != "5");

        }
    }
}
