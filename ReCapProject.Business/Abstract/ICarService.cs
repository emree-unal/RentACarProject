using ReCapProject.Core.Utilities.Result;
using ReCapProject.Entities;
using ReCapProject.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProject.Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAllCars();
        IDataResult<Car> GetCarById(int id);
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<CarDetailDto> GetCarDetailById(int id);
        IDataResult<List<CarDetailDto>> GetCarsByBrandId(int id);
        IDataResult<List<CarDetailDto>> GetCarsByColorId(int id);
        IDataResult<List<CarDetailDto>> GetCarsByBrandIdAndColorId(int brandId, int colorId);

        IResult AddTransactionalTest (Car car);

    }
}
