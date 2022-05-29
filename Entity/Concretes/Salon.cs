using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concretes
{
    public class Salon : IEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string SalonNumber { get; set; }

        private ICollection<Seat> _Seats;

  /*      public virtual ICollection<Seat> Seats
        {
            get 
            {
                Name = "BOŞŞŞŞŞŞŞŞŞŞŞŞ";
                return _Seats;
                  
            } 
            set 
            { 
                _Seats = value;
            } 
        }*/

        public virtual ICollection<Ticket> Tickets { get; set; }

        
        
    }
}
