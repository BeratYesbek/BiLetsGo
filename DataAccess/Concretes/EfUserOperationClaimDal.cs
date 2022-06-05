using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Core.Entity.Concretes;
using DataAccess.Abstracts;

namespace DataAccess.Concretes
{
    public class EfUserOperationClaimDal : EfEntityRepositoryBase<UserOperationClaim, AppDbContext>, IUserOperationClaimDal
    {
    }
}