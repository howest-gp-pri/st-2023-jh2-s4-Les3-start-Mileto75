﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Ca.Core.Entities
{
    public class Game : BaseEntity
    {
        public ICollection<Category> Categories { get; set; }
        public ICollection<Sale> Sales { get; set; }
    }
}
