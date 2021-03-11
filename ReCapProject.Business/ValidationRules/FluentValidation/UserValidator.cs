using FluentValidation;
using ReCapProject.Core.Entities.Concrete;
using ReCapProject.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProject.Business.ValidationRules.FluentValidation
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty().MinimumLength(3);
            RuleFor(u => u.LastName).NotEmpty().MinimumLength(2);
            RuleFor(u => u.Email).NotEmpty().EmailAddress();
         

        }
    }
}
