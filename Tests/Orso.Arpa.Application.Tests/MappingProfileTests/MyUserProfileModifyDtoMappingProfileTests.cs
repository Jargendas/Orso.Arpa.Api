using AutoMapper;
using FluentAssertions;
using NUnit.Framework;
using Orso.Arpa.Application.MeApplication;
using Orso.Arpa.Domain.Logic.Me;
using Orso.Arpa.Tests.Shared.TestSeedData;

namespace Orso.Arpa.Application.Tests.MappingProfileTests
{
    [TestFixture]
    public class MyUserProfileModifyDtoMappingProfileTests
    {
        [SetUp]
        public void Setup()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MyUserProfileModifyDtoMappingProfile>());

            _mapper = new Mapper(config);
        }

        private IMapper _mapper;

        [Test]
        public void Should_Map()
        {
            // Arrange
            var dto = new MyUserProfileModifyDto
            {
                Email = UserTestSeedData.Performer.Email,
                GivenName = "Orsi",
                Surname = "Aner",
            };

            // Act
            Modify.Command command = _mapper.Map<Modify.Command>(dto);

            // Assert
            command.Should().BeEquivalentTo(dto);
        }
    }
}
