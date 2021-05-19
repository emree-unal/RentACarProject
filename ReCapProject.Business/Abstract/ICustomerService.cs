using ReCapProject.Core.Utilities.Result;
using ReCapProject.Entities;
using ReCapProject.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProject.Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAllCustomers();
        IDataResult<List<CustomerDetailDto>> GetCustomersDetail();
        IDataResult<Customer> GetCustomerById(int id);
        IResult Add(Customer customer);
        IResult Delete(Customer customer);
        IResult Update(Customer customer);
    }
}
