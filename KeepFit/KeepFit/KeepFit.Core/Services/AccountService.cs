using System;
using System.Collections.Generic;
using System.Linq;
using KeepFit.Core.Extensions;
using KeepFit.Core.Models;
using KeepFit.Core.Utils;

namespace KeepFit.Core.Services
{
    public class AccountService : IAccountService
    {
        private IKeepFitContext keepFitContext;
        private readonly ISecurityService securityService;
        public AccountService(IKeepFitContext keepFitContext, ISecurityService securityService)
        {
            this.keepFitContext = keepFitContext;
            this.securityService = securityService;
        }

        public User GetUserByUserName(string userName)
        {
            return keepFitContext.Users.FirstOrDefault(x => x.Username == userName);
        }

        public bool IsUsernameExists(string userName)
        {
            return keepFitContext.Users.Any(u => u.Username == userName);
        }

        public CheckCredentialsResultType CheckCredintials(User user, string password)
        {
            if (user == null)
            {
                return CheckCredentialsResultType.InvalidCredentials;
            }

            if (user.IsDeleted)
            {
                return CheckCredentialsResultType.Inactivated;
            }

            var currentPassword = user.CurrentPassword();

            if (currentPassword == null)
            {
                return CheckCredentialsResultType.NoPasswordHasBeenSetUp;
            }

            if (!securityService.IsPasswordMatch(password, currentPassword.PasswordSalt, currentPassword.NewPassword))
            {
                return CheckCredentialsResultType.InvalidCredentials;
            }

            if (currentPassword.ChangeDateTime.Date.AddDays(
                365) <=
                DateTime.UtcNow.Date)
            {
                return CheckCredentialsResultType.PasswordExpired;
            }
            var passwordForceReseted = user.PasswordChanges.FirstOrDefault(x => x.ForseReseted);
            if (passwordForceReseted != null)
            {
                return CheckCredentialsResultType.ForcePasswordReseted;
            }

            return CheckCredentialsResultType.Ok;
        }

        public User CreateUser(User newUser, string firstname, string lastname, string password, IEnumerable<RoleType> roles)
        {
            if (!password.IsNullOrEmpty())
            {
                string passwordSalt;
                newUser.PasswordChanges = new[]
                {
                    new PasswordChange
                    {
                        ChangeDateTime = DateTime.UtcNow,
                        NewPassword = securityService.GeneratePasswordHash(password, out passwordSalt),
                        PasswordSalt = passwordSalt
                    }
                };
            }
            newUser.Individual = new Individual
            {
                FirstName = firstname,
                LastName = lastname,
                IndividualRoles = roles.Distinct().Select(r => new IndividualRole
                {
                    RoleId = (int)r
                }).ToList()
            };

            keepFitContext.Users.Add(newUser);

            keepFitContext.SaveChanges();

            return newUser;
        }
    }
    public enum CheckCredentialsResultType
    {
        None = 0,
        InvalidCredentials = 1,
        NoPasswordHasBeenSetUp = 2,
        Ok = 3,
        PasswordExpired = 4,
        Inactivated = 5,
        ForcePasswordReseted = 6
    }
}
