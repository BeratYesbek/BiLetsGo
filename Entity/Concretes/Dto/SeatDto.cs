using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concretes.Dto
{
    public class SeatDto : IDto
    {
        public int Id { get; set; }

        public int SeatNumber { get; set; }

        public int SalonId { get; set; }

        public bool IsBooked { get; set; }

    }
}
