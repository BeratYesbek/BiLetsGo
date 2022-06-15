using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstracts;
using Business.Aspects;
using Business.Validation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.FileHelper;
using Core.Utilities.Result;
using DataAccess.Abstracts;
using Entity.Concretes;
using Entity.Concretes.Dto;

namespace Business.Concretes
{
    public class TicketManager : ITicketService
    {
        private readonly ITicketDal _ticketDal;
        private readonly ITicketFileService _ticketFileService;
        public TicketManager(ITicketDal ticketDal,ITicketFileService ticketFileService)
        {
            _ticketDal = ticketDal;
            _ticketFileService = ticketFileService;
        }

        [ValidationAspect(typeof(TicketValidator))]
        [SecuredOperation("Admin,SuperAdmin")]
        public async Task<IDataResult<Ticket>> Add(Ticket ticket,TicketFile files)
        {
            var result = _ticketDal.Add(ticket);
            foreach(var file in files.Files)
            {
                var fileHelper = new FileHelper(RecordType.Cloud, FileExtension.ImageExtension);
                var fileResult = await fileHelper.UploadAsync(file);
                if (fileResult.Success)
                {
                    var resultImage = _ticketFileService.Add(new TicketFile
                    {
                        ImagePath = fileResult.Message.Split("&&")[0],
                        PublicId = fileResult.Message.Split("&&")[1],
                        TicketId = result.Id
                    });
                    if (!resultImage.Success)
                    {
                        return new ErrorDataResult<Ticket>(null);
                    }
                }
            }
            return new SuccessDataResult<Ticket>(result);
        }

        [ValidationAspect(typeof(TicketValidator))]
        [SecuredOperation("Admin,SuperAdmin")]
        public async Task<IResult> Update(Ticket ticket,TicketFile ticketFile)
        {
            if(ticketFile.Files is not null &&  ticketFile.Files.Count() > 0)
            {
                var image = _ticketFileService.GetAll(ticketFile.Id);
                var fileHelper = new FileHelper(RecordType.Cloud, FileExtension.ImageExtension);
                for (int i =0; i < ticketFile.Files.Count(); i++)
                {
                    var fileResult = await fileHelper.UpdateAsync(ticketFile.Files[i], image.Data[i].ImagePath, image.Data[i].PublicId);
                    var result = _ticketFileService.Update(new TicketFile
                    {
                        ImagePath = fileResult.Message.Split("&&")[0],
                        PublicId = fileResult.Message.Split("&&")[1],
                        TicketId = ticket.Id,
                        Id = image.Data[i].Id
                    });
                    if (!result.Success)
                    {
                        return new ErrorResult();
                    }
                }
            }
            _ticketDal.Update(ticket);
            return new SuccessResult();
        }

        public IResult UpdateQuantity(Ticket ticket)
        {
            _ticketDal.Update(ticket);
            return new SuccessResult();
        }

        [SecuredOperation("Admin,SuperAdmin")]
        public IResult Delete(Ticket ticket)
        {
            _ticketDal.Delete(ticket);
            return new SuccessResult();
        }
        [SecuredOperation("User,Admin,SuperAdmin")]
        public IDataResult<Ticket> GetById(int id)
        {
            var data = _ticketDal.Get(t => t.Id == id);
            if (data is not null)
            {
                return new SuccessDataResult<Ticket>(data);
            }

            return new ErrorDataResult<Ticket>(null);
        }

        [SecuredOperation("User,Admin,SuperAdmin")]
        public IDataResult<List<Ticket>> GetAll()
        {
            var data = _ticketDal.GetAll();
            if (data is not null)
            {
                return new SuccessDataResult<List<Ticket>>(data);
            }

            return new ErrorDataResult<List<Ticket>>(null);
        }

        //[SecuredOperation("User,Admin,SuperAdmin")]
        public IDataResult<List<TicketReadDto>> GetAllDetails()
        {
            return new SuccessDataResult<List<TicketReadDto>>(_ticketDal.GetAllDetails());

        }
        [SecuredOperation("User,Admin,SuperAdmin")]
        public IDataResult<TicketReadDto> GetTicketDetailById(int id)
        {
            return new SuccessDataResult<TicketReadDto>(_ticketDal.GetTicketDetailById(t => t.Id == id));
        }
    }
}
