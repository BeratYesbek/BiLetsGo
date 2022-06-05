using Core.Entities.Concretes;
using Core.Entity.Concretes;
using Core.Utilities.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IUserService
    {
        IDataResult<User> Add(User user);

        IResult Update(User user);

        IResult Delete(User user);

        IDataResult<User> Get(int id);

        IDataResult<List<User>> GetAll();

        List<OperationClaim> GetClaims(User user);

        IDataResult<User> GetByMail(string email);


    }
}
