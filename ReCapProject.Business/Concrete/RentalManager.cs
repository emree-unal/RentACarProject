using ReCapProject.Business.Abstract;
using ReCapProject.Business.Constants;
using ReCapProject.Business.ValidationRules.FluentValidation;
using ReCapProject.Core.Aspects.Autofac.Validation;
using ReCapProject.Core.Utilities.Result;
using ReCapProject.DataAccess.Abstract;
using ReCapProject.Entities;
using ReCapProject.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProject.Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            this._rentalDal = rentalDal;
        }

        //[ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            var newrentdate = rental.RentDate;
            //select* from rentals where ReturnDate = (select MAX(ReturnDate) from Rentals where CarId = 4)
           var rentalinformation= _rentalDal.GetLastRental(rental.CarId);

            if (rentalinformation==null || rentalinformation.ReturnDate < newrentdate)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalAdded);
            }
            else
            {
                return new ErrorResult(Messages.CarAlreadyRented);
            }
           
            
        }

        public IDataResult<Rental> DateVerification(Rental rental)
        {
            var newrentdate = rental.RentDate;
            //select* from rentals where ReturnDate = (select MAX(ReturnDate) from Rentals where CarId = 4)
            var rentalinformation = _rentalDal.GetLastRental(rental.CarId);

            if (rentalinformation == null || rentalinformation.ReturnDate < newrentdate)
            {
                
                return new SuccessDataResult<Rental>(rental,Messages.CarIsAvailableForRental);
            }
            else
            {
                return new ErrorDataResult<Rental>(rental,Messages.CarAlreadyRented);
            }


        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAllRentals()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(),Messages.RentalsListed);
        }

        public IDataResult<Rental> GetRentalById(int id)
        {
            
            return new SuccessDataResult<Rental>(_rentalDal.Get(x => x.Id == id));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalModified);
        }
    }
}
