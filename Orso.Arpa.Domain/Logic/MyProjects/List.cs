using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Orso.Arpa.Domain.Entities;
using Orso.Arpa.Domain.Enums;
using Orso.Arpa.Domain.Interfaces;

namespace Orso.Arpa.Domain.Logic.MyProjects;

public static class List
{
    public class MyProjectGrouping
    {
        public Project Project { get; set; }
        public IEnumerable<ProjectParticipation> ProjectParticipations { get; set; }
    }

    public class Query : IRequest<Tuple<IEnumerable<MyProjectGrouping>, int>>
    {
        public Guid PersonId { get; set; }
        public int? Limit { get; set; }
        public int? Offset { get; set; }
        public bool IncludeCompleted { get; set; }
    }

    public class Handler : IRequestHandler<Query, Tuple<IEnumerable<MyProjectGrouping>, int>>
    {
        private readonly IArpaContext _arpaContext;

        public Handler(IArpaContext arpaContext)
        {
            _arpaContext = arpaContext;
        }

        public async Task<Tuple<IEnumerable<MyProjectGrouping>, int>> Handle(Query request, CancellationToken cancellationToken)
        {
            List<Guid> musicianProfileIds = await _arpaContext.MusicianProfiles
                .Where(mp => mp.PersonId == request.PersonId)
                .Select(mp => mp.Id)
                .ToListAsync(cancellationToken: cancellationToken);

            IQueryable<Project> projectQuery = _arpaContext.Projects
                .Where(p => (!p.IsCompleted || request.IncludeCompleted)
                    && !p.IsHiddenForPerformers
                    && !ProjectStatus.Cancelled.Equals(p.Status)
                    && !p.Children.Any())
                .OrderByDescending(p => p.StartDate);

            var totalRecordsCount = await projectQuery.CountAsync(cancellationToken);

            if (request.Offset.HasValue)
            {
                projectQuery = projectQuery.Skip(request.Offset ?? 0);
            }

            if (request.Limit.HasValue)
            {
                projectQuery = projectQuery.Take(request.Limit.Value);
            }

            var result = new List<MyProjectGrouping>();

            foreach (Project project in await projectQuery.ToListAsync(cancellationToken))
            {
                result.Add(new MyProjectGrouping
                {
                    Project = project,
                    ProjectParticipations = musicianProfileIds.Any()
                        ? musicianProfileIds.Select(muproId =>
                        {
                            ProjectParticipation existingParticipation = project.ProjectParticipations.FirstOrDefault(pp => pp.MusicianProfileId.Equals(muproId));
                            return existingParticipation ?? new ProjectParticipation(project, _arpaContext.MusicianProfiles.Find(muproId));
                        })
                        : new List<ProjectParticipation>()
                });
            }

            return new Tuple<IEnumerable<MyProjectGrouping>, int>(result, totalRecordsCount);
        }
    }
}
