using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Concretes;
using FluentValidation;
namespace Business.Validation
{
    public class PaymentValidator : AbstractValidator<Payment>
    {
        public PaymentValidator()
        {
            RuleFor(p => p.Year).NotEmpty().GreaterThanOrEqualTo(2022);
            RuleFor(p => p.Month).NotEmpty().GreaterThan(0);
            RuleFor(p => p.CardNumber).NotEmpty().Length(16);
            RuleFor(p => p.Cvv).NotEmpty();
            RuleFor(p => p.UserId).NotEmpty();
            RuleFor(p => p.NameOnTheCard).NotEmpty();

        }
    }
}
