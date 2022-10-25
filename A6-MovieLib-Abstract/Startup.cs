using A6_MovieLib_Abstract.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A6_MovieLib_Abstract.Dao;
using A6_MovieLib_Abstract.Models;
using Microsoft.Extensions.Logging;

namespace A6_MovieLib_Abstract
{
    public class Startup
    {
        public IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddLogging(builder =>
            {
                builder.AddConsole();
                builder.AddFile("app.log");
            });

            // Add new lines of code here to register any interfaces and concrete services you create
            services.AddTransient<IMainService, MainService>();
            services.AddSingleton<IRepositoryBasic, MovieRepository>();
            services.AddSingleton<IRepository<Movie>>(_ => DataServiceFactory.GetRepositoryInstance<Movie, Repository<Movie>>());
            // services.AddSingleton<IRepositoryBasic, ShowRepository>();
            // services.AddSingleton<IRepositoryBasic, VideoRepository>();


            return services.BuildServiceProvider();
        }
    }
}
