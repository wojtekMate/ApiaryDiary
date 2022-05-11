using ApiaryDiary.Shared.Abstractions.Exceptions;

namespace ApiaryDiary.Modules.Users.Core.Exceptions;

public class InvalidActivationTokenException : ApiaryDiaryException
{
    public string ActivationToken { get;  }
    public InvalidActivationTokenException(string activationToken) : base($"Wrong activation token '{activationToken}")
    {
        ActivationToken = activationToken;
    }
}