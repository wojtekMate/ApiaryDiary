using ApiaryDiary.Shared.Abstractions.Exceptions;

namespace ApiaryDiary.Modules.Users.Core.Exceptions;

internal class EmailInUseException : ApiaryDiaryException
{
    public EmailInUseException() : base("Email is already in use.")
    {
    }
}