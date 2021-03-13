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
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentaCarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {

            using (RentaCarContext context = new RentaCarContext())
            {
                var result = from r in context.Rentals
                             join car in context.Cars on r.CarId equals car.Id
                             join b in context.Brands on car.BrandId equals b.BrandId
                             join c in context.Customers on r.CustomerId equals c.Id
                             join u in context.Users on c.UserId equals u.Id
                           
                             select new RentalDetailDto 
                             {   Id = r.Id, 
                                 BrandName = b.BrandName, 
                                 CustomerNameSurname = u.FirstName +" "+u.LastName, 
                                 RentDate = r.RentDate, 
                                 ReturnDate = r.ReturnDate 
                             };
                return result.ToList();
            }
        }
    }
}
