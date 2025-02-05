using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Orso.Arpa.Domain.Entities;
using Orso.Arpa.Domain.Interfaces;

namespace Orso.Arpa.Domain.GenericHandlers
{
    public static class Delete
    {
        public interface IDeleteCommand<TEntity> : IRequest where TEntity : BaseEntity
        {
            Guid Id { get; }
        }

        public class Command<TEntity> : IDeleteCommand<TEntity> where TEntity : BaseEntity
        {
            public Guid Id { get; set; }
        }

        public class Handler<TEntity> : IRequestHandler<IDeleteCommand<TEntity>> where TEntity : BaseEntity
        {
            private readonly IArpaContext _arpaContext;

            public Handler(IArpaContext arpaContext)
            {
                _arpaContext = arpaContext;
            }

            public async Task<Unit> Handle(IDeleteCommand<TEntity> request, CancellationToken cancellationToken)
            {
                TEntity entityToDelete = await _arpaContext.FindAsync<TEntity>(new object[] { request.Id }, cancellationToken);

                if (entityToDelete == null)
                {
                    throw new ValidationException(new[]
                    {
                        new ValidationFailure(nameof(request.Id), $"The {typeof(TEntity).Name} could not be found.")
                        {
                            ErrorCode = "404"
                        }
                    });
                }

                _arpaContext.Remove(entityToDelete);

                if (await _arpaContext.SaveChangesAsync(cancellationToken) > 0)
                {
                    _arpaContext.ClearChangeTracker();
                    return Unit.Value;
                }

                throw new Exception($"Problem deleting {typeof(TEntity).Name}");
            }
        }
    }
}
