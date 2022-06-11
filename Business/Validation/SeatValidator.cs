using Entity.Concretes;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation
{
    public class SeatValidator : AbstractValidator<Seat>
    {
        public SeatValidator()
        {
            RuleFor(s => s.SalonId ).NotEmpty();
            RuleFor(s => s.SeatNumber).NotEmpty();  
        }
    }
}
