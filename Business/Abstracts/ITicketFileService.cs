using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Result;
using Entity.Concretes;

namespace Business.Abstracts
{
    public interface ITicketFileService
    {
        IDataResult<TicketFile> Add(TicketFile file);

        IResult Update(TicketFile file);

        IResult Delete(TicketFile file);

        IDataResult<TicketFile> GetById(int id);

        IDataResult<List<TicketFile>> GetAll(int ticketId);
    }
}
