using Pri.Ca.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Ca.Core.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        //define the cruds
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(int id);
        Task<bool> AddAsync(Category Category);
        Task<bool> UpdateAsync(Category Category);
        Task<bool> DeleteAsync(int id);
        IQueryable<Category> GetAll();
    }
}
