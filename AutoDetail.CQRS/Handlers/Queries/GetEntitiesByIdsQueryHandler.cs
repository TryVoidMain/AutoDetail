using AutoDetail.Core.Interfaces;
using AutoDetail.DAL.Interfaces;
using AutoDetail.Dtos.Queries.Common;
using MediatorLight.Interfaces;

namespace AutoDetail.CQRS.Handlers.Queries
{
    public class GetEntitiesByIdsQueryHandler<T> : IRequestHandler<GetEntitiesByIdsQuery<T>, IEnumerable<T>> where T : class, IDatabaseEntity
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetEntitiesByIdsQueryHandler(IUnitOfWork unitOfWork)
        {
            ArgumentNullException.ThrowIfNull(unitOfWork);

            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<T>> Handle(GetEntitiesByIdsQuery<T> request, CancellationToken cancellationToken)
        {
            var ids = request.Ids;
            var repository = _unitOfWork.GetGenericRepository<T>();
            return await repository.GetWhereToListAsync(x => ids.Contains(x.Id));
        }
    }
}
