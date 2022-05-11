using ApiaryDiary.Shared.Abstractions.Exceptions;

namespace ApiaryDiary.Modules.Users.Core.Exceptions;

public class UserNotActiveException : ApiaryDiaryException
{
    public Guid UserId { get; }
    public UserNotActiveException(Guid userId) : base($"User with ID: '{userId}' is not active")
    {
        UserId = userId;
    }
}