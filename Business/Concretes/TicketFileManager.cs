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
    public class TicketFileManager : ITicketFileService
    {
        private readonly ITicketFileDal _ticketFileDal;

        public TicketFileManager(ITicketFileDal ticketFileDal)
        {
            _ticketFileDal = ticketFileDal;
        }

        public IDataResult<TicketFile> Add(TicketFile file)
        {
            var data = _ticketFileDal.Add(file);
            if (data is not null)
            {
                return new SuccessDataResult<TicketFile>(data);
            }

            return new ErrorDataResult<TicketFile>(null);
        }

        public IResult Update(TicketFile file)
        {
            _ticketFileDal.Update(file);
            return new SuccessResult();
        }

        public IResult Delete(TicketFile file)
        {
            _ticketFileDal.Delete(file);
            return new SuccessResult();
        }

        public IDataResult<TicketFile> GetById(int id)
        {
            var data = _ticketFileDal.Get(t => t.Id == id);
            if (data is not null)
            {
                return new SuccessDataResult<TicketFile>(data);
            }

            return new ErrorDataResult<TicketFile>(null);
        }

        public IDataResult<List<TicketFile>> GetAll(int ticketId)
        {
            var data = _ticketFileDal.GetAll(t => t.TicketId == ticketId);
            if (data.Count > 0)
            {
                return new SuccessDataResult<List<TicketFile>>(data);
            }

            return new ErrorDataResult<List<TicketFile>>(null);
        }
    }
}
