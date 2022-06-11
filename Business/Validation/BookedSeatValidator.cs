using Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation
{
    public class BookedSeatValidator : AbstractValidator<BookedSeat>
    {
        public BookedSeatValidator()
        {
            RuleFor(t => t.PurchaseId).NotEmpty();
            RuleFor(t => t.UserId).NotEmpty();
        }
    }
}
