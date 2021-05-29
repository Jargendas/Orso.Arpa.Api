using System;
using Orso.Arpa.Application.MyMusicianProfileApplication;
using Orso.Arpa.Persistence.Seed;
using Orso.Arpa.Tests.Shared.FakeData;

namespace Orso.Arpa.Tests.Shared.DtoTestData
{
    public static class MyMusicianProfileDtoData
    {
        public static MyMusicianProfileDto PerformerProfile
        {
            get
            {
                return new MyMusicianProfileDto
                {
                    Id = Guid.Parse("9a609084-a5b6-485f-8960-724a8b470b13"),
                    PersonId = Guid.Parse("cb441176-eecb-4c56-908d-5a6afec36a95"),
                    InstrumentId = SectionSeedData.Alto1.Id,
                    CreatedAt = FakeDateTime.UtcNow,
                    CreatedBy = "anonymous",
                    IsMainProfile = true
                };
            }
        }

        public static MyMusicianProfileDto PerformersHornMusicianProfile
        {
            get
            {
                var dto = new MyMusicianProfileDto
                {
                    Id = Guid.Parse("e2ef2e6c-035e-4fff-9293-a6a7b67524a9"),
                    PersonId = Guid.Parse("cb441176-eecb-4c56-908d-5a6afec36a95"),
                    InstrumentId = Guid.Parse("b9532add-efec-4510-831c-902c32ef7dbb"),
                    LevelAssessmentPerformer = 1,
                    InquiryStatusPerformerId = SelectValueMappingSeedData.MusicianProfileInquiryStatusPerformerMappings[1].Id,
                    BackgroundPerformer = "Background Trombonist",
                    ProfilePreferencePerformer = 3,
                    CreatedAt = FakeDateTime.UtcNow,
                    CreatedBy = "anonymous",
                    IsMainProfile = false,
                };
                dto.DoublingInstruments.Add(new MyDoublingInstrumentDto
                {
                    AvailabilityId = Guid.Parse("d33ea034-0c5f-458d-bef5-26d2c12b6b03"),
                    Comment = "Wagner rocks",
                    LevelAssessmentPerformer = 3,
                    Id = Guid.Parse("d57c5706-f0aa-4e02-829c-e7823ed7a63d"),
                    CreatedAt = FakeDateTime.UtcNow,
                    CreatedBy = "anonymous",
                    InstrumentId = Guid.Parse("c42591db-4e41-413f-8b98-6607e2f12e39")
                });
                dto.PreferredPositionsPerformerIds.Add(Guid.Parse("b43fc897-ebcf-4d2a-8682-33b6337b5ab2"));
                dto.PreferredPartsPerformer.Add(2);
                return dto;
            }
        }

        public static MyMusicianProfileDto PerformersDeactivatedTubaProfile
        {
            get
            {
                return new MyMusicianProfileDto
                {
                    Id = Guid.Parse("056a27f0-cd88-4cd9-8729-ce2f23b8b0ef"),
                    PersonId = Guid.Parse("cb441176-eecb-4c56-908d-5a6afec36a95"),
                    InstrumentId = SectionSeedData.Tuba.Id,
                    CreatedAt = FakeDateTime.UtcNow,
                    CreatedBy = "anonymous",
                    IsMainProfile = false,
                    IsDeactivated = true,
                };
            }
        }
    }
}