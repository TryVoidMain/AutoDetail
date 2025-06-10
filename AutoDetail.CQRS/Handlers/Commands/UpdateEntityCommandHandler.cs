using AutoDetail.Core.Interfaces;
using AutoDetail.DAL.Interfaces;
using AutoDetail.Dtos.Commands.Common;
using MediatorLight.Interfaces;

namespace AutoDetail.CQRS.Handlers.Commands
{
    public class UpdateEntityCommandHandler<T> : IRequestHandler<UpdateEntityCommand<T>, bool> where T : class, IDatabaseEntity
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateEntityCommandHandler(IUnitOfWork unitOfWork)
        {
            ArgumentNullException.ThrowIfNull(unitOfWork);

            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateEntityCommand<T> request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.GetGenericRepository<T>();
            Guid entityId = request.Entity.Id;
            var entity = await repo.FirstOrDefaultAsync(x => x.Id == entityId);
            entity = request.Entity;
            ArgumentNullException.ThrowIfNull(entity);

            _unitOfWork.Update(entity);
            await _unitOfWork.SaveAsync();
            return true;
        }
    }
}
