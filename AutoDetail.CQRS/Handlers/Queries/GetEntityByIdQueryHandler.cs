using AutoDetail.Core.Interfaces;
using AutoDetail.DAL.Interfaces;
using AutoDetail.Dtos.Queries;
using MediatorLight.Interfaces;

namespace AutoDetail.CQRS.Handlers.Queries
{
    public class GetEntityByIdQueryHandler<TEntity> : IRequestHandler<GetEntityByIdQuery<TEntity>, TEntity> where TEntity : class, IDatabaseEntity
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetEntityByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            ArgumentNullException.ThrowIfNull(unitOfWork, nameof(unitOfWork));

            _unitOfWork = unitOfWork;
        }

        public async Task<TEntity> Handle(GetEntityByIdQuery<TEntity> request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.GetGenericRepository<TEntity>();
            return await repository.GetByIdAsync(request.Id);
        }
    }
}
