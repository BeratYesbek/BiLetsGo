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
        private readonly ITicketService _ticketService;


        public BookedSeatManager(IBookedSeatDal bookedSeatDal,ITicketService ticketService)
        {
            _bookedSeatDal = bookedSeatDal;
            _ticketService = ticketService;
        }

        [ValidationAspect(typeof(BookedSeatValidator))]
        [SecuredOperation("User,Admin,SuperAdmin")]
        public IDataResult<BookedSeat> Add(BookedSeat seat)
        {
            BookedSeat data = null;
            var result = _ticketService.GetById(seat.TicketId);
            if (result.Success)
            {
                 data = _bookedSeatDal.Add(seat);
                 result.Data.Quantity = result.Data.Quantity - 1;
                _ticketService.Update(result.Data,null);
            }
            return new SuccessDataResult<BookedSeat>(data);
        }

        [SecuredOperation("User,Admin,SuperAdmin")]
        public IResult Delete(BookedSeat seat)
        {
            var result = _ticketService.GetById(seat.TicketId);
            if (result.Success)
            {
                _bookedSeatDal.Delete(seat);
                result.Data.Quantity = result.Data.Quantity + 1;
                _ticketService.Update(result.Data, null);
            }
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
