using Microsoft.AspNetCore.Http;
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
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(carImage.CarId));
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
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(carImage.CarId));
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
                string path = @"\Images\EmptyImage.jpg";
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

        //List<CarDetailDto> carDetailDtos = new List<CarDetailDto>();
        //CarDetailDto carDetail = new CarDetailDto();

        //ICarImageDal _carImageDal;
        //ICarService _carService;
        //public CarImageManager(ICarImageDal carImageDal, ICarService carService)
        //{
        //    _carImageDal = carImageDal;
        //    _carService = carService;
        //}




        //public IResult Add( IFormFile file, CarImage carImage)
        //{
        //    IResult result = BusinessRules.Run(CheckIfImageLimitExpired(carImage.CarId));
        //    if (result != null)
        //    {
        //        return result;
        //    }
        //    carImage.ImagePath = FileHelper.Add(file);
        //    carImage.Date = DateTime.Now;
        //    _carImageDal.Add(carImage);
        //    return new SuccessResult();
        //}

        //public IResult Delete(CarImage carImage)
        //{
        //    //IResult result = BusinessRules.Run(CheckIfImageExists(carImage.Id));
        //    //if (result != null)
        //    //{
        //    //    return result;
        //    //}
        //    string path = Get(carImage.Id).Data.ImagePath;
        //    FileHelper.Delete(path);
        //    return new SuccessResult();
        //}

        //public IDataResult<List<CarImage>> GetAll()
        //{
        //    return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        //}

        //public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        //{
        //    return new SuccessDataResult<List<CarImage>>(CheckIfCarHaveNoImage(carId));
        //}

        //public IDataResult<CarImage> Get(int id)
        //{
        //    return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == id));
        //}

        //public IResult Update(IFormFile file, CarImage carImage)
        //{
        //    IResult result = BusinessRules.Run(CheckIfImageLimitExpired(carImage.CarId));
        //        //CheckIfImageExtensionValid(file),
        //        //CheckIfImageExists(carImage.Id));
        //    if (result != null)
        //    {
        //        return result;
        //    }
        //    carImage.Date = DateTime.Now;
        //    string OldPath = Get(carImage.Id).Data.ImagePath;
        //    _carImageDal.Update(carImage);
        //    return new SuccessResult();
        //}
        //private IResult CheckIfImageLimitExpired(int carId)
        //{
        //    int result = _carImageDal.GetAll(c => c.CarId == carId).Count;
        //    if (result >= 5)
        //        return new ErrorResult(Messages.CarImageLimitExceeded);
        //    return new SuccessResult();
        //}
        ////private IResult CheckIfImageExtensionValid(IFormFile file)
        ////{
        ////    bool isValidFileExtension = Messages.ValidImageFileTypes.Any(i => i == Path.GetExtension(file.FileName).ToUpper());
        ////    if (!isValidFileExtension)
        ////        return new ErrorResult(Messages.CarImageAdded);
        ////    return new SuccessResult();

        ////}

        //private List<CarImage> CheckIfCarHaveNoImage(int carId)
        //{
        //    string path = "/Images/EmptyImage.jpg";
        //    var result = _carImageDal.GetAll(c => c.CarId == carId);
        //    if (!result.Any())
        //        return new List<CarImage> { new CarImage { CarId = carId, ImagePath = path } };
        //    return result;
        //}
        ////private IResult CheckIfImageExists(int id)
        ////{
        ////    if (_carImageDal.IsExist(id))
        ////        return new SuccessResult();
        ////    return new ErrorResult(Messages.CarImageAddingLimit);
        ////}
        ////public IDataResult<List<CarDetailDto>> CarDtoImageList(List<CarDetailDto> carDetailList)
        ////{
        ////    carDetailDtos.Clear();

        ////    foreach (var item in carDetailList)
        ////    {
        ////        carDetail = item;
        ////        var resultImage = _carImageDal.GetAll(p => p.CarId == item.CarId);
        ////        if (resultImage.Count != 0)
        ////        {
        ////            foreach (var item2 in resultImage)
        ////            {
        ////                carDetail.ImagePath = item2.ImagePath;
        ////                break;
        ////            }
        ////        }
        ////        else
        ////        {

        ////            carDetail.ImagePath = "/Images/default.jpg";


        ////        }
        ////        carDetailDtos.Add(carDetail);
        ////    }
        ////    return new SuccessDataResult<List<CarDetailDto>>(carDetailDtos);
        ////}



    }
}
