using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstracts;
using Core.Utilities.Result;
using DataAccess.Abstracts;
using Entity.Concretes;

namespace Business.Concretes
{
    public class TicketManager : ITicketService
    {
        private readonly ITicketDal _ticketDal;
        public TicketManager(ITicketDal ticketDal)
        {
            _ticketDal = ticketDal;
        }

        public IDataResult<Ticket> Add(Ticket ticket)
        {
            var data = _ticketDal.Add(ticket);
            if (data is not null)
            {
                return new SuccessDataResult<Ticket>(data);
            }
            return new ErrorDataResult<Ticket>(null);
        }

        public IResult Update(Ticket ticket)
        {
            _ticketDal.Update(ticket);
            return new SuccessResult();
        }

        public IResult Delete(Ticket ticket)
        {
            _ticketDal.Delete(ticket);
            return new SuccessResult();
        }

        public IDataResult<Ticket> GetById(int id)
        {
            var data = _ticketDal.Get(t => t.Id == id);
            if (data is not null)
            {
                return new SuccessDataResult<Ticket>(data);
            }

            return new ErrorDataResult<Ticket>(null);
        }

        public IDataResult<List<Ticket>> GetAll()
        {
            var data = _ticketDal.GetAll();
            if (data is not null)
            {
                return new SuccessDataResult<List<Ticket>>(data);
            }

            return new ErrorDataResult<List<Ticket>>(null);
        }
    }
}
