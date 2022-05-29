using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Result;
using Entity.Concretes;

namespace Business.Abstracts
{
    public interface ITicketService
    {
        Task<IDataResult<Ticket>> Add(Ticket ticket,TicketFile file);

        Task<IResult> Update(Ticket ticket,TicketFile file);

        IResult Delete(Ticket ticket);

        IDataResult<Ticket> GetById(int id);

        IDataResult<List<Ticket>> GetAll();
    }
}
