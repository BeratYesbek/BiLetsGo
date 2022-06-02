using Core.Entities;
using Core.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concretes
{
    public class Purchase : IEntity
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public string SocialIdentity { get; set; }

        public string Phone { get; set; }

        public int UserId { get; set; }

        public int PaymentId  { get; set; }

        public int TicketId { get; set; }

    }
}
