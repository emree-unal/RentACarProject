using FluentValidation;
using ReCapProject.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProject.Business.ValidationRules.FluentValidation
{
    public class CustomerValidator:AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.UserId).NotEmpty();
            RuleFor(customer => customer.CompanyName).NotEmpty().MinimumLength(2);
        }
    }
}
