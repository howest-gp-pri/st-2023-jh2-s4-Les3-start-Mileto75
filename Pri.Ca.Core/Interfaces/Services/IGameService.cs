﻿using Pri.Ca.Core.Entities;
using Pri.Ca.Core.Services.Models;
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
        Task<GamesItemResultModel<Game>> GetAllAsync();
        Task<GamesItemResultModel<Game>> GetByIdAsync(int id);
        Task<GamesItemResultModel<Game>> AddAsync(string title,List<int> categoryIds);
        Task<GamesItemResultModel<Game>> DeleteAsync(int id);
        Task<GamesItemResultModel<Game>> UpdateAsync(int id, string title,List<int> categoryIds);
    }
}
