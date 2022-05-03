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

        public TicketFile TicketFile { get; set; }
    }
}
