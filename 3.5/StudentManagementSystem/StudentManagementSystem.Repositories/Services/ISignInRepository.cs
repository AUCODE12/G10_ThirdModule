namespace StudentManagementSystem.Repositories.Services;

public interface ISignInRepository
{
    void SignInClient(string email, string password);
}