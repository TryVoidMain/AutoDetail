using AutoDetail.DAL.Models;
using AutoDetail.Dtos.Dtos;
using MapsterMapper;
using MediatorLight.Interfaces;

namespace AutoDetail.Host.Controllers
{
    public class UsersController : BaseCrudController<UserDto, UserDb>
    {
        public UsersController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }
    }
}
