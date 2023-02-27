using Pri.Ca.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Ca.Core.Services.Models
{
    internal class CategoriesItemResultModel : BaseItemResultModel
    {
        public IEnumerable<Category> Categories { get; set; }
    }
}
