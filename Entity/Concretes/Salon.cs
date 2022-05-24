using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concretes
{
    public class Salon : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string SalonNumber { get; set; }
    }
}
