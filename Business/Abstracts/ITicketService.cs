using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Result;
using Entity.Concretes;
using Entity.Concretes.Dto;

namespace Business.Abstracts
{
    public interface ITicketService
    {
        Task<IDataResult<Ticket>> Add(Ticket ticket,TicketFile file);

        Task<IResult> Update(Ticket ticket,TicketFile file);

        IResult UpdateQuantity(Ticket ticket);

        IResult Delete(Ticket ticket);

        IDataResult<Ticket> GetById(int id);

        IDataResult<List<Ticket>> GetAll();

        IDataResult<List<TicketReadDto>> GetAllDetails();

        IDataResult<TicketReadDto> GetTicketDetailById(int id);


    }
}
