using Core.DataAccess;
using Core.Entities.Concretes;
using Core.Entity.Concretes;
using DataAccess.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes
{
    public class EfUserDal : EfEntityRepositoryBase<User,AppDbContext>,IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new AppDbContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join UserOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals UserOperationClaim.OperationClaimId
                             where UserOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };

                return result.ToList();
            }
        }
    }
}
