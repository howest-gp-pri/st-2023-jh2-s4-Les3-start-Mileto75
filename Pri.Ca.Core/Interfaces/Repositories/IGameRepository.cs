using Pri.Ca.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Ca.Core.Interfaces.Repositories
{
    public interface IGameRepository
    {
        //define the cruds
        Task<IEnumerable<Game>> GetAllAsync();
        Task<Game> GetById(int id);
        Task<bool> Add(Game game);
        Task<bool> Update(Game game);
        Task<bool> Delete(int id);
    }
}
