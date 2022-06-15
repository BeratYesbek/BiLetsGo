using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using DataAccess.Abstracts;
using Entity.Concretes;
using Entity.Concretes.Dto;

namespace DataAccess.Concretes
{
    public class EfTicketDal : EfEntityRepositoryBase<Ticket, AppDbContext>, ITicketDal
    {
        public List<TicketReadDto> GetAllDetails(Expression<Func<Ticket, bool>> filter = null)
        {
            using(var context = new AppDbContext())
            {
                var result = from ticket in context.Tickets.Where(t => t.EventFinishedDate < DateTime.Now) 
                             join category in context.Categories on ticket.CategoryId equals category.Id
                             join salon in context.Salons on ticket.SalonId equals salon.Id
                             select new TicketReadDto
                             {
                                 Ticket = ticket,
                                 Category = category,
                                 Salon = salon,
                                 Images = (from images in context.TicketFiles where ticket.Id == images.TicketId select images.ImagePath).ToList(),
                                 Seats = (from seats in context.Seats where salon.Id == seats.SalonId select seats).ToList()
                             };

                return result.ToList();
            }

        }

        public TicketReadDto GetTicketDetailById(Expression<Func<Ticket, bool>> filter)
        {
            using(var context = new AppDbContext())
            {
                var result = from ticket in context.Tickets.Where(filter)
                             join category in context.Categories on ticket.CategoryId equals category.Id
                             join salon in context.Salons on ticket.SalonId equals salon.Id
                             select new TicketReadDto
                             {
                                 Ticket = ticket,
                                 Category = category,
                                 Salon = salon,
                                 Images = (from images in context.TicketFiles where ticket.Id == images.TicketId select images.ImagePath).ToList(),
                                 Seats = (from seats in context.Seats where salon.Id == seats.SalonId select seats).ToList()
                             };
                return result.FirstOrDefault();
            }
        }
    }
}
