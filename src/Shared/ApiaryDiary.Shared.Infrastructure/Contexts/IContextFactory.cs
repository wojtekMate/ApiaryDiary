using ApiaryDiary.Shared.Abstractions.Contexts;

namespace ApiaryDiary.Shared.Infrastructure.Contexts;

internal interface IContextFactory
{
    IContext Create();
}