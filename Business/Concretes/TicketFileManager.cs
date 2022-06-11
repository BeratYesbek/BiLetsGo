using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstracts;
using Business.Aspects;
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

        [SecuredOperation("Admin,SuperAdmin")]
        public IDataResult<TicketFile> Add(TicketFile file)
        {
            var data = _ticketFileDal.Add(file);
            if (data is not null)
            {
                return new SuccessDataResult<TicketFile>(data);
            }

            return new ErrorDataResult<TicketFile>(null);
        }

        [SecuredOperation("Admin,SuperAdmin")]
        public IResult Update(TicketFile file)
        {
            _ticketFileDal.Update(file);
            return new SuccessResult();
        }

        [SecuredOperation("Admin,SuperAdmin")]
        public IResult Delete(TicketFile file)
        {
            _ticketFileDal.Delete(file);
            return new SuccessResult();
        }


        [SecuredOperation("User,Admin,SuperAdmin")]
        public IDataResult<TicketFile> GetById(int id)
        {
            var data = _ticketFileDal.Get(t => t.Id == id);
            if (data is not null)
            {
                return new SuccessDataResult<TicketFile>(data);
            }

            return new ErrorDataResult<TicketFile>(null);
        }

        [SecuredOperation("User,Admin,SuperAdmin")]
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
