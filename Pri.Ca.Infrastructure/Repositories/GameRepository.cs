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
    public class GameRepository : BaseRepository<Game>, IGameRepository
    {
        public GameRepository(ApplicationDbcontext applicationDbcontext, ILogger<GameRepository> logger) : base(applicationDbcontext, logger)
        {
        }

        public async Task<IEnumerable<Game>> SearchByTitle(string title)
        {
            return await _table.Where(g => g.Name.Contains(title)).ToListAsync();
        }
    }
}
