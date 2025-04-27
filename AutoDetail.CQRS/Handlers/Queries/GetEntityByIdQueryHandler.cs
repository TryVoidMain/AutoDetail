using AutoDetail.Core.Interfaces;
using AutoDetail.Dtos.Queries;
using MediatorLight.Interfaces;

namespace AutoDetail.CQRS.Handlers.Queries
{
    public class GetEntityByIdQueryHandler<TEntity> : IRequestHandler<GetEntityByIdQuery<TEntity>, TEntity> where TEntity : IDatabaseEntity
    {
        public GetEntityByIdQueryHandler()
        {

        }

        public Task<TEntity> Handle(GetEntityByIdQuery<TEntity> request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
