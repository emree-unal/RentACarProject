using ReCapProject.Business.Abstract;
using ReCapProject.Business.BusinessAspect.Autofac;
using ReCapProject.Business.Constants;
using ReCapProject.Business.ValidationRules.FluentValidation;
using ReCapProject.Core.Aspects.Autofac.Caching;
using ReCapProject.Core.Aspects.Autofac.Performance;
using ReCapProject.Core.Aspects.Autofac.Transaction;
using ReCapProject.Core.Aspects.Autofac.Validation;
using ReCapProject.Core.CrossCuttingConcerns.Validation;
using ReCapProject.Core.Utilities.Result;
using ReCapProject.DataAccess.Abstract;
using ReCapProject.Entities;
using ReCapProject.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ReCapProject.Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal carDal;

        public CarManager(ICarDal carDal)
        {
            this.carDal = carDal;
        }

        //[SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        //[CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            Add(car);
            if (car.DailyPrice>1000)
            {
                throw new Exception("");
            }
            Add(car);
            return null;

        }

       // [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        //[CacheAspect]
        //[SecuredOperation("car.getall,admin")]
        //[PerformanceAspect(4)]
        public IDataResult<List<Car>> GetAllCars()
        {
           // Thread.Sleep(5000);
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
         
            return new SuccessDataResult<List<Car>>(carDal.GetAll(),Messages.CarsListed);
        }

        //[CacheAspect]
        public IDataResult<Car> GetCarById(int id)
        {
            return new SuccessDataResult<Car>(carDal.Get(x => x.Id == id));
        }

        public IDataResult<CarDetailDto> GetCarDetailById(int id)
        {
            return new SuccessDataResult<CarDetailDto>(carDal.GetCarDetailsById(x => x.CarId == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>( carDal.GetCarDetails());
        }

        public IDataResult<List<CarDetailDto>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(carDal.GetCarDetails(x => x.BrandId == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarsByBrandIdAndColorId(int brandId, int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(carDal.GetCarDetails(x => x.BrandId == brandId && x.ColorId==colorId));
        }

        public IDataResult<List<CarDetailDto>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(carDal.GetCarDetails(x => x.ColorId == id));
        }

        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
             carDal.Update(car);
            return new SuccessResult(Messages.CarModified);
        }
    }
}
