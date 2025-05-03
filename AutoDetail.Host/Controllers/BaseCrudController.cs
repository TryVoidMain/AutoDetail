using AutoDetail.Core.Interfaces;
using AutoDetail.Dtos.Commands.Common;
using AutoDetail.Dtos.Queries.Common;
using MapsterMapper;
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
        protected readonly IMapper _mapper;

        public BaseCrudController(
            IMediator mediator,
            IMapper mapper)
        {
            ArgumentNullException.ThrowIfNull(mediator);
            ArgumentNullException.ThrowIfNull(mapper);

            _mediator = mediator;
            _mapper = mapper;
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
            if (ids is not List<Guid> listIds ||
                !listIds.Any())
            {
                return BadRequest();
            }

            var request = new GetEntitiesByIdsQuery<TEntity>(ids);
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpPost()]
        public virtual async Task<IActionResult> Post([FromBody] TDto entity)
        {
            var request = new AddEntityCommand<TEntity>(_mapper.Map<TDto, TEntity>(entity));
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpPut()]
        public virtual IActionResult Put([FromBody] TDto entity)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> DeleteById(Guid id)
        {
            var request = new DeleteEntityByIdCommand<TEntity>(id);
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpDelete("DeleteRange")]
        public virtual async Task<IActionResult> DeleteRange([FromQuery] List<Guid> ids)
        {
            var request = new DeleteEntitiesByIdsCommand<TEntity>(ids);
            var result = await _mediator.Send(request);

            return Ok(result);
        }
    }
}
