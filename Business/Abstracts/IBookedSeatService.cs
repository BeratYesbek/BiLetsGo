using Core.Utilities.Result;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IBookedSeatService
    {
        IDataResult<BookedSeat> Add(BookedSeat seat);

        IResult Update(BookedSeat seat);

        IResult Delete(BookedSeat seat);

        IDataResult<BookedSeat> GetById(int id);

        IDataResult<List<BookedSeat>> GetAll();
    }
}
