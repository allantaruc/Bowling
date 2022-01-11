﻿using Bowling.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bowling.Data
{
    public interface IGameRepo
    {
        Task CreateAsync(Game game);
        Task DeleteAsync(int id);
        Task<Game> GetGameAsync(int id);
        Task<List<Game>> GetGamesAsync();
        Task UpdateAsync(Game game);
        


        Task CreateShotAsync(Shot shot);
        Task DeleteShotAsync(int gameId, int id);
        Task<List<Shot>> GetAllShotsAsync(int gameId);
        Task<Shot> GetShotAsync(int gameId, int id);
        Task UpdateShotAsync(Shot shot);
    }
}