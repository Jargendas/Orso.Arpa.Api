using System.Threading.Tasks;
using NUnit.Framework;
using Orso.Arpa.Domain.Entities;
using Orso.Arpa.Domain.Identity;
using Orso.Arpa.Tests.Shared.Extensions;
using Orso.Arpa.Tests.Shared.Identity;
using Orso.Arpa.Tests.Shared.TestSeedData;
using static Orso.Arpa.Domain.Logic.Auth.ResetPassword;

namespace Orso.Arpa.Domain.Tests.AuthTests.ValidatorTests
{
    [TestFixture]
    public class ResetPasswordCommandValidatorTests
    {
        private Validator _validator;
        private ArpaUserManager _userManager;

        [SetUp]
        public void Setup()
        {
            _userManager = new FakeUserManager();
            _validator = new Validator(_userManager);
        }

        [Test]
        public async Task Should_Have_Validation_Error_If_Username_Does_Not_Exist()
        {
            await _validator.ShouldHaveNotFoundErrorForAsync(c => c.UsernameOrEmail, "DoesNotExist", typeof(User).Name);
        }

        [Test]
        public async Task Should_Not_Have_Validation_Error_If_Valid_UserName_Is_Supplied()
        {
            await _validator.ShouldNotHaveValidationErrorForExactAsync(command => command.UsernameOrEmail, UserTestSeedData.Performer.UserName);
        }
    }
}
