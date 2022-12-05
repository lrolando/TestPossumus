using Microsoft.AspNetCore.Mvc;
using TestPossumus.UnitOfWork;
using TestPossumus.UnitOfWork.Repository;

namespace TestPossumus.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmpleoController : Controller
    {
        readonly IRepository<Empleo> itemService;

        public EmpleoController(IRepository<Empleo> _itemService)
        {
            itemService = _itemService;
        }


        [HttpGet]
        public async Task<ActionResult<List<Empleo>>> Get()
        {
            return Ok(await itemService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Empleo>> GetById(int id)
        {
            var item = await itemService.GetById(id);
            if (item == null)
                return BadRequest("Employ not found.");
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<List<Empleo>>> Add(Empleo item)
        {
            await itemService.Add(item);

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<List<Empleo>>> Update(Empleo item)
        {
            itemService.Update(item);

            return Ok();
        }

        //public async Task<ActionResult<List<Item>>> Delete([FromBody] int id)

        [HttpDelete]
        public async Task<ActionResult<List<Empleo>>> Delete(Empleo id)
        {
            itemService.Delete(id);

            return Ok();
        }
    }

}
