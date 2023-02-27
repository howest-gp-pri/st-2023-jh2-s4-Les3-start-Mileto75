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
        Task<Category> GetById(int id);
        Task<bool> Add(Category Category);
        Task<bool> Update(Category Category);
        Task<bool> Delete(int id);
    }
}
