using ApiaryDiary.Infrastructure.Extensions.Builders.ApiaryDiaryBuilder.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace ApiaryDiary.Infrastructure.Extensions.Builders.ApiaryDiaryBuilder
{
    public static class BuilderExtensions
    {
        private const string SectionName = "sectionName";
        public static IApiaryDiaryBuilder AddApiaryDiary(this IServiceCollection services, string sectionName = SectionName)
        {
            if (string.IsNullOrWhiteSpace(sectionName))
            {
                sectionName = SectionName;
            }

            var builder = ApiaryDiaryBuilder.Create(services);
            var options = builder.GetOptions<Types.AppOptions>(sectionName);
            services.AddSingleton(options);
            return builder;
        }
        public static IApplicationBuilder UseBuilder(this IApplicationBuilder app)
        {
            return app;
        }
        public static TModel GetOptions<TModel>(this IApiaryDiaryBuilder builder, string settingsSectionName) where TModel : new()
        {
            using var serviceProvider = builder.Services.BuildServiceProvider();
            var configuration = serviceProvider.GetService<IConfiguration>();
            return configuration.GetOptions<TModel>(settingsSectionName);
        }
        public static TModel GetOptions<TModel>(this IConfiguration configuration, string sectionName) where TModel : new()
        {
            var model = new TModel();
            configuration.GetSection(sectionName).Bind(model);
            return model;
        }
    }
}
