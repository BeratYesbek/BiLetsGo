using Core.DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    public interface IBookedSeatDal : IEntityRepository<BookedSeat>
    {
    }
}
