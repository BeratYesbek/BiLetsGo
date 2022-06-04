using Core.DataAccess;
using DataAccess.Abstracts;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes
{
    public class EfBookedSeatDal : EfEntityRepositoryBase<BookedSeat,AppDbContext>, IBookedSeatDal
    {
    }
}
