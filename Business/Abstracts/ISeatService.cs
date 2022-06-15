using Core.Utilities.Result;
using Entity.Concretes;
using Entity.Concretes.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ISeatService
    {
        IDataResult<Seat> Add(Seat seat);

        IResult Update(Seat seat);

        IResult Delete(Seat seat);

        IDataResult<Seat> GetById(int id);

        IDataResult<List<SeatDto>> GetBySalonId(int salonId);

        IDataResult<List<SeatDto>> GetBySalonId(int salonId,int ticketId);


        IDataResult<List<Seat>> GetAll();
    }
}
