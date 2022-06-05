

using Business.Abstracts;
using Core.Entities.Concretes;
using Core.Entity.Concretes;
using Core.Utilities.Result;
using DataAccess.Abstracts;
using System.Collections.Generic;

namespace Business.Concretes
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        private readonly IUserOperationClaimDal _userOperationClaimDal;
        private readonly IOperationClaimService _operationClaimService;
        public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal, IOperationClaimService operationClaimService)
        {
            _userOperationClaimDal = userOperationClaimDal;
            _operationClaimService = operationClaimService;
        }

        public IDataResult<UserOperationClaim> Add(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimDal.Add(userOperationClaim);
            return new SuccessDataResult<UserOperationClaim>(null, "");
        }


        public IResult Update(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimDal.Update(userOperationClaim);
            return new SuccessResult();
        }

        public IResult Delete(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimDal.Delete(userOperationClaim);
            return new SuccessResult();
        }

        public IDataResult<UserOperationClaim> Get(int id)
        {
            var data = _userOperationClaimDal.Get(u => u.Id == id);
            if (data != null)
            {
                return new SuccessDataResult<UserOperationClaim>(data);
            }

            return new ErrorDataResult<UserOperationClaim>(null);
        }


        public IDataResult<List<UserOperationClaim>> GetAll()
        {
            var data = _userOperationClaimDal.GetAll();
            if (data.Count > 0)
            {
                return new SuccessDataResult<List<UserOperationClaim>>(data);
            }

            return new ErrorDataResult<List<UserOperationClaim>>(null);
        }

        public IDataResult<UserOperationClaim> AddDefaultRole(User user)
        {
            var operationClaim = _operationClaimService.GetByName("User").Data;
            if (operationClaim is not null)
            {
                var data = _userOperationClaimDal.Add(new UserOperationClaim
                {
                    UserId = user.Id,
                    OperationClaimId = operationClaim.Id
                });
                return new SuccessDataResult<UserOperationClaim>(data);
            }
            return new ErrorDataResult<UserOperationClaim>(null);

        }
    }
}