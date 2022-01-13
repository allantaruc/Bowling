using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Net.Http;
using System.Net.Http.Json;
using System;

namespace Bowling.BlazorUI.Data
{
    public class BowlingService : IBowlingService
    {
        private readonly HttpClient _client;

        public BowlingService()
        {
            _client = new HttpClient {
                //BaseAddress = new Uri("http://localhost:5001/")
                BaseAddress = new Uri("http://bowlingapi-dev.us-east-2.elasticbeanstalk.com")
            };
        }

        List<Game> _games = new List<Game> {
                new Game { Id = 1, Name = "Game1" },
                new Game { Id = 2, Name = "Game2" },
                new Game { Id = 3, Name = "Game3" }
            };

        public void AddGame(Game game)
        {
            //var games = GetGames().Result;
            game.Id = _games.Count + 1;
            
            var result = _client.PostAsJsonAsync("api/bowling", new Domain.Game
            {
                Id = game.Id,
                Name = game.Name
            });

            //result.Result.Content

        }

        public void DeleteGame(int id)
        {
            var game = GetGame(id);
            _games.Remove(game);
            _client.DeleteAsync($"api/bowling/{id}");
        }

        public Game GetGame(int Id)
        {
            return _games.SingleOrDefault(game => game.Id == Id);
        }

        public async Task<List<Game>> GetGames()
        {
            List<Game> games = new List<Game>();
            var result = await _client.GetFromJsonAsync<List<Domain.Game>>("api/bowling");

            foreach (var game in result)
            {
                games.Add(new Game
                {
                    Id = game.Id,
                    Name = game.Name
                });
            }

            _games = games;
            
            return games;
        }

        public void UpdateGame(Game game)
        {
            var toUpdate = GetGame(game.Id);
            toUpdate.Name = game.Name;
        }
    }
}
