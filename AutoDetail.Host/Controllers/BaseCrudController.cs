using AutoDetail.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AutoDetail.Host.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseCrudController<TDto, TEntity> : ControllerBase
        where TDto : class
        where TEntity : class, IDatabaseEntity
    {
        [HttpGet()]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromQuery] Guid id)
        {
            return Ok();
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
