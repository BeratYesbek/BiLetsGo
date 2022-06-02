using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entity.Concretes.Dto
{
    public class TicketReadDto : IDto
    {
        public Ticket Ticket { get; set; }

        public Category Category { get; set; }

        public Salon Salon { get; set; }

        public List<Seat> Seats { get; set; }

        public List<string> Images { get; set; }

    }
}
