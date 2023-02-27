using Pri.Ca.Core.Entities;
using Pri.Ca.Core.Interfaces.Repositories;
using Pri.Ca.Core.Interfaces.Services;
using Pri.Ca.Core.Interfaces.Services.Models;
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
        private readonly ICategoryRepository _categoryRepository;


        public GameService(IGameRepository gameRepository, ICategoryRepository categoryRepository)
        {
            _gameRepository = gameRepository;
            _categoryRepository = categoryRepository;
        }

        public Task<bool> AddAsync(string title, List<int> categoryIds)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
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
            var game = await _gameRepository.GetById(id);
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

        public async Task<int> GetSalesFromIdAsync(int id)
        {
            var sales = await _gameRepository.GetById(id);
            if(sales != null)
            {
                return sales.Sales.Sum(s => s.Quantity);
            }
            return 0;
        }

        public async Task<GamesItemResultModel> GetTopSalesAsync()
        {
            var sales = await _gameRepository.GetAllAsync();
            var grouped = sales.GroupBy(s => s.Sales.Sum(s => s.Quantity));
            return new GamesItemResultModel();
        }

        public async Task<bool> UpdateAsync(int id, string title, List<int> categoryIds)
        {
            var game = await _gameRepository.GetById(id);
            if(game != null) 
            {
                return false;
            }
            game.Name = title;
            var categories = await _categoryRepository.GetAllAsync();
            game.Categories = categories.Where(c => categoryIds.Contains(c.Id)).ToList();
            return await _gameRepository.Update(game);
        }
    }
}
