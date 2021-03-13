using ReCapProject.Core.DataAccess.EntityFramework;
using ReCapProject.DataAccess.Abstract;
using ReCapProject.Entities;
using ReCapProject.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ReCapProject.DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentaCarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentaCarContext context = new RentaCarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join co in context.Colors on c.ColorId equals co.ColorId
                             select new CarDetailDto() { CarId = c.Id, BrandName = b.BrandName, 
                                 ColorName = co.ColorName, Description = c.Description, Price = c.DailyPrice,ModelYear=c.ModelYear };
                return result.ToList();
                             

            }
        }
    }
}
