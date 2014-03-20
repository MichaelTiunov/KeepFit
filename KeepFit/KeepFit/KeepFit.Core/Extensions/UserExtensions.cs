using System.Collections.Generic;
using System.Linq;
using KeepFit.Core.Models;

namespace KeepFit.Core.Extensions
{
    internal static class UserExtensions
    {
        public static IEnumerable<PasswordChange> LastPasswordChanges(this User user, int count)
        {
            return user.PasswordChanges.OrderByDescending(pc => pc.ChangeDateTime).Take(count);
        }

        public static PasswordChange CurrentPassword(this User user)
        {
            return user.LastPasswordChanges(1).FirstOrDefault();
        }
    }
}
