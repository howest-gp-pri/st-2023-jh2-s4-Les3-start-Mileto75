﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Ca.Core.Entities
{
    public class Category : BaseEntity
    {
        public ICollection<Game> Games { get; set; }
    }
}
