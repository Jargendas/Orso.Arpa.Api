using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Orso.Arpa.Domain.Entities;
using Orso.Arpa.Domain.Enums;
using Orso.Arpa.Domain.Errors;
using Orso.Arpa.Domain.Extensions;
using Orso.Arpa.Domain.Identity;
using Orso.Arpa.Domain.Interfaces;
using Orso.Arpa.Misc;

namespace Orso.Arpa.Domain.Logic.Auth
{
    public static class UserRegister
    {
        public class Command : IRequest
        {
            public string UserName { get; set; }
            public string Password { get; set; }
            public string Email { get; set; }
            public string GivenName { get; set; }
            public string Surname { get; set; }
            public DateTime DateOfBirth { get; set; }
            public Guid GenderId { get; set; }
            public string ClientUri { get; set; }

            public IList<Guid> StakeholderGroupIds { get; set; } = new List<Guid>();
        }

        public class Validator : AbstractValidator<Command>
        {
            public Validator(ArpaUserManager userManager, IArpaContext context)
            {
                _ = RuleFor(c => c.UserName)
                    .MustAsync(async (username, _) => await userManager.FindByNameAsync(username) == null)
                    .WithMessage("Username aleady exists");
                _ = RuleFor(c => c.Email)
                    .MustAsync(async (email, _) => await userManager.FindByEmailAsync(email) == null)
                    .WithMessage("Email aleady exists");
                _ = RuleForEach(c => c.StakeholderGroupIds)
                    .EntityExists<Command, Section>(context);
                _ = RuleFor(c => c.GenderId)
                    .SelectValueMapping<Command, Person>(context, p => p.Gender);
            }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly ArpaUserManager _userManager;
            private readonly IDateTimeProvider _dateTimeProvider;
            private readonly IArpaContext _arpaContext;

            public Handler(
                ArpaUserManager userManager,
                IDateTimeProvider dateTimeProvider,
                IArpaContext arpaContext)
            {
                _userManager = userManager;
                _dateTimeProvider = dateTimeProvider;
                _arpaContext = arpaContext;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var existingPersons = _arpaContext.Persons
                    .AsQueryable()
                    .Where(p =>
                        p.User == null
                        && p.ContactDetails.Any(detail =>
                            detail.Key == ContactDetailKey.EMail
#pragma warning disable RCS1155 // Use StringComparison when comparing strings.
                            && detail.Value.ToLower() == request.Email.ToLower()))
#pragma warning restore RCS1155 // Use StringComparison when comparing strings.
                    .ToList();

                Person person;

                switch (existingPersons.Count)
                {
                    case 0:
                        person = new Person(Guid.NewGuid(), request);
                        break;
                    case 1:
                        Person existingPerson = existingPersons[0];
                        if (!(existingPerson.GivenName.Equals(request.GivenName) && existingPerson.Surname.Equals(request.Surname)))
                        {
                            throw new AuthorizationException("You are not allowed to register with this combination of email address and name.");
                        }
                        person = existingPerson;
                        person.Update(request);
                        break;
                    default:
                        throw new ValidationException(
                            new ValidationFailure[] { new ValidationFailure(nameof(Command.Email), "Multiple persons found with this email address. Registration aborted. Please contact your system admin.") });
                }

                var user = new User
                {
                    Email = request.Email,
                    UserName = request.UserName,
                    Person = person,
                    CreatedAt = _dateTimeProvider.GetUtcNow()
                };

                IdentityResult result = await _userManager.CreateAsync(user, request.Password);

                if (!result.Succeeded)
                {
                    throw new IdentityException("Problem creating user", result.Errors);
                }

                _arpaContext.Set<PersonSection>().AddRange(request.StakeholderGroupIds.Select(sg => new PersonSection(null, person.Id, sg)));
                _ = _arpaContext.Set<ContactDetail>().Add(new ContactDetail(null, new ContactDetails.Create.Command
                {
                    Key = ContactDetailKey.EMail,
                    PersonId = person.Id,
                    Value = request.Email,
                }));

                return (await _arpaContext.SaveChangesAsync(cancellationToken)) < request.StakeholderGroupIds.Count + 1
                    ? throw new Exception("Problem creating stakeholder groups")
                    : Unit.Value;
            }
        }
    }
}
