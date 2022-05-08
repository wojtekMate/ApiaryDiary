using ApiaryDiary.Shared.Abstractions.Time;

namespace ApiaryDiary.Shared.Infrastructure.Time;

internal class UtcClock : IClock
{
    public DateTime CurrentDate()
    {
        return DateTime.UtcNow;
    }
}