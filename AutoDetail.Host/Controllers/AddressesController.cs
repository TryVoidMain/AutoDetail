using AutoDetail.DAL.Models;
using AutoDetail.Dtos.Dtos;
using MapsterMapper;
using MediatorLight.Interfaces;

namespace AutoDetail.Host.Controllers
{
    public class AddressesController : BaseCrudController<AddressDto, AddressDb>
    {
        public AddressesController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }
    }
}
