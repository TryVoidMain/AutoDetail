using AutoDetail.Core.Interfaces;
using MediatorLight.Interfaces;

namespace AutoDetail.Dtos.Queries.Common
{
    public record GetQuery<T>() : IRequest<IEnumerable<T>> where T : class, IDatabaseEntity;
}
