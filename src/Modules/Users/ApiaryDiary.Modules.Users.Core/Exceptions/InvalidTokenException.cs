using ApiaryDiary.Shared.Abstractions.Exceptions;

namespace ApiaryDiary.Modules.Users.Core.Exceptions;

public class InvalidTokenException : ApiaryDiaryException
{
    public InvalidTokenException() : base("Given token is invalid.")
    {
    }
}