using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiaryDiary.Infrastructure.Extensions.Builders.ApiaryDiaryBuilder
{
    public interface IApiaryDiaryBuilder
    {
        IServiceCollection Services { get; }
        IServiceProvider Build();
    }
}
