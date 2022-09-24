using A6_MovieLib_Abstract.Services;
using Microsoft.Extensions.DependencyInjection;
namespace A6_MovieLib_Abstract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var startup = new Startup();
                var serviceProvider = startup.ConfigureServices();
                var service = serviceProvider.GetService<IMainService>();

                service?.Invoke();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
            }
        }
    }
}