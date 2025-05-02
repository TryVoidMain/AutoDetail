using AutoDetail.Core.Interfaces;
using MediatorLight.Interfaces;

namespace AutoDetail.Dtos.Queries.Common
{
    public record GetEntityByIdQuery<TEntity>(Guid Id) : IRequest<TEntity> where TEntity : IDatabaseEntity;
}
