using Business.Abstracts;
using Business.Aspects;
using Business.Validation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Result;
using DataAccess.Abstracts;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class BookedSeatManager : IBookedSeatService
    {
        private readonly IBookedSeatDal _bookedSeatDal;


        public BookedSeatManager(IBookedSeatDal bookedSeatDal)
        {
            _bookedSeatDal = bookedSeatDal;
        }

        [ValidationAspect(typeof(BookedSeatValidator))]
        [SecuredOperation("User,Admin,SuperAdmin")]
        public IDataResult<BookedSeat> Add(BookedSeat seat)
        {
            return new SuccessDataResult<BookedSeat>(_bookedSeatDal.Add(seat));
        }

        [SecuredOperation("User,Admin,SuperAdmin")]
        public IResult Delete(BookedSeat seat)
        {
            _bookedSeatDal.Delete(seat);
            return new SuccessResult();
        }

        [SecuredOperation("User,Admin,SuperAdmin")]
        public IDataResult<List<BookedSeat>> GetAll()
        {
            return new SuccessDataResult<List<BookedSeat>>(_bookedSeatDal.GetAll());
        }

        [SecuredOperation("User,Admin,SuperAdmin")]
        public IDataResult<BookedSeat> GetById(int id)
        {
            return new SuccessDataResult<BookedSeat>(_bookedSeatDal.Get(t => t.Id == id));
        }

        [SecuredOperation("User,Admin,SuperAdmin")]
        public IDataResult<BookedSeat> GetByPurchaseId(int purchaseID)
        {
            return new SuccessDataResult<BookedSeat>(_bookedSeatDal.Get(t => t.PurchaseId == purchaseID));
        }

        [SecuredOperation("User,Admin,SuperAdmin")]
        [ValidationAspect(typeof(BookedSeatValidator))]
        public IResult Update(BookedSeat seat)
        {
            _bookedSeatDal.Update(seat);
            return new SuccessResult();
        }
    }
}
