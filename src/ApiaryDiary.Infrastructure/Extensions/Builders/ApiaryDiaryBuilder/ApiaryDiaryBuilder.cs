using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiaryDiary.Infrastructure.Extensions.Builders.ApiaryDiaryBuilder
{
    sealed public class ApiaryDiaryBuilder : IApiaryDiaryBuilder
    {
        private readonly IServiceCollection _services;
        IServiceCollection IApiaryDiaryBuilder.Services => _services;

        public IServiceProvider Build()
        {
            throw new NotImplementedException();
        }
        public ApiaryDiaryBuilder(IServiceCollection services)
        {
            _services = services;
        }
        public static IApiaryDiaryBuilder Create(IServiceCollection services)
        => new ApiaryDiaryBuilder(services);
    }
}
