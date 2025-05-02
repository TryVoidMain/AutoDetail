using AutoDetail.Core.Interfaces;
using AutoDetail.DAL.Interfaces;
using AutoDetail.Dtos.Queries;
using MediatorLight.Interfaces;

namespace AutoDetail.CQRS.Handlers.Queries
{
    public class GetQueryHandler<T> : IRequestHandler<GetQuery<T>, IEnumerable<T>> where T : class, IDatabaseEntity
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetQueryHandler(IUnitOfWork unitOfWork)
        {
            ArgumentNullException.ThrowIfNull(unitOfWork);

            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<T>> Handle(GetQuery<T> request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.GetGenericRepository<T>();
            return await repository.GetAll();
        }
    }
}
