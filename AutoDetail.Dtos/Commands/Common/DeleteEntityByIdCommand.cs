using AutoDetail.Core.Interfaces;
using MediatorLight.Interfaces;

namespace AutoDetail.Dtos.Commands.Common
{
    public record DeleteEntityByIdCommand<T>(Guid Id) : IRequest<bool> where T : class, IDatabaseEntity;
}
