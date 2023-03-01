using Pri.Ca.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Ca.Core.Services.Models
{
    public class GamesItemResultModel<T> : BaseItemResultModel
    {
        //ienumerable of games
        public IEnumerable<T> Games { get; set; }
    }
}
