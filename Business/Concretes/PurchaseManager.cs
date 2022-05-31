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
    public class PurchaseManager : IPurchaseService
    {
        private readonly IPurchaseDal _purchaseDal;

        public PurchaseManager(IPurchaseDal purchaseDal)
        {
            _purchaseDal = purchaseDal;
        }

        public IDataResult<Purchase> Add(Purchase purchase)
        {
            _purchaseDal.Add(purchase);
            return new SuccessDataResult<Purchase>(purchase);
        }

        public IResult Delete(Purchase purchase)
        {
            _purchaseDal.Delete(purchase);
            return new SuccessResult();
        }

        public IDataResult<List<Purchase>> GetAll()
        {
            var data = _purchaseDal.GetAll();
            if (data.Count > 0)
            {
                return new SuccessDataResult<List<Purchase>>(data);
            }
            return new ErrorDataResult<List<Purchase>>(data);
        }

        public IDataResult<Purchase> GetById(int id)
        {
            var data = _purchaseDal.Get(t => t.Id == id);
            if (data is not null)
                return new SuccessDataResult<Purchase>(data);
            return new ErrorDataResult<Purchase>(data);
        }

        public IResult Update(Purchase purchase)
        {
            _purchaseDal.Update(purchase);
            return new SuccessResult();
        }
    }
}
