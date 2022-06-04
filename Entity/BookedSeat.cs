using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class BookedSeat : IEntity
    {
        public int Id { get; set; }

        public int SeatId { get; set; }

        public int UserId { get; set; }

        public int TicketId { get; set; }

        public int PurchaseId { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
