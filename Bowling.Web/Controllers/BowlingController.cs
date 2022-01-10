using Bowling.Data;
using Bowling.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Bowling.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BowlingController : ControllerBase
    {
        readonly IGameRepo _gameRepo;
        public BowlingController()
        {
            _gameRepo = new GameRepo();
        }
        [HttpGet]
        public async Task<ActionResult<Game>> GetAll()
        {
            return new OkObjectResult(await _gameRepo.GetGamesAsync());
        }

        [HttpPost]
        public async Task<ActionResult> Create(Game game)
        {
            await _gameRepo.CreateAsync(game);
            return new OkResult();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _gameRepo.DeleteAsync(id);
            return new OkResult();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> Get(int id)
        {
            return await _gameRepo.GetGameAsync(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Game game)
        {
            game.Id = id;
            await _gameRepo.UpdateAsync(game);
            return new OkResult();
        }
    }
}
