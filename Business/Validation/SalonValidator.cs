using Entity.Concretes;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation
{
    public class SalonValidator : AbstractValidator<Salon>
    {
        public SalonValidator()
        {
            RuleFor(s => s.SalonNumber).NotEmpty();
            RuleFor(s => s.Name).NotEmpty();
        }
    }
}
