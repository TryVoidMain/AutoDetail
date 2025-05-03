using AutoDetail.Core.Interfaces;
using AutoDetail.DAL.Interfaces;
using AutoDetail.Dtos.Commands.Common;
using MediatorLight.Interfaces;

namespace AutoDetail.CQRS.Handlers.Commands
{
    public class DeleteEntitiesByIdsCommandHandler<T> : IRequestHandler<DeleteEntityByIdCommand<T>, bool> where T : class, IDatabaseEntity
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteEntitiesByIdsCommandHandler(IUnitOfWork unitOfWork)
        {
            ArgumentNullException.ThrowIfNull(unitOfWork);
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteEntityByIdCommand<T> request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.GetGenericRepository<T>();
            var entity = await repo.GetByIdAsync(request.Id);

            _unitOfWork.Delete(entity);
            await _unitOfWork.SaveAsync();

            return true;
        }
    }
}
