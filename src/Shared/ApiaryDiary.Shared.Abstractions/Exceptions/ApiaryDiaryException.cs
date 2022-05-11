namespace ApiaryDiary.Shared.Abstractions.Exceptions;

public class ApiaryDiaryException : Exception
{
    protected ApiaryDiaryException(string message) : base(message)
    {
    }
}