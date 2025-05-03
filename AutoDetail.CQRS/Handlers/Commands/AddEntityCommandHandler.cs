using AutoDetail.Core.Interfaces;
using AutoDetail.DAL.Interfaces;
using AutoDetail.Dtos.Commands.Common;
using MediatorLight.Interfaces;

namespace AutoDetail.CQRS.Handlers.Commands
{
    public class AddEntityCommandHandler<T> : IRequestHandler<AddEntityCommand<T>, bool> where T : class, IDatabaseEntity
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddEntityCommandHandler(IUnitOfWork unitOfWork)
        {
            ArgumentNullException.ThrowIfNull(unitOfWork);
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(AddEntityCommand<T> request, CancellationToken cancellationToken)
        {
            var entity = request.Entity;
            entity.Id = Guid.NewGuid();
            entity.CreatedAt = DateTime.Now;

            await _unitOfWork.AddAsync(request.Entity);
            await _unitOfWork.SaveAsync();

            return true;
        }
    }
}
