using Business.Abstracts;
using Business.Validation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concretes;
using Core.Entity.Concretes;
using Core.Utilities.Result;
using DataAccess.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [ValidationAspect(typeof(UserValidator))]
        public IDataResult<User> Add(User user)
        {
            var result = _userDal.Add(user);

            if (result != null)
            {
                return new SuccessDataResult<User>(user);
            }

            return new ErrorDataResult<User>(null);
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult();
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult();
        }


        public IDataResult<User> Get(int id)
        {
            var result = _userDal.Get(u => u.Id == id);
            if (result != null)
            {
                return new SuccessDataResult<User>(result);
            }

            return new ErrorDataResult<User>(result);
        }


        public IDataResult<List<User>> GetAll()
        {
            var result = _userDal.GetAll();
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<User>>(result);
            }

            return new ErrorDataResult<List<User>>(null);
        }


        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }


        public IDataResult<User> GetByMail(string email)
        {
            var result = _userDal.Get(u => u.Email == email);
            if (result != null)
            {
                return new SuccessDataResult<User>(result);
            }

            return new ErrorDataResult<User>(null);
        }

        public IResult UpdateLocation(decimal latitude, decimal longitude, int userId)
        {
            var user = _userDal.Get(t => t.Id == userId);
            if (user != null)
            {

                _userDal.Update(user);
            }

            return new SuccessResult();
        }
    }
}
