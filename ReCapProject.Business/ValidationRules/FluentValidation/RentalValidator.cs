using FluentValidation;
using ReCapProject.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProject.Business.ValidationRules.FluentValidation
{
    public class RentalValidator:AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.CarId).NotEmpty();
            RuleFor(r => r.CustomerId).NotEmpty();
            RuleFor(r => r.RentDate).NotEmpty();
            RuleFor(r => r.ReturnDate).NotEmpty().GreaterThan(DateTime.Now);


        }

     

        //private bool BeforeDateTime(DateTime arg)
        //{
        //    if (arg<DateTime.Now)
        //    {
        //        return false;
        //    }
        //    return true;
        //}
    }
}
