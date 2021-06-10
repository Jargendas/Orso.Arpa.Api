using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Orso.Arpa.Domain.Entities;
using Orso.Arpa.Domain.Extensions;
using Orso.Arpa.Domain.Interfaces;

namespace Orso.Arpa.Domain.Logic.Projects
{
    public static class SetProjectParticipation
    {
        public class Command : IRequest<ProjectParticipation>
        {
            public Guid? ParticipationStatusInnerId { get; set; }
            public Guid? ParticipationStatusInternalId { get; set; }
            public Guid? InvitationStatusId { get; set; }
            public string CommentByStaffInner { get; set; }
            public string CommentTeam { get; set; }
            public Guid ProjectId { get; set; }
            public Guid MusicianProfileId { get; set; }
        }

        public class Validator : AbstractValidator<Command>
        {
            public Validator(IArpaContext arpaContext)
            {
                RuleFor(c => c.ProjectId)
                    .EntityExists<Command, Project>(arpaContext, nameof(Command.ProjectId))
                    .MustAsync(async (projectId, cancellation) => !(await arpaContext.FindAsync<Project>(new object[] { projectId }, cancellation)).IsCompleted)
                    .WithMessage("The project is completed. You may not set the participation of a completed project");

                RuleFor(c => c.ParticipationStatusInnerId)
                    .SelectValueMapping<Command, ProjectParticipation>(arpaContext, p => p.ParticipationStatusInner);

                RuleFor(c => c.ParticipationStatusInternalId)
                    .SelectValueMapping<Command, ProjectParticipation>(arpaContext, p => p.ParticipationStatusInternal);

                RuleFor(c => c.InvitationStatusId)
                    .SelectValueMapping<Command, ProjectParticipation>(arpaContext, p => p.InvitationStatus);

                RuleFor(c => c.MusicianProfileId)
                    .EntityExists<Command, MusicianProfile>(arpaContext, nameof(Command.MusicianProfileId))
                    .MustAsync(async (musicianProfileId, cancellation) => !(await arpaContext.FindAsync<MusicianProfile>(new object[] { musicianProfileId }, cancellation)).IsDeactivated)
                    .WithMessage("The musician profile is deactivated. A deactivated musician profile may not participate in a project");
            }
        }

        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<Command, ProjectParticipation>()
                    .ForMember(dest => dest.ParticipationStatusInnerId, opt => opt.MapFrom(src => src.ParticipationStatusInnerId))
                    .ForMember(dest => dest.ParticipationStatusInternalId, opt => opt.MapFrom(src => src.ParticipationStatusInternalId))
                    .ForMember(dest => dest.InvitationStatusId, opt => opt.MapFrom(src => src.InvitationStatusId))
                    .ForMember(dest => dest.CommentByStaffInner, opt => opt.MapFrom(src => src.CommentByStaffInner))
                    .ForMember(dest => dest.CommentTeam, opt => opt.MapFrom(src => src.CommentTeam))
                    .ForAllOtherMembers(opt => opt.Ignore());
            }
        }

        public class Handler : IRequestHandler<Command, ProjectParticipation>
        {
            private readonly IArpaContext _arpaContext;
            private readonly IMapper _mapper;

            public Handler(IArpaContext arpaContext, IMapper mapper)
            {
                _arpaContext = arpaContext;
                _mapper = mapper;
            }

            public async Task<ProjectParticipation> Handle(Command request, CancellationToken cancellationToken)
            {
                ProjectParticipation participation = await _arpaContext.ProjectParticipations
                    .SingleOrDefaultAsync(pp => pp.ProjectId == request.ProjectId && pp.MusicianProfileId == request.MusicianProfileId, cancellationToken);

                if (participation == null)
                {
                    participation = new ProjectParticipation(request);
                    participation = (await _arpaContext.ProjectParticipations.AddAsync(participation, cancellationToken)).Entity;
                }
                else
                {
                    _mapper.Map(request, participation);
                    participation = _arpaContext.ProjectParticipations.Update(participation).Entity;
                }

                if (await _arpaContext.SaveChangesAsync(cancellationToken) > 0)
                {
                    return participation;
                }

                throw new Exception("Problem setting project participation");
            }
        }
    }
}