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
    public class CategoryRepository : ICategoryRepository
    {
        //database context
        private readonly ApplicationDbcontext _applicationDbcontext;
        private ILogger<CategoryRepository> _logger;

        public CategoryRepository(ApplicationDbcontext applicationDbcontext, ILogger<CategoryRepository> logger)
        {
            _applicationDbcontext = applicationDbcontext;
            _logger = logger;
        }

        public async Task<bool> Add(Category Category)
        {
            await _applicationDbcontext.Categories.AddAsync(Category);
            return await Save();
        }

        public async Task<bool> Delete(int id)
        {
            var Category = await GetById(id);
            _applicationDbcontext.Categories.Remove(Category);
            return await Save();
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _applicationDbcontext
                .Categories
                .Include(c => c.Games)
                .ToListAsync();
        }

        public async Task<Category> GetById(int id)
        {
            return await _applicationDbcontext
                .Categories
                .Include(c => c.Games)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> Update(Category Category)
        {
            _applicationDbcontext.Categories.Update(Category);
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
