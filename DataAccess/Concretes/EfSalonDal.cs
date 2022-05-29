using Core.DataAccess;
using DataAccess.Abstracts;
using Entity.Concretes;


namespace DataAccess.Concretes
{
    public class EfSalonDal : EfEntityRepositoryBase<Salon,AppDbContext>,ISalonDal
    {

    }
}
