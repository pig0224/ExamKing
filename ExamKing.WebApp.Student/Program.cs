using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace ExamKing.WebApp.Student
{
    
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .Inject()
                        // .UseUrls("http://*:8071")
                        .UseStartup<Startup>();
                });
        }
    }
}
