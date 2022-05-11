using ApiaryDiary.Shared.Abstractions.Exceptions;

namespace ApiaryDiary.Modules.Users.Core.Exceptions;

public class InvalidCredentialsException : ApiaryDiaryException
{
    public InvalidCredentialsException() : base("Invalid credentials.")
    {
        
    }
}