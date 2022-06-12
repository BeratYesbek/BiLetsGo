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
            RuleFor(t => t.Title).NotEmpty().MinimumLength(10);
            RuleFor(t => t.Description).NotEmpty().MinimumLength(50);
            RuleFor(t => t.Price).NotEmpty().GreaterThan(0);
            RuleFor(t => t.Quantity).NotEmpty().GreaterThan(0);
            RuleFor(t => t.SalonId).NotEmpty();


        }
    }
}
