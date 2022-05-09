using System.Reflection;
using ApiaryDiary.Shared.Abstractions.Modules;
using ApiaryDiary.Shared.Infrastructure;
using ApiaryDiary.Shared.Infrastructure.Modules;

namespace ApiaryDiary.Bootstrapper
{
    public class Program
    {
        public static Task Main(string[] args)
            => CreateHostBuilder(args).Build().RunAsync();
        
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>())
                .ConfigureModules();
    }
}