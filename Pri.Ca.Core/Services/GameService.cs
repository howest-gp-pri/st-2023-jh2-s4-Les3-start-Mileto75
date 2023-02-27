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
        private readonly ICategoryRepository _categoryRepository;

        public GameService(IGameRepository gameRepository, ICategoryRepository categoryRepository)
        {
            _gameRepository = gameRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<GamesItemResultModel> AddAsync(string title, List<int> categoryIds)
        {
            //check if title exists
            var games = await _gameRepository.GetAllAsync();
            if(games.Any(g => g.Name.Contains(title)))
            {
                //game exists error
                return new GamesItemResultModel
                {
                    ValidationErrors = new List<ValidationResult>
                    { new ValidationResult("Title exists!") }
                };
            }
            var game = new Game 
            {
                Name = title,
                Categories = _categoryRepository.GetAll()
                .Where(c => categoryIds.Contains(c.Id)).ToList()
            };
            //add to database
            if(!await _gameRepository.AddAsync(game))
            {
                return new GamesItemResultModel
                {
                    ValidationErrors = new List<ValidationResult>
                    { new ValidationResult("Something went wrong...") }
                };
            }
            //game saved
            return new GamesItemResultModel
            {
                Issuccess = true,
            };
        }

        public async Task<GamesItemResultModel> DeleteAsync(int id)
        {
            //check if game exists
            var game = await _gameRepository.GetByIdAsync(id);
            if (game == null)
            {
                return new GamesItemResultModel
                {
                    ValidationErrors = new List<ValidationResult>
                    {
                        new ValidationResult("Game not found!")
                    }
                };
            }
            //safely delete
            if(!await _gameRepository.DeleteAsync(game.Id))
            {
                //check if game exists
                return new GamesItemResultModel
                {
                        ValidationErrors = new List<ValidationResult>
                {new ValidationResult("Something went wrong...")}
                };
            }
            //delete success
            return new GamesItemResultModel { Issuccess = true };
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

        public async Task<GamesItemResultModel> UpdateAsync(int id, string title, List<int> categoryIds)
        {
            //check if game exists
            var game = await _gameRepository.GetByIdAsync(id);
            if(game == null) 
            {
                return new GamesItemResultModel
                {
                    ValidationErrors = new List<ValidationResult>
                    {
                        new ValidationResult("Game not found!")
                    }
                };
            }
            //update the game
            game.Name = title;
            game.Categories = _categoryRepository.GetAll()
                .Where(c => categoryIds.Contains(c.Id)).ToList();
            //save to database
            if(!await _gameRepository.UpdateAsync(game))
            {
                return new GamesItemResultModel
                {
                    ValidationErrors = new List<ValidationResult>
                    {
                        new ValidationResult("something went wrong...")
                    }
                };
            }
            return new GamesItemResultModel { Issuccess = true };
        }
    }
}
