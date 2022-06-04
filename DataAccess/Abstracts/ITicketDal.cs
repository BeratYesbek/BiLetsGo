using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Entity.Concretes;
using Entity.Concretes.Dto;

namespace DataAccess.Abstracts
{
    public interface ITicketDal : IEntityRepository<Ticket>
    {
        List<TicketReadDto> GetAllDetails(Expression<Func<Ticket,bool>> filter = null);

        TicketReadDto GetTicketDetailById(Expression<Func<Ticket, bool>> filter);

    }
}
