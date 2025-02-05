using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Orso.Arpa.Application.CurriculumVitaeReferenceApplication;
using Orso.Arpa.Application.EducationApplication;
using Orso.Arpa.Application.General;
using Orso.Arpa.Application.MusicianProfileApplication;
using Orso.Arpa.Application.MusicianProfileDeactivationApplication;
using Orso.Arpa.Domain.Entities;
using Orso.Arpa.Domain.Enums;

namespace Orso.Arpa.Application.MeApplication
{
    public class MyMusicianProfileDto : BaseEntityDto
    {
        public bool IsMainProfile { get; set; }
        public byte LevelAssessmentInner { get; set; }
        public byte ProfilePreferenceInner { get; set; }
        public string BackgroundInner { get; set; }
        public Guid PersonId { get; set; }
        public Guid InstrumentId { get; set; }
        public MusicianProfileInquiryStatus? InquiryStatusInner { get; set; }
        public IList<MyDoublingInstrumentDto> DoublingInstruments { get; set; } = new List<MyDoublingInstrumentDto>();
        public IList<EducationDto> Educations { get; set; } = new List<EducationDto>();
        public IList<CurriculumVitaeReferenceDto> CurriculumVitaeReferences { get; set; } = new List<CurriculumVitaeReferenceDto>();
        public IList<Guid> PreferredPositionsInnerIds { get; set; } = new List<Guid>();
        public IList<byte> PreferredPartsInner { get; set; } = new List<byte>();
        public IList<Guid> Documents { get; set; } = new List<Guid>();
        public MusicianProfileDeactivationDto Deactivation { get; set; }
        public IList<RegionPreferenceDto> RegionPreferencesRehearsal { get; set; } = new List<RegionPreferenceDto>();
        public IList<RegionPreferenceDto> RegionPreferencesPerformance { get; set; } = new List<RegionPreferenceDto>();
    }

    public class MyDoublingInstrumentDto : BaseEntityDto
    {
        public Guid InstrumentId { get; set; }
        public byte LevelAssessmentInner { get; set; }
        public Guid? AvailabilityId { get; set; }
        public string Comment { get; set; }
    }

    public class MyMusicianProfileDtoMappingProfile : Profile
    {
        public MyMusicianProfileDtoMappingProfile()
        {
            _ = CreateMap<MusicianProfile, MyMusicianProfileDto>()
                .ForMember(dest => dest.IsMainProfile, opt => opt.MapFrom(src => src.IsMainProfile))
                .ForMember(dest => dest.Deactivation, opt => opt.MapFrom(src => src.Deactivation))

                .ForMember(dest => dest.LevelAssessmentInner, opt => opt.MapFrom(src => src.LevelAssessmentInner))
                .ForMember(dest => dest.ProfilePreferenceInner, opt => opt.MapFrom(src => src.ProfilePreferenceInner))
                .ForMember(dest => dest.BackgroundInner, opt => opt.MapFrom(src => src.BackgroundInner))

                .ForMember(dest => dest.PersonId, opt => opt.MapFrom(src => src.PersonId))
                .ForMember(dest => dest.InstrumentId, opt => opt.MapFrom(src => src.InstrumentId))
                .ForMember(dest => dest.InquiryStatusInner, opt => opt.MapFrom(src => src.InquiryStatusInner))

                .ForMember(dest => dest.DoublingInstruments, opt => opt.MapFrom(src => src.DoublingInstruments))
                .ForMember(dest => dest.PreferredPositionsInnerIds, opt => opt.MapFrom(src => src.PreferredPositionsInner
                    .Select(p => p.SelectValueSectionId)))
                .ForMember(dest => dest.PreferredPartsInner, opt => opt.MapFrom(src => src.PreferredPartsInner))
                .ForMember(dest => dest.Documents, opt => opt.MapFrom(src => src.Documents.Select(d => d.SelectValueMappingId)))
                .ForMember(dest => dest.RegionPreferencesPerformance, opt => opt.MapFrom(src => src.RegionPreferences.Where(p => p.Type == RegionPreferenceType.Performance)))
                .ForMember(dest => dest.RegionPreferencesRehearsal, opt => opt.MapFrom(src => src.RegionPreferences.Where(p => p.Type == RegionPreferenceType.Rehearsal)))

                .IncludeBase<BaseEntity, BaseEntityDto>();
        }
    }

    public class MyDoublingInstrumentDtoMappingProfile : Profile
    {
        public MyDoublingInstrumentDtoMappingProfile()
        {
            _ = CreateMap<MusicianProfileSection, MyDoublingInstrumentDto>()
                .ForMember(dest => dest.AvailabilityId, opt => opt.MapFrom(src => src.InstrumentAvailabilityId))
                .ForMember(dest => dest.InstrumentId, opt => opt.MapFrom(src => src.SectionId))
                .ForMember(dest => dest.LevelAssessmentInner, opt => opt.MapFrom(src => src.LevelAssessmentInner))
                .ForMember(dest => dest.Comment, opt => opt.MapFrom(src => src.Comment))
                .IncludeBase<BaseEntity, BaseEntityDto>();
        }
    }
}
