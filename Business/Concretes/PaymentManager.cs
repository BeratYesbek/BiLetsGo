using Business.Abstracts;
using Business.Aspects;
using Business.Validation;
using Core.Aspects.Autofac.Validation;
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
    public class PaymentManager : IPaymentService
    {
        private readonly IPaymentDal _paymentDal;

        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }

        [SecuredOperation("User,Admin,SuperAdmin")]
        [ValidationAspect(typeof(PaymentValidator))]
        public IDataResult<Payment> Add(Payment payment)
        {
            return new SuccessDataResult<Payment>(_paymentDal.Add(payment));
        }

        [SecuredOperation("User,Admin,SuperAdmin")]
        public IResult Delete(Payment payment)
        {
            _paymentDal.Delete(payment);
            return new SuccessResult();
        }

        [SecuredOperation("User,Admin,SuperAdmin")]
        public IDataResult<List<Payment>> GetAll()
        {
            return new SuccessDataResult<List<Payment>>(_paymentDal.GetAll());
        }

        [SecuredOperation("User,Admin,SuperAdmin")]
        public IDataResult<Payment> GetById(int id)
        {
            return new SuccessDataResult<Payment>(_paymentDal.Get(t => t.Id == id));
        }

        [SecuredOperation("User,Admin,SuperAdmin")]
        public IDataResult<List<Payment>> GetByUserId(int userId)
        {
            return new SuccessDataResult<List<Payment>>(_paymentDal.GetAll(t => t.UserId == userId));
        }

        [SecuredOperation("User,Admin,SuperAdmin")]
        [ValidationAspect(typeof(PaymentValidator))]
        public IResult Update(Payment payment)
        {
            _paymentDal.Update(payment);
            return new SuccessResult();
        }
    }
}
