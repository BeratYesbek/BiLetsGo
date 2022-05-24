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
    public class SalonManager : ISalonService
    {

        private readonly ISalonDal _salonDal;
        public SalonManager(ISalonDal salonDal)
        {
            _salonDal = salonDal;
        }
        public IDataResult<Salon> Add(Salon salon)
        {
            var data = _salonDal.Add(salon);
            if (data != null)  
                return new SuccessDataResult<Salon>(data);  
            return new ErrorDataResult<Salon>(data);    
        }

        public IResult Delete(Salon salon)
        {
            _salonDal.Delete(salon);
            return new SuccessDataResult<Salon>(null);  
        }

        public IDataResult<List<Salon>> GetAll()
        {
           return new SuccessDataResult<List<Salon>>(_salonDal.GetAll());    
        }

        public IDataResult<Salon> GetById(int id) 
        {
           return new SuccessDataResult<Salon>(_salonDal.Get(t => t.Id == id));
        } 
        

        public IResult Update(Salon salon)
        {
            _salonDal.Update(salon);
            return new SuccessResult();    
        }
    }
}
