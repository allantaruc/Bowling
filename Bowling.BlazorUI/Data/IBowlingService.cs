using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bowling.BlazorUI.Data
{
    interface IBowlingService
    {
        Task<List<Game>> GetGames();
        Game GetGame(int Id);

        void UpdateGame(Game game);
        void AddGame(Game game);
        void DeleteGame(int id);
    }
}
