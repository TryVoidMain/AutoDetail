using AutoDetail.Core.Interfaces;
using AutoDetail.Dtos.Queries.Common;
using MediatorLight.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AutoDetail.Host.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(IgnoreApi = false)]
    public class BaseCrudController<TDto, TEntity> : ControllerBase
        where TDto : class
        where TEntity : class, IDatabaseEntity
    {

        protected readonly IMediator _mediator;

        public BaseCrudController(IMediator mediator)
        {
            ArgumentNullException.ThrowIfNull(mediator);

            _mediator = mediator;
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetAll()
        {
            var request = new GetQuery<TEntity>();
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(Guid id)
        {
            var request = new GetEntityByIdQuery<TEntity>(id);
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpGet("GetByIds")]
        public virtual async Task<IActionResult> GetByIds([FromQuery] List<Guid> ids)
        {
            if (ids is not List<Guid> listIds)
            {
                return BadRequest();
            }

            var request = new GetEntitiesByIdsQuery<TEntity>(ids);
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpPost()]
        public virtual IActionResult Post([FromBody] TDto entity)
        {
            return Ok();
        }

        [HttpPut()]
        public virtual IActionResult Put([FromBody] TDto entity)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public virtual IActionResult DeleteById([FromQuery] Guid id)
        {
            return Ok();
        }

        [HttpDelete()]
        public virtual IActionResult DeleteRange([FromQuery] List<Guid> ids)
        {
            return Ok();
        }
    }
}
