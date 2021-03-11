﻿using Microsoft.AspNetCore.Http;
using ReCapProject.Business.Abstract;
using ReCapProject.Business.Constants;
using ReCapProject.Core.Utilities.Business;
using ReCapProject.Core.Utilities.Helpers;
using ReCapProject.Core.Utilities.Result;
using ReCapProject.DataAccess.Abstract;
using ReCapProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReCapProject.Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDAL;

        public CarImageManager(ICarImageDal carImageDAL)
        {
            _carImageDAL = carImageDAL;
        }

        
        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result =BusinessRules.Run(CheckImageLimitExceeded(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = FileHelper.Add(file);
            carImage.Date = DateTime.Now;
            _carImageDAL.Add(carImage);
            return new SuccessResult();
        }

      
        public IResult Delete(CarImage carImage)
        {
            FileHelper.Delete(carImage.ImagePath);
            _carImageDAL.Delete(carImage);
            return new SuccessResult();
        }

      
        public IResult Update(IFormFile file, CarImage carImage)
        {
            IResult result =BusinessRules.Run(CheckImageLimitExceeded(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = FileHelper.Update(_carImageDAL.Get(p => p.Id == carImage.Id).ImagePath, file);
            carImage.Date = DateTime.Now;
            _carImageDAL.Update(carImage);
            return new SuccessResult();
        }

    
        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDAL.Get(p => p.Id == id));
        }

    
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDAL.GetAll());
        }

  
        public IDataResult<List<CarImage>> GetImagesByCarId(int id)
        {
            IResult result = CheckIfCarImageNull(id);

            if (result == null)
            {
                return new ErrorDataResult<List<CarImage>>(result.Message);
            }

            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(id).Data);
        }

        //business rules
        private IResult CheckImageLimitExceeded(int carid)
        {
            var carImagecount = _carImageDAL.GetAll(p => p.CarId == carid).Count;
            if (carImagecount >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded);
            }

            return new SuccessResult();
        }

     
        private IDataResult<List<CarImage>> CheckIfCarImageNull(int id)
        {
            try
            {
                string path = @"\wwwroot\Images\EmptyImage.jpg";
                var result = _carImageDAL.GetAll(c => c.CarId == id).Any();
                if (!result)
                {
                    List<CarImage> carimage = new List<CarImage>();
                    carimage.Add(new CarImage { CarId = id, ImagePath = path, Date = DateTime.Now });
                    return new SuccessDataResult<List<CarImage>>(carimage);
                }
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<List<CarImage>>(exception.Message);
            }

            return new SuccessDataResult<List<CarImage>>(_carImageDAL.GetAll(p => p.CarId == id).ToList());
        }



    
     }
}
