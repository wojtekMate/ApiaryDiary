using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiaryDiary.Application;
using ApiaryDiary.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Shared;

namespace ApiaryDiary.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var services = builder.Services;

            services.AddControllers();
            services.AddSharedInfrastructure();
            services.AddInfrastructure();
            services.AddApplication();

            var app = builder.Build();
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSharedInfrastructure();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
            app.Run();
        }
    }
}