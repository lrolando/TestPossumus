using Microsoft.AspNetCore.Mvc;
using TestPossumus.UnitOfWork;
using TestPossumus.UnitOfWork.Repository;

namespace TestPossumus.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CandidatoController : Controller
    {

        readonly IRepository<Candidato> itemService;

        public CandidatoController(IRepository<Candidato> _itemService)
        {
            itemService = _itemService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Candidato>>> GetAll()
        {
            return Ok(await itemService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Candidato>> GetById(int id)
        {
            var item = await itemService.GetById(id);
            if (item == null)
                return BadRequest("Item not found.");
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<List<Candidato>>> Add(Candidato item)
        {
            await itemService.Add(item);

            return Ok(await itemService.GetAll());
        }

        [HttpPut]
        public async Task<ActionResult<List<Candidato>>> UpdateItem(Candidato item)
        {
            itemService.Update(item);

            return Ok(await itemService.GetAll());
        }

        [HttpDelete]
        public async Task<ActionResult<List<Candidato>>> Delete(Candidato id)
        {
            itemService.Delete(id);

            return Ok(await itemService.GetAll());
        }

    }
}
