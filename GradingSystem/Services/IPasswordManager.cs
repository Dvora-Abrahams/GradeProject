namespace GradingSystem.Services
{
    public interface IPasswordManager
    {
        bool ValideNameAndPassword(string name, string password);
    }
}