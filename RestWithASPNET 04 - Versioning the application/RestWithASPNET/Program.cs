using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace RestWithASPNET
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();
            BuilderWebHost(args).Run();
        }

        private static IWebHost BuilderWebHost(string[] args) => WebHost.CreateDefaultBuilder(args).
            UseStartup<Startup>()
            .Build();


        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseStartup<Startup>();
        //        });
    }
}
