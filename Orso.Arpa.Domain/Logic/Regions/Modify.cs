using System;
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Orso.Arpa.Domain.Entities;
using Orso.Arpa.Domain.Extensions;
using Orso.Arpa.Domain.Interfaces;
using static Orso.Arpa.Domain.GenericHandlers.Modify;

namespace Orso.Arpa.Domain.Logic.Regions
{
    public static class Modify
    {
        public class Command : IModifyCommand<Region>
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
        }

        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<Command, Region>()
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    .ForAllOtherMembers(opt => opt.Ignore());
            }
        }

        public class Validator : AbstractValidator<Command>
        {
            public Validator(IArpaContext arpaContext)
            {
                

                RuleFor(c => c.Id)
                    .EntityExists<Command, Region>(arpaContext, nameof(Command.Id));

                RuleFor(c => c.Name)
                    .MustAsync(async (dto, name, cancellation) => !(await arpaContext.Regions
                        .AnyAsync(r => r.Name.ToLower() == name.ToLower() && r.Id != dto.Id, cancellation)))
                    .WithMessage("A region with the requested name does already exist");
            }
        }
    }
}
