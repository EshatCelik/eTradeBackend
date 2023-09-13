﻿using eTradeBackend.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Domain.Entities
{
    public class Menu:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<EndPoint> Endpoints { get; set; }
    }
}
