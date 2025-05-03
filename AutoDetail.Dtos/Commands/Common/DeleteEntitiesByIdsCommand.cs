using AutoDetail.Core.Interfaces;
using MediatorLight.Interfaces;

namespace AutoDetail.Dtos.Commands.Common
{
    public record DeleteEntitiesByIdsCommand<T>(List<Guid> Ids) : IRequest<bool> where T : class, IDatabaseEntity;
}
