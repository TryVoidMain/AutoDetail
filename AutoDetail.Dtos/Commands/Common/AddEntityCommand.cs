using AutoDetail.Core.Interfaces;
using MediatorLight.Interfaces;

namespace AutoDetail.Dtos.Commands.Common
{
    public record AddEntityCommand<T>(T Entity) : IRequest<bool> where T : class, IDatabaseEntity;
}
