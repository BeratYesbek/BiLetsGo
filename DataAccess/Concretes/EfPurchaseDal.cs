using Core.DataAccess;
using DataAccess.Abstracts;
using Entity.Concretes;
using Entity.Concretes.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes
{
    public class EfPurchaseDal : EfEntityRepositoryBase<Purchase, AppDbContext>, IPurchaseDal
    {
        public List<TicketOrderDto> GetByUserId(int userId)
        {
            using(var context = new AppDbContext())
            {
                var result = from purchase in context.Purchases.Where(t => t.UserId == userId)
                             join ticket in context.Tickets on purchase.TicketId equals ticket.Id
                             join bookedSeat in context.BookedSeats on purchase.Id equals bookedSeat.PurchaseId
                             join category in context.Categories on ticket.CategoryId equals category.Id
                             join salon in context.Salons on ticket.SalonId equals salon.Id
                             select new TicketOrderDto
                             {
                                 Ticket = ticket,
                                 Category = category,
                                 Salon = salon,
                                 Images = (from images in context.TicketFiles where ticket.Id == images.TicketId select images.ImagePath).ToList(),
                                 bookedSeat = bookedSeat,
                                 purchase = purchase
                                

                             };

                return result.ToList();
            }
        }
    }
}
