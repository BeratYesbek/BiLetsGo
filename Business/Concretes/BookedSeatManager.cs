using Business.Abstracts;
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

        public IDataResult<BookedSeat> Add(BookedSeat seat)
        {
            return new SuccessDataResult<BookedSeat>(_bookedSeatDal.Add(seat));
        }

        public IResult Delete(BookedSeat seat)
        {
            _bookedSeatDal.Delete(seat);
            return new SuccessResult();
        }

        public IDataResult<List<BookedSeat>> GetAll()
        {
            return new SuccessDataResult<List<BookedSeat>>(_bookedSeatDal.GetAll());
        }

        public IDataResult<BookedSeat> GetById(int id)
        {
            return new SuccessDataResult<BookedSeat>(_bookedSeatDal.Get(t => t.Id == id));
        }

        public IDataResult<BookedSeat> GetByPurchaseId(int purchaseID)
        {
            return new SuccessDataResult<BookedSeat>(_bookedSeatDal.Get(t => t.PurchaseId == purchaseID));
        }

        public IResult Update(BookedSeat seat)
        {
            _bookedSeatDal.Update(seat);
            return new SuccessResult();
        }
    }
}
