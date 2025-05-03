using AutoDetail.Core.Interfaces;
using AutoDetail.DAL.Interfaces;
using AutoDetail.Dtos.Commands.Common;
using MediatorLight.Interfaces;

namespace AutoDetail.CQRS.Handlers.Commands
{
    public class DeleteEntityByIdCommandHandler<T> : IRequestHandler<DeleteEntitiesByIdsCommand<T>, bool> where T : class, IDatabaseEntity
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteEntityByIdCommandHandler(IUnitOfWork unitOfWork)
        {
            ArgumentNullException.ThrowIfNull(unitOfWork);

            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteEntitiesByIdsCommand<T> request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.GetGenericRepository<T>();
            var ids = request.Ids;

            var entities = await repo.GetWhereToListAsync(x => ids.Contains(x.Id));

            _unitOfWork.DeleteRange(entities);
            await _unitOfWork.SaveAsync();

            return true;
        }
    }
}
