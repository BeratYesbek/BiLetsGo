using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstracts;
using Business.Aspects;
using Core.Entity.Concretes;
using Core.Utilities.Result;
using DataAccess.Abstracts;

namespace Business.Concretes
{
    public class OperationClaimManager : IOperationClaimService
    {
        private readonly IOperationClaimDal _operationClaimDal;
        public OperationClaimManager(IOperationClaimDal operationClaimDal)
        {
            _operationClaimDal = operationClaimDal;
        }

        [SecuredOperation("SuperAdmin")]
        public IDataResult<OperationClaim> Add(OperationClaim operationClaim)
        {
            var data = _operationClaimDal.Add(operationClaim);
            if (data != null)
            {
                return new SuccessDataResult<OperationClaim>(data);
            }

            return new ErrorDataResult<OperationClaim>(null);
        }
        [SecuredOperation("SuperAdmin")]
        public IResult Update(OperationClaim operationClaim)
        {
            _operationClaimDal.Update(operationClaim);
            return new SuccessResult();
        }
        [SecuredOperation("SuperAdmin")]
        public IResult Delete(OperationClaim operationClaim)
        {
            _operationClaimDal.Delete(operationClaim);
            return new SuccessResult();
        }

        public IDataResult<OperationClaim> Get(int id)
        {
            var data = _operationClaimDal.Get(t => t.Id == id);
            if (data != null)
            {
                return new SuccessDataResult<OperationClaim>(data);
            }

            return new ErrorDataResult<OperationClaim>(null);
        }

        public IDataResult<List<OperationClaim>> GetAll()
        {
            var data = _operationClaimDal.GetAll();
            if (data.Count > 0)
            {
                return new SuccessDataResult<List<OperationClaim>>(data);
            }

            return new ErrorDataResult<List<OperationClaim>>(null);
        }

        public IDataResult<OperationClaim> GetByName(string name)
        {
            return new SuccessDataResult<OperationClaim>(_operationClaimDal.Get(t => t.Name == name));
        }
    }
}
