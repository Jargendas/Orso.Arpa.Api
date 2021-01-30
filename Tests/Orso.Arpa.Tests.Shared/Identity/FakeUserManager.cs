using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MockQueryable.NSubstitute;
using NSubstitute;
using Orso.Arpa.Domain.Entities;
using Orso.Arpa.Domain.Roles;
using Orso.Arpa.Persistence.Seed;
using Orso.Arpa.Tests.Shared.FakeData;
using Orso.Arpa.Tests.Shared.TestSeedData;

namespace Orso.Arpa.Tests.Shared.Identity
{
    public class FakeUserManager : UserManager<User>
    {
        private static readonly string _emailConfirmationToken = "ABCDEFGHIJKLMNOP+";

        public FakeUserManager()
            : base(
              Substitute.For<IUserStore<User>>(),
              Substitute.For<IOptions<IdentityOptions>>(),
              Substitute.For<IPasswordHasher<User>>(),
              new IUserValidator<User>[0],
              new IPasswordValidator<User>[0],
              Substitute.For<ILookupNormalizer>(),
              Substitute.For<IdentityErrorDescriber>(),
              Substitute.For<IServiceProvider>(),
              Substitute.For<ILogger<UserManager<User>>>())
        { }

        public override IQueryable<User> Users
        {
            get
            {
                IEnumerable<User> users = FakeUsers.Users.Where(u => !u.Deleted);
                return users.AsQueryable().BuildMock();
            }
        }

        public override string NormalizeName(string key)
        {
            return key.ToUpperInvariant();
        }

        public override Task<User> FindByEmailAsync(string email)
        {
            return Task.FromResult(FakeUsers.Users.FirstOrDefault(u => u.Email.Equals(email, StringComparison.InvariantCultureIgnoreCase) && !u.Deleted));
        }

        public override Task<User> FindByNameAsync(string userName)
        {
            return Task.FromResult(FakeUsers.Users.FirstOrDefault(u => u.UserName.Equals(userName, StringComparison.InvariantCultureIgnoreCase) && !u.Deleted));
        }

        public override Task<IdentityResult> CreateAsync(User user, string password)
        {
            return Task.FromResult(IdentityResult.Success);
        }

        public override Task<IdentityResult> ChangePasswordAsync(User user, string currentPassword, string newPassword)
        {
            return Task.FromResult(IdentityResult.Success);
        }

        public override Task<bool> CheckPasswordAsync(User user, string password)
        {
            return Task.FromResult(password.Equals(UserSeedData.ValidPassword));
        }

        public override Task<IdentityResult> UpdateAsync(User user)
        {
            return Task.FromResult(IdentityResult.Success);
        }

        public override Task<IList<string>> GetRolesAsync(User user)
        {
            var roleNames = RoleSeedData.Roles.Select(r => r.Name).ToList();
            roleNames.RemoveAll(rn => !rn.Equals(user.UserName, StringComparison.InvariantCultureIgnoreCase));
            return Task.FromResult(roleNames as IList<string>);
        }

        public override Task<IdentityResult> AddToRoleAsync(User user, string role)
        {
            return Task.FromResult(IdentityResult.Success);
        }

        public override Task<IdentityResult> RemoveFromRoleAsync(User user, string role)
        {
            return Task.FromResult(IdentityResult.Success);
        }

        public override Task<bool> IsInRoleAsync(User user, string role)
        {
            if (user.Id == FakeUsers.Admin.Id && role == RoleNames.Admin)
            {
                return Task.FromResult(true);
            }
            if (user.Id == FakeUsers.Performer.Id && role == RoleNames.Performer)
            {
                return Task.FromResult(true);
            }
            if (user.Id == FakeUsers.Staff.Id && role == RoleNames.Staff)
            {
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        public override Task<string> GeneratePasswordResetTokenAsync(User user)
        {
            return Task.FromResult("PasswordResetToken");
        }

        public override Task<IdentityResult> ResetPasswordAsync(User user, string token, string newPassword)
        {
            return Task.FromResult(IdentityResult.Success);
        }

        public override Task<bool> IsEmailConfirmedAsync(User user)
        {
            return Task.FromResult(user.EmailConfirmed);
        }

        public override Task<string> GenerateEmailConfirmationTokenAsync(User user)
        {
            return Task.FromResult(_emailConfirmationToken);
        }

        public override Task<IdentityResult> ConfirmEmailAsync(User user, string token)
        {
            if (user != null && token == _emailConfirmationToken)
            {
                return Task.FromResult(IdentityResult.Success);
            }
            return Task.FromResult(IdentityResult.Failed(new[] { new IdentityError() }));
        }
    }
}
