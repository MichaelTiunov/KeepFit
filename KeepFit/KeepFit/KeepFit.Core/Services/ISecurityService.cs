using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepFit.Core.Services
{
    public interface ISecurityService
    {
        string GeneratePasswordHash(string plainTextPassword, out string salt);

        bool IsPasswordMatch(string password, string salt, string hash);
    }
}
