using Pri.Ca.Core.Interfaces.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Ca.Core.Interfaces.Services
{
    public interface IGameService
    {
        //Get methods
        Task<GamesItemResultModel> GetAllAsync();
        Task<GamesItemResultModel> GetByIdAsync(int id);
        Task<bool> AddAsync(string title,List<int> categoryIds);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(int id, string title,List<int> categoryIds);
        Task<GamesItemResultModel> GetTopSalesAsync();
        Task<int> GetSalesFromIdAsync(int id);
    }
}
