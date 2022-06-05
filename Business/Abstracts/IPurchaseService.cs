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
    public interface IPurchaseService
    {
        IDataResult<Purchase> Add(Purchase purchase);

        IResult Update(Purchase purchase);

        IResult Delete(Purchase purchase);

        IDataResult<Purchase> GetById(int id);

        IDataResult<List<Purchase>> GetAll();

        IDataResult<List<TicketOrderDto>> GetByUserId(int userId);
    }
}
