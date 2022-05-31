using Core.Entities;
using Core.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concretes
{
    public class Payment : IEntity
    {
        public int Id { get; set; }

        public string CardNumber { get; set; }

        public string NameOnTheCard { get; set; }

        public string CardName { get; set; }

        public int Year { get; set; }

        public int Month { get; set; }

        public int Cvv { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

    }
}
