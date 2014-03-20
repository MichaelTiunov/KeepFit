using KeepFit.Core.Models;

namespace KeepFit.Core.Services
{
    public interface IAccountService
    {
        User GetUserByUserName(string userName);
        CheckCredentialsResultType CheckCredintials(User user, string password);
    }
}
