using Core.Utilities.Result;
using Entity.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ISalonService
    {
        IDataResult<Salon> Add(Salon salon);

        IResult Update(Salon salon);

        IResult Delete(Salon salon);

        IDataResult<Salon> GetById(int id);

        IDataResult<List<Salon>> GetAll();
    }
}
