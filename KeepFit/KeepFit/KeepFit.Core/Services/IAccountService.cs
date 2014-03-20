using System.Collections.Generic;
using KeepFit.Core.Models;

namespace KeepFit.Core.Services
{
    public interface IAccountService
    {
        User GetUserByUserName(string userName);

        bool IsUsernameExists(string userName);
        CheckCredentialsResultType CheckCredintials(User user, string password);

        User CreateUser(User newUser, string firstname, string lastname, string password, IEnumerable<RoleType> roles);
    }
}
