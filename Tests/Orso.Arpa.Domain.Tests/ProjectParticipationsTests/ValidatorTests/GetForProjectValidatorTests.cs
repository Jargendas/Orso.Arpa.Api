using System;
using System.Threading;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using Orso.Arpa.Domain.Entities;
using Orso.Arpa.Domain.Interfaces;
using Orso.Arpa.Domain.Logic.ProjectParticipations;
using Orso.Arpa.Tests.Shared.Extensions;

namespace Orso.Arpa.Domain.Tests.ProjectParticipationsTests.ValidatorTests
{
    [TestFixture]
    public class GetForProjectValidatorTests
    {
        private IArpaContext _arpaContext;
        private GetForProject.Validator _validator;

        [SetUp]
        public void Setup()
        {
            _arpaContext = Substitute.For<IArpaContext>();
            _validator = new GetForProject.Validator(_arpaContext);
        }

        [Test]
        public async Task Should_Have_Validation_Error_If_Not_Existing_ProjectId_Is_Supplied()
        {
            _arpaContext.EntityExistsAsync<Project>(Arg.Any<Guid>(), Arg.Any<CancellationToken>()).Returns(false);

            await _validator.ShouldHaveNotFoundErrorForAsync(c => c.ProjectId, Guid.NewGuid(), nameof(Project));
        }

        [Test]
        public async Task Should_Not_Have_Validation_Error_If_Valid_ProjectId_Is_Supplied()
        {
            _arpaContext.EntityExistsAsync<Project>(Arg.Any<Guid>(), Arg.Any<CancellationToken>()).Returns(true);

            await _validator.ShouldNotHaveValidationErrorForExactAsync(c => c.ProjectId, Guid.NewGuid());
        }
    }
}
