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
    public class PurchaseManager : IPurchaseService
    {
        private readonly IPurchaseDal _purchaseDal;
        private readonly IBookedSeatService _bookedSeatService;

        public PurchaseManager(IPurchaseDal purchaseDal,IBookedSeatService bookedSeatService)
        {
            _purchaseDal = purchaseDal;
            _bookedSeatService = bookedSeatService;
        }

        [SecuredOperation("User,Admin,SuperAdmin")]
        [ValidationAspect(typeof(PurchaseValidator))]
        public IDataResult<Purchase> Add(Purchase purchase)
        {
            _purchaseDal.Add(purchase);
            return new SuccessDataResult<Purchase>(purchase);
        }

        [SecuredOperation("User,Admin,SuperAdmin")]
        public IResult Delete(Purchase purchase)
        {
            _purchaseDal.Delete(purchase);
            var data = _bookedSeatService.GetByPurchaseId(purchase.Id).Data;
            _bookedSeatService.Delete(data);

            return new SuccessResult();
        }

        [SecuredOperation("User,Admin,SuperAdmin")]
        public IDataResult<List<Purchase>> GetAll()
        {
            var data = _purchaseDal.GetAll();
            if (data.Count > 0)
            {
                return new SuccessDataResult<List<Purchase>>(data);
            }
            return new ErrorDataResult<List<Purchase>>(data);
        }

        [SecuredOperation("User,Admin,SuperAdmin")]
        public IDataResult<Purchase> GetById(int id)
        {
            var data = _purchaseDal.Get(t => t.Id == id);
            if (data is not null)
                return new SuccessDataResult<Purchase>(data);
            return new ErrorDataResult<Purchase>(data);
        }

        [SecuredOperation("User,Admin,SuperAdmin")]
        public IDataResult<List<TicketOrderDto>> GetByUserId(int userId)
        {
            return new SuccessDataResult<List<TicketOrderDto>>(_purchaseDal.GetByUserId(userId));

        }

        [ValidationAspect(typeof(PurchaseValidator))]
        [SecuredOperation("User,Admin,SuperAdmin")]
        public IResult Update(Purchase purchase)
        {
            _purchaseDal.Update(purchase);
            return new SuccessResult();
        }
    }
}
