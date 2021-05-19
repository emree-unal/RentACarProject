using ReCapProject.Core.DataAccess.EntityFramework;
using ReCapProject.DataAccess.Abstract;
using ReCapProject.Entities;
using ReCapProject.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace ReCapProject.DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentaCarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> expression=null)
        {
            using (RentaCarContext context = new RentaCarContext())
            {

                var result = from c in context.Cars

                                 //from images in context.CarImages.Where(x=>x.CarId==c.Id).ToList()
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join co in context.Colors on c.ColorId equals co.ColorId


                             select new CarDetailDto()
                             {
                                 CarId = c.Id,
                                 ColorId = co.ColorId,
                                 BrandId = b.BrandId,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 Description = c.Description,
                                 Price = c.DailyPrice,
                                 ModelYear = c.ModelYear,
                                 ImagePath = (from i in context.CarImages where i.CarId == c.Id select i.ImagePath).FirstOrDefault()

                             };
                return expression == null ? result.ToList()
                    : result.Where(expression).ToList();


            }
        }

        public CarDetailDto GetCarDetailsById(Expression<Func<CarDetailDto, bool>> expression = null)
        {
            using (RentaCarContext context = new RentaCarContext())
            {

                var result = from c in context.Cars

                                 //from images in context.CarImages.Where(x=>x.CarId==c.Id).ToList()
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join co in context.Colors on c.ColorId equals co.ColorId


                             select new CarDetailDto()
                             {
                                 CarId = c.Id,
                                 ColorId = co.ColorId,
                                 BrandId = b.BrandId,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 Description = c.Description,
                                 Price = c.DailyPrice,
                                 ModelYear = c.ModelYear,
                                 ImagePath = (from i in context.CarImages where i.CarId == c.Id select i.ImagePath).FirstOrDefault()

                             };
                return expression == null ? result.FirstOrDefault()
                    : result.Where(expression).FirstOrDefault();


            }
        }
    }
}
