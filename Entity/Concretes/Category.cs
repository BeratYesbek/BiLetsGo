﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entity.Concretes
{
    public class Category : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
