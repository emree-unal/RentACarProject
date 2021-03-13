using ReCapProject.Core.Utilities.Result;
using ReCapProject.Entities;
using ReCapProject.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProject.Business.Abstract
{
    public interface IRentalService
    {

        IDataResult<List<Rental>> GetAllRentals();
        IDataResult<Rental> GetRentalById(int id);
        IResult Add(Rental rental);
        IResult Delete(Rental rental);
        IResult Update(Rental rental);
        IDataResult<List<RentalDetailDto>> GetRentalDetails();
    }
}
