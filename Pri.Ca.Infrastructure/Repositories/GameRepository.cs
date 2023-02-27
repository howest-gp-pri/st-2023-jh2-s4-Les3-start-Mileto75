using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pri.Ca.Core.Entities;
using Pri.Ca.Core.Interfaces.Repositories;
using Pri.Ca.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Ca.Infrastructure.Repositories
{
    public class GameRepository : IGameRepository
    {
        //database context
        private readonly ApplicationDbcontext _applicationDbcontext;
        private ILogger<GameRepository> _logger;

        public GameRepository(ApplicationDbcontext applicationDbcontext, ILogger<GameRepository> logger)
        {
            _applicationDbcontext = applicationDbcontext;
            _logger = logger;
        }

        public async Task<bool> AddAsync(Game game)
        {
            await _applicationDbcontext.Games.AddAsync(game);
            return await Save();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var game = await GetByIdAsync(id);
            _applicationDbcontext.Games.Remove(game);
            return await Save();
        }

        public async Task<IEnumerable<Game>> GetAllAsync()
        {
            return await _applicationDbcontext
                .Games
                .Include(g => g.Categories)
                .ToListAsync();
        }

        public async Task<Game> GetByIdAsync(int id)
        {
            return await _applicationDbcontext
                .Games
                .Include(g => g.Categories)
                .FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<bool> UpdateAsync(Game game)
        {
            _applicationDbcontext.Games.Update(game);
            return await Save();
        }
        private async Task<bool> Save()
        {
            try
            {
                await _applicationDbcontext.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException dbUpdateException)
            {
                //log the error
                _logger.LogError(dbUpdateException.Message);
                return false;
            }
        }
    }
}
