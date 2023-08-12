﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class City
    {
        public City()
        {
            News = new();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public HashSet<News> News { get; set; }
    }
}
