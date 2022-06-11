using Entity.Concretes;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation
{
    public class PurchaseValidator : AbstractValidator<Purchase>
    {
        public PurchaseValidator()
        {
            RuleFor(p => p.Address).NotEmpty();
            RuleFor(p => p.Phone).Length(10).NotEmpty(); 
            RuleFor(p => p.SocialIdentity).Length(11).NotEmpty();  
            RuleFor(p => p.TicketId).NotEmpty();
        }
    }
}
