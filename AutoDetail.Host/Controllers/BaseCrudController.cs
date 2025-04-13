using Microsoft.AspNetCore.Mvc;

namespace AutoDetail.Host.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseCrudController<T> : ControllerBase where T : class
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
        public IActionResult Post([FromBody] T entity)
        {
            return Ok();
        }

        [HttpPut()]
        public IActionResult Put([FromBody] T entity)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromQuery] Guid id)
        {
            return Ok();
        }

        [HttpDelete()]
        public IActionResult DeleteRange([FromBody] List<Guid> ids)
        {
            return Ok();
        }
    }
}
