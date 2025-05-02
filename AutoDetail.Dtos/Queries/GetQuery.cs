using AutoDetail.Core.Interfaces;
using MediatorLight.Interfaces;

namespace AutoDetail.Dtos.Queries
{
    public record GetQuery<T>() : IRequest<IEnumerable<T>> where T : class, IDatabaseEntity;
}
