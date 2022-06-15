using Core.DataAccess;
using DataAccess.Abstracts;
using Entity.Concretes;
using Entity.Concretes.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes
{
    public class EfSeatDal : EfEntityRepositoryBase<Seat, AppDbContext>, ISeatDal
    {
        public List<SeatDto> GetAllBySalonID(Expression<Func<Seat, bool>> filter)
        {
            using (var context = new AppDbContext())
            {
                var result = from seat in context.Seats.Where(filter)
                             select new SeatDto
                             {
                                 Id = seat.Id,
                                 SalonId = seat.SalonId,
                                 SeatNumber = seat.SeatNumber,
                                 IsBooked = (from booked in context.BookedSeats where seat.Id == booked.SeatId select booked).Any()
                             };
                return result.ToList();
            }
        }

    }
}
