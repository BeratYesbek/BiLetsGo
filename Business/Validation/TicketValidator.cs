using Entity.Concretes;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation
{
    public class TicketValidator : AbstractValidator<Ticket>
    {
        public TicketValidator()
        {
            RuleFor(t => t.CategoryId).NotEmpty();
            RuleFor(t => t.EventFinishedDate).NotEmpty();
            RuleFor(t => t.EventStartedDate).NotEmpty();
            RuleFor(t => t.Title).NotEmpty().Length(10);
            RuleFor(t => t.Description).NotEmpty().Length(50);
            RuleFor(t => t.Price).NotEmpty().LessThan(0);
            RuleFor(t => t.Quantity).NotEmpty().LessThan(0);
            RuleFor(t => t.SalonId).NotEmpty();


        }
    }
}
