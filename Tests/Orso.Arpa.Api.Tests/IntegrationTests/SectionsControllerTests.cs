using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Orso.Arpa.Api.Tests.IntegrationTests.Shared;
using Orso.Arpa.Application.SectionApplication;
using Orso.Arpa.Tests.Shared.DtoTestData;

namespace Orso.Arpa.Api.Tests.IntegrationTests
{
    [TestFixture]
    public class SectionsControllerTests : IntegrationTestBase
    {
        [Test, Order(1)]
        public async Task Should_Get_All()
        {
            // Act
            HttpResponseMessage responseMessage = await _authenticatedServer
                .CreateClient()
                .AuthenticateWith(_performer)
                .GetAsync(ApiEndpoints.SectionsController.Get());

            // Assert
            responseMessage.StatusCode.Should().Be(HttpStatusCode.OK);
            IEnumerable<SectionDto> result = await DeserializeResponseMessageAsync<IEnumerable<SectionDto>>(responseMessage);
            result.Should().BeEquivalentTo(SectionDtoData.Sections);
        }

        [Test, Order(2)]
        public async Task Should_Get_Tree()
        {
            // Act
            HttpResponseMessage responseMessage = await _authenticatedServer
                .CreateClient()
                .AuthenticateWith(_performer)
                .GetAsync(ApiEndpoints.SectionsController.GetTree(2));

            // Assert
            responseMessage.StatusCode.Should().Be(HttpStatusCode.OK);
            SectionTreeDto result = await DeserializeResponseMessageAsync<SectionTreeDto>(responseMessage);
            result.Should().BeEquivalentTo(SectionTreeDtoData.Level2SectionTreeDto);
        }
    }
}
