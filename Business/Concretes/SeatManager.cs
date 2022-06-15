using Business.Abstracts;
using Business.Aspects;
using Business.Validation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Result;
using DataAccess.Abstracts;
using Entity.Concretes;
using Entity.Concretes.Dto;
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

        [SecuredOperation("Admin,SuperAdmin")]
        public IDataResult<Seat> Add(Seat seat)
        {
            var data = _seatDal.Add(seat);
            if (data == null)
                return new ErrorDataResult<Seat>(null);
            return new ErrorDataResult<Seat>(data);
        }

        [SecuredOperation("Admin,SuperAdmin")]
        public IResult Delete(Seat seat)
        {
            _seatDal.Delete(seat);
            return new SuccessDataResult<Seat>(null);   
        }

        [SecuredOperation("User,Admin,SuperAdmin")]
        public IDataResult<List<Seat>> GetAll()
        {
            return new SuccessDataResult<List<Seat>>(_seatDal.GetAll());
        }

        [SecuredOperation("User,Admin,SuperAdmin")]
        public IDataResult<Seat> GetById(int id)
        {
            return new SuccessDataResult<Seat>(_seatDal.Get(t => t.Id == id));
        }

        [SecuredOperation("User,Admin,SuperAdmin")]
        public IDataResult<List<SeatDto>> GetBySalonId(int salonId)
        {
            return new SuccessDataResult<List<SeatDto>>(_seatDal.GetAllBySalonID(t => t.SalonId == salonId));
        }

        public IDataResult<List<SeatDto>> GetBySalonId(int salonId, int ticketId)
        {
            return new SuccessDataResult<List<SeatDto>>(_seatDal.GetAllDetailBySalonID(salonId, ticketId));
        }

        [ValidationAspect(typeof(SeatValidator))]
        [SecuredOperation("Admin,SuperAdmin")]
        public IResult Update(Seat seat)
        {
            _seatDal.Update(seat);
            return new SuccessResult("");
        }
    }
}
