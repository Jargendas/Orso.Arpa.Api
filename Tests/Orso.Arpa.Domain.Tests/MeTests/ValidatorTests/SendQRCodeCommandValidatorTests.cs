using System.Threading.Tasks;
using NUnit.Framework;
using Orso.Arpa.Domain.Entities;
using Orso.Arpa.Domain.Identity;
using Orso.Arpa.Domain.Logic.Me;
using Orso.Arpa.Tests.Shared.Extensions;
using Orso.Arpa.Tests.Shared.Identity;
using Orso.Arpa.Tests.Shared.TestSeedData;

namespace Orso.Arpa.Domain.Tests.AuthTests.ValidatorTests
{
    [TestFixture]
    public class SendQRCodeCommandValidatorTests
    {
        private SendQRCode.Validator _validator;
        private ArpaUserManager _userManager;

        [SetUp]
        public void Setup()
        {
            _userManager = new FakeUserManager();
            _validator = new SendQRCode.Validator(_userManager);
        }

        [Test]
        public async Task Should_Not_Have_Validation_Error_If_Username_Does_Exist()
        {
            await _validator.ShouldNotHaveValidationErrorForExactAsync(c => c.Username, UserTestSeedData.Performer.UserName);
        }

        [Test]
        public async Task Should_Have_Validation_Error_If_Username_Does_Not_Exist()
        {
            await _validator.ShouldHaveNotFoundErrorForAsync(c => c.Username, "DoesNotExist", typeof(User).Name);
        }
    }
}
