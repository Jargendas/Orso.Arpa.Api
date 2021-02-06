using System.Linq;
using AutoMapper;
using FluentAssertions;
using NUnit.Framework;
using Orso.Arpa.Application.AppointmentApplication;
using Orso.Arpa.Application.General;
using Orso.Arpa.Application.ProjectApplication;
using Orso.Arpa.Domain.Entities;
using Orso.Arpa.Tests.Shared.DtoTestData;
using Orso.Arpa.Tests.Shared.Extensions;
using Orso.Arpa.Tests.Shared.TestSeedData;

namespace Orso.Arpa.Application.Tests.MappingProfileTests
{
    [TestFixture]
    public class AppointmentDtoMappingProfileTests
    {
        [SetUp]
        public void Setup()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AppointmentDtoMappingProfile>();
                cfg.AddProfile<BaseEntityDtoMappingProfile>();
                cfg.AddProfile<ProjectDtoMappingProfile>();
            });

            _mapper = new Mapper(config);
        }

        private IMapper _mapper;

        [Test]
        public void Should_Map()
        {
            // Arrange
            Appointment appointment = AppointmentSeedData.RockingXMasRehearsal;
            appointment.ProjectAppointments.First().SetProperty(nameof(ProjectAppointment.Project), ProjectSeedData.RockingXMas);
            AppointmentDto expectedDto = AppointmentDtoData.RockingXMasRehearsal;

            // Act
            AppointmentDto dto = _mapper.Map<AppointmentDto>(appointment);

            // Assert
            dto.Should().BeEquivalentTo(expectedDto, opt => opt
                .Excluding(dto => dto.CreatedBy)
                .Excluding(dto => dto.Participations)
                .Excluding(dto => dto.Projects));
            for (int i = 0; i < expectedDto.Projects.Count; i++)
            {
                dto.Projects[i].Should().BeEquivalentTo(expectedDto.Projects[i], opt => opt
                    .Excluding(p => p.CreatedAt)
                    .Excluding(p => p.CreatedBy));
            }
        }
    }
}