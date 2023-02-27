using Pri.Ca.Core.Entities;
using Pri.Ca.Core.Interfaces.Repositories;
using Pri.Ca.Core.Interfaces.Services;
using Pri.Ca.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Ca.Core.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public Task<GamesItemResultModel> AddAsync(string title, List<int> categoryIds)
        {
            throw new NotImplementedException();
        }

        public Task<GamesItemResultModel> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<GamesItemResultModel> GetAllAsync()
        {
            var gamesItemResultModel = new GamesItemResultModel();
            var games = await _gameRepository.GetAllAsync();
            //validation
            if (games.Count() == 0)
            {
                gamesItemResultModel.Issuccess = false;
                gamesItemResultModel.ValidationErrors
                    = new List<ValidationResult>
                    {
                        new ValidationResult("No Games in database!")
                    };
                return gamesItemResultModel;
            }
            gamesItemResultModel.Issuccess = true;
            gamesItemResultModel.Games = games;
            return gamesItemResultModel;
        }

        

        public async Task<GamesItemResultModel> GetByIdAsync(int id)
        {
            var gamesItemResultModel = new GamesItemResultModel();
            var game = await _gameRepository.GetByIdAsync(id);
            //validation
            if(game == null) 
            {
                gamesItemResultModel.Issuccess = false;
                gamesItemResultModel.ValidationErrors = new List<ValidationResult>
                {
                    new ValidationResult("Game not found!")
                };
                return gamesItemResultModel;
            }
            gamesItemResultModel.Issuccess = true;
            gamesItemResultModel.Games = new List<Game> { game };
            return gamesItemResultModel;
        }

        public Task<GamesItemResultModel> UpdateAsync(int id, string title, List<int> categoryIds)
        {
            throw new NotImplementedException();
        }
    }
}
