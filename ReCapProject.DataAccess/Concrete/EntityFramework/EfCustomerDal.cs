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
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, RentaCarContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (RentaCarContext context = new RentaCarContext())
            {

                var result = from c in context.Customers

                             join u in context.Users on c.UserId equals u.Id
                            
                             select new CustomerDetailDto()
                             {
                                CustomerId=c.Id,
                                CompanyName=c.CompanyName,
                                UserName=u.FirstName+" "+u.LastName

                             };
                return result.ToList();

            }
        }
    }
}
