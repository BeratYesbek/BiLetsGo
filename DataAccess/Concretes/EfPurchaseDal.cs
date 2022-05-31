using Core.DataAccess;
using DataAccess.Abstracts;
using Entity.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes
{
    public class EfPurchaseDal : EfEntityRepositoryBase<Purchase,AppDbContext>,IPurchaseDal
    {
    }
}
