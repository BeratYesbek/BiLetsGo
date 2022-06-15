using Core.DataAccess;
using Entity.Concretes;
using Entity.Concretes.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    public interface ISeatDal : IEntityRepository<Seat> 
    {
        List<SeatDto> GetAllBySalonID(Expression<Func<Seat, bool>> filter);

        List<SeatDto> GetAllDetailBySalonID(int salonId, int ticketId);
    }
}
