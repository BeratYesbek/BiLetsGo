using Core.Entities.Concretes;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Email).NotEmpty().EmailAddress();
            RuleFor(u => u.FullName).NotEmpty();
        }
    }
}
