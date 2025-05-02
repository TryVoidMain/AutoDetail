using AutoDetail.DAL.Interfaces;
using AutoDetail.DAL.Models;
using AutoDetail.Dtos.Dtos;
using MediatorLight.Interfaces;

namespace AutoDetail.Host.Controllers
{
    public class UsersController : BaseCrudController<UserDto, UserDb>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<UserDb> _usersRepository;

        public UsersController(IMediator mediator, IUnitOfWork unitOfWork) : base(mediator)
        {
            ArgumentNullException.ThrowIfNull(unitOfWork);

            _unitOfWork = unitOfWork;
            _usersRepository = unitOfWork.GetGenericRepository<UserDb>();
        }
    }
}
