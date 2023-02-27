using Pri.Ca.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Ca.Core.Services.Models
{
    public class GamesItemResultModel : BaseItemResultModel
    {
        //ienumerable of games
        public IEnumerable<Game> Games { get; set; }
    }
}
