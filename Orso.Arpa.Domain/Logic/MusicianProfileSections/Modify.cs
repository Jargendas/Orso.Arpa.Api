using System;
using FluentValidation;
using Orso.Arpa.Domain.Entities;
using Orso.Arpa.Domain.Extensions;
using Orso.Arpa.Domain.Interfaces;
using static Orso.Arpa.Domain.GenericHandlers.Modify;

namespace Orso.Arpa.Domain.Logic.MusicianProfileSections
{
    public static class Modify
    {
        public class Command : IModifyCommand<MusicianProfileSection>
        {
            public Guid Id { get; set; }
            public Guid MusicianProfileId { get; set; }
            public byte LevelAssessmentInner { get; set; }
            public byte LevelAssessmentTeam { get; set; }
            public Guid? AvailabilityId { get; set; }
            public string Comment { get; set; }
        }

        public class Validator : AbstractValidator<Command>
        {
            public Validator(IArpaContext arpaContext)
            {
                RuleFor(c => c.Id)
                    .MustAsync(async (command, id, cancellation) => await arpaContext
                        .EntityExistsAsync<MusicianProfileSection>(s => s.Id == id && s.MusicianProfileId == command.MusicianProfileId, cancellation))
                    .WithMessage("Doubling instrument with this id and the supplied musician profile does not exist");

                RuleFor(c => c.AvailabilityId)
                    .SelectValueMapping<Command, MusicianProfileSection>(arpaContext, a => a.InstrumentAvailability);
            }
        }
    }
}
