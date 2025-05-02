using AutoDetail.Core.Interfaces;
using MediatorLight.Interfaces;

namespace AutoDetail.Dtos.Queries.Common
{
    public record GetEntitiesByIdsQuery<T>(List<Guid> Ids) : IRequest<IEnumerable<T>> where T : class, IDatabaseEntity;
}
