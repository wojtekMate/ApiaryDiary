namespace ApiaryDiary.Modules.Users.Core.Services
{
    public interface IRng
    {
        string Generate(int length = 50, bool removeSpecialChars = false);
    }
}
