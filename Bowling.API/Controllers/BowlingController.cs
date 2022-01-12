using Bowling.Data;
using Bowling.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

        #region Game
        [HttpGet]
        public async Task<ActionResult<IList<Game>>> GetAll()
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

        #endregion

        #region shots
        [HttpPost("{gameId}/shots")]
        public async Task<ActionResult<Shot>> CreateShot(int gameId, Shot shot)
        {
            shot.GameId = gameId;
            await _gameRepo.CreateShotAsync(shot);
            return new OkObjectResult(shot);
        }

        [HttpDelete("{gameId}/shots/{id}")]
        public async Task<ActionResult> DeleteShot(int gameId, int id)
        {
            await _gameRepo.DeleteShotAsync(gameId, id);
            return new OkResult();
        }

        [HttpGet("{gameId}/shots/{id}")]
        public async Task<ActionResult<Shot>> GetShot(int gameId, int id)
        {
            return new OkObjectResult(await _gameRepo.GetShotAsync(gameId, id));

        }

        [HttpGet("{gameId}/shots")]
        public async Task<ActionResult<IList<Shot>>> GetAllShots(int gameId)
        {
            return new OkObjectResult(await _gameRepo.GetAllShotsAsync(gameId));
        }

        [HttpPut("{gameId}/shots/{id}")]
        public async Task<ActionResult<Shot>> UpdateShot(int gameId, int id, Shot shot)
        {
            shot.GameId = gameId;
            shot.Id = id;
            await _gameRepo.UpdateShotAsync(shot);
            return new OkObjectResult(shot);
        }
        #endregion
    }
}
