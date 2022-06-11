using Business.Abstracts;
using Business.Aspects;
using Business.Validation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Result;
using DataAccess.Abstracts;
using Entity.Concretes;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace Business.Concretes
{
    public class SalonManager : ISalonService
    {

        private readonly ISalonDal _salonDal;
        public SalonManager(ISalonDal salonDal)
        {
            _salonDal = salonDal;
        }

        [ValidationAspect(typeof(SalonValidator))]
        [SecuredOperation("Admin,SuperAdmin")]
        public IDataResult<Salon> Add(Salon salon)
        {
            var data = _salonDal.Add(salon);
            if (data != null)  
                return new SuccessDataResult<Salon>(data);  
            return new ErrorDataResult<Salon>(data);    
        }

        [SecuredOperation("Admin,SuperAdmin")]
        public IResult Delete(Salon salon)
        {
            _salonDal.Delete(salon);
            return new SuccessDataResult<Salon>(null);  
        }

        [SecuredOperation("User,Admin,SuperAdmin")]
        public IDataResult<List<Salon>> GetAll()
        {
        
           return new SuccessDataResult<List<Salon>>(_salonDal.GetAll());    
        }

        [SecuredOperation("User,Admin,SuperAdmin")]
        public IDataResult<Salon> GetById(int id) 
        {
           return new SuccessDataResult<Salon>(_salonDal.Get(t => t.Id == id));
        }

        [ValidationAspect(typeof(SalonValidator))]
        [SecuredOperation("Admin,SuperAdmin")]
        public IResult Update(Salon salon)
        {
            _salonDal.Update(salon);
            return new SuccessResult();    
        }
    }
}
