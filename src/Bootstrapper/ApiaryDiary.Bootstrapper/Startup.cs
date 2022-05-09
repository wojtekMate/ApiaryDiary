using System.Reflection;
using ApiaryDiary.Shared.Abstractions.Modules;
using ApiaryDiary.Shared.Infrastructure;

namespace ApiaryDiary.Bootstrapper
{
    public class Startup
    {
        private readonly IList<Assembly> _assemblies;
        private readonly IList<IModule> _modules;

        public Startup(IConfiguration configuration)
        {
            _assemblies = ModuleLoader.LoadAssemblies(configuration);
            _modules = ModuleLoader.LoadModules(_assemblies);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSharedInfrastructure(_assemblies, _modules);
            foreach (var module in _modules)
            {
                module.Register(services);
            }
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            logger.LogInformation($"Modules: {string.Join(", ", _modules.Select(x => x.Name))}");
            app.UseSharedInfrastructure();
            foreach (var module in _modules)
            {
                module.Use(app);
            }
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", context => context.Response.WriteAsync("Confab API!"));
                
            });
            
            _assemblies.Clear();
            _modules.Clear();
        }
    }
}