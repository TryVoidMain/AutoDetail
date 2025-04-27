using AutoDetail.DAL.Models;
using AutoDetail.Dtos.Dtos;
using MediatorLight.Interfaces;

namespace AutoDetail.Host.Controllers
{
    public class UsersController(IMediator mediator) : BaseCrudController<UserDto, UserDb>(mediator)
    {
    }
}
