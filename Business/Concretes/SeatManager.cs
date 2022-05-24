using Business.Abstracts;
using Core.Utilities.Result;
using DataAccess.Abstracts;
using Entity.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class SeatManager : ISeatService
    {

        private readonly ISeatDal _seatDal; 
        public SeatManager(ISeatDal seatDal)
        {
            _seatDal = seatDal;
        }

        public IDataResult<Seat> Add(Seat seat)
        {
            var data = _seatDal.Add(seat);
            if (data == null)
                return new ErrorDataResult<Seat>(null);
            return new ErrorDataResult<Seat>(data);
        }

        public IResult Delete(Seat seat)
        {
            _seatDal.Delete(seat);
            return new SuccessDataResult<Seat>(null);   
        }

        public IDataResult<List<Seat>> GetAll()
        {
            return new SuccessDataResult<List<Seat>>(_seatDal.GetAll());
        }

        public IDataResult<Seat> GetById(int id)
        {
            return new SuccessDataResult<Seat>(_seatDal.Get(t => t.Id == id));
        }

        public IDataResult<List<Seat>> GetBySalonId(int salonId)
        {
            return new SuccessDataResult<List<Seat>>(_seatDal.GetAll(t => t.SalonId == salonId));
        }

        public IResult Update(Seat seat)
        {
            _seatDal.Update(seat);
            return new SuccessResult("");
        }
    }
}
