﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entity.Concretes
{
    public class Category : IEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

    }
}
