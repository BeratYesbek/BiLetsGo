using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concretes.Dto
{
    public class TicketOrderDto
    {
        public Ticket Ticket { get; set; }

        public Category Category { get; set; }

        public Salon Salon { get; set; }

        public List<Seat> Seats { get; set; }

        public List<string> Images { get; set; }

        public BookedSeat bookedSeat { get; set; }

        public Purchase purchase { get; set; }

    }
}
