using System.Collections.Generic;
using Core.Entity.Concretes;
using Core.Utilities.Result;

namespace Business.Abstracts
{
    public interface IOperationClaimService
    {
        IDataResult<OperationClaim> Add(OperationClaim operationClaim);

        IResult Update(OperationClaim operationClaim);

        IResult Delete(OperationClaim operationClaim);

        IDataResult<OperationClaim> Get(int id);

        IDataResult<OperationClaim> GetByName(string name);

        IDataResult<List<OperationClaim>> GetAll();
    }
}
