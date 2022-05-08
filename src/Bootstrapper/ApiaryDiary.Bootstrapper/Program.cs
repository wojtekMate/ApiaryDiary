using ApiaryDiary.Shared.Infrastructure;
using ApiaryDiary.Shared.Infrastructure.Modules;

namespace ApiaryDiary.Bootstrapper
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            var builder = WebApplication.CreateBuilder(args);
            builder.ConfigureModules();
            var services = builder.Services;
            services.AddControllers();
            
            
            var  assemblies = ModuleLoader.LoadAssemblies(builder.Configuration);
            var modules = ModuleLoader.LoadModules(assemblies);
            services.AddSharedInfrastructure(assemblies,modules);
            foreach (var module in modules)
            {
                module.Register(services);
            }
            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSharedInfrastructure();
            foreach (var module in modules)
            {
                module.Use(app);
            }
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
            app.Run();
        }
    }
}