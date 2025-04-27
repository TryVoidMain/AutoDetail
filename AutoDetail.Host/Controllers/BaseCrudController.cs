using AutoDetail.Core.Interfaces;
using AutoDetail.Dtos.Queries;
using MediatorLight.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AutoDetail.Host.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseCrudController<TDto, TEntity> : ControllerBase
        where TDto : class
        where TEntity : class, IDatabaseEntity
    {

        private readonly IMediator _mediator;

        public BaseCrudController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromQuery] Guid id)
        {
            var request = new GetEntityByIdQuery<TEntity>(id);
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpPost()]
        public IActionResult Post([FromBody] TDto entity)
        {
            return Ok();
        }

        [HttpPut()]
        public IActionResult Put([FromBody] TDto entity)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromQuery] Guid id)
        {
            return Ok();
        }

        [HttpDelete()]
        public IActionResult DeleteRange([FromQuery] List<Guid> ids)
        {
            return Ok();
        }
    }
}
