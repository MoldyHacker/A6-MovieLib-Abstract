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
        private readonly IRepositoryBasic<Movie> _movieRepo;
        private readonly IRepositoryBasic<Show> _showRepo;
        private readonly IRepositoryBasic<Video> _videoRepo;

        public MainService(IRepositoryBasic<Movie> movieRepo, IRepositoryBasic<Show> showRepo,
            IRepositoryBasic<Video> videoRepo)
        {
            _movieRepo = movieRepo;
            _showRepo = showRepo;
            _videoRepo = videoRepo;
        }


        public void Invoke()
        {
            var movies = _movieRepo.Get();
            var shows = _showRepo.Get();
            var videos = _videoRepo.Get();

            // var searchedMedia = _movieRepo.Search("Toy");
            // Console.WriteLine(searchedMedia);


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


                        var filteredMovies = movies.Where(m => m.title.Contains(searchText, StringComparison.CurrentCultureIgnoreCase));
                        Console.WriteLine(filteredMovies.Any() ? "==Movies Found==" : "==No Movies Found==");
                        foreach (var m in filteredMovies)
                            Console.WriteLine(m?.title);


                        var filteredShows = shows.Where(m => m.title.Contains(searchText, StringComparison.CurrentCultureIgnoreCase));
                        Console.WriteLine(filteredShows.Any() ? "==Shows Found==" : "==No Shows Found==");
                        foreach (var m in filteredShows)
                            Console.WriteLine(m?.title);


                        var filteredVideos = videos.Where(m => m.title.Contains(searchText, StringComparison.CurrentCultureIgnoreCase));
                        Console.WriteLine(filteredVideos.Any() ? "==Videos Found==" : "==No Videos Found==");
                        foreach (var m in filteredVideos)
                            Console.WriteLine(m?.title);


                        Console.Write("Count of media found: ");
                        Console.WriteLine(filteredVideos?.Count() + filteredShows?.Count() + filteredMovies?.Count());


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