using Core.Utilities.Result;
using Entity.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IPaymentService
    {
        IDataResult<Payment> Add(Payment payment);

        IResult Update(Payment payment);

        IResult Delete(Payment payment);

        IDataResult<Payment> GetById(int id);

        IDataResult<List<Payment>> GetAll();

        IDataResult<List<Payment>> GetByUserId(int userId);

    }
}
